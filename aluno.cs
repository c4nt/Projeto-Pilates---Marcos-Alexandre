using System;

class Aluno : IComparable<Aluno> {
  public int Id {get;set;}
  public string Nome {get;set;}
  public int Idade {get;set;}
  public Pacote Pacote {get; set;}

  public Turma Turma {get;set;}

  public int CompareTo(Aluno obj){
    return this.Nome.CompareTo(obj.Nome);
  }

  public void Apresentar(){
    if (Turma == null && Pacote == null)
      Console.WriteLine("Matrícula: " + Id + " / Nome: " + Nome +" / Idade: "+Idade+" / Turma : sem cadastro " + " / Pacote: sem cadastro "+" / Aulas por semana: 0"+" / Valore da mensalidade: 0");
    if (Turma != null && Pacote == null)
      Console.WriteLine("Matrícula: " + Id + " / Nome: " + Nome +" / Idade: "+Idade+ " / Turma : "+ Turma.Descricao + " / Pacote: sem cadastro ");
    if (Pacote != null && Turma == null)
      Console.WriteLine("Matrícula: " + Id + " / Nome: " + Nome +" / Idade: "+Idade+ " / Turma : sem cadastro " + " / Pacote : "+Pacote.Descricao+" / Aulas por semana: "+Pacote.QtdAulas/4+" / Valor da mensalidade: "+Pacote.ValorPacote.ToString("0.00"));
    if ((Pacote != null && Turma != null))
      Console.WriteLine("Matrícula: " + Id + " / Nome: " + Nome +" / Idade: "+Idade+ " / Turma : " + Turma.Descricao + " / Pacote : " +Pacote.Descricao+" / Aulas por semana: "+Pacote.QtdAulas/4+" / Valor da mensalidade: "+Pacote.ValorPacote.ToString("0.00"));
  }
  
  
  
}