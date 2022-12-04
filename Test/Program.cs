using ShisokuEnzan;

var e = new EnzanPoint("1") / new EnzanPoint("3") - new EnzanPoint("100");
Console.WriteLine(e.num + " " + e.deno);

var e2 = new EnzanPoint("1000") / new EnzanPoint("3");
(var u, var l) = e2.ToRealNumber(1000);
Console.WriteLine(u + " " + l);

Enzan.Calc("(-5) * ((100 + 100.1) * + 5) / 10 + - 23.3");