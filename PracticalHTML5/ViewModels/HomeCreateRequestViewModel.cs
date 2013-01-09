using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace PracticalHTML5.ViewModels
{
    public class HomeCreateRequestViewModel
    {
        public HomeCreateRequestViewModel()
        {
            Sizes = new SelectList(new[] { 3, 5 });
        }

        [Required]
        public string PlayerO { get; set; }
        public DateTime StartedAt { get; set; }
        public SelectList Sizes { get; set; }
        public int Size { get; set; }
    }
}