namespace HW3.Menues.ReadFromFile
{
    internal class FileReader : IOption
    {
        public string OptionName => "Read File";

        public void Run()
        {
            ExecuteRead();
        }

        private void ExecuteRead()
        {
            Console.Clear();

            ConsoleHelper.WriteService("Enter path to file:");
            string path = Console.ReadLine();

            ConsoleHelper.WriteService("Enter count of lines");
            string input = Console.ReadLine();

            int linesCount;
            while (!int.TryParse(input, out linesCount) && linesCount > 0)
            {
                ConsoleHelper.WriteError("Enter correct number > 0");
            }

            ShowTXTFileData(path, linesCount);
        }

        private void ShowTXTFileData(string path, int linesCount)
        {
            List<string> data = ReadTXTFile(path, linesCount);

            if (data != null)
            {
                foreach (string line in data)
                {
                    ConsoleHelper.WriteResult("Result:");
                    ConsoleHelper.WriteResult(line);
                }
            }

            ConsoleHelper.WriteService("Tap anything");
            Console.ReadKey();
        }

        private List<string> ReadTXTFile(string path, int linesCount)
        {
            List<string> list = null;

            using (StreamReader sr = new StreamReader(path))
            {
                try
                {
                    list = new List<string>();

                    string? line = "";

                    for (int i = 0; i < linesCount; i++)
                    {
                        line = sr.ReadLine();
                        if (line == null)
                        {
                            break;
                        }

                        list.Add(line);
                    }
                }
                catch (FileNotFoundException e)
                {
                    ConsoleHelper.WriteError("File not found");
                    ConsoleHelper.WriteService("Try Again");
                }
                catch (Exception e)
                {
                    ConsoleHelper.WriteError(e.Message);
                    ConsoleHelper.WriteService("Try again");
                }
            }

            return list;
        }
    }
}
