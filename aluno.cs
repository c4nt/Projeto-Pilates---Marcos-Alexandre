using System;

class Aluno {
  private int id;
  private string nome;
  private int vezessemana;
  private double mensalidade;
  private Turma turma;
  public Aluno(int id, string nome, int vezessemana, double mensalidade) {
    this.id = id;
    this.nome = nome;
    this.vezessemana = vezessemana > 0 ? vezessemana : 0;
    this.mensalidade = mensalidade > 0 ? mensalidade : 0;
  }
  public Aluno(int id, string nome, int vezessemana, double mensalidade, Turma turma) : this(id, nome, vezessemana, mensalidade) {
    this.turma = turma;
  }
  public void SetId(int id) {
    this.id = id;
  }
  public void SetNome(string nome) {
    this.nome = nome;
  }
  public void SetVezessemana(int vezessemana) {
    this.vezessemana = vezessemana > 0 ? vezessemana : 0;
  }
  public void SetMensalidade(double mensalidade) {
    this.mensalidade = mensalidade > 0 ? mensalidade : 0;
  }
  public void SetTurma(Turma turma) {
    this.turma = turma;
  }
  public int GetId() {
    return id;
  }
  public string Getnome() {
    return nome;
  }
  public int GetVezessemana() {
    return vezessemana;
  }
  public double GetMensalidade() {
    return mensalidade;
  }
  public Turma GetTurma() {
    return turma;
  }
  public override string ToString() {
    if (turma == null)
      return "Matrícula: " + id + " / Nome: " + nome + " / Vezes na Semana: " + vezessemana + " / Mensalidade: " + mensalidade.ToString("0.00");
    else  
      return "Matrícula: " + id + " / Nome: " + nome + " / Vezes na Semana: " + vezessemana + " / Mensalidade: " + mensalidade.ToString("0.00") + " / Turma: " + turma.GetDescricao();
  }
}