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

namespace WPF_millionaire
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Button> _button;
        List<TextBlock> _textBlockMoney;
        List<TextBlock> _textBlockNumber;

        List<Question> _question;
        XML_File _XML;
        Help _help;

        int _questionNumberBoard;
        int _index; //
        int _questionNumber = 0; //номер вопроса
        int _money;
        int _fireproofAmount; //не сгораемая суммв

        public MainWindow()
        {
            InitializeComponent();
            _button = new List<Button>();
            _button.Add(bt0);
            _button.Add(bt1);
            _button.Add(bt2);
            _button.Add(bt3);
            
            _XML = new XML_File();
        }

        private void CloseWindow(object sender, RoutedEventArgs e)
        {
            // this.Close();
            // Environment.Exit(0);
        }

        //public void AddQuestion(string question, List<string> answerStr, string trueAnswer)
        //{
        //    _XML = new XML_File();
        //    _XML.Load("XMLFile1.xml");

        //    var gameEl = _doc.CreateElement("game"); //тег, который хранит в себе вопрос и ответы

        //    var questionEl = _doc.CreateElement("question"); //вложенный тег, который хранит вопрос
        //    questionEl.InnerText = question; //собственно сам вопрос
        //    gameEl.AppendChild(questionEl); //теперь он точновложенный

        //    var answersEl = _doc.CreateElement("answers"); //вложенный тег с ответами
        //    gameEl.AppendChild(answersEl);

        //    for (int i = 0; i < answerStr.Count; i++)
        //    {
        //        var answer = _doc.CreateElement("answer"); //будущие потомки тега answers(answersEl)
        //        answer.InnerText = answerStr[i];
        //        answersEl.AppendChild(answer); //уже точно потомки
        //        if (answerStr[i].Equals(trueAnswer))
        //        {
        //            var Attr = _doc.CreateAttribute("bool");
        //            Attr.Value = "true";
        //            answer.Attributes.Append(Attr);
        //        }
        //    }

        //    _doc.DocumentElement.AppendChild(gameEl); // добавляем данные в файл
        //    _doc.Save("XMLFile1.xml");
        //}

        private void StartGame(object sender, RoutedEventArgs e)
        {
            ReturnButtonImage();

            MainMenu.Visibility = Visibility.Hidden;
            game.Visibility = Visibility.Visible;
            End.Visibility = Visibility.Hidden;

            _help = new Help();
            _question = new List<Question>();
            _XML.Read(_question);

            if (BoardMoney.Children.Count != 0)
            {
                for (int i = 0; i < _textBlockMoney.Count; i++)
                {
                    BoardMoney.Children.Remove(_textBlockMoney[i]);
                }
            }
            if (NumberQuestion.Children.Count != 0)
            {
                for (int i = 0; i < _textBlockNumber.Count; i++)
                {
                    NumberQuestion.Children.Remove(_textBlockNumber[i]);
                }
            }

            for (int i = 0; i < _button.Count; i++)
            {
                _button[i].Visibility = Visibility.Visible;
            }

            MainMenu.Visibility = Visibility.Hidden;
            game.Visibility = Visibility.Visible;

            _textBlockMoney = new List<TextBlock>();
            _textBlockNumber = new List<TextBlock>();
            for (int i = 0; i < 15; i++)
            {
                TextBlock text = new TextBlock();
                text.FontSize = 13d;
                text.Margin = new Thickness(-1, 3, 8, 3);
                text.Foreground = Brushes.Orange;
                _textBlockMoney.Add(text);
                BoardMoney.Children.Add(_textBlockMoney[i]);
            }
            for (int i = 0, j = 15; i < 15; i++, j--)
            {
                TextBlock text = new TextBlock();
                text.FontSize = 13d;
                text.Margin = new Thickness(8, 3, 0, 3);
                text.Padding = new Thickness(5, 0, 10, 0);
                text.Text = j.ToString();
                text.Foreground = Brushes.Orange;
                _textBlockNumber.Add(text);
                NumberQuestion.Children.Add(_textBlockNumber[i]);
            }
            //заполняем её данными
            _textBlockMoney[0].Text = "1000000";
            _textBlockMoney[0].Foreground = Brushes.White;
            _textBlockNumber[0].Foreground = Brushes.White;
            _textBlockMoney[1].Text = "500000";
            _textBlockMoney[2].Text = "250000";
            _textBlockMoney[3].Text = "125000";
            _textBlockMoney[4].Text = "64000";
            _textBlockMoney[5].Text = "32000";
            _textBlockMoney[5].Foreground = Brushes.White;
            _textBlockNumber[5].Foreground = Brushes.White;
            _textBlockMoney[6].Text = "16000";
            _textBlockMoney[7].Text = "8000";
            _textBlockMoney[8].Text = "4000";
            _textBlockMoney[9].Text = "2000";
            _textBlockMoney[10].Text = "1000";
            _textBlockMoney[10].Foreground = Brushes.White;
            _textBlockNumber[10].Foreground = Brushes.White;
            _textBlockMoney[11].Text = "500";
            _textBlockMoney[12].Text = "300";
            _textBlockMoney[13].Text = "200";
            _textBlockMoney[14].Text = "100";
            _textBlockMoney[14].Background = Brushes.Orange;
            _textBlockNumber[14].Background = Brushes.Orange;
            _textBlockMoney[14].Foreground = Brushes.Black;
            _textBlockNumber[14].Foreground = Brushes.Black;

            _money = 0;
            _fireproofAmount = 0;
            _questionNumberBoard = 14;
            _questionNumber = 0;

            Draw1();
            Draw2();
            //помещаем их на кнопки
            MyRandom();
        }

        private void MyRandom()
        {
            Random rand = new Random();
            
                try
                {
                _index = rand.Next(0, _question.Count);
                    question.Text = _question[_index].QuestionStr;
                    for (int i = 0; i < 4; i++)
                    {
                    if (i == 0)
                        _button[i].Content = string.Format("A. {0}", _question[_index].Answer[i]);
                    else if (i == 1)
                        _button[i].Content = string.Format("B. {0}", _question[_index].Answer[i]);
                    else if (i == 2)
                        _button[i].Content = string.Format("C. {0}", _question[_index].Answer[i]);
                    else if (i == 3)
                        _button[i].Content = string.Format("D. {0}", _question[_index].Answer[i]);
                    _button[i].Visibility = Visibility.Visible;
                }

                }
                catch (Exception)
                {
                    MessageBox.Show("");
                }
        }

        private void Draw1()
        {
            if (_questionNumberBoard == 14 || _questionNumberBoard == 10 || _questionNumberBoard == 5)
            {
                _textBlockMoney[_questionNumberBoard].Foreground = Brushes.White;
                _textBlockNumber[_questionNumberBoard].Foreground = Brushes.White;
                _textBlockMoney[_questionNumberBoard].Background = Brushes.Black;
                _textBlockNumber[_questionNumberBoard].Background = Brushes.Black;
            }
            else
            {
                _textBlockMoney[_questionNumberBoard].Foreground = Brushes.Orange;
                _textBlockNumber[_questionNumberBoard].Foreground = Brushes.Orange;
                _textBlockMoney[_questionNumberBoard].Background = Brushes.Black;
                _textBlockNumber[_questionNumberBoard].Background = Brushes.Black;
            }
        }

        private void Draw2()
        {
            _textBlockMoney[_questionNumberBoard].Foreground = Brushes.Black;
            _textBlockNumber[_questionNumberBoard].Foreground = Brushes.Black;
            _textBlockMoney[_questionNumberBoard].Background = Brushes.Orange;
            _textBlockNumber[_questionNumberBoard].Background = Brushes.Orange;
        }

        private void Click(object sender, RoutedEventArgs e)
        {
            Button b = (Button)sender;
            for (int i = 0; i < _button.Count; i++)
            {
                if (b.Content == _button[i].Content)
                {
                    if (_question[_index].TrueAnswer.Equals(b.Content.ToString().Remove(0, 3)))
                    {
                        try
                        {
                            _money = Convert.ToInt32(_textBlockMoney[_questionNumberBoard].Text);
                            if (_money == 100 || _money == 1000 || _money == 32000)
                            {
                                _fireproofAmount = _money;
                            }
                            if (_questionNumberBoard - 1 == -1)
                            {
                                //MessageBox.Show("You win");
                                winOrLose.Text = "Вы победили!\nВаш выигрыш 1000000.";
                                End.Visibility = Visibility.Visible;
                                game.Visibility = Visibility.Hidden;
                                return;
                            }
                            _question.RemoveAt(_index);
                            Draw1();
                            _questionNumberBoard--;
                            Draw2();
                            _questionNumber++;

                            MyRandom();
                        }
                        catch (ArgumentOutOfRangeException ex)
                        {
                            MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                            MainMenu.Visibility = Visibility.Visible;
                            game.Visibility = Visibility.Hidden;
                        }
                    }
                    else
                    {
                        winOrLose.Text = string.Format("Вы проиграли!\nВаш выигрыш {0}", _fireproofAmount);
                        
                        End.Visibility = Visibility.Visible;
                        game.Visibility = Visibility.Hidden;
                        return;
                    }
                }
            }
        }
        private void FiftyFiftyClick(object sender, RoutedEventArgs e)
        {
            _help.MethodFiftyFifty(_button, _question[_index].TrueAnswer);
            Uri u = new Uri(@"pack://application:,,,/Image/fiftyFifty2.png");
            BitmapImage img = new BitmapImage();
            img.BeginInit();
            img.UriSource = u;
            img.EndInit();
            ButtonFiftyFifty.Content = new Image() { Source = img };
        }

        private void HallClick(object sender, RoutedEventArgs e)
        {
            _help.MethodHall(_button, _question[_index].TrueAnswer);
            Uri u = new Uri(@"pack://application:,,,/Image/hall2.png");
            BitmapImage img = new BitmapImage();
            img.BeginInit();
            img.UriSource = u;
            img.EndInit();
            ButtonHall.Content = new Image() { Source = img };
        }

        private void CallClick(object sender, RoutedEventArgs e)
        {
            _help.MethodCall(_button, _question[_index].TrueAnswer);
            Uri u = new Uri(@"pack://application:,,,/Image/call2.png");
            BitmapImage img = new BitmapImage();
            img.BeginInit();
            img.UriSource = u;
            img.EndInit();
            ButtonCall.Content = new Image() { Source = img };
        }

        private void ReturnButtonImage()
        {
            Uri u = new Uri(@"pack://application:,,,/Image/fiftyFifty1.png");
            BitmapImage img = new BitmapImage();
            img.BeginInit();
            img.UriSource = u;
            img.EndInit();
            ButtonFiftyFifty.Content = new Image() { Source = img };
            //
            u = new Uri(@"pack://application:,,,/Image/hall1.png");
            img = new BitmapImage();
            img.BeginInit();
            img.UriSource = u;
            img.EndInit();
            ButtonHall.Content = new Image() { Source = img };
            //
            u = new Uri(@"pack://application:,,,/Image/call1.png");
            img = new BitmapImage();
            img.BeginInit();
            img.UriSource = u;
            img.EndInit();
            ButtonCall.Content = new Image() { Source = img };
        }

        private void ExitClick(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(string.Format("Ваш выигрыш {0}", _money));
            MainMenu.Visibility = Visibility.Visible;
            game.Visibility = Visibility.Hidden;
            End.Visibility = Visibility.Hidden;
        }

        private void MainMenuClick(object sender, RoutedEventArgs e)
        {
            MainMenu.Visibility = Visibility.Visible;
            game.Visibility = Visibility.Hidden;
            End.Visibility = Visibility.Hidden;
        }
    }
}
