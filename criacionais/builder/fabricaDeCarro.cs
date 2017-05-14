using System;
using Montadoras;

public class CarroModel {
  private double preco;
  private string motor;
  private int anoDeFabricacao;
  private string modelo;
  private string montadora;

  public void setPreco(double preco) {
    this.preco = preco;
  }

  public double getPreco() {
    return preco;
  }

  public void setMotor(string motor) {
    this.motor = motor;
  }

  public string getMotor() {
    return motor;
  }

  public void setAnoDeFabricacao(int anoDeFabricacao) {
    this.anoDeFabricacao = anoDeFabricacao;
  }

  public int getAnoDeFabricacao() {
    return anoDeFabricacao;
  }

  public void setModelo(string modelo) {
    this.modelo = modelo;
  }

  public string getModelo() {
    return modelo;
  }

  public void setMontadora(string montadora) {
    this.montadora = montadora;
  }

  public string getMontadora() {
    return montadora;
  }
}

namespace Montadoras {

  public abstract class CarroBuilder {
    protected CarroModel carro;

    public CarroBuilder() {
      carro = new CarroModel();
    }

    public abstract void buildPreco();
    public abstract void buildMotor();
    public abstract void buildAnoDeFabricacao();
    public abstract void buildModelo();
    public abstract void buildMontadora();

    public CarroModel getCarro() {
      return carro;
    }
  }

  public class FiatBuilder: CarroBuilder {
    public override void buildPreco() {
      carro.setPreco(25000.00);
    }

    public override void buildMotor() {
      carro.setMotor("Fire Flex 1.0");
    }

    public override void buildAnoDeFabricacao() {
      carro.setAnoDeFabricacao(2011);
    }

    public override void buildModelo() {
      carro.setModelo("Palio");
    }

    public override void buildMontadora() {
      carro.setMontadora("Fiat");
    }
  }

  public class VolksBuilder: CarroBuilder {
    public override void buildPreco() {
      carro.setPreco(45000.00);
    }

    public override void buildMotor() {
      carro.setMotor("Fire Flex 2.0");
    }

    public override void buildAnoDeFabricacao() {
      carro.setAnoDeFabricacao(2008);
    }

    public override void buildModelo() {
      carro.setModelo("CrossFox");
    }

    public override void buildMontadora() {
      carro.setMontadora("Volkswagen");
    }
  }
}

public class ConcessionariaDirector {
  protected CarroBuilder montadora;

  public ConcessionariaDirector(CarroBuilder montadora) {
    this.montadora = montadora;
  }

  public void construirCarro() {
    montadora.buildPreco();
    montadora.buildAnoDeFabricacao();
    montadora.buildMotor();
    montadora.buildModelo();
    montadora.buildMontadora();
  }

  public CarroModel getCarro() {
    return montadora.getCarro();
  }
}

class Teste {
  public static void Main(string[] args) {
    ConcessionariaDirector concessionaria = new ConcessionariaDirector(new FiatBuilder());
    concessionaria.construirCarro();
    CarroModel carro = concessionaria.getCarro();
    Console.WriteLine("Carro: " + carro.getModelo() + "/" + carro.getMontadora());
    Console.WriteLine("Ano: " + carro.getAnoDeFabricacao());
    Console.WriteLine("Motor: " + carro.getMotor());
    Console.WriteLine("Valor: " + carro.getPreco());

    concessionaria = new ConcessionariaDirector(new VolksBuilder());
    concessionaria.construirCarro();
    carro = concessionaria.getCarro();
    Console.WriteLine("Carro: " + carro.getModelo() + "/" + carro.getMontadora());
    Console.WriteLine("Ano: " + carro.getAnoDeFabricacao());
    Console.WriteLine("Motor: " + carro.getMotor());
    Console.WriteLine("Valor: " + carro.getPreco());
  }
}
