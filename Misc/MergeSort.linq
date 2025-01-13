<Query Kind="Program" />

void Main()
{
	(3/2).Dump();
	int[] test = new int[] {5,4,23};
	
	MergeSort(test).Dump();
}

// Define other methods and classes here
public static T[] MakeSubarray<T>(T[] source, int begin, int end)
{
	if(source == null)
	{
		throw new ArgumentNullException( "Source array is null");
	}
	if(begin > source.Length)
	{
		throw new ArgumentOutOfRangeException("Begin index is to big");
	}
	if(end > source.Length)
	{
		throw new ArgumentOutOfRangeException("End index is to big");
	}
	if(begin > end)
	{
		throw new ArgumentOutOfRangeException("Begin index is larger than end index");
	}
	
	T[] destination = new T[end - begin];
	if(destination.Length > 0)
	{
		Array.Copy(source, begin,destination,0,destination.Length);
	}
	
	return destination;
}

public int[] MergeSort(int[] arrayToSort)
{
	//BASE CASE: arrays with fewer than 2 elements are sorted
	if(arrayToSort.Length < 2)
	{
		return arrayToSort;
	}
	
	int midIndex = arrayToSort.Length / 2;
	
	int[] left = MakeSubarray(arrayToSort, 0, midIndex);
	int[] right = MakeSubarray(arrayToSort, midIndex, arrayToSort.Length);
	
	int[] sortedLeft = MergeSort(left);
	int[] sortedRight = MergeSort(right);
	
	int[] sortedArray = new int[arrayToSort.Length];
	
	int currentLeftIndex = 0;
	int currentRightIndex = 0;
	
	for(int currentSortedIndex = 0; currentSortedIndex < arrayToSort.Length; currentSortedIndex++)
	{
		if(currentLeftIndex < sortedLeft.Length
			&& (currentRightIndex >= sortedRight.Length || sortedLeft[currentLeftIndex] < sortedRight[currentRightIndex]))
		{
			sortedArray[currentSortedIndex] = sortedLeft[currentLeftIndex];
			currentLeftIndex++;
		}
		else
		{
			sortedArray[currentSortedIndex] = sortedRight[currentRightIndex];
			currentRightIndex++;
		}
	}
	
	return sortedArray;
}