## Builder

Separar o processo de construção de um objeto de sua representação e permitir a sua criação passo-a-passo. Diferentes tipos de objetos podem ser
criados com implementações distintas de cada passo.

***
#### Diagrama de classe
***

![builder](https://cloud.githubusercontent.com/assets/14116020/26184556/20f84e22-3b5c-11e7-946a-5211bfaeef48.png)

* **ProdutoAbstrato (CarroModel)**: Interface que define os objetos que devem ser construídos pelos Builders.

* **ProdutoConcreto (...)**: Implementação da interface que define os objetos que devem ser contruídos pelos builders.

* **ConstrutorAbstrato (CarroBuilder)**: Interface que define os passos para a criação de um produto.

* **ConstrutorConcreto (FiatBuilder, VolksBuilder)**: Constrói um produto específico implementando a interface Builder.

* **Diretor (ConcessionariaDirector)**: Aciona os método de um Builder para construir um produto, constroi passo a passo em apenas um método.

* **Cliente**: Utiliza do Director para construir o produto.

***
#### Implementação
***

1. Crie o produto (**ProdutoAbstrato**) e suas implementações se tiver.

    ```c#
    namespace Product {
      public class CarroModel {
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
    namespace Builder {
      public abstract class CarroBuilder {
        protected CarroModel carro;
    
        public CarroBuilder() {
          carro = new CarroModel();
        }
    
        public abstract void buildPreco();
        public abstract void buildMotor();
        public abstract void buildAnoDeFabricacao();
        public abstract void buildModelo();
        public abstract void buildMontadora();
    
        public CarroModel getCarro() {
          return carro;
        }
      }
    }
    ```

3. Crie as fabricas que irão construir o produto utilizando como base a interface Builder (**ConstrutorConcreto**)

    ```c#
    namespace ConcreteBuilder {
      public class FiatBuilder: CarroBuilder {
        public override void buildPreco() {
          carro.setPreco(25000.00);
        }
    
        public override void buildMotor() {
          carro.setMotor("Fire Flex 1.0");
        }
    
        public override void buildAnoDeFabricacao() {
          carro.setAnoDeFabricacao(2011);
        }
    
        public override void buildModelo() {
          carro.setModelo("Palio");
        }
    
        public override void buildMontadora() {
          carro.setMontadora("Fiat");
        }
      }
    
      public class VolksBuilder: CarroBuilder {
        public override void buildPreco() {
          carro.setPreco(45000.00);
        }
    
        public override void buildMotor() {
          carro.setMotor("Fire Flex 2.0");
        }
    
        public override void buildAnoDeFabricacao() {
          carro.setAnoDeFabricacao(2008);
        }
    
        public override void buildModelo() {
          carro.setModelo("CrossFox");
        }
    
        public override void buildMontadora() {
          carro.setMontadora("Volkswagen");
        }
      }
    }
    ```

4. Agora crie a classe que irá construir o objeto passo a passo utilizando as fabricas como base (**Diretor**)

    ```c#
    namespace Director {
      public class ConcessionariaDirector {
        protected CarroBuilder montadora;
      
        public ConcessionariaDirector(CarroBuilder montadora) {
          this.montadora = montadora;
        }
      
        public void construirCarro() {
          montadora.buildPreco();
          montadora.buildAnoDeFabricacao();
          montadora.buildMotor();
          montadora.buildModelo();
          montadora.buildMontadora();
        }
      
        public CarroModel getCarro() {
          return montadora.getCarro();
        }
      }
    }
    ```

5. Crie o cliente que irá usar o Director para criar seus objetos

    ```c#
    class Teste {
      public static void Main(string[] args) {
        ConcessionariaDirector concessionaria = new ConcessionariaDirector(new FiatBuilder());
        concessionaria.construirCarro();
        CarroModel carro = concessionaria.getCarro();
        Console.WriteLine("Carro: " + carro.getModelo() + "/" + carro.getMontadora());
        Console.WriteLine("Ano: " + carro.getAnoDeFabricacao());
        Console.WriteLine("Motor: " + carro.getMotor());
        Console.WriteLine("Valor: " + carro.getPreco());
    
        concessionaria = new ConcessionariaDirector(new VolksBuilder());
        concessionaria.construirCarro();
        carro = concessionaria.getCarro();
        Console.WriteLine("Carro: " + carro.getModelo() + "/" + carro.getMontadora());
        Console.WriteLine("Ano: " + carro.getAnoDeFabricacao());
        Console.WriteLine("Motor: " + carro.getMotor());
        Console.WriteLine("Valor: " + carro.getPreco());
      }
    }
    ```
