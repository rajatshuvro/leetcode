using System.Collections.Generic;

namespace Problems
{
    public class KeysAndRooms
    {
        //https://leetcode.com/problems/keys-and-rooms/
        public bool CanVisitAllRooms(IList<IList<int>> rooms)
        {
            //we will do a DFS on the graph to see which rooms are reachable
            var visitedRooms = new HashSet<int>();
            var dfsStack = new Stack<int>();
            dfsStack.Push(0);

            while (dfsStack.Count > 0)
            {
                var currentRoom = dfsStack.Pop();
                visitedRooms.Add(currentRoom);
                foreach (var room in rooms[currentRoom])
                {
                    if(visitedRooms.Contains(room)) continue;
                    dfsStack.Push(room);
                }
            }
            
            for(var i=0; i < rooms.Count; i++)
                if (!visitedRooms.Contains(i))
                    return false;

            return true;
        }
    }
}