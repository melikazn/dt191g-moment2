document.addEventListener("DOMContentLoaded", function () {
    // Hämta elementet för cookie-popupen
    const cookiePopup = document.getElementById("cookiePopup");

    // Om användaren inte har accepterat cookies (
    if (!localStorage.getItem("cookiesAccepted")) {
        // Visa cookie-popupen
        cookiePopup.style.display = "block";
    }

    // Lägg till en klick-händelse på knappen för att acceptera cookies
    document.querySelector("#cookiePopup button").addEventListener("click", function () {
        // Sätt "cookiesAccepted" till true i localStorage så att popupen inte visas igen nästa gång användaren besöker sidan
        localStorage.setItem("cookiesAccepted", "true");
        // Dölja cookie-popupen
        cookiePopup.style.display = "none";
    });
});


