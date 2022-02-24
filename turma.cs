using System;

class Turma : IComparable<Turma>{
  public int Id {get;set;}
  public string Descricao {get;set;}
  public Instrutor Responsavel {get;set;}
  public List<Aluno> alunos = new List<Aluno>();
  private int qtdalu;
  
  public int CompareTo(Turma obj){
    return this.Descricao.CompareTo(obj.Descricao);
  }
  public List<Aluno> AlunoListar() {
  
    return alunos;
  }
  public void AlunoInserir(Aluno a) {
    alunos.Add(a);
    qtdalu++;
  }

  public void ExcluirAluno(Aluno a) {
    if (a != null) alunos.Remove(a);  
  }
  public override string ToString() {
    if(Responsavel == null)
      return $"Nº de id da turma: {Id} /  Descrição da Turma: {Descricao} /  Nº de Alunos Matriculados: {alunos.Count()} / Instrutor Responsável: Não cadastrado";
    else
      return $"Nº de id da turma: {Id} /  Descrição da Turma: {Descricao} /  Nº de Alunos Matriculados: {alunos.Count()} / Instrutor Responsável: {Responsavel.Nome}";
  }
}