
class IngredientManager
{
    (long start, long end)[] freshIdRanges;
    long[] ingredientIds;

    public IngredientManager(string inputFile)
    {
        string text = File.ReadAllText(inputFile);
        string[] rows = text.Split('\n');
        int delimiter = Array.FindIndex(rows, (s) => s == "");

        freshIdRanges = rows[..delimiter]
            .Select(r =>
            {
                string[] value = r.Split("-");
                return (
                    Convert.ToInt64(value[0]),
                    Convert.ToInt64(value[1])
                );
            })
            .ToArray();

        ingredientIds = rows[(delimiter + 1)..]
            .Where(r => !string.IsNullOrWhiteSpace(r))
            .Select(r => Convert.ToInt64(r)).ToArray();
    }

    public int CheckFreshIngredients()
    {
        int result = 0;
        foreach (long i in ingredientIds)
        {
            foreach ((long start, long end) range in freshIdRanges)
            {
                if (i >= range.start && i <= range.end)
                {
                    result++;
                    break;
                }
            }
        }

        return result;
    }

    public long GetAmountOfFreshIds()
    {
        long result = 0;
        // sort ranges by their start value
        (long start, long end)[] sortedRanges = freshIdRanges.OrderBy(r => r.start).ToArray();

        for (int i = 0; i < sortedRanges.Length; i++)
        {   // Track start and end of each range 
            (long start, long end) range = sortedRanges[i];

            // find the next range to conisder. Ranges we dont consider are the ones that are fully encapsulated by the current range
            while (i < (sortedRanges.Length - 1) && sortedRanges[i + 1].end < range.end)
            {
                i++;
            }

            if (i >= (sortedRanges.Length - 1))
            {
                result += range.end + 1 - range.start;
                break;
            }
            
            (long start, long end) nextRange = sortedRanges[i + 1];

            // Check if its correlating end is smaller than the next start. 
            if (range.end < nextRange.start)
            {   // if it is there is a gap. deduct the difference between this end and the smallest other start from the end result.
                result += range.end + 1 - range.start;
            }
            else
            {   // if it is go to next start
                result += nextRange.start - range.start;
            }
        }

        return result;
    }

}
