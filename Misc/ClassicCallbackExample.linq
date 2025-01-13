<Query Kind="Program" />

void Main()
{
	Test();
}


public delegate void WorkCompletedCallBack(string result);

public void DoWork(WorkCompletedCallBack callback)
{
	callback("Hello World");
}

public void Test()
{
	WorkCompletedCallBack callback = TestCallBack;
	DoWork(callback);
}

public void TestCallBack(string result)
{
	result.Dump();
}