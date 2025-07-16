using GALNewGUI.Entity;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace GALNewGUI.Controls
{
    public partial class ModernMessageDialog : UserControl
    {
        public string Title
        {
            get => TitleText.Text;
            set => TitleText.Text = value;
        }

        public string Message
        {
            get => MessageText.Text;
            set => MessageText.Text = value;
        }

        public Brush BackgroundColor
        {
            get => (Brush)GetValue(BackgroundColorProperty);
            set => SetValue(BackgroundColorProperty, value);
        }

        public MessageBoxMode Mode = MessageBoxMode.Alert;
        public static readonly DependencyProperty BackgroundColorProperty =
            DependencyProperty.Register("BackgroundColor", typeof(Brush), typeof(ModernMessageDialog), new PropertyMetadata(Brushes.DarkSlateGray));

        public ModernMessageDialog()
        {
            InitializeComponent();
            DataContext = this;
        }

        private void Ok_Click(object sender, RoutedEventArgs e)
        {
            Window.GetWindow(this)?.Close();
        }
        public bool? Result { get; private set; }

        private void Yes_Click(object sender, RoutedEventArgs e)
        {
            Result = true;
            Window.GetWindow(this)?.Close();
        }

        private void No_Click(object sender, RoutedEventArgs e)
        {
            Result = false;
            Window.GetWindow(this)?.Close();
        }
        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            TitleText.Text = Title;
            MessageText.Text = Message;

            if (Mode == MessageBoxMode.Alert)
            {
                OkPanel.Visibility = Visibility.Visible;
            }
            else if (Mode == MessageBoxMode.Confirmation)
            {
                YesNoPanel.Visibility = Visibility.Visible;
               
            }
        }
    }
}
