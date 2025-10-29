

# Nac2Estoque

## Descrição do Projeto
Sistema de gerenciamento de estoque desenvolvido em .NET, com funcionalidades de cadastro de produtos, movimentação de entradas e saídas, validações de regras de negócio e geração de relatórios.

## Dupla
- Julia Martins de Almeida Antunes RM98601
- Ana Luisa Giaquinto Zólio RM99348

O projeto tem como objetivo controlar o estoque de produtos, garantindo que:
- Não haja saídas de estoque sem quantidade suficiente;
- Produtos perecíveis tenham validade controlada;
- Produtos abaixo do estoque mínimo sejam identificados.

---

## Regras de Negócio Implementadas

### Produto
- Validação de categoria vs dados obrigatórios.
- Cadastro completo com nome, categoria, preço, estoque mínimo e estoque atual.
- Identificação de produtos abaixo do estoque mínimo.

### Movimentação
- Quantidade positiva obrigatória.
- Verificação de estoque suficiente para saídas.
- Atualização automática do saldo do produto após entradas e saídas.
- Validação da data de validade para produtos perecíveis.
- Registro de entrada e saída de estoque.

### Relatórios
- Cálculo do valor total do estoque (`quantidade × preço`).
- Listagem de produtos que vencerão em até 7 dias.
- Identificação de produtos com estoque abaixo do mínimo.


## Diagrama simples das entidades

Produto
├── Id
├── Nome
├── Categoria
├── Preco
├── EstoqueMinimo
└── EstoqueAtual

MovimentacaoEstoque
├── Id
├── ProdutoId
├── Tipo (Entrada/Saida)
├── Quantidade
├── DataMovimentacao
└── DataValidade

## Exemplos de Requisições API

### Produtos

- **Listar produtos**
- http
GET /api/produtos


* **Cadastrar produto**
http
POST /api/produtos
Content-Type: application/json

{
  "nome": "Produto A",
  "categoria": "Perecível",
  "preco": 10.50,
  "estoqueMinimo": 5,
  "estoqueAtual": 20
}

### Movimentação de Estoque

* **Registrar entrada/saída**

http
POST /api/movimentacoes
Content-Type: application/json

{
  "produtoId": 1,
  "tipo": "Saida",
  "quantidade": 2,
  "dataValidade": "2025-11-05"
}

* **Listar movimentações**

http
GET /api/movimentacoes


### Relatórios

* **Produtos abaixo do estoque mínimo**

http
GET /api/relatorios/estoque-baixo

* **Produtos vencendo em até 7 dias**

http
GET /api/relatorios/produtos-vencendo

* **Valor total do estoque**

http
GET /api/relatorios/valor-estoque

---

## Como Executar o Projeto

1. Restaurar pacotes NuGet:

dotnet restore

2. Compilar o projeto:

dotnet build

3. Executar:
   
dotnet run

4. Acessar as APIs pelo endereço indicado no console (ex.: `https://localhost:5001/api/produtos`).

---

## Comprovantes no Repositório

* Etapa 1: Modelagem do domínio
* Etapa 2: Implementação das regras de negócio
* Etapa 3: Validações e tratamento de erros
* Etapa 4: Documentação e entrega	

---

## Tag de Entrega

* versao-final

