using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz
{
    public class Questions
    {
        Guid id1 = Guid.NewGuid();
        public Guid Id
        {
            get { return id1; }
        }
        public string Content { get; set; }
        public int CorrectAnswer { get; set; }
        public string Answer1 { get; set; }
        public string Answer2 { get; set; }
        public string Answer3 { get; set; }

        public Questions(string Content, int Correct, string Answer1, string Answer2, string Answer3)
        {
            Guid Id;
            this.Content = Content;
            CorrectAnswer = Correct;
            this.Answer1 = Answer1;
            this.Answer2 = Answer2;
            this.Answer3 = Answer3;
        }

        public static List<T> Random<T>(List<T> list)
        {
            List<T> List = new List<T>();
            Random rnd = new Random();
            while (list.Count > 0)
            {
                int index = rnd.Next(0, list.Count);
                List.Add(list[index]);
                list.RemoveAt(index);
            }
            return List;
        }
    }

    public class Answers
    {
        public Guid AnswerID { get; set; }
        public int QuestionsAnswered { get; set; }

        public Answers(int QuestionsAnswered)
        {
            this.QuestionsAnswered = QuestionsAnswered;
        }
    }

    public class Database
    {
        public List<Questions> Question = new List<Questions>()
        {
            new Questions("Kiedy powołana została PWSIP?", 1, "22 czerwca 2004", "25 marca 2003", "25 czerwa 2004"),
            new Questions("Jakie kierunki istnieją na uczelni?", 2, "malarstwo", "informatyka", "lotnictwo"),
            new Questions("Jakiej specjalizacji nie ma na kierunku informatyka?", 3, "grafika", "oprogramowanie", "sieci"),
            new Questions("Jaki kolor jest charakterystyczny dla PWSIP?", 1, "czerwony", "zielony", "żółty"),
            new Questions("Jak nazywa się dom studenta PWSIP?", 2, "Rubin", "Rubikon", "Esmerald"),
            new Questions("Jakie nazwisko nosi rektor uczelni?", 3, "Stasik", "Srebrzycki", "Surowik"),
            new Questions("Który z wydziałów nie istnieje na PWSIP?", 1, "Sportu i Rekreacji", "Informatyki i Nauk o Żywności", "Nauk Społecznych i Humanistycznych"),
            new Questions("Na jakiej ulicy znajduje się główny budynek uczelni?", 2, "Wiejska", "Akademicka", "Administracyjna"),
            new Questions("Jak nazywa się ssytem biblioteczny PWSIP?", 3, "GOHA", "LOHA", "KOHA"),
            new Questions("Co jest w logo uczelni?", 1, "Budynek", "Orzeł", "Nie ma nic")
        };

        public static Database getInstance { get; } = new Database();

        public List<Answers> Answer = new List<Answers>(10)
        {
            new Answers(0),
            new Answers(0),
            new Answers(0),
            new Answers(0),
            new Answers(0),
            new Answers(0),
            new Answers(0),
            new Answers(0),
            new Answers(0),
            new Answers(0)
        };
    }
}
