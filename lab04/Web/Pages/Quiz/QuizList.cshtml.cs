using ApplicationCore.Interfaces.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.CodeAnalysis.Elfie.Serialization;

namespace BackendLab01.Pages
{
    public class QuizList : PageModel
    {
        private readonly IGenericRepository<BackendLab01.Quiz, int> _quizRepo;

        public QuizList(IGenericRepository<BackendLab01.Quiz, int> quizRepo)
        {
            _quizRepo = quizRepo;
        }

        public List<BackendLab01.Quiz> Quizzes { get; set; }

        public async Task OnGetAsync()
        {
            Quizzes = await _quizRepo.FindAllAsync();
        }
    }
}