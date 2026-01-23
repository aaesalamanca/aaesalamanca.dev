# Iniciar proyecto de Razor Pages

Actualizar Bootstrap en ASP.NET

Eliminar /wwwroot/lib/bootstrap.

https://getbootstrap.com/docs/5.3/getting-started/introduction/
https://getbootstrap.com/docs/5.3/getting-started/download/
Descargar el CSS y JS de Bootstrap compilado.

Copiar los directorios js y css descargados en /wwwroot/lib/bootstrap.

Incluir el CSS y JS de Bootstrap en /Pages/Shared/\_Layout.cshtml.

<head>
    @* ... *@
    <link rel="stylesheet" href="~/lib/bootstrap/css/bootstrap.min.css" />
    @* ... *@
</head>
<body>
    @* ... *@
    <script src="~/lib/bootstrap/js/bootstrap.bundle.min.js"></script>
    @* ... *@
</body>

https://github.com/aviiceena/bootstrap-intellisense
https://marketplace.visualstudio.com/items?itemName=hossaini.bootstrap-intellisense
Instalar en VS Code la extensión Bootstrap Intellisense.
