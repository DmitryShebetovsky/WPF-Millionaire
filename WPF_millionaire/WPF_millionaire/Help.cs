using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace WPF_millionaire
{
    class Help
    {
        DiagramWindow _diagram;
        Random _rand;
        bool _friend;
        bool _fiftyFifty;
        bool _hall;

        public Help()
        {
            _rand = new Random();
            _friend = true;
            _fiftyFifty = true;
            _hall = true;
        }

        public bool Friend
        {
            get { return _friend; }
            // set { _friend = value; }
        }

        public bool FiftyFifty
        {
            get { return _fiftyFifty; }
            // set { _fiftyFifty = value; }
        }

        public bool Hall
        {
            get { return _hall; }
            //set { _hall = value; }
        }

        public void MethodFiftyFifty(List<Button> b, string trueAnswer)
        {
            if (_fiftyFifty)
            {
                _fiftyFifty = false;
                int trueButton = 0;
                for (int i = 0; i < b.Count; i++)
                {
                    string str = b[i].Content.ToString();
                    if (trueAnswer.Equals(str.Remove(0, 3)))
                    {
                        trueButton = i;
                    }
                }


                int falseButton = _rand.Next(0, 4);
                while (falseButton == trueButton)
                {
                    falseButton = _rand.Next(0, 4);
                }

                for (int i = 0; i < 4; i++)
                {
                    if (i == trueButton || i == falseButton)
                    {
                        continue;
                    }
                    b[i].Content = "";
                    b[i].Visibility = Visibility.Hidden;
                }
            }
        }

        public void MethodHall(List<Button> b, string trueAnswer)
        {
            if (_hall)
            {
                _hall = false;
                _diagram = new DiagramWindow();
                _diagram.WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;

                int count = 0;
                for (int i = 0; i < 4; i++)
                {
                    if (!b[i].Content.Equals(""))
                    {
                        count++;
                    }
                }
                int trueButton = 0;
                for (int i = 0; i < b.Count; i++)
                {
                    string str = b[i].Content.ToString();
                    if (!str.Equals("") && trueAnswer.Equals(str.Remove(0, 3)))
                    {
                        trueButton = i;
                    }
                }
                if (count == 4)
                {
                    int[] array = { 0, 0, 0, 0 };

                    array[trueButton] = 5;

                    int index = 0;
                    for (int i = 0; i < 15; i++)
                    {
                        index = _rand.Next(0, 4);
                        array[index]++;
                    }

                    float percent = ((float)_diagram.window.Height - (float)_diagram.text.Height) / 23f;

                    _diagram.rectangleA.Height = array[0] * percent;
                    _diagram.rectangleB.Height = array[1] * percent;
                    _diagram.rectangleC.Height = array[2] * percent;
                    _diagram.rectangleD.Height = array[3] * percent;
                }
                else if (count == 2)
                {
                    int falseButton = 0;
                    int[] array = { 0, 0, 0, 0 };
                    for (int i = 0; i < 4; i++)
                    {
                        if (!b[i].Content.Equals("") && i != trueButton)
                        {
                            falseButton = i;
                        }
                    }
                    array[trueButton] = 8;

                    float percent = ((float)_diagram.window.Height - (float)_diagram.text.Height) / 23f;

                    int index = 0;
                    for (int i = 0; i < 12; i++)
                    {
                        while (true)
                        {
                            index = _rand.Next(0, 4);
                            if (index == trueButton)
                            {
                                break;
                            }
                            else if (index == falseButton)
                            {
                                break;
                            }
                        }
                        array[index]++;
                    }

                    _diagram.rectangleA.Height = array[0] * percent;
                    _diagram.rectangleB.Height = array[1] * percent;
                    _diagram.rectangleC.Height = array[2] * percent;
                    _diagram.rectangleD.Height = array[3] * percent;
                }
                _diagram.Show();
            }
        }

        public void MethodCall(List<Button> b, string trueAnswer)
        {
            if (_friend)
            {
                _friend = false;
                int count = 0;
                for (int i = 0; i < 4; i++)
                {
                    if (!b[i].Content.Equals(""))
                    {
                        count++;
                    }
                }
                int trueButton = 0;

                for (int i = 0; i < b.Count; i++)
                {
                    string str = b[i].Content.ToString();
                    if (!str.Equals("") && trueAnswer.Equals(str.Remove(0, 3)))
                    {
                        trueButton = i;
                    }
                }

                if (count == 4)
                {
                    int[] array = { 0, 0, 0, 0 };

                    array[trueButton] = 5;

                    int index = 0;
                    for (int i = 0; i < 15; i++)
                    {
                        index = _rand.Next(0, 4);
                        array[index]++;
                    }
                    //MessageBox.Show(array.Max().ToString());
                    if (array[0] == array.Max())
                        MessageBox.Show(string.Format("Я думаю, что это вариант A"));
                    else if (array[1] == array.Max())
                        MessageBox.Show(string.Format("Я думаю, что это вариант B"));
                    else if (array[2] == array.Max())
                        MessageBox.Show(string.Format("Я думаю, что это вариант C"));
                    else if (array[3] == array.Max())
                        MessageBox.Show(string.Format("Я думаю, что это вариант D"));
                    //return array.Max();
                }
                else if (count == 2)
                {
                    int falseButton = 0;
                    int[] array = { 0, 0, 0, 0 };
                    for (int i = 0; i < 4; i++)
                    {
                        if (!b[i].Content.Equals("") && i != trueButton)
                        {
                            falseButton = i;
                        }
                    }
                    array[trueButton] = 8;

                    int index = 0;
                    for (int i = 0; i < 12; i++)
                    {
                        while (true)
                        {
                            index = _rand.Next(0, 4);
                            if (index == trueButton)
                            {
                                break;
                            }
                            else if (index == falseButton)
                            {
                                break;
                            }
                        }
                        array[index]++;
                    }
                    if (array[0] == array.Max())
                        MessageBox.Show(string.Format("Я думаю, что это вариант A"));
                    else if (array[1] == array.Max())
                        MessageBox.Show(string.Format("Я думаю, что это вариант B"));
                    else if (array[2] == array.Max())
                        MessageBox.Show(string.Format("Я думаю, что это вариант C"));
                    else if (array[3] == array.Max())
                        MessageBox.Show(string.Format("Я думаю, что это вариант D"));
                    // return array.Max();
                }
            }
            ///
            //return -1;
        }

    }
}
