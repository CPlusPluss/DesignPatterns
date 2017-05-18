## Prototype

Possibilitar a criação de novos objetos a partir da cópia de objetos existentes.

***
#### Diagrama de classe
***

![prototype](https://cloud.githubusercontent.com/assets/14116020/26185361/df214346-3b60-11e7-822b-dc6c89584d9c.png)

* **PrototipoAbstrato (CarroPrototype)**: Abstração dos objetos que possuem a capacidade de se auto copiar.

* **PrototipoConcreto (FiestaPrototype, GolPrototype, ...)**: Classe que define um tipo particular de objeto que pode ser clonado.

***
#### Implementação
***

1. Primeiro crie a interface de todos os prototipos (**PrototipoAbstrato**)

    ```c#
    namespace PrototipoAbstrato {
      public abstract class PrototipoDeCarro {
        protected double valorCompra;
      
        public abstract string exibirInfo();
      
        public abstract PrototipoDeCarro clonar();
      
        public double getValorCompra() {
          return valorCompra;
        }
      
        public void setValorCompra(double valorCompra) {
          this.valorCompra = valorCompra;
        }
      }
    }
    ```

2. Crie a implementação dos prototipos (**PrototipoConcreto**)

    ```c#
    namespace PrototiposConcretos {
      public class Fiesta: PrototipoDeCarro {
        protected Fiesta(Fiesta fiesta) {
          this.valorCompra = fiesta.getValorCompra();
        }
    
        public Fiesta() {
          valorCompra = 0.0;
        }
    
        public override string exibirInfo() {
          return "Modelo: Fiesta\nMontadora: Ford\nValor: R$ " + getValorCompra();
        }
    
        public override PrototipoDeCarro clonar() {
          return new Fiesta(this);
        }
      }
    }
    ```

3. Crie a main que irá utilizar os prototipos

    ```c#
    class Testes {
      public static void Main(string[] args) {
        Fiesta fiesta = new Fiesta();
    
        PrototipoDeCarro fiestaNovo = fiesta.clonar();
        fiestaNovo.setValorCompra(26900.0);
    
        PrototipoDeCarro fiestaUsado = fiesta.clonar();
        fiestaUsado.setValorCompra(16000.0);
    
        Console.WriteLine(fiestaNovo.exibirInfo());
        Console.WriteLine(fiestaUsado.exibirInfo());
      }
    }
    ```
