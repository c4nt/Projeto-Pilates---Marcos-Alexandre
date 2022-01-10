using System;

class Nturma {
  private Turma[] turmas = new Turma[10];
  private int nt;

  public Turma[] Listar() {
    Turma[] t = new Turma[nt];
    Array.Copy(turmas, t, nt);
    return t;
  }

  public Turma Listar(int id) {
    for (int i = 0; i < nt; i++)
      if (turmas[i].GetId() == id) return turmas[i];
    return null;  
  }

  public void Inserir(Turma t) {
    if (nt == turmas.Length) {
      Array.Resize(ref turmas, 2 * turmas.Length);
    }
    turmas[nt] = t;
    nt++;
  } 

  public void Atualizar(Turma t) {
    // Localizar no vetor a categoria que possui o id informado no parametro categoria
    Turma t_atual = Listar(t.GetId());
    if (t_atual == null) return;
    // Alterar os dados da minha categoria
    t_atual.SetDescricao(t.GetDescricao());
  } 

  private int Indice(Turma t) {
    for (int i = 0; i < nt; i++)
      if (turmas[i] == t) return i;
    return -1;      
  }

  public void Excluir(Turma t) {
    // Verifica se a categoria está cadastrada
    int n = Indice(t);
    if (n == -1) return;
    for (int i = n; i < nt - 1; i++)
      turmas[i] = turmas[i + 1];
    nt--;
    // Recuperar a lista de produtos da categoria
    Aluno[] xs = t.AlunoListar();
    foreach(Aluno p in xs) p.SetTurma(null); 
  } 
}