using ShisokuEnzan;

int digit = 10000;
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
	catch (Exception)
	{

	}
}