using System;
using Proxy;

namespace Proxy {

  public class BancoProxy: BancoDeUsuarios {
    protected string usuario, senha;

    public BancoProxy(string usuario, string senha) {
      this.usuario = usuario;
      this.senha = senha;
    }

    public override string getNumeroDeUsuarios() {
      if (temPermissaoDeAcesso()) {
        return base.getNumeroDeUsuarios();
      }
      return "Você não tem permissão para pegar o número de usuários";
    }

    public override string getUsuariosConectados() {
      if (temPermissaoDeAcesso()) {
        return base.getUsuariosConectados();
      }
      return "Você não tem permissão para pegar a quantidade de usuários conectados";
    }

    private bool temPermissaoDeAcesso() {
      return usuario == "admin" && senha == "admin";
    }
  }

}

public class BancoDeUsuarios {
  private int quantidadeDeUsuarios;
  private int usuariosConectados;

  public BancoDeUsuarios() {
    this.quantidadeDeUsuarios = 55;
    this.usuariosConectados = 30;
  }

  public virtual string getNumeroDeUsuarios() {
    return "Total de usuário: " + quantidadeDeUsuarios;
  }

  public virtual string getUsuariosConectados() {
    return "Usuários conectados: " + usuariosConectados;
  }
}

class Testes {
  public static void Main(string[] args) {
    Console.WriteLine("Hacker acessando: ");
    BancoDeUsuarios banco = new BancoProxy("Hacker", "1234");
    Console.WriteLine(banco.getNumeroDeUsuarios());
    Console.WriteLine(banco.getUsuariosConectados());

    Console.WriteLine("Admin acessando: ");
    banco = new BancoProxy("admin", "admin");
    Console.WriteLine(banco.getNumeroDeUsuarios());
    Console.WriteLine(banco.getUsuariosConectados());
  }
}
