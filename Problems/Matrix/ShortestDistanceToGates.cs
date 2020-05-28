using System.Collections.Generic;
using System.IO;

namespace Problems.Matrix
{
    public class ShortestDistanceToGates
    {
        //https://leetcode.com/problems/walls-and-gates/
        private int[][] _rooms;
        private bool[][] _visited;
        
        public void WallsAndGates(int[][] rooms)
        {
            _rooms = rooms;
            _visited = new bool[_rooms.Length][];
            for (int i = 0; i < _rooms.Length; i++)
            {
                _visited[i]= new bool[_rooms[i].Length];
            }
            //find the gates and perform a BFS from each gate
            var roomQ = GetDoors(rooms);

            while (roomQ.Count > 0)
            {
                var count = roomQ.Count;
                for (int c = 0; c < count; c++)
                {
                    var (i, j) = roomQ.Dequeue();
                    var distance = _rooms[i][j];
                
                    TryEnqueue(roomQ, i, j+1, distance+1);
                    TryEnqueue(roomQ, i, j-1, distance+1);
                    TryEnqueue(roomQ, i-1, j, distance+1);
                    TryEnqueue(roomQ, i+1, j, distance+1);
                }    
            }
            
        }

        
        private void TryEnqueue(Queue<(int, int)> queue, int i, int j, int newDistance)
        {
            if(!IsInsideGrid(i,j) ) return;
            if (_visited[i][ j] || _rooms[i][j]< 0) return;
            
            _visited[i][ j] = true;
            queue.Enqueue((i,j));
            if (_rooms[i][j] > newDistance)
                _rooms[i][j] = newDistance;
        }

        private bool IsInsideGrid(int i, int j)
        {
            var n = _rooms.Length;
            if (n < 1) return false;
            return i >= 0 && j >= 0 && i < n && j < _rooms[0].Length;
        }
        
        private static Queue<(int, int)> GetDoors(int[][] rooms)
        {
            var queue = new Queue<(int, int)>();

            for (int i = 0; i < rooms.Length; i++)
            {
                for (int j = 0; j < rooms[i].Length; j++)
                {
                    if (rooms[i][j] == 0) queue.Enqueue((i, j));
                }
            }

            return queue;
        }
    }
}