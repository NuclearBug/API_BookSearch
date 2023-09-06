# API_BookSearch
API para pesquisa de livros e suas informações.

Integrante: Felipe Cipriano de Andrade Ferreira.
<br>
Link da API externa: https://rickandmortyapi.com/documentation 
<br>
Tema da API externa: A série animada de TV, Rick And Morty. 
<br>
Descrição das funcionalidades já existentes ou previstas: Mostra dados de todos os personagens pesquisados, assim como fornece imagens dos mesmos e também permite a pesquisa de planetas apresentados na série.  
<br>
<br>
Tema da nova API: Livros (foco em fictícios -  relacionados a série Rick And Morty). 
<br>
Endpoints da API BookSearch: 
<br>
GET - https://web-hdz6zoncyp736.azurewebsites.net/books </br>
GET - https://web-hdz6zoncyp736.azurewebsites.net/books/{id} </br>
GET - https://web-hdz6zoncyp736.azurewebsites.net/books/{nome} </br>
POST - https://web-hdz6zoncyp736.azurewebsites.net/books </br>
PUT - https://web-hdz6zoncyp736.azurewebsites.net/books/{id} </br>
DELETE - https://web-hdz6zoncyp736.azurewebsites.net/books/{id} </br>


<br>
Exemplo de arquivo JSON a ser enviado pelo método POST: 
<br>
{ </br>
  "id":4, </br>
  "nome":"Teste livro", </br>
  "sinopse":"Era uma vez...", </br>
  "Class":"Romance - Sci-fi", </br>
  "numCap":22, </br>
  "numPag":404, </br>
  "autor":"Demond", </br>
  "favorito":true </br>
}


<br>
Descrição – Nova API: Api de busca de livros e todos os dados relacionados, assim como sinopse, classificação, número de capítulos, número de páginas, avaliação, etc. 
</br>
</br>

# Modelo Lógico:
</br>
</br>
<p align="center">
<img src="https://github.com/NuclearBug/API_BookSearch/assets/71195558/d47bb838-1660-4523-b590-7226e60a18ab.png"/>
</p>
</br>
</br>

# Modelo Físico:
</br>
</br>
<p align="center">
<img src="https://github.com/NuclearBug/API_BookSearch/assets/71195558/aef282e3-e643-46f4-9a75-4c4dd596d828.png"/>
</p>
</br>
</br>

# Diagrama de Classes:
</br>
</br>
<p align="center">
<img src="https://github.com/NuclearBug/API_BookSearch/assets/71195558/9e3c14e6-ed80-4150-a461-db0d9845b2fc.png"/>
</p>
