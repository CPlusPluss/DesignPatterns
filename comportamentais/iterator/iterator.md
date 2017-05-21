## Iterator

Fornecer um modo eficiente para percorrer sequencialmente os elementos de uma coleção, sem que a estrutura interna da coleção seja exposta.

Isso pode facilitar a criação de uma lista única independe do tipo de lista nativa da liguagem utilizar, por exemplo, List<>, ArrayList, HashMap,
...

***
#### Diagrama de classe
***

![iterator](https://cloud.githubusercontent.com/assets/14116020/26286031/e0aced2c-3e31-11e7-8900-a3fbbdff0ab0.png)

* **Iterador (IteradorInterface)**: Define a interface dos objetos que encapsulam toda a complexidade para percorrer os elementos do Agregador.

* **IteradorConcreto (IteradorDeCanais)**: Implementação da interface Iterador para um tipo específico de Agregador.

* **Agregador (ConjuntoDeCanais)**: Define a interface das coleções de objetos que podem ter seus elementos percorridos através de um Iterador.

* **AgregadorConcreto (CanaisEsporte, CanaisFilme)**: Estrutura de dados que implementa o Agregador.

***
#### Implementação
***

1. Inicialmente vamos criar uma interface comum à todos os objetos agregados, ou seja uma lista genérica (**Agregador**)

    ```c#
    namespace Agregador {
      public interface ConjuntoDeCanais {
        IteradorDeCanais criarIterator();
      }
    }
    ```

2. Agora vamos criar uma lista particular (**AgregadorConcreto**)

    ```c#
    namespace AgregadoresConcretos {
      public class CanaisEsporte: ConjuntoDeCanais {
        private List<Canal> canais;
    
        public CanaisEsporte() {
          canais = new List<Canal>();
          canais.Add(new Canal("Esporte ao vivo"));
          canais.Add(new Canal("Basquete 2011"));
          canais.Add(new Canal("Campeonato Italiano"));
          canais.Add(new Canal("Campeonato Espanhol"));
          canais.Add(new Canal("Campeonato Brasileiro"));
        }
    
        public IteradorDeCanais criarIterator() {
          return new IteradorDeCanais(canais);
        }
      }
    }
    ```

3. Agora vamos a iterface que ira definir o iterador que irá percorrer a lista (**Iterador**)

    ```c#
    namespace Iterador {
      public interface IteradorInterface {
        void first();
        void next();
        void back();
        int count();
        bool isDone();
        Canal currentItem();
      }
    }
    ```

4. Com isso vamos criar os iteradores concretos (**IteradorConcreto**)

    ```c#
    namespace IteradoresConcretos {
      public class IteradorDeCanais: IteradorInterface {
        protected List<Canal> lista;
        protected int contador;
    
        public IteradorDeCanais(List<Canal> lista) {
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
        ConjuntoDeCanais canais = new CanaisEsporte();
        IteradorInterface iterador;
        for (iterador = canais.criarIterador(); !iterador.isDone(); iterador.next()) {
          Console.WriteLine(iterador.currentItem().getNome());
        }
        Console.WriteLine("\nQuantidade de canais: " + iterador.count() + "\n");
    
        iterador.next();
        Console.WriteLine(iterador.currentItem().getNome());
        iterador.next();
        Console.WriteLine(iterador.currentItem().getNome());
        iterador.next();
        Console.WriteLine(iterador.currentItem().getNome());
        iterador.back();
        Console.WriteLine(iterador.currentItem().getNome());
        iterador.first();
        Console.WriteLine(iterador.currentItem().getNome());
      }
    }
    ```
