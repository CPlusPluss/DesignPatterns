## Iterator
***
#### Definição
***

Fornecer um modo eficiente para percorrer sequencialmente os elementos de uma coleção, sem que a estrutura interna da coleção seja exposta.

Isso pode facilitar a criação de uma lista única independe do tipo de lista nativa da liguagem utilizar, por exemplo, List<>, ArrayList, HashMap,
...

***
#### Diagrama de classe
***

![iterator](https://cloud.githubusercontent.com/assets/14116020/26138806/18bd8a8e-3aa2-11e7-82e8-0ac2e16d38f1.png)


* **Iterator (AgregadoDeCanais)**: Define a interface dos objetos que encapsulam toda a complexidade para percorrer os elementos do Aggregate.

* **ConcreteIterator (CanaisEsporte, CanaisFilme)**: Implementação da interface Iterator para um tipo específico de Aggregate.

* **Aggregate (IteradorInterface)**: Define a interface das coleções de objetos que podem ter seus elementos percorridos através de um Iterator.

* **ConcreteAggregate (IteradorListaDeCanais, IteradorArrayDeCanais)**: Estrutura de dados que implementa o Aggregate.

***
#### Implementação
***

1. Inicialmente vamos criar uma interface comum à todos os objetos agregados, ou seja uma lista genérica (**Aggregate**)

    ```c#
    namespace Aggregate {
      public interface AgregadoDeCanais {
        IteratorCanais criarIterator();
      }
    }
    ```

2. Agora vamos criar uma lista particular (**ConcreteAggregate**)

    ```c#
    namespace ConcreteAggregate {
      public class CanaisEsporte: AgregadoDeCanais {
        private List<Canal> canais;
    
        public CanaisEsporte() {
          canais = new List<Canal>();
          canais.Add(new Canal("Esporte ao vivo"));
          canais.Add(new Canal("Basquete 2011"));
          canais.Add(new Canal("Campeonato Italiano"));
          canais.Add(new Canal("Campeonato Espanhol"));
          canais.Add(new Canal("Campeonato Brasileiro"));
        }
    
        public IteratorCanais criarIterator() {
          return new IteratorCanais(canais);
        }
      }
    }
    ```

3. Agora vamos a iterface que ira definir o iterator que irá percorrer a lista (**Iterator**)

    ```c#
    namespace Iterator {
      public interface IteratorInterface {
        void first();
        void next();
        void back();
        int count();
        bool isDone();
        Canal currentItem();
      }
    }
    ```

4. Com isso vamos criar os iteradores concretos (**ConcreteIterator**)

    ```c#
    namespace ConcreteIterator {
      public class IteratorCanais: IteratorInterface {
        protected List<Canal> lista;
        protected int contador;
    
        public IteratorCanais(List<Canal> lista) {
          this.lista = lista;
          contador = 0;
        }
    
        public void first() {
          contador = 0;
        }
    
        public void next() {
          contador++;
        }
    
        public void back() {
          contador--;
        }
    
        public int count() {
          return lista.Count;
        }
    
        public bool isDone() {
          return contador == lista.Count;
        }
    
        public Canal currentItem() {
          if (isDone()) {
            contador = lista.Count - 1;
          } else if (contador < 0 || contador > lista.Count) {
            contador = 0;
          }
          return lista[contador];
        }
      }
    }
    ```
5. Crie a main que irá percorrer a lista de canais

    ```c#
    class Testes {
      public static void Main(string[] args) {
        AgregadoDeCanais canais = new CanaisEsporte();
        IteratorInterface iterator;
        for (iterator = canais.criarIterator(); !iterator.isDone(); iterator.next()) {
          Console.WriteLine(iterator.currentItem().getNome());
        }
        Console.WriteLine("\nQuantidade de canais: " + iterator.count() + "\n");
    
        iterator.next();
        Console.WriteLine(iterator.currentItem().getNome());
        iterator.next();
        Console.WriteLine(iterator.currentItem().getNome());
        iterator.next();
        Console.WriteLine(iterator.currentItem().getNome());
        iterator.back();
        Console.WriteLine(iterator.currentItem().getNome());
        iterator.first();
        Console.WriteLine(iterator.currentItem().getNome());
      }
    }
    ```
