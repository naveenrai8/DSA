// See https://aka.ms/new-console-template for more information

using DataStructureAlgo.RecursionBacktracking;

var obj = new PermutationsLeetCode();
obj.Run();

var o = Permute(new[] {1, 2, 3});
Console.WriteLine();

 IList<IList<int>> Permute(int[] nums) {
    var output = new List<IList<int>>();

    Permutation(nums, 0, output);
    return output;
}

 void Permutation(int[] arr, int index, IList<IList<int>> output)
{
    if (index > arr.Length-1)
    {
        output.Add(arr.ToList());
        return;
    }
    for(var itr = index; itr <= arr.Length-1; itr++)
    {
        (arr[index], arr[itr]) = (arr[itr], arr[index]);
        Permutation(arr, index+1, output);
        (arr[itr], arr[index]) = (arr[index], arr[itr]);
    }
}
