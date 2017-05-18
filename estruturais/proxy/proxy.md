## Proxy

Controlar as chamadas a um objeto através de outro objeto de mesma interface.

Esse padrão define um intermediário para controlar o acesso a um determinado objeto, podendo adicionar funcionalidades que esse objeto não possui

***
#### Diagrama de classe
***

![proxy](https://cloud.githubusercontent.com/assets/14116020/26187585/7df69aca-3b70-11e7-88a3-dd7d726bae1c.png)

* **ComponenteAbstrato (Conta)**: Interface que padroniza ComponenteReal e ComponenteIntermediario.

* **ComponenteReal (ContaPadrao)**: Define um tipo de objeto do domínio da aplicação.

* **ComponenteIntermediario (ContaIntermediaria)**: Define os objetos que controlam o acesso aos componentes reais.

* **Client**: Cliente que usa o componente real por meio do componente intermediario.

***
#### Implementação
***

1. Defina a classe real (**ComponenteReal**)

    ```c#
    namespace ComponenteReal {
      public class ContaPadrao: Conta {
        private double saldo = 0;
    
        public void deposita(double valor) {
          this.saldo += valor;
        }
    
        public void saca(double valor) {
          this.saldo -= valor;
        }
    
        public double getSaldo() {
          return this.saldo;
        }
      }
    }
    ```

2. Defina a interface que irá padronizar a classe real com seu intermediario ou proxy (**ComponenteAbstrato**)

    ```c#
    namespace ComponenteAbstrato {
      public interface Conta {
        void deposita(double valor);
        void saca(double valor);
        double getSaldo();
      }
    }
    ```

3. Defina o intermediario com as novas funcionalidades ou modificações (**ComponenteIntermediario**)

    ```c#
    namespace ComponenteIntermediario {
      public class ContaIntermediaria: Conta {
        private Conta conta;
    
        public ContaIntermediaria(Conta conta) {
          this.conta = conta;
        }
    
        public void deposita(double valor) {
          Console.WriteLine("Efetuando o depósito de R$ " + valor + " reais");
          this.conta.deposita(valor);
          Console.WriteLine("Depósito de R$ " + valor + " efetuado...");
        }
    
        public void saca(double valor) {
          Console.WriteLine("Efetuando o saque de R$ " + valor + " reais");
          this.conta.saca(valor);
          Console.WriteLine("Saque de R$ " + valor + " efetuado...");
        }
    
        public double getSaldo() {
          Console.WriteLine("Verificando o saldo...");
          return this.conta.getSaldo();
        }
      }
    }
    ```

4. Crie a main que irá utilizar a proxy ou intermediaria para acessar a classe real

    ```c#
    class Testes {
      public static void Main(string[] args) {
        Conta contaPadrao = new ContaPadrao();
        Conta contaIntermediaria = new ContaIntermediaria(contaPadrao);
        contaIntermediaria.deposita(100);
        Console.WriteLine("Saldo: " + contaIntermediaria.getSaldo());
        contaIntermediaria.saca(59);
        Console.WriteLine("Saldo: " + contaIntermediaria.getSaldo());
      }
    }
    ```
