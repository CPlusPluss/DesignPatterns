using System;
using Abstraction;
using Implementor;

namespace Abstraction {

  public interface Documento {
    void geraArquivo();
  }

  public class Recibo: Documento {
    private string emissor;
    private string favorecido;
    private double valor;
    private GeradorDeArquivo geradorDeArquivo;

    public Recibo(string emissor, string favorecido, double valor, GeradorDeArquivo gerador) {
      this.emissor = emissor;
      this.favorecido = favorecido;
      this.valor = valor;
      this.geradorDeArquivo = gerador;
    }

    public void geraArquivo() {
      string nomeDoArquivo = "recibo";
      string conteudo = "Empresa: " + this.emissor +
                        "\nCliente: " + this.favorecido +
                        "\nValor: " + this.valor;
      this.geradorDeArquivo.gera(nomeDoArquivo, conteudo);
    }
  }

}

namespace Implementor {

  public interface GeradorDeArquivo {
    void gera(string nomeDoArquivo, string conteudo);
  }

  public class GeradorDeArquivoTXT: GeradorDeArquivo {
    public void gera(string nomeDoArquivo, string conteudo) {
        Console.WriteLine("Arquivo: " + nomeDoArquivo + ".txt");
        Console.WriteLine(conteudo);
    }
  }

  public class GeradorDeArquivoJSON: GeradorDeArquivo {
    public void gera(string nomeDoArquivo, string conteudo) {
        Console.WriteLine("Arquivo: " + nomeDoArquivo + ".json");
        Console.WriteLine(conteudo);
    }
  }

}

class Testes {
  public static void Main(string[] args) {
   GeradorDeArquivo geradorDeArquivoTXT = new GeradorDeArquivoTXT();
   GeradorDeArquivo geradorDeArquivoJSON = new GeradorDeArquivoJSON();
   Documento reciboTXT = new Recibo("K19 Treinamentos", "Marcelo Martins", 1000, geradorDeArquivoTXT);
   reciboTXT.geraArquivo();
   Documento reciboJSON = new Recibo("K19 Treinamentos", "Marcelo Martins", 1000, geradorDeArquivoJSON);
   reciboJSON.geraArquivo();
  }
}
