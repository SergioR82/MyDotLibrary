using System;
using System.Data.Entity;

namespace MyDotSample
{
	public class SampleContext:DbContext
	{
		public SampleContext(): base("name=SampleContext"){}

		public virtual DbSet<Customer> Customers { get; set; }
				
	}
}
