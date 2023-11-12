/*Velázquez Tovar Luz Elizabeth
Examen 2 Aplicación Librería (API Rest)
Desarrollo de Aplicaciones Empresariales
Ismael Pérez Mena
13/noviembre/2023*/

document.addEventListener('DOMContentLoaded', function(){
    //url del api que proporciona los datos de los libros
    const url = 'http://localhost:5140/api/bookAuthor';

    //obtener referencia del listado de libros (cuerpo de la tabla) y el campo de búsqueda
    const listadoLibros = document.getElementById('listadoLibros');
    const bookTitle = document.getElementById('bookTitle');

    var allBooks = {};
    
    //Función para obtener y mostrar los libros obtenidos de la api
    function fetchBooks(){
        //realizamos una solicitud fetch a la api
        fetch(url)
            .then(response => response.json()) //convertimos la respuesta en formato json
            .then(data => {
                listadoLibros.innerHTML = '';
                allBooks = data;

                for(const book of data){
                    const row = document.createElement('tr');

                    //asignamos html a la fila con los datos del libro
                    row.innerHTML = `
                        <td>${book.titleBook}</td>
                        <td>${book.nameAuthor}</td>
                        <td>${book.chapters}</td>
                        <td>${book.pages}</td>
                        <td>$${book.price}</td>`;

                    listadoLibros.appendChild(row);
                }
            })
            .catch(error => console.error('Error al obtener los datos: ', error));
    }

    //llamamos a la funcion fetchBooks para cargar los libros a la página
    fetchBooks();

    //evento campo de búsqueda
    bookTitle.addEventListener('input', function(){
        const searchTitle = bookTitle.value.toLowerCase();
        
        var libros = [];
        for(const row of allBooks){
            const title = row.titleBook.toLowerCase();
            
            if(title.includes(searchTitle)){
                libros.push(title);
            }
        }
        while (listadoLibros.firstChild) {  listadoLibros.removeChild(listadoLibros.firstChild);  }
        for(const name of libros){
            fetch('http://localhost:5140/api/searchBook?titleBook=' + name)
            .then(response => response.json())
            .then(book => {
                console.log(book);
                htmlCode = `<tr><td>${book.titleBook}</td>
                                <td>${book.nameAuthor}</td>
                                <td>${book.chapters}</td>
                                <td>${book.pages}</td>
                                <td>$ ${book.price}</td></tr>`;
                                
                            listadoLibros.insertAdjacentHTML("beforeend", htmlCode);
                                
                htmlCode = ``;
            })
    }})
})