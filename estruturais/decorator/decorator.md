## Decorator
***
#### Definição
***

Adiciona funcionalidade a um objeto dinamicamente.

***
#### Diagrama de classe
***

![decorator](https://cloud.githubusercontent.com/assets/14116020/26123876/ea4b5d24-3a52-11e7-9457-bc5d6547f5fa.png)

* **Component (Coquetel)**: Define a interface de objetos que possuem determinada tarefa.

* **ConcreteComponent (Cachaca, Rum, Vodka)**: Implementação particular do Component.

* **Decorator (CoquetelDecorator)**: Classe abstrata que mantém uma referência para um Component e será utilizada para padronizar os objetos decoradores.

* **ConcreteDecorator (Refrigerante, Suco, Acuca, Limao)**: Implementação de um Decorator.

***
#### Implementação
***

1. Defina uma interface ou classe abstrata Coquetel (**Component**)

    ```c#
    namespace Component {
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

2. Crie os tipos de coqueteis (**ConcreteComponent**)

    ```c#
    namespace ConcreteComponent {
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

3. Crie a classe abstrata ou interface que será de base para os decorators (**Decorator**)

    ```c#
    namespace Decorator {
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
    }
    ```

4. Crie os decorators para o coquetel (**ConcreteDecorator**)

    ```c#
    namespace ConcreteDecorator {
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
    ```

5. Teste os decorators

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
