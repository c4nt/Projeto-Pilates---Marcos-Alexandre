using System;
using System.Collections.Generic;

class Instrutor : IComparable<Instrutor>{
    public int Id {get;set;}
    public string Nome {get;set;}
    public string Formacao {get;set;}
    


    public int CompareTo(Instrutor obj){
        return this.Nome.CompareTo(obj.Nome);
    }
    
    

    public override string ToString()
    {   
        return $"Matrícula: {Id} / Nome: {Nome} / Formação: {Formacao}";
    }
}
