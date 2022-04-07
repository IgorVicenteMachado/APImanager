# APImanager 
Projeto desenvolvendo uma API por camadas:

`Camada de Aplicação:` Exposição da aplicação ao público. Aqui são desenvolvidos os controladores, que recebem todas as requisições e as direcionam a algum serviço para executar uma determinada ação.

`Camada de Dominio:` Entidades (bem como seus métodos, comportamentos e propriedades) da aplicação.

`Camada de Serviços:` Define as regras de negócio.

`Camada de Infraestrutura:` lida com persistência no banco de dados.

![layers](img/layers.PNG)

> ### O que foi visto?

| Abordagens durante o projeto |
| ---------------------------- |
| Arquitetura em camadas       |
| Injeção de dependência       |
| Acesso a dados: Entity Framework Core |
| Fluent Validation            |
| Repository Pattern           |
