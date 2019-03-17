using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pds.Vendas.Web.Domain
{
	public class Produto
	{
		public Produto()
		{
			Fornecedor = new Fornecedor();
		}

		public int Id { get; set; }
		public string Nome { get; set; }
		public Fornecedor Fornecedor { get; set; }
	}
}
