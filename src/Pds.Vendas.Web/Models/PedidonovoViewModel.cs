using Pds.Vendas.Web.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pds.Vendas.Web.Models
{
	public class PedidoNovoViewModel
	{
		public PedidoNovoViewModel()
		{
			Produto = new Produto();
		}

		public Produto Produto { get; set; }
		public int Quantidade { get; set; }
		public List<Produto> Produtos { get; set; }

		public object ToPedido()
		{
			return new Pedido(Produto.Id, Quantidade);
		}
	}
}
