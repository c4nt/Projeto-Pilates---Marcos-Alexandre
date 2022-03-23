using System;
using System.IO;
using System.Text;
using System.Xml.Serialization;
using System.Linq;


class Naluno {
  private Naluno(){}
  static Naluno obj = new Naluno();
  public static Naluno Singleton {get => obj;}
  public List<Aluno> alunos = new List<Aluno>();
  private int na;

  public List<Aluno> Listar() {
    alunos.Sort();
    return alunos;
  }

  public Aluno Listar(int id) {
    return alunos.FirstOrDefault(obj => obj.Id == id);
  }

  public void Inserir(Aluno a) {
    int max = 0;    
    max = alunos.Max(obj => obj.Id);
    a.Id = max + 1;
    alunos.Add(a);
    Turma c = a.Turma;
    if (c != null) c.AlunoInserir(a);
    Pacote p = a.Pacote;
    if (p != null) p.AdcAlu(a);
  } 

  public void Atualizar(Aluno a) {
    Aluno a_atual = Listar(a.Id);
    if (a_atual == null) return;
    a_atual.Nome = a.Nome;
    a_atual.Idade = a.Idade;
    
    if (a_atual.Turma != null) 
      a_atual.Turma.ExcluirAluno(a_atual);
    a_atual.Turma = a.Turma;
    if (a_atual.Turma != null)
      a_atual.Turma.AlunoInserir(a_atual);
      
    if (a_atual.Pacote != null) 
      a_atual.Pacote.ExcAlu(a_atual);
    a_atual.Pacote = a.Pacote;
   if (a_atual.Pacote != null)
      a_atual.Pacote.AdcAlu(a_atual);
      
  }

  

  public void Excluir(Aluno a) {
    if (a != null) alunos.Remove(a);
    Turma t = a.Turma;
    if (t != null) t.ExcluirAluno(a); 
    Pacote p = a.Pacote;
    if(p != null) p.ExcAlu(a); 
  }

  public void AtualizarListaPessoa(){
    for(int i = 0; i < alunos.Count(); i++){
        Aluno a = alunos[i];
        Pacote pac = Npacote.Singleton.Listar(a.IdPacote);
            if(pac != null){
              a.Pacote = pac;
              pac.AdcAlu(a);}
        }
      
    }

    public void AtualizarListaPessoa2(List<Aluno> alist){
      foreach(Aluno a in alist){
        Pacote pac = Npacote.Singleton.Listar(a.IdPacote);
        Turma tur = Nturma.Singleton.Listar(a.IdTurma);
        a.Pacote = pac;
        pac.AdcAlu(a);
        a.Turma = tur;
        tur.AlunoInserir(a);
        alunos.Add(a);
      }
      
    }

  public List<Aluno> PadraoDeLista(){
    List<Aluno> aux = new List<Aluno>();
    foreach(Aluno a in alunos) {
      Aluno aln = new Aluno{Id = a.Id, Nome = a.Nome, Idade = a.Idade, IdTurma = a.Turma.Id, IdPacote = a.Pacote.Id};
      aux.Add(aln);
    };
    return aux;
  }
  
   public void SerializarAlunos(){
      Arquivo<List<Aluno>> arq = new Arquivo<List<Aluno>>();
      arq.Salvar("./ListaNaluno.xml", PadraoDeLista());
    
    }
  
  public void DesSerializarAlunos(){
      Arquivo<List<Aluno>> arq = new Arquivo<List<Aluno>>();
      List<Aluno> alns = arq.Abrir("./ListaNaluno.xml");
      AtualizarListaPessoa2(alns);
      
      Console.WriteLine("\nDados recuperados de: ListaNaluno.xml");
     }

}
