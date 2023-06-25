el formato principal es el siguiente
```
- bin
- obj
- Models
	- ErrorViewModel.cs
- Views
	- Home
		- Index.cshtml
	- Shared
		- _Layout.cshmtl
		- _layout.cshtml.css
		- ...
	- _ViewImports.cshtml
	- _ViewStart.cshtml
- Controller
	- HomeController.cs
- Program.cs
- wwwroot
- ...
```

**revisa el modelo MVC para entender mejor**
Primero debemos entender los archivos que contiene:
- Razor (cshtml)
	- es una combinación entre C Sharp y HTML de ahí es que se llama cshtml
	- donde para llamar a cualquier linea en c# usas `@`
	- estos generalmente son los que pertenecen a la parte de **view**
	- también incluyen css importando como si fuese un html incluso javascript
- C Sharp (cs)
	- Un nuevo lenguaje de alto nivel con similiaridad a muchos lenguajes
	- en ASP.NET Core se usa para la parte del `Model` y `Controller`
	- usualmente se usan clases y se importa algunas "librerías"
- CSS
	- son solo archivos que le dan estilo a un HTML no tiene mucha ciencia a parte que puede ser reemplazado si importamos `bootstrap` por link.
## para el proyecto de ASP.NET Core
- la parte de vista debe ser una carpeta con un nombre único
	- dentro de este puede contener varios archivos `cshtml` sus nombres también son importantes e: `Home/Index.cshtml`
- la parte de Controlador es importante destacar que el nombre debe ser por convención y referencia a carpetas de archivos
	- si teníamos una carpeta llamada `Home` en la vista entonces debemos tener un controller llamado `HomeController.cs` tal cuál, y **este controlador manejará todas las vistas dentro de la carpeta**
- la parte de Modelo no necesariamente importa el nombre respecto a la vista o al controlador, pero sugiere incluir algo similar como si nuestra carpeta de vista fuese `Home` entonces debería llamarse `HomeModel` ~
### Views
- contiene archivos `cshtml` donde se genera la vista del usuario
- primeramente se recomienda crear carpetas para un conjunto de vistas ya  que *de esta forma trabaja ASP.NET Core ~* para luego poder implementar sus **nombres por convención**.
#### estructura
(puedes revisar /Views/Home/Index.cshtml para entender)
- posee una parte inicial que es:
```cshtml
@{
	ViewData["Title"] = "Privacy Policy";
}
```
- esta parte como se ve es una referencia a un pedazo de código C#, y *por generalidad todos los archivos cshtml de vista lo tienen ~*

- Lo siguiente que puedes o no añadir es:
```cshtml
@model MyModel
```
- que indica que objeto de una clase de un modelo que hayas creado, usualmente las clases que se crean dentro de los modelos poseen el mismo nombre que sus respectivos archivos c#

- luego viene la parte de contenido general de HTML, con la forma del proyecto, este tiene como una plantilla que viene del archivo `_layout.cshtml` donde le da un encabezado y un pie de página que tu mismo puedes editar en ese archivo, **en esta plantilla incluye el header del html**
#### notas cuerpo del archivo
al momento de introducir un `@model MyModel` podemos nosotros entrar a las propiedades (elementos que compongan el objeto) con  `@Model.Nombre` de esta forma podremos nosotros introducir información que haya sido introducido en el Controller.
- También existen otras llamadas como `@ViewBag` que lleva consigo un dato que te hubiese gustado mostrar y no sabes como retornar.
- para el momento de hacer comunicación con el servidor con `POST` y `GET` en el controllador, en la vista deberíamos crear una etiqueta tipo `<form>` donde entrará algunos atributos propios del framework:
	- `method = "post"`: se encuentra el tipo de comunicación, en este caso se le incluye `post` pero también puede ser `get` u otro tipo de comunicación~
	- `action = ""` propia de html donde indicas donde está el método con un directorio **investigar mas~**
	- `asp-action=""` de asp net core y es más dinámico, en este caso entra al método que está dentro de su respectivo controlador (Home/Index - HomeController)
	- cualquier cosa con @ será considerado parte de c#  pero también puede combinarse, puede poner un condicional if{} pero lo que esté dentro será html también puede crear ambitos con @{} etc
	- **cuando se usa asp-action o action** el método que se guarda se activa con el input exclusivamente `<input type="submit">` o mas bien del tipo submit ya sea input o botón. esto recargará la página.
# notas
- nombres por convención: se refiere a que es importante nombrar correctamente algunas carpetas y archivos para que pueda funcionar bien este framework
## perplexity form
Sí, se puede utilizar `@model` en la vista `Index.cshtml` del ejemplo "si en vez de un input, sea un selector?" en lugar de `asp-for="Pais"`. `@model` se utiliza para especificar el tipo de modelo que se está utilizando en la vista. Aquí está el código completo de la vista `Index.cshtml` con `@model` en lugar de `asp-for="Pais"`:

