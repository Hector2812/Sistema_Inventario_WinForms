using OfficeOpenXml;
using PdfSharp.Pdf;
using PdfSharp.Drawing;
using PdfSharp.Drawing.Layout;
using PdfSharp.Fonts;
using SistemaInventarioWinForms.Clases;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;

namespace SistemaInventarioWinForms.Helpers
{
    public static class Exportador
    {
        public static void ExportarAExcel(List<Producto> productos, string ruta)
        {
            // Declarar licencia de uso no comercial para EPPlus 8
            ExcelPackage.License.SetNonCommercialPersonal("Héctor Arrasco");

            using var package = new ExcelPackage();
            var hoja = package.Workbook.Worksheets.Add("Inventario");

            hoja.Cells[1, 1].Value = "Nombre";
            hoja.Cells[1, 2].Value = "Categoría";
            hoja.Cells[1, 3].Value = "Precio";
            hoja.Cells[1, 4].Value = "Stock";

            for (int i = 0; i < productos.Count; i++)
            {
                hoja.Cells[i + 2, 1].Value = productos[i].Nombre;
                hoja.Cells[i + 2, 2].Value = productos[i].Categoria;
                hoja.Cells[i + 2, 3].Value = productos[i].Precio;
                hoja.Cells[i + 2, 4].Value = productos[i].Stock;
            }

            File.WriteAllBytes(ruta, package.GetAsByteArray());
            Process.Start(new ProcessStartInfo(ruta) { UseShellExecute = true });
        }

        public static void ExportarAPDF(List<Producto> productos, string ruta)
        {
            var doc = new PdfDocument();
            var pagina = doc.AddPage();
            var gfx = XGraphics.FromPdfPage(pagina);
            var fuente = new XFont("Arial", 12);
            var fuenteTitulo = new XFont("Arial", 14, XFontStyleEx.Bold);

            int y = 40;
            gfx.DrawString("Inventario de Productos", fuenteTitulo, XBrushes.Black, new XRect(0, 20, pagina.Width, 20), XStringFormats.TopCenter);

            foreach (var p in productos)
            {
                gfx.DrawString($"{p.Nombre} | {p.Categoria} | S/. {p.Precio} | Stock: {p.Stock}", fuente, XBrushes.Black, new XRect(40, y, pagina.Width - 80, 20), XStringFormats.TopLeft);
                y += 25;
                if (y > pagina.Height - 40)
                {
                    pagina = doc.AddPage();
                    gfx = XGraphics.FromPdfPage(pagina);
                    y = 40;
                }
            }

            doc.Save(ruta);
            Process.Start(new ProcessStartInfo(ruta) { UseShellExecute = true });
        }
    }
}
