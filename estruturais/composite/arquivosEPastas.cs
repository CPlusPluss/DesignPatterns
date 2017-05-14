using System;
using System.Collections;
using Composites;
using Leafs;

namespace Composites {

  public class ArquivoComposite: ArquivoComponent {
    ArrayList arquivos = new ArrayList();

    public ArquivoComposite(string nomeDoArquivo) {
      this.nomeDoArquivo = nomeDoArquivo;
    }

    public override void printNomeDoArquivo() {
      Console.Write(this.nomeDoArquivo);
      foreach (ArquivoComponent arquivo in arquivos) {
        arquivo.printNomeDoArquivo();
      }
    }

    public override void adicionar(ArquivoComponent novoArquivo) {
      this.arquivos.Add(novoArquivo);
    }

    public override void remover(string nomeDoArquivo) {
      foreach (ArquivoComponent arquivo in arquivos) {
        if (arquivo.getNomeDoArquivo() == nomeDoArquivo) {
          this.arquivos.Remove(arquivo);
          return;
        }
      }
      throw new ArgumentException("Não existe esse arquivo.");
    }

    public override ArquivoComponent getArquivo(string nomeDoArquivo) {
      foreach (ArquivoComponent arquivo in arquivos) {
        if (arquivo.getNomeDoArquivo() == nomeDoArquivo) {
          return arquivo;
        }
      }
      throw new ArgumentException("Não existe esse arquivo.");
    }
  }

}

namespace Leafs {

  public class ArquivoVideo: ArquivoComponent {
    public ArquivoVideo(string nomeDoArquivo) {
      this.nomeDoArquivo = nomeDoArquivo;
    }
  }

  public class ArquivoFoto: ArquivoComponent {
    public ArquivoFoto(string nomeDoArquivo) {
      this.nomeDoArquivo = nomeDoArquivo;
    }
  }

}

public abstract class ArquivoComponent {
  public string nomeDoArquivo;

  public virtual void printNomeDoArquivo() {
    Console.Write(this.nomeDoArquivo);
  }

  public virtual string getNomeDoArquivo() {
    return this.nomeDoArquivo;
  }

  public virtual void adicionar(ArquivoComponent novoArquivo) {
    throw new ArgumentException("Não pode inserir arquivos em: " + this.nomeDoArquivo + " - Não é uma pasta.");
  }

  public virtual void remover(string nomeDoArquivo) {
    throw new ArgumentException("Não pode remover arquivos em: " + this.nomeDoArquivo + " - Não é uma pasta.");
  }

  public virtual ArquivoComponent getArquivo(string nomeDoArquivo) {
    throw new ArgumentException("Não pode pesquisar arquivos em: " + this.nomeDoArquivo + " - Não é uma pasta.");
  }
}

class Teste {
  public static void Main(string[] args) {
    ArquivoComponent pasta = new ArquivoComposite("Pasta");
    ArquivoComponent arquivoVideo = new ArquivoVideo("Arquivo vídeo");
    ArquivoComponent arquivoFoto = new ArquivoFoto("Arquivo foto");

    try {
      pasta.adicionar(arquivoVideo);
      pasta.adicionar(arquivoVideo);
      pasta.adicionar(arquivoFoto);
      pasta.printNomeDoArquivo();
    } catch (ArgumentException e) {
      Console.WriteLine(e);
    }

    try {
      Console.WriteLine("\nPesquisando arquivos: ");
      pasta.getArquivo(arquivoVideo.getNomeDoArquivo());
      pasta.printNomeDoArquivo();
      Console.WriteLine("\nRemover arquivos: ");
      pasta.remover(arquivoFoto.getNomeDoArquivo());
      pasta.printNomeDoArquivo();
    } catch (ArgumentException e) {
      Console.WriteLine(e);
    }


    try {
      arquivoVideo.adicionar(arquivoFoto);
    } catch (ArgumentException e) {
      Console.WriteLine("\n" + e);
    }

  }
}
