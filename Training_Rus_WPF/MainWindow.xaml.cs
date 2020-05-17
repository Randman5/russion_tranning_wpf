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
using word = Microsoft.Office.Interop.Word;

using printer = System.Diagnostics;
using form = System.Windows.Forms;
//using System.ComponentModel;



namespace Training_Rus_WPF
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            
            /// верхний слой 5 текст

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            menuImage.Background = new ImageBrush(new BitmapImage(new Uri(@"Images\MenuImg.png", UriKind.Relative)));
             


            // подгрузка событий анимации справки
            spravka_animation();
            instrukciya_animation();

            //Подготовка форм с текстом
            LoadingDateTheory();
            load_all_Massive_for_text();
            load_all_btn_for_text();

            // перелистывание инструкции
            next_sheet();


            // проверка текста
            execute_texts_data();
            //text1.IsUndoEnabled = false;
            //text1.Text = texts_from_bd[0].inputedTxt;
            //text1.IsUndoEnabled = true;
            //wrap_Panels[0].Visibility = Visibility.Hidden;
            proverka_texts();
            set_texts();

        }

        private void load_all_Massive_for_text()
        {
            texts_grids         =      new   Grid[]          { For_text_1, For_text_2, For_text_3, For_text_4, For_text_5 };
            btn_texts           =      new   Button[]        { open_text1, open_text2, open_text3, open_text4, open_text5 };
            text_boxes          =      new   TextBox[]       { text1, text2, text3, text4, text5 };
            btn_back            =      new   Button[]        { back1, back2, back3, back4, back5 };
            btn_proverka        =      new   Button[]        { Proverka1, Proverka2, Proverka3, Proverka4, Proverka5 };
            wrap_Panels         =      new   WrapPanel[]     { wrap1, wrap2, wrap3, wrap4, wrap5 };
            btn_sbros           =      new   Button[]        { sbros1, sbros2, sbros3, sbros4, sbros5 };
            labels_assessment   =      new   Label[]         { lbl1, lbl2, lbl3, lbl4, lbl5 };

            btn_ins_next        =      new   Button[]        { btnNext1, btnNext2 };
            inst_grids          =      new   Grid[]          { ins1, ins2, ins3 };
            btn_ins_back        =      new   Button[]        { btnBack1, btnBack2 };
        }

        Grid[]          texts_grids;
        Grid[]          inst_grids;
        Button[]        btn_back;
        Button[]        btn_texts;
        Button[]        btn_proverka;
        Button[]        btn_sbros;
        Button[]        btn_ins_next;
        Button[]        btn_ins_back;
        TextBox[]       text_boxes;
        WrapPanel[]     wrap_Panels;
        Label[]         labels_assessment;


        private void instruction_Animation( Grid grid1)
        {
            grid1.Visibility = Visibility.Visible;
            DoubleAnimation gridAnimation = new DoubleAnimation();
            gridAnimation.From = 0;
            gridAnimation.To = MainGrid.ActualWidth;
            gridAnimation.Duration = TimeSpan.FromSeconds(0.2);
            gridAnimation.FillBehavior = FillBehavior.Stop;
            gridAnimation.Completed += delegate
            {
                grid1.BeginAnimation(Grid.WidthProperty, null);

                grid1.Width = double.NaN;
                grid1.HorizontalAlignment = HorizontalAlignment.Stretch;
            };
            grid1.BeginAnimation(Grid.WidthProperty, gridAnimation);
             
        }
        private void instruction_Animation_back(Grid grid1)
        {
            
            DoubleAnimation gridAnimation = new DoubleAnimation();
            gridAnimation.From = MainGrid.ActualWidth;
            gridAnimation.To = 0;
            gridAnimation.Duration = TimeSpan.FromSeconds(0.2);
            gridAnimation.FillBehavior = FillBehavior.Stop;
            gridAnimation.Completed += delegate
            {
                grid1.BeginAnimation(Grid.WidthProperty, null);
                theoryGrid.Visibility = Visibility.Collapsed;
                grid1.Width = 0;
                grid1.HorizontalAlignment = HorizontalAlignment.Stretch;
            };
            grid1.BeginAnimation(Grid.WidthProperty, gridAnimation);

        }
        private void next_sheet()
        {
            for (int i = 0; i < btn_ins_next.Length; i++)
            {
                int value = i;
                btn_ins_next[i].Click += delegate
                {
                    //inst_grids[value + 1].Visibility = Visibility.Visible;
                    instruction_Animation(inst_grids[value+1]);
                };

                btn_ins_back[i].Click += delegate
                {
                    instruction_Animation_back(inst_grids[value + 1]);
                };

            }
        }

        private void load_all_btn_for_text()
        {
             

            // добавление анимации открытия 5 текстов
            for (int i = 0; i < texts_grids.Length; i++)
            {
                var N_btn = i;
                btn_texts[i].Click += delegate
                {
                    for (int j = 0; j < btn_texts.Length; j++)
                    {
                        if (j != N_btn)
                        {
                            texts_grids[j].Visibility = Visibility.Collapsed;
                        }
                        else
                        {
                            texts_grids[j].HorizontalAlignment = HorizontalAlignment.Left;
                            texts_grids[j].Visibility = Visibility.Visible;
                            texts_grids[j].Width = 0;
                        } 
                    }

                    DoubleAnimation gridAnimation = new DoubleAnimation();
                    gridAnimation.From = 0;
                    gridAnimation.To = MainGrid.ActualWidth;
                    gridAnimation.Duration = TimeSpan.FromSeconds(0.3);
                    gridAnimation.FillBehavior = FillBehavior.Stop;
                    gridAnimation.Completed += delegate
                    {
                        texts_grids[N_btn].BeginAnimation(Grid.WidthProperty, null);
                        texts_grids[N_btn].HorizontalAlignment = HorizontalAlignment.Stretch;
                        texts_grids[N_btn].Width = Double.NaN;

                         
                    };
                    texts_grids[N_btn].BeginAnimation(Grid.WidthProperty, gridAnimation);
                     
                };
                
                 
                //Вставка символов
                text_boxes[i].PreviewMouseUp += delegate
                { 
                    insert_simbols_in_text(text_boxes[N_btn]);
                };

                // шаг назад
                btn_back[i].MouseEnter += delegate
                {
                    text_boxes[N_btn].IsReadOnly = false;
                    btn_back[N_btn].Focus();
                    text_boxes[N_btn].Focusable = false;
                };
                btn_back[i].MouseLeave += delegate
                {
                    text_boxes[N_btn].IsReadOnly = true;
                    text_boxes[N_btn].Focusable = true;
                };
                btn_back[i].Click += delegate
                {
                    text_boxes[N_btn].IsReadOnly = false;
                };
                

            }

        }
        

        private void set_texts()
        {
            peremeshat();
            for (int i = 0; i < btn_proverka.Length; i++)
            {
                int value = i;

                text_boxes[value].IsUndoEnabled = false;

                text_boxes[value].Text = texts_from_bd[value].inputedTxt;
                //обнуление undo

                text_boxes[value].IsUndoEnabled = true;

                btn_sbros[value].IsEnabled = true;
                btn_proverka[value].IsEnabled = true;
                btn_back[value].IsEnabled = true;

                // лейбл для оценки
                labels_assessment[value].Visibility = Visibility.Hidden;

                //обнуление панели ошибок
                wrap_Panels[i].Children.Clear();
                wrap_Panels[i].Visibility = Visibility.Collapsed;
            }
        }

        //заполнение текстов и кнопок заного
        private void proverka_texts()
        {
            
            for (int i = 0; i < btn_proverka.Length; i++)
            {
                //btn_proverka[i].Click -= delegate { };
                 
                wrap_Panels[i].Visibility = Visibility.Hidden;

                int value = i;

                //text_boxes[value].IsUndoEnabled = false;
                //text_boxes[value].IsUndoEnabled = true;

                // кнопка проверки
                btn_proverka[i].Click += delegate
                {
                    wrap_Panels[value].Visibility = Visibility.Visible;
                    int balls = check_on_error(text_boxes[value].Text, texts_from_bd[value].originalTxt, wrap_Panels[value]);

                      
                    labels_assessment[value].Visibility = Visibility.Visible;
                    labels_assessment[value].Content = "Ваша оценка: " + assessment_calculation(texts_from_bd[value].inputedTxt, texts_from_bd[value].originalTxt, balls);

                    btn_sbros[value].IsEnabled = false;
                    btn_proverka[value].IsEnabled = false;
                    btn_back[value].IsEnabled = false;
                };

                // кнопка сброс
                btn_sbros[i].Click += delegate
                {
                    text_boxes[value].IsReadOnly = false;
                    text_boxes[value].Text = texts_from_bd[value].inputedTxt;
                    text_boxes[value].IsReadOnly = true;

                    text_boxes[value].IsUndoEnabled = false; 
                    text_boxes[value].IsUndoEnabled = true;
                };

            }
            //set_texts();
        }


        // открытие справки
        bool spravka_open = true; 
        private void spravka_animation()
        { 
            Bloc_spravka.MouseEnter += delegate
            { 
                Bloc_spravka.Foreground = (Brush)System.ComponentModel.TypeDescriptor.GetConverter(typeof(Brush)).ConvertFromInvariantString("red");
            };
            Bloc_spravka.MouseLeave += delegate
            { 
                Bloc_spravka.Foreground = (Brush)System.ComponentModel.TypeDescriptor.GetConverter(typeof(Brush)).ConvertFromInvariantString("blue");
            };
            Bloc_spravka.MouseDown += delegate
            {

                if (spravka_open)
                {

                    DoubleAnimation gridAnimation = new DoubleAnimation();
                    gridAnimation.From = 200;
                    gridAnimation.To = 700;
                    gridAnimation.Duration = TimeSpan.FromSeconds(0.2);
                    gridAnimation.Completed += delegate
                    {
                        DoubleAnimation gridAnimation1 = new DoubleAnimation();
                        gridAnimation1.From = 20;
                        gridAnimation1.To = 250;
                        gridAnimation1.Duration = TimeSpan.FromSeconds(0.2);
                        gridAnimation1.Completed += delegate
                        {
                            spravka.BeginAnimation(Grid.WidthProperty, null);
                            spravka.BeginAnimation(Grid.HeightProperty, null);
                            spravka.Width = 700;
                            spravka.Height = 250;
                        };
                        spravka.BeginAnimation(Grid.HeightProperty, gridAnimation1);

                    };
                    spravka.BeginAnimation(Grid.WidthProperty, gridAnimation);


                    spravka_open = false;
                }
                else
                {
                    spravka.VerticalAlignment = VerticalAlignment.Top;


                    DoubleAnimation gridAnimation = new DoubleAnimation();
                    gridAnimation.From = 250;
                    gridAnimation.To = 20;
                    gridAnimation.Duration = TimeSpan.FromSeconds(0.2);
                    gridAnimation.Completed += delegate
                    {
                        spravka.HorizontalAlignment = HorizontalAlignment.Center;

                        DoubleAnimation gridAnimation1 = new DoubleAnimation();
                        gridAnimation1.From = 700;
                        gridAnimation1.To = 200;
                        gridAnimation1.Duration = TimeSpan.FromSeconds(0.2);
                        gridAnimation1.Completed += delegate
                        {
                            spravka.BeginAnimation(Grid.WidthProperty, null);
                            spravka.BeginAnimation(Grid.HeightProperty, null);
                            spravka.Width = 200;
                            spravka.Height = 20;
                        };
                        spravka.BeginAnimation(Grid.WidthProperty, gridAnimation1);
                    };
                    spravka.BeginAnimation(Grid.HeightProperty, gridAnimation);

                    spravka_open = true;
                }


            };
        }

        // откртие инструкции
        bool instrukciya_open = true;
        private void instrukciya_animation()
        {
            Bloc_instrukcii.MouseEnter += delegate
            {
                Bloc_instrukcii.Foreground = (Brush)System.ComponentModel.TypeDescriptor.GetConverter(typeof(Brush)).ConvertFromInvariantString("red");
            };
            Bloc_instrukcii.MouseLeave += delegate
            {
                Bloc_instrukcii.Foreground = (Brush)System.ComponentModel.TypeDescriptor.GetConverter(typeof(Brush)).ConvertFromInvariantString("blue");
            };
            Bloc_instrukcii.MouseDown += delegate
            {

                if (instrukciya_open)
                {

                    DoubleAnimation gridAnimation = new DoubleAnimation();
                    gridAnimation.From = 200;
                    gridAnimation.To = MainGrid.ActualWidth;
                    gridAnimation.Duration = TimeSpan.FromSeconds(0.2);
                    gridAnimation.Completed += delegate
                    {
                        DoubleAnimation gridAnimation1 = new DoubleAnimation();
                        gridAnimation1.From = 20;
                        gridAnimation1.To = MainGrid.ActualHeight;
                        gridAnimation1.Duration = TimeSpan.FromSeconds(0.2);
                        gridAnimation1.Completed += delegate
                        {
                            instrukciya.BeginAnimation(Grid.WidthProperty, null);
                            instrukciya.BeginAnimation(Grid.HeightProperty, null);

                             
                            instrukciya.Width = MainGrid.ActualWidth;
                            instrukciya.Height = MainGrid.ActualHeight;
                            instrukciya.Height = double.NaN;
                            instrukciya.Width = double.NaN;
                            instrukciya.HorizontalAlignment = HorizontalAlignment.Stretch;
                            instrukciya.VerticalAlignment = VerticalAlignment.Stretch;
                        };
                        instrukciya.BeginAnimation(Grid.HeightProperty, gridAnimation1);
                         
                         

                    };
                    instrukciya.BeginAnimation(Grid.WidthProperty, gridAnimation);



                    instrukciya_open = false;
                }
                else
                {
                    instrukciya.VerticalAlignment = VerticalAlignment.Top;


                    DoubleAnimation gridAnimation = new DoubleAnimation();
                    gridAnimation.From = MainGrid.ActualHeight;
                    gridAnimation.To = 20;
                    gridAnimation.Duration = TimeSpan.FromSeconds(0.2);
                    gridAnimation.Completed += delegate
                    {
                        instrukciya.HorizontalAlignment = HorizontalAlignment.Right;

                        DoubleAnimation gridAnimation1 = new DoubleAnimation();
                        gridAnimation1.From = MainGrid.ActualWidth;
                        gridAnimation1.To = 200;
                        gridAnimation1.Duration = TimeSpan.FromSeconds(0.2);
                        gridAnimation1.Completed += delegate
                        {
                            instrukciya.BeginAnimation(Grid.WidthProperty, null);
                            instrukciya.BeginAnimation(Grid.HeightProperty, null);
                            instrukciya.Width = 200;
                            instrukciya.Height = 20;
                            instrukciya.HorizontalAlignment = HorizontalAlignment.Right;
                            instrukciya.VerticalAlignment = VerticalAlignment.Top;
                        };
                        instrukciya.BeginAnimation(Grid.WidthProperty, gridAnimation1);
                    };
                    instrukciya.BeginAnimation(Grid.HeightProperty, gridAnimation);

                    instrukciya_open = true;
                }


            };
        }

        // Кнопка приступить
        public void Button_Click(object sender, RoutedEventArgs e)
        {
            //рандом новых вопросов
            set_texts();

            // Вход
            if (Enter_in_system())
            {
                enterGrid.HorizontalAlignment = HorizontalAlignment.Left;
                //width_animation = enterGrid.ActualWidth;

                DoubleAnimation gridAnimation = new DoubleAnimation();
                gridAnimation.From = enterGrid.ActualWidth;
                gridAnimation.To = 0;
                gridAnimation.Duration = TimeSpan.FromSeconds(0.15);
                gridAnimation.FillBehavior = FillBehavior.Stop;
                gridAnimation.Completed += delegate
                {
                    enterGrid.BeginAnimation(Grid.WidthProperty, null);
                    enterGrid.Visibility = Visibility.Collapsed;
                    enterGrid.Width = 0;
                };
                enterGrid.BeginAnimation(Grid.WidthProperty, gridAnimation);
            }

             
            
             
        }

        //назад;
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            enterGrid.Visibility = Visibility.Visible;
            DoubleAnimation gridAnimation = new DoubleAnimation();
            gridAnimation.From = 0;
            gridAnimation.To = MainGrid.ActualWidth;
            gridAnimation.Duration = TimeSpan.FromSeconds(0.15);
            gridAnimation.FillBehavior = FillBehavior.Stop;
            gridAnimation.Completed += delegate
            {
                enterGrid.BeginAnimation(Grid.WidthProperty, null);
                
                enterGrid.Width = double.NaN;
                enterGrid.HorizontalAlignment = HorizontalAlignment.Stretch;
                menu_stack.Width = 70;
                check_menu = true;
            };
            enterGrid.BeginAnimation(Grid.WidthProperty, gridAnimation);

            DoubleAnimation gridAnimation1 = new DoubleAnimation();
            gridAnimation1.From = 0;
            gridAnimation1.To = 100;
            gridAnimation1.Duration = TimeSpan.FromSeconds(80);
            Fio.BeginAnimation(TextBox.OpacityProperty, gridAnimation1);
            Pas.BeginAnimation(TextBox.OpacityProperty, gridAnimation1);
            Begin_BTN.BeginAnimation(Button.OpacityProperty, gridAnimation1);
            Mlabel1.BeginAnimation(Label.OpacityProperty,gridAnimation1);
            Mlabel2.BeginAnimation(Label.OpacityProperty, gridAnimation1);
            Mlabel3.BeginAnimation(Label.OpacityProperty, gridAnimation1);


        }
        
         

        // открытие теории из меню в тесте
        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            theoryGrid.Visibility = Visibility.Visible;
            DoubleAnimation gridAnimation = new DoubleAnimation();
            gridAnimation.From = 0;
            gridAnimation.To = MainGrid.ActualWidth;
            gridAnimation.Duration = TimeSpan.FromSeconds(0.2);
            gridAnimation.FillBehavior = FillBehavior.Stop;
            gridAnimation.Completed += delegate
            {
                theoryGrid.BeginAnimation(Grid.WidthProperty, null);

                theoryGrid.Width = double.NaN;
                theoryGrid.HorizontalAlignment = HorizontalAlignment.Stretch;
                menu_stack.Width = 70;
                check_menu = true;
            };
            theoryGrid.BeginAnimation(Grid.WidthProperty, gridAnimation);

            load_theory(insertInStack_files);

        }

        // анимация на кнопку назад в гриде теория
        private void Back_to_test_MouseUp(object sender, MouseButtonEventArgs e)
        {
            theoryGrid.HorizontalAlignment = HorizontalAlignment.Right;

            DoubleAnimation gridAnimation = new DoubleAnimation();
            gridAnimation.From = MainGrid.ActualWidth;
            gridAnimation.To = 0;
            gridAnimation.Duration = TimeSpan.FromSeconds(0.2);
            gridAnimation.FillBehavior = FillBehavior.Stop;
            gridAnimation.Completed += delegate
            {
                theoryGrid.BeginAnimation(Grid.WidthProperty, null);
                theoryGrid.Visibility = Visibility.Collapsed;
                theoryGrid.Width = 0;
                
            };
            theoryGrid.BeginAnimation(Grid.WidthProperty, gridAnimation);

            TextDocumenta.Document = new FlowDocument();
            stack.Children.Clear();
            tema_name.Text = "Выберите тему";

            searchBox.Text = "Поиск";

        }
        /// ////////////////////////////////////////////////////////////////// 

        //theory btn
        struct file_theory
        {
            public string name;
            public string path;
        }

        //запрос на получение теории
        List<file_theory> fileList;
        private void LoadingDateTheory()
        { 
            string[] files = Directory.GetFiles(@"BD_theory\Theory_list");

            //MessageBox.Show(files[1]);

            fileList = new List<file_theory>();
            for (int i = 0; i < files.Length; i++)
            {
                FileInfo fileInf = new FileInfo(files[i]);

                fileList.Add(new file_theory { name = fileInf.Name, path = files[i] });

            } 

            using (OleDbConnection connection = new OleDbConnection(@"Provider = Microsoft.jet.OLEDB.4.0;  data source = BD_theory\BDRus.mdb"))
            {
                String request = "DELETE * FROM Theory";
                connection.Open();
                OleDbCommand command1 = new OleDbCommand(request, connection);
                command1.ExecuteNonQuery();

                for (int i = 0; i < fileList.Count; i++)
                {
                    
                    request = string.Format("INSERT INTO Theory (id,name,path) VALUES({0},'{1}','{2}')",i+1 ,fileList[i].name.Substring(0, fileList[i].name.Length - 4), fileList[i].path);

                    OleDbCommand command = new OleDbCommand(request, connection);
                    command.ExecuteNonQuery(); 


                }

            }

        }

        // загрузка документа
        public void loadDOC(object fileName)
        {
            OpenFileDialog ofd = new OpenFileDialog();

            TextRange doc = new TextRange(TextDocumenta.Document.ContentStart, TextDocumenta.Document.ContentEnd);
            using (FileStream fs = new FileStream(fileName.ToString(), FileMode.Open))
            {
                doc.Load(fs, DataFormats.Rtf);
            }
        }


        // контекстный поиск
        private void ContextSearch()
        {
            TheoryList = new List<file_theory>();
            using (OleDbConnection connection = new OleDbConnection(@"Provider = Microsoft.jet.OLEDB.4.0;  data source = BD_theory\BDRus.mdb"))
            {
                connection.Open();
                //String request = "DELETE * FROM Theory";

                String request = string.Format("SELECT * FROM Theory WHERE name Like '%{0}%' ",searchBox.Text);

                OleDbCommand command = new OleDbCommand(request, connection);
                OleDbDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    { 
                        TheoryList.Add(new file_theory { name = reader.GetString(1), path = reader.GetString(2) }); 
                    }
                }


            }
            stack.Children.Clear();
        }

        TextBlock selectedBlock;
        TextBlock PselectedBlock;

        List<file_theory> TheoryList;
        
        // запрос на получение всей теории из списка
        private void insertInStack_files()
        {
            TheoryList = new List<file_theory>();
            using (OleDbConnection connection = new OleDbConnection(@"Provider = Microsoft.jet.OLEDB.4.0;  data source = BD_theory\BDRus.mdb"))
            {
                connection.Open(); 
                //String request = "DELETE * FROM Theory";

                String request = string.Format("SELECT * FROM Theory ");

                OleDbCommand command = new OleDbCommand(request, connection);
                OleDbDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {

                        TheoryList.Add(new file_theory { name = reader.GetString(1) , path = reader.GetString(2) });
                        //Console.Write(reader.GetInt32(0).ToString() + " " + reader.GetString(1) + " " + reader.GetString(2) + "\n");
                    }
                } 
            }
        }

        // добавление элементов теории в список
        public delegate void loadTh();
        public string selectedPath;
        private void load_theory(loadTh loadSettings)
        {
            insertInStack_files();

            loadTh Settings = loadSettings;
            Settings();



            for (int i = 0; i < TheoryList.Count; i++)
            {
                TextBlock tb = new TextBlock(); 
                tb.Width = Double.NaN;
                tb.Margin = new Thickness(0, 0, 0, 0);
                tb.Padding = new Thickness(10, 0, 0, 0);


                tb.TextWrapping = TextWrapping.Wrap;
                tb.Text = TheoryList[i].name;
                tb.Background = (Brush)System.ComponentModel.TypeDescriptor.GetConverter(typeof(Brush)).ConvertFromInvariantString("#616375");

                tb.FontSize = 14;
                tb.Foreground = (Brush)System.ComponentModel.TypeDescriptor.GetConverter(typeof(Brush)).ConvertFromInvariantString("White");

                string path_to_open = TheoryList[i].path;
                tb.MouseUp += delegate
                {
                    loadDOC(path_to_open);
                    selectedPath = path_to_open;



                    tb.Background = (Brush)System.ComponentModel.TypeDescriptor.GetConverter(typeof(Brush)).ConvertFromInvariantString("#6F7285");
                    tb.Foreground = (Brush)System.ComponentModel.TypeDescriptor.GetConverter(typeof(Brush)).ConvertFromInvariantString("#E8E9A0");
                    tb.FontWeight = FontWeights.Bold;

                    PselectedBlock = selectedBlock;
                    if (PselectedBlock != null)
                    {
                        PselectedBlock.FontWeight = FontWeights.Normal;
                        PselectedBlock.Background = (Brush)System.ComponentModel.TypeDescriptor.GetConverter(typeof(Brush)).ConvertFromInvariantString("#616375");
                        PselectedBlock.Foreground = (Brush)System.ComponentModel.TypeDescriptor.GetConverter(typeof(Brush)).ConvertFromInvariantString("White");
                        PselectedBlock.IsEnabled = true;
                    }

                    selectedBlock = tb;
                    selectedBlock.IsEnabled = false;


                    tema_name.Text = tb.Text;

                };
                tb.MouseEnter += delegate
                {
                    if (tb != selectedBlock)
                    {
                        tb.Background = (Brush)System.ComponentModel.TypeDescriptor.GetConverter(typeof(Brush)).ConvertFromInvariantString("#67697E");
                        tb.FontWeight = FontWeights.Bold;
                        tb.Foreground = (Brush)System.ComponentModel.TypeDescriptor.GetConverter(typeof(Brush)).ConvertFromInvariantString("White");
                    }

                };
                tb.MouseLeave += delegate
                {
                    if (tb != selectedBlock)
                    {
                        tb.Background = (Brush)System.ComponentModel.TypeDescriptor.GetConverter(typeof(Brush)).ConvertFromInvariantString("#616375");
                        tb.FontWeight = FontWeights.Normal;
                    }
                };


                stack.Children.Add(tb);
            }

        }

        // анимация мини меню 1
        private void MenuImage_MouseEnter(object sender, MouseEventArgs e)
        {
            menu_stack.Background = (Brush)System.ComponentModel.TypeDescriptor.GetConverter(typeof(Brush)).ConvertFromInvariantString("Gray"); 
            
        }
        // анимация мини меню2
        private void MenuImage_MouseLeave(object sender, MouseEventArgs e)
        {
            menu_stack.Background = (Brush)System.ComponentModel.TypeDescriptor.GetConverter(typeof(Brush)).ConvertFromInvariantString("#616375");
        } 
        // анимация мини меню3
        bool check_menu = true;
        private void MenuImage_MouseUp(object sender, MouseButtonEventArgs e)
        {

            if (check_menu)
            {
                DoubleAnimation gridAnimation = new DoubleAnimation();
                gridAnimation.From = 70;
                gridAnimation.To = 210;
                gridAnimation.Duration = TimeSpan.FromSeconds(0.2);
                gridAnimation.FillBehavior = FillBehavior.Stop;
                gridAnimation.Completed += delegate
                {
                    menu_stack.BeginAnimation(Grid.WidthProperty, null);
                    menu_stack.Width = 210;

                };
                menu_stack.BeginAnimation(Grid.WidthProperty, gridAnimation);
                check_menu = false;
            }
            else
            {
                DoubleAnimation gridAnimation = new DoubleAnimation();
                gridAnimation.From = 210;
                gridAnimation.To = 70;
                gridAnimation.Duration = TimeSpan.FromSeconds(0.2);
                gridAnimation.FillBehavior = FillBehavior.Stop;
                gridAnimation.Completed += delegate
                {
                    menu_stack.BeginAnimation(Grid.WidthProperty, null);
                    menu_stack.Width = 70;

                };
                menu_stack.BeginAnimation(Grid.WidthProperty, gridAnimation);
                check_menu = true;
            }

              
        }
         
        //изменение текста вв поиске по теории
        private void SearchBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            //Console.WriteLine(searchBox.Text);

            load_theory(ContextSearch);
        }


        // пробразование массива чар в строку
        private string toString(char[] stroke)
        {
            string s = "";
            for (int i = 0; i < stroke.Length; i++)
            {
                s += stroke[i];
            }
            return s;
        }

        

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
             
            text1.IsReadOnly = false; 
            //text1.LockCurrentUndoUnit();
        }

        //получение символов с лева и с права от курсора
        private void whrerCursor(TextBox textBox, ref char L, ref char R, ref int indexL, ref int indexR)
        {
            if (textBox.CaretIndex != 0)
            {
                L = textBox.Text[textBox.CaretIndex - 1];
                indexL = textBox.CaretIndex - 1;
            }

            if (textBox.CaretIndex != textBox.Text.Length)
            {
                R = textBox.Text[textBox.CaretIndex];
                indexR = textBox.CaretIndex;
            }
        }

         

        /// <summary>
        /// переработоно
        /// </summary>
        /// 
        private bool isRussian( char c)
        {
            return (c >= 'А' && c <= 'я') || c == 'ё' || c == 'Ё';
        }

         

        private void insert_simbols_in_text(TextBox textBox )
        {
            // переменные под распознавание символов 
              
            char[] changed_text;
            char L = ' ', R = ' ';
            int indexL = 0, indexR = 0;

            whrerCursor(textBox, ref L, ref R, ref indexL, ref indexR);

            //Console.WriteLine("1 " + L + " : " + R);
            if (L == '_' || R == '_')
            {
                Training_Rus_WPF.FormInputed dialog = new Training_Rus_WPF.FormInputed();
                var windowPosition = Mouse.GetPosition(this);
                var screenPosition = this.PointToScreen(windowPosition);
                dialog.Top = screenPosition.Y;
                dialog.Left = screenPosition.X;

                dialog.ShowDialog();

                if (dialog.result == FormInputed.DialogRes.Ok && dialog.Value != null && dialog.Value != " ")
                {
                    changed_text = textBox.Text.ToCharArray();

                    if (L == '_')
                    {
                        changed_text[indexL] = Convert.ToChar(dialog.Value);
                    }
                    if (R == '_')
                    {
                        changed_text[indexR] = Convert.ToChar(dialog.Value);
                    }

                    textBox.Text = toString(changed_text);
                }

            }
            if (isRussian(L) && R == ' ')
            {
                Training_Rus_WPF.FormInputed dialog = new Training_Rus_WPF.FormInputed();
                var windowPosition = Mouse.GetPosition(this);
                var screenPosition = this.PointToScreen(windowPosition);
                dialog.Top = screenPosition.Y;
                dialog.Left = screenPosition.X;

                dialog.set_comma();

                dialog.ShowDialog();

                if (dialog.result == FormInputed.DialogRes.Ok && dialog.Value != null && dialog.Value != " ")
                {
                    changed_text = textBox.Text.ToCharArray();

                    if (isRussian(L))
                    {
                        changed_text[indexR] = Convert.ToChar(dialog.Value);

                    }

                    
                    textBox.Text = toString(changed_text).Insert(indexR + 1, " ");
                }

            }

            textBox.CaretIndex = indexR;
            
            //whrerCursor(textBox, ref L, ref R, ref indexL, ref indexR);
            Console.WriteLine("2 " + L + " : " + R);
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            set_texts();
        }



        //private void Button_Click_5(object sender, RoutedEventArgs e)
        //{
        //    try
        //    {
        //        word.Application app = new word.Application();
        //        app.Visible = true;
        //        app.Documents.Open(selectedPath);
        //        app.Documents[0].PrintPreview();
        //        //app.Documents[0].Close();
        //    }
        //    catch (Exception)
        //    {

                 
        //    }
             
        //}
    }
} 