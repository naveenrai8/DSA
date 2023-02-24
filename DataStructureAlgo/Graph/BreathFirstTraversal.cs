namespace DataStructureAlgo.Graph;

public class BreathFirstTraversal
{
    public void Run()
    {
        Bfs(new IList<int>[]
        {
            new List<int>(){1,2},
            new List<int>(){4},
            new List<int>(){3},
            new List<int>(){5}
        }, 6);
        Console.WriteLine();
    }

    private void Bfs(IList<int>[] adj, int nodes)
    {
        var visited = new bool[nodes];
        var queue = new Queue<int>();
        queue.Enqueue(0);
        while (queue.Any())
        {
            var element = queue.Dequeue();
            visited[element] = true;
            Console.Write($"{element}..");
            if (element > adj.Length-1)
                continue;
            foreach (var nbr in adj[element])
            {
                if (visited[nbr])
                    continue;
                queue.Enqueue(nbr);
            }
        }
    }
}