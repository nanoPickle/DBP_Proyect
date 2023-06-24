using Microsoft.AspNetCore.Mvc;
using Proyect_mvc.Models;

namespace Proyect_mvc.Controllers
{
    public class FormularioController : Controller
    {
        private Formulario mi_formulario = new Formulario();
        public IActionResult Index(){
            return View(mi_formulario);
        }
        [HttpPost]
        public IActionResult Procesame(string TextBoxNombre, 
                                        string TextBoxApellidos, 
                                        string TextBoxDireccion, 
                                        string TextBoxRequerimiento,
                                        string DropDownListCiudad
        ) {
            mi_formulario.Nombres = TextBoxNombre;
            mi_formulario.Apellidos = TextBoxApellidos;
            mi_formulario.Direccion = TextBoxDireccion;
            mi_formulario.Requerimiento = TextBoxRequerimiento;
            ViewBag.CiudadS = DropDownListCiudad;
            return View("Index",mi_formulario);
        }
    }
}
