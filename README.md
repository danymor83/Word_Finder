Breve explicación del código.
- Inicialice las variable y cree dos constantes (FILA y COLUMNA) para crear la matriz
- En el constructor:
    - Validé que la matriz que viene como parámetro no sea nula y que sea de 64x64
    - TrieNode: este método es para crear una estructura donde almacelará las palabras de la matriz
    - ConvertirAMatriz: este método es para transformar la lista de cadenas matrixList en una matriz
      bidimensional de caracteres (char).
    - ConstruirTrie: Este método recorrerá cada palabra y la insertará en el Trie, estableciendo
      conexiones entre los nodos para representar las letras de las palabras.
  - Método Find:
     - Busca palabras en la matriz y devuelve las más repetidas
     - Dictionary: es para almacenar ocurrencias de palabras durante la busqueda.
     - foreach: recorre el Trie para cada carácter en la palabra.
     - GetTopNWords: obtiene las 10 palabras más repeditas.
  - Método BuildTrie:
     - Construye una estructura Trie a partir de una colección de palabras.
     - foreach: recorre el Trie para cada carácter en la palabra, si el siguiente nodo no existe, crea
       un nuevo nodo.
  - Inner Class TrieNode
     - Es una estructura para almacenar y buscar palabras.
  
