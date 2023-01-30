namespace DataStructureAlgo.RecursionBacktracking;

public class PermutationsLeetCode
{
    public void Run()
    {
        PermutationUsingBooleanArray(new []{1,2,3}, new LinkedList<int>(), new bool[3]);
        Console.WriteLine();
        PermutationUsingSwapping(new[] {1, 2, 3}, 0);
    }

    /// <summary>
    /// TC: O(n!) * O(n)
    ///     n! because for every n at level 1, we are making n-1 (as the number picked at level 1 is not going to be picked up again). at next level, n-2 number are being picked and so on. hence n*(n-1)*(n-2)*.. = n!
    ///     n because we need to copy the list to output list which is O(n) operations
    /// SC: O(n) + O(n) + O(n!)*O(n)
    ///     first O(n) is for stack space being used during recursion call
    ///     second O(n) is for list being used to store the combo
    ///     third O(n!) is the output list which contains the count of list * O(n) for elements in each list in output
    /// </summary>
    /// <param name="arr"></param>
    /// <param name="list"></param>
    /// <param name="picked"></param>
    private void PermutationUsingBooleanArray(int[] arr, LinkedList<int> list, bool[] picked)
    {
        if (list.Count == arr.Length)
        {
            foreach (var element in list)
            {
                Console.Write($"{element}->");
            }
            Console.WriteLine();
        }
        
        for (var i = 0; i < arr.Length; i++)
        {
            if (picked[i])// if its already picked
                continue;
            picked[i] = true;
            list.AddLast(arr[i]);
            PermutationUsingBooleanArray(arr, list, picked);
            list.RemoveLast();
            picked[i] = false;
        }
    }

    /// <summary>
    /// TC: O(n!) * O(n)
    /// SC: O(N)
    /// </summary>
    /// <param name="arr"></param>
    /// <param name="index"></param>
    private void PermutationUsingSwapping(int[] arr, int index)
    {
        if (index > arr.Length-1)
        {
            foreach (var element in arr)
            {
                Console.Write($"{element}->");
            }
            Console.WriteLine();
            return;
        }

        for (var i = index; i < arr.Length; i++)
        {
            (arr[index], arr[i]) = (arr[i], arr[index]);
            PermutationUsingSwapping(arr, index+1);
            (arr[i], arr[index]) = (arr[index], arr[i]);
        }
    }
}