using System;
using System.Collections;
using Colleagues;
using Mediators;

namespace Colleagues {

  public abstract class Colleague {
    protected Mediator mediator;

    public Colleague(Mediator mediator) {
      this.mediator = mediator;
    }

    public void enviaMensagem(string mensagem) {
      mediator.envia(mensagem, this);
    }

    public abstract void recebeMensagem(string mensagem);
  }

  public class AndroidColleague: Colleague {
    public AndroidColleague(Mediator mediator): base(mediator) {}

    public override void recebeMensagem(string mensagem) {
      Console.WriteLine("Android recebeu: " + mensagem);
    }
  }

  public class IOSColleague: Colleague {
    public IOSColleague(Mediator mediator): base(mediator) {}

    public override void recebeMensagem(string mensagem) {
      Console.WriteLine("IOS recebeu: " + mensagem);
    }
  }

}

namespace Mediators {

  public interface Mediator {
    void envia(string mensagem, Colleague colleague);
  }

  public class MensagemMediator: Mediator {
    protected ArrayList contatos;

    public MensagemMediator() {
      contatos = new ArrayList();
    }

    public void adicionaColleague(Colleague colleague) {
      contatos.Add(colleague);
    }

    public void envia(string mensagem, Colleague colleague) {
      foreach (Colleague contato in contatos) {
        if (contato != colleague) {
          definirProtocolo(contato);
          contato.recebeMensagem(mensagem);
        }
      }
    }

    private void definirProtocolo(Colleague contato) {
      if (contato.GetType() == typeof(IOSColleague)) {
        Console.WriteLine("Protocolo IOS");
      } else if (contato.GetType() == typeof(AndroidColleague)) {
        Console.WriteLine("Protocolo Android");
      }
    }
  }

}

class Testes {
  public static void Main(string[] args) {
    MensagemMediator mediator = new MensagemMediator();

    AndroidColleague android = new AndroidColleague(mediator);
    IOSColleague ios = new IOSColleague(mediator);

    mediator.adicionaColleague(android);
    mediator.adicionaColleague(ios);

    android.enviaMensagem("Oi, eu sou o android");
    ios.enviaMensagem("Olá android, eu sou o IOS");
    ios.enviaMensagem("Como você está?");
    android.enviaMensagem("Estou bem e você?");
    ios.enviaMensagem("Estou ótimo!");
  }
}
