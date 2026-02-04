using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography.X509Certificates;

class DialMKII
{
    private int pointer = 50;
    private const int range = 100;
    private int password = 0; 

    public void Rotate(char direction, int amount)
    {
        switch (direction)
        {
            case 'L':
                {
                    if(pointer == 0)
                    {
                        pointer += range;
                    }
                    pointer -= amount;
                    while (pointer < 0)
                    {
                        password++;
                        pointer += range;
                    }
                    break;
                }
            case 'R':
                {
                    pointer += amount;
                    while (pointer > range)
                    {
                        password++;
                        pointer -= range;
                    }
                    if (pointer == range)
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
        foreach (var instruction in instructions)
        {
            Rotate(instruction.Item1, instruction.Item2);
            if(pointer == 0)
            {
                password++;
            }
        }
        return password;
    }
}
