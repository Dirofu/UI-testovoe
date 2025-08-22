namespace UI.MenuOpener
{
    public interface IOpenableMenu
    {
        public MenuType Type { get; }

		public void OpenMenu();
        public void CloseMenu();
    }
}