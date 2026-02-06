
// Day 1 
Dial dial = new Dial();

List<(char, int)> instructions = new List<(char, int)>();
const string fileNameDay1 = "Aoc_Day1/input.txt";
instructions = Dial.ParseInstructions(fileNameDay1);
int result = dial.SolveInstructions(instructions);

Console.WriteLine("Result 1 is: " + Convert.ToString(result));

// Day 1 Part 2
DialMKII newDial = new DialMKII();

List<(char, int)> instructions2 = new List<(char, int)>();
instructions2 = DialMKII.ParseInstructions(fileNameDay1);
int result2 = newDial.SolveInstructions(instructions2);

Console.WriteLine("Result 2 is: " + Convert.ToString(result2));

// Day 2 
const string fileNameDay2 = "Aoc_Day2/input.txt";
List<(long, long)> idRanges = IDValidator.ParseInput(fileNameDay2);
long result3 = IDValidator.ValidateIds(idRanges);

Console.WriteLine("Result day 3 is: " + Convert.ToString(result3));

//  Day 3 
const string fileNameDay3 = "AoC_Day3/input.txt";
BatteryBank bank = new BatteryBank(fileNameDay3);
long result4 = bank.GetOptimalJoltage();

Console.WriteLine("Result day 4 is: " + Convert.ToString(result4));
