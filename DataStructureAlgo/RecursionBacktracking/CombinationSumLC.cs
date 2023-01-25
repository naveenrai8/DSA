namespace DataStructureAlgo.RecursionBacktracking;

/// <summary>
/// this is the Leetcode problem.
/// https://leetcode.com/problems/combination-sum/description/
/// </summary>
public class CombinationSumLC
{
    public void Run()
    {
        var output = new List<IList<int>>();
        PickDontPickApproach(new[] { 2,3,6,7}, 0, 7, output, new LinkedList<int>());
        foreach (var list in output)
        {
            foreach (var element in list)
            {
                Console.Write($"{element} ");
            }
            Console.WriteLine();
        }
    }

    private void PickDontPickApproach(int[] arr, int index, int target, IList<IList<int>> output, LinkedList<int> list)
    {
        if (index >= arr.Length)
        {
            if (target == 0)
            {
                output.Add(list.ToList());
            }

            return;
        }

        list.AddLast(arr[index]);
        if (target >= arr[index])
            PickDontPickApproach(arr, index, target-arr[index], output, list);
        list.RemoveLast();
        PickDontPickApproach(arr, index+1, target, output, list);
    }
}