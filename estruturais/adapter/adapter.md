## Adapter
***
#### Definição
***

Permite que um objeto seja substituido por outro que, apesar de realizar a mesma tarefa, possui uma interface diferente.

***
#### Diagrama de classe
***

![adapter](https://cloud.githubusercontent.com/assets/14116020/26122241/329a3d08-3a4d-11e7-8b8f-c6a8a6a17f51.png)

* **Target (ControleDePonto)**: Define a interface utilizada pelo cliente

* **Adapter (ControleDePontoAdapter)**: Classe que implementa a interface definida pelo Target e adapta as chamadas do Client para o Adaptee.

* **Adaptee (ControleDePontoNovo)**: Classe que define o novo objeto a ser utilizado.

* **Cliente**: Interage com os objetos através da interface definida por Target.

***
#### Implementação
***

1. Primeiro crie a classe funcionario que terá os dados do funcionario

    ```c#
    public class Funcionario {
      private string nome;
  
      public Funcionario(string nome) {
        this.nome = nome;
      }
  
      public string getNome() {
        return nome;
      }
    }
    ```

2. Defina qual o ponto de controle antigo ou o (**Target**) a qual precisa ser adaptado para o novo

    ```c#
    namespace Target {  
      public class ControleDePonto {
        public void registraEntrada(Funcionario funcionario) {
          StringBuilder stringBuilder = new StringBuilder();
          stringBuilder.Append(String.Format("Entrada: {0} às {1}:{2}:{3}",
            funcionario.getNome(),
            DateTime.Now.Hour,
            DateTime.Now.Minute,
            DateTime.Now.Second));
          Console.WriteLine(stringBuilder);
        }
    
        public void registraSaida(Funcionario funcionario) {
          StringBuilder stringBuilder = new StringBuilder();
          stringBuilder.Append(String.Format("Saída: {0} às {1}:{2}:{3}",
            funcionario.getNome(),
            DateTime.Now.Hour,
            DateTime.Now.Minute,
            DateTime.Now.Second));
          Console.WriteLine(stringBuilder);
        }
      }
    }
    ```

3. Defina qual a novo ponto de controle ou (**Adaptee**) que será usado no lugar do velho definido anteriormente.

    ```c#
    namespace Adaptee {
      public class ControleDePontoNovo {
        public void registra(Funcionario funcionario, bool entrada) {
          StringBuilder stringBuilder = new StringBuilder();
    
          if(entrada == true) {
            stringBuilder.Append(String.Format("Entrada: {0} às {1}:{2}:{3}",
              funcionario.getNome(),
              DateTime.Now.Hour,
              DateTime.Now.Minute,
              DateTime.Now.Second));
            Console.WriteLine(stringBuilder);
          } else {
            stringBuilder.Append(String.Format("Saída: {0} às {1}:{2}:{3}",
              funcionario.getNome(),
              DateTime.Now.Hour,
              DateTime.Now.Minute,
              DateTime.Now.Second));
            Console.WriteLine(stringBuilder);
          }
        }
      }
    }
    ```

4. Agora só criar o adaptador (**Adapter**) que será utilizado para substituir o velho pelo novo sem mudar sua estrutura.

    ```c#
    namespace Adapter {
      public class ControleDePontoAdapter: ControleDePonto {
        private ControleDePontoNovo controleDePontoNovo;
    
        public ControleDePontoAdapter() {
          this.controleDePontoNovo = new ControleDePontoNovo();
        }
    
        public new void registraEntrada(Funcionario funcionario) {
          this.controleDePontoNovo.registra(funcionario, true);
        }
    
        public new void registraSaida(Funcionario funcionario) {
          this.controleDePontoNovo.registra(funcionario, false);
        }
      }
    }
    ```

5. Agora crie o cliente que utilizará essa adaptação

    ```c#
    class Teste {
      public static void Main(string[] args) {
        ControleDePonto controleDePonto = new ControleDePontoAdapter();
        Funcionario funcionario = new Funcionario("Marcelo Adnet");
        controleDePonto.registraEntrada(funcionario);
        Thread.Sleep(3000);
        controleDePonto.registraSaida(funcionario);
      }
    }
    ```
