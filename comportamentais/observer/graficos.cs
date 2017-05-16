using System;
using System.Collections;
using InteressadosObserver;
using ObservadosSubject;

namespace InteressadosObserver {

  public interface DadosObserver {
    void notificaAlteracao(DadosSubject dados);
  }

  public class TabelaObserver: DadosObserver {

    public void notificaAlteracao(DadosSubject dados) {
      Console.WriteLine("Tabela:");
      Console.WriteLine("Valor A: " + dados.getDados().getValorA());
      Console.WriteLine("Valor B: " + dados.getDados().getValorB());
      Console.WriteLine("Valor C: " + dados.getDados().getValorC());
    }
  }

}

namespace ObservadosSubject {

  public class Dados {
    int valorA, valorB, valorC;

    public Dados(int valorA, int valorB, int valorC) {
      this.valorA = valorA;
      this.valorB = valorB;
      this.valorC = valorC;
    }

    public int getValorA() { return valorA; }
    public int getValorB() { return valorB; }
    public int getValorC() { return valorC; }

  }

  public class DadosSubject {
    private ArrayList interessados = new ArrayList();
    Dados dados;

    public DadosSubject(Dados dados) {
      this.dados = dados;
    }

    public void registraInteressado(DadosObserver observer) {
      this.interessados.Add(observer);
    }

    public void cancelaInteresse(DadosObserver observer) {
      this.interessados.Remove(observer);
    }

    public void setDados(Dados dados) {
      this.dados = dados;
      notifyObservers();
    }

    private void notifyObservers() {
      foreach (DadosObserver interessado in this.interessados) {
        interessado.notificaAlteracao(this);
      }
    }

    public Dados getDados() {
      return dados;
    }
  }

}

class Testes {
  public static void Main(string[] args) {
    Dados dados = new Dados(10, 30, 20);
    DadosSubject observados = new DadosSubject(dados);

    TabelaObserver tabela1 = new TabelaObserver();
    TabelaObserver tabela2 = new TabelaObserver();

    observados.registraInteressado(tabela1);
    observados.registraInteressado(tabela2);
    observados.cancelaInteresse(tabela2);

    observados.setDados(new Dados(5, 9, 12));
  }
}


