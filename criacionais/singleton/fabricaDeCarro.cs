using System;
using Singleton;

namespace Singleton {
  public class FabricaDeCarro {

    protected int totalCarrosFiat;
    protected int totalCarrosFord;
    protected int totalCarrosVolks;

    public string criarCarroVolks() {
      return "Carro Volks #" + totalCarrosVolks++ + " criado.";
    }

    public string criarCarroFord() {
      return "Carro Ford #" + totalCarrosFord++ + " criado.";
    }

    public string criarCarroFiat() {
      return "Carro Fiat #" + totalCarrosFiat++ + " criado.";
    }

    public string gerarRelatorio() {
      return "Total de carros Fiat vendidos: " + totalCarrosFiat + "\n" +
             "Total de carros Ford vendidos: " + totalCarrosFord + "\n" +
             "Total de carros Volks vendidos: " + totalCarrosVolks + "\n";
    }

    public static FabricaDeCarro instancia;

    protected FabricaDeCarro() {}

    public static FabricaDeCarro getInstancia() {
      if(instancia == null) {
        instancia = new FabricaDeCarro();
      }
      return instancia;
    }
  }
}

class Teste {
  public static void Main(string[] args) {
    FabricaDeCarro fabrica = FabricaDeCarro.getInstancia();
    Console.WriteLine(fabrica.criarCarroFiat());
    Console.WriteLine(fabrica.criarCarroFiat());
    Console.WriteLine(fabrica.criarCarroFord());
    Console.WriteLine(fabrica.criarCarroVolks());
    Console.WriteLine(fabrica.gerarRelatorio());

    fabrica = FabricaDeCarro.getInstancia();
    Console.WriteLine(fabrica.gerarRelatorio());
  }
}
