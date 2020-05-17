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

namespace Training_Rus_WPF
{
    /// <summary>
    /// Логика взаимодействия для FormInputed.xaml
    /// </summary>
    public partial class FormInputed : Window
    {
        public FormInputed()
        {
            InitializeComponent();
            textbox.Focus();
            textbox.MaxLength = 1; 
            
        }

        public enum DialogRes
        {
            Ok = 1,
            None = 2
        }

        public void set_comma()
        {
            textbox.Text = ",";
            textbox.IsReadOnly = true;
        }

        public DialogRes result { get; private set; }
        public string Value { get; private set; }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            result = DialogRes.None;
            Value = "";
            this.Close();
        }

        private bool isRussian(char c)
        {
            return (c >= 'А' && c <= 'я') || c == 'ё' || c == 'Ё' || c == ',' || c == '-' || c == ':';
        }

        private void TextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            { 
                Button_Click_1(null, null);
            }
            if (e.Key == Key.Escape)
            {
                Button_Click(null, null);
            }

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            result = DialogRes.Ok;

            if (textbox.Text != " " && textbox.Text != "" && isRussian(char.Parse(textbox.Text)))
                Value = textbox.Text;
            else Value = "_";

            this.Close();
        }

        

         
    }
}
