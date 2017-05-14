using System;
using Fabricas;
using Carros;

namespace Fabricas {

  public interface FabricaDeCarro {
    Carro criarCarro(int carro = 0);
  }

  public class FabricaFiat: FabricaDeCarro {
    public const int PALIO = 0;
    public const int UNO = 1;

    public Carro criarCarro(int carro) {
      if(carro == FabricaFiat.PALIO) {
        return new Palio();
      } else if(carro == FabricaFiat.UNO){
        return new Uno();
      } else {
        throw new ArgumentException("Carro não existe!");
      }
    }
  }

  public class FabricaVolkswagen: FabricaDeCarro {
    public Carro criarCarro(int carro) {
      return new Gol();
    }
  }

  public class FabricaChevrolet: FabricaDeCarro {
    public Carro criarCarro(int carro) {
      return new Celta();
    }
  }

  public class FabricaFord: FabricaDeCarro {
    public Carro criarCarro(int carro) {
      return new Fiesta();
    }
  }

}

namespace Carros {

  public interface Carro {
    void exibirInformacao();
  }

  public class Palio: Carro {
    public void exibirInformacao() {
      Console.WriteLine("Modelo: Palio");
      Console.WriteLine("Fabricante: Fiat");
    }
  }

  public class Uno: Carro {
    public void exibirInformacao() {
      Console.WriteLine("Modelo: Uno");
      Console.WriteLine("Fabricante: Fiat");
    }
  }

  public class Gol: Carro {
    public void exibirInformacao() {
      Console.WriteLine("Modelo: Gol");
      Console.WriteLine("Fabricante: Volkswagen");
    }
  }

  public class Celta: Carro {
    public void exibirInformacao() {
      Console.WriteLine("Modelo: Celta");
      Console.WriteLine("Fabricante: Chevrolet");
    }
  }

  public class Fiesta: Carro {
    public void exibirInformacao() {
      Console.WriteLine("Modelo: Fiesta");
      Console.WriteLine("Fabricante: Ford");
    }
  }

}

class Teste {

  static void Main(string[] args) {

    FabricaDeCarro fabrica = new FabricaFiat();
    Carro carro = fabrica.criarCarro(FabricaFiat.UNO);
    carro.exibirInformacao();

    fabrica = new FabricaFord();
    carro = fabrica.criarCarro();
    carro.exibirInformacao();

    fabrica = new FabricaVolkswagen();
    carro = fabrica.criarCarro();
    carro.exibirInformacao();

    fabrica = new FabricaChevrolet();
    carro = fabrica.criarCarro();
    carro.exibirInformacao();

  }

}
