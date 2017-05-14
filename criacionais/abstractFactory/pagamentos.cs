using System;
using Bandeiras;
using Fabricas;

namespace Bandeiras {

  public interface Emissor {
    void envia(String mensagem);
  }

  public interface Receptor {
    string recebe();
  }

  public class EmissorVisa: Emissor {
    public void envia(String mensagem) {
      Console.WriteLine("Enviando a seguinte mensagem para a Visa: " + mensagem);
    }
  }

  public class ReceptorVisa: Receptor {
    public string recebe() {
      Console.WriteLine("Recebendo mensagem da Visa.");
      string mensagem = "Mensagem da Visa.";
      return mensagem;
    }
  }

  public class EmissorMastercard: Emissor {
    public void envia(String mensagem) {
      Console.WriteLine("Enviando a seguinte mensagem para o Mastercard: " + mensagem);
    }
  }

  public class ReceptorMastercard: Receptor {
    public string recebe() {
      Console.WriteLine("Recebendo mensagem do Mastercard.");
      string mensagem = "Mensagem do Mastercard.";
      return mensagem;
    }
  }

}

namespace Fabricas {

  public class EmissorCreator {
    public const int VISA = 0;
    public const int MASTERCARD = 1;

    public Emissor create(int tipoDoEmissor) {
      if(tipoDoEmissor == EmissorCreator.VISA) {
        return new EmissorVisa();
      } else if(tipoDoEmissor == EmissorCreator.MASTERCARD) {
        return new EmissorMastercard();
      } else {
        throw new ArgumentException("Tipo de emissor não suportado");
      }
    }
  }

  public class ReceptorCreator {
    public const int VISA = 0;
    public const int MASTERCARD = 1;

    public Receptor create(int tipoDeReceptor) {
      if(tipoDeReceptor == ReceptorCreator.VISA) {
        return new ReceptorVisa();
      } else if(tipoDeReceptor == ReceptorCreator.MASTERCARD) {
        return new ReceptorMastercard();
      } else {
        throw new ArgumentException("Tipo de receptor não suportado");
      }
    }
  }

  public interface ComunicadorFactory {
    Emissor createEmissor();
    Receptor createReceptor();
  }

  public class VisaComunicadorFactory: ComunicadorFactory {
    private EmissorCreator emissorCreator = new EmissorCreator();
    private ReceptorCreator receptorCreator = new ReceptorCreator();

    public Emissor createEmissor() {
      return emissorCreator.create(EmissorCreator.VISA);
    }

    public Receptor createReceptor() {
      return receptorCreator.create(ReceptorCreator.VISA);
    }
  }

  public class MastercardComunicadorFactory: ComunicadorFactory {
    private EmissorCreator emissorCreator = new EmissorCreator();
    private ReceptorCreator receptorCreator = new ReceptorCreator();

    public Emissor createEmissor() {
      return emissorCreator.create(EmissorCreator.MASTERCARD);
    }

    public Receptor createReceptor() {
      return receptorCreator.create(ReceptorCreator.MASTERCARD);
    }
  }
}

class Teste {
  public static void Main(string[] args) {
    ComunicadorFactory comunicador = new VisaComunicadorFactory();
    // ComunicadorFactory comunicador = new MastercardComunicadorFactory();

    string transacao = "Valor=560; Senha=123";
    Emissor emissor = comunicador.createEmissor();
    emissor.envia(transacao);

    Receptor receptor = comunicador.createReceptor();
    string mensagem = receptor.recebe();
    Console.WriteLine(mensagem);
  }
}
