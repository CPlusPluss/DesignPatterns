using System;
using System.Collections.Generic;

public class Texto {
  protected string texto;
  TextoCareTaker careTaker;

  public Texto() {
    careTaker = new TextoCareTaker();
    texto = "";
  }

  public void escreverTexto(string novoTexto) {
    careTaker.adicionarMemento(new TextoMemento(texto));
    texto += novoTexto;
  }

  public void desfazerEscrita() {
    texto = careTaker.getUltimoEstadoSalvo().getTextoSalvo();
  }

  public void mostrarTexto() {
    Console.WriteLine(texto);
  }
}

public class TextoMemento {
  protected string estadoTexto;

  public TextoMemento(string texto) {
    estadoTexto = texto;
  }

  public string getTextoSalvo() {
    return estadoTexto;
  }
}

public class TextoCareTaker {
  protected List<TextoMemento> estados;

  public TextoCareTaker() {
    estados = new List<TextoMemento>();
  }

  public void adicionarMemento(TextoMemento memento) {
    estados.Add(memento);
  }

  public TextoMemento getUltimoEstadoSalvo() {
    if (estados.Count <= 0) {
      return new TextoMemento("");
    }
    TextoMemento estadoSalvo = estados[estados.Count -1];
    estados.Remove(estados[estados.Count - 1]);
    return estadoSalvo;
  }
}

class Testes {
  public static void Main(string[] args) {
    Texto texto = new Texto();
    texto.escreverTexto("Primeira linha do texto \n");
    texto.escreverTexto("Segunda linha do texto \n");
    texto.escreverTexto("Terceira linha do texto \n");
    texto.mostrarTexto();
    texto.desfazerEscrita();
    texto.mostrarTexto();
    texto.desfazerEscrita();
    texto.mostrarTexto();
  }
}
