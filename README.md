# BlogMarkDown

BlogMarkDown es una aplicaci�n web desarrollada con ASP.NET Core Razor Pages (.NET 8, C# 12) que permite la creaci�n y gesti�n de entradas de blog utilizando Markdown. El proyecto utiliza Bootstrap para el dise�o responsivo y EasyMDE como editor de Markdown.

## Caracter�sticas

- Interfaz moderna y responsiva con Bootstrap 5.
- Edici�n de entradas de blog en Markdown gracias a EasyMDE.
- Estructura basada en Razor Pages para una gesti�n sencilla y escalable.
- Iconograf�a con Bootstrap Icons.
- C�digo fuente organizado y f�cil de mantener.

## Requisitos

- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- Node.js (opcional, para gesti�n de paquetes front-end)
- Un editor compatible, como Visual Studio 2022

## Instalaci�n

1. Clona el repositorio:
```git clone https://github.com/tu-usuario/BlogMarkDown.git cd BlogMarkDown```
2. Restaura los paquetes NuGet:
```dotnet restore```
3. Ejecuta la aplicaci�n:
```dotnet run``` 
4. Accede a la aplicaci�n en [http://localhost:5000](http://localhost:5000) o el puerto configurado.

## Estructura del Proyecto

- `Views/Shared/_Layout.cshtml`: Plantilla principal con Bootstrap, EasyMDE y Bootstrap Icons.
- `wwwroot/lib/`: Librer�as est�ticas (Bootstrap, EasyMDE, etc.).
- `wwwroot/css/`: Hojas de estilo personalizadas.
- `wwwroot/js/`: Scripts personalizados.

## Personalizaci�n

- Modifica el archivo `_Layout.cshtml` para cambiar la estructura base o los estilos globales.
- Agrega o edita p�ginas Razor en la carpeta `Pages` para ampliar la funcionalidad.

## Cr�ditos

- [Bootstrap](https://getbootstrap.com/)
- [EasyMDE](https://github.com/Ionaru/easy-markdown-editor)
- [Bootstrap Icons](https://icons.getbootstrap.com/)

## Licencia

Este proyecto est� bajo la licencia MIT.