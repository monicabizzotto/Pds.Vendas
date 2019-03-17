using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pds.Vendas.Web.Domain
{
	public class ApiProdutosResponse
	{
		public ApiProdutosResponse()
		{
		}

		public List<Produto> Produtos { get; set; }
	}
}
