## Factory Method

Encapsula a escolha da classe concreta a ser utilizada na criação de objetos de um determinado tipo

A fábrica (interface) cria objetos que só serão definidos em tempo de execução pela suas subclasses

***
#### Diagrama de classe
***

![factorymethod](https://cloud.githubusercontent.com/assets/14116020/26185539/01d47376-3b62-11e7-9c5e-2885e9a3362b.png)

* **FabricaAbstrata (FabricaDeCarro)**: Classe ou interface que define a assinatura do método responsável pela criação do produto.
Pode possuir uma implementação padrão do método de criação do produto.

* **FabricaConcreta (FabricaFiat, FabricaFord, ...)**: Classe que implementa ou sobrescreve o método de criação do produto.

* **ProdutoAbstrato (Carro)**: Classe ou interface que define o objeto a ser criado.

* **ProdutoConcreto (Uno, Fiesta, Gol, Palio, ...)**: Uma implementação particular do tipo de objeto a ser criado.

***
#### Implementação
***

1. Crie a interface que irá definir as fabricas concretas (**FabricaAbstrata**)

    ```c#
    namespace FabricaAbstrata {
      public interface FabricaDeCarro {
        Carro criarCarro(int carro = 0);
      }
    }
    ```

2. Cria as fabricas concretas seguindo a interface definida (**FabricaConcreta**)

    ```c#
    namespace FabricasConcretas {
      public class FabricaFiat: FabricaDeCarro {
        public const int PALIO = 0;
        public const int UNO = 1;
    
        public Carro criarCarro(int carro) {
          if(carro == FabricaFiat.PALIO) {
            return new Palio();
          } else if(carro == FabricaFiat.UNO){
            return new Uno();
          } else {
            throw new ArgumentException("Carro não existe!");
          }
        }
      }
    
      public class FabricaVolkswagen: FabricaDeCarro {
        public Carro criarCarro(int carro) {
          return new Gol();
        }
      }
    
      public class FabricaChevrolet: FabricaDeCarro {
        public Carro criarCarro(int carro) {
          return new Celta();
        }
      }
    
      public class FabricaFord: FabricaDeCarro {
        public Carro criarCarro(int carro) {
          return new Fiesta();
        }
      }
    }
    ```

3. Crie a interface que irá definir os produtos (**ProdutoAbstrato**)

    ```c#
    namespace ProdutoAbstrato {
      public interface Carro {
        void exibirInformacao();
      }
    }
    ```

4. Crie os produtos concretos de acordo com sua interface (**ProdutoConcreto**)

    ```c#
    namespace ProdutosConcretos {
      public class Palio: Carro {
        public void exibirInformacao() {
          Console.WriteLine("Modelo: Palio");
          Console.WriteLine("Fabricante: Fiat");
        }
      }
    
      public class Uno: Carro {
        public void exibirInformacao() {
          Console.WriteLine("Modelo: Uno");
          Console.WriteLine("Fabricante: Fiat");
        }
      }
    
      public class Gol: Carro {
        public void exibirInformacao() {
          Console.WriteLine("Modelo: Gol");
          Console.WriteLine("Fabricante: Volkswagen");
        }
      }
    
      public class Celta: Carro {
        public void exibirInformacao() {
          Console.WriteLine("Modelo: Celta");
          Console.WriteLine("Fabricante: Chevrolet");
        }
      }
    }
    ```

5. Crie a main que irá usar a fabrica e os carros implementados

    ```c#
    class Teste {
      static void Main(string[] args) {
    
        FabricaDeCarro fabrica = new FabricaFiat();
        Carro carro = fabrica.criarCarro(FabricaFiat.UNO);
        carro.exibirInformacao();
    
        fabrica = new FabricaFord();
        carro = fabrica.criarCarro();
        carro.exibirInformacao();
    
        fabrica = new FabricaVolkswagen();
        carro = fabrica.criarCarro();
        carro.exibirInformacao();
    
        fabrica = new FabricaChevrolet();
        carro = fabrica.criarCarro();
        carro.exibirInformacao();
    
      }
    }
    ```
