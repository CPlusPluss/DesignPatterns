using System;
using Ordenadores;

namespace Ordenadores {

  public abstract class OrdenadorTemplate {
    public abstract bool isPrimeiro(MusicaMP3 musica1, MusicaMP3 musica2);

    public ArrayList<MusicaMP3> ordenarMusica(ArrayList<MusicaMP3> lista) {
      ArrayList<MusicaMP3> novaLista = new ArrayList<MusicaMP3>();
      for (MusicaMP3 musicaMP3 in lista) {
        novaLista.Add(musicaMP3);
      }
    }
  }

}

public class MusicaMP3 {
  string nome;
  string autor;
  string ano;
  int estrela;

  public MusicaMP3(string nome, string autor, string ano, int estrela) {
    this.nome = nome;
    this.autor = autor;
    this.ano = ano;
    this.estrela = estrela;
  }
}

public enum ModoDeReproducao {
  porNome, porAutor, porAno, porEstrela
}


