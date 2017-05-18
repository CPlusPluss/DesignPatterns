## Adapter

Permite que um objeto seja substituido por outro que, apesar de realizar a mesma tarefa, possui uma interface diferente.

***
#### Diagrama de classe
***

![adapter](https://cloud.githubusercontent.com/assets/14116020/26186346/6add8b32-3b67-11e7-89a2-3305dc140d5b.png)

* **SistemaAntigo (ControleDePonto)**: Define a interface utilizada pelo cliente

* **Adaptador (ControleDePontoAdapter)**: Classe que implementa a interface definida pelo SistemaAntigo e adapta as chamadas do Client para o NovoSistema.

* **NovoSistema (ControleDePontoNovo)**: Classe que define o novo objeto a ser utilizado.

* **Cliente**: Interage com os objetos através da interface definida pelo SistemaAntigo.

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

2. Defina qual o ponto de controle antigo ou o (**SistemaAntigo**) a qual precisa ser adaptado para o novo

    ```c#
    namespace SistemaAntigo {  
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

3. Defina qual a novo ponto de controle ou (**NovoSistema**) que será usado no lugar do velho definido anteriormente.

    ```c#
    namespace NovoSistema {
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

4. Agora só criar o adaptador (**Adaptador**) que será utilizado para substituir o velho pelo novo sem mudar sua estrutura.

    ```c#
    namespace Adaptador {
      public class ControleDePontoAdaptador: ControleDePonto {
        private ControleDePontoNovo controleDePontoNovo;
    
        public ControleDePontoAdaptador() {
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
        ControleDePonto controleDePonto = new ControleDePontoAdaptador();
        Funcionario funcionario = new Funcionario("Marcelo Adnet");
        controleDePonto.registraEntrada(funcionario);
        Thread.Sleep(3000);
        controleDePonto.registraSaida(funcionario);
      }
    }
    ```
