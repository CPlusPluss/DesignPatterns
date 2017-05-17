## Bridge
***
#### Definição
***

Separar uma abstração de sua representação, de forma que ambos possam variar e produzir tipos de objetos diferentes.

Por exemplo, a possibilidade de combinar os cartões SIM e os aparelhos celulares de forma independente é a característica principal proposta pelo
padrão Bridge.

***
#### Diagrama de classe
***

![bridge](https://cloud.githubusercontent.com/assets/14116020/26143842/052a5f90-3abd-11e7-869e-2d048ab5047d.png)

* **Abstraction (JanelaAbstrata)**: Define a interface de um determinado tipo de objeto.

* **RefinedAbstraction (JanelaDialogo, janelaAviso)**: Uma implementação particular do Abstraction que delega a um Implementor a realização de
determindas tarefas.

* **Implementor (janelaImplementada)**: Define a interface dos objetos que serão acionados pelos Abstractions .

* **ConcreteImplementor (janelaMac, janelaWindows, janelaMac)**: Uma implementação específica do Implementor

* **Client**: Interage com as Abstractions.

***
#### Implementação
***

1. Crie a interface que irá implementar as janelas de determinada plataforma (Implementador)

    ```c#
    namespace Implementor {
      public interface JanelaImplementada {
        void desenharJanela(string titulo);
        void desenharBotao(string titulo);
      }
    }
    ```

2. Crie as janelas das plataformas especificas de acordo com a interface

    ```c#
    namespace ConcreteImplementor {
      public class JanelaWindows: JanelaImplementada {
        public void desenharJanela(string titulo) {
          Console.WriteLine(titulo + " - Janela Windows");
        }
    
        public void desenharBotao(string titulo) {
          Console.WriteLine(titulo + " - Botão Windows");
        }
      }
    
      public class JanelaLinux: JanelaImplementada {
        public void desenharJanela(string titulo) {
          Console.WriteLine(titulo + " - Janela Linux");
        }
    
        public void desenharBotao(string titulo) {
          Console.WriteLine(titulo + " - Botão Linux");
        }
      }
    
      public class JanelaMac: JanelaImplementada {
        public void desenharJanela(string titulo) {
          Console.WriteLine(titulo + " - Janela Mac");
        }
    
        public void desenharBotao(string titulo) {
          Console.WriteLine(titulo + " - Botão Mac");
        }
      }
    }
    ```


3. Cria a interface da janela abstrata (**Abstraction**)

    ```c#
    namespace Abstraction {
      public abstract class JanelaAbstrata {
        protected JanelaImplementada janela;
    
        public JanelaAbstrata(JanelaImplementada janela) {
          this.janela = janela;
        }
    
        public void desenharJanela(string titulo) {
          janela.desenharJanela(titulo);
        }
    
        public void desenharBotao(string botao) {
          janela.desenharBotao(botao);
        }
    
        public abstract void desenhar();
      }
    }
    ```

4. Cria as janelas abstratas de acordo com a interface definida (RefinedAbstraction)

    ```c#
    namespace RefinedAbstraction {
      public class JanelaDialogo: JanelaAbstrata {
        public JanelaDialogo(JanelaImplementada janela): base(janela) {}
    
        public override void desenhar() {
          desenharJanela("Janela de diálogo");
          desenharBotao("Botão SIM");
          desenharBotao("Botão NÃO");
          desenharBotao("Botão Cancelar");
        }
      }
    
      public class JanelaAviso: JanelaAbstrata {
        public JanelaAviso(JanelaImplementada janela): base(janela) {}
    
        public override void desenhar() {
          desenharJanela("Janela de aviso");
          desenharBotao("Botão OK");
        }
      }
    }
    ```

5. Crie uma main que irá iteragir com as abstrações

    ```c#
    class Testes {
      public static void Main(string[] args) {
        JanelaAbstrata janela = new JanelaDialogo(new JanelaLinux());
        janela.desenhar();
        janela = new JanelaAviso(new JanelaLinux());
        janela.desenhar();
    
        janela = new JanelaDialogo(new JanelaWindows());
        janela.desenhar();
        janela = new JanelaAviso(new JanelaMac());
        janela.desenhar();
      }
    }
    ```
