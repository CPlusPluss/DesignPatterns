using System;
using Components;
using Decorators;

namespace Components {

  public interface Emissor {
    void envia(string mensagem);
  }

  public class EmissorBasico: Emissor {
    public void envia(string mensagem) {
      Console.WriteLine("Enviando mensagem: ");
      Console.WriteLine(mensagem);
    }
  }

}

namespace Decorators {

  public abstract class EmissorDecorator: Emissor {
    private Emissor emissor;

    public EmissorDecorator(Emissor emissor) {
      this.emissor = emissor;
    }

    public abstract void envia(string mensagem);

    public Emissor getEmissor() {
      return this.emissor;
    }
  }

  public class EmissorComCriptografia: EmissorDecorator {
    public EmissorComCriptografia(Emissor emissor): base(emissor) {}

    public override void envia(string mensagem) {
      this.getEmissor().envia(criptografa(mensagem));
    }

    private string criptografa(string mensagem) {
      string mensagemCriptografada = mensagem + " criptografada";
      return mensagemCriptografada;
    }
  }

  public class EmissorComCompressao: EmissorDecorator {
    public EmissorComCompressao(Emissor emissor): base(emissor) {}

    public override void envia(string mensagem) {
      this.getEmissor().envia(comprimida(mensagem));
    }

    private string comprimida(string mensagem) {
      string mensagemComprimida = mensagem + " comprimida";
      return mensagemComprimida;
    }
  }

}

class Testes {
  public static void Main(string[] args) {
    string mensagem = "mensagem muito doida";

    Emissor emissorBasico = new EmissorBasico();
    emissorBasico.envia(mensagem);

    Emissor emissorCriptografado = new EmissorComCriptografia(new EmissorBasico());
    emissorCriptografado.envia(mensagem);

    Emissor emissorComprimido = new EmissorComCompressao(new EmissorBasico());
    emissorComprimido.envia(mensagem);

    Emissor emissorCriptografadoComprimido = new EmissorComCriptografia(new EmissorComCompressao(new EmissorBasico()));
    emissorCriptografadoComprimido.envia(mensagem);
  }
}
