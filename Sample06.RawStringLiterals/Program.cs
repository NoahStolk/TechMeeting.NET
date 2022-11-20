const string pi = "3.14";

const string msg1 = """
1. Raw
	String
		Literals
""";

const string msg2 = """
					2. Raw
						String
							Literals
					""";

const string msg3 = """
3. Raw
	String
		"Literals"
""";
	
const string msg4 = """
4. Raw
	String
		\"Literals\"
""";

const string msg5 = $"""
5. Raw
	String {pi}
		\"Literals\"
""";

const string msg6 = $$"""
6. Raw
	String {{pi}}
		{Literals}
""";

const string msg7 = $$""""""
7. Raw
	String {{pi}}
		"""""{Literals}"""""
"""""";

const string msg8 = $$$$$$""""""
8. Raw
	String {{{{{{pi}}}}}}
		"""""{{{{{Literals}}}}}"""""
"""""";

const string name = "Noah";
const string json = $$""""
{
	"Name": "{{name}}"
}
"""";

Console.WriteLine(msg1);
Console.WriteLine(msg2);
Console.WriteLine(msg3);
Console.WriteLine(msg4);
Console.WriteLine(msg5);
Console.WriteLine(msg6);
Console.WriteLine(msg7);
Console.WriteLine(msg8);
Console.WriteLine();
Console.WriteLine(json);
