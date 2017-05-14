using System;
using System.Text;
using System.Threading;
using Controles;

namespace Controles {

  public class Funcionario {
    private string nome;

    public Funcionario(string nome) {
      this.nome = nome;
    }

    public string getNome() {
      return nome;
    }
  }

  public class ControleDePonto {
    public void registraEntrada(Funcionario funcionario) {
      StringBuilder stringBuilder = new StringBuilder();
      stringBuilder.Append(String.Format("Entrada: {0} às {1}:{2}:{3}", funcionario.getNome(), DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second));
      Console.WriteLine(stringBuilder);
    }

    public void registraSaida(Funcionario funcionario) {
      StringBuilder stringBuilder = new StringBuilder();
      stringBuilder.Append(String.Format("Saída: {0} às {1}:{2}:{3}", funcionario.getNome(), DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second));
      Console.WriteLine(stringBuilder);
    }
  }

  public class ControleDePontoAdapter: ControleDePonto {
    private ControleDePontoNovo controleDePontoNovo;

    public ControleDePontoAdapter() {
      this.controleDePontoNovo = new ControleDePontoNovo();
    }

    public new void registraEntrada(Funcionario funcionario) {
      this.controleDePontoNovo.registra(funcionario, true);
    }

    public new void registraSaida(Funcionario funcionario) {
      this.controleDePontoNovo.registra(funcionario, false);
    }
  }

  public class ControleDePontoNovo {
    public void registra(Funcionario funcionario, bool entrada) {
      StringBuilder stringBuilder = new StringBuilder();

      if(entrada == true) {
        stringBuilder.Append(String.Format("Entrada: {0} às {1}:{2}:{3}", funcionario.getNome(), DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second));
        Console.WriteLine(stringBuilder);
      } else {
      stringBuilder.Append(String.Format("Saída: {0} às {1}:{2}:{3}", funcionario.getNome(), DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second));
      Console.WriteLine(stringBuilder);
      }
    }
  }

}

class Teste {

  public static void Main(string[] args) {
    ControleDePonto controleDePonto = new ControleDePontoAdapter();
    Funcionario funcionario = new Funcionario("Marcelo Adnet");
    controleDePonto.registraEntrada(funcionario);
    Thread.Sleep(3000);
    controleDePonto.registraSaida(funcionario);
  }

}
