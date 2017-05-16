## State
#### Definição
***

Alterar o comportamento de um determinado objeto de acordo com o estado no qual ele se encontra, por exemplo, no jogo do mario, ao pegar um
cogumelo o estado interno do personagem muda e vira um mario grande, e ao pegar um peninha ele aprende a voar, mudando o estado interno do
personagem.

***
#### Diagrama de classe
***

![state](https://cloud.githubusercontent.com/assets/14116020/26089297/f9746320-39d2-11e7-9a17-14667e1c767f.png)

* **State (MarioState)**: Interface para padronizar os estados do Context.

* **ConcreteState (MarioCapa, MarioFogo, MarioGrande, MarioMorto, MarioPequeno)**: Implementação particular de um State. 

* **Contexto (Mario)**: Mantém uma referência para um State que define o estado atual.

***
#### Implementação
***

1. Crie uma interface que define métodos para todos os tipos de estados internos do objeto (**State**)

    ```c#
    namespace State {
      public interface MarioState {
        MarioState pegarCogumelo();
        MarioState pegarFlor();
        MarioState pegarPena();
        MarioState levarDano();
      }
    }
    ```

2. Crie classes para método definido na interface, implemente o método retornando o novo método ou estado atual do objeto, por exemplo, se o
   Mario tiver MarioPequeno e pegarCogumelo() ele vai para o estado MarioGrande e assim por diante. (**ConcreteState**)

    ```c#
    namespace ConcreteState {
      public class MarioPequeno: MarioState {
        public MarioState pegarCogumelo() {
          Console.WriteLine("Mario ficou grande!");
          return new MarioGrande();
        }

        public MarioState pegarFlor() {
          Console.WriteLine("Mario ficou grande e com poder de fogo!");
          return new MarioFogo();
        }

        public MarioState pegarPena() {
          Console.WriteLine("Mario grande com capa");
          return new MarioCapa();
        }

        public MarioState levarDano() {
          Console.WriteLine("Mario morto");
          return new MarioMorto();
        }
      }
  
      public class MarioGrande: MarioState {
        public MarioState pegarCogumelo() {
          Console.WriteLine("Mario ganhou 1000 pontos!");
          return new MarioGrande();
        }

        public MarioState pegarFlor() {
          Console.WriteLine("Mario ficou com poder de fogo!");
          return new MarioFogo();
        }

        public MarioState pegarPena() {
          Console.WriteLine("Mario com capa");
          return new MarioCapa();
        }

        public MarioState levarDano() {
          Console.WriteLine("Mario morto");
          return new MarioMorto();
        }
      }
  
      public class MarioCapa: MarioState {
        public MarioState pegarCogumelo() {
          Console.WriteLine("Mario ganhou 1000 pontos!");
          return new MarioGrande();
        }

        public MarioState pegarFlor() {
          Console.WriteLine("Mario ficou com poder de fogo!");
          return new MarioFogo();
        }

        public MarioState pegarPena() {
          Console.WriteLine("Mario ganhou 1000 pontos!");
          return new MarioCapa();
        }

        public MarioState levarDano() {
          Console.WriteLine("Mario morto");
          return new MarioMorto();
        }
      }
  
      public class MarioFogo: MarioState {
        public MarioState pegarCogumelo() {
          Console.WriteLine("Mario ganhou 1000 pontos!");
          return new MarioGrande();
        }

        public MarioState pegarFlor() {
          Console.WriteLine("Mario ganhou 1000 pontos!");
          return new MarioFogo();
        }

        public MarioState pegarPena() {
          Console.WriteLine("Mario com capa!");
          return new MarioCapa();
        }

        public MarioState levarDano() {
          Console.WriteLine("Mario morto");
          return new MarioMorto();
        }
      }
  
      public class MarioMorto: MarioState {
        public MarioMorto() {
          Console.WriteLine("GameOver!");
          Console.WriteLine("Jogue novamente!");
        }

        public MarioState pegarCogumelo() {
          return new MarioPequeno().pegarCogumelo();
        }

        public MarioState pegarFlor() {
          return new MarioPequeno().pegarFlor();
        }

        public MarioState pegarPena() {
          return new MarioPequeno().pegarPena();
        }

        public MarioState levarDano() {
          Console.WriteLine("Mario morto");
          return new MarioPequeno().levarDano();
        }
      }
    }
    ``` 

3. Crie o (**Contexto**) inicializando no construtor o estado inicial do objeto, e implemente os métodos do State variando seu próprio estado, por
   exemplo:

    ```c#
    namespace Context {
      public class Mario {
        protected MarioState estado;
      
        public Mario() {
          estado = new MarioPequeno();
        }
      
        public void pegarCogumelo() {
          estado = estado.pegarCogumelo();
        }
      
        public void pegarFlor() {
          estado = estado.pegarFlor();
        }
      
        public void pegarPena() {
          estado = estado.pegarPena();
        }
      
        public void levarDano() {
          estado = estado.levarDano();
        }
      }
    }
    ```

4. A classe cliente percorre todos os estados como se tivesse jogando apenas instanciando o Contexto

    ```c#
    class Testes {
      public static void Main(string[] args) {
        Mario mario = new Mario();
        mario.pegarCogumelo();
        mario.pegarPena();
        mario.levarDano();
        mario.pegarFlor();
        mario.pegarFlor();
        mario.levarDano();
        mario.levarDano();
        mario.pegarPena();
      }
    }
    ```
