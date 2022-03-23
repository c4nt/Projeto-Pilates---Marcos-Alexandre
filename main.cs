using System;
using System.Linq;

class MainClass {
  private static Nturma nturma = Nturma.Singleton;
  private static Naluno naluno = Naluno.Singleton;
  private static Npacote npacote = Npacote.Singleton;
  private static Ninstrutor ninstrutor = new Ninstrutor();
  private static NinstrutorV2 ninstrutorV2 = NinstrutorV2.Singleton;
  
  public static void Main() {
    int op = 0;
    int perfil = 0;

    try{
      
        ninstrutorV2.DesSerializarInstrutoresV2();
        nturma.DesSerializarTurmas();
        npacote.DesSerializarPacotes();
        naluno.DesSerializarAlunos();
    }catch (Exception erro){
     Console.WriteLine(erro.Message);
       }

    do {
      try {
        if(perfil == 0){
          op = 0;
          perfil = MenuInicial();
        }

        if(perfil == 1){
        op = MenuInstrutor();
        switch(op) {
          case 1 : ListaTurmaLinq(); break;
          case 2 : InserirTurma(); break;
          case 3 : AtualizarTurma(); break;
          case 4 : ExcluirTurma(); break;
          case 5 : ListarAlunos(); break;
          case 6 : CadastrarAlunoTurma(); break;
          case 7 : CadastrarPac(); break;
          case 8 : ListarPac(); break;
          case 9 : CadastrarAlunoPac(); break;
          case 10 : ListaAdesoesLinq(); break;
          case 11 : AtualizarPac(); break;
          case 12 : ExcluirPac(); break;
          case 13 : CadastrarInstV2(); break;
          case 14 : AtualizarInstV2(); break;
          case 15 : ExcluirInstV2(); break;
          case 16 : ListarInstV2(); break;
          case 17 : ApresentarResumo(); break;
          
          case 99 : perfil = 0; break;
        }
        }

        if(perfil == 2){
        op = MenuAluno();
        switch(op) {
          case 1 : CadastrarAluno(); break;
          case 2 : AtualizarCadastro(); break;
          case 3 : VerificarDados(); break;
          case 4 : ExcluirCadastro(); break;
          case 99 : perfil = 0; break;
          
        }}}
      
      catch (Exception erro) {
        Console.WriteLine(erro.Message);
        op = 100;
      }
    } while (op != 0);
    Console.WriteLine ("----- Programa Encerrado ------------");

    try{
      naluno.SerializarAlunos();
      nturma.SerializarTurmas();
      ninstrutorV2.SerializarInstrutoresV2();
      npacote.SerializarPacotes();
    }catch (Exception erro){
     Console.WriteLine(erro.Message);
       }  
           
  }

  public static int MenuInicial() {
    Console.WriteLine();
    Console.WriteLine("----- Aplicativo Gestão Pilates -------------\n");
    Console.WriteLine("1 - Acessar area do Instrutor");
    Console.WriteLine("2 - Acessar área do Aluno");
    Console.WriteLine();
    Console.WriteLine("-------------------------------------\n");
    Console.Write("Informe uma opção: ");
    int op = int.Parse(Console.ReadLine());
    Console.WriteLine("\n-------------------------------------\n");
    return op;
    }
  public static int MenuInstrutor() {
    Console.WriteLine();
    Console.WriteLine("----- Menu do Instrutor-------------");
    Console.WriteLine();
    Console.WriteLine("Configurações de Turma:");
    Console.WriteLine("1 - Listar Turmas");
    Console.WriteLine("2 - Criar Turma");
    Console.WriteLine("3 - Atualizar Turma");
    Console.WriteLine("4 - Excluir Turma");
    Console.WriteLine("5 - Relação de Alunos");
    Console.WriteLine("6 - Cadastrar aluno em Turma\n");
    Console.WriteLine("Configurações de Pacote:");
    Console.WriteLine("7 - Cadastrar pacotes");
    Console.WriteLine("8 - Listar pacotes disponíveis");
    Console.WriteLine("9 - Cadastrar aluno em pacote");
    Console.WriteLine("10 - Listar adesões de um pacote");
    Console.WriteLine("11 - Atualizar pacotes");
    Console.WriteLine("12 - Excluir pacotes\n");
    Console.WriteLine("Configurações do Instrutor:");
    Console.WriteLine("13 - Cadastrar Instrutor");
    Console.WriteLine("14 - Atualizar Cadastro de Instrutor");
    Console.WriteLine("15 - Excluir Cadastro de Instrutor");
    Console.WriteLine("16 - Relação de instrutores ");
    Console.WriteLine();
    Console.WriteLine("17 - Apresentar Resumo das Operações");
    Console.WriteLine();
    Console.WriteLine("99 - Voltar ao menu inicial");
    Console.WriteLine("0 - Encerrar Programa");
    Console.WriteLine("-------------------------------------\n");
    Console.Write("Informe uma opção: ");
    int op = int.Parse(Console.ReadLine());
    Console.WriteLine("\n-------------------------------------\n");
    return op; 
  }

