namespace HW3.Menues.WriteWebPageToFile
{
    internal class FileWriter : IOption
    {
        public string OptionName { get => "Write web page to file"; }

        public void Run()
        {
            ExecuteWriteFromWebPage();
        }

        private static async void ExecuteWriteFromWebPage()
        {
            Console.Clear();

            ConsoleHelper.WriteService("Enter url");
            string url = Console.ReadLine();

            ConsoleHelper.WriteService("Enter path to file");
            string path = Console.ReadLine();

            string code = WebPageReader.GetWebPageCode(url).Result;

            if (code != null)
            {
                WriteToFile(path, code);
            }

            ConsoleHelper.WriteService("Tap anything");
            Console.ReadKey();
        }

        private static async void WriteToFile(string path, string code)
        {
            StreamWriter sw = null;

            try
            {
                sw = new StreamWriter(path);
                await sw.WriteAsync(code);
            }
            catch (Exception e)
            {
                ConsoleHelper.WriteError(e.Message);
            }
            finally
            {
                if (sw != null)
                {
                    ConsoleHelper.WriteService("Success");
                    sw.Dispose();
                }
            }
        }
    }
}
