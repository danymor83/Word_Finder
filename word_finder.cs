using System;
using System.Collections.Generic;
using System.Linq;

public class WordFinder
{
    private TrieNode root;
    private char[,] matrix;
    private const int FILA = 64;
    private const int COLUMNA = 64;

    public WordFinder(IEnumerable<string> matrix)
    {
        if (matrix == null)
        {
            throw new ArgumentNullException(nameof(matrix));
        }

        List<string> matrixList = new List<string>(matrix);

        if (matrixList.Count != FILA || matrixList.Any(row => row.Length != COLUMNA))
        {
            throw new ArgumentException($"El tamaño de la matriz debe ser de {FILA}x{COLUMNA}.");
        }

        this.root = new TrieNode();
        this.matrix = ConvertToMatrix(matrixList);
        BuildTrie(matrixList);
    }

    public IEnumerable<string> Find(IEnumerable<string> wordstream)
    {
        if (wordstream == null)
        {
            throw new ArgumentNullException("wordstream", "Wordstream no puede ser nulo.");
        }

        Dictionary<string, int> wordCount = new Dictionary<string, int>();

        foreach (string word in wordstream)
        {
            TrieNode currentNode = root;

            foreach (char c in word)
            {
                int index = c - 'A';
                if (currentNode.Children[index] == null)
                {
                    
                    break;
                }

                currentNode = currentNode.Children[index];
            }

            if (currentNode != root)
            {
                string foundWord = currentNode.Word;
                if (!wordCount.ContainsKey(foundWord))
                {
                    wordCount[foundWord] = 1;
                }
            }
        }

        List<string> result = GetTopNWords(wordCount, 10);
        return result;
    }

    private void BuildTrie(IEnumerable<string> words)
    {
        foreach (string word in words)
        {
            TrieNode currentNode = root;

            foreach (char c in word)
            {
                int index = c - 'A';

                if (currentNode.Children[index] == null)
                {
                    currentNode.Children[index] = new TrieNode();
                }

                currentNode = currentNode.Children[index];
            }

            currentNode.Word = word;
        }
    }

    private char[,] ConvertToMatrix(List<string> matrixList)
    {
        char[,] resultMatrix = new char[FILA, COLUMNA];

        for (int i = 0; i < FILA; i++)
        {
            string row = matrixList[i];

            for (int j = 0; j < COLUMNA; j++)
            {
                resultMatrix[i, j] = row[j];
            }
        }

        return resultMatrix;
    }

    private List<string> GetTopNWords(Dictionary<string, int> wordCount, int n)
    {
        List<string> result = new List<string>();

        foreach (var entry in wordCount.OrderByDescending(pair => pair.Value).Take(n))
        {
            result.Add(entry.Key);
        }

        return result;
    }

    private class TrieNode
    {
        public TrieNode[] Children;
        public string Word;

        public TrieNode()
        {
            this.Children = new TrieNode[26];
            this.Word = null;
        }
    }
}
