using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyDotSample
{
    [Table("Cliente")]
    public class Customer
	{
        [Key]
        public int id { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
	}
}
