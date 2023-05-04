using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace EduHome.Models
{
	public class CourseDetail
	{
		public int Id { get; set; }
		public string AboutCourse { get; set; }
		public string Apply { get; set; }
		public string Certification { get; set; }
		public DateTime Starts { get; set; }
		public double Duration { get; set; }
		public double ClassDuration { get; set; }
		public string SkillLevel { get; set; }
		public string Language { get; set; }
		public int Student { get; set; }
		public int CourseFee { get; set; }
		public Course Course { get; set; }
		[ForeignKey("Course")]
		public int CourseId { get; set; }

	}
}
