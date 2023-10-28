# M3P-BackEnd-Squad1

#LABMedical

# Sobre o projeto

Em função do término do curso FullStack 2023, Turma Coqueiros, oferecido pelo LAB365 em parceria com o SENAI/SC, SEBRAE e ACATE, que faz parte do projeto Floripa Mais Tech (programa de iniciativa da Prefeitura de Florianópolis),foi nos passado como avaliação do módulo 3, o desenvolvimento de projeto seguindo os requisitos detalhados na documentação entregue aos alunos. 

Os alunos dessa turma foram divididos em duas squads, sendo que cada squad deverá desenvolver o projeto.

Conforme documentação fornecida, a organização LABMedicine LTDA, empresa líder no segmento tecnológico de gestão hospitalar, foi selecionada em edital e recebeu um aporte financeiro para aprimorar seu principal produto, o LABMedical. A expectativa é que esse novo produto possa ser personalizado e comercializado para postos de saúde e clínicas particulares em todo o país.

A aplicação engloba o desenvolvimento de BACK-END (WebAPI) e FRONT-END conforme requisitos especificados, regra de negócio e tecnologias listadas abaixo.

## 1. Tecnologias utilizadas

### Back end
- C#
- Banco de dados: SQL Server
### Front end
- HTML / CSS / Javascript
- React

## 2. Regras de negócio

### Autenticação dos usuários: 
Quando um usuário realizar a autenticação, o sistema deverá entender o cargo do usuário e permitir alguns funcionalidades conforme as permissões vinculadas. Nessa aplicação teremos cadastrados os seguintes usuários:
- Administrador: poderá cadastrar, editar, listar e deletar qualquer usuário, bem como qualquer uma das funcionalidades de consultas, exames, medicamentos, dietas e exercícios. Só não poderá deletar a si mesmo. Poderá também editar as configurações da aplicação e visualizar os logs.
- Médico: poderá cadastrar, editar, listar e deletar qualquer paciente, exame, consulta, medicação, dieta e exercício.
- Enfermeiro: poderá cadastrar, editar, listar e deletar qualquer paciente, medicação, dieta e exercício.
- Paciente: não possuirá acesso ao sistema.

### Deleção:
Um recurso não poderá ser deletado caso tenha algo vinculado.

### Inativação:
Todos os usuários e recursos devem possuir uma flag (ativo/inativo) para que possa ser inativado caso seja necessário. Se um usuário for inativado, todos os recursos vinculados a ele também serão inativados.

### Registro:
Todas as operações realizadas no sistema deverão gerar um log que poderá ser visualizado apenas pelo Administrador do sistema.
