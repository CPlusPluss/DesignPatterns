using System;
using Fabricas;
using Categorias;

namespace Fabricas {

  public interface FabricaDeCarro {
    CarroSedan criarCarroSedan();
    CarroPopular criarCarroPopular();
  }

  public class FabricaFiat: FabricaDeCarro {
    public CarroSedan criarCarroSedan() {
      return new Siena();
    }

    public CarroPopular criarCarroPopular() {
      return new Palio();
    }
  }

  public class FabricaFord: FabricaDeCarro {
    public CarroSedan criarCarroSedan() {
      return new FiestaSedan();
    }

    public CarroPopular criarCarroPopular() {
      return new Fiesta();
    }
  }

}

namespace Categorias {

  public interface CarroPopular {
    void exibirInformacao();
  }

  public interface CarroSedan {
    void exibirInformacao();
  }

  public class Palio: CarroPopular {
    public void exibirInformacao() {
      Console.WriteLine("Modelo: Palio");
      Console.WriteLine("Fábrica: Fiat");
      Console.WriteLine("Categoria: Popular");
    }
  }

  public class Siena: CarroSedan {
    public void exibirInformacao() {
      Console.WriteLine("Modelo: Siena");
      Console.WriteLine("Fábrica: Fiat");
      Console.WriteLine("Categoria: Sedan");
    }
  }

  public class Fiesta: CarroPopular {
    public void exibirInformacao() {
      Console.WriteLine("Modelo: Fiesta");
      Console.WriteLine("Fábrica: Ford");
      Console.WriteLine("Categoria: Popular");
    }
  }

  public class FiestaSedan: CarroSedan {
    public void exibirInformacao() {
      Console.WriteLine("Modelo: Fiesta");
      Console.WriteLine("Fábrica: Ford");
      Console.WriteLine("Categoria: Sedan");
    }
  }
}

class Teste {
  public static void Main(string[] args) {
    FabricaDeCarro fabrica = new FabricaFiat();
    CarroSedan sedan = fabrica.criarCarroSedan();
    CarroPopular popular = fabrica.criarCarroPopular();
    sedan.exibirInformacao();
    popular.exibirInformacao();

    fabrica = new FabricaFord();
    sedan = fabrica.criarCarroSedan();
    popular = fabrica.criarCarroPopular();
    sedan.exibirInformacao();
    popular.exibirInformacao();
  }
}
