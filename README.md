# Locadora
## *Nesse projeto é possível cadastrar filmes e locações*


## Estrutura do projeto
* Solução C# .NET 5
* Banco de dados SQL Server
* Endpoints disponibilizados via swagger



## Exemplo de uso

## Filmes
#### Inserir   
Utilizar método Inserir que recebe os dados do filme através de um DTO e retorna o ID do novo filme cadastrado

#### Editar
Utilizar método Editar que recebe os dados do filme através de um DTO

#### Listar
Utilizar método Listar para listar todos os filmes

#### Remover
Utilizar o método Remover passando como parâmetro o código de um filme para removê-lo

Utilizar o método RemoverFilmes passando como parâmetro uma lista de código de filmes para serem removidos

## Gêneros
#### Inserir   
Utilizar método Inserir que recebe os dados do gênero através de um DTO e retorna o ID do novo gênero cadastrado

#### Editar
Utilizar método Editar que recebe os dados do gênero através de um DTO

#### Listar
Utilizar método Listar para listar todos os gêneros

#### Remover
Utilizar o método Remover passando como parâmetro o código de um gênero para removê-lo

Utilizar o método RemoverGeneros passando como parâmetro uma lista de código de gêneros para serem removidos

## Locação
#### Inserir
Utilizar o método Inserir que recebe os dados da locação através de um DTO e retorna o código da nova locação

#### Editar
Utilizar o método Editar que recebe os dados da locação através de um DTO

#### Listar
Utilizar o método listar para listar todas as locação

###### *Métodos de remoção não foram implementados em locação porque uma locação não deve ser removida, somente alterada*
