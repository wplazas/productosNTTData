using Moq;
using System.Data;
using System.Data.SqlClient;

namespace TestProduct
{


    [TestClass]
    public class testProduct
    {
        private readonly string cadCon = "Server=DESKTOP-TOI7C9D\\SQLEXPRESS;Trusted_Connection=yes;Database=DBData;";

        [TestMethod]
        public void test_productoConsulta()
        {
            int id = 1;
            DataTable tabrow = new DataTable();


            using (SqlConnection conn = new SqlConnection(cadCon))
            {
                using (SqlCommand sqlcom = new SqlCommand("sp_productoconsultaxID", conn))
                {
                    sqlcom.CommandType = CommandType.StoredProcedure;
                    sqlcom.Parameters.AddWithValue("@id", id);

                    using (SqlDataAdapter adaptador = new SqlDataAdapter(sqlcom))
                    {
                        adaptador.Fill(tabrow);
                    }
                }
            }

            Assert.IsNotNull(tabrow);

        }

        [TestMethod]
        public void test_productoConsultasave()
        {
            // Arrange
            string categoria = "categoria_test";
            string nombre = "nombre_test";
            int unidades = 100;
            string fecha = "2023-11-22 00:00:00";


            // Mock del repositorio
            var mockProductoRepository = new Mock<Interface_productosRepository>();
            mockProductoRepository.Setup(repo => repo.InsertarProducto(categoria, nombre, unidades, fecha));

            // Instanciar el servicio con el mock del repositorio
            var usuarioService = new ProductoService(mockProductoRepository.Object);

            // Act
            usuarioService.CrearNuevoProducto(categoria, nombre, unidades, fecha);

            // Assert
            // Verificar que el método InsertarUsuario del repositorio se haya llamado con los parámetros esperados
            mockProductoRepository.Verify(repo => repo.InsertarProducto(categoria, nombre, unidades, fecha), Times.Once);

        }

    }

    public interface Interface_productosRepository
    {
        void InsertarProducto(string categoria, string nombre, int unidades, string fecha);
    }


}