## Object Pool

Possibilita o reaproveitamento de objetos

Uma situação típica em que recursos limitados devem ser reutilizados é o do restaurante. O restaurante não adquire novas mesas a medida que clientes chegam ao restaurante e as mesas são reutilizadas por novos clientes assim que são liberadas.

***
#### Diagrama de classe
***

![objectpool](https://cloud.githubusercontent.com/assets/14116020/26185127/626ca292-3b5f-11e7-9e97-7a2797cb89e9.png)

* **Produto (Mesa)**: Define os objetos gerenciados pelos CompartilhamentosConcretos.

* **CompartilhamentoAbstrato (Compartilhamento)**: Interface dos objetos que controlam a aquisição e a liberação dos Produtos.

* **CompartilhamentoConcreto (MesaCompartilhada)**: Implementação particular de um CompartilhamentoAbstrato que gerencia um Produto específico.

***
#### Implementação
***

1. Defina a classe de mesas que terá suas informações:

    ```c#
    namespace Produtos {
      public class Mesa {
        private int numero;
      
        public Mesa(int numero) {
          this.numero = numero;
        }
      
        public int getNumero() {
          return this.numero;
        }
      }
    }
    ```

2. Defina a inteface que irá controlar as mesas (**CompartilhamentoAbstrato**)

    ```c#
    namespace CompartilhamentoAbstrato {
      public interface Compartilhamento<Type> {
        Type adquire(int numero);
        void libera(int numero);
      }
    }
    ```

3. Defina a classe de mesaCompartilhadas (**CompartilhamentoConcreto**) que irá controlar a entrega ou liberação das mesas definidas em sua interface (**CompartilhamentoAbstrato**)

    ```c#
    namespace CompartilhamentosConcretos {
      public class MesaCompartilhada: Compartilhamento<Mesa> {
        private List<Mesa> mesasDisponiveis;
        private List<Mesa> mesasOcupadas;
    
        public MesaCompartilhada() {
          this.mesasDisponiveis = new List<Mesa>();
          this.mesasOcupadas = new List<Mesa>();
          this.mesasDisponiveis.Add(new Mesa(1));
          this.mesasDisponiveis.Add(new Mesa(7));
          this.mesasDisponiveis.Add(new Mesa(2));
          this.mesasDisponiveis.Add(new Mesa(5));
          this.mesasDisponiveis.Add(new Mesa(10));
          this.mesasOcupadas.Add(new Mesa(3));
          this.mesasOcupadas.Add(new Mesa(4));
          this.mesasOcupadas.Add(new Mesa(6));
          this.mesasOcupadas.Add(new Mesa(8));
          this.mesasOcupadas.Add(new Mesa(9));
        }
    
        public Mesa adquire(int numero) {
          foreach (Mesa mesa in this.mesasDisponiveis) {
            if (mesa.getNumero() == numero) {
              Console.WriteLine("Mesa adquirida: " + mesa.getNumero());
              this.mesasOcupadas.Add(mesa);
              this.mesasDisponiveis.Remove(mesa);
              return mesa;
            }
          }
          Console.WriteLine("A mesa número {0} está ocupada", numero);
          return null;
        }
    
        public void libera(int numero) {
          foreach (Mesa mesa in this.mesasOcupadas) {
            if (mesa.getNumero() == numero) {
              Console.WriteLine("Mesa liberada: " + mesa.getNumero());
              this.mesasDisponiveis.Add(mesa);
              this.mesasOcupadas.Remove(mesa);
              return;
            }
          }
          Console.WriteLine("A mesa número {0} já está disponivel", numero);
        }
      }
    }
    ```

4. Crie a classe para testar o controle de mesa do restaurante

    ```c#
    class Testes {
      public static void Main(string[] args) {
        Compartilhamento<Mesa> mesaCompartilhada = new MesaCompartilhada();
        Mesa mesa = mesaCompartilhada.adquire(7);
        mesa = mesaComartilhada.adquire(3);
        mesaCompartilhada.libera(7);
        mesaCompartilhada.libera(7);
      }
    }
    ```
