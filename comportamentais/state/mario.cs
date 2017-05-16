using System;
using Estados;

namespace Estados {

  public interface MarioState {
    MarioState pegarCogumelo();
    MarioState pegarFlor();
    MarioState pegarPena();
    MarioState levarDano();
  }

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
