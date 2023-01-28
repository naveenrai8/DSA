namespace DataStructureAlgo.RecursionBacktracking;
/// <summary>
/// 
/// </summary>
public class SubSetSum
{
    public void Run()
    {
        PickDontPick(new []{1,2,3}, 0, 0);
    }

    /// <summary>
    /// TC: 2^n
    /// SC: O(2^N) as we are simply printing it. but why 2^N because we are printing the sum of all the subset and number of subset are 2^N. 
    /// </summary>
    /// <param name="nums"></param>
    /// <param name="index"></param>
    /// <param name="sum"></param>
    private void PickDontPick(int[] nums, int index, int sum)
    {
        if (index > nums.Length - 1)
        {
            Console.Write($"->{sum}");
            return;
        }

        sum += nums[index];
        PickDontPick(nums, index+1, sum);
        sum -= nums[index];
        PickDontPick(nums, index+1, sum);
    }
}