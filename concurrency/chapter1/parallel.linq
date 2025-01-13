<Query Kind="Program">
  <Namespace>System.Drawing.Drawing2D</Namespace>
  <Namespace>System.Threading.Tasks</Namespace>
</Query>

void Main()
{
	
}

void RoatatMatricies(IEnumerable<Matrix> matricies, float degrees)
{
	Parallel.ForEach(matricies, matrix => matrix.Rotate(degrees));
}

/////////PLINQ

IEnumerable<bool> PrimalityTest(IEnumerable<int> values)
{
	return values.AsParallel().Select(value => IsPrime(value));
}

bool IsPrime(int value)
{
	throw new NotImplementedException();
}

//////Task Parallelism
void PeocessArray(double[] array)
{
	Parallel.Invoke(
		() => ProcessPartialArray(array, 0, array.Length / 2),
		() => ProcessPartialArray(array, array.Length/2, array.Length)
	);
}

void ProcessPartialArray(double[] array, int begin, int end)
{
	//CPU-intensiver processing
}
