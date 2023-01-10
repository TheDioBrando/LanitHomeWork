using ConsoleManagement;

namespace HW4.Menues.WriteWebPageToFile
{
    public class WebPageReader
    {

        public static async Task<string> GetWebPageCode(string url)
        {
            string text = null;

            using (var httpClient = new HttpClient())
            {
                try
                {
                    text = await httpClient.GetStringAsync(url);
                }
                catch (Exception e)
                {
                    ConsoleHelper.WriteError(e.Message);
                }
            }

            return text;
        }
    }
}
