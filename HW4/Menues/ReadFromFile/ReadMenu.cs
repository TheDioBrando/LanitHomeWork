namespace HW4.Menues.ReadFromFile
{
    public class ReadMenu : Menu, IOption
    {
        public ReadMenu(List<IOption> options) : base(options)
        {
        }

        public string OptionName { get => "Read"; }
    }
}
