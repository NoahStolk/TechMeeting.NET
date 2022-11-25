Console.WriteLine($"Good {DateTime.Now.Hour switch
{
	< 6 => "night",
	< 12 => "morning",
	< 18 => "afternoon",
	_ => "evening",
}}");
