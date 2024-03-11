﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BackendLab01.Pages;

public class Summary : PageModel
{
    [BindProperty(SupportsGet = true)] public int CorrectAnswers { get; set; }

    [BindProperty(SupportsGet = true)] public int TotalQuestions { get; set; }

    public float Percentage { get; set; }

    public void OnGet()
    {

        Percentage = ((float)CorrectAnswers / TotalQuestions) * 100;
    }
}