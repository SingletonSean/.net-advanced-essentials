using System;
using System.Collections.Generic;
using System.Text;

namespace LazyDemo.Models
{
    public class Account
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public double Balance { get; set; }
    }
}
