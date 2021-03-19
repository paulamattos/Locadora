# Projeto de Locadora

Esse projeto contém uma API simples de demonstração para gestão de locadoras.<br/>
Foi disponibilizado no Azure cloud container no link http://locadoraapi.brazilsouth.azurecontainer.io/swagger/index.html

## Estrutura do projeto

O projeto é dividido em quatro camadas lógicas.
* **WebApi** responsável por disponibilizar os endpoints da aplicação e realizar a configuração e injeção dos serviços.
* **Aplication** responsável por coordenar e transacionar os casos de uso.
* **Domain** responsável pelas entidades e regras de negócio do domínio.
* **Repository** responsável pela abstração do acesso ao dados da aplicação.

##  Tecnologias utilizadas

* C# .NET 5
* Banco de dados PostgreSQL
* ORM Entity Framework
* Api RESTful
* Endpoints disponibilizados via swagger
* Docker 
* Azure cloud

## Instalação

### Instalação manual

* Tenha o [.NET 5 SDK](https://dotnet.microsoft.com/download/dotnet/5.0) instalado.
* Tenha o [PostgreSQL](https://www.postgresql.org/) instalado.
* Clone o repositório em sua máquina usando o comando git clone https://github.com/paulamattos/Locadora.git
* Configure a string de conexão do PostgreSQL editando a variável de ambiente **db** no arquivo **"\src\WebApi\appsettings.json"**.
* Abra o console na pasta do projeto e execute o comando **dotnet restore**.
* E por fim execute o comando **dotnet run** na raiz do projeto para subir a aplicação.
* Acesse o link **https://localhost:5001/swagger/index.html**

### Instalação via docker-compose

* Tenha o [Docker](https://www.docker.com/) instalado.
* Abra o console na pasta do projeto e execute o comando **docker-compose up -d**. Esse comando vai utilizar o arquivo **docker-compose.yml** para montar o container do PostgreSQL e outro da aplicação.
* Espere até que os containers estejam prontos.
* Acesse o link **https://localhost:5001/swagger/index.html**.

## API contém os seguintes endpoints

## Filme
#### Inserir   
Utilize o método POST que recebe os dados do filme através de um JSON e retorna o ID do novo filme cadastrado

#### Editar
Utilize o método PUT que recebe os dados do filme através de um JSON

#### Listar
Utilize o método GET para listar todos os filmes

#### Remover
Utilize o método DELETE passando como parâmetro o código de um filme para removê-lo

Utilize o método DELETE passando como parâmetro uma lista de código de filmes para serem removidos

## Gênero
#### Inserir   
Utilize o método POST que recebe os dados do gênero através de um JSON e retorna o ID do novo gênero cadastrado

#### Editar
Utilize o método PUT que recebe os dados do gênero através de um JSON

#### Listar
Utilize o método GET para listar todos os gêneros

#### Remover
Utilize o método DELETE passando como parâmetro o código de um gênero para removê-lo

Utilize o método DELETE passando como parâmetro uma lista de código de gêneros para serem removidos

## Locação
#### Inserir
Utilize o método POST que recebe os dados da locação através de um JSON e retorna o código da nova locação

#### Editar
Utilize o método PUT que recebe os dados da locação através de um JSON

#### Listar
Utilize o método GET para listar todas as locações

###### *Métodos de remoção não foram implementados em locação porque uma locação não deve ser removida, somente alterada*
