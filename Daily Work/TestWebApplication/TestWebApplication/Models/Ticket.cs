using System;
using System.Collections.Generic;
using System.Data;
using System.Net;
using System.Web.Mvc;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TestWebApplication.Models
{

    public class Ticket
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "Please enter a Title.")]
        [Display(Name = "Title")]
        [StringLength(50, ErrorMessage = "Title cannot be longer than 50 characters.")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Please enter a Description.")]
        [Display(Name = "Description")]
        [StringLength(500, ErrorMessage = "Description cannot be longer than 500 characters.")]
        public string Description { get; set; }

        [Required (ErrorMessage = "Please enter a Date.")]
        [Display(Name = "Date Created")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM-dd-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DateCreated { get; set; }

        [Required(ErrorMessage = "Please select a Status.")]
        [Display(Name = "Status")]
        public string Status { get; set; }

        public IEnumerable<SelectListItem> Statuses { get; set; }
    }
}