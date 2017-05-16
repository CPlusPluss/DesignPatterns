using System;

public interface Prototype<Type> {
  Type clone();
}

public class Campanha: Prototype<Campanha> {
  private string nome;
  private string vencimento;

  public Campanha(string nome, string vencimento) {
    this.nome = nome;
    this.vencimento = vencimento;
  }

  public string getNome() {
    return nome;
  }

  public string getVencimento() {
    return vencimento;
  }

  public Campanha clone() {
    string nome = "Cópia da Campanha: " + this.getNome();
    string vencimento = this.getVencimento();
    Campanha campanha = new Campanha(nome, vencimento);
    return campanha;
  }

  public void print() {
    Console.WriteLine("----------");
    Console.WriteLine("Nome da Campanha: ");
    Console.WriteLine(this.getNome());
    Console.WriteLine("\n");
    Console.WriteLine("Vencimento: " + this.getVencimento());
    Console.WriteLine("\n");
    Console.WriteLine("----------");
    Console.WriteLine("\n");
  }
}

class Testes {
  public static void Main(string[] args) {
    string nome = "K19";
    string vencimento = "21/08/2023";

    Campanha campanha = new Campanha(nome, vencimento);
    campanha.print();

    Campanha clone = campanha.clone();
    clone.print();
  }
}
