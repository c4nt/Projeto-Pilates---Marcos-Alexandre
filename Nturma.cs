using System;

class Nturma {
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
  } 

  public void Atualizar(Turma t) {
    // Localizar na lista a turma que possui o valor de id informado no parametro id da turma em questão
    Turma t_atual = Listar(t.Id);
    if (t_atual == null) return;
    // Altera os dados da turma existente atribuindo o novo valor definido
    t_atual.Descricao = t.Descricao;
    t_atual.Responsavel = t.Responsavel;
  } 


  public void Excluir(Turma t) {
    // Verifica se a turma está cadastrada
    if (t != null) turmas.Remove(t);
    // Recuperar a lista de alunos da turma que será excluída
    List<Aluno> xs = t.AlunoListar();
    // Limpa a propriedade (turma) dos alunos que estavam cadastrados na turma que foi excluida.
    foreach(Aluno p in xs) p.Turma = null; 

  } 
}