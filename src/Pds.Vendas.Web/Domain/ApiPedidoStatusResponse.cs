using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pds.Vendas.Web.Domain
{
	public class ApiPedidoStatusResponse
	{
		public ApiPedidoStatusResponse()
		{
			RetornoPedido = new List<RetornoPedido>();
		}

		public List<RetornoPedido> RetornoPedido { get; set; }
	}
}
