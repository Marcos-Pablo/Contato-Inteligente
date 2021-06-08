# Contato Inteligente

Este projeto tem como objetivo buscar os 5 reposit�rios mais antigos escritos em C#
da Take.

Os reposit�rios podem ser encontrados em https://github.com/takenet

A integra��o com a API do GitHub foi feita com um pacote NuGet chamado Octokit.
As informa��es desse pacote est�o dispon�veis em https://github.com/octokit/octokit.net

Para a aplica��o executar corretamente, � necess�rio gerar um token da API do GitHub em https://github.com/settings/tokens e armazen�-lo juntamente com um login como Segredo do usu�rio da aplica��o.

Segredos de usu�rio podem ser configurados no arquivo secrets.json atrav�s do menu Gerenciar Segredos de Usu�rio

```c#
{
  "AppSettings": {
    "token": "",
    "login": ""
  }
}
```



