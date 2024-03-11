using ApplicationCore.Interfaces.Repository;
using BackendLab01;

namespace Infrastructure.Memory;
public static class SeedData
{
    public static void Seed(this WebApplication app)
    {
        IGenericRepository<Quiz, int>? quizRepo;
        using (var scope = app.Services.CreateScope())
        {
            var provider = scope.ServiceProvider;
            quizRepo = provider.GetService<IGenericRepository<Quiz, int>>();
            var quizItemRepo = provider.GetService<IGenericRepository<QuizItem, int>>();
        }

        
        var quizItems1 = new List<QuizItem>()
        {
            new QuizItem(1,
                "What is the output of the following code snippet in C#?\nint x = 5;\nint y = 3;\nConsole.WriteLine(x + y * 2);\n",
                new List<string> { "13", "15", "17" }, "11"),
            new QuizItem(2, "What does the acronym 'HTML' stand for?",
                new List<string>
                {
                    "High Tech Machine Learning", "Home Tool Management Language", "Hotel Transfer Markup Logic"
                },
                "Hyper Text Markup Language"),
            new QuizItem(3, "Which of the following is NOT a programming language?",
                new List<string> { "Python", "Java", "C++" }, "HTML"),
            new QuizItem(4, "What does the 'SQL' acronym stand for?",
                new List<string>
                    { "Sequential Query Language", "Simple Query Language", "Standardized Query Language" },
                "Structured Query Language")
        };


        var quizItems2 = new List<QuizItem>()
        {
            new QuizItem(1, "Which city is the capital of Poland?",
                new List<string> { "Krakow", "Gdansk", "Wroclaw" }, "Warsaw"),
            new QuizItem(2, "What is the name of the longest river in Poland?",
                new List<string> { "Odra", "Warta", "Bug" }, "Vistula"),
            new QuizItem(3, "Which historical event marked the beginning of World War II and involved Poland?",
                new List<string> { "Battle of Warsaw", "Polish-Soviet War", "Warsaw Uprising" },
                "Invasion of Poland"),
            new QuizItem(4, "What is the name of the famous salt mine located near Krakow, Poland?",
                new List<string> { "Bochnia Salt Mine", "Kłodawa Salt Mine", "Kopalnia Soli " },
                "Wieliczka Salt Mine")
        };

        // foreach (var q in quizItems1)
        // {
        //     quizItemRepo.Add(q);
        // }
        //
        // foreach (var q in quizItems2)
        // {
        //     quizItemRepo.Add(q);
        // }

        Quiz quiz1 = new Quiz(1, quizItems1, "Programing quiz");
        Quiz quiz2 = new Quiz(2, quizItems2, "Poland Trivia Quiz");

        quizRepo.Add(quiz1);
        quizRepo.Add(quiz2);
    }
}