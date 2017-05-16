using System;
using System.Collections;
using InteressadosObserver;
using ObservadosSubject;

namespace InteressadosObserver {

  public interface AcaoObserver {
    void notificaAlteracao(Acao acao);
  }

  public class Corretora: AcaoObserver {
    private string nome;

    public Corretora(string nome) {
      this.nome = nome;
    }

    public void notificaAlteracao(Acao acao) {
      Console.WriteLine("Corretora " + this.nome + " sendo notificada");
      Console.WriteLine("A ação " + acao.getCodigo() + " teve o seu valor alterado para " + acao.getValor());
    }
  }

}

namespace ObservadosSubject {

  public class Acao {
    private string codigo;
    private double valor;

    private ArrayList interessados = new ArrayList();

    public Acao(string codigo, double valor) {
      this.codigo = codigo;
      this.valor = valor;
    }

    public void registraInteressado(AcaoObserver interessado) {
      this.interessados.Add(interessado);
    }

    public void cancelaInteresse(AcaoObserver interessado) {
      this.interessados.Remove(interessado);
    }

    public double getValor() {
      return valor;
    }

    public void setValor(double valor) {
      this.valor = valor;
      foreach (AcaoObserver interessado in this.interessados) {
        interessado.notificaAlteracao(this);
      }
    }

    public string getCodigo() {
      return codigo;
    }
  }

}

class Testes {
  public static void Main(string[] args) {
    Acao acao = new Acao("Vale3", 45.27);

    Corretora corretora1 = new Corretora("Corretora1");
    Corretora corretora2 = new Corretora("Corretora2");

    acao.registraInteressado(corretora1);
    acao.registraInteressado(corretora2);
    acao.cancelaInteresse(corretora2);

    acao.setValor(50);
  }
}
