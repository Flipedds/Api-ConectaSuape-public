# Conecta Suape - Api

## Uma api para o projeto Conecta Suape

Acesso à Api:
https://api-mobile-25hv.onrender.com

Acesso ao swagger do deploy: https://api-mobile-25hv.onrender.com/swagger

## Endpoints
1. Login

   - URL: /api/Login

   - Método: Post

   - Parâmetros:

        userName: nome do usuário.

        pass: senha do usuário.
   
   - Para testar
    
    - json {

        "userName": "teste",

        "pass": "teste"

        }

2. Voucher 1

    - URL: /api/Voucher/{id}

    - Método: GET
    - Parâmetros:

        id: id do usuário.

    - Exemplo de requisição: 

    - curl -X GET "https://sua-api.com/api/Voucher/1


3. Voucher 2

    - URL: /api/Voucher

    - Método: Post

    - id: id do usuário.

    - Para testar

    - json {

        "userId": 1

       }
