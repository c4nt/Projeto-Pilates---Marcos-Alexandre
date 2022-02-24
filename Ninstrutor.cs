using System;

class Ninstrutor {
  private List<Instrutor> Instrutores = new List<Instrutor>();
  private int na;

  public List<Instrutor> Listar() {
    Instrutores.Sort();
    return Instrutores;
  }

  public Instrutor Listar(int id) {
    for (int i = 0; i < Instrutores.Count(); i++)
      if (Instrutores[i].Id == id) return Instrutores[i];
    return null;  
  }

  public void Inserir(Instrutor a) {
    int max = 0;
    foreach (Instrutor obj in Instrutores)
      if(obj.Id > max) max = obj.Id;
    a.Id = max + 1; 
    Instrutores.Add(a);
  } 

  public void Atualizar(Instrutor inst) {
    Instrutor inst_atual = Listar(inst.Id);
    if (inst_atual == null) return;
    inst_atual.Nome = inst.Nome;
    inst_atual.Formacao = inst.Formacao;
  }

  

  public void Excluir(Instrutor inst) {
    if (inst != null) Instrutores.Remove(inst); 
  }

}