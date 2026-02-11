
class TachyonManifold
{
    private char[][] diagram;

    public TachyonManifold(string inputFile)
    {
        string text = File.ReadAllText(inputFile);
        diagram = text.Split('\n')
            .Where(s => !string.IsNullOrWhiteSpace(s))
            .Select(s => s.ToCharArray())
            .ToArray();
    }

    private (int y, int x) FindStartPosition()
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

    public int Solve()
    {
        int result = 0;
        HashSet<(int y, int x)> positions = new HashSet<(int y, int x)> { FindStartPosition() };
        for (int i = 1; i < diagram.Length; i++)
        {
            (int y, int x)[] rowPositions = positions.Where(pos => pos.y == i - 1).ToArray();
            foreach ((int y, int x) position in rowPositions)
            {
                switch (diagram[i][position.x])
                {
                    case '^':
                        {
                            positions.Add((i, position.x + 1));
                            positions.Add((i, position.x - 1));
                            result++;
                            break;
                        }
                    case '.':
                        {
                            positions.Add((i, position.x));
                            break;
                        }
                    default:
                        {
                            break;
                        }
                }
            }
        }
        return result;
    }
}
