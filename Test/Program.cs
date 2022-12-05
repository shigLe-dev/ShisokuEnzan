using ShisokuEnzan;

int digit = 10000;
EnzanPoint p = (new EnzanPoint(13) / new EnzanPoint(3)) % (new EnzanPoint(2) / new EnzanPoint(7));
Console.WriteLine(p.num + " / " + p.deno);
while (true)
{
	Console.Write(">>>");
    string code = Console.ReadLine() ?? "";
	try
	{
        EnzanPoint point = Enzan.Calc(code);
		Console.WriteLine(point.num + " / " + point.deno);
		Console.WriteLine(point.ToString(digit));
    }
	catch (Exception e)
	{
		Console.WriteLine(e.Message);
	}
}