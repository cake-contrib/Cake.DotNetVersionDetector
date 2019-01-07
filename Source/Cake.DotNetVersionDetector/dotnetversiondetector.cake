#r "./bin/Debug/netstandard2.0/Cake.DotNetVersionDetector.dll"

try
{
	DotNetVersionDetector("./../output.txt");
}
catch(Exception ex)
{
    Error("{0}", ex);
}

Console.ReadLine();
