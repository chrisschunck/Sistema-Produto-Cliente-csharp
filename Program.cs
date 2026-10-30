public class Program
{
    private static readonly ProdutoService ProdutoService =
        new(new ProdutoRepository());

    private static readonly ClienteService ClienteService =
        new(new ClienteRepository());

    public static void Main(string[] args)
    {
        while (true)
        {
            Console.WriteLine("===== Menu principal =====");
            Console.WriteLine("1. Menu Produto");
            Console.WriteLine("2. Menu Cliente");
            Console.WriteLine("0. Sair");
            Console.Write("Escolha uma opção: ");

            switch (Console.ReadLine())
            {
                case "1":
                    MostrarMenuProduto();
                    break;
                case "2":
                    MostrarMenuCliente();
                    break;
                case "0":
                    return;
                default:
                    Console.WriteLine("Opção inválida.");
                    break;
            }
        }
    }

    private static void MostrarMenuProduto()
    {
        Console.WriteLine("===== Menu Produto =====");
        Console.WriteLine("1. Adicionar Produto");
        Console.WriteLine("2. Atualizar Produto");
        Console.WriteLine("3. Deletar Produto");
        Console.WriteLine("4. Obter Produto por ID");
        Console.WriteLine("5. Obter Todos os Produtos");
        Console.Write("Escolha uma opção: ");


            switch (Console.ReadLine())
            {
                case "1":
                    AdicionarProduto();
                    break;
                case "2":
                    AtualizarProduto();
                    break;
                case "3":
                    DeletarProduto();
                    break;
                case "4":
                    ObterProdutoPorId();
                    break;
                case "5":
                    ObterTodosOsProdutos();
                    break;
                default:
                    Console.WriteLine("Opção inválida.");
                    break;
            }
        }
        

    private static void MostrarMenuCliente()
    {
        Console.WriteLine("===== Menu Cliente =====");
        Console.WriteLine("1. Adicionar Cliente");
        Console.WriteLine("2. Atualizar Cliente");
        Console.WriteLine("3. Deletar Cliente");
        Console.WriteLine("4. Obter Cliente por ID");
        Console.WriteLine("5. Obter Todos os Clientes");
        Console.Write("Escolha uma opção: ");

        switch (Console.ReadLine())
        {
            case "1":
                AdicionarCliente();
                break;
            case "2":
                AtualizarCliente();
                break;
            case "3":
                DeletarCliente();
                break;
            case "4":
                ObterClientePorId();
                break;
            case "5":
                ObterTodosOsClientes();
                break;
            default:
                Console.WriteLine("Opção inválida.");
                break;
        }
    }

    private static void AdicionarProduto()
    {
        var produto = new Produto
        {
            id = LerLong("ID: "),
            nome = LerTexto("Nome: "),
            descricao = LerTexto("Descrição: "),
            preco = LerDecimal("Preço: "),
            quantidade = LerInt("Quantidade: ")
        };

        ProdutoService.AdicionarProduto(produto);
        Console.WriteLine("Produto adicionado com sucesso!");
    }

    private static void AtualizarProduto()
    {
        var produto = new Produto
        {
            id = LerLong("ID do Produto: "),
            nome = LerTexto("Novo Nome: "),
            descricao = LerTexto("Nova Descrição: "),
            preco = LerDecimal("Novo Preço: "),
            quantidade = LerInt("Nova Quantidade: ")
        };

        ProdutoService.AtualizarProdutoPorId(produto);
        Console.WriteLine("Produto atualizado com sucesso!");
    }

    private static void DeletarProduto()
    {
        ProdutoService.DeletarProdutoPorId(LerLong("ID do Produto: "));
        Console.WriteLine("Produto deletado com sucesso!");
    }

    private static void ObterProdutoPorId()
    {
        var produto = ProdutoService.ObterProdutoPorId(LerLong("ID do Produto: "));
        if (produto is null)
        {
            Console.WriteLine("Produto não encontrado.");
            return;
        }

        Console.WriteLine($"ID: {produto.id}, Nome: {produto.nome}, Descrição: {produto.descricao}, Preço: {produto.preco}, Quantidade: {produto.quantidade}");
    }

    private static void ObterTodosOsProdutos()
    {
        foreach (var produto in ProdutoService.ObterTodosProdutos())
        {
            Console.WriteLine($"ID: {produto.id}, Nome: {produto.nome}, Descrição: {produto.descricao}, Preço: {produto.preco}, Quantidade: {produto.quantidade}");
        }
    }

    private static void AdicionarCliente()
    {
        var cliente = new Cliente
        {
            id = LerLong("ID: "),
            Nome = LerTexto("Nome: "),
            Email = LerTexto("Email: "),
            Telefone = LerTexto("Telefone: "),
            Endereco = LerTexto("Endereço: "),
            Cpf = LerTexto("CPF: ")
        };

        ClienteService.AdicionarCliente(cliente);
        Console.WriteLine("Cliente adicionado com sucesso!");
    }

    private static void AtualizarCliente()
    {
        var cliente = new Cliente
        {
            id = LerLong("ID do Cliente: "),
            Nome = LerTexto("Novo Nome: "),
            Email = LerTexto("Novo Email: "),
            Telefone = LerTexto("Novo Telefone: "),
            Endereco = LerTexto("Novo Endereço: "),
            Cpf = LerTexto("Novo CPF: ")
        };

        ClienteService.AtualizarClientePorId(cliente);
        Console.WriteLine("Cliente atualizado com sucesso!");
    }

    private static void DeletarCliente()
    {
        ClienteService.DeletarClientePorId(LerLong("ID do Cliente: "));
        Console.WriteLine("Cliente deletado com sucesso!");
    }

    private static void ObterClientePorId()
    {
        var cliente = ClienteService.ObterClientePorId(LerLong("ID do Cliente: "));
        if (cliente is null)
        {
            Console.WriteLine("Cliente não encontrado.");
            return;
        }

        Console.WriteLine($"ID: {cliente.id}, Nome: {cliente.Nome}, Email: {cliente.Email}, Telefone: {cliente.Telefone}, Endereço: {cliente.Endereco}, CPF: {cliente.Cpf}");
    }

    private static void ObterTodosOsClientes()
    {
        foreach (var cliente in ClienteService.ObterTodosClientes())
        {
            Console.WriteLine($"ID: {cliente.id}, Nome: {cliente.Nome}, Email: {cliente.Email}, Telefone: {cliente.Telefone}, Endereço: {cliente.Endereco}, CPF: {cliente.Cpf}");
        }
    }

    private static string LerTexto(string mensagem)
    {
        Console.Write(mensagem);
        return Console.ReadLine() ?? string.Empty;
    }

    private static long LerLong(string mensagem)
    {
        while (true)
        {
            if (long.TryParse(LerTexto(mensagem), out var valor))
                return valor;

            Console.WriteLine("Digite um número inteiro válido.");
        }
    }

    private static int LerInt(string mensagem)
    {
        while (true)
        {
            if (int.TryParse(LerTexto(mensagem), out var valor))
                return valor;

            Console.WriteLine("Digite um número inteiro válido.");
        }
    }

    private static decimal LerDecimal(string mensagem)
    {
        while (true)
        {
            if (decimal.TryParse(LerTexto(mensagem), out var valor))
                return valor;

            Console.WriteLine("Digite um valor decimal válido.");
        }
    }
}