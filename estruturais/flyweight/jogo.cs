using System;
using System.Collections.Generic;
using Flyweight;

namespace Flyweight {

  public interface SpriteFlyweight {
    void desenharImagem(Ponto ponto);
  }

  public class Sprite: SpriteFlyweight {
    protected Imagem imagem;

    public Sprite(string nomeDaImagem) {
      imagem = new Imagem(nomeDaImagem);
    }

    public void desenharImagem(Ponto ponto) {
      imagem.desenharImagem();
      Console.WriteLine("No ponto (" + ponto.x + ", " + ponto.y + ")!");
    }
  }

  public class FlyweightFactory {
    protected List<SpriteFlyweight> flyweights;

    public FlyweightFactory() {
      flyweights = new List<SpriteFlyweight>();
      flyweights.Add(new Sprite("jogador.png"));
      flyweights.Add(new Sprite("inimigo1.png"));
      flyweights.Add(new Sprite("inimigo2.png"));
      flyweights.Add(new Sprite("inimigo3.png"));
      flyweights.Add(new Sprite("cenario1.png"));
      flyweights.Add(new Sprite("cenario2.png"));
    }

    public SpriteFlyweight getFlyweight(Sprites sprite) {
      switch (sprite) {
        case Sprites.JOGADOR:
          return flyweights[0];
        case Sprites.INIMIGO_1:
          return flyweights[1];
        case Sprites.INIMIGO_2:
          return flyweights[2];
        case Sprites.INIMIGO_3:
          return flyweights[3];
        case Sprites.CENARIO_1:
          return flyweights[4];
        case Sprites.CENARIO_2:
          return flyweights[5];
        default:
          throw new ArgumentException("Sprite invalida!");
      }
    }
  }

}

public enum Sprites {
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

class Testes {
  public static void Main(string[] args) {
    FlyweightFactory factory = new FlyweightFactory();

    factory.getFlyweight(Sprites.CENARIO_1).desenharImagem(new Ponto(0, 0));
    factory.getFlyweight(Sprites.JOGADOR).desenharImagem(new Ponto(10, 10));
    factory.getFlyweight(Sprites.INIMIGO_1).desenharImagem(new Ponto(100, 10));
    factory.getFlyweight(Sprites.INIMIGO_2).desenharImagem(new Ponto(120, 10));
    factory.getFlyweight(Sprites.INIMIGO_1).desenharImagem(new Ponto(140, 10));
    factory.getFlyweight(Sprites.INIMIGO_2).desenharImagem(new Ponto(60, 10));
    factory.getFlyweight(Sprites.CENARIO_2).desenharImagem(new Ponto(50, 40));
    factory.getFlyweight(Sprites.INIMIGO_3).desenharImagem(new Ponto(170, 20));
  }
}
