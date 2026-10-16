# Integração Front-End (Angular) e Back-End (.NET) - CRUD de Produtos

Este repositório contém uma aplicação full-stack de gestão de produtos, desenvolvida para demonstrar a integração completa entre uma API RESTful em C# (.NET) e uma interface moderna de página única (SPA) em Angular.

## 🚀 Tecnologias Utilizadas

### Front-End
* **Angular 18+:** Utilizando as funcionalidades mais modernas do framework, incluindo *Standalone Components*, *Signals* para gestão de estado reativa e a nova sintaxe de *Control Flow* (`@if`, `@for`).
* **TypeScript, HTML5 & CSS3.**

### Back-End
* **C# .NET:** ASP.NET Core Web API.
* **Banco de Dados:** SQLite (com Entity Framework Core).
* **Validação e Testes:** DBeaver (inspeção direta do banco `minhaapi.db`) e Swagger (testes de rotas da API).

## ⚙️ Funcionalidades

O sistema permite operações completas de CRUD (Create, Read, Update, Delete):
* Listagem em tempo real de todos os produtos.
* Busca detalhada de produtos por ID.
* Cadastro de novos itens com validação de payload.
* Edição inline de produtos existentes.
* Exclusão de itens com atualização reativa da interface.

## 🔧 Como Executar o Projeto

Você precisará de dois terminais rodando simultaneamente (um para a API e outro para o Front-End).

### 1. Rodando a API (.NET)
1. Navegue até a pasta do back-end:
   ```bash
   cd back-end