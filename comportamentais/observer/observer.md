## Observer

Atribui aos objetos que tem seus estados alterados a tarefa de notificar os objetos interessados nessas mudanças, por exemplo, Na bolsa de valores as ações estão em constante mudança e as corretoras e bancos sempre querem ficar observando as alterações nessas ações.

***
#### Diagrama de classe
***

![observer](https://cloud.githubusercontent.com/assets/14116020/26278411/77b38388-3d70-11e7-8ba6-ab72db83eee4.png)

* **ObjetoObservadoAbstrato (AcaoAbstrata)**: Interface usada para padronizar os objetos que serão observados.

* **ObjetoObservado (Acao)**: Implementação de um objeto de interesse.

* **Observador (Observador)**: Interface dos observadores interessados no estado dos objetos.

* **ObservadorConcreto (Corretora, Bancos)**: Implementação particular de um Observador.

***
#### Implementação
***

1. Crie uma interface de objetos interessados (**Observador**) nas mudanças do (**ObjetoDeInteresse**) e defina a função para receber notificações para que as classes concretas (**ObjetoConcreto**) possa implementar.

    ```c#
    namespace Observador { 
      public interface AcaoAbstrata {
        void notificaAlteracao(Acao acao);
      }
    }
    ```

    ```c#
    namespace ObservadoresConcretos {
      public class Corretora: Observador {
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

2. Crie a interface (**ObjetoObservadoAbstrato**) que irá padronizar os objetos que serão observados (**ObjetoObservador**), essa classe leva a definição ou implementação de registrar o interessado na lista de interessados e remover ele dessa lista.

    ```c#
    namespace ObjetoObservado {
      public class Acao {
        private string codigo;
        private double valor;
    
        private ArrayList interessados = new ArrayList();
    
        public Acao(string codigo, double valor) {
          this.codigo = codigo;
          this.valor = valor;
        }
    
        public void registraInteressado(Observador interessado) {
          this.interessados.Add(interessado);
        }
    
        public void cancelaInteresse(Observador interessado) {
          this.interessados.Remove(interessado);
        }
    
        public double getValor() {
          return valor;
        }
    
        public void setValor(double valor) {
          this.valor = valor;
          foreach (Observador interessado in this.interessados) {
            interessado.notificaAlteracao(this);
          }
        }
    
        public string getCodigo() {
          return codigo;
        }
      }
    }
    ```

3. O método de **setState()** do (**ObjetoObservado**) irá modificar o valor dos objetos observados e irá percorrer a lista de observadores notificando eles que houve mudanças nos objetos observados.

    ```c#
    public void setValor(double valor) {
      this.valor = valor;
      foreach (Observador interessado in this.interessados) {
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
