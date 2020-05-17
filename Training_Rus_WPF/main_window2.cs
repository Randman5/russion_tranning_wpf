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
using System.Windows.Navigation;
using System.Windows.Shapes;

using Microsoft.Win32;
using System.IO;
using System.Windows.Media.Animation;
using System.Data.OleDb;


namespace Training_Rus_WPF
{
    public partial class MainWindow 
    {

        public struct Texts
        {
            public int id;
            public string originalTxt;
            public string inputedTxt;
        }

        List<Texts> texts_from_bd = new List<Texts>();


        private void execute_texts_data()
        {
            texts_from_bd.Clear();

            using (OleDbConnection connection = new OleDbConnection(@"Provider = Microsoft.jet.OLEDB.4.0;  data source = BD_theory\BDRus.mdb"))
            {
                connection.Open(); 

                String request = string.Format("SELECT * FROM Texts ");

                OleDbCommand command = new OleDbCommand(request, connection);
                OleDbDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        texts_from_bd.Add(new Texts { id = reader.GetInt32(0), originalTxt = reader.GetString(1), inputedTxt = reader.GetString(2) });
                    }
                }
            }

            peremeshat();

        }
        
        //перемешка текста
        private void peremeshat()
        {
            Random random = new Random();
            int j;
            for (int i = texts_from_bd.Count - 1; i >= 0; i--)
            {
                Texts tmp = texts_from_bd[i];
                j = random.Next(i + 1);
                texts_from_bd[i] = texts_from_bd[j];
                texts_from_bd[j] = tmp;
            }

            //texts_from_bd[0] = texts_from_bd[texts_from_bd.Count -1];
        }


        private int check_on_error(string inputend_text, string original_text , WrapPanel wrap)
        {
            const double fontSize = 53.5;

            wrap.Children.Clear();

            List<string> firstWord = WordProcessing.WordTrimming.Trim(inputend_text, WordProcessing.WordTrimming.TrimmingType.word);
            List<string> secondWord = WordProcessing.WordTrimming.Trim(original_text, WordProcessing.WordTrimming.TrimmingType.word);

            List<WordProcessing.WordError> ls = WordProcessing.WordTrimming.SearchWordError(firstWord, secondWord);
            //string s = "";

             
            //foreach (var Word in ls)
            //{
            //    foreach (var symbol in Word.SimbolError)
            //    {
            //        Console.WriteLine(Word.WordNumber + ":" + symbol.SymbolNumber + ":" + symbol.Symbol);
            //        s += Word.WordNumber + ":" + symbol.SymbolNumber + ":" + symbol.Symbol + "\n";
            //    }
            //}

            List<string> firstWord1 = WordProcessing.WordTrimming.Trim(inputend_text, WordProcessing.WordTrimming.TrimmingType.Comma);
            List<string> secondWord1 = WordProcessing.WordTrimming.Trim(original_text, WordProcessing.WordTrimming.TrimmingType.Comma);
             
            List<WordProcessing.WordError> ls1 = WordProcessing.WordTrimming.SearchCommaError(firstWord1, secondWord1);
            //string s1 = "";

            //foreach (var Word in ls1)
            //{
            //    foreach (var symbol in Word.SimbolError)
            //    {
            //        Console.WriteLine(Word.WordNumber + ":" + symbol.SymbolNumber + ":" + symbol.Symbol);
            //        s1 += Word.WordNumber + ":" + symbol.SymbolNumber + ":" + symbol.Symbol + "\n";
            //    }
            //}

  
            //wrap.Visibility = Visibility.Visible;
            // определение ошибок и вывод их в wrap panel
            for (int i = 0; i < secondWord1.Count; i++)
            {
                TextBlock tb = new TextBlock();

                if (ls[i].Iserror )
                {
                    for (int j = 0; j < secondWord1[i].Length; j++)
                    {
                        TextBlock tbd = new TextBlock();
                        
                        tbd.FontSize = fontSize;

                        //for (int k = 0; k < ls[i].SimbolError.Count; k++)
                        //{

                            if (/*j == */ls[i].SimbolError.Count > j && ls[i].SimbolError[j].IserrorS /*&& ls[i].SimbolError[k].IserrorS*/)
                            {
                                 
                                tbd.Foreground = Brushes.Red;
                                //tbd.Text = ls[i].SimbolError[k].Symbol.ToString();
                                tbd.Text = firstWord1[i][j].ToString();
                                //wrap.Children.Add(tbd);
                                //ls[i].SimbolError.RemoveAt(j);
                                
                                  
                            }
                            else
                            {
                                 
                                tbd.Foreground = Brushes.Black;
                                tbd.Text = secondWord1[i][j].ToString();

                                //wrap.Children.Add(tbd);
                                   
                            }
                            //wrap.Children.Add(tbd);
                        //}
                        wrap.Children.Add(tbd);

                    }

                    if (ls1[i].Iserror && ls[i].Iserror )
                    {
                        //wrap.Children.RemoveAt(wrap.Children.Count - 1);
                        TextBlock tb3 = new TextBlock();
                        tb3.VerticalAlignment = VerticalAlignment.Bottom;
                        tb3.FontSize = fontSize;
                        tb3.Foreground = (secondWord1[i][secondWord1[i].Length - 1] != ',') ? Brushes.Blue : Brushes.Red;
                        //tb3.Text = secondWord1[i][secondWord1[i].Length - 1].ToString(); 
                        if (secondWord1[i][secondWord1[i].Length - 1] != ',')
                            tb3.Text = ",";
                        else
                        {
                            wrap.Children.RemoveAt(wrap.Children.Count - 1);
                            tb3.Text = ",";
                        }

                        wrap.Children.Add(tb3);
                    }
                }
                else
                { 
                    if (ls1[i].Iserror)
                    {
                        TextBlock tb2 = new TextBlock();
                        tb2.FontSize = fontSize;
                        tb2.Text = secondWord[i];
                        tb2.Foreground = Brushes.Black;
                        wrap.Children.Add(tb2);

                        //wrap1.Children.RemoveAt(wrap1.Children.Count - 1);
                        TextBlock tb3 = new TextBlock();
                        tb3.VerticalAlignment = VerticalAlignment.Bottom;
                        tb3.FontSize = fontSize;
                        tb3.Foreground = (secondWord1[i][secondWord1[i].Length - 1] != ',') ? Brushes.Blue : Brushes.Red;
                        //tb3.Text = secondWord1[i][secondWord1[i].Length - 1].ToString();
                        tb3.Text = ",";
                        wrap.Children.Add(tb3);
                    }
                    else
                    {
                        TextBlock tb2 = new TextBlock();
                        tb2.FontSize = fontSize;
                        tb2.Text = secondWord1[i];
                        tb2.Foreground = Brushes.Black;
                        wrap.Children.Add(tb2);
                    }
                }

                tb.FontSize = fontSize;
                tb.Text = " ";
                wrap.Children.Add(tb);

            }

            // сколько набранно баллов
            int word_errors = 0;
            int comma_errors = 0;
            for (int i = 0; i < ls.Count; i++)
            {
                if (ls[i].Iserror)
                {
                    for (int j = 0; j < ls[i].SimbolError.Count; j++)
                    {
                        if (ls[i].SimbolError[j].IserrorS)
                        {
                            word_errors++;
                        }
                    }
                     
                }
            }

            for (int i = 0; i < ls1.Count; i++)
            {
                if (ls1[i].Iserror)
                {
                    comma_errors++;
                }
            }


            return word_errors + comma_errors;
        }

        //выставление оценки
        private int assessment_calculation(string inputend_text, string original_text, int balls)
        {
              

            List<string> firstWord = WordProcessing.WordTrimming.Trim(inputend_text, WordProcessing.WordTrimming.TrimmingType.word);
            List<string> secondWord = WordProcessing.WordTrimming.Trim(original_text, WordProcessing.WordTrimming.TrimmingType.word);

            List<WordProcessing.WordError> ls = WordProcessing.WordTrimming.SearchWordError(firstWord, secondWord);
             

            List<string> firstWord1 = WordProcessing.WordTrimming.Trim(inputend_text, WordProcessing.WordTrimming.TrimmingType.Comma);
            List<string> secondWord1 = WordProcessing.WordTrimming.Trim(original_text, WordProcessing.WordTrimming.TrimmingType.Comma);

            List<WordProcessing.WordError> ls1 = WordProcessing.WordTrimming.SearchCommaError(firstWord1, secondWord1);


            int word_errors = 0;
            int comma_errors = 0;
            for (int i = 0; i < ls.Count; i++)
            {
                if (ls[i].Iserror)
                {
                    for (int j = 0; j < ls[i].SimbolError.Count; j++)
                    {
                        if (ls[i].SimbolError[j].IserrorS)
                        {
                            word_errors++;
                        }
                    }

                }
            }

            for (int i = 0; i < ls1.Count; i++)
            {
                if (ls1[i].Iserror)
                {
                    comma_errors++;
                }
            }

            int MaxError = word_errors + comma_errors;
            //MessageBox.Show(MaxError.ToString());
            //MessageBox.Show(balls.ToString());
            int on_five = 1;
            int on_four = (MaxError / 4);
            int on_three = (MaxError/2);
            int on_two = MaxError - MaxError /4;

            return balls <= on_five ? 5 : ((balls > on_five) && (balls <= on_four) ? 4 : ((balls > on_four) && (balls <= on_three) ? 3 : 2));

        }

        private bool Enter_in_system()
        {
            bool check = true;
            //if (Fio.Text.Length < 3)
            //{
            //    MessageBox.Show("Ошибка","ФИо не может состоять из 3.х букв");
            //    check = false;
            //}
            //if (Pas.Text.Length < 3)
            //{
            //    MessageBox.Show("Ошибка", "группа не может состоять из 3.х букв");
            //    check = false;
            //}
            //Entered_fio.Content = Fio.Text;
            //Entered_group.Content = Pas.Text;

            return check;
        }
        
    }
}
