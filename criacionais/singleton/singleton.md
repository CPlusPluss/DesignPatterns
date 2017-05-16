## Singleton
***
#### Definição
***

Permitir a criação de uma única instância de uma classe e fornecer um modo para recuperá-la.

***
#### Diagrama de classe
***

![singleton](https://cloud.githubusercontent.com/assets/14116020/26128579/3f2604e2-3a63-11e7-8e9b-d132ba79adfa.png)

* **singleton ()**: Classe que permite a criação de uma única instância e fornece um método estático para recuperá-la.

* **Cliente**:  Teste da classe singleton

***
#### Implementação
***

1. Crie a classe (**Singleton**), encapsule o construtor e o atributo instancia e crie o método que verifica se
   a instancia já foi criada, caso já retorna a instancia.

    ```c#
    namespace Singleton {
      public class FabricaDeCarro {
    
        protected int totalCarrosFiat;
        protected int totalCarrosFord;
        protected int totalCarrosVolks;
    
        public string criarCarroVolks() {
          return "Carro Volks #" + totalCarrosVolks++ + " criado.";
        }
    
        public string criarCarroFord() {
          return "Carro Ford #" + totalCarrosFord++ + " criado.";
        }
    
        public string criarCarroFiat() {
          return "Carro Fiat #" + totalCarrosFiat++ + " criado.";
        }
    
        public string gerarRelatorio() {
          return "Total de carros Fiat vendidos: " + totalCarrosFiat + "\n" +
                 "Total de carros Ford vendidos: " + totalCarrosFord + "\n" +
                 "Total de carros Volks vendidos: " + totalCarrosVolks + "\n";
        }
    
        private static FabricaDeCarro instancia;
    
        protected FabricaDeCarro() {}
    
        public static FabricaDeCarro getInstancia() {
          if(instancia == null) {
            instancia = new FabricaDeCarro();
          }
          return instancia;
        }
      }
    }
    ```

2. Cria a main para testa o relatorio criado

    ```c#
    class Teste {
      public static void Main(string[] args) {
        FabricaDeCarro fabrica = FabricaDeCarro.getInstancia();
        Console.WriteLine(fabrica.criarCarroFiat());
        Console.WriteLine(fabrica.criarCarroFiat());
        Console.WriteLine(fabrica.criarCarroFord());
        Console.WriteLine(fabrica.criarCarroVolks());
        Console.WriteLine(fabrica.gerarRelatorio());
    
        fabrica = FabricaDeCarro.getInstancia();
        Console.WriteLine(fabrica.gerarRelatorio());
      }
    }
    ```
