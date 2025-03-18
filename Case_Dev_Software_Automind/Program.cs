using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

// Lista para armazenar usuarios
List<Usuario> usuarios = new();

// Loop principal
while (true)
{
    //Menu
    Console.WriteLine("1 - Cadastrar Usuário");
    Console.WriteLine("2 - Listar Usuários");
    Console.WriteLine("3 - Buscar Usuário");
    Console.WriteLine("4 - Sair");
    Console.Write("Escolha uma opção: ");

    // Leitura da opção escolhida
    switch (Console.ReadLine())
    {
        case "1":
            CadastrarUsuario();
            break;
        case "2":
            ListarUsuarios();
            break;
        case "3":
            BuscarUsuario();
            break;
        case "4":
            Console.WriteLine("Programa encerrado.");
            return;
        default:
            Console.WriteLine("Opção inválida!\n");
            break;
    }
}
// Função para cadastrar novo usuario
void CadastrarUsuario()
{
    Console.Write("Digite o nome: ");
    string nome = Console.ReadLine();

    // Validação do nome
    if (string.IsNullOrWhiteSpace(nome) || !nome.All(c => char.IsLetter(c) || char.IsWhiteSpace(c)))
    {
        Console.WriteLine("Nome inválido! Use apenas letras e espaços.\n");
        return;
    }

    Console.Write("Digite o e-mail: ");
    string email = Console.ReadLine();

    // Validação do e-mail
    if (!ValidarEmail(email))
    {
        Console.WriteLine("E-mail inválido!\n");
        return;
    }

    Console.Write("Digite a idade: ");
    string idadeInput = Console.ReadLine();

    // Validação da idade
    if (!int.TryParse(idadeInput, out int idade) || idade < 0 || idade > 120)
    {
        Console.WriteLine("Idade inválida! Deve ser um número entre 0 e 120.\n");
        return;
    }

    // Adiciona o usuário se todas as validações passarem
    usuarios.Add(new Usuario(nome, email, idade));
    Console.WriteLine("Usuário cadastrado com sucesso!\n");
}
// Função para listar todos os usuarios cadastrados
void ListarUsuarios()
{
    // Verifica se a usuarios cadastrados
    if (usuarios.Count == 0)
    {
        Console.WriteLine("Nenhum usuário cadastrado.\n");
        return;
    }

    Console.WriteLine("Usuários cadastrados:");
    foreach (var usuario in usuarios)
    {
        Console.WriteLine(usuario);
    }
    Console.WriteLine();
}
// Função para buscar um usuario pelo nome
void BuscarUsuario()
{
    Console.Write("Digite o nome do usuário a ser buscado: ");
    string nomeBusca = Console.ReadLine().ToLower();
    
    // Buscar usuario na lista, ignorando maiusculas/minusculas
    var usuario = usuarios.FirstOrDefault(u => u.Nome.ToLower() == nomeBusca);

    // Verifica se o usuario foi encontrado 
    if (usuario != null)
    {
        Console.WriteLine("Usuário encontrado:");
        Console.WriteLine(usuario);
    }
    else
    {
        Console.WriteLine("Usuário não encontrado.");
    }
    Console.WriteLine();
}

// Função para validar o formato do e-mail
bool ValidarEmail(string email)
{
    try
    {
        var addr = new System.Net.Mail.MailAddress(email);
        return addr.Address == email;
    }
    catch
    {
        return false;
    }
}

// Classe que representa o usuario 
class Usuario
{
    public string Nome { get; }
    public string Email { get; }
    public int Idade { get; }

    public Usuario(string nome, string email, int idade)
    {
        Nome = nome;
        Email = email;
        Idade = idade;
    }
 
    // Sobrescreve o método ToString para exibir os dados do usuário
    public override string ToString() => $"Nome: {Nome}, Email: {Email}, Idade: {Idade}";
}
