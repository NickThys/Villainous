namespace Villainous.WinForm
{
    public partial class MainMenu : Form
    {
        public MainMenu()
        {
            InitializeComponent();
        }

        private void MainMenu_SizeChanged(object sender, EventArgs e)
        {
            LogoImg.Left = (LogoImg.Parent.Width - LogoImg.Width) / 2;
        }
    }
}