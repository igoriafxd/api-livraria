# API Livraria

Uma API simples para gerenciamento de livros, construída com .NET 8.

## Estrutura do Projeto

A API é organizada da seguinte forma:

-   **Controllers:** Contém os controladores da API (ex: `LivrosController.cs`).
-   **Models:** Contém as classes de modelo (ex: `Livro.cs`).
-   **Repositories:** Contém as classes responsáveis pelo acesso aos dados (ex: `LivroRepository.cs`).
-   **Data:** Contém os arquivos de dados (ex: `livros.csv`).

## Modelo de Dados (`Livro.cs`)

O modelo `Livro` representa um livro e possui as seguintes propriedades:

| Propriedade | Tipo     | Descrição                                   | Obrigatório |
| :---------- | :------- | :------------------------------------------ | :---------- |
| `Id`        | `int`    | Identificador único do livro.               | Sim         |
| `Titulo`    | `string` | Título do livro.                            | Sim         |
| `Autor`     | `string` | Autor do livro.                             | Sim         |
| `Genero`    | `string` | Gênero do livro.                            | Sim         |
| `Preco`     | `decimal` | Preço do livro (deve ser maior que zero). | Sim         |
| `Estoque`   | `int`    | Quantidade em estoque (não pode ser negativo). | Sim         |

## Endpoints da API (`LivrosController.cs`)

A API possui os seguintes endpoints:

| Método HTTP | Endpoint          | Descrição                                      |
| :---------- | :---------------- | :--------------------------------------------- |
| `GET`       | `/api/livros`     | Retorna todos os livros.                       |
| `GET`       | `/api/livros/{id}` | Retorna um livro específico pelo ID.          |
| `POST`      | `/api/livros`     | Adiciona um novo livro.                        |
| `PUT`       | `/api/livros/{id}` | Atualiza um livro existente.                   |
| `DELETE`    | `/api/livros/{id}` | Exclui um livro.                              |

## Acesso a Dados

Os dados dos livros são armazenados em um arquivo CSV (`Data/livros.csv`). A classe `LivroRepository` é responsável por ler, adicionar, atualizar e excluir livros do arquivo CSV.

## Formato dos Dados (CSV)

O arquivo `livros.csv` segue o seguinte formato:

```
Id,Titulo,Autor,Genero,Preco,Estoque
1,Dom Casmurro,Machado de Assis,Ficção,29.00,99
2,Senhora,José de Alencar,Ficção,25.00,50
...
```

## Como Executar o Projeto

1.  Certifique-se de ter o .NET 8 SDK instalado.
2.  Clone este repositório.
3.  Navegue até a pasta raiz do projeto (onde este README.md está localizado).
4.  Execute o comando `dotnet run` no terminal.
5.  A API estará disponível em `http://localhost:5000` (ou outra porta, se configurado).

## Exemplo de requisição

```http
GET http://localhost:5000/api/livros
