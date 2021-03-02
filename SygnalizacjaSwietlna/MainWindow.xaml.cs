using System.Windows;

namespace SygnalizacjaSwietlna
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Sygnalizator MojSygnalizator;
        System.Timers.Timer Timer;

        public MainWindow()
        {
            MojSygnalizator = new Sygnalizator();
            InitializeComponent();
            ZmienSwiatloCoOkresCzasu();
            this.DataContext = MojSygnalizator;
        }

        private void ZmienSwiatloCoOkresCzasu()
        {
            Timer = new System.Timers.Timer();
            Timer.Elapsed += CzasUplynal;
            Timer.Interval = 20000;
            Timer.Enabled = true;
        }

        private void CzasUplynal(object sender, System.Timers.ElapsedEventArgs e)
        {
            MojSygnalizator.ZmienSwiatlo();
        }
    }
}
