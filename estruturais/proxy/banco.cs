using System;
using Proxy;
using Real;

namespace Proxy {

  public class ContaProxy: Conta {
    private Conta conta;

    public ContaProxy(Conta conta) {
      this.conta = conta;
    }

    public void deposita(double valor) {
      Console.WriteLine("Efetuando o depósito de R$ " + valor + " reais");
      this.conta.deposita(valor);
      Console.WriteLine("Depósito de R$ " + valor + " efetuado...");
    }

    public void saca(double valor) {
      Console.WriteLine("Efetuando o saque de R$ " + valor + " reais");
      this.conta.saca(valor);
      Console.WriteLine("Saque de R$ " + valor + " efetuado...");
    }

    public double getSaldo() {
      Console.WriteLine("Verificando o saldo...");
      return this.conta.getSaldo();
    }
  }

}

namespace Real {

  public class ContaPadrao: Conta {
    private double saldo = 0;

    public void deposita(double valor) {
      this.saldo += valor;
    }

    public void saca(double valor) {
      this.saldo -= valor;
    }

    public double getSaldo() {
      return this.saldo;
    }
  }

}

public interface Conta {
  void deposita(double valor);
  void saca(double valor);
  double getSaldo();
}

class Testes {
  public static void Main(string[] args) {
    Conta contaPadrao = new ContaPadrao();
    Conta contaProxy = new ContaProxy(contaPadrao);
    contaProxy.deposita(100);
    Console.WriteLine("Saldo: " + contaProxy.getSaldo());
    contaProxy.saca(59);
    Console.WriteLine("Saldo: " + contaProxy.getSaldo());
  }
}
