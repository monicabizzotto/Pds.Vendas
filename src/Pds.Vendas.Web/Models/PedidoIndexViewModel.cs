using Pds.Vendas.Web.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pds.Vendas.Web.Models
{
	public class PedidoIndexViewModel
	{
		public PedidoIndexViewModel()
		{
			StatusPedidos = new List<ItemStatusPedido>();
		}
		public PedidoIndexViewModel(List<RetornoPedido> pedidoStatusResponse)
			: this()
		{
			for (int i = 0; i < pedidoStatusResponse.Count; i++)
			{
				StatusPedidos.Add(new ItemStatusPedido(pedidoStatusResponse[i]));
			}
		}

		public List<ItemStatusPedido> StatusPedidos { get; set; }
	}
}
