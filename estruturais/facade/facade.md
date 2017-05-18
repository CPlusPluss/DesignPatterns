## Facade

Prove uma interface simplificada para a utilização de várias interfaces de um subsistema.

A ideia do Facade é a mesma da agência de viagem, ou seja, simplificar a interação de um cliente com diversos sistemas, por exemplo, compnhias
aéreas, hotéis, e etc...

***
#### Diagrama de classe
***

![facade](https://cloud.githubusercontent.com/assets/14116020/26187299/408e468a-3b6e-11e7-9b70-7dfcd5c1d063.png)

* **Fachada (sistemaFachada)**: Classe intermediária que simplifica o acesso aos Componentes.

* **Componentes (SistemaDeAudio, SistemaDeInput, SistemaDeVideo)**: Classes que compõem o subsistema.

* **Cliente**: Classe que usa os Componentes de forma indireta através da Fachada.

***
#### Implementação
***

1. Primeiro defina as classes de subsistemas que serão utilizados no facade (**Componentes**)

    ```c#
    namespace Componentes {
      public class SistemaDeAudio {
        public void configurarFrequencia() {
          Console.WriteLine("Frequencia configurada!");
        }
    
        public void configurarVolume() {
          Console.WriteLine("Volume configurado!");
        }
    
        public void configurarCanais() {
          Console.WriteLine("Canais configurados");
        }
    
        public void reproduzirAudio(string arquivo) {
          Console.WriteLine("Reproduzindo: " + arquivo);
        }
      }
    
      public class SistemaDeInput {
        public void configurarJoystick() {
          Console.WriteLine("Joystick configurado!");
        }
    
        public void configurarTeclado() {
          Console.WriteLine("Teclado configurados");
        }
    
        public void lerInput() {
          Console.WriteLine("Input lido!");
        }
      }
    
      public class SistemaDeVideo {
        public void configurarCores() {
          Console.WriteLine("Cores configurada!");
        }
    
        public void configurarResolucao() {
          Console.WriteLine("Resolução configurados");
        }
    
        public void renderizarImagem(string imagem) {
          Console.WriteLine("Renderizando: " + imagem);
        }
      }
    }
    ```

2. Crie o sistema fachada que irá simplificar a utilização desses subsistemas (**Fachada**)

    ```c#
    namespace Fachada {
      public class SistemaFachada {
        protected SistemaDeAudio audio;
        protected SistemaDeInput input;
        protected SistemaDeVideo video;
      
        public void inicializarSubsistemas() {
          video = new SistemaDeVideo();
          video.configurarCores();
          video.configurarResolucao();
      
          input = new SistemaDeInput();
          input.configurarJoystick();
          input.configurarTeclado();
      
          audio = new SistemaDeAudio();
          audio.configurarCanais();
          audio.configurarFrequencia();
          audio.configurarVolume();
        }
      
        public void reproduzirAudio(string arquivo) {
          audio.reproduzirAudio(arquivo);
        }
      
        public void renderizarImagem(string imagem) {
          video.renderizarImagem(imagem);
        }
      
        public void lerInput() {
          input.lerInput();
        }
      }
    }
    ```

3. Crie o cliente para utilizar desse sistema simplificado

    ```c#
    class Testes {
      public static void Main(string[] args) {
        Console.WriteLine("#### Configurando subsistemas ####");
        SistemaFachada fachada = new SistemaFachada();
        fachada.inicializarSubsistemas();
    
        Console.WriteLine("\n#### Utilizando subsistemas ####");
        fachada.renderizarImagem("imagem.png");
        fachada.reproduzirAudio("audio.mp3");
        fachada.lerInput();
      }
    }
    ```
