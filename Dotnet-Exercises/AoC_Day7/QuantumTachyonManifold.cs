
class QuantumTachyonManifold
{
    private char[][] diagram;
    private Dictionary<(int, int), long> visited = new Dictionary<(int, int), long>();

    public QuantumTachyonManifold(string inputFile)
    {
        string text = File.ReadAllText(inputFile);
        diagram = text.Split('\n')
            .Where(s => !string.IsNullOrWhiteSpace(s))
            .Select(s => s.ToCharArray())
            .ToArray();
    }

    private (int, int) FindStartPosition()
    {
        for (int i = 0; i < diagram.Length; i++)
        {
            int foundPosition = diagram[i].IndexOf('S');
            if (foundPosition >= 0)
            {
                return (i, foundPosition);

            }
        }
        return (0, 0);
    }
    public long Solve()
    {
        return EnterTimeline(FindStartPosition());
    }

    public long EnterTimeline((int y, int x) position)
    {
        if (visited.ContainsKey(position))
            return visited[position];

        int i = position.y + 1;
        while (i < diagram.Length)
        {
            switch (diagram[i][position.x])
            {
                case '^':
                    {
                        long result = EnterTimeline((i, position.x - 1)) + EnterTimeline((i, position.x + 1));
                        visited[position] = result;
                        return result;
                    }
                default:
                    {
                        i++;
                        break;
                    }
            }
        }

        visited[position] = 1;
        return 1;
    }
}
