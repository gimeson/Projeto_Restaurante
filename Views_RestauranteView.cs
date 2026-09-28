using System;
using ProjetoRestaurante.Models;

namespace ProjetoRestaurante.Views
{
    public class RestauranteView
    {
        public int MostrarMenu()
        {
            Console.Clear();
            Console.WriteLine("=================================");
            Console.WriteLine("     RESTAURANTE - GERENCIADOR   ");
            Console.WriteLine("=================================");
            Console.WriteLine("0. Sair");
            Console.WriteLine("1. Criar novo pedido");
            Console.WriteLine("2. Adicionar item ao pedido");
            Console.WriteLine("3. Remover item do pedido");
            Console.WriteLine("4. Consultar pedido");
            Console.WriteLine("5. Cancelar pedido");
            Console.WriteLine("6. Listar todos os pedidos");
            Console.WriteLine("=================================");
            Console.Write("Escolha uma opção: ");

            if (int.TryParse(Console.ReadLine(), out int opcao))
            {
                return opcao;
            }
            return -1;
        }

        public string SolicitarNomeCliente()
        {
            Console.WriteLine("--- NOVO PEDIDO ---");
            Console.Write("Informe o nome do cliente: ");
            return Console.ReadLine();
        }

        public int SolicitarIdPedido()
        {
            Console.Write("Informe o ID do pedido: ");
            int.TryParse(Console.ReadLine(), out int id);
            return id;
        }

        public Item SolicitarDadosItem()
        {
            Console.WriteLine("\n--- DADOS DO ITEM ---");
            Console.Write("ID do item: ");
            int.TryParse(Console.ReadLine(), out int id);

            Console.Write("Descrição do item: ");
            string descricao = Console.ReadLine();

            Console.Write("Preço do item (R$): ");
            double.TryParse(Console.ReadLine(), out double preco);

            return new Item(id, descricao, preco);
        }

        public int SolicitarIdItemParaRemover()
        {
            Console.Write("Informe o ID do item que deseja remover: ");
            int.TryParse(Console.ReadLine(), out int id);
            return id;
        }

        public void MostrarMensagem(string mensagem)
        {
            Console.WriteLine($"\n{mensagem}");
        }

        public void MostrarPedido(Pedido pedido)
        {
            if (pedido != null)
            {
                Console.WriteLine("\n" + pedido.DadosDoPedido());
            }
            else
            {
                Console.WriteLine("\nPedido não encontrado.");
            }
        }

        public void ListarTodosOsPedidos(Pedido[] pedidos)
        {
            Console.WriteLine("\n--- LISTAGEM DE TODOS OS PEDIDOS ---");
            bool encontrouAlgum = false;
            double somaGeralDia = 0;

            foreach (var pedido in pedidos)
            {
                if (pedido != null)
                {
                    encontrouAlgum = true;
                    double totalPedido = pedido.CalcularTotal();
                    somaGeralDia += totalPedido;

                    Console.WriteLine($"ID: {pedido.Id} | Cliente: {pedido.Cliente} | Valor Total: R$ {totalPedido:F2}");
                }
            }

            if (!encontrouAlgum)
            {
                Console.WriteLine("Nenhum pedido cadastrado no momento.");
            }
            else
            {
                Console.WriteLine("---------------------------------");
                Console.WriteLine($"SOMA GERAL DO DIA: R$ {somaGeralDia:F2}");
            }
        }

        public void AguardarTecla()
        {
            Console.WriteLine("\nPressione qualquer tecla para continuar...");
            Console.ReadKey();
        }
    }
}