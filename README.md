# Projeto de Cálculo de CDB

Este é um projeto que consiste em uma aplicação web em Angular para cálculo de CDB (Certificado de Depósito Bancário) e uma Web API em ASP.NET Core para executar os cálculos. A aplicação permite ao usuário calcular o valor bruto e líquido do investimento em um CDB com base em um valor inicial e um prazo em meses.

## Funcionalidades

- Cálculo do valor bruto e líquido do investimento em um CDB.
- Cálculo do imposto devido com base em um valor inicial e prazo.
- Interface web amigável para inserção dos valores e visualização dos resultados.

## Tecnologias Utilizadas

- Angular para o frontend.
- ASP.NET Core para o backend.
- Testes unitários utilizando Xunit.

## Como Executar o Projeto

### Frontend (Angular)

1. Navegue até o diretório `frontend`:
cd CalculadoraCDB\CalculadoraCDB\ClientApp

2. Instale as dependências:
npm install

3. Inicie o servidor de desenvolvimento:
npm start

4. Abra um navegador e acesse: `https://localhost:44404/`

### Backend (ASP.NET Core)

1. Navegue até o diretório `backend`:
cd CalculadoraCDB\CalculadoraCDB

2. Execute o projeto:
dotnet run

## Testes

### Backend (Testes Unitários)

1. Navegue até o diretório `backend.Tests`:
cd CalculadoraCDB\CalculadoraCDB.Tests

2. Execute os testes:
dotnet test
   
