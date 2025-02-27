﻿using System.IO;
using System.Runtime.CompilerServices;

namespace The_idiot_genius
{
    class Program
    {
        static void Main(string[] args)
        {
            var userName = GetUserName();
            string[] questions = GetQuestions();
            int[] answers = GetAnswers();

            var correctAnswersCount = 0;

            for (int i = 0; i < questions.Length; i++)
            {
                Console.Clear();
                Console.Write(questions[i] + ": ");

                var userAnswer = GetUserAnswer();

                if (userAnswer == answers[i])
                {
                    correctAnswersCount++;
                }
            }

            Console.Clear();
            Console.WriteLine($"{userName}, вы ответили правильно на {correctAnswersCount} из {questions.Length} вопросов.");

            var diagnose = CalculateDiagnose(correctAnswersCount, answers.Length);
            SaveData(userName, correctAnswersCount, diagnose);

            Console.WriteLine($"Официально вы {diagnose}");

            Console.WriteLine("Желаете ознакомиться с предыдущими результатами игр? Введите да/нет");
            var yesOrNo = Console.ReadLine();

            while (yesOrNo.ToLower() != "да" && yesOrNo.ToLower() != "нет")
            {
                Console.WriteLine("Введите 'да' или 'нет':");
                yesOrNo = Console.ReadLine().ToLower();
            }

            if (yesOrNo.ToLower() == "да")
            {
                StreamReader dataFile = new StreamReader("data.txt");
                var line = dataFile.ReadLine();

                while (line != null)
                {
                    Console.WriteLine(line);

                    line = dataFile.ReadLine();
                }

                dataFile.Close();
            }
            else
            {
                Console.WriteLine("Хорошо, спасибо за игру!");
            }

            Console.ReadLine();


        }

        private static void SaveData(string name, int correctAnswer, string diagnose)
        {

            var dataFile = new StreamWriter("data.txt", true);

            dataFile.WriteLine(name + "\t" + correctAnswer + "\t" + diagnose);


            dataFile.Close();

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

            var correctAnswersProcent = correctAnswersCount * 100 / allAnswersCount;

            var diagnose = diagnoses[(correctAnswersProcent + 19) / 20];


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
            var userName = Console.ReadLine();

            return userName;
        }
    }
}