using ProjetoRestaurante.Models;
using ProjetoRestaurante.Views;

namespace ProjetoRestaurante.Controllers
{
    public class RestauranteController
    {
        private Restaurante restaurante;
        private RestauranteView view;

        public RestauranteController(Restaurante restaurante, RestauranteView view)
        {
            this.restaurante = restaurante;
            this.view = view;
        }

        public void Iniciar()
        {
            int opcao = -1;
            do
            {
                opcao = view.MostrarMenu();
                ProcessarOpcao(opcao);
            } while (opcao != 0);
        }

        private void ProcessarOpcao(int opcao)
        {
            switch (opcao)
            {
                case 1:
                    CriarNovoPedido();
                    break;
                case 2:
                    AdicionarItem();
                    break;
                case 3:
                    RemoverItem();
                    break;
                case 4:
                    ConsultarPedido();
                    break;
                case 5:
                    CancelarPedido();
                    break;
                case 6:
                    ListarPedidos();
                    break;
                case 0:
                    view.MostrarMensagem("Encerrando a aplicação...");
                    break;
                default:
                    view.MostrarMensagem("Opção inválida!");
                    break;
            }

            if (opcao != 0)
            {
                view.AguardarTecla();
            }
        }

        private void CriarNovoPedido()
        {
            string cliente = view.SolicitarNomeCliente();
            if (string.IsNullOrWhiteSpace(cliente))
            {
                view.MostrarMensagem("Erro: O nome do cliente não pode ser vazio.");
                return;
            }

            Pedido novoPedido = new Pedido(0, cliente);
            if (restaurante.NovoPedido(novoPedido))
            {
                view.MostrarMensagem($"Pedido nº {novoPedido.Id} criado com sucesso para o cliente {cliente}!");
            }
            else
            {
                view.MostrarMensagem("Erro: Não foi possível criar o pedido. A cozinha atingiu o limite de 50 pedidos no dia.");
            }
        }

        private void AdicionarItem()
        {
            int idPedido = view.SolicitarIdPedido();
            Pedido pedidoBuscado = restaurante.BuscarPedido(new Pedido { Id = idPedido });

            if (pedidoBuscado != null)
            {
                Item novoItem = view.SolicitarDadosItem();
                if (pedidoBuscado.AdicionarItem(novoItem))
                {
                    view.MostrarMensagem("Item adicionado com sucesso ao pedido!");
                }
                else
                {
                    view.MostrarMensagem("Erro: O pedido já atingiu o limite máximo de 10 itens.");
                }
            }
            else
            {
                view.MostrarMensagem("Erro: Pedido não encontrado.");
            }
        }

        private void RemoverItem()
        {
            int idPedido = view.SolicitarIdPedido();
            Pedido pedidoBuscado = restaurante.BuscarPedido(new Pedido { Id = idPedido });

            if (pedidoBuscado != null)
            {
                int idItem = view.SolicitarIdItemParaRemover();
                if (pedidoBuscado.RemoverItem(new Item { Id = idItem }))
                {
                    view.MostrarMensagem("Item removido com sucesso do pedido!");
                }
                else
                {
                    view.MostrarMensagem("Erro: Item não encontrado no pedido informado.");
                }
            }
            else
            {
                view.MostrarMensagem("Erro: Pedido não encontrado.");
            }
        }

        private void ConsultarPedido()
        {
            int idPedido = view.SolicitarIdPedido();
            Pedido pedidoBuscado = restaurante.BuscarPedido(new Pedido { Id = idPedido });
            view.MostrarPedido(pedidoBuscado);
        }

        private void CancelarPedido()
        {
            int idPedido = view.SolicitarIdPedido();
            if (restaurante.CancelarPedido(new Pedido { Id = idPedido }))
            {
                view.MostrarMensagem($"Pedido nº {idPedido} cancelado/removido com sucesso!");
            }
            else
            {
                view.MostrarMensagem("Erro: Pedido não encontrado.");
            }
        }

        private void ListarPedidos()
        {
            view.ListarTodosOsPedidos(restaurante.Pedidos);
        }
    }
}