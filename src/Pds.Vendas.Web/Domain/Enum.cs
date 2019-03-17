using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pds.Vendas.Web.Domain
{
	public enum StatusPedido : int
	{
		Realizado = 0,
		AguardandoPagamento = 1,
		PagamentoConfirmado = 2,
		SeparacaoEstoque = 3,
		Transportadora = 4,
		EmRotaEntrega = 5,
		Entregue = 6,
		Outros = 99
	}
}
