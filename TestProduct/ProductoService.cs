using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProduct
{
    internal class ProductoService
    {
        private readonly Interface_productosRepository productoRepository;

        public ProductoService(Interface_productosRepository productoRepository)
        {
            this.productoRepository = productoRepository;
        }

        public void CrearNuevoProducto(string categoria, string nombre, int unidades, string fecha)
        {
            productoRepository.InsertarProducto( categoria,  nombre,  unidades,  fecha);
        }
    }
}
