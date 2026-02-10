
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
int result1pt2 = newDial.SolveInstructions(instructions2);

Console.WriteLine("Result 1.2 is: " + Convert.ToString(result1pt2));

// Day 2 
const string fileNameDay2 = "Aoc_Day2/input.txt";
List<(long, long)> idRanges = IDValidator.ParseInput(fileNameDay2).ToList();
long result2 = IDValidator.ValidateIds(idRanges);

Console.WriteLine("Result day 2 is: " + Convert.ToString(result2));

//  Day 3 
const string fileNameDay3 = "AoC_Day3/input.txt";
BatteryBank bank = new BatteryBank(fileNameDay3);
long result3 = bank.GetOptimalJoltage();

Console.WriteLine("Result day 3 is: " + Convert.ToString(result3));

// Day 4
const string fileNameDay4 = "AoC_Day4/input.txt";
PaperMatrix paperMatrix = new PaperMatrix(fileNameDay4);
int result4 = paperMatrix.GetAvailableSpots();
int result4pt2 = paperMatrix.ClearPaper();

Console.WriteLine("Result day 4 is: " + Convert.ToString(result4));
Console.WriteLine("Result day 4 pt.2 is: " + Convert.ToString(result4pt2));

// Day 5 
const string fileNameDay5 = "AoC_Day5/input.txt";
IngredientManager manager = new IngredientManager(fileNameDay5);
int result5 = manager.CheckFreshIngredients();
long result5pt2 = manager.GetAmountOfFreshIds();

Console.WriteLine("Result day 5 is: " + Convert.ToString(result5));
Console.WriteLine("Result day 5 pt.2 is: " + Convert.ToString(result5pt2));

// Day 6
const string fileNameDay6 = "AoC_Day6/input.txt";
CephalopodCalculator calculator = new CephalopodCalculator(fileNameDay6);
long result6 = calculator.SolveInput();
CephalopodCalculatorMkII calculator2 = new CephalopodCalculatorMkII(fileNameDay6);
long result6pt2 = calculator2.SolveInput();

Console.WriteLine("Result day 6 is: " + Convert.ToString(result6));
Console.WriteLine("Result day 6 pt.2 is: " + Convert.ToString(result6pt2));