  public static int MenuAluno() {
    Console.WriteLine();
    Console.WriteLine("----- Menu do Aluno-----------------");
    Console.WriteLine("1 - Cadastrar-se no Sistema");
    Console.WriteLine("2 - Atualizar Cadastro");
    Console.WriteLine("3 - Verificar dados do cadastro");
    Console.WriteLine("4 - Excluir Cadastro");
    Console.WriteLine("99 - Voltar ao menu inicial");

    Console.WriteLine("0 - Encerrar Programa");
    Console.WriteLine("-------------------------------------\n");
    Console.Write("Informe uma opção: ");
    int op = int.Parse(Console.ReadLine());
    Console.WriteLine("\n-------------------------------------\n");
    return op; 
  }

  public static void ListaTurmaLinq(){
    List<Turma> tm = nturma.Listar(); 
    
    var tms = tm.OrderBy(t => t.Descricao).ThenBy(t => t.AlunoListar().Count());
    
    if(tms.Count() == 0) {Console.WriteLine("Nenhuma turma cadastrada no sistema"); return;}
    Console.WriteLine($"------- Turmas Cadastradas no Sistema ------- \n");
    foreach(var obj in tms) Console.WriteLine($" ID: {obj.Id} \n Descrição: {obj.Descricao} \n Responsável: {obj.Responsavel.Nome} \n Quantidade de alunos matriculados: {obj.AlunoListar().Count()} \n");
  }


  public static void InserirTurma() {
    Console.WriteLine("----- Cadastro de Turmas -----");
    
    Console.Write("Informe a descrição da Turma: ");
    string descricao = Console.ReadLine();
    ListarInstV2();
    Console.Write("Informe o ID do instrutor para essa turma: ");
    int id = int.Parse(Console.ReadLine());
    InstrutoV2 inst = ninstrutorV2.Listar(id);
    Turma t = new Turma {Descricao = descricao, Responsavel = inst, IdResponsavel = id};
    nturma.Inserir(t);
    
  }

  public static void AtualizarTurma() {
    Console.WriteLine("----- Atualização de Turma -----\n");
    ListaTurmaLinq();
    Console.Write("Informe o Id da turma que sera atualizada: ");
    int id = int.Parse(Console.ReadLine());
    Turma tmref = nturma.Listar(id);
    InstrutoV2 instref = tmref.Responsavel;
    Console.Write("Informe a nova descrição: ");
    string descricao = Console.ReadLine();
    ListarInstV2();
    Console.Write("Informe o ID do instrutor para essa turma: ");
    int idinst = int.Parse(Console.ReadLine());
    InstrutoV2 inst = ninstrutorV2.Listar(idinst);
    Turma t = new Turma {Id = id, Descricao = descricao, Responsavel = inst, IdResponsavel = idinst};
    nturma.Atualizar(t);

    List<Turma> tmsnulas = instref.ListarTurmasInst();

    foreach(Turma trm in tmsnulas) 
      if(trm.Responsavel == null || trm.Responsavel != instref) instref.ExcTurmaInst(trm);
    }

  public static void ExcluirTurma() {
    Console.WriteLine("----- Exclusão de Turmas -----");
    ListaTurmaLinq();
    Console.Write("Informe o Id da turma que será excluida: ");
    int id = int.Parse(Console.ReadLine());
    Turma tmref = nturma.Listar(id);
    InstrutoV2 instref = tmref.Responsavel;

    Turma t = nturma.Listar(id);
    nturma.Excluir(t);
    instref.ExcTurmaInst(t);
    
  }

  public static async void ListarAlunos() {
    Console.WriteLine("----- Relação de Alunos -----");
    List<Aluno> als = naluno.Listar();
    if (als.Count() == 0) {
      Console.WriteLine("Nenhum aluno foi cadastrado ainda");
      return;
    }
    foreach(Aluno a in als) a.Apresentar(); 
    Console.WriteLine();
  }

