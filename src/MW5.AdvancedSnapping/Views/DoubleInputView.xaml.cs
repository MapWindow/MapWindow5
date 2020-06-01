using System.Windows;
using System.Windows.Forms.Integration;
using System.Windows.Input;

namespace MW5.Plugins.AdvancedSnapping.Views
{
    /// <summary>
    /// Interaction logic for DoubleInputView.xaml
    /// </summary>
    public partial class DoubleInputView : Window
    {
        private double pX;
        private double pY;

        public DoubleInputView()
        {
            InitializeComponent();
            ElementHost.EnableModelessKeyboardInterop(this);
            this.Loaded += OnWindowLoaded;
        }

        // Escape closes this
        protected override void OnPreviewKeyDown(KeyEventArgs e)
        {
            base.OnPreviewKeyDown(e);
            if (e.Key == Key.Escape)
                Close();
        }

        public void Refocus()
        {
            X.Focus();
            Keyboard.Focus(X);
        }

        // Make sure we are positioned correc
        private void OnWindowLoaded(object sender, RoutedEventArgs e)
        {
            Reposition(pX, pY);
        }

        public void Reposition(double pX, double pY)
        {
            this.pX = pX;
            this.pY = pY;
            var w = this.IsLoaded ? this.ActualWidth : this.Width;
            var h = this.IsLoaded ? this.ActualHeight : this.Height;
            this.Left = pX - w / 2;
            this.Top = pY - h - 10;

            if (Top < 0) Top = 0;

        }
    }
}
