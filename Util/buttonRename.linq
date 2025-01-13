<Query Kind="Statements" />

string path = @"J:\Projects\Images\from_camera\buttons";
string path2 = @"J:\Projects\Images\from_camera\buttons\rename";
var dir = Directory.GetFiles(path);
int count = 1;
foreach(var fn in dir)
{
	System.IO.File.Copy(fn, string.Format("{0}\\{1}.jpg",path2,count));
	count++;
}