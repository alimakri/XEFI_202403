using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    public class VoitureController : Controller
    {
        public IActionResult Accueil()
        {
            var contenu = System.IO.File.ReadAllText(@"d:\accueil.html");
            return Content(contenu, "text/html", System.Text.Encoding.UTF8);
        }
        public IActionResult Modele()
        {
            var v1 = new Voiture { Modele = "Prius", Marque = "Toyota" };
            var contenu = System.IO.File.ReadAllText(@"d:\modele.html");
            var contenuAmeliore = contenu.Replace("@modele", v1.Modele).Replace("@marque", v1.Marque);
            return Content(contenuAmeliore, "text/html", System.Text.Encoding.UTF8);
        }
        public IActionResult Modele2()
        {
            var v1 = new Voiture { Modele = "Prius", Marque = "Toyota" };
            ViewBag.Personne = "Ali MAKRI";
            return View(v1);
        }
    }
}
