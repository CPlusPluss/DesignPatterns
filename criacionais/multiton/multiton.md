## Multiton

Permitir a criação de uma quantidade limitada de instâncias de determinada classe e fornecer um modo para recuperá-las.

***
#### Diagrama de classe
***

![multiton](https://cloud.githubusercontent.com/assets/14116020/26185622/819ae662-3b62-11e7-94e3-3289b37ae885.png)

* **Multiton**: Classe que permite a criação de uma quantidade limitada de instâncias e fornece um método estático para recuperá-las.

***
#### Implementação
***

1. Crie a classe Tema e pré defina os temas “Fire” e “Sky” utilizando o padrão (**Multiton**), no getInstance verifique se já existe a chave
   passada e retorne o tema, caso não exita construa os temas e retorne.

    ```c#
    namespace Multiton {
      public class Tema {
        private string nome;
        private string corDoFundo;
        private string corDaFonte;
        public const string SKY = "Sky";
        public const string FIRE = "Fire";
        private static Dictionary<string, Tema> temas = new Dictionary<string, Tema>();
    
        private Tema() {}
    
        private static void constroiTemas() {
          Tema tema1 = new Tema();
          tema1.setNome(Tema.SKY);
          tema1.setCorDeFundo("Blue");
          tema1.setCorDaFonte("Black");
    
          Tema tema2 = new Tema();
          tema2.setNome(Tema.FIRE);
          tema2.setCorDeFundo("Red");
          tema2.setCorDaFonte("White");
    
          temas.Add(tema1.getNome(), tema1);
          temas.Add(tema2.getNome(), tema2);
        }
    
        public static Tema getInstancia(string nomeDoTema) {
          if (Tema.temas.ContainsKey(nomeDoTema)) {
            return Tema.temas[nomeDoTema];
          } else {
            constroiTemas();
            return Tema.temas[nomeDoTema];
          }
        }
    
        public string getNome() {
          return nome;
        }
    
        public void setNome(string nome) {
          this.nome = nome;
        }
    
        public string getCorDeFundo() {
          return corDoFundo;
        }
    
        public void setCorDeFundo(string corDoFundo) {
          this.corDoFundo = corDoFundo;
        }
    
        public string getCorDaFonte() {
          return corDaFonte;
        }
    
        public void setCorDaFonte(string corDaFonte) {
          this.corDaFonte = corDaFonte;
        }
      }
    }
    ```

2. Teste a classe Tema

    ```c#
    class Testes {
      public static void Main(string[] args) {
        Tema temaFire = Tema.getInstancia(Tema.FIRE);
        Console.WriteLine("Tema: " + temaFire.getNome());
        Console.WriteLine("Cor da fonte: " + temaFire.getCorDaFonte());
        Console.WriteLine("Cor de fundo: " + temaFire.getCorDeFundo());
    
        Tema temaFire2 = Tema.getInstancia(Tema.FIRE);
        Console.WriteLine("------------");
        Console.WriteLine("Comparando as referências");
        Console.WriteLine(temaFire == temaFire2);
      }
    }
    ```
