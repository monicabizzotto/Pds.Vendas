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
	[Route("Pedido")]
	public class PedidoController : Controller
	{
		private Configurations configurations;

		public PedidoController()
		{
			configurations = new Configurations();
		}
		public async Task<IActionResult> Index()
		{
			PedidoIndexViewModel pedidoIndexViewModel;
			HttpClient httpClient = new HttpClient();
			httpClient.BaseAddress = new Uri(configurations.Configuration["ServicesReference:0:PdsControleVendasApi"].ToString());

			var response = await httpClient.GetAsync("/v1/pedido/status");

			if (response.StatusCode == HttpStatusCode.OK)
			{
				var content = await response.Content.ReadAsStringAsync();

				var statusPedidos = Newtonsoft.Json.JsonConvert.DeserializeObject<List<RetornoPedido>>(content);

				pedidoIndexViewModel = new PedidoIndexViewModel(statusPedidos);
			}
			else
			{
				pedidoIndexViewModel = new PedidoIndexViewModel();
			}

			//pedidoIndexViewModel.StatusPedidos.Add(new Domain.ItemStatusPedido(3, "Produto 6", 1, "Pedido entregue"));
			//pedidoIndexViewModel.StatusPedidos.Add(new Domain.ItemStatusPedido(5, "Produto 1", 2, "Aguardando Pagamento"));
			//pedidoIndexViewModel.StatusPedidos.Add(new Domain.ItemStatusPedido(6, "Produto 4", 1, "Separação Estoque"));
			//pedidoIndexViewModel.StatusPedidos.Add(new Domain.ItemStatusPedido(7, "Produto 2", 3, "Aguardando Pagamento"));
			//pedidoIndexViewModel.StatusPedidos.Add(new Domain.ItemStatusPedido(8, "Produto 4", 6, "Em rota de Entrega"));
			//pedidoIndexViewModel.StatusPedidos.Add(new Domain.ItemStatusPedido(9, "Produto 3", 2, "Separação Estoque"));
			//pedidoIndexViewModel.StatusPedidos.Add(new Domain.ItemStatusPedido(10, "Produto 5", 3, "Pagamento Confirmado"));

			return View(pedidoIndexViewModel);
		}

		[HttpGet]
		[Route("/Novo")]
		public IActionResult Novo()
		{
			PedidoNovoViewModel pedidoNovoViewModel = new PedidoNovoViewModel();
			HttpClient httpClient = new HttpClient();
			httpClient.BaseAddress = new Uri(configurations.Configuration["ServicesReference:0:PdsControleVendasApi"].ToString());

			var response = httpClient.GetAsync("/v1/produto");

			Task.WaitAll(response);

			if (response.IsCompletedSuccessfully && response.Result.StatusCode == HttpStatusCode.OK)
			{
				Task<string> content = response.Result.Content.ReadAsStringAsync();

				Task.WaitAll(content);

				var produtos = Newtonsoft.Json.JsonConvert.DeserializeObject<ApiProdutosResponse>(content.Result);

				pedidoNovoViewModel.Produtos = produtos.Produtos;
			}


			return View(pedidoNovoViewModel);
		}
		[HttpPost]
		[Route("/Novo")]
		public IActionResult Novo(PedidoNovoViewModel pedidoNovoViewModel)
		{
			HttpClient httpClient = new HttpClient();
			httpClient.BaseAddress = new Uri(configurations.Configuration["ServicesReference:0:PdsControleVendasApi"].ToString());

			var pedido = Newtonsoft.Json.JsonConvert.SerializeObject(pedidoNovoViewModel.ToPedido());

			var response = httpClient.PostAsync("/v1/produto", new StringContent(pedido));

			Task.WaitAll(response);

			if (response.IsCompletedSuccessfully && response.Result.StatusCode == HttpStatusCode.OK)
			{

			}

			return View();
		}
	}
}