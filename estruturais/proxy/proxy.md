## Proxy
***
#### Definição
***

Controlar as chamadas a um objeto através de outro objeto de mesma interface.

Esse padrão define um intermediário para controlar o acesso a um determinado objeto, podendo adicionar funcionalidades que esse objeto não possui

***
#### Diagrama de classe
***

![proxy](https://cloud.githubusercontent.com/assets/14116020/26135427/c9ddbd32-3a8b-11e7-87b8-b4c80f9de851.png)

* **Subject**: Interface que padroniza RealSubject e Proxy.

* **RealSubject**: Define um tipo de objeto do domínio da aplicação.

* **Proxy**: Define os objetos que controlam o acesso aos RealSubjects.

* **Client**: Cliente que usa o RealSubject por meio do Proxy.

***
#### Implementação
***

1. Defina a classe real

    ```c#
    namespace RealSubject {
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

2. Defina a interface que irá padronizar a classe real com seu proxy

    ```c#
    namespace Subject {
      public interface Conta {
        void deposita(double valor);
        void saca(double valor);
        double getSaldo();
      }
    }
    ```

3. Defina a proxy com as novas funcionalidades ou modificações

    ```c#
    namespace Proxy {
      public class ContaProxy: Conta {
        private Conta conta;
    
        public ContaProxy(Conta conta) {
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

4. Crie a main que irá utilizar a proxy para acessar a classe real

    ```c#
    class Testes {
      public static void Main(string[] args) {
        Conta contaPadrao = new ContaPadrao();
        Conta contaProxy = new ContaProxy(contaPadrao);
        contaProxy.deposita(100);
        Console.WriteLine("Saldo: " + contaProxy.getSaldo());
        contaProxy.saca(59);
        Console.WriteLine("Saldo: " + contaProxy.getSaldo());
      }
    }
    ```
