## Strategy

O padrão Strategy é muito útil quando temos um conjunto de algoritmos similares, e precisamos alternar entre eles em diferentes pedaços da
aplicação.

A ideia fundamental desse padrão é possibilitar facilmente a variação do algoritmo a ser utilizado na resolução de um problema

***
#### Diagrama de classe
***

![strategy](https://cloud.githubusercontent.com/assets/14116020/26229921/8700fc18-3c1b-11e7-9a28-a07db9cda4d9.png)

* **Estrategia (CalculaImposto)**: Interface para padronizar as diferentes estratégias de um algoritmo.

* **EstrategiaConcreta (CalculaImpostoQuinzeOuDez, CalculaImpostoVinteOuQuinze)**: Implementação particular de uma estrategia.

* **Contexto (Funcionario)**: Mantém uma referência para um objeto Strategia e pode permitir que esse acesse os seus dados.

***
#### Implementação
***

1. Primeiro vamos encapsular todos os algoritmos da mesma familia na interface (**Strategia**).

    ```c#
    namespace Strategia {
      public interface CalculaImposto {
        double calculaSalarioComImposto(Funcionario funcionario);
      }
    }    
    ```

2. Uma vez definida a classe, vamos definir as estrategias concretas (**EstrategiaConcreta**)

    ```c#
    namespace EstrategiaConcreta {
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
    ```

3. Agora só criar o (**Contexto**) na qual a estrategia irá se aplicar

    ```c#
    namespace Context {
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
    }
    ```

4. Agora iremos implementar o cliente, instanciando apenas o funcionario e passando seu cargo como parâmetro.

    ```c#
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
    ```
