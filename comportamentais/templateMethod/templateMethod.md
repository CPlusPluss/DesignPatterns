## Template Method

Quanto temos diferentes algoritmos que possuem estruturas parecidas, ele tem uma estrutura parecida com às linhas de montagem de carro, pois
permite definir a ordem de execução dos passos que resolvem um determinado problema e permite que cada passo possa ser implementado de maneiras
diferentes.

***
#### Diagrama de classe
***

![templatemethod](https://cloud.githubusercontent.com/assets/14116020/26278735/217bbfa0-3d78-11e7-8b22-1faca240716a.png)

* **ClasseAbstrata**: Classe abstrata que define os templates methods baseados em métodos abstratos que serão implementados nas classes concretas,
  define a ordem de execução desse métodos.

* **ClasseConcreta**: Classes concretas que implementam os métodos abstratos definidos pela classe abstrata e que são utilizados pelos templates methods.

***
#### Implementação
***

1. Crie a classe abstrata com a definição dos métodos que irão ser ordenados no método **template()** (**ClasseAbstrata**)

    ```c#
    namespace ClasseAbstrata {
      public abstract class ProcessoSeletivo {
        public abstract void provaTeorica();
        public abstract void resistenciaFisica();
        public abstract void provaPratica();
        public abstract void testePsicologico();
        public abstract void exameMedico();
    
        public void templateMethod() {
          provaTeorica();
          provaPratica();
          testePsicologico();
          exameMedico();
          resistenciaFisica();
        }
      }
    }
    ```

2. Crie as classes concretas que irão implementar esse métodos ordenados no template(), (**ClasseConcreta**)

    ```c#
    namespace ClasseConcreta {
      public class ConcursoMarinha: ProcessoSeletivo {
        public override void provaTeorica() {
          Console.WriteLine("Prova teorica da marinha concluida!");
        }
    
        public override void resistenciaFisica() {
          Console.WriteLine("Resistencia fisica da marinha concluida!");
        }
    
        public override void provaPratica() {
          Console.WriteLine("Prova prática da marinha concluida!");
        }
    
        public override void testePsicologico() {
          Console.WriteLine("Teste psicologico da marinha concluida!");
        }
    
        public override void exameMedico() {
          Console.WriteLine("Exame médico da marinha concluida!");
        }
      }
    
      public class ConcursoAeronautica: ProcessoSeletivo {
        public override void provaTeorica() {
          Console.WriteLine("Prova teorica da aeronautica concluida!");
        }
    
        public override void resistenciaFisica() {
          Console.WriteLine("Resistencia fisica da aeronautica concluida!");
        }
    
        public override void provaPratica() {
          Console.WriteLine("Prova prática da aeronautica concluida!");
        }
    
        public override void testePsicologico() {
          Console.WriteLine("Teste psicologico da aeronautica concluida!");
        }
    
        public override void exameMedico() {
          Console.WriteLine("Exame médico da aeronautica concluida!");
        }
      }
    }
    ```

3. Agora só implementar a cliente

    ```c#
    class Testes {
      public static void Main(string[] args) {
        ProcessoSeletivo processo = new ConcursoMarinha();
        processo.template();
    
        processo = new ConcursoAeronautica();
        processo.template();
      }
    }
    ```
