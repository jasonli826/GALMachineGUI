using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace GALNewGUI.Product
{
    /// <summary>
    /// Interaction logic for InputDialog.xaml
    /// </summary>
    public partial class InputDialog : Window
    {
        public InputDialog()
        {
            InitializeComponent();
        }
        private void btnDialogOk_Click(object sender, RoutedEventArgs e)
        {
            // this.Close();

            string productName = txtAnswer.Text.Trim();

            if (string.IsNullOrEmpty(productName))
            {
                MessageBox.Show("Product Name Cannot be empty");
                return;
            }
            string filePath = "C:\\router\\Product File\\"+productName+".json";
            var EditProductWindow = new GALNewGUI.Product.EditProduct(filePath); // Use the correct namespace if needed
            EditProductWindow.Owner = this;
            EditProductWindow.ShowDialog(); // Or use Show() if you don’t want modal
            this.Close();
        }
        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
