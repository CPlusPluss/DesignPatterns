## Abstract Factory
***
#### Definição
***

Fornecer uma interface para criação de famílias de objetos relacionados ou dependentes sem especificar suas classes concretas

Encapsula a escolha da ckasse cibcreta a ser utilizada na criação de objetos de diversas familias.

***
#### Diagrama de classe
***

![abstractfactory](https://cloud.githubusercontent.com/assets/14116020/26125745/9d1cb5d2-3a59-11e7-9e8d-8f3c30b645d6.png)

* **AbstractFactory (FabricaDeCarro)**: Interface que define as assinaturas dos métodos responsáveis pela criação dos objetos uma família.

* **ConcreteFactory (FabricaFiat, FabricaFord, ...)**: Classe que implementa os métodos de criação dos objetos de uma família.

* **AbstractProduct (CarroSedan, CarroPopular)**: Interface que define um tipo de produto ou família de produtos.

* **ConcreteProduct (Siena, FiestaSedan, Palio, Fiesta)**: Implementação particular dessas informações um tipo/família de produto.

* **Cliente**: Usa apenas as interfaces AbstractFactory e AbstractProduct.

***
#### Implementação
***

1. Defina as interfaces que irão definir as familias de produtos (**AbstractProduct**)

    ```c#
    namespace AbstractProduct {
      public interface CarroPopular {
        void exibirInformacao();
      }
    
      public interface CarroSedan {
        void exibirInformacao();
      }
    }
    ```

2. Define os produtos de cada tipo/família (**ConcreteProduct**)

    ```c#
    namespace ConcreteProduct {
      public class Palio: CarroPopular {
        public void exibirInformacao() {
          Console.WriteLine("Modelo: Palio");
          Console.WriteLine("Fábrica: Fiat");
          Console.WriteLine("Categoria: Popular");
        }
      }
    
      public class Siena: CarroSedan {
        public void exibirInformacao() {
          Console.WriteLine("Modelo: Siena");
          Console.WriteLine("Fábrica: Fiat");
          Console.WriteLine("Categoria: Sedan");
        }
      }
    
      public class Fiesta: CarroPopular {
        public void exibirInformacao() {
          Console.WriteLine("Modelo: Fiesta");
          Console.WriteLine("Fábrica: Ford");
          Console.WriteLine("Categoria: Popular");
        }
      }
    
      public class FiestaSedan: CarroSedan {
        public void exibirInformacao() {
          Console.WriteLine("Modelo: Fiesta");
          Console.WriteLine("Fábrica: Ford");
          Console.WriteLine("Categoria: Sedan");
        }
      }
    }
    ```

3. Defina a fabrica que ira definir as fabricas concretas (**AbstractFactory**) passando os tipos de produtos que ela irá fabricar

    ```c#
    namespace AbstractFactory {
      public interface FabricaDeCarro {
        CarroSedan criarCarroSedan();
        CarroPopular criarCarroPopular();
      }
    }
    ```

4. Defina as fabricas concretas que irão criar os carros (**ConcreteFactory**)

    ```c#
    namespace ConcreteFactory {
      public class FabricaFiat: FabricaDeCarro {
        public CarroSedan criarCarroSedan() {
          return new Siena();
        }
    
        public CarroPopular criarCarroPopular() {
          return new Palio();
        }
      }
    
      public class FabricaFord: FabricaDeCarro {
        public CarroSedan criarCarroSedan() {
          return new FiestaSedan();
        }
    
        public CarroPopular criarCarroPopular() {
          return new Fiesta();
        }
      }
    }
    ```

5. Crie o cliente que usará dessas fabricas e carros

    ```c#
    class Teste {
      public static void Main(string[] args) {
        FabricaDeCarro fabrica = new FabricaFiat();
        CarroSedan sedan = fabrica.criarCarroSedan();
        CarroPopular popular = fabrica.criarCarroPopular();
        sedan.exibirInformacao();
        popular.exibirInformacao();
    
        fabrica = new FabricaFord();
        sedan = fabrica.criarCarroSedan();
        popular = fabrica.criarCarroPopular();
        sedan.exibirInformacao();
        popular.exibirInformacao();
      }
    }
    ``` 
