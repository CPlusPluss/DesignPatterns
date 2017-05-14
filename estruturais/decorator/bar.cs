using System;
using Components;
using Decorators;

namespace Components {

  public abstract class Coquetel {
    protected string nome;
    protected double preco;

    public virtual string getNome() {
      return nome;
    }

    public virtual double getPreco() {
      return preco;
    }
  }

  public class Cachaca: Coquetel {
    public Cachaca() {
      nome = "Cachaça";
      preco = 1.5;
    }
  }

  public class Vodka: Coquetel {
    public Vodka() {
      nome = "Vodka";
      preco = 3.5;
    }
  }

}

namespace Decorators {

  public abstract class CoquetelDecorator: Coquetel {
    Coquetel coquetel;

    public CoquetelDecorator(Coquetel coquetel) {
      this.coquetel = coquetel;
    }

    public override string getNome() {
      return coquetel.getNome() + " + " + nome;
    }

    public override double getPreco() {
      return coquetel.getPreco() + preco;
    }
  }

  public class Refrigerante: CoquetelDecorator {
    public Refrigerante(Coquetel coquetel): base(coquetel) {
      nome = "Refrigerante";
      preco = 1.0;
    }
  }

  public class Acuca: CoquetelDecorator {
    public Acuca(Coquetel coquetel): base(coquetel) {
      nome = "Açuca";
      preco = 0.5;
    }
  }

  public class Dose: CoquetelDecorator {
    public Dose(Coquetel coquetel): base(coquetel) {
      nome = "Dose";
      preco = 2.5;
    }
  }

}

class Testes {
  public static void Main(string[] args) {
    Coquetel coquetel = new Cachaca();
    Console.WriteLine(coquetel.getNome() + " = " + coquetel.getPreco());

    coquetel = new Refrigerante(coquetel);
    Console.WriteLine(coquetel.getNome() + " = " + coquetel.getPreco());

    coquetel = new Acuca(coquetel);
    Console.WriteLine(coquetel.getNome() + " = " + coquetel.getPreco());
  }
}
