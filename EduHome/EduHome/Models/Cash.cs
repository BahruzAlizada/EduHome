using System;

namespace EduHome.Models
{
	public class Cash
	{
		public int Id { get; set; }
		public int Balance { get; set; }
		public string Description { get; set; }
		public int LastModifiedMoney { get; set; }
		public string By { get; set; }
		public DateTime CreatedTime { get; set; }
	}
}
