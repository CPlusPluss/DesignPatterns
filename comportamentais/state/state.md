## State

Alterar o comportamento de um determinado objeto de acordo com o estado no qual ele se encontra, por exemplo, no jogo do mario, ao pegar um
cogumelo o estado interno do personagem muda e vira um mario grande, e ao pegar um peninha ele aprende a voar, mudando o estado interno do
personagem.

***
#### Diagrama de classe
***

![state](https://cloud.githubusercontent.com/assets/14116020/26286256/f780b628-3e36-11e7-8d69-118cb0f08281.png)

* **Estado (MarioEstado)**: Interface para padronizar os estados do Contexto.

* **EstadoConcreto (MarioCapa, MarioFogo, MarioGrande, MarioMorto, MarioPequeno)**: Implementação particular de um Estado. 

* **Contexto (Mario)**: Mantém uma referência para um Estado que define o estado atual.

***
#### Implementação
***

1. Crie uma interface que define métodos para todos os tipos de estados internos do objeto (**Estado**)

    ```c#
    namespace Estado {
      public interface MarioEstado {
        MarioEstado pegarCogumelo();
        MarioEstado pegarFlor();
        MarioEstado pegarPena();
        MarioEstado levarDano();
      }
    }
    ```

2. Crie classes para método definido na interface, implemente o método retornando o novo método ou estado atual do objeto, por exemplo, se o
   Mario tiver MarioPequeno e pegarCogumelo() ele vai para o estado MarioGrande e assim por diante. (**EstadoConcreto**)

    ```c#
    namespace EstadoConcreto {
      public class MarioPequeno: MarioState {
        public MarioEstado pegarCogumelo() {
          Console.WriteLine("Mario ficou grande!");
          return new MarioGrande();
        }

        public MarioEstado pegarFlor() {
          Console.WriteLine("Mario ficou grande e com poder de fogo!");
          return new MarioFogo();
        }

        public MarioEstado pegarPena() {
          Console.WriteLine("Mario grande com capa");
          return new MarioCapa();
        }

        public MarioEstado levarDano() {
          Console.WriteLine("Mario morto");
          return new MarioMorto();
        }
      }
  
      public class MarioGrande: MarioEstado {
        public MarioEstado pegarCogumelo() {
          Console.WriteLine("Mario ganhou 1000 pontos!");
          return new MarioGrande();
        }

        public MarioEstado pegarFlor() {
          Console.WriteLine("Mario ficou com poder de fogo!");
          return new MarioFogo();
        }

        public MarioEstado pegarPena() {
          Console.WriteLine("Mario com capa");
          return new MarioCapa();
        }

        public MarioEstado levarDano() {
          Console.WriteLine("Mario morto");
          return new MarioMorto();
        }
      }
  
      public class MarioCapa: MarioEstado {
        public MarioEstado pegarCogumelo() {
          Console.WriteLine("Mario ganhou 1000 pontos!");
          return new MarioGrande();
        }

        public MarioEstado pegarFlor() {
          Console.WriteLine("Mario ficou com poder de fogo!");
          return new MarioFogo();
        }

        public MarioEstado pegarPena() {
          Console.WriteLine("Mario ganhou 1000 pontos!");
          return new MarioCapa();
        }

        public MarioEstado levarDano() {
          Console.WriteLine("Mario morto");
          return new MarioMorto();
        }
      }
  
      public class MarioFogo: MarioEstado {
        public MarioEstado pegarCogumelo() {
          Console.WriteLine("Mario ganhou 1000 pontos!");
          return new MarioGrande();
        }

        public MarioEstado pegarFlor() {
          Console.WriteLine("Mario ganhou 1000 pontos!");
          return new MarioFogo();
        }

        public MarioEstado pegarPena() {
          Console.WriteLine("Mario com capa!");
          return new MarioCapa();
        }

        public MarioEstado levarDano() {
          Console.WriteLine("Mario morto");
          return new MarioMorto();
        }
      }
  
      public class MarioMorto: MarioEstado {
        public MarioMorto() {
          Console.WriteLine("GameOver!");
          Console.WriteLine("Jogue novamente!");
        }

        public MarioEstado pegarCogumelo() {
          return new MarioPequeno().pegarCogumelo();
        }

        public MarioEstado pegarFlor() {
          return new MarioPequeno().pegarFlor();
        }

        public MarioEstado pegarPena() {
          return new MarioPequeno().pegarPena();
        }

        public MarioEstado levarDano() {
          Console.WriteLine("Mario morto");
          return new MarioPequeno().levarDano();
        }
      }
    }
    ``` 

3. Crie o (**Contexto**) inicializando no construtor o estado inicial do objeto, e implemente os métodos do State variando seu próprio estado, por
   exemplo:

    ```c#
    namespace Contexto {
      public class Mario {
        protected MarioEstado estado;
      
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
