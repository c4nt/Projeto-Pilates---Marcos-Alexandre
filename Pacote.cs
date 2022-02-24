using System;

class Pacote : IComparable<Pacote>{
    public int Id {get;set;}
    public string Descricao {get;set;}
    public int QtdAulas {get;set;}
    public int ValorPacote {get;set;}
    private List<Aluno> adesoes = new List<Aluno>();

    
    public int CompareTo(Pacote obj){
        return this.Descricao.CompareTo(obj.Descricao);
  }
    public List<Aluno> ListarAdesoes(){
        
        return adesoes;
    }

    public void AdcAlu(Aluno a){
        adesoes.Add(a);
    }

    public void ExcAlu(Aluno a){
        if(a != null) adesoes.Remove(a);
    }

    public override string ToString(){
        return $"ID: {Id} / Descrição do Pacote: {Descricao} / Quantidade de Aulas: {QtdAulas} / Valor da Mensalidade {ValorPacote.ToString("0.00")} / Adesôes: {adesoes.Count()}";
    }
}