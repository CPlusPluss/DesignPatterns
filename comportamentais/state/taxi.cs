using System;
using Estados;

namespace Estados {

  public interface Bandeira {
    double calculaValorDaCorrida(double tempo, double distancia);
  }

  public class Bandeira1: Bandeira {
    public double calculaValorDaCorrida(double tempo, double distancia) {
      return 5.0 + tempo * 1.5 + distancia * 1.7;
    }
  }

  public class Bandeira2: Bandeira {
    public double calculaValorDaCorrida(double tempo, double distancia) {
      return 10.0 + tempo * 3.0 + distancia * 4.0;
    }
  }

}

public class Taximetro {
  private Bandeira bandeira;

  public Taximetro(Bandeira bandeira) {
    this.bandeira = bandeira;
  }

  public void setBandeira(Bandeira bandeira) {
    this.bandeira = bandeira;
  }

  public double calculaValorDaCorrida(double tempo, double distancia) {
    return this.bandeira.calculaValorDaCorrida(tempo, distancia);
  }
}

class Testes {
  public static void Main(string[] args) {
    Bandeira bandeira1 = new Bandeira1();
    Bandeira bandeira2 = new Bandeira2();

    Taximetro taximetro = new Taximetro(bandeira1);

    double valor1 = taximetro.calculaValorDaCorrida(10, 20);
    Console.WriteLine("Valor da corrida na bandeira 1: " + valor1);

    taximetro.setBandeira(bandeira2);

    double valor2 = taximetro.calculaValorDaCorrida(5, 30);
    Console.WriteLine("Valor da corrida na bandeira 2: " + valor2);
  }
}
