using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace buy_easy_api.Views.Product
{
    public class SearchResultModel
    {
        [BindProperty(SupportsGet = true)]
        public string SearchString { get; set; }
        public List<Entities.Product> Products { get; set; }
    }
}