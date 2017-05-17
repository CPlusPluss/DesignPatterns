using System;
using System.Collections.Generic;
using Pools;

namespace Pools {

  public interface Pool<Type> {
    Type adquire(int numero);
    void libera(int numero);
  }

  public class MesaPool: Pool<Mesa> {
    private List<Mesa> mesasDisponiveis;
    private List<Mesa> mesasOcupadas;

    public MesaPool() {
      this.mesasDisponiveis = new List<Mesa>();
      this.mesasOcupadas = new List<Mesa>();
      this.mesasDisponiveis.Add(new Mesa(1));
      this.mesasDisponiveis.Add(new Mesa(7));
      this.mesasDisponiveis.Add(new Mesa(2));
      this.mesasDisponiveis.Add(new Mesa(5));
      this.mesasDisponiveis.Add(new Mesa(10));
      this.mesasOcupadas.Add(new Mesa(3));
      this.mesasOcupadas.Add(new Mesa(4));
      this.mesasOcupadas.Add(new Mesa(6));
      this.mesasOcupadas.Add(new Mesa(8));
      this.mesasOcupadas.Add(new Mesa(9));
    }

    public Mesa adquire(int numero) {
      foreach (Mesa mesa in this.mesasDisponiveis) {
        if (mesa.getNumero() == numero) {
          Console.WriteLine("Mesa adquirida: " + mesa.getNumero());
          this.mesasOcupadas.Add(mesa);
          this.mesasDisponiveis.Remove(mesa);
          return mesa;
        }
      }
      Console.WriteLine("A mesa número {0} está ocupada", numero);
      return null;
    }

    public void libera(int numero) {
      foreach (Mesa mesa in this.mesasOcupadas) {
        if (mesa.getNumero() == numero) {
          Console.WriteLine("Mesa liberada: " + mesa.getNumero());
          this.mesasDisponiveis.Add(mesa);
          this.mesasOcupadas.Remove(mesa);
          return;
        }
      }
      Console.WriteLine("A mesa número {0} já está disponivel", numero);
    }
  }

}

public class Mesa {
  private int numero;

  public Mesa(int numero) {
    this.numero = numero;
  }

  public int getNumero() {
    return this.numero;
  }
}

class Testes {
  public static void Main(string[] args) {
    Pool<Mesa> mesaPool = new MesaPool();
    Mesa mesa = mesaPool.adquire(7);
    mesa = mesaPool.adquire(3);
    mesaPool.libera(7);
    mesaPool.libera(7);
  }
}
