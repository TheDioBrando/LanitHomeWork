namespace HW4.Menues.WriteWebPageToFile
{
    internal class WriteMenu : Menu, IOption
    {
        public WriteMenu(List<IOption> options) : base(options)
        {
        }

        public string OptionName => "Write";
    }
}
