# Backend.Challenge
Este projeto utiliza o entity framework em memory como banco de dados

## Chamadas da api ##

**GET - http://localhost:19094/main/comments?entidade=mxa&totalResults=0&sizeByPage=2** 
    <br>Uma entidade com seus comentários
    
 **GET - http://localhost:19094/main/commentsall?totalResults=0&sizeByPage=2** 
    <br>Todas as entidades com seus comentários
    
 **POST - http://localhost:19094/main/commentsAdd**
 <br>
 {
	"entidade":"mxa",
	"autor":"Marcelo Xavier Almeida",
	"texto":"<html><body>texto novo 3</body></html>"	
}
    
  
