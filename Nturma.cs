using System;
using System.IO;
using System.Text;
using System.Xml.Serialization;
using System.Linq;

class Nturma {
  private Nturma(){}
  static Nturma obj = new Nturma();
  public static Nturma Singleton {get => obj;}
  private List<Turma> turmas = new List<Turma>();
  private int nt;

  public List<Turma> Listar() {
    turmas.Sort();
    return turmas;
  }

  public Turma Listar(int id) {
    for (int i = 0; i < turmas.Count(); i++)
      if (turmas[i].Id == id) return turmas[i];
    return null;  
  }

  public void Inserir(Turma t) {
    int max = 0;
    foreach (Turma obj in turmas)
      if(obj.Id > max) max = obj.Id;
    t.Id = max + 1;
    turmas.Add(t);
    InstrutoV2 inst = t.Responsavel;
    if (inst != null) inst.AdcTurmaInst(t);
  } 

  public void Atualizar(Turma t) {
    // Localizar na lista a turma que possui o valor de id informado no parametro id da turma em questão
    Turma t_atual = Listar(t.Id);
    if (t_atual == null) return;
    // Altera os dados da turma existente atribuindo o novo valor definido
    t_atual.Descricao = t.Descricao;
    t_atual.Responsavel = t.Responsavel;
    
    if (t_atual.Responsavel != null) 
      t_atual.Responsavel.ExcTurmaInst(t_atual);
    t_atual.Responsavel = t.Responsavel;
    t_atual.IdResponsavel = t.IdResponsavel;
    if (t_atual.Responsavel != null)
      t_atual.Responsavel.AdcTurmaInst(t_atual);
  } 


  public void Excluir(Turma t) {
    // Verifica se a turma está cadastrada
    if (t != null) turmas.Remove(t);
    // Recuperar a lista de alunos da turma que será excluída
    List<Aluno> xs = t.AlunoListar();
    // Limpa a propriedade (turma) dos alunos que estavam cadastrados na turma que foi excluida.
    foreach(Aluno p in xs) p.Turma = null; 

  } 

  public List<Turma> PadraoDeLista(){
    List<Turma> aux = new List<Turma>();
    foreach(Turma t in turmas){
        Turma tm = new Turma{Id = t.Id, Descricao = t.Descricao, Responsavel = null, IdResponsavel = t.IdResponsavel};
        aux.Add(tm);
    }
    return aux;
    }

  public void AtualizarListaTurma(List<Turma> tlist){
      foreach(Turma t in tlist){
        InstrutoV2 iv2 = NinstrutorV2.Singleton.Listar(t.IdResponsavel);
        
        t.Responsavel = iv2;
        iv2.AdcTurmaInst(t);
        turmas.Add(t);
      }
      
    }  

  public void SerializarTurmas(){
    Arquivo<List<Turma>> arq = new Arquivo<List<Turma>>();
    arq.Salvar("./ListaNturma.xml", PadraoDeLista());
    
    }

  
  public void DesSerializarTurmas(){
    Arquivo<List<Turma>> arq = new Arquivo<List<Turma>>();
    List<Turma> tms = arq.Abrir("./ListaNturma.xml");
    AtualizarListaTurma(tms);        
    Console.WriteLine("Dados recuperados de: ListaNturma.xml");
     } 
}
