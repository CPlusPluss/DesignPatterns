## Mediator

Quando uma situação em que um relacionamento muitos para muitos é necessário, uma boa prática é criar uma tabela intermediária e deixar que ela
relaciona uma entidade com outras várias e vice versa. É semelhante a central telefônica, pois diminui a quantidade de ligações entre objetos
introduzindo um mediador, através da qual toda comunicação entre os objetos será realizada, ou seja, eliminar conexões excessivas entre elementos
por meio da introdução de um intermediário único.

***
#### Diagrama de classe
***

![mediador](https://cloud.githubusercontent.com/assets/14116020/26286102/4225232a-3e33-11e7-99da-7781da90ffa5.png)

* **Mediador (Mediador)**: Interface que padroniza as operações que serão chamadas pelos Colegas.

* **MediadorConcreto (Mensagem)**: Implementação particular do Mediador , que coordena a interação entre os Colegas.

* **Colega (Colega)**: Possível interface para padronizar os colegas concretos.

* **ColegaConcreto (Android, IOS)**: Classes que interagem entre si por meio do Mediador.

***
#### Implementação
***

1. Implemente a interface que irá padronizar os colegas (**Mediador**)

    ```c#
    namespace Mediador {
      public interface Mediador {
        void envia(string mensagem, Colega colega);
      }
    }
    ```

2. Crie as implementações desse mediador (**MediadorConcreto**)

    ```c#
    namespace MediadoresConcretos {
      public class Mensagem: Mediador {
        protected ArrayList contatos;
    
        public Mensagem() {
          contatos = new ArrayList();
        }
    
        public void adicionaColega(Colega colega) {
          contatos.Add(colega);
        }
    
        public void envia(string mensagem, Colega colega) {
          foreach (Colega contato in contatos) {
            if (contato != colega) {
              definirProtocolo(contato);
              contato.recebeMensagem(mensagem);
            }
          }
        }
    
        private void definirProtocolo(Colega contato) {
          if (contato.GetType() == typeof(IOS)) {
            Console.WriteLine("Protocolo IOS");
          } else if (contato.GetType() == typeof(Android)) {
            Console.WriteLine("Protocolo Android");
          }
        }
      }
    }
    ```     

3. Agora crie a interface ou classe abstrata que irá definir os colegas (**Colega**)

    ```c#
    namespace Colega {
      public abstract class Colega {
        protected Mediador mediador;
    
        public Colega(Mediador mediador) {
          this.mediador = mediador;
        }
    
        public void enviaMensagem(string mensagem) {
          mediador.envia(mensagem, this);
        }
    
        public abstract void recebeMensagem(string mensagem);
      }
    }
    ```

4. Crie as implementações dos colegas (**ColegaConcreto**)

    ```c#
    namespace ColegasConcretos {
      public class Android: Colega {
        public Android(Mediador mediador): base(mediador) {}
    
        public override void recebeMensagem(string mensagem) {
          Console.WriteLine("Android recebeu: " + mensagem);
        }
      }
    
      public class IOSColega: Colega {
        public IOS(Mediador mediador): base(mediador) {}
    
        public override void recebeMensagem(string mensagem) {
          Console.WriteLine("IOS recebeu: " + mensagem);
        }
      }
    }
    ```

5. Defina a main que irá fazer essa comunicação

    ```c#
    class Testes {
      public static void Main(string[] args) {
        Mensagem mediador = new Mensagem();
    
        Android android = new Android(mediador);
        IOS ios = new IOS(mediador);
    
        mediador.adicionaColega(android);
        mediador.adicionaColega(ios);
    
        android.enviaMensagem("Oi, eu sou o android");
        ios.enviaMensagem("Olá android, eu sou o IOS");
        ios.enviaMensagem("Como você está?");
        android.enviaMensagem("Estou bem e você?");
        ios.enviaMensagem("Estou ótimo!");
      }
    }
    ```
