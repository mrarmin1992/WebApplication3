using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebApplication3.Models
{
    public class Kupac
    {
        [Key]
        public int Id { get; set; }
        public int Position { get; set; }
        public string Name { get; set; }
        public int Score { get; set; }
    }
}