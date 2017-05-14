using System;
using Emissoes;

namespace Emissoes {

  public interface Emissor {
    void envia(String mensagem);
  }

  public class EmissorSMS: Emissor {
    public void envia(String mensagem) {
      Console.WriteLine("Enviando por SMS a mensagem: ");
      Console.WriteLine(mensagem);
    }
  }

  public class EmissorEmail: Emissor {
    public void envia(String mensagem) {
      Console.WriteLine("Enviando por Email a mensagem: ");
      Console.WriteLine(mensagem);
    }
  }

  public class EmissorJMS: Emissor {
    public void envia(String mensagem) {
      Console.WriteLine("Enviando por JMS a mensagem: ");
      Console.WriteLine(mensagem);
    }
  }

}

class EmissorCreator {
  public const int SMS = 0;
  public const int EMAIL = 1;
  public const int JMS = 2;

  public Emissor create(int tipoDeEmissor) {
    if(tipoDeEmissor == EmissorCreator.SMS) {
      return new EmissorSMS();
    } else if(tipoDeEmissor == EmissorCreator.EMAIL) {
      return new EmissorEmail();
    } else if(tipoDeEmissor == EmissorCreator.JMS) {
      return new EmissorJMS();
    } else {
      throw new ArgumentException("Tipo de emissor não suportado");
    }
  }
}

class Teste {

  static void Main(string[] args) {
    EmissorCreator creator = new EmissorCreator();

    Emissor emissor = creator.create(EmissorCreator.SMS);
    emissor.envia("K19 - Treinamentos");

    emissor = creator.create(EmissorCreator.EMAIL);
    emissor.envia("K19 - Treinamentos");

    emissor = creator.create(EmissorCreator.JMS);
    emissor.envia("K19 - Treinamentos");

  }

}
