# Bootcamp .NET SQUADRA DIGITAL

#### Participante: Diogo Victor Santos Silva
#### Professor: Francisco Otávio de Queiroz

## Livraria Virtual - API REST
## 📋 Descrição do Projeto
Uma API REST desenvolvida para gerenciar produtos de uma livraria virtual, oferecendo funcionalidades como cadastro, consulta, atualização e exclusão de produtos. A API também possui autenticação via JWT para controle de login e acesso a funcionalidades restritas.

### 🚀 Funcionalidades
#### 1. Gerenciamento de Produtos

* Cadastro de produtos.
* Consulta de todos os produtos cadastrados.
* Consulta de produtos disponíveis em estoque.
* Atualização de informações de um produto.
* Exclusão de produtos.
  
#### 2. Autenticação e Controle de Acesso
* Autenticação JWT para geração de tokens de acesso.
  * Controle de permissões:
  * Qualquer pessoa pode consultar produtos.
  * Apenas Gerente pode excluir produtos.
  * Apenas Gerente e Funcionário podem atualizar produtos.
#### 3. Persistência de Dados
* Banco de Dados SQL Server para armazenamento e gerenciamento dos dados.


### 🗂 Estrutura dos Dados do Produto
* Id: Identificador único do produto.
* Nome: Nome do produto.
* Descrição: Descrição detalhada do produto.
* Preço: Preço do produto.
* Status: Status do produto (Disponível/Indisponível).
* Estoque: Indica a quantidade, que irá cadastrar.
* Categoria: Categoria do produto.

  
### 🛠 Tecnologias Utilizadas
* Backend: C# .NET.
* Banco de Dados: SQL Server.
* Autenticação: JWT.
* API REST: Métodos HTTP (GET, POST, PUT, DELETE).

### 🌐 Endpoints da API
### 1. Produtos
* GET /api/produtos  
Retorna a lista de todos os produtos cadastrados.

* GET /api/produtos/{id}  
Retorna os detalhes de um produto específico pelo seu id.

* POST /api/produtos  
Cadastra um novo produto (disponível apenas para usuários autenticados).

* PUT /api/produtos/{id}  
Atualiza os dados de um produto existente (apenas para Gerente ou Funcionário).

* DELETE /api/produtos/{id}  
Exclui um produto (apenas para Gerente).

### 🧰 Como Executar o Projeto (Passo a Passo)


#### Segue abaixo o JSON de exemplo para cadastro no swagger.

* POST /api/produtos  
{  
  "nome": "Kit Home Office",  
  "descricao": "Kit com mouse pad, teclado e mouse sem fio.",  
  "preco": 99.90,  
  "status": "Disponível",  
  "estoque": 1,  
  "categoria": "Diversos"  
}

#### Utilização de Autenticação JWT

#### Para testar o PUT e DELETE, fazer o login primeiro em:

* POST /api/Auth  
Autentica um usuário e retorna um token JWT.

Escolher:  
Delete e PUT
* Usuário: (Gerente)
* Senha (123456)


Somente PUT 
* Usuário: (Funcionário)
* Senha (654321)

Com o token gerado ir em Authorize para fazer o login, quando abrir inserir em Value: ( Bearer espaço, colar o token gerado.)

Feito o login acessar 
* GET /api/Auth/RotaProtegida
Clicar em (Try it out).
Feito isso o usuário estára logado e pronto para executar o PUT ou DELETE.
