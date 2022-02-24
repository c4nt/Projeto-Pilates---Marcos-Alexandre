using System;

class MainClass {
  private static Nturma nturma = new Nturma();
  private static Naluno naluno = new Naluno();
  private static Npacote npacote = new Npacote();
  private static Ninstrutor ninstrutor = new Ninstrutor();
  
  public static void Main() {
    int op = 0;
    int perfil = 0;
    do {
      try {
        if(perfil == 0){
          op = 0;
          perfil = MenuInicial();
        }

        if(perfil == 1){
        op = MenuInstrutor();
        switch(op) {
          case 1 : ListarTurmas(); break;
          case 2 : InserirTurma(); break;
          case 3 : AtualizarTurma(); break;
          case 4 : ExcluirTurma(); break;
          case 5 : ListarAlunos(); break;
          case 6 : CadastrarAlunoTurma(); break;
          case 7 : CadastrarPac(); break;
          case 8 : ListarPac(); break;
          case 9 : CadastrarAlunoPac(); break;
          case 10 : ListarAdesoesPac(); break;
          case 11 : AtualizarPac(); break;
          case 12 : ExcluirPac(); break;
          case 13 : CadastrarInstrutor(); break;
          case 14 : AtualizarCadastroInst(); break;
          case 15 : ExcluirCadastroInst(); break;
          case 16 : ListarInstrutores(); break;
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
    Console.WriteLine("16 - Relação de instrutores");
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


  
  public static void ListarTurmas() {
    Console.WriteLine("----- Lista de Turmas -----");
    List<Turma> ts = nturma.Listar();
    if (ts.Count() == 0) {
      Console.WriteLine("Nenhuma turma cadastrada");
      return;
    }
    foreach(Turma t in ts) Console.WriteLine(t);
    Console.WriteLine();  
  }
  public static void InserirTurma() {
    Console.WriteLine("----- Cadastro de Turmas -----");
    
    Console.Write("Informe a descrição da Turma: ");
    string descricao = Console.ReadLine();
    ListarInstrutores();
    Console.Write("Informe o ID do instrutor para essa turma: ");
    int id = int.Parse(Console.ReadLine());
    Instrutor inst = ninstrutor.Listar(id);
    Turma t = new Turma {Descricao = descricao, Responsavel = inst};
    nturma.Inserir(t);
    
  }

  public static void AtualizarTurma() {
    Console.WriteLine("----- Atualização de Turma -----\n");
    ListarTurmas();
    Console.Write("Informe o Id da turma que sera atualizada: ");
    int id = int.Parse(Console.ReadLine()); 
    Console.Write("Informe a nova descrição: ");
    string descricao = Console.ReadLine();
    ListarInstrutores();
    Console.Write("Informe o ID do instrutor para essa turma: ");
    int idinst = int.Parse(Console.ReadLine());
    Instrutor inst = ninstrutor.Listar(idinst);
    Turma t = new Turma {Id = id, Descricao = descricao, Responsavel = inst};
    nturma.Atualizar(t);
    
    
  }

  public static void ExcluirTurma() {
    Console.WriteLine("----- Exclusão de Turmas -----");
    ListarTurmas();
    Console.Write("Informe o Id da turma que será excluida: ");
    int id = int.Parse(Console.ReadLine());

    Turma t = nturma.Listar(id);
    nturma.Excluir(t);
    
    
  }


  public static void ListarAlunos() {
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
    Aluno a = new Aluno {Id = id, Nome = nome, Turma = aln.Turma, Pacote = aln.Pacote};
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
    ListarTurmas();
    Console.Write("Informe o código da turma para esse aluno: ");
    int idturma = int.Parse(Console.ReadLine());
    
    Turma t = nturma.Listar(idturma);    
    Aluno a = new Aluno {Id = aln.Id, Nome = aln.Nome, Turma = t, Pacote = aln.Pacote};
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
        
    Aluno a = new Aluno {Id = aln.Id, Nome = aln.Nome, Turma = aln.Turma, Pacote = p};
    naluno.Atualizar(a);
  }

  public static void ListarPac() {
    Console.WriteLine("----- Pacotes Cadastrados -----");
    List<Pacote> pacs = npacote.Listar();
    if (pacs.Count() == 0) {
      Console.WriteLine("Nenhum pacote foi cadastrado no sistema");
      return;
    }
    foreach(Pacote p in pacs) Console.WriteLine(p);
    Console.WriteLine();  
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

  public static void ListarAdesoesPac() {
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

  public static void ListarInstrutores() {
    Console.WriteLine("----- Relação de Instrutores ----- ");
    List<Instrutor> insts = ninstrutor.Listar();
    List<Turma> turmas_syst = new List<Turma>();
    turmas_syst = nturma.Listar();
    Instrutor escolha;
    int qtd = 0;
    
    if (insts.Count() == 0) {
      Console.WriteLine("Nenhum instrutor foi cadastrado ainda");
      return;
    }

    Instrutor inst;
    foreach(Instrutor a in insts){ 
      qtd = qtd + 1;
      Console.WriteLine($"\n{qtd}º Instrutor: \n{a.ToString()}");
      Console.WriteLine($" \nTurmas atribuídas ao instrutor(a) {a.Nome}:");
      inst = ninstrutor.Listar(a.Id);
      foreach(Turma t in turmas_syst) if(t.Responsavel == inst) Console.WriteLine($"Turma: {t.Descricao} / Quantidade de alunos: {t.alunos.Count()}");
      }
  }
  public static void CadastrarInstrutor() {
    Console.WriteLine("----- Cadastro de Instrutores -----");
    
    Console.Write("Informe o nome do Instrutor: ");
    string nome = Console.ReadLine();
    Console.Write("Formação profissional: ");
    string form = Console.ReadLine();    
    Instrutor inst = new Instrutor {Nome = nome, Formacao = form};
    
    ninstrutor.Inserir(inst);
  }

  public static void VerificarDadosInst() {
    Console.WriteLine("----- Informe a Matrícula do Instrutor para verificação: -----\n");
    ListarInstrutores();
    Console.Write("Matrícula: ");
    int id = int.Parse(Console.ReadLine());
    Instrutor inst = ninstrutor.Listar(id);
    Console.WriteLine();
    Console.WriteLine("----- Dados referentes a essa Matrícula: -----\n");
    Console.WriteLine(ninstrutor.Listar(id));
    Console.WriteLine();
    Console.WriteLine("------Turmas atribuidas a esse instrutor ----- \n");
    List<Turma> turmas_syst = new List<Turma>();
    turmas_syst = nturma.Listar();
    foreach(Turma tm in turmas_syst) 
      if(tm.Responsavel == inst) Console.WriteLine(tm);
      else Console.WriteLine("  - Esse instrutor não possui turmas atribuídas a ele -      ");
  }

  public static void ExcluirCadastroInst() {
    Console.WriteLine("----- Excluir Cadastro -----");
    ListarInstrutores();
    Console.Write("Informe a matrícula do instrutor que será excluido: ");
    int id = int.Parse(Console.ReadLine());
    Instrutor inst = ninstrutor.Listar(id);
    ninstrutor.Excluir(inst);
    List<Turma> tms = new List<Turma>();
    tms = nturma.Listar();
    foreach(Turma t in tms)
      if(t.Responsavel == inst) t.Responsavel = null; 

  }

  public static void AtualizarCadastroInst() {
    Console.WriteLine("----- Atualização de Cadastro -----");
    ListarInstrutores();
    Console.Write("Informe a matrícula do instrutor que será atualizado: ");
    int id = int.Parse(Console.ReadLine());
    Console.Write("Informe o nome do instrutor: ");
    string nome = Console.ReadLine();
    Console.Write("Formação profissional: ");
    string form = Console.ReadLine();

    Instrutor inst = new Instrutor {Id = id, Nome = nome, Formacao = form};
    
    ninstrutor.Atualizar(inst);
  }

  public static void ExcluirTurmaDoInst() {
    Console.WriteLine("----- Selecionar Instrutor -----");
    ListarInstrutores();
    Console.Write("Informe o ID do instrutor: ");
    int id = int.Parse(Console.ReadLine());
    ListarTurmas();
    Console.Write("Informe o ID da turma que será excluída: ");
    int idturma = int.Parse(Console.ReadLine());
    Turma t = nturma.Listar(idturma);
    Instrutor inst = ninstrutor.Listar(id);
    t.Responsavel = null;
    
  }

  public static void ListarTurmaDeInstrutor() {
    Console.WriteLine("----- Listar as turmas de um instrutor----------");
    ListarInstrutores();
    Console.WriteLine("Digite o ID do instrutor para a listagem: ");
    int id = int.Parse(Console.ReadLine());
    Instrutor inst = ninstrutor.Listar(id);
    List<Turma> turmas_syst = new List<Turma>();
    turmas_syst = nturma.Listar();
    foreach(Turma tm in turmas_syst) 
      if(tm.Responsavel == inst) Console.WriteLine(tm);


    }
  


}