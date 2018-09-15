using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BankAccounts
{
    public class Account
    {
        [Key]
        public int id { get; set; }

        public float Amount { get; set; }

        [ForeignKey("id")]
        public int User_id { get; set; }

        public DateTime Date { get; set; }
    }
}