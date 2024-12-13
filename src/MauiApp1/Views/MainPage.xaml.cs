using System.Reflection;

namespace MauiApp1.Views
{
    public partial class MainPage : ContentPage
    {
        private const string KeyName = "current_count";
        private int _count = 0;

        public MainPage()
        {
            InitializeComponent();
            // Initialize to Zero if not available
            _count = Preferences.Get(KeyName, 0);
            counterLabel.Text = $"Current count: {_count}";
            save.IsEnabled = false;

            var version = typeof(MauiApp).Assembly.GetCustomAttribute<AssemblyInformationalVersionAttribute>()?.InformationalVersion;
            versionLabel.Text = $".NET MAUI ver. {version?[..version.IndexOf('+')]}";
        }

        private void OnCounterClicked(object sender, EventArgs e)
        {
            save.IsEnabled = true;
            _count++;
            counterLabel.Text = $"Current count: {_count}";

            SemanticScreenReader.Announce(counterLabel.Text);
        }

        private void OnSaved(object sender, EventArgs e)
        {
            Preferences.Default.Set(KeyName, _count);
            save.IsEnabled = false;
        }
    }
}
