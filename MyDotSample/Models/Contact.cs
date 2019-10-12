using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyDotSample
{
    [Table("Contacts")]
    public class Contact
    {
        [Key]
        public int Id { get; set; }
        public string FullName { get; set; }
        public virtual IList<Customer> Customers { get; set; }
    }
}