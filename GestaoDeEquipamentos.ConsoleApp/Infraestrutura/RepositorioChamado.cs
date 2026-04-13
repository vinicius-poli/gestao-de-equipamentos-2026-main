using System;
using GestaoDeEquipamentos.ConsoleApp.Dominio;
using System.Security.Cryptography;

namespace GestaoDeEquipamentos.ConsoleApp.Infraestrutura;

public class RepositorioChamado
{
    public Chamado?[] chamados = new Chamado[100];

    public void Cadastrar(Chamado novoChamado)
    {
        novoChamado.id = Convert.ToHexString(RandomNumberGenerator.GetBytes(20)).ToLower().Substring(0, 7); // 0-255

        for (int i = 0; i < chamados.Length; i++)
        {
            Chamado? c = chamados[i];

            if (c == null)
            {
                chamados[i]= novoChamado;
                break;
            }
        }
    }

    public Chamado?[] SelecionarTodos()
    {
        return chamados;
    }
}