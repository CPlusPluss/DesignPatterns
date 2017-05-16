## Observer
***
#### Definição
***

Atribui aos objetos que tem seus estados alterados a tarefa de notificar os objetos interessados nessas mudanças, por exemplo, Na bolsa de valores as ações estão em constante mudança e as corretoras e bancos sempre querem ficar observando as alterações nessas ações.

***
#### Diagrama de classe
***

![observer](https://cloud.githubusercontent.com/assets/14116020/26085324/d588f7b4-39b9-11e7-9372-84ae045ef90a.png)

* **Subject (AcaoSubject)**: Interface usada para padronizar os objetos que serão observados.

* **ConcreteSubject (Acao)**: Implementação de um Subject.

* **Observer (AcaoObserver)**: Interface dos objetos interessados no estado dos Subjects.

* **ConcreteObserver(Corretora, Bancos)**: Implementação particular de um Observer.

***
#### Implementação
***

1. Crie uma interface de objetos interessados (**Observer**) nas mudanças do (**Subject**) e defina a função para receber notificações para que as classes concretas (**ConcreteObserver**) possa implementar.

    ```c#
    namespace Observer { 
      public interface AcaoObserver {
        void notificaAlteracao(Acao acao);
      }
    }
    ```

    ```c#
    namespace ConcreteObserver {
      public class Corretora: AcaoObserver {
        private string nome;
    
        public Corretora(string nome) {
          this.nome = nome;
        }
    
        public void notificaAlteracao(Acao acao) {
          Console.WriteLine("Corretora " + this.nome + " sendo notificada");
          Console.WriteLine("A ação " + acao.getCodigo() + " teve o seu valor alterado para " + acao.getValor());
        }
      }
    }
    ```

2. Crie a interface (**Subject**) que irá padronizar os objetos que serão observados (**ConcreteSubject**), essa classe leva a definição ou implementação de registrar o interessado na lista de interessados e remover ele dessa lista.

    ```c#
    namespace Subject {
      public class Acao {
        private string codigo;
        private double valor;
    
        private ArrayList interessados = new ArrayList();
    
        public Acao(string codigo, double valor) {
          this.codigo = codigo;
          this.valor = valor;
        }
    
        public void registraInteressado(AcaoObserver interessado) {
          this.interessados.Add(interessado);
        }
    
        public void cancelaInteresse(AcaoObserver interessado) {
          this.interessados.Remove(interessado);
        }
    
        public double getValor() {
          return valor;
        }
    
        public void setValor(double valor) {
          this.valor = valor;
          foreach (AcaoObserver interessado in this.interessados) {
            interessado.notificaAlteracao(this);
          }
        }
    
        public string getCodigo() {
          return codigo;
        }
      }
    }
    ```

3. O método de **setState()** do (**Subject**) irá modificar o valor dos objetos observados e irá percorrer a lista de observadores notificando eles que houve mudanças nos objetos observados.

    ```c#
    public void setValor(double valor) {
      this.valor = valor;
      foreach (AcaoObserver interessado in this.interessados) {
        interessado.notificaAlteracao(this);
      }
    }
    ```

4. Agora só implementar a classe cliente

    ```c#
    class Testes {
      public static void Main(string[] args) {
        Acao acao = new Acao("Vale3", 45.27);
    
        Corretora corretora1 = new Corretora("Corretora1");
        Corretora corretora2 = new Corretora("Corretora2");
    
        acao.registraInteressado(corretora1);
        acao.registraInteressado(corretora2);
        acao.cancelaInteresse(corretora2);
    
        acao.setValor(50);
      }
    }
    ```
