using System.Windows.Forms;

namespace OuvreurDeDossiers
{
    public partial class FormHelp : Form
    {
        public FormHelp()
        {
            InitializeComponent();

            buttonOK.Focus();

            this.buttonOK.Click += (s,e) =>
            {
                this.Close();
            };

            // Shortcuts.
            this.KeyDown += (se, ev) =>
            {
                if (ev.KeyCode.Equals(Keys.Escape))
                {
                    this.Close();
                }
            };
        }
    }
}
