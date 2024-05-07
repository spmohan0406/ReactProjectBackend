using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ReactProject.Models
{
    [Table("mohanstudenttable")]
    public class Student
    {
         [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("ms_id")]
        public long id { get; set; }
        [Column("ms_student_name")]
        public string stname { get; set; }
        [Column("ms_student_course")]
        public string course{get; set;}
    }
}