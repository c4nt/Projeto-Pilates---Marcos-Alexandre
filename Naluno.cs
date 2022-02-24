using System;

class Naluno {
  public List<Aluno> alunos = new List<Aluno>();
  private int na;

  public List<Aluno> Listar() {
    alunos.Sort();
    return alunos;
  }

  public Aluno Listar(int id) {
    for (int i = 0; i < alunos.Count(); i++)
      if (alunos[i].Id == id) return alunos[i];
    return null;  
  }

  public void Inserir(Aluno a) {
    int max = 0;
    foreach (Aluno obj in alunos)
      if(obj.Id > max) max = obj.Id;
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

}