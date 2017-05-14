using System;
using API;
using Adaptadores;

namespace API {

  public class OpenGLImage {
    public void glCarregarImagem(string arquivo) {
      Console.WriteLine("Imagem " + arquivo + " carregada.");
    }

    public void glDesenharImagem(int posicaoX, int posicaoY) {
      Console.WriteLine("OpenGL imagem desenhada");
    }
  }

  public class SDL_Surface {
    public void SDL_CarregarSurface(string arquivo) {
      Console.WriteLine("Imagem " + arquivo + " carregada.");
    }

    public void SDL_DesenharSurface(int largura, int altura, int posicaoX, int posicaoY) {
      Console.WriteLine("SDL_Surface desenhada");
    }
  }

}

namespace Adaptadores {

  public class OpenGLImageAdapter: OpenGLImage, ImagemTarget {
    public void carregarImagem(string nomeDoArquivo) {
      glCarregarImagem(nomeDoArquivo);
    }

    public void desenharImagem(int posX, int posY, int largura, int altura) {
      glDesenharImagem(posX, posY);
    }
  }

  public class SDLImageAdapter: SDL_Surface, ImagemTarget {
    public void carregarImagem(string nomeDoArquivo) {
      SDL_CarregarSurface(nomeDoArquivo);
    }

    public void desenharImagem(int posX, int posY, int largura, int altura) {
      SDL_DesenharSurface(largura, altura, posX, posY);
    }
  }

}

public interface ImagemTarget {
  void carregarImagem(string nomeDoArquivo);
  void desenharImagem(int posX, int posY, int largura, int altura);
}

class Teste {
  public static void Main(string[] args) {
    ImagemTarget imagem = new SDLImageAdapter();
    imagem.carregarImagem("sdl.png");
    imagem.desenharImagem(1, 2, 10, 10);

    imagem = new OpenGLImageAdapter();
    imagem.carregarImagem("opengl.png");
    imagem.desenharImagem(3, 4, 20, 20);
  }
}
