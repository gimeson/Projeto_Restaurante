using ProjetoRestaurante.Controllers;
using ProjetoRestaurante.Models;
using ProjetoRestaurante.Views;

namespace ProjetoRestaurante
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Restaurante restauranteModel = new Restaurante();
            RestauranteView restauranteView = new RestauranteView();

            RestauranteController controller = new RestauranteController(restauranteModel, restauranteView);
            controller.Iniciar();
        }
    }
}