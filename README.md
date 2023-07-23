# My Finance Web

> O My Finance Web é uma aplicação de controle financeiro projetada para ajudar os usuários a gerenciarem suas finanças pessoais com facilidade e eficiência, a partir do registro das transaçãoes do usuário.

### Ajustes e melhorias

O projeto ainda está em desenvolvimento e as próximas atualizações serão voltadas nas seguintes tarefas:

Requisitos Funcionais
- [x] Cadastro de Plano de Contas
- [x] Cadastro de Transação
- [ ] Gráficos analíticos
- [ ] Relatório de transações
- [ ] Inserção de tipo de operação na transação

Requisitos não funcionais
- [ ] Cobertura de Testes (unit tests e integração)
- [ ] Dockerizacao da Aplicação, como um modelo em Produção
- [ ] Aplicar CI/CD com git action

## 💻 Arquitetura e tecnologias utlizadas

Essa aplicação foi desenvolvida utilizando:
* ASP.NET MVC
* .Net Core 
* SQL Server
* Docker 
* Entity Framework.

Arquitetura em Camada:No projeto descrito, as camadas seguem uma arquitetura típica de aplicação em camadas, separando responsabilidades e tornando o código mais organizado e modular. Vamos explicar cada camada com mais detalhes:

1. Camada de Apresentação (MVC):
   - Nessa camada, encontramos os arquivos relacionados à interface do usuário, como as views (arquivos .cshtml), os controllers e os view models.
   - Os controllers recebem as requisições HTTP do usuário, invocam os casos de uso da camada de aplicação (casos de uso do sistema), recebem os resultados e os enviam para as views.
   - Os view models são classes utilizadas para representar as informações que são exibidas nas views. Eles são mapeados pelos controllers a partir dos modelos de domínio (ou DTOs) retornados pela camada de aplicação.

2. Camada de Aplicação:
   - Nessa camada, encontramos os casos de uso específicos do sistema, que definem as funcionalidades principais da aplicação. Cada caso de uso é implementado como uma classe que recebe os dados necessários para executar a operação e invoca os serviços da camada de serviço.
   - A camada de aplicação faz a orquestração dos serviços da camada de serviço, utilizando suas interfaces para realizar operações mais complexas, combinar operações de diferentes serviços ou realizar validações adicionais.
   - Os casos de uso são expostos através de interfaces, permitindo a separação da implementação dos contratos, facilitando a substituição de implementações por outras, se necessário.

3. Camada de Serviço:
   - Nessa camada, encontramos a implementação dos serviços de negócio da aplicação. Cada serviço corresponde a um conjunto de operações relacionadas que manipulam os modelos de domínio.
   - Os serviços contêm a lógica de negócio da aplicação, trabalhando com os modelos de domínio e interagindo com os repositórios para persistir ou recuperar dados do banco de dados.
   - A camada de serviço não possui conhecimento direto do banco de dados ou da infraestrutura de persistência, trabalhando com os modelos de domínio e abstraindo a lógica de persistência para os repositórios.

4. Camada de Domínio:
   - Essa é a camada central da aplicação, onde estão definidos os modelos de domínio que representam as principais entidades e conceitos do negócio.
   - Nessa camada, também encontramos as interfaces dos repositórios, que definem os contratos para a persistência de dados. Essas interfaces permitem a separação entre o domínio e a infraestrutura de persistência.
   - A camada de domínio não possui dependências em outras camadas, tornando-a independente e reutilizável.

5. Camada de Infraestrutura (Repositório):
   - Nessa camada, encontramos a implementação dos repositórios que utilizam a infraestrutura de persistência, como um banco de dados, para armazenar e recuperar dados.
   - Os repositórios implementam as interfaces definidas na camada de domínio e abstraem os detalhes do acesso a dados específicos, permitindo que a lógica da aplicação permaneça independente da tecnologia de persistência utilizada.

Essa arquitetura em camadas ajuda a manter um código organizado, de fácil manutenção e com baixo acoplamento entre as diferentes partes da aplicação. Cada camada possui responsabilidades bem definidas, facilitando a evolução e expansão do sistema de forma incremental e consistente. Além disso, essa abordagem permite testar cada camada de forma isolada, facilitando a criação de testes unitários e melhorando a qualidade do software como um todo.

Utiliza o padrão arquitetural MVC, além da utilização de camadas - Domínio, Instraestrutura, Aplicação, Serviços e Apresentação.

## 🚀 Requisitos do My Finance Web

Para rodar  o My Finance Web, siga estas etapas:

Você precisa instalar:

* Visual Studio ou VS Code
* .NET Core SDK
* Docker

## Como executar

1. Certifique-se de que o Docker e o Docker Compose estão instalados em seu sistema.
2. Clone o projeto
  ```bash
    https://github.com/thiagoholder/myfinance-web-dotnet.git
  ```
2. Abra um terminal na pasta raiz do projeto.
3. Execute o comando Docker Compose para criar e iniciar os contêineres:

   ```bash
   docker-compose up -d
   ```
4. Espere com o compose execute todos os passos para que os scripts sejam executados
5. Execute o comando para rodar a aplicação
    ```bash
    dotnet run --project src/WebApp/WebApp.csproj
    ```