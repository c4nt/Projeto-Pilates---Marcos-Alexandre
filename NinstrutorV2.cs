using System;
using System.IO;
using System.Text;
using System.Xml.Serialization;
using System.Linq;

class NinstrutorV2{
    private NinstrutorV2(){}
    static NinstrutorV2 obj = new NinstrutorV2();
    public static NinstrutorV2 Singleton {get => obj;}
    private List<InstrutoV2> instrutoresV2 = new List<InstrutoV2>();


    public List<InstrutoV2> Listar(){
        
        return instrutoresV2;
    }

    public InstrutoV2 Listar(int id){
        for (int i = 0; i < instrutoresV2.Count(); i++)
        if (instrutoresV2[i].Id == id) return instrutoresV2[i];
        return null;
    
    }

    public List<Turma> ListarTurmas(InstrutoV2 p){
        List<Turma> tms = new List<Turma>();
        tms = p.ListarTurmasInst();
        return tms;
    }
    public void Inserir(InstrutoV2 p){
        int max = 0;
        foreach (InstrutoV2 obj in instrutoresV2)
            if(obj.Id > max) max = obj.Id;
        p.Id = max + 1;
        instrutoresV2.Add(p);
        
    }

    public void Excluir(InstrutoV2 p) {
        if (p != null) instrutoresV2.Remove(p);

        List<Turma> x = p.ListarTurmasInst();
        foreach(Turma t in x) t.Responsavel = null; 
  }

    public void Atualizar(InstrutoV2 inst) {
        InstrutoV2 inst_atual = Listar(inst.Id);
        if (inst_atual == null) return;
        inst_atual.Nome = inst.Nome;
        inst_atual.Formacao = inst.Formacao;        
  }

  

  public List<InstrutoV2> PadraoDeLista(){
        List<InstrutoV2> aux = new List<InstrutoV2>();
        foreach(InstrutoV2 i in instrutoresV2){
            InstrutoV2 inst = new InstrutoV2{Id = i.Id, Nome = i.Nome, Formacao = i.Formacao};
            aux.Add(inst);
        }
        return aux;
    }
  
  
  public void SerializarInstrutoresV2(){
        Arquivo<List<InstrutoV2>> arq = new Arquivo<List<InstrutoV2>>();
        arq.Salvar("./ListaNinstrutorV2.xml", PadraoDeLista());
        
    }

  
  public void DesSerializarInstrutoresV2(){
        Arquivo<List<InstrutoV2>> arq = new Arquivo<List<InstrutoV2>>();
        instrutoresV2 = arq.Abrir("./ListaNinstrutorV2.xml");
        
        Console.WriteLine("Dados recuperados de: ListaNinstrutorV2.xml");
     } 

}