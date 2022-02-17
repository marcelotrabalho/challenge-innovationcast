# Challenge-innovationcast

Este o branch do projeto. A pasta da solution principal é **InnovationCast.Backend.Challenge-main** <br>

Os métodos http criados foram:
- GET Comments
- GET CommentsAll
- POST CommentsAdd

### GET Comments ###
É um GET que retorna os comentários de uma determinada entidade. 
Os comentários vem ordenados por publicação decrescente
Este GET tem tres queries:
  - entidade      : Nome da entidade que quero pesquisar
  - totalResults  : Total de registros que já tenho do lado do Front
  - sizeByPage    : Total de registros que tem que retornar da Api para a consulta desta entidade

***Example***

http://localhost:19094/main/comments?entidade=marcelo&totalResults=2&sizeByPage=20

Return 200 OK 

```
{
	"comments": {
		"marcelo": [
			{
				"id": "acc88efb-f49f-4679-9f92-73a676ba94eb",
				"entidade": "marcelo",
				"autor": "Marcelo Xavier Almeida",
				"campoTexto": "<html><body>texto novo 4</body></html>",
				"dataDePublicacao": "2022-02-16T20:55:20.6554085+00:00"
			},
			{
				"id": "37eb65c7-b1a0-4837-8c2d-28aa7f652724",
				"entidade": "marcelo",
				"autor": "Marcelo Xavier Almeida",
				"campoTexto": "<html><body>texto novo 4</body></html>",
				"dataDePublicacao": "2022-02-16T20:55:20.1437219+00:00"
			}
		]
	},
	"totalResults": 2,
	"sizeByPage": 20,
	"timeStamp": "2022-02-16T20:56:11.802191+00:00"
}
```

### GET CommentsAll ###
É um GET que retorna todas as entidades e seus comentários ordenados por publicação decrescente
Este GET tem duas queries:
  - totalResults  : Total de registros que já tenho do lado do Front
  - sizeByPage    : Total de registros que tem que retornar da Api para cada entidade retornada, ou seja:
                    Entidade A => vai retornar os registros totalResults + sizeByPage para esta entidade
                    Entidade B => vai retornar os registros totalResults + sizeByPage para esta entidade

***Example***
http://localhost:19094/main/commentsall?totalResults=2&sizeByPage=1

Return 200 OK 
```
{
	"comments": {
		"mxa": [
			{
				"id": "49861490-8871-4104-855f-0138596b8118",
				"entidade": "mxa",
				"autor": "Marcelo Xavier Almeida",
				"campoTexto": "<html><body>texto novo 4</body></html>",
				"dataDePublicacao": "2022-02-17T09:10:12.180011+00:00"
			},
			{
				"id": "6faab628-4fca-489a-b8e2-111731589336",
				"entidade": "mxa",
				"autor": "Marcelo Xavier Almeida",
				"campoTexto": "<html><body>texto novo 4</body></html>",
				"dataDePublicacao": "2022-02-17T09:10:11.4831177+00:00"
			},
			{
				"id": "57b94c04-8729-44e0-99d5-16d3a9320c95",
				"entidade": "mxa",
				"autor": "Marcelo Xavier Almeida",
				"campoTexto": "<html><body>texto novo 4</body></html>",
				"dataDePublicacao": "2022-02-17T09:10:10.4033187+00:00"
			}
		],
		"marcelo": [
			{
				"id": "d23d01cd-2111-46e7-b36b-7f5b9c1cd038",
				"entidade": "marcelo",
				"autor": "Marcelo Xavier Almeida",
				"campoTexto": "<html><body>texto novo 4</body></html>",
				"dataDePublicacao": "2022-02-17T09:10:23.7687276+00:00"
			},
			{
				"id": "bcd110de-b4bd-4929-b8a1-920e2f8216b5",
				"entidade": "marcelo",
				"autor": "Marcelo Xavier Almeida",
				"campoTexto": "<html><body>texto novo 4</body></html>",
				"dataDePublicacao": "2022-02-17T09:10:23.0742222+00:00"
			}
		]
	},
	"totalResults": 5,
	"sizeByPage": 1,
	"timeStamp": "2022-02-17T09:10:26.6081869+00:00"
}
```
