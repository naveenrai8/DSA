using System.Collections;

namespace DataStructureAlgo.Graph;

public class DepthFirstSearchTraversal
{
    public void Run()
    {
        var adj = new IList<int>[10];
        adj[0] = new List<int>() {1};
        adj[1] = new List<int>() {2};
        adj[2] = new List<int>() {3};
        adj[3] = new List<int>() {4};
        adj[4] = new List<int>() {5};
        adj[5] = new List<int>() {0};
        Dfs_Recursion(0, adj, new bool[10]);

        adj = new IList<int>[]
        {
            new List<int>() {1},
            new List<int>() {2},
            new List<int>() {3},
            new List<int>() {4},
            new List<int>() {5},
            new List<int>() {0}
        };
       
        Dfs_Non_Recursion(adj);
    }

    private void Dfs_Recursion(int node, IList<int>[] adj, bool[] visited)
    {
        // this can be skipped because we are not returning anything and below foreach loop takes care of this
        // if (adj[node].Count == 0)
        //     return;

        visited[node] = true;
        Console.Write($"{node} ..");
        foreach (var nbr in adj[node])
        {
            if (visited[nbr])
                continue;
            Dfs_Recursion(nbr, adj, visited);
        }
    }

    private void Dfs_Non_Recursion(IList<int>[] adj)
    {
        var visited = new bool[adj.Length];
        var stack = new Stack<int>();
        stack.Push(0);
        while (stack.Count != 0)
        {
            var pop = stack.Pop();
            visited[pop] = true;
            Console.Write($"{pop} ..");
            foreach (var nbr in adj[pop])
            {
                if (visited[nbr])
                    continue;
                stack.Push(nbr);
            }
        }
    }
}