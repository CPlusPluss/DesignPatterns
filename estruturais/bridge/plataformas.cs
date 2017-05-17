using System;
using Abstraction;
using Implementation;

namespace Abstraction {

  public abstract class JanelaAbstrata {
    protected JanelaImplementada janela;

    public JanelaAbstrata(JanelaImplementada janela) {
      this.janela = janela;
    }

    public void desenharJanela(string titulo) {
      janela.desenharJanela(titulo);
    }

    public void desenharBotao(string botao) {
      janela.desenharBotao(botao);
    }

    public abstract void desenhar();
  }

  public class JanelaDialogo: JanelaAbstrata {
    public JanelaDialogo(JanelaImplementada janela): base(janela) {}

    public override void desenhar() {
      desenharJanela("Janela de diálogo");
      desenharBotao("Botão SIM");
      desenharBotao("Botão NÃO");
      desenharBotao("Botão Cancelar");
    }
  }

  public class JanelaAviso: JanelaAbstrata {
    public JanelaAviso(JanelaImplementada janela): base(janela) {}

    public override void desenhar() {
      desenharJanela("Janela de aviso");
      desenharBotao("Botão OK");
    }
  }

}

namespace Implementation {

  public interface JanelaImplementada {
    void desenharJanela(string titulo);
    void desenharBotao(string titulo);
  }

  public class JanelaWindows: JanelaImplementada {
    public void desenharJanela(string titulo) {
      Console.WriteLine(titulo + " - Janela Windows");
    }

    public void desenharBotao(string titulo) {
      Console.WriteLine(titulo + " - Botão Windows");
    }
  }

  public class JanelaLinux: JanelaImplementada {
    public void desenharJanela(string titulo) {
      Console.WriteLine(titulo + " - Janela Linux");
    }

    public void desenharBotao(string titulo) {
      Console.WriteLine(titulo + " - Botão Linux");
    }
  }

  public class JanelaMac: JanelaImplementada {
    public void desenharJanela(string titulo) {
      Console.WriteLine(titulo + " - Janela Mac");
    }

    public void desenharBotao(string titulo) {
      Console.WriteLine(titulo + " - Botão Mac");
    }
  }
}

class Testes {
  public static void Main(string[] args) {
    JanelaAbstrata janela = new JanelaDialogo(new JanelaLinux());
    janela.desenhar();
    janela = new JanelaAviso(new JanelaLinux());
    janela.desenhar();

    janela = new JanelaDialogo(new JanelaWindows());
    janela.desenhar();
    janela = new JanelaAviso(new JanelaMac());
    janela.desenhar();
  }
}
