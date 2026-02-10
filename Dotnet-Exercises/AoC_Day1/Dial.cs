
class Dial
{
    private int pointer = 50;
    private const int range = 100;

    public void Rotate(char direction, int amount)
    {
        if (direction != 'L' && direction != 'R')
        {
            return;
        }

        switch (direction)
        {
            case 'L':
                {
                    pointer -= amount;
                    while(pointer < 0)
                    {
                        pointer += range;
                    }
                    break;
                }
            case 'R':
                {
                    pointer += amount;
                    while(pointer >= range)
                    {
                        pointer -= range;
                    }
                    break;
                }
            default:
                {
                    break;
                }
        }
    }

    public static List<(char, int)> ParseInstructions(string fileName)
    {
        string text = File.ReadAllText(fileName);
        string[] unparsedInstructions = text.Split('\n');

        var instructions = new List<(char, int)>();
        foreach (var item in unparsedInstructions)
        {
            if (item.Length > 0 && (item[0] == 'L' || item[0] == 'R'))
            {
                instructions.Add((item[0], Convert.ToInt32(item.Substring(1))));
            }
        }

        return instructions;
    }

    public int SolveInstructions(List<(char, int)> instructions)
    {
        int result = 0;
        foreach (var instruction in instructions)
        {
            Rotate(instruction.Item1, instruction.Item2);
            if (this.pointer == 0)
            {
                result++;
            }
        }
        return result;
    }
}