```html
@model MiProyecto.Models.ModeloFormulario

<form method="post" action="/Home/ProcesarFormulario">
    <label for="pais">País:</label>
    <select id="pais" name="pais">
        <option value="1">México</option>
        <option value="2">Argentina</option>
        <option value="3">Chile</option>
    </select>
    <button type="submit">Enviar</button>
</form>

@if (!string.IsNullOrEmpty(ViewBag.PaisSeleccionado))
{
    <p>País seleccionado: @ViewBag.PaisSeleccionado</p>
}
```

En este ejemplo, se utiliza `@model MiProyecto.Models.ModeloFormulario` para especificar que la vista utiliza el modelo `ModeloFormulario`. En el selector, no se utiliza `asp-for="Pais"`, sino que simplemente se especifica el nombre del selector como `name="pais"`. En el controlador `ProcesarFormulario()`, se utiliza `Request.Form["pais"]` para obtener el valor del selector. Aquí está el código completo del controlador `HomeController` con esta modificación:

```csharp
using Microsoft.AspNetCore.Mvc;
using MiProyecto.Models;

namespace MiProyecto.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult ProcesarFormulario()
        {
            string paisSeleccionado = "";
            switch (Request.Form["pais"])
            {
                case "1":
                    paisSeleccionado = "México";
                    break;
                case "2":
                    paisSeleccionado = "Argentina";
                    break;
                case "3":
                    paisSeleccionado = "Chile";
                    break;
            }
            ViewBag.PaisSeleccionado = paisSeleccionado;
            return View("Index");
        }
    }
}
```

En resumen, se puede utilizar `@model` en la vista `Index.cshtml` del ejemplo "si en vez de un input, sea un selector?" en lugar de `asp-for="Pais"`. `@model` se utiliza para especificar el tipo de modelo que se está utilizando en la vista. En el selector, no se utiliza `asp-for="Pais"`, sino que simplemente se especifica el nombre del selector como `name="pais"`. En el controlador `ProcesarFormulario()`, se utiliza `Request.Form["pais"]` para obtener el valor del selector.

Citations:
[1] https://desarrolloweb.com/articulos/pasar-datos-controladores-vistas-dotnet.html
[2] https://codigofacilito.com/articulos/mvc-model-view-controller-explicado
[3] https://www.campusmvp.es/recursos/post/que-es-el-patron-mvc-en-programacion-y-por-que-es-util.aspx
[4] https://learn.microsoft.com/es-es/aspnet/core/tutorials/first-mvc-app/adding-model
[5] https://es.stackoverflow.com/questions/540496/error-con-validaciones-del-modelo-en-asp-net-core-mvc

By Perplexity at https://www.perplexity.ai/search/64eca42c-0503-4be8-8eae-c5b9edfd5b31
---
`Request.Form["pais"]` en el controlador `ProcesarFormulario()` del ejemplo "si en vez de un input, sea un selector?" se utiliza para obtener el valor del selector del formulario enviado por el usuario. `Request.Form` es una propiedad que contiene los valores de los campos del formulario enviado por el usuario. En este caso, `Request.Form["pais"]` obtiene el valor del campo del formulario con el nombre "pais", que es el nombre del selector en la vista `Index.cshtml`. El valor de `Request.Form["pais"]` es una cadena que representa el valor seleccionado en el selector. En el controlador `ProcesarFormulario()`, se utiliza un switch para determinar el país seleccionado y se guarda en una variable `paisSeleccionado`. Luego, se utiliza `ViewBag` para pasar el valor de `paisSeleccionado` a la vista `Index.cshtml`. En resumen, `Request.Form["pais"]` se utiliza para obtener el valor del selector del formulario enviado por el usuario en el ejemplo "si en vez de un input, sea un selector?".

Citations:
[1] https://es.stackoverflow.com/questions/387589/selector-css-para-seleccionar-todos-los-inputs-menos-type-submit
[2] https://recursivos.com/html/input/
[3] https://developer.mozilla.org/es/docs/Web/HTML/Element/form
[4] https://doc.laserfiche.com/laserfiche.documentation/es-mx/Subsystems/ProcessAutomation/Content/Forms-Current/Javascript-and-CSS/Javascript%20Selectors.htm
[5] https://desarrolloweb.com/faq/que-selector-css-usar-para-seleccionar-un-campo-input-que-tiene-el-atributo-namesearch

By Perplexity at https://www.perplexity.ai/search/653268aa-d1d8-4042-a262-8e26e602fae8
