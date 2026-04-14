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

    public Fabricante?[] SelecionarTodos()
    {
        return fabricantes;
    }
}
