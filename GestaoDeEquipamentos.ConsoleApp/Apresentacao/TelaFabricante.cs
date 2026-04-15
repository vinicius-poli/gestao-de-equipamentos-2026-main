using System;
using GestaoDeEquipamentos.ConsoleApp.Dominio;
using GestaoDeEquipamentos.ConsoleApp.Infraestrutura;
namespace GestaoDeEquipamentos.ConsoleApp.Apresentacao;

public class TelaFabricante
{
    public RepositorioChamado repositorioChamado;
    public RepositorioEquipamento repositorioEquipamento;
    public RepositorioFabricante repositorioFabricante;
    public string? ObterEscolhaMenuPrincipal()
    {
        Console.Clear();
        Console.WriteLine("---------------------------------");
        Console.WriteLine("Gestão de Fabricantes");
        Console.WriteLine("---------------------------------");
        Console.WriteLine("1 - Cadastrar fabricante");
        Console.WriteLine("2 - Editar fabricante");
        Console.WriteLine("3 - Excluir fabricante");
        Console.WriteLine("4 - Visualizar fabricantes");
        Console.WriteLine("S - Sair");
        Console.WriteLine("---------------------------------");
        Console.Write("> ");
        string? opcaoMenu = Console.ReadLine()?.ToUpper();

        return opcaoMenu;
    }

    public void Cadastrar()
    {
        ExibirCabecalho("Cadastro de Fabricante");

        Fabricante novoFabricante = new Fabricante();

        do
        {
            Console.WriteLine("Digite o nome do fabricante: ");
            novoFabricante.nome = Console.ReadLine();

            if (!string.IsNullOrWhiteSpace(novoFabricante.nome) && novoFabricante.nome.Length >= 2)
            {
                break;
            }            
        } while (true);

        Console.WriteLine("Digite o email do fabricante: ");
        novoFabricante.email = Console.ReadLine();

        Console.WriteLine("Digite o número de telefone do fabricante: ");
        novoFabricante.telefone = Console.ReadLine();

        repositorioFabricante.Cadastrar(novoFabricante);

        Console.WriteLine("---------------------------------");
        Console.WriteLine($"O registro \"{novoFabricante.nome}\" foi cadastrado com sucesso!");
        Console.WriteLine("---------------------------------");
        Console.WriteLine("Digite ENTER para continuar...");
        Console.ReadLine();
    }