  public static void CadastrarAluno() {
    Console.WriteLine("----- Cadastro de Alunos -----");
    
    Console.Write("Informe seu nome : ");
    string nome = Console.ReadLine();
    Console.Write("Informe sua idade : ");
    int idade = int.Parse(Console.ReadLine());

    // p = npacote.Listar(idpac);    
    
    //Turma t = nturma.Listar(idturma);

    Aluno a = new Aluno {Nome = nome, Idade = idade};
    //a.Pacote = p;
    //a.Turma = t;
    naluno.Inserir(a);
  }

  public static void VerificarDados() {
    Console.Write("Informe sua Matrícula: ");
    int id = int.Parse(Console.ReadLine());
    Aluno a = naluno.Listar(id);
    Console.WriteLine();
    if(a == null) Console.WriteLine("(sem registro no sistema)");
    else if (a != null){ Console.WriteLine("----- Informações dessa Matrícula: -----");
          a.Apresentar();}

  }

  public static void ExcluirCadastro() {
    Console.WriteLine("----- Excluir Cadastro -----");
    ListarAlunos();
    Console.Write("Informe a matrícula do aluno que será excluido: ");
    int id = int.Parse(Console.ReadLine());
    Aluno a = naluno.Listar(id);
    naluno.Excluir(a);
  }

  public static void AtualizarCadastro() {
    Console.WriteLine("----- Atualização de Cadastro -----");
    ListarAlunos();
    Console.Write("Informe a matrícula do aluno que será atualizado: ");
    int id = int.Parse(Console.ReadLine());
    Aluno aln = naluno.Listar(id);
    Console.Write("Informe seu nome : ");
    string nome = Console.ReadLine();
    Console.Write("Informe sua idade : ");
    int idade = int.Parse(Console.ReadLine());
    //Pacote p = npacote.Listar(idpac);
    //Turma t = nturma.Listar(idturma);    
    Aluno a = new Aluno {Id = id, Nome = nome, Idade = idade, Turma = aln.Turma, Pacote = aln.Pacote};
    
    naluno.Atualizar(a);
  }

  public static void CadastrarAlunoTurma() {
    Console.WriteLine("----- Cadastrar Aluno em Turma -----");
    ListarAlunos();
    Console.WriteLine();
    Console.Write("Informe a matrícula do aluno que será cadastrado na turma: ");
    int id = int.Parse(Console.ReadLine());
    Aluno aln = naluno.Listar(id);
    Console.WriteLine();
    ListaTurmaLinq();
    Console.Write("Informe o código da turma para esse aluno: ");
    int idturma = int.Parse(Console.ReadLine());
    Turma t = nturma.Listar(idturma);   
    Aluno a = new Aluno {Id = aln.Id, Nome = aln.Nome, Idade = aln.Idade, Turma = t, Pacote = aln.Pacote};
    naluno.Atualizar(a);
  }

  public static void CadastrarAlunoPac() {
    Console.WriteLine("----- Cadastrar Aluno em Pacote -----");
    ListarAlunos();
    Console.WriteLine();
    Console.Write("Informe a matrícula do aluno que será cadastrado no pacote: ");
    int id = int.Parse(Console.ReadLine());
    Aluno aln = naluno.Listar(id);
    Console.WriteLine();
    ListarPac();
    Console.Write("Informe o ID do pacote para esse aluno: ");
    int idpac = int.Parse(Console.ReadLine());
    Pacote p = npacote.Listar(idpac);  
    Aluno a = new Aluno {Id = aln.Id, Nome = aln.Nome, Idade = aln.Idade, Turma = aln.Turma, Pacote = p};
    naluno.Atualizar(a);
  }

