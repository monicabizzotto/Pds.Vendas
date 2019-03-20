using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pds.Vendas.Web.Domain
{
	public class PedidoRequest
	{
		public PedidoRequest()
		{
		}

		public int CodigoProduto { get; set; }
		public int CodigoCliente { get; set; }
		public int Quantidade { get; set; }

	}
}