    public void Editar()
    {
        ExibirCabecalho("Edição de Fabricante");

        Visualizar(deveExibirCabecalho: false);

        Console.WriteLine("---------------------------------");
        
        string? idSelecionado;        

        do
        {
            Console.WriteLine("Digite o id do fabricante que deseja editar: ");
            idSelecionado = Console.ReadLine();

            if (!string.IsNullOrWhiteSpace(idSelecionado) && idSelecionado.Length == 7)
                break;
        } while (true);

        Fabricante? novoFabricante = ObterDadosCadastrais();

        if (novoFabricante == null)
        {
            Console.WriteLine("---------------------------------");
            Console.WriteLine($"Não foi possível obter os dados do registro!");
            Console.WriteLine("---------------------------------");
            Console.WriteLine("Digite ENTER para continuar...");
            Console.ReadLine();
            return;
        }        

        bool conseguiuEditar = repositorioFabricante.Editar(idSelecionado, novoFabricante);

        if (!conseguiuEditar)
        {
            Console.WriteLine("---------------------------------");
            Console.WriteLine($"Não foi possível encontrar o registro informado!");
            Console.WriteLine("---------------------------------");
            Console.WriteLine("Digite ENTER para continuar...");
            Console.ReadLine();
            return;
        } 

        Console.WriteLine("---------------------------------");
        Console.WriteLine($"O registro \"{idSelecionado}\" foi editado com sucesso!");
        Console.WriteLine("---------------------------------");
        Console.WriteLine("Digite ENTER para continuar...");
        Console.ReadLine();       
    }
    public void Excluir()
    {
        ExibirCabecalho("Exclusão de Fabricante");

        Visualizar(deveExibirCabecalho: false);

        Console.WriteLine("---------------------------------");
        
        string? idSelecionado;        

        do
        {
            Console.WriteLine("Digite o id do fabricante que deseja excluir: ");
            idSelecionado = Console.ReadLine();

            if (!string.IsNullOrWhiteSpace(idSelecionado) && idSelecionado.Length == 7)
                break;
        } while (true);     

        bool conseguiuExcluir = repositorioFabricante.Excluir(idSelecionado);  

        if (!conseguiuExcluir)
        {
            Console.WriteLine("---------------------------------");
            Console.WriteLine($"Não foi possível encontrar o registro informado!");
            Console.WriteLine("---------------------------------");
            Console.WriteLine("Digite ENTER para continuar...");
            Console.ReadLine();
            return;
        }

        Console.WriteLine("---------------------------------");
        Console.WriteLine($"O registro \"{idSelecionado}\" foi excluído com sucesso!");
        Console.WriteLine("---------------------------------");
        Console.WriteLine("Digite ENTER para continuar...");
        Console.ReadLine();       
    }
    public void Visualizar(bool deveExibirCabecalho)
    {
        if (deveExibirCabecalho)
            ExibirCabecalho("Visualização de Fabricantes");
               
        
        Console.WriteLine(
            "{0, -7} |  {1, -30} | {2,-15} | {3, -22}",
            "id", "Nome", "Email", "Telefone"
            );

        Fabricante?[] fabricantes = repositorioFabricante.SelecionarTodos();

        for (int i = 0; i < fabricantes.Length; i++)
        {
            Fabricante? f = fabricantes[i];

            if (f == null) // null guard/check
                continue;

            Console.WriteLine(
                "{0, -7} |  {1, -30} | {2,-15} | {3, -22}",
                f.id, f.nome, f.email, f.telefone);                       
        }

        if (deveExibirCabecalho)
        {
            Console.WriteLine("---------------------------------");
            Console.WriteLine("Digite ENTER para continuar...");
            Console.ReadLine();
        }               
    }
    public void ExibirCabecalho(string titulo)
    {
        Console.Clear();
        Console.WriteLine("---------------------------------");
        Console.WriteLine("Gestão de Fabricantes");
        Console.WriteLine("---------------------------------");
        Console.WriteLine(titulo);
        Console.WriteLine("---------------------------------");
    }

    public Fabricante? ObterDadosCadastrais()
    {
        Console.WriteLine(
            "{0, -7} |  {1, -30} | {2,-15} | {3, -22}",
            "id", "Nome", "Email", "Telefone"
        );

        Fabricante?[] fabricantes = repositorioFabricante.SelecionarTodos();

        for (int i = 0; i < fabricantes.Length; i++)
        {
            Fabricante? f = fabricantes[i];

            if (f == null) // null guard/check
                continue;

            Console.WriteLine(
                "{0, -7} |  {1, -30} | {2,-15} | {3, -22}",
                f.id, f.nome, f.email, f.telefone
            );                       
        }

        string? idSelecionado;

        Console.WriteLine("---------------------------------");

        do
        {
        Console.WriteLine("Digite o id do fabricante que deseja selecionar: ");
        idSelecionado = Console.ReadLine();

        if (!string.IsNullOrWhiteSpace(idSelecionado) && idSelecionado.Length == 7)
            break;
        } while (true);

        Fabricante? fabricanteSelecionado = repositorioFabricante.SelecionarPorId(idSelecionado);

        if (fabricanteSelecionado == null)
        {
            Console.WriteLine("---------------------------------");
            Console.WriteLine($"Não foi possível encontrar o fabricante selecionado!");
            Console.WriteLine("---------------------------------");
            Console.WriteLine("Digite ENTER para continuar...");
            Console.ReadLine();
            return null;
        }

        Fabricante novoFabricante = new Fabricante();
        
        do
        {
            Console.WriteLine("Digite o nome do fabricante: ");
            novoFabricante.nome = Console.ReadLine();

            if (!string.IsNullOrWhiteSpace(novoFabricante.nome) && novoFabricante.nome.Length >= 2)
            {
                break;
            }            
        } while (true); 

        Console.WriteLine("Digite o email do fabricante: ");
        novoFabricante.email = Console.ReadLine(); 
        
        Console.WriteLine("Digite o número de telefone do fabricante: ");
        novoFabricante.email = Console.ReadLine();         

        return novoFabricante;
    }
}
