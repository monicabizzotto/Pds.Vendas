using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
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
		[Route("")]
		[HttpGet]
		public async Task<IActionResult> Index()
		{
			PedidoIndexViewModel pedidoIndexViewModel;
			HttpClient httpClient = new HttpClient();
			httpClient.BaseAddress = new Uri(configurations.Configuration["ServicesReference:0:PdsControleVendasApi"].ToString());

			var response = await httpClient.GetAsync("/v1/pedido");

			if (response.StatusCode == HttpStatusCode.OK)
			{
				var content = await response.Content.ReadAsStringAsync();

				var statusPedidos = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Pedido>>(content);

				pedidoIndexViewModel = new PedidoIndexViewModel(statusPedidos);
			}
			else
			{
				pedidoIndexViewModel = new PedidoIndexViewModel();
			}

			return View(pedidoIndexViewModel);
		}

		[HttpGet]
		[Route("/Status")]
		public async Task<IActionResult> Status()
		{
			PedidoStatusViewModel pedidoStatusViewModel;
			HttpClient httpClient = new HttpClient();
			httpClient.BaseAddress = new Uri(configurations.Configuration["ServicesReference:0:PdsControleVendasApi"].ToString());

			var response = await httpClient.GetAsync("/v1/pedido/status");

			if (response.StatusCode == HttpStatusCode.OK)
			{
				var content = await response.Content.ReadAsStringAsync();

				var statusPedidos = Newtonsoft.Json.JsonConvert.DeserializeObject<List<RetornoPedido>>(content);

				pedidoStatusViewModel = new PedidoStatusViewModel(statusPedidos);
			}
			else
			{
				pedidoStatusViewModel = new PedidoStatusViewModel();
			}

			//pedidoIndexViewModel.StatusPedidos.Add(new Domain.ItemStatusPedido(3, "Produto 6", 1, "Pedido entregue"));
			//pedidoIndexViewModel.StatusPedidos.Add(new Domain.ItemStatusPedido(5, "Produto 1", 2, "Aguardando Pagamento"));
			//pedidoIndexViewModel.StatusPedidos.Add(new Domain.ItemStatusPedido(6, "Produto 4", 1, "Separação Estoque"));
			//pedidoIndexViewModel.StatusPedidos.Add(new Domain.ItemStatusPedido(7, "Produto 2", 3, "Aguardando Pagamento"));
			//pedidoIndexViewModel.StatusPedidos.Add(new Domain.ItemStatusPedido(8, "Produto 4", 6, "Em rota de Entrega"));
			//pedidoIndexViewModel.StatusPedidos.Add(new Domain.ItemStatusPedido(9, "Produto 3", 2, "Separação Estoque"));
			//pedidoIndexViewModel.StatusPedidos.Add(new Domain.ItemStatusPedido(10, "Produto 5", 3, "Pagamento Confirmado"));

			return View(pedidoStatusViewModel);
		}

		[HttpGet]
		[Route("/Novo")]
		public async Task<IActionResult> Novo()
		{
			PedidoNovoViewModel pedidoNovoViewModel = new PedidoNovoViewModel();
			HttpClient httpClient = new HttpClient();
			httpClient.BaseAddress = new Uri(configurations.Configuration["ServicesReference:0:PdsControleVendasApi"].ToString());

			var response = await httpClient.GetAsync("/v1/produto");

			if (response.StatusCode == HttpStatusCode.OK)
			{
				Task<string> content = response.Content.ReadAsStringAsync();

				Task.WaitAll(content);

				var produtos = Newtonsoft.Json.JsonConvert.DeserializeObject<ApiProdutosResponse>(content.Result);

				pedidoNovoViewModel.Produtos = produtos.Produtos;
			}


			return View(pedidoNovoViewModel);
		}
		[HttpPost]
		[Route("/Novo")]
		public async Task<IActionResult> Novo(PedidoNovoViewModel pedidoNovoViewModel)
		{
			HttpClient httpClient = new HttpClient();
			httpClient.BaseAddress = new Uri(configurations.Configuration["ServicesReference:0:PdsControleVendasApi"].ToString());

			var pedido = Newtonsoft.Json.JsonConvert.SerializeObject(pedidoNovoViewModel.ToPedido());

			var response = await httpClient.PostAsync("/v1/pedido", new StringContent(pedido, Encoding.UTF8, "application/json"));

			if (response.StatusCode == HttpStatusCode.OK)
			{
			}

			return RedirectToAction("Index");
		}
	}
}