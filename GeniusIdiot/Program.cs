namespace The_idiot_genius
{
    class Program
    {
        static void Main(string[] args)
        {
            string userName = GetUserName();
            string[] questions = GetQuestions();
            int[] answers = GetAnswers();

            int correctAnswersCount = 0;

            for (int i = 0; i < questions.Length; i++)
            {
                Console.Clear();
                Console.Write(questions[i] + ": ");

                int userAnswer = GetUserAnswer();

                if (userAnswer == answers[i])
                {
                    correctAnswersCount++;
                }
            }

            Console.Clear();
            Console.WriteLine($"{userName}, вы ответили правильно на {correctAnswersCount} из {questions.Length} вопросов.");

            string diagnose = CalculateDiagnose(correctAnswersCount, answers.Length);
            Console.WriteLine($"Официально вы {diagnose}");

            Console.ReadLine();


        }
        static int GetUserAnswer()
        {
            while (true)
            {
                try
                {
                    return Convert.ToInt32(Console.ReadLine());
                }
                catch (Exception)
                {
                    Console.WriteLine("Введите пожалуйста число!");
                }
            }

        }

        private static string CalculateDiagnose(int correctAnswersCount, int allAnswersCount)
        {
            string[] diagnoses = {
                "Идиот",
                "Кретин",
                "Дурак",
                "Нормальный",
                "Талантливый",
                "Гений",
            };

            int correctAnswersProcent = correctAnswersCount * 100 / allAnswersCount;

            string diagnose = diagnoses[(correctAnswersProcent + 19) / 20];
            return diagnose;
        }

        private static int[] GetAnswers()
        {
            return new int[] { 6, 9, 25, 60, 2 };
        }

        private static string[] GetQuestions()
        {
            return new string[]{
                "Сколько будет 2+2*2",
                "Сколько раз нужно разрезать бревно, чтобы получить 10 кусочков",
                "На двух руках 10 пальцев, сколько пальцев на 5 руках",
                "Один укол делают 30 мин, за сколько поставят 3 укола",
                "5 свечей горело, 2 потухло, сколько осталось"
            };
        }

        private static string GetUserName()
        {
            Console.Write("Введите ваше Имя: ");
            string userName = Console.ReadLine();

            return userName;
        }
    }
}