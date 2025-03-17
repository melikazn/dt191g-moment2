document.addEventListener("DOMContentLoaded", function() {
    const form = document.querySelector("form");

    // Om formuläret finns på sidan
    if (form) {
        // Lägg till en eventlistener för formulärets 'submit' händelse
        form.addEventListener("submit", function (event) {
            // Hämta värdet för genre från select-elementet
            const genre = document.getElementById("Genre").value;

            // Kontrollera om genre inte är vald (om värdet är tomt)
            if (!genre) {
                // Visa ett meddelande till användaren om att välja en genre
                alert("Vänligen välj en genre!");
                // Förhindra att formuläret skickas 
                event.preventDefault();  
            }
        });
    }
});
