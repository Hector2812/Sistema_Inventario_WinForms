Sistema de Inventario con Windows Forms (C# .NET 9.0)

Este proyecto es una aplicación de escritorio desarrollada en C# utilizando Windows Forms, diseñada para gestionar productos dentro de un inventario. Incluye funciones como búsqueda, 
validaciones, guardado automático en JSON y exportación de reportes a Excel y PDF. Es un ejemplo completo de una aplicación empresarial con arquitectura limpia y moderna.


Funcionalidades

- Agregar, buscar y eliminar productos
- Visualizar inventario completo en tabla (DataGridView)
- Validaciones de entrada (precio y stock)
- Persistencia de datos automática usando JSON
- Exportación a Excel (EPPlus)
- Exportación a PDF (PDFSharp)
- Interfaz amigable con Windows Forms
- Carpeta dedicada de almacenamiento ("Datos/") fuera del "bin/"


Tecnologías Utilizadas

| Tecnología / Librería | Propósito en el Proyecto |
|------------------------|---------------------------|
| C# | Lenguaje de programación principal |
| .NET 9.0 | Framework base para el desarrollo |
| Windows Forms | Interfaz gráfica de usuario |
| Newtonsoft.Json | Serialización y deserialización de objetos |
| EPPlus | Exportación de inventario a Excel |
| PDFSharp | Generación de reportes en PDF |
| LINQ | Consultas sobre listas y filtrado |
| JSON | Formato para almacenamiento persistente |
| Visual Studio 2022 | Entorno de desarrollo y diseño de formularios |


Estructura del Proyecto

SistemaInventarioWinForms/
│
├── 📁 Clases/
│   ├── Inventario.cs
│   ├── Producto.cs
│   ├── ProductoSimple.cs
│   ├── IProducto.cs
│   └── ProductoNoEncontradoException.cs
│
├── 📁 Helpers/
│   └── Exportador.cs
│
├── 📁 Datos/
│   └── inventario.json         
│
├── FormPrincipal.cs            
├── FormPrincipal.Designer.cs    
├── Program.cs                   
├── SistemaInventarioWinForms.csproj
├── .gitignore
└── README.md


¿Cómo probarlo?

Este sistema de inventario permite gestionar productos a través de una interfaz gráfica construida con Windows Forms.

1. Al iniciar la aplicación:
- Carga automáticamente los datos guardados en un archivo JSON ("Datos/inventario.json"), o los genera después del guardado, si es que no hay nada.
- Muestra el inventario en una tabla (DataGridView)

2. Agregar productos:
- Rellenas campos como nombre, precio, stock y categoría
- Al presionar Agregar, el producto aparece en la tabla

3. Buscar:
- Escribes el nombre y presionas Buscar
- Muestra una alerta con los detalles del producto si existe

4. Eliminar:
- Seleccionas un producto en la tabla
- Presionas Eliminar para quitarlo

5. Guardar:
- Presionas Guardar para que el inventario quede almacenado de forma persistente

6. Exportar:
- Puedes exportar a Excel o PDF desde los botones respectivos

7. Al cerrar y volver a abrir:
- El sistema recupera el inventario automáticamente desde el archivo JSON


Imagen de la Interfaz Gráfica:
![image](https://github.com/user-attachments/assets/52c58607-e02f-4503-a7d4-af922bdf5a86)


Documentación útil y librerías

- WinForms en .NET: https://learn.microsoft.com/es-es/dotnet/desktop/winforms/
- Newtonsoft.Json: https://www.newtonsoft.com/json/help/html/Introduction.htm
- EPPlus (Excel): https://www.nuget.org/packages/epplus/
- PDFSharp: https://github.com/empira/PDFsharp
- Serialización JSON: https://learn.microsoft.com/es-es/dotnet/standard/serialization/system-text-json-overview
- Programación async/await: https://learn.microsoft.com/es-es/dotnet/csharp/programming-guide/concepts/async/


Requisitos

- .NET 9.0 SDK instalado
- Visual Studio 2022
- NuGet Packages:
  - Newtonsoft.Json
  - EPPlus
  - PDFSharp


Autor

Héctor Arrasco 
Estudiante de Ingeniería de Sistemas, Universidad de Lima.  
hector28122003@gmail.com
