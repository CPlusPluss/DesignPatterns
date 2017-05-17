using System;
using System.Collections.Generic;
using Aggregate;
using Iterator;

namespace Aggregate {

  public interface IteratorInterface {
    void first();
    void next();
    void back();
    int count();
    bool isDone();
    Canal currentItem();
  }

  public class IteratorCanais: IteratorInterface {
    protected List<Canal> lista;
    protected int contador;

    public IteratorCanais(List<Canal> lista) {
      this.lista = lista;
      contador = 0;
    }

    public void first() {
      contador = 0;
    }

    public void next() {
      contador++;
    }

    public void back() {
      contador--;
    }

    public int count() {
      return lista.Count;
    }

    public bool isDone() {
      return contador == lista.Count;
    }

    public Canal currentItem() {
      if (isDone()) {
        contador = lista.Count - 1;
      } else if (contador < 0 || contador > lista.Count) {
        contador = 0;
      }
      return lista[contador];
    }
  }

}

namespace Iterator {

  public interface AgregadoDeCanais {
    IteratorCanais criarIterator();
  }

  public class CanaisEsporte: AgregadoDeCanais {
    private List<Canal> canais;

    public CanaisEsporte() {
      canais = new List<Canal>();
      canais.Add(new Canal("Esporte ao vivo"));
      canais.Add(new Canal("Basquete 2011"));
      canais.Add(new Canal("Campeonato Italiano"));
      canais.Add(new Canal("Campeonato Espanhol"));
      canais.Add(new Canal("Campeonato Brasileiro"));
    }

    public IteratorCanais criarIterator() {
      return new IteratorCanais(canais);
    }
  }

}

public class Canal {
  private string nome;

  public Canal(string nome) {
    this.nome = nome;
  }

  public string getNome() {
    return this.nome;
  }
}

class Testes {
  public static void Main(string[] args) {
    AgregadoDeCanais canais = new CanaisEsporte();
    IteratorInterface iterator;
    for (iterator = canais.criarIterator(); !iterator.isDone(); iterator.next()) {
      Console.WriteLine(iterator.currentItem().getNome());
    }
    Console.WriteLine("\nQuantidade de canais: " + iterator.count() + "\n");

    iterator.next();
    Console.WriteLine(iterator.currentItem().getNome());
    iterator.next();
    Console.WriteLine(iterator.currentItem().getNome());
    iterator.next();
    Console.WriteLine(iterator.currentItem().getNome());
    iterator.back();
    Console.WriteLine(iterator.currentItem().getNome());
    iterator.first();
    Console.WriteLine(iterator.currentItem().getNome());
  }
}
