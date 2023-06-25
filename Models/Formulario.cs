
namespace Proyect_mvc.Models
{
    public class Formulario
    {
        public List<string> Ciudad { get; set; } = new List<string>();
        public string Nombres {get; set; } = "";
        public string Apellidos {get; set; } = "";
        public string Direccion {get; set; } = "";
        public string Requerimiento {get; set; } = "";
        public string CiudadSeleccionada { get; set; } = "Lima";
        public string Sexo { get; set; } = "";
        
        public Formulario(){
            var path = "Ciudades.txt";
            string contenido = System.IO.File.ReadAllText(path);
            string []ciudades = contenido.Split('\n');
            foreach(string line in ciudades)
            {
                Ciudad.Add(line);
            }
        }

    }
    public class Informacion
    {
        public string? Nombre {get; set; }
    }
}