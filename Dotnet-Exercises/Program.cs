
// Day 1 
Dial dial = new Dial();

List<(char, int)> instructions = new List<(char, int)>();
string fileNameDay1 = "Aoc_Day1/input.txt";
instructions = Dial.ParseInstructions(fileNameDay1);
int result = dial.SolveInstructions(instructions);

Console.WriteLine("Result 1 is:" + Convert.ToString(result));

// Day 1 Part 2
DialMKII newDial = new DialMKII();

List<(char, int)> instructions2 = new List<(char, int)>();
instructions2 = DialMKII.ParseInstructions(fileNameDay1);
int result2 = newDial.SolveInstructions(instructions2);

Console.WriteLine("Result 2 is:" + Convert.ToString(result2));

// Day 2 
string fileNameDay2 = "Aoc_Day2/input.txt";
List<(long, long)> idRanges = IDValidator.ParseInput(fileNameDay2);
long result3 = IDValidator.ValidateIds(idRanges);

Console.WriteLine("Result day 2 is:" + Convert.ToString(result3));


