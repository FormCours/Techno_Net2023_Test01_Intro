using Testing_01_Intro.BLL;

Console.WriteLine("Demo de la calculatrice");

#region Input user
Console.Write("Operation : ");
string operation = Console.ReadLine() ?? string.Empty;

Console.Write("Valeur 1 : ");
double val1 = double.Parse(Console.ReadLine()!);

Console.Write("Valeur 2 : ");
double val2 = double.Parse(Console.ReadLine()!);
Console.WriteLine();
#endregion

#region Logic
Calculator calculator = new Calculator();

string resultMessage;
switch (operation)
{
	case "+":
		double result = calculator.Add(val1, val2);
		resultMessage = $"L'addition de {val1} et {val2} donne {result}.";
		break;

	default:
		resultMessage = "L'operation n'est pas supporté (╯°□°）╯︵ ┻━┻";
		break;
}
#endregion

#region Display result
Console.WriteLine("Resultat de l'operation : ");
Console.WriteLine(resultMessage);
#endregion
