namespace BMB.Core.UI
{
    using System.Windows;

    using Dependency;

    /// <summary>
    ///     Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly BMBApplication application;

        public MainWindow()
        {
            Registration.RegisterDependencies();
            InitializeComponent();
            application = Resolver.Resolve<BMBApplication>();
            application.Start();
        }

        ~MainWindow()
        {
            application.Stop();
        }
    }
}