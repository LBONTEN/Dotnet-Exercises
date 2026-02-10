
//  Solution for Advent of Code day 2 
// https://adventofcode.com/2025/day/2

class IDValidator()
{
    public static IEnumerable<(long start, long end)> ParseInput(string fileName)
    {
        string text = File.ReadAllText(fileName);
        string[] idRangeInputs = text.Split(',');
        foreach (string input in idRangeInputs)
        {
            string[] splitInput = input.Split('-');
            yield return (Convert.ToInt64(splitInput[0]), Convert.ToInt64(splitInput[1]));
        }
    }

    public static long ValidateIds(List<(long start, long end)> idRanges)
    {
        List<long> invalidIds = new List<long>();
        foreach ((long start, long end) range in idRanges)
        {
            for (long i = range.start; i < range.end + 1; i++)
            {
                if (CheckForRepeatedSequence(i))
                {
                    invalidIds.Add(i);
                }
            }
        }
        long value = invalidIds.Sum();
        return value;
    }

    private static bool CheckForRepeatedSequence(long input)
    {
        string inputAsString = Convert.ToString(input);
        for (int i = 1; i < inputAsString.Length; i++)
        {
            if (inputAsString.Length % i == 0)
            {
                string[] sequence = inputAsString.Chunk(i)
                    .Select(element => new string(element))
                    .ToArray();

                int distinct = sequence.Distinct().Count();
                if (distinct == 1)
                {
                    return true;
                }
            }
        }
        return false;
    }
}
