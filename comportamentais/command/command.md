## Command

Controlar as chamadas a um determinado componente, modelando cada requisição como um objeto. Permitir que as operações possam ser desfeitas,
enfileiradas ou registradas através de comandos.

A ideia do Command é abstrair um comando que deve ser executado, pois não é possível executá-lo naquele momento (pois precisamos por em uma fila
ou coisa do tipo).

***
#### Diagrama de classe
***

![command](https://cloud.githubusercontent.com/assets/14116020/26278856/a34ed506-3d7a-11e7-9e43-46e45334bd69.png)

* **ComandoAbstrato (Comando)**: Define uma interface para a execução dos métodos do Receiver.

* **ComandoConcreto (TocarMusica, AumentarVolume, DiminuirVolume)**: Classe que implementa ComandoAbstrato e modela uma operação específica do Receiver.

* **Invocador (ListaDeComandos)**: Classe que armazena os Commands que devem ser executados.

* **Receptor (Player)**: Define os objetos que terão as chamadas aos seus métodos controladas.

* **Cliente**: Instancia os Commands associando-os ao Receiver e armazena-os no Invoker.

***
#### Implementação
***

1. Crie uma (**Receptor**) para rodar os comandos de **Comando**

    ```c#
    namespace Receptor {
      public class Player {
        public void play(string fileName) {
          Console.WriteLine("Tocando o arquivo " + fileName);
        }
    
        public void aumentaVolume(int levels) {
          Console.WriteLine("Aumentando o volume em " + levels);
        }
    
        public void diminuiVolume(int levels) {
          Console.WriteLine("Diminuindo o volume em " + levels);
        }
      }
    }
    ```

2. Crie a interface (**Comando**) que será implementada pela ComandoConcreto através do método **executa()**

    ```c#
    namespace Comando {
      public interface Comando {
        void executa();
      }
    }
    ```

3. Crie cada comando (**ComandoConcreto**) que será inserido na lista de comandos e associados ao **Receptor**

    ```c#
    namespace ComandosConcreto {
      public class TocaMusica: Comando {
        private Player player;
        private string file;
    
        public TocaMusica(Player player, string file) {
          this.player = player;
          this.file = file;
        }
    
        public void executa() {
          this.player.play(this.file);
        }
      }
    
      public class AumentaVolume: Comando {
        private Player player;
        private int levels;
    
        public AumentaVolume(Player player, int levels) {
          this.player = player;
          this.levels = levels;
        }
    
        public void executa() {
          this.player.aumentaVolume(this.levels);
        }
      }
    
      public class DiminuiVolume: Comando {
        private Player player;
        private int levels;
    
        public DiminuiVolume(Player player, int levels) {
          this.player = player;
          this.levels = levels;
        }
    
        public void executa() {
          this.player.diminuiVolume(this.levels);
        }
      }
    }
    ```

4. Crie o (**Invocador**) que armazenará a lista de comandos através do método adiciona() executará todos os comandos da lista através do método
   executa()

    ```c#
    namespace Invocador {
      public class ListaDeComandos {
        private List<Comando> comandos = new List<Comando>();
    
        public void adiciona(Comando comando) {
          this.comandos.Add(comando);
        }
    
        public void executa() {
          foreach (Comando comando in this.comandos) {
            comando.executa();
          }
        }
      }
    }
    ```

5. Crie a cliente que irá instanciar um Receptor e o Invocador adicionado cada ComandoConcreto dentro do Invocador e executando-o

    ```c#
    class Testes {
      public static void Main(string[] args) {
        Player player = new Player();
        ListaDeComandos listaDeComandos = new ListaDeComandos();
    
        listaDeComandos.adiciona(new TocaMusica(player, "musica.mp3"));
        listaDeComandos.adiciona(new AumentaVolume(player, 3));
        listaDeComandos.adiciona(new DiminuiVolume(player, 2));
    
        listaDeComandos.executa();
      }
    }
    ```

