using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Pds.Vendas.Web.Domain;
using Pds.Vendas.Web.Models;
using Pds.Vendas.Web.Util;

namespace Pds.Vendas.Web.Controllers
{
	public class ProdutoController : Controller
	{
		private Configurations configurations;

		public ProdutoController()
		{
			configurations = new Configurations();
		}

		public IActionResult Index()
		{
			ProdutoViewModel produtoViewModel = new ProdutoViewModel();

			HttpClient httpClient = new HttpClient();
			httpClient.BaseAddress = new Uri(configurations.Configuration["ServicesReference:0:PdsControleVendasApi"].ToString());

			var response = httpClient.GetAsync("/v1/produto");

			Task.WaitAll(response);

			if (response.IsCompletedSuccessfully && response.Result.StatusCode == HttpStatusCode.OK)
			{
				Task<string> content = response.Result.Content.ReadAsStringAsync();

				Task.WaitAll(content);

				var produtos = Newtonsoft.Json.JsonConvert.DeserializeObject<ApiProdutosResponse>(content.Result);

				produtoViewModel.Produtos = produtos.Produtos;
			}

			return View(produtoViewModel);
		}
	}
}