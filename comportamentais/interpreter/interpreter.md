## Interpreter

Reconhecer padrões é um problema bem complicado, no entanto, quando conseguimos formular uma gramática para o problema a solução fica bem mais
fácil.

Uma vez definida a grámatica e suas regras, é possível utilizar o padrão Interpreter para montar uma estrtura para interpretar os comandos.

Dada uma linguagem, definir uma representação para sua gramática juntamente com um interpretador que usa a representação para interpretar
sentenças dessa linguagem.

***
#### Diagrama de classe
***

![interpreter](https://cloud.githubusercontent.com/assets/14116020/26278888/67dc33e6-3d7b-11e7-9fa2-0f0a9e5bd441.png)

***
#### Implementação
***

1. Crie o contexto (**Contexto**)

    ```c#
    namespace Contexto {
      public class Contexto {
        protected string input;
        protected int output;
      
        public Contexto(String input) {
          this.input = input;
        }
      
        public String getInput() {
          return input;
        }
      
        public void setInput(String input) {
          this.input = input;
        }
      
        public int getOutput() {
          return output;
        }
      
        public void setOutput(int output) {
          this.output = output;
        }
      }
    }
    ```

2. Crie a classe abstrata que terá a lógica da gramática (**InterpretadorAbstrato**)

    ```c#
    namespace InterpretadorAbstrato {
      public abstract class InterpretadorDeNumerosRomanos {
        public void interpretar(Contexto contexto) {
          if (contexto.getInput().Length == 0) {
            return;
          }
    
          // Os valores nove e quatro são os únicos que possuem duas casas, ex: IV, IX
          if (contexto.getInput().StartsWith(nove())) {
            adicionarValorOutput(contexto, 9);
            consumirDuasCasasDoInput(contexto);
          } else if (contexto.getInput().StartsWith(quatro())) {
            adicionarValorOutput(contexto, 4);
            consumirDuasCasasDoInput(contexto);
          } else if (contexto.getInput().StartsWith(cinco())) {
            adicionarValorOutput(contexto, 5);
            consumirUmaCasaInput(contexto);
          }
    
          // Os valores de um são os únicos que repetem, ex: III, CCC, MMM
          while (contexto.getInput().StartsWith(um())) {
            adicionarValorOutput(contexto, 1);
            consumirUmaCasaInput(contexto);
          }
        }
    
        private void consumirUmaCasaInput(Contexto contexto) {
          contexto.setInput(contexto.getInput().Substring(1));
        }
    
        private void consumirDuasCasasDoInput(Contexto contexto) {
          contexto.setInput(contexto.getInput().Substring(2));
        }
    
        private void adicionarValorOutput(Contexto contexto, int numero) {
          contexto.setOutput(contexto.getOutput() + (numero * multiplicador()));
        }
    
        public abstract String um();
        public abstract String quatro();
        public abstract String cinco();
        public abstract String nove();
        public abstract int multiplicador();
      }
    }
    ```

3. Crie a implementação dos métodos dessa classe abstrata (**InterpretadorConcreto**)

    ```c#
    namespace InterpretadorConcreto {
      public class UmDigitoRomano: InterpretadorDeNumerosRomanos {
        public override string um() {
          return "I";
        }
    
        public override string quatro() {
          return "IV";
        }
    
        public override string cinco() {
          return "V";
        }
    
        public override string nove() {
          return "IX";
        }
    
        public override int multiplicador() {
          return 1;
        }
      }
    
      public class DoisDigitosRomano: InterpretadorDeNumerosRomanos {
        public override string um() {
          return "X";
        }
    
        public override string quatro() {
          return "XL";
        }
    
        public override string cinco() {
          return "L";
        }
    
        public override string nove() {
          return "XC";
        }
    
        public override int multiplicador() {
          return 10;
        }
      }
    
      public class TresDigitosRomano: InterpretadorDeNumerosRomanos {
        public override string um() {
          return "C";
        }
    
        public override string quatro() {
          return "CD";
        }
    
        public override string cinco() {
          return "D";
        }
    
        public override string nove() {
          return "CM";
        }
    
        public override int multiplicador() {
          return 100;
        }
      }
    
      public class QuatroDigitosRomano: InterpretadorDeNumerosRomanos {
        public override string um() {
          return "M";
        }
    
        public override string quatro() {
          return " ";
        }
    
        public override string cinco() {
          return " ";
        }
    
        public override string nove() {
          return " ";
        }
    
        public override int multiplicador() {
          return 1000;
        }
      }
    }
    ```

4. Crie a main

    ```c#
    class Testes {
      public static void Main(string[] args) {
        ArrayList interpretadores = new ArrayList();
        interpretadores.Add(new QuatroDigitosRomano());
        interpretadores.Add(new TresDigitosRomano());
        interpretadores.Add(new DoisDigitosRomano());
        interpretadores.Add(new UmDigitoRomano());
    
        string numeroRomano = "cxciv";
        Contexto contexto = new Contexto(numeroRomano);
    
        foreach (InterpretadorDeNumerosRomanos interpreter in interpretadores) {
          interpreter.interpretar(contexto);
        }
    
        Console.WriteLine(numeroRomano + " = " + contexto.getOutput().ToString());
      }
    }
    ```
