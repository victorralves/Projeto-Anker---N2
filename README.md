# Projeto AED 2 - N2

Disciplina: Algoritmos e Estruturas de Dados II  
Professor: Anker D. Loss  
Grupo: Denis Ambrozini e Victor Rocha Alves

---

## O que é o projeto

Sistema de gerenciamento escolar feito em C# que calcula o resultado das provas dos alunos. O programa lê as informações de arquivos de texto, armazena tudo em listas encadeadas implementadas do zero e permite consultar e cadastrar alunos, disciplinas e matrículas pelo terminal.

---

## A parte mais importante: as Listas Encadeadas

A principal exigência do trabalho era implementar as estruturas de dados manualmente, sem usar nenhuma estrutura nativa do C# como `List<T>` ou arrays dinâmicos.

Para isso criamos nossas próprias classes de nó e lista para cada tipo de dado:

- `NOAluno` + `ListaEncadeadaAluno`
- `NODisciplina` + `ListaEncadeadaDisciplina`
- `NOMatricula` + `ListaEncadeadaMatricula`

Cada nó guarda o objeto e um ponteiro para o próximo nó da lista, como visto em aula.

---

## Arquivos de Dados

Os arquivos ficam na pasta `Data/` e cada registro ocupa uma linha, com os campos separados por `;`.

- `Alunos.dat` — Matricula;Nome;Idade
- `Disciplinas.dat` — Codigo;Nome;NotaMinima
- `Matriculas.dat` — AlunoMatricula;DisciplinaId;Nota1;Nota2

---

## Estrutura do Projeto
ProjetoAnkerN1/
├── Data/
│   ├── Alunos.dat
│   ├── Disciplinas.dat
│   └── Matriculas.dat
├── Estruturas/
│   ├── NOAluno.cs
│   ├── NODisciplina.cs
│   ├── NOMatricula.cs
│   ├── ListaEncadeadaAluno.cs
│   ├── ListaEncadeadaDisciplina.cs
│   └── ListaEncadeadaMatricula.cs
├── Models/
│   ├── Aluno.cs
│   ├── Disciplina.cs
│   └── Matricula.cs
├── Services/
│   ├── AlunoService.cs
│   ├── DisciplinaService.cs
│   └── MatriculaService.cs
├── Views/
│   ├── AlunoView.cs
│   ├── DisciplinaView.cs
│   ├── MatriculaView.cs
│   └── MenuView.cs
├── Controllers/
│   ├── AlunoController.cs
│   ├── DisciplinaController.cs
│   ├── MatriculaController.cs
│   └── MenuController.cs
└── Program.cs

---

## Funcionalidades

### Consultas
- Listar todos os alunos
- Listar todas as disciplinas
- Listar alunos de uma disciplina (aceita nome ou código), exibindo notas, média e situação
- Listar disciplinas de um aluno (aceita nome ou matrícula), exibindo notas, média e situação

### Cadastros
- Cadastrar aluno (matrícula gerada automaticamente)
- Cadastrar disciplina (código gerado automaticamente)
- Cadastrar matrícula (vincula aluno a uma disciplina)
- Atribuir notas a um aluno em uma disciplina

### Salvar
- Grava os dados das listas nos arquivos `.dat`

### Sair
- Salva os dados e encerra o programa

---

## Regras de Negócio

- Média: (Nota1 + Nota2) / 2
- Aprovado: média maior ou igual à nota mínima da disciplina
- Reprovado: média menor que a nota mínima da disciplina
- Matrícula e código de disciplina são únicos e gerados automaticamente

---

## Como Executar

Requer .NET 8 SDK instalado.

```bash
cd ProjetoAnkerN1
dotnet run
```
