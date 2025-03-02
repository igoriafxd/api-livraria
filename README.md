API Livraria 📚
🚀 Uma API simples para gerenciar um catálogo de livros, permitindo operações de CRUD (Create, Read, Update, Delete).

🔹 Sobre o Projeto
Esta API foi desenvolvida em .NET 7 com ASP.NET Core, permitindo o gerenciamento de livros através de endpoints REST. Os dados são armazenados em um arquivo CSV, garantindo uma abordagem simples e acessível para manipulação dos registros.

📌 Funcionalidades
✔️ Listar todos os livros
✔️ Buscar um livro por ID
✔️ Adicionar um novo livro
✔️ Atualizar as informações de um livro
✔️ Remover um livro do catálogo

🛠 Tecnologias Utilizadas
.NET 7 e ASP.NET Core 🌐
C# como linguagem principal
CSV como banco de dados simples
Git e GitHub para controle de versão
📂 Estrutura do Projeto
bash
Copiar
Editar
📦 API_Livraria
 ┣ 📂 Controllers        # Endpoints da API
 ┣ 📂 Models             # Modelos de dados
 ┣ 📂 Repositories       # Regras de negócio e acesso a dados
 ┣ 📜 appsettings.json   # Configurações da API
 ┣ 📜 Program.cs         # Ponto de entrada da aplicação
 ┣ 📜 README.md          # Documentação do projeto
 ┣ 📜 .gitignore         # Arquivos ignorados pelo Git
🚀 Como Rodar a API
1️⃣ Clone este repositório:

bash
Copiar
Editar
git clone https://github.com/SEU_USUARIO/api-livraria.git
2️⃣ Abra a pasta do projeto no VS Code:

bash
Copiar
Editar
cd api-livraria
3️⃣ Execute a API:

bash
Copiar
Editar
dotnet run
4️⃣ Acesse no navegador ou Postman:

bash
Copiar
Editar
http://localhost:5000/api/livros
🛠 Endpoints da API
Método	Rota	Descrição
GET	/api/livros	Lista todos os livros
GET	/api/livros/{id}	Busca um livro pelo ID
POST	/api/livros	Adiciona um novo livro
PUT	/api/livros/{id}	Atualiza os dados de um livro
DELETE	/api/livros/{id}	Remove um livro do catálogo

