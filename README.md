# Contato Inteligente

Este projeto tem como objetivo buscar os 5 repositórios mais antigos escritos em C#
da Take.

Os repositórios podem ser encontrados em https://github.com/takenet

A integração com a API do GitHub foi feita com um pacote NuGet chamado Octokit.
As informações desse pacote estão disponíveis em https://github.com/octokit/octokit.net

Para a aplicação executar corretamente, é necessário gerar um token da API do GitHub em https://github.com/settings/tokens e armazená-lo juntamente com um login como Segredo do usuário da aplicação.

Segredos de usuário podem ser configurados no arquivo secrets.json através do menu Gerenciar Segredos de Usuário

```c#
{
  "AppSettings": {
    "token": "",
    "login": ""
  }
}
```



