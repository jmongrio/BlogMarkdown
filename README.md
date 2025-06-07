# BlogMarkDown

BlogMarkDown es una aplicación web desarrollada con ASP.NET Core Razor Pages (.NET 8, C# 12) que permite la creación y gestión de entradas de blog utilizando Markdown. El proyecto utiliza Bootstrap para el diseño responsivo y EasyMDE como editor de Markdown.

## Características

- Interfaz moderna y responsiva con Bootstrap 5.
- Edición de entradas de blog en Markdown gracias a EasyMDE.
- Estructura basada en Razor Pages para una gestión sencilla y escalable.
- Iconografía con Bootstrap Icons.
- Código fuente organizado y fácil de mantener.

## Requisitos

- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- Node.js (opcional, para gestión de paquetes front-end)
- Un editor compatible, como Visual Studio 2022

## Instalación

1. Clona el repositorio:
```git clone https://github.com/tu-usuario/BlogMarkdown.git cd BlogMarkDown```
2. Restaura los paquetes NuGet:
```dotnet restore```
3. Ejecuta la aplicación:
```dotnet run``` 
4. Accede a la aplicación en [http://localhost:5000](http://localhost:5000) o el puerto configurado.

## Estructura del Proyecto

- `Views/Shared/_Layout.cshtml`: Plantilla principal con Bootstrap, EasyMDE y Bootstrap Icons.
- `wwwroot/lib/`: Librerías estáticas (Bootstrap, EasyMDE, etc.).
- `wwwroot/css/`: Hojas de estilo personalizadas.
- `wwwroot/js/`: Scripts personalizados.

## Personalización

- Modifica el archivo `_Layout.cshtml` para cambiar la estructura base o los estilos globales.
- Agrega o edita páginas Razor en la carpeta `Pages` para ampliar la funcionalidad.

## Créditos

- [Bootstrap](https://getbootstrap.com/)
- [EasyMDE](https://github.com/Ionaru/easy-markdown-editor)
- [Bootstrap Icons](https://icons.getbootstrap.com/)

## Licencia

Este proyecto está bajo la licencia MIT.
