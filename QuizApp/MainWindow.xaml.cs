using System.Windows;
using Microsoft.EntityFrameworkCore;

namespace QuizApp;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }

    private void Window_Loaded(object sender, RoutedEventArgs e)
    {
        InitDatabase();
    }

    private void InitDatabase()
    {
        MyDataContext fileData = new MyDataContext();
        fileData.Database.EnsureCreated();

        if (fileData.Tests.Any() == false)
        {
            TestEntity test = new TestEntity();
            test.Title = "Основи C#";
            test.Description = "Перевіряє знання по рівню C# - Змінні, Оператори умови, Цикли";
            test.TimeLimitMinutes = 15;
            fileData.Tests.Add(test);
            fileData.SaveChanges();
        }

        if (fileData.Questions.Any() == false)
        {
            TestEntity test = fileData.Tests.First();

            test.Questions.Add(new QuestionEntity
            {
                Text = "Який тип даних використовується для цілих чисел?",
                Answers =
                {
                    new AnswerEntity { Text = "int", IsCorrect = true },
                    new AnswerEntity { Text = "string", IsCorrect = false },
                    new AnswerEntity { Text = "bool", IsCorrect = false }
                }
            });

            test.Questions.Add(new QuestionEntity
            {
                Text = "Який оператор використовується для умови?",
                Answers =
                {
                    new AnswerEntity { Text = "if", IsCorrect = true },
                    new AnswerEntity { Text = "for", IsCorrect = false },
                    new AnswerEntity { Text = "while", IsCorrect = false }
                }
            });

            fileData.SaveChanges();
        }

        int countTest = fileData.Tests.Count();
        MessageBox.Show("Кількість тестів в БД: " + countTest);
        StatusText.Text = "База готова";
    }
}
