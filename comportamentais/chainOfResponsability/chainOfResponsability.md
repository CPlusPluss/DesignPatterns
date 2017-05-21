## Chain of Responsability

Usado para acabar com estruturas de decisão, evitando o acoplamento utilizando uma cadeia de solicitações até que uma trate

Evitar o acoplamento do remetente de uma solicitação ao seu receptor, ao dar a mais de um objeto a oportunidade de tratar a solicitação. Encadear
os objetos receptores, passando a solicitação ao longo da cadeia até que um objeto a trate.

***
#### Diagrama de classe
***

![chainofresponsability](https://cloud.githubusercontent.com/assets/14116020/26278776/037c433e-3d79-11e7-9006-f13473f590f5.png)

* **CorrenteAbstrata**: Classe abstrata que irá definir quem é o próximo da lista de responsabilidade

* **CorrenteConcreta**: Define a implementação das classes concretas que farão parte desse corrente

***
#### Implementação
***

1. Crie a classe abstrata que irá definir quem é o proximo da lista de responsabilidade

    ```c#
    namespace CorrenteAbstrata {
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
    ```

2. Defina a implementação das classes concretas que farão parte desse corrente

    ```c#
    namespace CorrentesConcreta {
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
    ```

3. Defina a main

    ```c#
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
    ```
