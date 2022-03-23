using System;
using System.IO;
using System.Text;
using System.Xml.Serialization;
using System.Linq;

public class Npacote{
    private Npacote(){}
    static Npacote obj = new Npacote();
    public static Npacote Singleton {get => obj;}
    private List<Pacote> pacotes = new List<Pacote>();


    public List<Pacote> Listar(){
        pacotes.Sort();
        return pacotes;
    }

    public Pacote Listar(int id){
        for (int i = 0; i < pacotes.Count(); i++)
        if (pacotes[i].Id == id) return pacotes[i];
        return null;
    
    }

    public List<Aluno> ListarAdesoes(Pacote p){
        List<Aluno> ads = new List<Aluno>();
        ads = p.ListarAdesoes();
        return ads;
    }
    public void Inserir(Pacote p){
        int max = 0;
        foreach (Pacote obj in pacotes)
            if(obj.Id > max) max = obj.Id;
        p.Id = max + 1;
        pacotes.Add(p);
    }

    public void Excluir(Pacote p) {
        if (p != null) pacotes.Remove(p);

        List<Aluno> x = p.ListarAdesoes();
        foreach(Aluno a in x) a.Pacote = null; 
  }

    public void Atualizar(Pacote p) {
        Pacote p_atual = Listar(p.Id);
        if (p_atual == null) return;
        p_atual.Descricao = p.Descricao;
        p_atual.QtdAulas = p.QtdAulas;
        p_atual.ValorPacote = p.ValorPacote;
        
  }

  public List<Pacote> PadraoDeLista(){
        List<Pacote> aux = new List<Pacote>();
        foreach(Pacote p in pacotes){
            Pacote pac = new Pacote{Id = p.Id, Descricao = p.Descricao, QtdAulas = p.QtdAulas, ValorPacote = p.ValorPacote};
            aux.Add(pac);
        }
        return aux;
    }


  public void SerializarPacotes(){
        Arquivo<List<Pacote>> arq = new Arquivo<List<Pacote>>();
        arq.Salvar("./ListaNpacotes.xml", PadraoDeLista());
    }

  
  public void DesSerializarPacotes(){
        Arquivo<List<Pacote>> arq = new Arquivo<List<Pacote>>();
        pacotes = arq.Abrir("./ListaNpacotes.xml");
        
        Console.WriteLine("Dados recuperados de: ListaNpacote.xml");
     } 

}
