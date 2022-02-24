using System;

class Npacote{
    private List<Pacote> pacotes = new List<Pacote>();


    public List<Pacote> Listar(){
        pacotes.Sort();
        return pacotes;
    }

    public Pacote Listar(int id){
        for (int i = 0; i < pacotes.Count(); i++)
        if (pacotes[i].Id == id) return pacotes[i];
        return null;
    
    }

    public List<Aluno> ListarAdesoes(Pacote p){
        List<Aluno> ads = new List<Aluno>();
        ads = p.ListarAdesoes();
        return ads;
    }
    public void Inserir(Pacote p){
        int max = 0;
        foreach (Pacote obj in pacotes)
            if(obj.Id > max) max = obj.Id;
        p.Id = max + 1;
        pacotes.Add(p);
    }

    public void Excluir(Pacote p) {
        if (p != null) pacotes.Remove(p);

        List<Aluno> x = p.ListarAdesoes();
        foreach(Aluno a in x) a.Pacote = null; 
  }

    public void Atualizar(Pacote p) {
        Pacote p_atual = Listar(p.Id);
        if (p_atual == null) return;
        p_atual.Descricao = p.Descricao;
        p_atual.QtdAulas = p.QtdAulas;
        p_atual.ValorPacote = p.ValorPacote;
        
  }

}