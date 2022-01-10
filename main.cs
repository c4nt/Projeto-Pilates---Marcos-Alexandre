using System;

class MainClass {
  private static Nturma nturma = new Nturma();
  private static Naluno naluno = new Naluno();
  public static void Main() {
    int op = 0;
    Console.WriteLine ("----- Aplicativo Gestão Pilates ------");
    do {
      try {
        op = Menu();
        switch(op) {
          case 1 : ListarTurmas(); break;
          case 2 : InserirTurma(); break;
          case 3 : AtualizarTurma(); break;
          case 4 : ExcluirTurma(); break;
          case 5 : ListarAlunos(); break;
          case 6 : CadastrarAluno(); break;
          case 7 : AtualizarCadastro(); break;
          case 8 : VerificarDados(); break;
          case 9 : ExcluirCadastro(); break;
        }
      }
      catch (Exception erro) {
        Console.WriteLine(erro.Message);
        op = 100;
      }
    } while (op != 0);
    Console.WriteLine ("----- Programa Encerrado ------------");    
  }
  public static int Menu() {
    Console.WriteLine();
    Console.WriteLine("----- Opções do Aluno-----------------");
    Console.WriteLine("6 - Cadastrar-se no Sistema");
    Console.WriteLine("8 - Verificar dados do cadastro");
    Console.WriteLine("9 - Excluir Cadastro");
    Console.WriteLine("0 - Encerrar Programa");
    
    Console.WriteLine("-------------------------------------\n");
    Console.WriteLine("----- Opções do Instrutor-------------");
    Console.WriteLine("1 - Listar Turmas");
    Console.WriteLine("2 - Criar uma Turma");
    Console.WriteLine("3 - Atualizar Turma");
    Console.WriteLine("4 - Excluir uma Turma");
    Console.WriteLine("5 - Relação de Alunos");
    Console.WriteLine("7 - Atualizar Cadastro");
    Console.WriteLine("0 - Encerrar Programa");
    Console.WriteLine("-------------------------------------");
    Console.Write("Informe uma opção: ");
    int op = int.Parse(Console.ReadLine());
    Console.WriteLine("\n-------------------------------------");
    return op; 
  }
  public static void ListarTurmas() {
    Console.WriteLine("----- Lista de Turmas -----");
    Turma[] ts = nturma.Listar();
    if (ts.Length == 0) {
      Console.WriteLine("Nenhuma turma cadastrada");
      return;
    }
    foreach(Turma t in ts) Console.WriteLine(t);
    Console.WriteLine();  
  }
  public static void InserirTurma() {
    Console.WriteLine("----- Cadastro de Turmas -----");
    Console.Write("Informe o Id da turma: ");
    int id = int.Parse(Console.ReadLine());
    Console.Write("Informe a descrição da Turma: ");
    string descricao = Console.ReadLine();

    Turma t = new Turma(id, descricao);

    nturma.Inserir(t);
  }

  public static void AtualizarTurma() {
    Console.WriteLine("----- Atualização de Turma -----\n");
    ListarTurmas();
    Console.Write("Id da categoria que sera atualizada: ");
    int id = int.Parse(Console.ReadLine());
    Console.Write("Informe a nova descrição: ");
    string descricao = Console.ReadLine();

    Turma t = new Turma(id, descricao);

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
    Aluno[] als = naluno.Listar();
    if (als.Length == 0) {
      Console.WriteLine("Nenhum aluno foi cadastrado ainda");
      return;
    }
    foreach(Aluno a in als) Console.WriteLine(a);
    Console.WriteLine();  
  }
  public static void CadastrarAluno() {
    Console.WriteLine("----- Cadastro de Alunos -----");
    Console.Write("Defina uma matrícula para o aluno: ");
    int id = int.Parse(Console.ReadLine());
    Console.Write("Informe o nome do aluno: ");
    string nome = Console.ReadLine();
    Console.Write("Informe a quantidade de aulas por semana: ");
    int vezessemana = int.Parse(Console.ReadLine());
    Console.Write("Informe o valor da mensalidade: ");
    double mensalidade = double.Parse(Console.ReadLine());
    ListarTurmas();
    Console.Write("Informe o código da turma para esse aluno: ");
    int idturma = int.Parse(Console.ReadLine());

    Turma t = nturma.Listar(idturma);    

    Aluno a = new Aluno(id, nome, vezessemana, mensalidade, t);

    naluno.Inserir(a);
  }

  public static void VerificarDados() {
    Console.WriteLine("----- Informe sua Matrícula: -----");
    int id = int.Parse(Console.ReadLine());
    Console.WriteLine("----- Informações dessa Matrícula: -----");
    Console.WriteLine(naluno.Listar(id));

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
    Console.Write("Informe o nome do aluno: ");
    string nome = Console.ReadLine();
    Console.Write("Informe a quantidade de aulas por semana: ");
    int vezessemana = int.Parse(Console.ReadLine());
    Console.Write("Informe o valor da mensalidade: ");
    double mensalidade = double.Parse(Console.ReadLine());
    ListarTurmas();
    Console.Write("Informe o código da turma para esse aluno: ");
    int idturma = int.Parse(Console.ReadLine());
    Turma t = nturma.Listar(idturma);    
    Aluno a = new Aluno(id, nome, vezessemana, mensalidade, t);
    // Atualiza o produto
    naluno.Atualizar(a);
  }


}