using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pds.Vendas.Web.Domain
{
	public class Pedido
	{
		public Pedido()
		{
		}
		public Pedido(Produto produto, int quantidade)
		{
			Produto = produto;
			Quantidade = quantidade;
		}
		public Pedido(int idProduto, int quantidade)
		{
			Produto = new Produto() { Id = idProduto };
			Quantidade = quantidade;
		}

		public int Id { get; set; }
		public Produto Produto { get; set; }
		public int Quantidade { get; set; }
	}
}
