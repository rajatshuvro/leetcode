using System.Collections.Generic;
using Algorithms;
using DataStructures;

namespace Problems
{
    public class ReconstructItinerary
    {
        private const string StartAirport="JFK";
        
        //https://leetcode.com/problems/reconstruct-itinerary/
        public IList<string> FindItinerary(IList<IList<string>> tickets)
        {
            var nodes = new HashSet<GraphNode<string>>(tickets.Count+1);
            var edges = new List<DirectedEdge<string>>(tickets.Count);

            foreach (var ticket in tickets)
            {
                var source = new GraphNode<string>(ticket[0]);
                if (!nodes.TryGetValue(source, out var srcNode))
                    nodes.Add(source);
                else source = srcNode;

                var destination = new GraphNode<string>(ticket[1]);
                if (!nodes.TryGetValue(destination, out var destNode))
                    nodes.Add(destination);
                else destination = destNode;

                edges.Add(new DirectedEdge<string>(source, destination ));
            }
            var graph = new DirectedGraph<string>(nodes, edges);
            var eular = new EularianPath<string>(graph);

            return eular.GetEularianPath(StartAirport);
        }
    }
}