  public static void ListarPac() {
    List<Pacote> pacs = npacote.Listar();
    if (pacs.Count() == 0) {
      Console.WriteLine("Nenhum pacote foi cadastrado no sistema");
      return;
    }
    var pacList = pacs.OrderByDescending( p => p.ListarAdesoes().Count());
    Console.WriteLine("Lista de pacotes cadastrados no sistema: \n");
    foreach(var p in pacList){ Console.WriteLine($" Id: {p.Id} \n Descrição do Pacote: {p.Descricao} \n Quantidade de aulas mês: {p.QtdAulas} \n Valor da mensalidade: {p.ValorPacote} \n Adesões: {p.ListarAdesoes().Count()} \n");
    Console.WriteLine("---------------------------------------- \n");}  
  }
  public static void CadastrarPac() {
    Console.WriteLine("----- Criar Pacote -----");
    
    Console.Write("Informe uma descrição para este pacote: ");
    string desc = Console.ReadLine();
    Console.Write("Informe a quantidade total de aulas no mês: ");
    int qtd = int.Parse(Console.ReadLine());
    Console.Write("Informe o valor da mensalidade para esse pacote de aulas: ");
    int vlr = int.Parse(Console.ReadLine());   

    Pacote p = new Pacote {Descricao = desc, QtdAulas = qtd, ValorPacote = vlr};

    npacote.Inserir(p);
  }

  public static void ExcluirPac() {
    Console.WriteLine("----- Excluir Pacote -----");
    ListarPac();
    Console.Write("Informe o ID do pacote que será excluido: ");
    int id = int.Parse(Console.ReadLine());
    Pacote p = npacote.Listar(id);
    npacote.Excluir(p);
  }

  public static void AtualizarPac() {
    Console.WriteLine("----- Atualizar informações do pacote -----\n");
    ListarPac();
    Console.Write("Informe o ID do pacote que sera atulizado: ");
    int id = int.Parse(Console.ReadLine());
    Console.Write("Informe a nova descrição: ");
    string descricao = Console.ReadLine();
    Console.Write("Informe a quantidade total de aula no mês: ");
    int qtd = int.Parse(Console.ReadLine());
    Console.Write("Informe o valor da mensalidade para esse pacote de aula: ");
    int vlr = int.Parse(Console.ReadLine());

    Pacote p = new Pacote {Id = id, Descricao = descricao, QtdAulas = qtd, ValorPacote = vlr};

    npacote.Atualizar(p);
  }

  public static void ListaAdesoesLinq(){
    ListarPac();
    Console.Write("Informe o ID do pacote que será listado: ");
    int id = int.Parse(Console.ReadLine());
    Pacote p = npacote.Listar(id);
    
    var ad = naluno.Listar().Where( v => v.Pacote == p);
    
    Console.WriteLine();
    Console.WriteLine($"------- Relação de Alunos - {p.Descricao} -------  \n");
    foreach(var obj in ad) Console.WriteLine($" Aluno: {obj.Nome} / Matrícula: {obj.Id} / Turma: {obj.Turma.Descricao}");
    Console.WriteLine($"\n Total de alunos matriculados: {p.ListarAdesoes().Count()} ");
    Console.WriteLine("--------------------------------------------- \n");
  }

  /*public static void ListarAdesoesPac() {
    Console.WriteLine("----- Lista de Pacotes -----");
    ListarPac();
    Console.Write("Informe o Id do pacote que será verificado: ");
    int id = int.Parse(Console.ReadLine());
    Pacote p = npacote.Listar(id);
    List<Aluno> alns = new List<Aluno>();
    alns = p.ListarAdesoes();

    if (alns.Count() == 0) {
      Console.WriteLine($"\n ---------- Alunos que aderiram ao {p.Descricao}  ----------- \n \n  Nenhuma aluno cadastrado nesse pacote");
      return;
    }
    foreach(Aluno t in alns) Console.WriteLine($"\n ---------- Alunos que aderiram ao {p.Descricao}  ----------- \n \n Nome do Aluno: "+t.Nome+" / Matrícula do Aluno: "+t.Id);
    Console.WriteLine();  
  }
  */

public static void ListarInstV2() {
    Console.WriteLine("------------------ Instrutores Cadastrados ------------------");
    List<InstrutoV2> instv2s = ninstrutorV2.Listar();
    if (instv2s.Count() == 0) {
      Console.WriteLine("Nenhum Instrutor Cadastrado");
      return;
    }
    foreach(InstrutoV2 t in instv2s) t.Apresentar();
    Console.WriteLine();  
  }
  public static void CadastrarInstV2() {
    Console.WriteLine("----- Cadastrar Instrutor -----");
    
    Console.Write("Informe o nome deste instrutor: ");
    string nome = Console.ReadLine();
    Console.Write("Formaçao profissional: ");
    string form = Console.ReadLine();   

    InstrutoV2 i = new InstrutoV2 {Nome = nome, Formacao = form};

    ninstrutorV2.Inserir(i);
  }

