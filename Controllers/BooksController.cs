using Microsoft.AspNetCore.Mvc;
using bibliotek.Models;
using System.Linq;
using Newtonsoft.Json;

namespace bibliotek.Controllers
{
    public class BooksController : Controller
    {
        // En statisk lista av böcker som används för att simulera en databas i detta exempel
        private static List<Book> books = new List<Book>
        {
            // Skapar några exempelböcker
            new Book { Id = 1, Title = "1984", Author = "George Orwell", Year = 1949 },
            new Book { Id = 2, Title = "To Kill a Mockingbird", Author = "Harper Lee" }
        };

        // GET: Visa listan av böcker
        public IActionResult Index()
        {
            // Lägger till antalet böcker i ViewBag för att kunna använda det i vyer
            ViewBag.BookCount = books.Count;

            // Returnerar vyn med listan av böcker
            return View(books);
        }

        // GET: Skapa en ny bok (visar formuläret)
        public IActionResult Create()
        {
            // Returnerar vyn för att skapa en ny bok
            return View();
        }

        // GET: Om sidan (visar information om webbapplikationen)
        [Route("om-sidan")]
        public IActionResult OmSidan()
        {
            // Skickar appinformation och teknologier till vyn via ViewData
            ViewData["AppInfo"] = "Denna webbapplikation är byggd med ASP.NET Core MVC och hanterar en lista med böcker.";
            ViewData["Technologies"] = new string[] { "ASP.NET Core MVC", "Razor Views" };
            
            // Returnerar vyn för Om-sidan
            return View();
        }

        // POST: Skapa en ny bok (hanterar inskickad data)
        [HttpPost]
        public IActionResult Create(Book book)
        {
            // Kontrollera att modellen är giltig (t.ex. att alla obligatoriska fält är ifyllda)
            if (ModelState.IsValid)
            {
                // Sätter id på boken till ett nytt värde baserat på det högsta id:t i listan
                book.Id = books.Any() ? books.Max(b => b.Id) + 1 : 1;
                
                // Lägger till den nya boken i listan
                books.Add(book);
                
                // Omdirigerar till Index-sidan efter att ha sparat boken
                return RedirectToAction("Index");
            }

            // Om modellen inte är giltig, returnerar formuläret igen med eventuella valideringsfel
            return View(book);
        }

        // POST: Ta bort en bok
        // För en mer RESTful tillvägagångssätt borde [HttpDelete] användas, men här används [HttpPost] för enkelhetens skull
        [HttpPost]
        public IActionResult Delete(int id)
        {
            // Söker efter boken med det angivna id:t
            var book = books.FirstOrDefault(b => b.Id == id);

            // Om boken finns, tas den bort från listan
            if (book != null)
            {
                books.Remove(book);
                // Omdirigerar till Index-sidan efter att ha tagit bort boken
                return RedirectToAction("Index");
            }

            // Om boken inte hittades, returneras NotFound
            return NotFound();
        }

        // GET: Redigera bok (visar formuläret för att redigera en bok)
        public IActionResult Edit(int id)
        {
            // Söker efter boken med det angivna id:t
            var book = books.FirstOrDefault(b => b.Id == id);

            // Om boken inte finns, returneras NotFound
            if (book == null)
            {
                return NotFound();
            }

            // Returnerar vyn med boken som ska redigeras
            return View(book);
        }

        // POST: Uppdatera bok (hanterar inskickad data för att uppdatera en bok)
        [HttpPost]
        public IActionResult Edit(int id, Book book)
        {
            // Söker efter den existerande boken med det angivna id:t
            var existingBook = books.FirstOrDefault(b => b.Id == id);

            // Om boken inte finns, returneras NotFound
            if (existingBook == null)
            {
                return NotFound();
            }

            // Kontrollera att modellen är giltig innan uppdatering
            if (ModelState.IsValid)
            {
                // Uppdaterar egenskaperna för den existerande boken
                existingBook.Title = book.Title;
                existingBook.Author = book.Author;
                existingBook.Year = book.Year;
                existingBook.Genre = book.Genre;  
                existingBook.IsFavorite = book.IsFavorite;
                existingBook.IsRead = book.IsRead;

                // Omdirigerar till Index-sidan efter att ha uppdaterat boken
                return RedirectToAction("Index");
            }

            // Om modellen inte är giltig, returneras formuläret igen med valideringsfel
            return View(book);
        }
    }
}
