namespace DataStructureAlgo.RecursionBacktracking;
/// <summary>
/// given an array of N elements, return the number of subsequence whose sum is K
/// </summary>
public class SubsequenceWithSumK
{
    public void Run()
    {
        //array empty
        Console.WriteLine(CountUsingBacktracking(new int[2], 0, 3));
        PrintAllPathsUsingBacktracking(new int[2], 0, 3, new LinkedList<int>());
        
        //array does not contains answer
        Console.WriteLine();
        Console.WriteLine(CountUsingBacktracking(new []{1,2}, 0, 4));
        PrintAllPathsUsingBacktracking(new []{1,2}, 0, 4, new LinkedList<int>());

        
        //whole array contains the answer
        Console.WriteLine();
        Console.WriteLine(CountUsingBacktracking(new []{1,2}, 0, 3));
        PrintAllPathsUsingBacktracking(new []{1,2}, 0, 3, new LinkedList<int>());
        
        //only one subset is part of the answer
        Console.WriteLine();
        Console.WriteLine(CountUsingBacktracking(new []{1,2, 4}, 0, 3));
        PrintAllPathsUsingBacktracking(new []{1,2, 4}, 0, 3, new LinkedList<int>());

        //more than one subset is part of the answer
        Console.WriteLine();
        Console.WriteLine(CountUsingBacktracking(new []{3,1,1,4,2,3}, 0, 3));
        PrintAllPathsUsingBacktracking(new []{3,1,1,4,2,3}, 0, 3, new LinkedList<int>());
        PrintAnySubsequenceBacktracking(new []{1,3,1,1,4,2,3}, 0, 3, new LinkedList<int>());
    }

    // in backtracking, pick and dont pick choices made at every level and the final decision is made once all the elements are traversed.
    private int CountUsingBacktracking(int[] arr, int index, int sum)
    {
        if (index > arr.Length - 1)
        {
            return sum == 0 ? 1 : 0;
        }

            //pick considering current element be part of the answer/subsequence
        var pick = CountUsingBacktracking(arr, index + 1, sum - arr[index]);
        
        //dont pick means current element is not part of the answer/subsequence
        var dontPick = CountUsingBacktracking(arr, index + 1, sum);
        return pick + dontPick;
    }

    private void PrintAllPathsUsingBacktracking(int[] arr, int index, int sum, LinkedList<int> list)
    {
        if (index > arr.Length - 1)
        {
            if (sum != 0) return;
            foreach (var element in list)
            {
                Console.Write($"{element}->");
            }
            Console.WriteLine();
            return;
        }
        list.AddLast(arr[index]);
        PrintAllPathsUsingBacktracking(arr, index+1, sum-arr[index], list);
        list.RemoveLast();
        PrintAllPathsUsingBacktracking(arr, index+1, sum, list);
    }

    private bool PrintAnySubsequenceBacktracking(int[] arr, int index, int sum, LinkedList<int> list)
    {
        if (index >= arr.Length)
        {
            if (sum != 0) return false;
            foreach (var element in list)
            {
                Console.Write($"{element}->");
            }
            Console.WriteLine();
            return true;
        }

        list.AddLast(arr[index]);
        if (PrintAnySubsequenceBacktracking(arr, index + 1, sum - arr[index], list))
            return true;
        list.RemoveLast();
        return PrintAnySubsequenceBacktracking(arr, index + 1, sum, list);
    }
}