using ShisokuEnzan;

var e = new EnzanPoint("1") / new EnzanPoint("3") - new EnzanPoint("100");
Console.WriteLine(e.num + " " + e.deno);

var e2 = new EnzanPoint("1") / new EnzanPoint("3");
(var u, var l) = e2.ToRealNumber(10);
Console.WriteLine(u + " " + l);

var e3 = new EnzanPoint("1") / new EnzanPoint("3");
Console.WriteLine(((float)e3).ToString("F39"));

var e4 = new EnzanPoint("1") / new EnzanPoint("3");
Console.WriteLine(((double)e3).ToString("F39"));

Enzan.Calc("(-5) * ((100 + 100.1) * + 5) / 10 + - 23.3");