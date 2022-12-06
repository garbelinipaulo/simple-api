# simple-api
I've made this project to show and example of a backend api with microservice purpose, will contain only one controller but shows all the process.


# About the pattern of the API
I've separated between two layers:
- The API layer is compose with controllers, components and resources injection.
- The Application layer is the core with Infra, Ioc, Domain, Services.


# About the components in the Application Layer:

- Services -> Contains core business, where the controllers of the API layer will call for the requisitions
- Domain -> Contains the models, Dto's ( data-transfer-object ), Contracts ( interfaces )
- Infra -> Contains the repositories and the DB connections main structure.
- Ioc -> Contains the components and classes for register dependencies and injections


# Some simple patterns

- I like to use automapper instead of mapping models manual.
- In repositories I like to separate queries just for clean code.
- I just use BaseRepositoriy for db connection structure to share with all repositories.
- I like to use dapper for performance purposes.
