using System;
using Handler;
using ConcreteHandler;

public enum IDBancos {
  bancoA, bancoB, bancoC
};

namespace Handler {

  public abstract class BancoChain {
    protected BancoChain next;
    protected IDBancos identificadorDoBanco;

    public BancoChain(IDBancos id) {
      next = null;
      identificadorDoBanco = id;
    }

    public void setNext(BancoChain forma) {
      if (next == null) {
        next = forma;
      } else {
        next.setNext(forma);
      }
    }

    public void efetuarPagamento(IDBancos id) {
      if (podeEfetuarPagamento(id)) {
        efetuaPagamento();
      } else {
        if (next == null) {
          throw new ArgumentException("Banco não cadastrado");
        }
        next.efetuarPagamento(id);
      }
    }

    private bool podeEfetuarPagamento(IDBancos id) {
      if (identificadorDoBanco == id) {
        return true;
      }
      return false;
    }

    protected abstract void efetuaPagamento();
  }

}

namespace ConcreteHandler {

  public class BancoA: BancoChain {
    public BancoA(): base(IDBancos.bancoA) {}

    protected override void efetuaPagamento() {
      Console.WriteLine("Pagamento efetuado no banco A");
    }
  }

  public class BancoB: BancoChain {
    public BancoB(): base(IDBancos.bancoB) {}

    protected override void efetuaPagamento() {
      Console.WriteLine("Pagamento efetuado no banco B");
    }
  }

  public class BancoC: BancoChain {
    public BancoC(): base(IDBancos.bancoC) {}

    protected override void efetuaPagamento() {
      Console.WriteLine("Pagamento efetuado no banco C");
    }
  }

}

class Testes {
  public static void Main(string[] args) {
    BancoChain bancos = new BancoA();
    bancos.setNext(new BancoB());
    bancos.setNext(new BancoC());

    try {
      bancos.efetuarPagamento(IDBancos.bancoC);
      bancos.efetuarPagamento(IDBancos.bancoA);
      bancos.efetuarPagamento(IDBancos.bancoB);
    } catch (ArgumentException e) {
      Console.WriteLine(e);
    }
  }
}
