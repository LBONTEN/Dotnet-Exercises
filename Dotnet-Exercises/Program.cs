
Console.WriteLine("Starting now.");


// Day 1 
Dial dial = new Dial();

List<(char, int)> instructions = new List<(char, int)>();
string fileName = "Aoc_Day1/input.txt";
instructions = Dial.ParseInstructions(fileName);
int result = dial.SolveInstructions(instructions);

Console.WriteLine("Result is:" + Convert.ToString(result));

// Day 1 Part 2
DialMKII newDial = new DialMKII();

List<(char, int)> instructions2 = new List<(char, int)>();
string fileName2 = "Aoc_Day2/input.txt";
instructions2 = DialMKII.ParseInstructions(fileName2);
int result2 = newDial.SolveInstructions(instructions2);

Console.WriteLine("Result is:" + Convert.ToString(result2));



