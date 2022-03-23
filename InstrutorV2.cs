using System;

public class InstrutoV2 {
    public int Id {get;set;}
    public string Nome {get;set;}
    public string Formacao {get;set;}
    private List<Turma> turmasInst = new List<Turma>();

    public InstrutoV2(){ }
    
    public List<Turma> ListarTurmasInst(){
        
        return turmasInst;
    }

    public void AdcTurmaInst(Turma t){
        turmasInst.Add(t);
    }

    public void ExcTurmaInst(Turma t){
        if(t != null) turmasInst.Remove(t);
    }

    public void Apresentar(){
        Console.WriteLine();
        Console.WriteLine($"Matrícula: {Id} / Instrutor: {Nome} / Formação: {Formacao}\n");
        Console.WriteLine($"Turmas atribuídas ao instrutor(a) {Nome}:");
        if(turmasInst.Count() == 0) 
        Console.WriteLine("\nSem registro de turmas");
        
        foreach(Turma t in turmasInst)
        Console.WriteLine($"Descrição: {t.Descricao} / Quantidade de alunos matriculados: {t.alunos.Count()}");
        Console.WriteLine($"\n--------------------------------------------------------------");
    }

    public override string ToString(){
        return $"ID: {Id} / Instrutor: {Nome} / Formação Profissional: {Formacao} / Quantidade de Turmas: {turmasInst.Count()}";
    }

}