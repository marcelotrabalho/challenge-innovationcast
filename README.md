# challenge-innovationcast

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
  - sizeByPage    : Total de registros que tem que retornar da Api

