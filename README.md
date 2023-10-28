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

## 3. Como executar o projeto
### para o BACK-END

Pré-requisito:
- instalado o Visual Studio ou VSCode
  
Comandos a serem executados:
```bash
# clonar repositório
git clone https://github.com/FullStack-Coqueiros/M3P-BackEnd-Squad1.git

# entrar na pasta do projeto back end
cd labmedicineapi

Obs.: verificar se os pacotes nugets foram baixados

# executar o projeto
dotnet run
```
A aplicação vai compilar e gerar no terminal da IDE o http://localhost, indicando uma porta, conforme figura 1 apresentada logo abaixo.

![image](https://github.com/alessandramedeirosvieira/modelreadme/assets/125104709/2b6d29a0-af4a-462a-a1d2-241d144d4fb5)
##### Figura 1: localhost do back-end


O usuário deverá rodar esse localhost no seu navegador seguido por "/swagger". Será carregada a WebApi em tela, conforme demonstrado nas figuras 2 e 3 demonstradas abaixo, para execução dos testes.
Obs.: como a webapi é bem extensa, para melhor visualização estamos apresentando as imagens em 2 figuras.


![image](https://github.com/alessandramedeirosvieira/modelreadme/assets/125104709/691ec8a2-e217-4fad-b4bb-979e5e81c908)
##### Figura 2: 1ª parte da webapi


![image](https://github.com/alessandramedeirosvieira/modelreadme/assets/125104709/e7af7630-0a25-4e05-b481-47a5145a97aa)
##### Figura 3: 2ª parte da webapi

### para o FRONT-END
Pré-requisito: 
- instalado o VSCode

Comandos a serem executados:
```bash
# clonar repositório
git clone https://github.com/FullStack-Coqueiros/M3P-FrontEnd-Squad1.git

# entrar na pasta do projeto front end 
cd labmedicineapi

# instalar as dependências
npm install

# executar o projeto
npm run dev
```
A aplicação vai compilar e gerar no terminal da IDE o http://localhost, indicando uma porta, conforme figura 4 abaixo.


![image](https://github.com/alessandramedeirosvieira/modelreadme/assets/125104709/57efbfb6-b9cf-4cc1-80f6-c474038b2db5)
##### Figura 4: localhost do front-end



Rodando esse localhost no navegador, será carregado a tela de Login da aplicação, conforme figura 5 apresentada logo abaixo.


![image](https://github.com/alessandramedeirosvieira/modelreadme/assets/125104709/1aa06a69-2165-450a-bc55-a60403346491)
##### Figura 5: tela de Login



Para o usuário já cadastrado na aplicação, basta inserir o seu e-mail e a sua senha cadastrados para realizar o login.

Para o caso de usar o db.json visando acessar a aplicação, segue o comando abaixo

```bash
# para usar o db.json, necessário executar o seguinte comando:
json-server --watch ./server/db.json
```
Será gerado os resources, conforme demonstrado na figura 6 abaixo.


![image](https://github.com/alessandramedeirosvieira/modelreadme/assets/125104709/d4513bd3-2f30-48ff-9653-4b85a8fd253a)
##### Figura 6: acessando a aplicação utilizando o db.json



O usuário para realização dos testes deverá digitar os seguintes dados:
e-mail: admin1@admin.com
senha: 12345678

No caso do usuário ainda não ser cadastrado na aplicação e desejar se cadastrar, o mesmo deverá clicar no botão Criar Conta que se apresenta na tela de Login, na canto superior direito da tela, conforme demonstrado na figura 7 abaixo.


![image](https://github.com/alessandramedeirosvieira/modelreadme/assets/125104709/86711d39-1c02-411a-b4b0-2e227709c453)
##### Figura 7: botão de Criar Conta, na tela de Login



Será exibido una mensagem em tela de que o usuário deverá entrar em contato como Administrador para criar uma nova conta junto a aplicação.


O usuário ao realizar a autenticação na aplicação será direcionado para a tela de Estatísticas e Informações, conforme figura 8 abaixo, e dessa forma poderá realizar a navegação na aplicação, pelas demais funcionaliddes, conforme menu lateral (sidebar).

![image](https://github.com/alessandramedeirosvieira/modelreadme/assets/125104709/16ac1447-fbf2-4ef9-9863-b61870f7110d)
##### figura 8: Sidebar apresentando as funcionalidades da aplicação

## 4. Funcionalidades do projeto

### Cadastro de usuários: 

![image](https://github.com/alessandramedeirosvieira/modelreadme/assets/125104709/c8ebffa2-0a54-4e39-a596-276b676ed7f0)
##### figura 9: Cadastro de usuários


# Autores


#### Rafael Santos da Silva 
##### github: rsilvagit

#### William Dias Rocha
#####  github: williamdiasrocha

#### Alessandra Medeiros Vieira
#####  github: alessandramedeirosvieira





