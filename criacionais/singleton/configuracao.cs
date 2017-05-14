using System;
using System.Collections;
using Singleton;

namespace Singleton {
  public class Configuracao {
    private Hashtable propriedades = new Hashtable();
    private static Configuracao instance;

    private Configuracao() {
      this.propriedades.Add("time-zone", "America/Sao_Paulo");
      this.propriedades.Add("currency-code", "BRL");
      this.propriedades.Add("language", "pt-br");
    }

    public static Configuracao getInstance() {
      if(instance == null) {
        instance = new Configuracao();
      }
      return instance;
    }

    public Object getPropriedade(string nomeDaPropriedade) {
      return this.propriedades[nomeDaPropriedade];
    }
  }
}

class Teste {
  public static void Main(string[] args) {
    Configuracao configuracao = Configuracao.getInstance();
    Console.WriteLine(configuracao.getPropriedade("time-zone"));
    Console.WriteLine(configuracao.getPropriedade("currency-code"));
    Console.WriteLine(configuracao.getPropriedade("language"));
  }
}
