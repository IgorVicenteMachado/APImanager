# APImanager 
Projeto desenvolvendo uma API por camadas:

`Camada de Aplicação:` Exposição da aplicação ao público. Aqui são desenvolvidos os controladores, que recebem todas as requisições e as direcionam a algum serviço para executar uma determinada ação.

`Camada de Dominio:` Entidades (bem como seus métodos, comportamentos e propriedades) da aplicação.

`Camada de Serviços:` Define as regras de negócio.

`Camada de Infraestrutura:` lida com persistência no banco de dados.

![layers](src/img/layers.PNG)

> ### Conteúdo Abordado

| O que foi visto? |
| ---------------------------- |
| Arquitetura em camadas       |
| <a href=" "> Injeção de dependência </a>    |
| <a href="src/Manager.Infra/Context/ManagerContext.cs"> Acesso a dados: Entity Framework Core </a>    |
| <a href="src/Manager.Infra/Mappings/UserMap.cs">Mapeamento DB com Entity framework core</a> |
| <a href="src/Manager.Domain/Validators/UserValidator.cs"> Fluent Validation </a> |
| <a href="src/Manager.Infra/Repositories"> Repository Pattern   </a> |
| <a href=" "> tópico </a>    |
