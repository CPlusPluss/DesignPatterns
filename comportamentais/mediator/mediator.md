## Mediator
***
#### Definição
***

Quando uma situação em que um relacionamento muitos para muitos é necessário, uma boa prática é criar uma tabela intermediária e deixar que ela
relaciona uma entidade com outras várias e vice versa. É semelhante a central telefônica, pois diminui a quantidade de ligações entre objetos
introduzindo um mediador, através da qual toda comunicação entre os objetos será realizada, ou seja, eliminar conexões excessivas entre elementos
por meio da introdução de um intermediário único.

***
#### Diagrama de classe
***

![mediador](https://cloud.githubusercontent.com/assets/14116020/26086490/54b7a060-39c1-11e7-86d9-3007d2cc3565.png)

* **Mediator (Mediator)**: Interface que padroniza as operações que serão chamadas pelos Colleagues.

* **ConcreateMediator (MensagemMediator)**: Implementação particular do Mediator , que coordena a interação entre os Colleagues.

* **Colleague (Colleague)**: Possível interface para padronizar os ConcreateColleagues.

* **ConcreateColleague (AndroidColleague, IOSColleague)**: Classes que interagem entre si por meio do Mediator.

***
#### Implementação
***

1. Implemente a interface que irá padronizar os colleagues (**Mediator**)

    ```c#
    namespace Mediator {
      public interface Mediator {
        void envia(string mensagem, Colleague colleague);
      }
    }
    ```

2. Crie as implementações desse mediator (**ConcreteMediator**)

    ```c#
    namespace ConcreteMediator {
      public class MensagemMediator: Mediator {
        protected ArrayList contatos;
    
        public MensagemMediator() {
          contatos = new ArrayList();
        }
    
        public void adicionaColleague(Colleague colleague) {
          contatos.Add(colleague);
        }
    
        public void envia(string mensagem, Colleague colleague) {
          foreach (Colleague contato in contatos) {
            if (contato != colleague) {
              definirProtocolo(contato);
              contato.recebeMensagem(mensagem);
            }
          }
        }
    
        private void definirProtocolo(Colleague contato) {
          if (contato.GetType() == typeof(IOSColleague)) {
            Console.WriteLine("Protocolo IOS");
          } else if (contato.GetType() == typeof(AndroidColleague)) {
            Console.WriteLine("Protocolo Android");
          }
        }
      }
    }
    ```     

3. Agora crie a interface ou classe abstrata que irá definir os colleagues (**Colleague**)

    ```c#
    namespace Colleague {
      public abstract class Colleague {
        protected Mediator mediator;
    
        public Colleague(Mediator mediator) {
          this.mediator = mediator;
        }
    
        public void enviaMensagem(string mensagem) {
          mediator.envia(mensagem, this);
        }
    
        public abstract void recebeMensagem(string mensagem);
      }
    }
    ```

4. Crie as implementações dos colleagues (**ConcreteColleague**)

    ```c#
    namespace ConcreteColleague {
      public class AndroidColleague: Colleague {
        public AndroidColleague(Mediator mediator): base(mediator) {}
    
        public override void recebeMensagem(string mensagem) {
          Console.WriteLine("Android recebeu: " + mensagem);
        }
      }
    
      public class IOSColleague: Colleague {
        public IOSColleague(Mediator mediator): base(mediator) {}
    
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
        MensagemMediator mediator = new MensagemMediator();
    
        AndroidColleague android = new AndroidColleague(mediator);
        IOSColleague ios = new IOSColleague(mediator);
    
        mediator.adicionaColleague(android);
        mediator.adicionaColleague(ios);
    
        android.enviaMensagem("Oi, eu sou o android");
        ios.enviaMensagem("Olá android, eu sou o IOS");
        ios.enviaMensagem("Como você está?");
        android.enviaMensagem("Estou bem e você?");
        ios.enviaMensagem("Estou ótimo!");
      }
    }
    ```
