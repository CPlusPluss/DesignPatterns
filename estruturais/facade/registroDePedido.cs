using System;
using Components;

namespace Components {

  public class Pedido {
    private string produto;
    private string cliente;
    private string enderecoDeEntrega;

    public Pedido(string produto, string cliente, string enderecoDeEntrega) {
      this.produto = produto;
      this.cliente = cliente;
      this.enderecoDeEntrega = enderecoDeEntrega;
    }

    public string getProduto() {
      return produto;
    }

    public string getCliente() {
      return cliente;
    }

    public string getEnderecoDeEntrega() {
      return enderecoDeEntrega;
    }
  }

  public class Estoque {
    public void enviaProduto(string produto, string enderecoDeEntrega) {
      string today = DateTime.Today.Day.ToString();
      Console.WriteLine("O produto " + produto + " será entregue no endereço " + enderecoDeEntrega + " até as 18h do dia " + today);
    }
  }

  public class Financeiro {
    public void fatura(string cliente, string produto) {
      Console.WriteLine("Fatura:");
      Console.WriteLine(" Cliente: " + cliente);
      Console.WriteLine(" Produto: " + produto);
    }
  }

  public class PosVenda {
    public void agendaContato(string cliente, string produto) {
      string today = DateTime.Today.Day.ToString();
      Console.WriteLine("Entrar em contato com " + cliente + " sobre o produto " + produto + " no dia " + today);
    }
  }

}

public class PedidoFacade {
  private Estoque estoque;
  private Financeiro financeiro;
  private PosVenda posVenda;

  public PedidoFacade(Estoque estoque, Financeiro financeiro, PosVenda posVenda) {
    this.estoque = estoque;
    this.financeiro = financeiro;
    this.posVenda = posVenda;
  }

  public void registraPedido(Pedido pedido) {
    this.estoque.enviaProduto(pedido.getProduto(), pedido.getEnderecoDeEntrega());
    this.financeiro.fatura(pedido.getCliente(), pedido.getProduto());
    this.posVenda.agendaContato(pedido.getCliente(), pedido.getProduto());
  }
}

class Testes {
  public static void Main(string[] args) {
    Estoque estoque = new Estoque();
    Financeiro financeiro = new Financeiro();
    PosVenda posVenda = new PosVenda();
    PedidoFacade facade = new PedidoFacade(estoque, financeiro, posVenda);
    Pedido pedido = new Pedido("Notebook", "Rafael Cosentino", "Av Brigadeiro Faria Lima, 1571, São Paulo, SP");
    facade.registraPedido(pedido);
  }
}
