## Memento
***
#### Definição
***

Sem violar o encapsulamento, capturar e externalizar um estado interno de um objeto, de maneira que o objeto possa ser restaurado para esse
estado mais tarde.

***
#### Diagrama de Classe
***

![memento](https://cloud.githubusercontent.com/assets/14116020/26141399/064ffe3a-3ab2-11e7-9ef7-11e173b06201.png)

* **Memento (TextoMemento)**: Ela simplesmente mantém a String que representa o texto e oferece um getter para esta String, permitindo que ela
  seja recuperada mais tarde

* **CareTaker (TextoCareTaker)**: O Caretaker vai guardar todos os Memento, permitindo que eles sejam restaurados.

* **Originator (Texto)**: Armazena o subconjunto do estado do objeto em um outro objeto memento

***
#### Implementação
***

1. Primeiro crie a classe TextoMemento (**Memento**) que será responsavel por manter a string que representa o texto e oferecer os getters e
   setters, permitindo que ela seja recuperada mais tarde.

    ```c#
    namespace Memento {
      public class TextoMemento {
        protected string estadoTexto;
      
        public TextoMemento(string texto) {
          estadoTexto = texto;
        }
      
        public string getTextoSalvo() {
          return estadoTexto;
        }
      }
    }
    ```

2. Agora vamos criar o TextoCareTaker que irá guardar todos os TextoMemento, permitindo que eles sejam recuperados

    ```c#
    namespace CareTaker {
      public class TextoCareTaker {
        protected List<TextoMemento> estados;
      
        public TextoCareTaker() {
          estados = new List<TextoMemento>();
        }
      
        public void adicionarMemento(TextoMemento memento) {
          estados.Add(memento);
        }
      
        public TextoMemento getUltimoEstadoSalvo() {
          if (estados.Count <= 0) {
            return new TextoMemento("");
          }
          TextoMemento estadoSalvo = estados[estados.Count -1];
          estados.Remove(estados.Count - 1);
          return estadoSalvo;
        }
      }
    }
    ```

3. Vamos criar a classe texto que possui uma interface que permite escrever um texto, desfazer a operação de escrita e exibir o texto no terminal.

    ```c#
    namespace Originator {
      public class Texto {
        protected string texto;
        TextoCareTaker careTaker;
      
        public Texto() {
          careTaker = new TextoCareTaker();
          texto = "";
        }
      
        public void escreverTexto(string novoTexto) {
          careTaker.adicionarMemento(new TextoMemento(texto));
          texto += novoTexto;
        }
      
        public void desfazerEscrita() {
          texto = careTaker.getUltimoEstadoSalvo().getTextoSalvo();
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
