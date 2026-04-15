using System;

/*1. Controle de Equipamentos
Requisito 1.1: Como funcionário, Junior quer ter a possibilidade de registrar equipamentos
• Deve ter identificador único (id)
• Deve ter um nome com no mínimo 3 caracteres;
• Deve ter um preço de aquisição;
• Deve ter uma fabricante;
• Deve ter uma data de fabricação;*/

namespace GestaoDeEquipamentos.ConsoleApp.Dominio;

public class Fabricante
{
    public string id;
    public string nome;
    public string? email;
    public string? telefone;
    public int numeroEquipamentos;
}
