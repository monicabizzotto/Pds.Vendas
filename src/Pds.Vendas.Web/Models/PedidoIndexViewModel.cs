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
			Pedidos = new List<Pedido>();
		}
		public PedidoIndexViewModel(List<Pedido> pedidos)
			: this()
		{
			for (int i = 0; i < pedidos.Count; i++)
			{
				Pedidos.Add(pedidos[i]);
			}
		}

		public List<Pedido> Pedidos { get; set; }
	}
}
