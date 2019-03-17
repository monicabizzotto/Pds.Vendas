using Pds.Vendas.Web.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pds.Vendas.Web.Models
{
	public class ProdutoViewModel
	{
		public ProdutoViewModel()
		{
			Produtos = new List<Produto>();
		}

		public List<Produto> Produtos { get; set; }
	}
}