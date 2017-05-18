## Flyweight

Compartilhar, de forma eficiente, objetos que são usados em grande quantidade.

***
#### Diagrama de classe
***

![flyweight](https://cloud.githubusercontent.com/assets/14116020/26188147/fc6c6490-3b73-11e7-90ce-01bbeedea5d3.png)

* **ComponenteAbstrato (SpriteAbstrata)**: Interface que define os objetos que serão compartilhados.

* **ComponenteConcreto (Sprite)**: Tipo específico de compartilhamento abstrato.

* **FabricaDeObjetosCompartilhados (FabricaDeSpritesCompartilhadas)**: Classe que controla a criação e recuperação de Componentes.

* **Client**: Utiliza a fabricaDeObjetosCompartilhados para recuperar os ComponentesConcretos.

***
#### Implementação
***

1. Crie as classes modelos para as imagens e pontos do mapa, além das sprites enumeradas, não faz parte do padrão e sim da implementação.

    ```c#
    public enum SPRITES {
      JOGADOR, INIMIGO_1, INIMIGO_2, INIMIGO_3, CENARIO_1, CENARIO_2
    };

    public class Imagem {
      protected string nomeDaImagem;
    
      public Imagem(string imagem) {
        this.nomeDaImagem = imagem;
      }
    
      public void desenharImagem() {
        Console.WriteLine(this.nomeDaImagem + " desenhada!");
      }
    }
    
    public class Ponto {
      public int x, y;
    
      public Ponto(int x, int y) {
        this.x = x;
        this.y = y;
      }
    }
    ```

2. Crie a interface que define os objetos que serão compartilhados (**ComponenteAbstrato**).

    ```c#
    namespace ComponenteAbstrato {
      public interface SpriteAbstrata {
        void desenharImagem(Ponto ponto);
      }
    }
    ```

3. Crie as implementações dos objetos que serão compartilhados no nosso caso sprites (**ComponenteConcreto**)

    ```c#
    namespace ComponentesConcretos {
      public class Sprite: SpriteAbstrata {
        protected Imagem imagem;
    
        public Sprite(string nomeDaImagem) {
          imagem = new Imagem(nomeDaImagem);
        }
    
        public void desenharImagem(Ponto ponto) {
          imagem.desenharImagem();
          Console.WriteLine("No ponto (" + ponto.x + ", " + ponto.y + ")!");
        }
      }
    }
    ```

4. Crie a fabrica que irá controla a criação e recuperação de objetos compartilhados (**FabricaDeObjetosCompartilhados**)

    ```c#
    namespace FabricaDeObjetosCompartilhados {
      public class FabricaDeSpritesCompartilhadas {
        protected List<SpriteAbstrata> sprites;
    
        public FabricaDeObjetosCompartilhados() {
          sprites = new List<SpriteAbstrata>();
          sprites.Add(new Sprite("jogador.png"));
          sprites.Add(new Sprite("inimigo1.png"));
          sprites.Add(new Sprite("inimigo2.png"));
          sprites.Add(new Sprite("inimigo3.png"));
          sprites.Add(new Sprite("cenario1.png"));
          sprites.Add(new Sprite("cenario2.png"));
        }
    
        public SpriteAbstrata getSprite(SPRITES sprite) {
          switch (sprite) {
            case SPRITES.JOGADOR:
              return sprites[0];
            case SPRITES.INIMIGO_1:
              return sprites[1];
            case SPRITES.INIMIGO_2:
              return sprites[2];
            case SPRITES.INIMIGO_3:
              return sprites[3];
            case SPRITES.CENARIO_1:
              return sprites[4];
            case SPRITES.CENARIO_2:
              return sprites[5];
            default:
              throw new ArgumentException("Sprite invalida!");
          }
        }
      }
    }
    ```

5. Crie o cliente que irá utilizar esses objetos compartilhados

    ```c#
    class Testes {
      public static void Main(string[] args) {
        FabricaDeObjetosCompartilhados fabrica = new FabricaDeObjetosCompartilhados();
    
        fabrica.getSprite(SPRITES.CENARIO_1).desenharImagem(new Ponto(0, 0));
        fabrica.getSprite(SPRITES.JOGADOR).desenharImagem(new Ponto(10, 10));
        fabrica.getSprite(SPRITES.INIMIGO_1).desenharImagem(new Ponto(100, 10));
        fabrica.getSprite(SPRITES.INIMIGO_2).desenharImagem(new Ponto(120, 10));
        fabrica.getSprite(SPRITES.INIMIGO_1).desenharImagem(new Ponto(140, 10));
        fabrica.getSprite(SPRITES.INIMIGO_2).desenharImagem(new Ponto(60, 10));
        fabrica.getSprite(SPRITES.CENARIO_2).desenharImagem(new Ponto(50, 40));
        fabrica.getSprite(SPRITES.INIMIGO_3).desenharImagem(new Ponto(170, 20));
      }
    }
    ```
