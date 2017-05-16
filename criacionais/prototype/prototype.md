## Prototype
***
#### Definição
***

Possibilitar a criação de novos objetos a partir da cópia de objetos existentes.

***
#### Diagrama de classe
***

![prototype](https://cloud.githubusercontent.com/assets/14116020/26128202/fc5aefc0-3a61-11e7-8a5d-219907317e48.png)

* **Prototype (CarroPrototype)**: Abstração dos objetos que possuem a capacidade de se auto copiar.

* **ConcretePrototype (FiestaPrototype, GolPrototype, ...)**: Classe que define um tipo particular de objeto que pode ser clonado.

***
#### Implementação
***

1. Primeiro crie a interface de todos os prototipos (**Prototype**)

    ```c#
    namespace Prototype {
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
    }
    ```

2. Crie a implementação dos prototipos (**ConcretePrototype**)

    ```c#
    namespace ConcretePrototype {
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
    ```

3. Crie a main que irá utilizar os prototipos

    ```c#
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
    ```
