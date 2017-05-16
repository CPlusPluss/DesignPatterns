using System;
using Carros;

namespace Carros {

  public class FiestaPrototype: CarroPrototype {
    protected FiestaPrototype(FiestaPrototype fiesta) {
      this.valorCompra = fiesta.getValorCompra();
    }

    public FiestaPrototype() {
      valorCompra = 0.0;
    }

    public override string exibirInfo() {
      return "Modelo: Fiesta\nMontadora: Ford\nValor: R$ " + getValorCompra();
    }

    public override CarroPrototype clonar() {
      return new FiestaPrototype(this);
    }
  }

}

public abstract class CarroPrototype {
  protected double valorCompra;

  public abstract string exibirInfo();

  public abstract CarroPrototype clonar();

  public double getValorCompra() {
    return valorCompra;
  }

  public void setValorCompra(double valorCompra) {
    this.valorCompra = valorCompra;
  }
}

class Testes {
  public static void Main(string[] args) {
    FiestaPrototype fiesta = new FiestaPrototype();

    CarroPrototype fiestaNovo = fiesta.clonar();
    fiestaNovo.setValorCompra(26900.0);

    CarroPrototype fiestaUsado = fiesta.clonar();
    fiestaUsado.setValorCompra(16000.0);

    Console.WriteLine(fiestaNovo.exibirInfo());
    Console.WriteLine(fiestaUsado.exibirInfo());
  }
}
