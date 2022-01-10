using System;

class Turma {
  private int id;
  private string descricao;
  private Aluno[] alunos = new Aluno[10];
  private int qtdalu;
  public Turma (int id, string descricao) {
    this.id = id;
    this.descricao = descricao;
  }
  public void SetId(int id) {
    this.id = id;
  }
  public void SetDescricao(string descricao) {
    this.descricao = descricao;
  }
  public int GetId() {
    return id;
  }
  public string GetDescricao() {
    return descricao;
  }
  public Aluno[] AlunoListar() {
    Aluno[] t = new Aluno[qtdalu];
    Array.Copy(alunos, t, qtdalu);
    return t;
  }
  public void AlunoInserir(Aluno a) {
    if (qtdalu == alunos.Length) {
      Array.Resize(ref alunos, 2 * alunos.Length);
    }
    alunos[qtdalu] = a;
    qtdalu++;
  }

  private int IndiceAluno(Aluno a) {
    for (int i = 0; i < qtdalu; i++)
      if (alunos[i] == a) return i;
    return -1;  
  }

  public void ExcluirAluno(Aluno a) {
    int n = IndiceAluno(a);
    if (n == -1) return;
    for (int i = n; i < qtdalu - 1; i++)
      alunos[i] = alunos[i + 1];
    qtdalu--;  
  }
  public override string ToString() {
    return "Nº de id da turma: " + id + "  /  Descrição da Turma: " + descricao + "  /  Nº de Alunos Matriculados: " + qtdalu;
  }
}