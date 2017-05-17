using System;
using Visitor;
using Element;

namespace Visitor {

  public interface ArvoreVisitor {
    void visitar(No no);
  }

  public class ExibirInOrderVisitor: ArvoreVisitor {
    public void visitar(No no) {
      if (no == null) {
        return;
      }
      this.visitar(no.getEsquerdo());
      Console.WriteLine(no.toString());
      this.visitar(no.getDireito());
    }
  }

  public class ExibirPosOrderVisitor: ArvoreVisitor {
    public void visitar(No no) {
      if (no == null) {
        return;
      }
      this.visitar(no.getEsquerdo());
      this.visitar(no.getDireito());
      Console.WriteLine(no.toString());
    }
  }

  public class ExibirPreOrderVisitor: ArvoreVisitor {
    public void visitar(No no) {
      if (no == null) {
        return;
      }
      Console.WriteLine(no.toString());
      this.visitar(no.getEsquerdo());
      this.visitar(no.getDireito());
    }
  }

}

namespace Element {

  public class No {
    protected int chave;
    No esquerdo, direito;

    public No(int chave) {
      this.chave = chave;
      esquerdo = null;
      direito = null;
    }

    public string toString() {
      return chave.ToString();
    }

    public int getChave() {
      return chave;
    }

    public No getEsquerdo() {
      return esquerdo;
    }

    public void setEsquerdo(No esquerdo) {
      this.esquerdo = esquerdo;
    }

    public No getDireito() {
      return direito;
    }

    public void setDireito(No direito) {
      this.direito = direito;
    }
  }

  public class ArvoreBinaria {
    No raiz;
    int quantidadeDeElementos;

    public ArvoreBinaria(int chaveRaiz) {
      raiz = new No(chaveRaiz);
      quantidadeDeElementos = 0;
    }

    public void inserir(int chave) {
      Console.WriteLine("Inserindo a chave " + chave);
      quantidadeDeElementos++;
    }

    public void remover(int chave) {
      Console.WriteLine("Removendo a chave " + chave);
      quantidadeDeElementos--;
    }

    public void buscar(int chave) {
      Console.WriteLine("buscandoa a chave " + chave);
    }

    public void aceitarVisitante(ArvoreVisitor visitor) {
      visitor.visitar(raiz);
    }
  }

}

class Testes {
  public static void Main(string[] args) {
    ArvoreBinaria arvore = new ArvoreBinaria(7);

    arvore.inserir(15);
    arvore.inserir(10);
    arvore.inserir(5);
    arvore.inserir(2);
    arvore.inserir(1);
    arvore.inserir(20);

    Console.WriteLine("#### Exibindo em ordem ####");
    arvore.aceitarVisitante(new ExibirInOrderVisitor());
    Console.WriteLine("#### Exibindo pré ordem ####");
    arvore.aceitarVisitante(new ExibirPreOrderVisitor());
    Console.WriteLine("#### Exibindo pós ordem ####");
    arvore.aceitarVisitante(new ExibirPosOrderVisitor());
  }
}
