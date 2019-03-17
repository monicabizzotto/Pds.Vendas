using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pds.Vendas.Web.Domain
{
	public class ItemStatusPedido
	{
		public ItemStatusPedido()
		{
		}
		public ItemStatusPedido(RetornoPedido pedido)
		{
			Id = pedido.Pedido.Id;
			Produto = pedido.Pedido.Produto.Nome;
			Quantidade = pedido.Pedido.Quantidade;
			Status = Enum.GetName(typeof(StatusPedido), pedido.StatusPedido);
		}
		public ItemStatusPedido(int id, string produto, int quantidade, string status)
		{
			Id = id;
			Produto = produto;
			Quantidade = quantidade;
			Status = status;
		}

		public int Id { get; set; }
		public string Produto { get; set; }
		public int Quantidade { get; set; }
		public string Status { get; set; }
	}
}
