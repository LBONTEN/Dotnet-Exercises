
class CephalopodCalculatorMkII
{

    private List<List<long>> terms;
    private char[] operands;

    public CephalopodCalculatorMkII(string inputFile)
    {
        string text = File.ReadAllText(inputFile);
        char[][] rows = text.Split('\n')
            .Where(s => !string.IsNullOrWhiteSpace(s))
            .Select(s => s.ToCharArray())
            .ToArray();

        int numTerms = rows.Length - 1;
        int numCharacters = rows[0].Length;

        // Join each number as strings separated by blank strings
        string[] stringTerms = Enumerable.Range(0, numCharacters)
            .Select(c => string.Join("", Enumerable.Range(0, numTerms).Select(t => rows[t][c]).ToArray()))
            .ToArray();

        terms = SplitIntoTerms(stringTerms);
        operands = rows[rows.Length - 1]
            .Where(s => s != ' ')
            .ToArray();

    }

    private static List<List<long>> SplitIntoTerms(string[] inputString)
    {
        List<long> termGroup = new List<long>();
        List<List<long>> results = new List<List<long>>();

        foreach (string s in inputString)
        {
            if (string.IsNullOrWhiteSpace(s))
            {
                results.Add(termGroup);
                termGroup = new List<long>();
            }
            else
            {
                termGroup.Add(Convert.ToInt64(s));
            }
        }

        if (termGroup.Count > 0)
        {
            results.Add(termGroup);
        }

        return results;
    }


    public long SolveInput()
    {
        long result = 0;
        for (int i = 0; i < terms.Count; i++)
        {
            long solution = terms[i][0];
            for (int j = 1; j < terms[i].Count; j++)
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
