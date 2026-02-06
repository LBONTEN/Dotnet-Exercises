
class PaperMatrix
{
    private char[][] field = Array.Empty<char[]>();

    public PaperMatrix(string inputFile)
    {
        string text = File.ReadAllText(inputFile);
        string[] rows = text.Split('\n')
            .Where(s => !string.IsNullOrWhiteSpace(s))
            .ToArray();
        field = rows
            .Select(s => s.Select(c => c).ToArray())
            .ToArray();
    }

    public int ClearPaper()
    {
        int result = 0;
        int availableSpots = GetAvailableSpots(true);
        while (availableSpots > 0)
        {
            result += availableSpots;
            RemoveMarkedCells();

            availableSpots = GetAvailableSpots(true);
        }

        return result;
    }

    private void TraverseField(Action<int, int> cellAction)
    {
        for (int y = 0; y < field.Length; y++)
        {
            for (int x = 0; x < field[y].Length; x++)
            {
                cellAction(x, y);
            }
        }
    }

    private void RemoveMarkedCells()
    {
        TraverseField((x, y) =>
        {
            if (field[y][x] == 'x')
            {
                field[y][x] = '.';
            }
        });
    }

    public int GetAvailableSpots(bool markAvailableSpots = false)
    {
        int result = 0;
        TraverseField((x, y) =>
        {
            if (field[y][x] == '@')
            {
                int occupiedSpots = CheckAdjacentSpots(x, y);
                if (occupiedSpots < 4)
                {
                    result++;
                    if(markAvailableSpots)
                    {   
                        field[y][x] = 'x';
                    }
                }
            }
        });
        return result;
    }

    private int CheckAdjacentSpots(int x, int y)
    {
        int result = 0;
        for (int dy = -1; dy <= 1; dy++)
        {
            int newY = y + dy;
            if (newY < 0 || newY >= field.Length) continue;

            for (int dx = -1; dx <= 1; dx++)
            {
                if (dx == 0 && dy == 0) continue;

                int newX = x + dx;

                if (newX < 0 || newX >= field[newY].Length) continue;
                if (field[newY][newX] == '@' ||
                    field[newY][newX] == 'x')
                {
                    result++;
                }
            }
        }
        return result;
    }
}
