using Microsoft.AspNetCore.Mvc;
using Proyect_mvc.Models;

namespace Proyect_mvc.Controllers
{
    public class FormularioController : Controller
    {
 
        public IActionResult Index(string TextBoxNombre, string TextBoxApellidos, string TextBoxDireccion, string TextBoxRequerimiento)
        {
            var path = "/home/pickle/RiderProjects/Proyect-mvc/Models/Ciudades.txt";
            string contenido = System.IO.File.ReadAllText(path);
            string []ciudades = contenido.Split('\n');
            var mi_formulario = new Formulario();
            mi_formulario.Ciudad = new List<string>();
            foreach(string line in ciudades)
            {
                (mi_formulario.Ciudad).Add(line);
            }
            mi_formulario.Nombres = TextBoxNombre;
            mi_formulario.Apellidos = TextBoxApellidos;
            mi_formulario.Direccion = TextBoxDireccion;
            mi_formulario.Requerimiento = TextBoxRequerimiento;

            return View(mi_formulario);

        }
        
        
        /*public IActionResult Index(string TextBoxNombre)
        {
            var mi_form = new Formulario();
            mi_form.Nombrecito = TextBoxNombre;
            //return Content($"Nombre: {TextBoxNombre}");
            return View(mi_form);
        }*/
    }
}
