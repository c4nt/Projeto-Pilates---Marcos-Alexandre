using System;

class Naluno {
  private Aluno[] alunos = new Aluno[10];
  private int na;

  public Aluno[] Listar() {
    Aluno[] a = new Aluno[na];
    Array.Copy(alunos, a, na);
    return a;
  }

  public Aluno Listar(int id) {
    for (int i = 0; i < na; i++)
      if (alunos[i].GetId() == id) return alunos[i];
    return null;  
  }

  public void Inserir(Aluno p) {
    if (na == alunos.Length) {
      Array.Resize(ref alunos, 2 * alunos.Length);
    }
    alunos[na] = p;
    na++;
    Turma c = p.GetTurma();
    if (c != null) c.AlunoInserir(p);
  } 

  public void Atualizar(Aluno a) {
    Aluno a_atual = Listar(a.GetId());
    if (a_atual == null) return;
    a_atual.SetNome(a.Getnome());
    a_atual.SetVezessemana(a.GetVezessemana());
    a_atual.SetMensalidade(a.GetMensalidade());
    if (a_atual.GetTurma() != null) 
      a_atual.GetTurma().ExcluirAluno(a_atual);
    a_atual.SetTurma(a.GetTurma());
    if (a_atual.GetTurma() != null)
      a_atual.GetTurma().AlunoInserir(a_atual);
  }

  private int Indice(Aluno a) {
    for(int i = 0; i < na; i++)
      if (alunos[i] == a) return i;
    return -1;  
  }

  public void Excluir(Aluno a) {
    int n = Indice(a);
    if (n == -1) return;
    for (int i = n; i < na - 1; i++)
      alunos[i] = alunos[i + 1];
    na--;
    Turma t = a.GetTurma();
    if (t != null) t.ExcluirAluno(a);  
  }

}