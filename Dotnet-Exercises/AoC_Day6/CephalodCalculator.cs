
class CephalopodCalculator
{

    private long[][] terms;
    private char[] operands;

    public CephalopodCalculator(string inputFile)
    {
        string text = File.ReadAllText(inputFile);
        string[] rows = text.Split('\n')
            .Where(s => !string.IsNullOrWhiteSpace(s))
            .ToArray();

        List<long[]> results = new List<long[]>();
        for (int i = 0; i < rows.Length - 1; i++)
        {
            string row = rows[i];
            string[] input = row.Split(" ")
                .Where(s => !string.IsNullOrWhiteSpace(s))
                .ToArray();

            long[] newInput = input.Select(r => Convert.ToInt64(r)).ToArray();
            results.Add(newInput);
        }

        int numColumns = results[0].Length;
        terms = Enumerable.Range(0, numColumns)
            .Select(col => results.Select(row => row[col]).ToArray())
            .ToArray();

        operands = rows[rows.Length - 1].Split(" ")
            .Where(s => !string.IsNullOrWhiteSpace(s))
            .Select(char.Parse)
            .ToArray();
    }

    public long SolveInput()
    {
        long result = 0;
        for (int i = 0; i < terms.Length; i++)
        {
            long solution = terms[i][0];
            for (int j = 1; j < terms[i].Length; j++)
            {
                switch (operands[i])
                {
                    case '*':
                        {
                            solution *= terms[i][j];
                            break;
                        }
                    case '+':
                        {
                            solution += terms[i][j];
                            break;
                        }
                    default:
                        {
                            break;
                        }
                }
            }
            result += solution;
        }
        return result;
    }
}
