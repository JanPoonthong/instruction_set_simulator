class InstructionSetSimulator
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
            { "R5", "101" }
        };

        string[] lines = File.ReadAllLines("instruction_file.txt");
        for (int i = 0; i < lines.Length; i++)
        {
            if (lines[i].Contains(","))
            {
                lines[i] = lines[i].Replace(",", "");
            }
        }

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
                    Console.Write(" {0}", value);
                }
                else
                {
                    if (int.TryParse(key, out int number))
                    {
                        string binary = Convert.ToString(number, 2);
                        Console.Write(" {0}", binary);
                    }
                }
            }
            Console.WriteLine("");
        }
    }
}