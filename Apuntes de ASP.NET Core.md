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
- los parámetros que entran en una función que usa una vista cuando son strings, busca los `name` de las etiquetas y extrae información del name que tenga el mismo nombre del parmetro, **recuerda que para que esto funcione correctamente debes tomar en cuenta que debes añadir `values` y otros atributos generales sino puedes recibir valores no deseados que no serán útiles para su procesamiento.
