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

namespace Quiz
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int Index = 0;
        int Radio = 0;
        int Score = 0;
        

        public MainWindow()
        {
            InitializeComponent();
            FirstPage();
        }

        public void FirstPage()
        {
            Back.Visibility = Visibility.Hidden;
            Question.Content = Database.getInstance.Question[Index].Content;
            Answer1.Content = Database.getInstance.Question[Index].Answer1;
            Answer2.Content = Database.getInstance.Question[Index].Answer2;
            Answer3.Content = Database.getInstance.Question[Index].Answer3;
        }

        public void PreviousPage()
        {
            Finish.Visibility = Visibility.Hidden;
            Next.Visibility = Visibility.Visible;
            Index--;

            if (Index == 0)
            {
                Back.Visibility = Visibility.Hidden;
            }

            Radio = Database.getInstance.Answer[Index].QuestionsAnswered;

            if (Radio == 1)
            {
                Answer1.IsChecked = true;
            }
            else if (Radio == 2)
            {
                Answer2.IsChecked = true;
            }
            else if (Radio == 3)
            {
                Answer3.IsChecked = true;
            }

            Question.Content = Database.getInstance.Question[Index].Content;
            Answer1.Content = Database.getInstance.Question[Index].Answer1;
            Answer2.Content = Database.getInstance.Question[Index].Answer2;
            Answer3.Content = Database.getInstance.Question[Index].Answer3;
        }

        public void NextPage()
        {
            Index++;
            Question.Content = Database.getInstance.Question[Index].Content;
            Answer1.Content = Database.getInstance.Question[Index].Answer1;
            Answer2.Content = Database.getInstance.Question[Index].Answer2;
            Answer3.Content = Database.getInstance.Question[Index].Answer3;

            Save();
            Database.getInstance.Answer[Index - 1].QuestionsAnswered = Radio;

            if (Database.getInstance.Answer[Index].QuestionsAnswered != 0)
            {
                Radio = Database.getInstance.Answer[Index].QuestionsAnswered;
                if (Radio == 1)
                {
                    Answer1.IsChecked = true;
                }
                else if (Radio == 2)
                {
                    Answer2.IsChecked = true;
                }
                else if (Radio == 3)
                {
                    Answer3.IsChecked = true;
                }
            }
            else
            {
                Answer1.IsChecked = false;
                Answer2.IsChecked = false;
                Answer3.IsChecked = false;
            }
        }

        public void Save()
        {
            if (Index == 9)
            {
                Next.Visibility = Visibility.Hidden;
                Finish.Visibility = Visibility.Visible;
            }
            else if (Index > 0 && Index < 9)
            {
                Back.Visibility = Visibility.Visible;
            }

            if (Answer1.IsChecked ?? true)
            {
                Radio = 1;
            }
            else if (Answer2.IsChecked ?? true)
            {
                Radio = 2;
            }
            else if (Answer3.IsChecked ?? true)
            {
                Radio = 3;
            }
            else
            {
                Radio = 0;
            }
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            PreviousPage();
        }

        private void Next_Click(object sender, RoutedEventArgs e)
        {
            NextPage();
        }

        private void Finish_Click(object sender, RoutedEventArgs e)
        {
            Save();
            Database.getInstance.Answer[Index].QuestionsAnswered = Radio;
            int num = 0;
            int answ;
            foreach (Questions quest in Database.getInstance.Question)
            {
                answ = Database.getInstance.Answer[num].QuestionsAnswered;
                if (quest.CorrectAnswer == answ)
                {
                    Score++;
                }
                num++;
            }
            MessageBox.Show("Twój wynik to: "+Score+"/10");
            this.Close();
        }
    }
}
