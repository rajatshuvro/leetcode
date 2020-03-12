using System.Collections.Generic;

namespace Problems
{

    public class WordSearchTwo
    {
        //https://leetcode.com/problems/word-search-ii/
        private char[][] _board;
        private int _n;
        private int _m;
        private Dictionary<char, List<(int, int)>> _firstCharLocations;
        private bool[][] _isUsed;
        
        public IList<string> FindWords(char[][] board, string[] words)
        {
            _board = board;
            _n = board.Length;
            _m = board[0].Length;
            
            _firstCharLocations = GetStartLocations();
            _isUsed = GetUsedMatrix();

            var foundWords = new List<string>();
            foreach (var word in words)
            {
                if(BoardContains( word)) foundWords.Add(word);
                ClearUsedMatrix();
            }

            return foundWords;
        }

        
        private bool BoardContains(string word)
        {
            if (!_firstCharLocations.TryGetValue(word[0], out var locations)) return false;

            foreach (var (x,y) in locations)
            {
                if (CheckMatchAt(x, y, word, 0)) return true;
            }

            return false;
        }

        private bool[][] GetUsedMatrix()
        {
            var isUsed = new bool[_n][];
            for (var i = 0; i < _n; i++)
                isUsed[i] = new bool[_m];
            return isUsed;
        }
        private void ClearUsedMatrix()
        {
            for (var i = 0; i < _n; i++)
            for (var j = 0; j < _m; j++)
                _isUsed[i][j] = false;
        }

        private  Dictionary<char, List<(int, int)>> GetStartLocations()
        {
            var firstCharLocations = new Dictionary<char, List<(int, int)>>(_n * _m);
            for (var i = 0; i < _n; i++)
            {
                for (var j = 0; j < _m; j++)
                {
                    if (firstCharLocations.TryGetValue(_board[i][j], out var startLocations))
                        startLocations.Add((i, j));
                    else firstCharLocations.Add(_board[i][j], new List<(int, int)>() {(i, j)});
                }
            }

            return firstCharLocations;
        }
    }
}