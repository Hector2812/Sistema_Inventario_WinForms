using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace SistemaInventarioWinForms.Clases
{
    public class Inventario
    {
        private List<Producto> productos = new();

        public void AgregarProducto(Producto producto)
        {
            productos.Add(producto);
        }

        public Producto BuscarProducto(string nombre)
        {
            var producto = productos.Find(p => p.Nombre.Equals(nombre, StringComparison.OrdinalIgnoreCase));
            if (producto == null)
                throw new ProductoNoEncontradoException("Producto no encontrado.");
            return producto;
        }

        public void EliminarProducto(string nombre)
        {
            var producto = BuscarProducto(nombre);
            productos.Remove(producto);
        }

        public List<Producto> BuscarPorPrecio(double precioMin, double precioMax)
        {
            return productos.Where(p => p.Precio >= precioMin && p.Precio <= precioMax).ToList();
        }

        public List<Producto> ObtenerProductos()
        {
            return productos;
        }

        public void GuardarEnJson(string nombreArchivo)
        {
            string rutaBase = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\\..\\..\\");
            string rutaDatos = Path.Combine(rutaBase, "Datos");

            if (!Directory.Exists(rutaDatos))
                Directory.CreateDirectory(rutaDatos);

            string rutaCompleta = Path.Combine(rutaDatos, nombreArchivo);

            string json = JsonConvert.SerializeObject(productos, Formatting.Indented, new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.All
            });

            File.WriteAllText(rutaCompleta, json);
        }

        public void CargarDesdeJson(string nombreArchivo)
        {
            string rutaBase = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\\..\\..\\");
            string rutaDatos = Path.Combine(rutaBase, "Datos");

            if (!Directory.Exists(rutaDatos))
                Directory.CreateDirectory(rutaDatos);

            string rutaCompleta = Path.Combine(rutaDatos, nombreArchivo);

            if (!File.Exists(rutaCompleta))
            {
                productos = new List<Producto>();
                GuardarEnJson(nombreArchivo);
            }
            else
            {
                string contenido = File.ReadAllText(rutaCompleta);

                productos = string.IsNullOrWhiteSpace(contenido)
                    ? new List<Producto>()
                    : JsonConvert.DeserializeObject<List<Producto>>(contenido, new JsonSerializerSettings
                    {
                        TypeNameHandling = TypeNameHandling.All
                    }) ?? new List<Producto>();
            }
        }
    }
}
