namespace ProjetoRestaurante.Models
{
    public class Restaurante
    {
        private int proxPedido;
        private Pedido[] pedidos;

        public int ProxPedido => proxPedido;
        public Pedido[] Pedidos => pedidos;

        public Restaurante()
        {
            proxPedido = 1;
            pedidos = new Pedido[50];
        }

        public bool NovoPedido(Pedido pedido)
        {
            for (int i = 0; i < pedidos.Length; i++)
            {
                if (pedidos[i] == null)
                {
                    pedido.Id = proxPedido++;
                    pedidos[i] = pedido;
                    return true;
                }
            }
            return false; // Limite de 50 pedidos do dia atingido
        }

        public Pedido BuscarPedido(Pedido pedido)
        {
            foreach (var p in pedidos)
            {
                if (p != null && p.Equals(pedido))
                {
                    return p;
                }
            }
            return null;
        }

        public bool CancelarPedido(Pedido pedido)
        {
            for (int i = 0; i < pedidos.Length; i++)
            {
                if (pedidos[i] != null && pedidos[i].Equals(pedido))
                {
                    pedidos[i] = null;
                    return true;
                }
            }
            return false;
        }
    }
}