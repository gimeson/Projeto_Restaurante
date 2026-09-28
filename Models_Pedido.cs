using System.Text;

namespace ProjetoRestaurante.Models
{
    public class Pedido
    {
        private int id;
        private string cliente;
        private Item[] itens;

        public int Id
        {
            get => id;
            set => id = value;
        }

        public string Cliente
        {
            get => cliente;
            set => cliente = value;
        }

        public Item[] Itens => itens;

        public Pedido()
        {
            itens = new Item[10];
        }

        public Pedido(int id, string cliente) : this()
        {
            this.id = id;
            this.cliente = cliente;
        }

        public bool AdicionarItem(Item item)
        {
            for (int i = 0; i < itens.Length; i++)
            {
                if (itens[i] == null)
                {
                    itens[i] = item;
                    return true;
                }
            }
            return false; // Limite de 10 itens atingido
        }

        public bool RemoverItem(Item item)
        {
            for (int i = 0; i < itens.Length; i++)
            {
                if (itens[i] != null && itens[i].Equals(item))
                {
                    itens[i] = null;
                    return true;
                }
            }
            return false; // Item não encontrado no pedido
        }

        public double CalcularTotal()
        {
            double total = 0;
            foreach (var item in itens)
            {
                if (item != null)
                {
                    total += item.Preco;
                }
            }
            return total;
        }

        public string DadosDoPedido()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"=================================");
            sb.AppendLine($" ID do Pedido: {id}");
            sb.AppendLine($" Cliente: {cliente}");
            sb.AppendLine($"---------------------------------");
            sb.AppendLine(" Itens:");

            bool temItens = false;
            for (int i = 0; i < itens.Length; i++)
            {
                if (itens[i] != null)
                {
                    temItens = true;
                    sb.AppendLine($"   [{itens[i].Id}] {itens[i].Descricao} - R$ {itens[i].Preco:F2}");
                }
            }

            if (!temItens)
            {
                sb.AppendLine("   (Nenhum item adicionado)");
            }

            sb.AppendLine($"---------------------------------");
            sb.AppendLine($" Valor Total: R$ {CalcularTotal():F2}");
            sb.AppendLine($"=================================");

            return sb.ToString();
        }

        public override bool Equals(object obj)
        {
            if (obj is Pedido outroPedido)
            {
                return this.id == outroPedido.id;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return id.GetHashCode();
        }
    }
}