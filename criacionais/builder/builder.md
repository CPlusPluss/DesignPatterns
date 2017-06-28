## Builder

Separar o processo de construção de um objeto de sua representação e permitir a sua criação passo-a-passo. Diferentes tipos de objetos podem ser
criados com implementações distintas de cada passo.

***
#### Diagrama de classe
***

![builder](https://cloud.githubusercontent.com/assets/14116020/26229940/a14f7608-3c1b-11e7-8afd-b78d8b1f63fb.png)

* **ProdutoAbstrato (Carro)**: Interface que define os objetos que devem ser construídos pelos Construtores.

* **ProdutoConcreto (...)**: Implementação da interface que define os objetos que devem ser contruídos pelos Construtores.

* **ConstrutorAbstrato (FabricaDeCarro)**: Interface que define os passos para a criação de um produto.

* **ConstrutorConcreto (FabricaFiat, FabricaVolks)**: Constrói um produto específico implementando a interface ConstrutoAbstrato.

* **Diretor (Concessionaria)**: Aciona os método do construtorAbstrato para construir um produto, constroi passo a passo em apenas um método.

* **Cliente**: Utiliza do Diretor para construir o produto.

***
#### Implementação
***

1. Crie o produto (**ProdutoAbstrato**) e suas implementações se tiver.

    ```c#
    namespace Produtos {
      public class Carro {
        private double preco;
        private string motor;
        private int anoDeFabricacao;
        private string modelo;
        private string montadora;
      
        public void setPreco(double preco) {
          this.preco = preco;
        }
      
        public double getPreco() {
          return preco;
        }
      
        public void setMotor(string motor) {
          this.motor = motor;
        }
      
        public string getMotor() {
          return motor;
        }
      
        public void setAnoDeFabricacao(int anoDeFabricacao) {
          this.anoDeFabricacao = anoDeFabricacao;
        }
      
        public int getAnoDeFabricacao() {
          return anoDeFabricacao;
        }
      
        public void setModelo(string modelo) {
          this.modelo = modelo;
        }
      
        public string getModelo() {
          return modelo;
        }
      
        public void setMontadora(string montadora) {
          this.montadora = montadora;
        }
      
        public string getMontadora() {
          return montadora;
        }
      }
    }
    ```

2. Cria a interface que irá definir os passos para criar o produto (**ConstrutorAbstrato**)

    ```c#
    namespace ConstrutorAbstrato {
      public abstract class FabricaDeCarro {
        protected Carro carro;
    
        public FabricaDeCarro() {
          carro = new Carro();
        }
    
        public abstract void criaPreco();
        public abstract void criaMotor();
        public abstract void criaAnoDeFabricacao();
        public abstract void criaModelo();
        public abstract void criaMontadora();
    
        public Carro getCarro() {
          return carro;
        }
      }
    }
    ```

3. Crie as fabricas que irão construir o produto utilizando como base a interface ConstrutorAbstrato (**ConstrutorConcreto**)

    ```c#
    namespace ConstrutoresConcretos {
      public class FabricaFiat: FabricaDeCarro {
        public override void criaPreco() {
          carro.setPreco(25000.00);
        }
    
        public override void criaMotor() {
          carro.setMotor("Fire Flex 1.0");
        }
    
        public override void criaAnoDeFabricacao() {
          carro.setAnoDeFabricacao(2011);
        }
    
        public override void criaModelo() {
          carro.setModelo("Palio");
        }
    
        public override void criaMontadora() {
          carro.setMontadora("Fiat");
        }
      }
    
      public class FabricaVolks: FabricaDeCarro {
        public override void criaPreco() {
          carro.setPreco(45000.00);
        }
    
        public override void criaMotor() {
          carro.setMotor("Fire Flex 2.0");
        }
    
        public override void criaAnoDeFabricacao() {
          carro.setAnoDeFabricacao(2008);
        }
    
        public override void criaModelo() {
          carro.setModelo("CrossFox");
        }
    
        public override void criaMontadora() {
          carro.setMontadora("Volkswagen");
        }
      }
    }
    ```

4. Agora crie a classe que irá construir o objeto passo a passo utilizando as fabricas como base (**Diretor**)

    ```c#
    namespace Diretor {
      public class Concessionaria {
        protected FabricaDeCarro montadora;
      
        public Concessionaria(FabricaDeCarro montadora) {
          this.montadora = montadora;
        }
      
        public void construirCarro() {
          montadora.criaPreco();
          montadora.criaAnoDeFabricacao();
          montadora.criaMotor();
          montadora.criaModelo();
          montadora.criaMontadora();
        }
      
        public Carro getCarro() {
          return montadora.getCarro();
        }
      }
    }
    ```

5. Crie o cliente que irá usar o Diretor para criar seus objetos

    ```c#
    class Teste {
      public static void Main(string[] args) {
        Concessionaria concessionaria = new Concessionaria(new FabricaFiat());
        concessionaria.construirCarro();
        Carro carro = concessionaria.getCarro();
        Console.WriteLine("Carro: " + carro.getModelo() + "/" + carro.getMontadora());
        Console.WriteLine("Ano: " + carro.getAnoDeFabricacao());
        Console.WriteLine("Motor: " + carro.getMotor());
        Console.WriteLine("Valor: " + carro.getPreco());
    
        concessionaria = new Concessionaria(new FabricaVolks());
        concessionaria.construirCarro();
        carro = concessionaria.getCarro();
        Console.WriteLine("Carro: " + carro.getModelo() + "/" + carro.getMontadora());
        Console.WriteLine("Ano: " + carro.getAnoDeFabricacao());
        Console.WriteLine("Motor: " + carro.getMotor());
        Console.WriteLine("Valor: " + carro.getPreco());
      }
    }
    ```
