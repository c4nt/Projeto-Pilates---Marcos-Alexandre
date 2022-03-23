using System;

public class Aluno : IComparable<Aluno> {
  public int Id {get;set;}
  public string Nome {get;set;}
  public int Idade {get;set;}
  public Pacote Pacote {get; set;}

  public Turma Turma {get;set;}
  public int IdPacote {get; set;}

  public int IdTurma {get;set;}

  public Aluno(){ }

  public int CompareTo(Aluno obj){
    return this.Nome.CompareTo(obj.Nome);
  }

  public void Apresentar(){
    if (Turma == null && Pacote == null)
      Console.WriteLine($"\n Aluno: {Nome} \n Matrícula: {Id} \n Turma: Sem Cadastro \n Aulas por Semana: 0 \n Valor da Mensalidade: 0 \n");
      
    if (Turma != null && Pacote == null)
      Console.WriteLine($" Aluno: {Nome} \n Matrícula: {Id} \n Turma: {Turma.Descricao} \n Aulas por Semana: 0 \n Valor da Mensalidade: 0 \n");
     
    if (Pacote != null && Turma == null)
      Console.WriteLine($" Aluno: {Nome} \n Matrícula: {Id} \n Turma: Sem Cadastro \n Aulas por Semana: {Pacote.QtdAulas/4} \n Valor da Mensalidade: {Pacote.ValorPacote.ToString("0.00")} \n");
    if ((Pacote != null && Turma != null))
      Console.WriteLine($" Aluno: {Nome} \n Matrícula: {Id} \n Turma: {Turma.Descricao} \n Aulas por Semana: {Pacote.QtdAulas/4} \n Valor da Mensalidade: {Pacote.ValorPacote.ToString("0.00")} \n");
      Console.WriteLine(("").PadRight(42, '-') );
      Console.WriteLine();
  }
  
  
  
}
