namespace AVCS4_FalconRadiosAliasFile
{
    /// <summary>
    /// Console app for converting Falcon BMS Radio Command alias files between JSON and flat text formats.
    /// </summary>
    internal class Program
    {
        private static readonly string AliasesFileName = "aliases";

        private static void Main(string[] args)
        {
            var exeDir = AppDomain.CurrentDomain.BaseDirectory;

            var aliasesJsonPath = Path.Combine(exeDir, AliasesFileName + ".json");
            var aliasesTextPath = Path.Combine(exeDir, AliasesFileName + ".txt");

            var aliasesPath = args.Length > 0 ? args[0] : aliasesJsonPath;

            if (!File.Exists(aliasesPath))
            {
                Console.WriteLine();
                Console.WriteLine($"Error: The file {aliasesPath} does not exist in the directory {exeDir}.");
                Console.WriteLine($"Press ENTER to exit app, or just close the program.");
                Console.WriteLine();
                Console.ReadLine();
                return;
            }

            if (aliasesPath.EndsWith(".json"))
            {
                ConvertFileToText(aliasesPath, aliasesTextPath);
            }
            else
            {
                ConvertFileToJson(aliasesPath, aliasesJsonPath);
            }

            Console.WriteLine();
            Console.WriteLine($"File conversion is complete.");
            Console.WriteLine($"Press ENTER to exit app, or just close the program.");
            Console.WriteLine();
            Console.ReadLine();
        }


        private static void ConvertFileToJson(string inputPath, string outputPath)
        {
            var text = File.ReadAllText(inputPath);
            var json = TextToJsonConverter.ConvertFlatTextToJson(text);
            File.WriteAllText(outputPath, json);
        }

        private static void ConvertFileToText(string inputPath, string outputPath)
        {
            var json = File.ReadAllText(inputPath);
            var flatText = JsonToTextConverter.ConvertJsonToFlatText(json);
            File.WriteAllText(outputPath, flatText);
        }
    }
}
