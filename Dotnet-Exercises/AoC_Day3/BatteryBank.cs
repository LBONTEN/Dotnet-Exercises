
class BatteryBank
{
    int BATTERY_CAPACITY = 12;
    private short[][] banks;
    public BatteryBank(string inputFile)
    {
        string text = File.ReadAllText(inputFile);
        string[] bankStrings = text.Split('\n')
            .Where(s => !string.IsNullOrWhiteSpace(s))
            .ToArray();
        banks = bankStrings
            .Select(s => s.Select(c => short.Parse(c.ToString())).ToArray())
            .ToArray();
    }

    public long GetOptimalJoltage()
    {
        List<long> solution = new List<long>();
        foreach (short[] bank in banks)
        {
            List<short> batteries = new List<short>();
            short[] remaining = bank;
            for(int i = 0; i < BATTERY_CAPACITY; i++)
            {
                short max = remaining[..(remaining.Length + 1 - (BATTERY_CAPACITY - i))].Max();
                remaining = remaining[(remaining.IndexOf(max) + 1)..];
                batteries.Add(max);
            }
            long result = Convert.ToInt64(string.Join("", batteries));
            solution.Add(result);
        }
        return solution.Sum();
    }
}
