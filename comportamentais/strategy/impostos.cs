using System;
using Impostos;

namespace Impostos {

  public interface CalculaImposto {
    double calculaSalarioComImposto(Funcionario funcionario);
  }

  public class CalculaImpostoQuinzeOuDez: CalculaImposto {
    public double calculaSalarioComImposto(Funcionario funcionario) {
      if (funcionario.getSalarioBase() > 2000) {
        return funcionario.getSalarioBase() * 0.85;
      }
      return funcionario.getSalarioBase() * 0.9;
    }
  }

  public class CalculaImpostoVinteOuQuinze: CalculaImposto {
    public double calculaSalarioComImposto(Funcionario funcionario) {
      if (funcionario.getSalarioBase() > 4000) {
        return funcionario.getSalarioBase() * 0.75;
      }
      return funcionario.getSalarioBase() * 0.9;
    }
  }

}

public class Funcionario {
  public const int DESENVOLVEDOR = 1;
  public const int GERENTE = 2;
  public const int DBA = 3;
  protected double salarioBase;
  protected int cargo;
  protected CalculaImposto estrategiaDeCalculo;

  public Funcionario(int cargo, double salarioBase) {
    this. salarioBase = salarioBase;
    switch(cargo) {
      case DESENVOLVEDOR:
        estrategiaDeCalculo = new CalculaImpostoQuinzeOuDez();
        cargo = DESENVOLVEDOR;
        break;
      case DBA:
        estrategiaDeCalculo = new CalculaImpostoQuinzeOuDez();
        cargo = DBA;
        break;
      case GERENTE:
        estrategiaDeCalculo = new CalculaImpostoVinteOuQuinze();
        cargo = GERENTE;
        break;
      default:
        throw new ArgumentException("Cargo não encontrado");
    }
  }

  public double calcularSalarioComImposto() {
    return estrategiaDeCalculo.calculaSalarioComImposto(this);
  }

  public double getSalarioBase() {
    return salarioBase;
  }
}

class Testes {
  public static void Main(string[] args) {
    Funcionario funcionario1 = new Funcionario(Funcionario.DESENVOLVEDOR, 2100);
    Console.WriteLine(funcionario1.calcularSalarioComImposto());

    Funcionario funcionario2 = new Funcionario(Funcionario.DESENVOLVEDOR, 1700);
    Console.WriteLine(funcionario2.calcularSalarioComImposto());

    Funcionario funcionario3 = new Funcionario(Funcionario.GERENTE, 4700);
    Console.WriteLine(funcionario3.calcularSalarioComImposto());
  }
}
