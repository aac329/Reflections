using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace TestWebApplication.ViewModels
{
    public class TicketDateGroup
    {
        [DataType(DataType.Date)]
        public DateTime? DateCreated { get; set; }

        public int TicketCount { get; set; }
    }
}