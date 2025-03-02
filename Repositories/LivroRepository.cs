using System.Globalization;
using API_Livraria.Models;

namespace API_Livraria.Repositories;

public class LivroRepository
{
    private readonly string _filePath = "Data\\livros.csv"; // Caminho do arquivo CSV

    public LivroRepository()
    {
        // Se o arquivo não existir, cria com cabeçalho
        if (!File.Exists(_filePath))
        {
            File.WriteAllText(_filePath, "Id,Titulo,Autor,Genero,Preco,Estoque\n");
        }
    }


    // Método para ler todos os livros do CSV
    public List<Livro> GetAll()
    {
        var livros = new List<Livro>();

        try
        {
            using (var reader = new StreamReader(_filePath))
            {
                // Ignora o cabeçalho
                reader.ReadLine();

                // Lê as linhas do arquivo uma por uma
                while (!reader.EndOfStream)
                {
                    var linha = reader.ReadLine();
                    var colunas = linha.Split(',');

                    // Tenta parsear os dados de forma segura
                    if (int.TryParse(colunas[0].Trim(), out int id) &&
                        decimal.TryParse(colunas[4].Trim(), NumberStyles.Any, CultureInfo.InvariantCulture, out decimal preco) &&
                        int.TryParse(colunas[5].Trim(), out int estoque))
                    {
                        var livro = new Livro
                        {
                            Id = id,
                            Titulo = colunas[1].Trim(),
                            Autor = colunas[2].Trim(),
                            Genero = colunas[3].Trim(),
                            Preco = preco,
                            Estoque = estoque
                        };

                        livros.Add(livro);
                    }
                    else
                    {
                        // Se algum campo não for parseável, você pode decidir o que fazer (logar erro, ignorar linha, etc.)
                        Console.WriteLine($"Linha inválida ignorada: {linha}");
                    }
                }
            }
        }
        catch (Exception ex)
        {
            // Tratar exceções, como erro ao acessar o arquivo
            Console.WriteLine($"Erro ao ler o arquivo: {ex.Message}");
        }

        return livros;
    }

    public Livro? GetById(int id)
    {
        return GetAll().FirstOrDefault(l => l.Id == id);
    }

    // Método para adicionar um livro ao CSV
    public void Add(Livro livro)
    {
        // Obtém a lista de livros com o cache
        var livros = GetAll();

        // Se não houver livros, o primeiro ID será 1, senão pega o maior ID + 1
        livro.Id = livros.Any() ? livros.Max(l => l.Id) + 1 : 1;

        // Garantir que o preço tenha o formato correto
        var precoFormatado = livro.Preco.ToString("F2", CultureInfo.InvariantCulture); // Usando ponto como separador decimal

        // Escapando vírgulas e quebras de linha nos campos de texto
        var tituloEscapado = livro.Titulo.Replace(",", "\\,").Replace("\n", "\\n");
        var autorEscapado = livro.Autor.Replace(",", "\\,").Replace("\n", "\\n");
        var generoEscapado = livro.Genero.Replace(",", "\\,").Replace("\n", "\\n");

        // Formatar linha para CSV
        var linha = $"{livro.Id},{tituloEscapado},{autorEscapado},{generoEscapado},{precoFormatado},{livro.Estoque}\n";

        // Adiciona ao final do arquivo CSV
        File.AppendAllText(_filePath, linha);
    }
    public void Update(Livro livroAtualizado)
    {
        var livros = GetAll(); // Obtém todos os livros
        var livroIndex = livros.FindIndex(l => l.Id == livroAtualizado.Id);

        if (livroIndex == -1)
        {
            Console.WriteLine("Livro não encontrado.");
            return; // Sai do método se o livro não existir
        }

        // Atualiza os dados do livro (não altera o Id)
        var livro = livros[livroIndex];
        livro.Titulo = livroAtualizado.Titulo;
        livro.Autor = livroAtualizado.Autor;
        livro.Genero = livroAtualizado.Genero;
        livro.Preco = livroAtualizado.Preco;
        livro.Estoque = livroAtualizado.Estoque;

        // Garantir que o preço tenha o formato correto
        var precoFormatado = livro.Preco.ToString("F2", CultureInfo.InvariantCulture); // Usando ponto como separador decimal

        // Escapando vírgulas e quebras de linha nos campos de texto
        var tituloEscapado = livro.Titulo.Replace(",", "\\,").Replace("\n", "\\n");
        var autorEscapado = livro.Autor.Replace(",", "\\,").Replace("\n", "\\n");
        var generoEscapado = livro.Genero.Replace(",", "\\,").Replace("\n", "\\n");

        // Atualizando a linha do livro no CSV
        var linhas = livros.Select(l =>
            l.Id == livroAtualizado.Id
                ? $"{l.Id},{tituloEscapado},{autorEscapado},{generoEscapado},{precoFormatado},{l.Estoque}" // Atualiza o livro específico
                : $"{l.Id},{l.Titulo},{l.Autor},{l.Genero},{l.Preco:F2},{l.Estoque}") // Deixa os outros livros inalterados
            .ToList();

        // Preservando o cabeçalho
        linhas.Insert(0, "Id,Titulo,Autor,Genero,Preco,Estoque");

        // Reescreve o arquivo CSV com as linhas atualizadas, incluindo o cabeçalho
        File.WriteAllLines(_filePath, linhas);
    }


    public void Delete(int id)
    {
        var livros = GetAll(); // Obtém todos os livros
        var livroIndex = livros.FindIndex(l => l.Id == id);

        if (livroIndex == -1)
        {
            Console.WriteLine("Livro não encontrado.");
            return; // Sai do método se o livro não existir
        }

        // Remove o livro da lista
        livros.RemoveAt(livroIndex);

        // Atualiza o arquivo CSV sem o livro removido
        var linhas = livros.Select(l =>
            $"{l.Id},{l.Titulo},{l.Autor},{l.Genero},{l.Preco:F2},{l.Estoque}") // Mantém a estrutura correta
            .ToList();

        // Preservando o cabeçalho
        linhas.Insert(0, "Id,Titulo,Autor,Genero,Preco,Estoque");

        try
        {
            // Reescreve o arquivo CSV com as linhas atualizadas, incluindo o cabeçalho
            File.WriteAllLines(_filePath, linhas);
        }
        catch (Exception ex)
        {
            // Caso ocorra algum erro na reescrita do arquivo
            Console.WriteLine($"Erro ao escrever o arquivo CSV: {ex.Message}");
        }
    }





}
