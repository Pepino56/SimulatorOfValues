﻿using Microsoft.AspNetCore.Mvc.RazorPages;

namespace vosplzen.sem2._2023k.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {

        }
    }
}