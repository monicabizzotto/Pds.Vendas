using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pds.Vendas.Web.Domain
{
	public class RetornoPedido
	{
		public RetornoPedido()
		{
			Pedido = new Pedido();
		}

		public Pedido Pedido { get; set; }
		public int StatusPedido { get; set; }
	}
}