  public static void ExcluirInstV2() {
    Console.WriteLine("----- Excluir Instrutor -----");
    ListarInstV2();
    Console.Write("Informe o ID do instrutor que será excluido: ");
    int id = int.Parse(Console.ReadLine());
    InstrutoV2 p = ninstrutorV2.Listar(id);
    ninstrutorV2.Excluir(p);
  }

  public static void AtualizarInstV2() {
    Console.WriteLine("----- Atualizar informações do Instrutor -----\n");
    ListarInstV2();
    Console.Write("Informe o ID do instrutor que sera atulizado: ");
    int id = int.Parse(Console.ReadLine());
    Console.Write("Informe o nome desse instrutor: ");
    string nome = Console.ReadLine();
    Console.Write("Formação profissional: ");
    string form = Console.ReadLine();
    
    InstrutoV2 p = new InstrutoV2 {Id = id, Nome = nome, Formacao = form};

    ninstrutorV2.Atualizar(p);
  }

  public static void ListarTurmasInstV2() {
    Console.WriteLine("----- Lista de Instrutores -----");
    ListarInstV2();
    Console.Write("Informe o Id do Instrutor que será verificado: ");
    int id = int.Parse(Console.ReadLine());
    InstrutoV2 inst = ninstrutorV2.Listar(id);
    List<Turma> tms = new List<Turma>();
    tms = inst.ListarTurmasInst();

    if (tms.Count() == 0) {
      Console.WriteLine($"\n ---------- Turmas atribuídas ao instrutor: {inst.Nome}  ----------- \n \n  Nenhuma turma atribuída a esse instrutor");
      return;
    }
    foreach(Turma t in tms) Console.WriteLine($"\n ---------- Turmas atribuídas ao instrutor: {inst.Nome}  ----------- \n \n Descrição da Turma: "+t.Descricao+" / Quantidade de Alunos: "+t.alunos.Count());
    Console.WriteLine();  
  }

  /*public static void ListarDadosAluno(){
    List<Aluno> teste = naluno.Listar();
    var listAlnTur = naluno.Listar().Join(nturma.Listar(), a => a.Turma, t => t, 
    (a,t) => new {a.Id, a.Nome, t.Descricao, t.Responsavel});
    var listAlnpac = naluno.Listar().Join(npacote.Listar(), a => a.Pacote, p => p, 
    (a,p) => new {a.Id, p.Descricao, p.QtdAulas, p.ValorPacote});
    var listMix = listAlnTur.Join(listAlnpac, a => a.Id, b => b.Id, (a, b) => new {a.Id, a.Nome, a.Descricao, b.QtdAulas, b.ValorPacote});
    
    Console.WriteLine("-----------Alunos Cadastrados------------- \n");
    foreach(var obj in listMix){
    Console.WriteLine($" Aluno: {obj.Nome} \n Matrícula: {obj.Id} \n Turma: {obj.Descricao} \n Aulas por Semana: {obj.QtdAulas/4} \n Valor da Mensalidade: {obj.ValorPacote.ToString("0.00")} \n");
    Console.WriteLine(("").PadRight(42, '-') );
    Console.WriteLine();}
    var x = listMix.Select(y => y.ValorPacote);
    var fat = x.Sum();
    Console.WriteLine($" Total de Alunos: {naluno.Listar().Count()} alunos");
    Console.WriteLine($" Faturamento Mensal: {fat, 8:c} reais");
    Console.WriteLine(("").PadRight(42,'-'));
    
    
  }
  */

  public static void ApresentarResumo(){
    var entradas = naluno.Listar().Where(a => a.Pacote != null);
    var x = entradas.Select(y => y.Pacote.ValorPacote);
    var fat = x.Sum();
    Console.WriteLine("----------- Resumo da Operação: ----------- \n");
    Console.WriteLine($" Total de alunos matriculados : {naluno.Listar().Count()} alunos");
    Console.WriteLine($" Total de turmas ativas : {nturma.Listar().Count()} turmas");
    Console.WriteLine($" Total de pacotes disponíveis : {nturma.Listar().Count()} turmas");
    Console.WriteLine($" Total de instrutores cadastrados : {ninstrutorV2.Listar().Count()} instrutores");
    Console.WriteLine($" Faturamento Mensal: {fat, 8:c} reais \n");
    Console.WriteLine(("").PadRight(42,'-'));
  }

}
