using System;
using Components;

namespace Components {

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

public class SistemasFacade {

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

class Testes {
  public static void Main(string[] args) {
    Console.WriteLine("#### Configurando subsistemas ####");
    SistemasFacade fachada = new SistemasFacade();
    fachada.inicializarSubsistemas();

    Console.WriteLine("\n#### Utilizando subsistemas ####");
    fachada.renderizarImagem("imagem.png");
    fachada.reproduzirAudio("audio.mp3");
    fachada.lerInput();
  }
}
