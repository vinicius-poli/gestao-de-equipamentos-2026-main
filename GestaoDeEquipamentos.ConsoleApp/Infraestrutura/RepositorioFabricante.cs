using System;
using GestaoDeEquipamentos.ConsoleApp.Dominio;
using System.Security.Cryptography;

namespace GestaoDeEquipamentos.ConsoleApp.Infraestrutura;

public class RepositorioFabricante
{
    public Fabricante?[] fabricantes = new Fabricante[100];

    public void Cadastrar(Fabricante novoFabricante)
    {
        novoFabricante.id = Convert.ToHexString(RandomNumberGenerator.GetBytes(20)).ToLower().Substring(0, 7); // 0-255

        for (int i = 0; i < fabricantes.Length; i++)
        {
            Fabricante? f = fabricantes[i];

            if (f == null)
            {
                fabricantes[i]= novoFabricante;
                break;
            }
        }
    }

    public bool Editar(string idSelecionado, Fabricante novoFabricante)
    {
        Fabricante? fabricanteSelecionado = SelecionarPorId(idSelecionado);

        if (fabricanteSelecionado == null)
            return false;

        fabricanteSelecionado.nome = novoFabricante.nome;
        fabricanteSelecionado.email = novoFabricante.email;
        fabricanteSelecionado.telefone = novoFabricante.telefone;        

        return true;
    }

    public Fabricante? SelecionarPorId(string idSelecionado)
    {
        Fabricante? fabricanteSelecionado = null;

        for (int i = 0; i < fabricantes.Length; i++)
        {
            Fabricante? f = fabricantes[i];

            if (f == null)
                continue;
            
            if (f.id == idSelecionado)
            {
                fabricanteSelecionado = f;
                break;
            }
        }

        return fabricanteSelecionado;
    }

    public Fabricante?[] SelecionarTodos()
    {
        return fabricantes;
    }
}
