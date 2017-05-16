## Composite
***
#### Definição
***

Agrupa objetos que fazem parte de uma relação parte-todo de forma a tratá-los sem distinção

***
#### Diagrama de classe
***

![composite](https://cloud.githubusercontent.com/assets/14116020/26123130/2fcb5d7a-3a50-11e7-8f0a-75f8aab125d8.png)

* **Component (Trecho)**: Interface que define os elementos da composição.

* **Composite (Caminho)**: Define os Components que são formados por outros Components.

* **Leaf (TrechoAndando, TrechoDeCarro)**: Define os elementos básicos da composição, isto é, aqueles que não são formados por outros
Components.

***
#### Implementação
***

1. Defina a interface Trecho (**Component**):

    ```c#
    namespace Component {
      public interface Trecho {
        void imprime();
      }
    }
    ```

2. Defina as classes que implementam a interface Trecho (**Leaf**):

    ```c#
    namespace Leafs {
      public class TrechoAndando: Trecho {
        private string direcao;
        private double distancia;
    
        public TrechoAndando(string direcao, double distancia) {
          this.direcao = direcao;
          this.distancia = distancia;
        }
    
        public void imprime() {
          Console.WriteLine("Vá andando: ");
          Console.WriteLine(this.direcao);
          Console.WriteLine("A distância percorrida será de: " + this.distancia + " metros.");
        }
      }
    
      public class TrechoDeCarro: Trecho {
        private string direcao;
        private double distancia;
    
        public TrechoDeCarro(string direcao, double distancia) {
          this.direcao = direcao;
          this.distancia = distancia;
        }
    
        public void imprime() {
          Console.WriteLine("Vá de carro: ");
          Console.WriteLine(this.direcao);
          Console.WriteLine("A distância percorrida será de: " + this.distancia + " metros.");
        }
      }
    }
    ```

3. Defina uma classe Caminho que é um Trecho e será composto por um ou mais trechos (**Composite**):

    ```c#
    namespace Composites {
      public class Caminho: Trecho {
        private ArrayList trechos;
    
        public Caminho() {
          this.trechos = new ArrayList();
        }
    
        public void adicionar(Trecho trecho) {
          this.trechos.Add(trecho);
        }
    
        public void remover(Trecho trecho) {
          this.trechos.Remove(trecho);
        }
    
        public void imprime() {
          foreach (Trecho trecho in trechos) {
            trecho.imprime();
          }
        }
      }
    }
    ```

4. Crie uma classe para testar e criar um caminho que é composto por mais de um trecho:

    ```c#
    class Testar {
      public static void Main(string[] args) {
        Trecho trecho1 = new TrechoAndando("Vá até o cruzamento da Av. Rebouças com a Av. Brigadeiro Faria Lima", 500);
        Trecho trecho2 = new TrechoDeCarro("Vá até o cruzamento da Av. Brigadeiro com a Av. Cidade Jardim", 1500);
        Trecho trecho3 = new TrechoDeCarro("Vire a direita na Marginal Pinheiros", 500);
    
        Caminho caminho1 = new Caminho();
        caminho1.adicionar(trecho1);
        caminho1.adicionar(trecho2);
    
        Console.WriteLine("Caminho 1: ");
        caminho1.imprime();
    
        Caminho caminho2 = new Caminho();
        caminho2.adicionar(caminho1);
        caminho2.adicionar(trecho3);
    
        Console.WriteLine("\nCaminho 2: ");
        caminho2.imprime();
      }
    }
    ```

