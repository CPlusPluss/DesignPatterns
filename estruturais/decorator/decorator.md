## Decorator

Adiciona funcionalidade a um objeto dinamicamente.

***
#### Diagrama de classe
***

![decorator](https://cloud.githubusercontent.com/assets/14116020/26187093/dd1ebab8-3b6c-11e7-8591-df374780d1d9.png)

* **ComponenteAbstrato (Coquetel)**: Define a interface de objetos que possuem determinada tarefa.

* **ComponenteConcreto (Cachaca, Rum, Vodka)**: Implementação particular do ComponenteAbstrato.

* **DecoradorAbstrato (DecoradorCoquetel)**: Classe abstrata que mantém uma referência para um Componente e será utilizada para padronizar os objetos decoradores.

* **DecoradorConcreto (Refrigerante, Suco, Acuca, Limao)**: Implementação de um Decorador.

***
#### Implementação
***

1. Defina uma interface ou classe abstrata Coquetel (**ComponenteAbstrato**)

    ```c#
    namespace ComponenteAbstrato {
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
    }
    ```

2. Crie os tipos de coqueteis (**ComponenteConcreto**)

    ```c#
    namespace ComponentesConcretos {
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
    ```

3. Crie a classe abstrata ou interface que será de base para os decoradores (**Decorador**)

    ```c#
    namespace Decorador {
      public abstract class DecoradorCoquetel: Coquetel {
        Coquetel coquetel;
    
        public DecoradorCoquetel(Coquetel coquetel) {
          this.coquetel = coquetel;
        }
    
        public override string getNome() {
          return coquetel.getNome() + " + " + nome;
        }
    
        public override double getPreco() {
          return coquetel.getPreco() + preco;
        }
      }
    }
    ```

4. Crie os decoradores para o coquetel (**DecoradorConcreto**)

    ```c#
    namespace DecoradoresConcretos {
      public class Refrigerante: DecoradorCoquetel {
        public Refrigerante(Coquetel coquetel): base(coquetel) {
          nome = "Refrigerante";
          preco = 1.0;
        }
      }
    
      public class Acuca: DecoradorCoquetel {
        public Acuca(Coquetel coquetel): base(coquetel) {
          nome = "Açuca";
          preco = 0.5;
        }
      }
    
      public class Dose: DecoradorCoquetel {
        public Dose(Coquetel coquetel): base(coquetel) {
          nome = "Dose";
          preco = 2.5;
        }
      }
    }
    ```

5. Teste os decoradores

    ```c#
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
    ```
