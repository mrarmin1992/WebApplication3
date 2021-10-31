using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication3.Models
{
    public class KupacPrikaziViewModel
    {
        public int Id { get; set; }
        public int Position { get; set; }
        public string Name { get; set; }
        public int Score { get; set; }
        public int KupacId { get; set; }
    }
}