using System.Text;
using ConsoleManagement;

namespace HW4.Menues
{
    public abstract class Menu
    {
        public Menu(List<IOption> options)
        {
            _optionList = options;
        }

        protected bool _active;
        protected List<IOption> _optionList;

        public virtual void Run()
        {
            _active = true;

            while (_active)
            {
                ShowMenu();
            }
        }

        protected virtual void ShowMenu()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append($"Select menu item: \n");

            int i;
            for (i = 0; i < _optionList.Count; i++)
            {
                sb.Append($"{i + 1}) {_optionList[i].OptionName}; \n");
            }

            sb.Append($"{i + 1}) Back; \n");

            ConsoleHelper.WriteMenu(sb.ToString());

            SelectMenuItem();
        }

        protected virtual void SelectMenuItem()
        {
            char choice = Console.ReadKey().KeyChar;

            while (choice < '1' || (choice - '0') > _optionList.Count + 1)
            {
                ConsoleHelper.WriteError("\n Write correct menu item");
                choice = Console.ReadKey().KeyChar;
            }

            if (choice - '0' == _optionList.Count + 1)
            {
                _active = false;
                return;
            }

            _optionList[choice - '1'].Run();
        }
    }
}
