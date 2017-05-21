## Memento

Sem violar o encapsulamento, capturar e externalizar um estado interno de um objeto, de maneira que o objeto possa ser restaurado para esse
estado mais tarde.

***
#### Diagrama de Classe
***

![memento](https://cloud.githubusercontent.com/assets/14116020/26286168/c5767b10-3e34-11e7-87e5-bfd605ab7eb9.png)

* **Memoria (Memoria)**: Ela simplesmente mantém a String que representa o texto e oferece um getter para esta String, permitindo que ela
  seja recuperada mais tarde

* **Guardador (GuardadorDeTexto)**: O Guardador vai guardar todos as Memorias, permitindo que eles sejam restaurados.

* **Originador (Texto)**: Armazena o subconjunto do estado do objeto em um outro objeto memoria

***
#### Implementação
***

1. Primeiro crie a classe TextoMemoria (**Memoria**) que será responsavel por manter a string que representa o texto e oferecer os getters e
   setters, permitindo que ela seja recuperada mais tarde.

    ```c#
    namespace Memoria {
      public class Memoria {
        protected string estadoDoTexto;
      
        public Memoria(string texto) {
          estadoDoTexto = texto;
        }
      
        public string getTextoSalvo() {
          return estadoDoTexto;
        }
      }
    }
    ```

2. Agora vamos criar o GuardadorDeTexto que irá guardar todos os Memoria, permitindo que eles sejam recuperados

    ```c#
    namespace Guardador {
      public class GuardadosDeTexto {
        protected List<Memoria> estados;
      
        public GuardadorDeTexto() {
          estados = new List<Memoria>();
        }
      
        public void adicionarMemoria(Memoria memoria) {
          estados.Add(memoria);
        }
      
        public Memotira getUltimoEstadoSalvo() {
          if (estados.Count <= 0) {
            return new Memoria("");
          }
          Memoria estadoSalvo = estados[estados.Count -1];
          estados.Remove(estados.Count - 1);
          return estadoSalvo;
        }
      }
    }
    ```

3. Vamos criar a classe texto que possui uma interface que permite escrever um texto, desfazer a operação de escrita e exibir o texto no terminal.

    ```c#
    namespace Originador {
      public class Texto {
        protected string texto;
        GuardadorDeTexto guardador;
      
        public Texto() {
          guardador = new GuardadorDeTexto();
          texto = "";
        }
      
        public void escreverTexto(string novoTexto) {
          guardador.adicionarMemoria(new Memoria(texto));
          texto += novoTexto;
        }
      
        public void desfazerEscrita() {
          texto = guardador.getUltimoEstadoSalvo().getTextoSalvo();
        }
      
        public void mostrarTexto() {
          Console.WriteLine(texto);
        }
      }
    }
    ```

3. Agora vamos criar a main que irá testar isso

    ```c#
    class Testes {
      public static void Main(string[] args) {
        Texto texto = new Texto();
        texto.escreverTexto("Primeira linha do texto \n");
        texto.escreverTexto("Segunda linha do texto \n");
        texto.escreverTexto("Terceira linha do texto \n");
        texto.mostrarTexto();
        texto.desfazerEscrita();
        texto.mostrarTexto();
        texto.desfazerEscrita();
        texto.mostrarTexto();
      }
    }
    ```
