using System;
using templateMethod;

namespace templateMethod {

  public abstract class ProcessoSeletivo {
    public abstract void provaTeorica();
    public abstract void resistenciaFisica();
    public abstract void provaPratica();
    public abstract void testePsicologico();
    public abstract void exameMedico();

    public void template() {
      provaTeorica();
      provaPratica();
      testePsicologico();
      exameMedico();
      resistenciaFisica();
    }
  }

  public class ConcursoMarinha: ProcessoSeletivo {
    public override void provaTeorica() {
      Console.WriteLine("Prova teorica da marinha concluida!");
    }

    public override void resistenciaFisica() {
      Console.WriteLine("Resistencia fisica da marinha concluida!");
    }

    public override void provaPratica() {
      Console.WriteLine("Prova prática da marinha concluida!");
    }

    public override void testePsicologico() {
      Console.WriteLine("Teste psicologico da marinha concluida!");
    }

    public override void exameMedico() {
      Console.WriteLine("Exame médico da marinha concluida!");
    }
  }

  public class ConcursoAeronautica: ProcessoSeletivo {
    public override void provaTeorica() {
      Console.WriteLine("Prova teorica da aeronautica concluida!");
    }

    public override void resistenciaFisica() {
      Console.WriteLine("Resistencia fisica da aeronautica concluida!");
    }

    public override void provaPratica() {
      Console.WriteLine("Prova prática da aeronautica concluida!");
    }

    public override void testePsicologico() {
      Console.WriteLine("Teste psicologico da aeronautica concluida!");
    }

    public override void exameMedico() {
      Console.WriteLine("Exame médico da aeronautica concluida!");
    }
  }
}

class Testes {
  public static void Main(string[] args) {
    ProcessoSeletivo processo = new ConcursoMarinha();
    processo.template();

    processo = new ConcursoAeronautica();
    processo.template();
  }
}
