<Query Kind="Program" />

void Main()
{
	int[] test = new int[] {1,2,3,4,6,7,8,9};
	
	BinarySearch(5, test).Dump();
}

//O(lg(n)) 
// Define other methods and classes here
public static bool BinarySearch(int target, int[] nums)
{
	int floorIndex = -1;
	int ceilingIndex = nums.Length;
	
	
	while(floorIndex + 1 < ceilingIndex)
	{
		int distance = ceilingIndex - floorIndex;
		int halfDistance = distance / 2;
		int guessIndex = floorIndex + halfDistance;
		
		int guessValue = nums[guessIndex];
		
		if(guessValue == target)
		{
			return true;
		}
		
		if(guessValue > target)
		{
			ceilingIndex = guessIndex;
		}
		else
		{
			floorIndex = guessIndex;
		}
	}
	
	return false;
}