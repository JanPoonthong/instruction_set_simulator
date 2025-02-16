﻿class InstructionSetSimulator
{
    static void Main(string[] args)
    {
        Dictionary<string, string> opcodes = new Dictionary<string, string>
        {
            { "MOV", "00000" },
            { "ADD", "00001" },
            { "SUB", "00010" },
            { "MUL", "00011" },
            { "DIV", "00100" }
        };

        Dictionary<string, string> registers = new Dictionary<string, string>
        {
            { "R1", "001" },
            { "R2", "010" },
            { "R3", "011" },
            { "R4", "100" },
            { "R5", "101" },
            { "R6", "110" },
            { "R7", "111" },
        };

        string[] lines = File.ReadAllLines("instruction_file.txt");

        Console.WriteLine("PC\tDecode:\t\tEncoded instruction(32-bit):");
        for (int i = 0; i < lines.Length; i++)
        {
            Console.Write("PC[{0}]", i);
            Console.Write("\t{0}", lines[i]);
            foreach (var key in lines[i].Split(" "))
            {
                if (opcodes.TryGetValue(key, out string? value))
                {
                    Console.Write("\t{0}", value);
                }

                if (registers.TryGetValue(key, out value))
                {
                    int count = 32 - value.Length;
                    Console.Write(" {0}", value);
                    Console.Write("{0}", string.Concat(Enumerable.Repeat("0", count)));
                }

                if (key.Contains(","))
                {
                    string removeSpecialCharacterKey = key.Replace(",", "");
                    if (registers.TryGetValue(removeSpecialCharacterKey, out value))
                    {
                        Console.Write(" {0}", value);
                    }
                }
                else
                {
                    if (int.TryParse(key, out int number))
                    {
                        string binary = Convert.ToString(number, 2);
                        int count = 32 - binary.Length;
                        Console.Write(" {0}", string.Concat(Enumerable.Repeat("0", count)));
                        Console.Write("{0}", binary);
                    }
                }
            }
            Console.WriteLine("");
        }
    }
}