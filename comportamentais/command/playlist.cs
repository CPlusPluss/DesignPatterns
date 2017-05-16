using System;
using System.Collections.Generic;
using Receiver;
using Invoker;
using Commands;

namespace Receiver {
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

namespace Invoker {
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

namespace Commands {
  public interface Comando {
    void executa();
  }

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
