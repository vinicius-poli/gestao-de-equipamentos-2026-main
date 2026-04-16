using System.Security.Cryptography;
using GestaoDeEquipamentos.ConsoleApp.Apresentacao;
using GestaoDeEquipamentos.ConsoleApp.Dominio;
using GestaoDeEquipamentos.ConsoleApp.Infraestrutura;

RepositorioEquipamento repositorioEquipamento = new RepositorioEquipamento();
RepositorioChamado repositorioChamado = new RepositorioChamado();
RepositorioFabricante repositorioFabricante = new RepositorioFabricante();

repositorioEquipamento.repositorioFabricante = repositorioFabricante;

TelaEquipamento telaEquipamento = new TelaEquipamento();
telaEquipamento.repositorioEquipamento = repositorioEquipamento;
telaEquipamento.repositorioFabricante = repositorioFabricante;

TelaChamado telaChamado = new TelaChamado();
telaChamado.repositorioChamado = repositorioChamado;
telaChamado.repositorioEquipamento = repositorioEquipamento;

TelaFabricante telaFabricante = new TelaFabricante();
telaFabricante.repositorioFabricante = repositorioFabricante;
telaFabricante.repositorioChamado = repositorioChamado;
telaFabricante.repositorioEquipamento = repositorioEquipamento;

while (true)
{    
    Console.Clear();
    Console.WriteLine("---------------------------------");
    Console.WriteLine("Gestão de Equipamentos");
    Console.WriteLine("---------------------------------");
    Console.WriteLine("1 - Gerenciar equipamento");
    Console.WriteLine("2 - Gerenciar chamados");    
    Console.WriteLine("3 - Gerenciar fabricantes");    
    Console.WriteLine("S - Sair");
    Console.WriteLine("---------------------------------");
    Console.Write("> ");
    string? opcaoMenuPrincipal = Console.ReadLine()?.ToUpper();    
    
    if (opcaoMenuPrincipal == "S")
    {
        Console.Clear();
        break;
    }

    while (true)
    {
        if (opcaoMenuPrincipal == "1")
        {
            string? opcaoMenu = telaEquipamento.ObterEscolhaMenuPrincipal();

            if (opcaoMenu == "S")
            {
                Console.Clear();
                break;
            }

            if (opcaoMenu == "1")
                telaEquipamento.Cadastrar();    

            else if (opcaoMenu == "2")
                telaEquipamento.Editar();
            
            else if (opcaoMenu == "3")
                telaEquipamento.Excluir();

            else if (opcaoMenu == "4")
                telaEquipamento.Visualizar();
        }

        else if (opcaoMenuPrincipal == "2")
        {
            string? opcaoMenu = telaChamado.ObterEscolhaMenuPrincipal();

            if (opcaoMenu == "S")
            {
                Console.Clear();
                break;
            }

            if (opcaoMenu == "1")
                telaChamado.Cadastrar();    

            else if (opcaoMenu == "2")
                telaChamado.Editar();
            
            else if (opcaoMenu == "3")
                telaChamado.Excluir();

            else if (opcaoMenu == "4")
                telaChamado.Visualizar(deveExibirCabecalho: true);
        }

        else if (opcaoMenuPrincipal == "3")
        {
            string? opcaoMenu = telaFabricante.ObterEscolhaMenuPrincipal();

            if (opcaoMenu == "S")
            {
                Console.Clear();
                break;
            }

            if (opcaoMenu == "1")
                telaFabricante.Cadastrar();    

            else if (opcaoMenu == "2")
                telaFabricante.Editar();
            
            else if (opcaoMenu == "3")
                telaFabricante.Excluir();

            else if (opcaoMenu == "4")
                telaFabricante.Visualizar(deveExibirCabecalho: true);
        }
    }    
}    
