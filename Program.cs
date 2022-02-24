namespace IB_4_8
{
    class Program
    {
        public static List<char> lang = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray().ToList<char>();
        public static Dictionary<char, int[]> LangDictionary = new Dictionary<char, int[]>();

        public static void Main(string[] args)
        {
            for (int i = 0; i < lang.Count; i++)
            {
                LangDictionary.Add(lang[i], new []{i, i});
            }
            //a = 7, k = 3
            // .\IB_4_7.exe mode a k input
            string output = String.Empty;
            try
            {
                if (int.TryParse(args[0], out var mode)
                    && int.TryParse(args[1], out var a)
                    && int.TryParse(args[2], out var k))
                {
                    for (int i = 0; i < lang.Count; i++)
                    {
                        LangDictionary[lang[i]][1] = (a * i + k) % lang.Count;
                    }
                    Console.WriteLine(PMZ(args[3], mode == 1));
                }
                else Console.WriteLine("Неверные аргументы");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        public static string PMZ(string input, bool mode)
        {
            string output = "";
            if (mode) // расшифровка
            {
                foreach (var symbol in input.ToUpper())
                {
                    int initKey = LangDictionary[symbol][0];
                    int c = 0;
                    foreach (var dict in LangDictionary.Values.Where(dict => initKey == dict[1]))
                    {
                        c = dict[0];
                    }
                    output += lang[c];
                }
            }
            else // зашифровка
            {
                foreach (var symbol in input.ToUpper())
                {
                    int c = LangDictionary[symbol][1];
                    output += lang[c];
                }
            }

            return output;
        }
    }
}


