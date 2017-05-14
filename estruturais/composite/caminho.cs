using System;
using System.Collections;
using Composites;
using Leafs;

namespace Composites {

  public class Caminho: Trecho {
    private ArrayList trechos;

    public Caminho() {
      this.trechos = new ArrayList();
    }

    public void adicionar(Trecho trecho) {
      this.trechos.Add(trecho);
    }

    public void remover(Trecho trecho) {
      this.trechos.Remove(trecho);
    }

    public void imprime() {
      foreach (Trecho trecho in trechos) {
        trecho.imprime();
      }
    }
  }

}

namespace Leafs {

  public class TrechoAndando: Trecho {
    private string direcao;
    private double distancia;

    public TrechoAndando(string direcao, double distancia) {
      this.direcao = direcao;
      this.distancia = distancia;
    }

    public void imprime() {
      Console.WriteLine("Vá andando: ");
      Console.WriteLine(this.direcao);
      Console.WriteLine("A distância percorrida será de: " + this.distancia + " metros.");
    }
  }

  public class TrechoDeCarro: Trecho {
    private string direcao;
    private double distancia;

    public TrechoDeCarro(string direcao, double distancia) {
      this.direcao = direcao;
      this.distancia = distancia;
    }

    public void imprime() {
      Console.WriteLine("Vá de carro: ");
      Console.WriteLine(this.direcao);
      Console.WriteLine("A distância percorrida será de: " + this.distancia + " metros.");
    }
  }

}

public interface Trecho {
  void imprime();
}

class Testar {
  public static void Main(string[] args) {
    Trecho trecho1 = new TrechoAndando("Vá até o cruzamento da Av. Rebouças com a Av. Brigadeiro Faria Lima", 500);
    Trecho trecho2 = new TrechoDeCarro("Vá até o cruzamento da Av. Brigadeiro com a Av. Cidade Jardim", 1500);
    Trecho trecho3 = new TrechoDeCarro("Vire a direita na Marginal Pinheiros", 500);

    Caminho caminho1 = new Caminho();
    caminho1.adicionar(trecho1);
    caminho1.adicionar(trecho2);

    Console.WriteLine("Caminho 1: ");
    caminho1.imprime();

    Caminho caminho2 = new Caminho();
    caminho2.adicionar(caminho1);
    caminho2.adicionar(trecho3);

    Console.WriteLine("\nCaminho 2: ");
    caminho2.imprime();
  }
}
