using System;
using Builders;
using Boletos;

namespace Boletos {

  public interface Boleto {
    string getSacado();       // Pessoa ou empresa responsável pelo pagamento do boleto
    string getCedente();      // Pessoa ou empres que receberá o pagamento do boleto
    double getValor();
    string getVencimento();
    int getNossoNumero();
    string toString();
  }

  public class BBBoleto: Boleto {
    private string sacado;
    private string cedente;
    private double valor;
    private string vencimento;
    private int nossoNumero;

    public BBBoleto(string sacado, string cedente, double valor, string vencimento, int nossoNumero) {
      this.sacado = sacado;
      this.cedente = cedente;
      this.valor = valor;
      this.vencimento = vencimento;
      this.nossoNumero = nossoNumero;
    }

    public string getSacado() {
      return this.sacado;
    }

    public string getCedente() {
      return this.cedente;
    }

    public double getValor() {
      return this.valor;
    }

    public string getVencimento() {
      return this.vencimento;
    }

    public int getNossoNumero() {
      return this.nossoNumero;
    }

    public string toString() {
      string stringBuilder = "Boleto BB\n" +
                              "Sacado: " + this.getSacado() + "\n" +
                              "Cedente: " + this.getCedente() + "\n" +
                              "Valor: " + this.getValor() + "\n" +
                              "Vencimento: " + this.getVencimento() + "\n" +
                              "Nosso número: " + this.getNossoNumero() + "\n";
      return stringBuilder;
    }
  }

}

namespace Builders {

  public interface BoletoBuilder {
    void buildSacado(string sacado);
    void buildCedente(string cedente);
    void buildValor(double valor);
    void buildVencimento(string vencimento);
    void buildNossoNumero(int nossoNumero);

    Boleto getBoleto();
  }

  public class BBBoletoBuilder: BoletoBuilder {
    private string sacado;
    private string cedente;
    private double valor;
    private string vencimento;
    private int nossoNumero;

    public void buildSacado(string sacado) {
      this.sacado = sacado;
    }

    public void buildCedente(string cedente) {
      this.cedente = cedente;
    }

    public void buildValor(double valor) {
      this.valor = valor;
    }

    public void buildVencimento(string vencimento) {
      this.vencimento = vencimento;
    }

    public void buildNossoNumero(int nossoNumero) {
      this.nossoNumero = nossoNumero;
    }

    public Boleto getBoleto() {
      return new BBBoleto(sacado, cedente, valor, vencimento, nossoNumero);
    }
  }
}

public class GeradorDeBoleto {
  private BoletoBuilder boletoBuilder;

  public GeradorDeBoleto(BoletoBuilder boletoBuilder) {
    this.boletoBuilder = boletoBuilder;
  }

  public Boleto geraBoleto() {
    this.boletoBuilder.buildSacado("Marcelo Martins");
    this.boletoBuilder.buildCedente("K19 Treinamentos");
    this.boletoBuilder.buildValor(100.53);
    this.boletoBuilder.buildVencimento("21/03/2010");
    this.boletoBuilder.buildNossoNumero(123685432);

    Boleto boleto = boletoBuilder.getBoleto();

    return boleto;
  }
}

class Teste {
  public static void Main(string[] args) {
    BoletoBuilder boletoBuilder = new BBBoletoBuilder();
    GeradorDeBoleto gerador = new GeradorDeBoleto(boletoBuilder);
    Boleto boleto = gerador.geraBoleto();
    Console.WriteLine(boleto.toString());
  }
}
