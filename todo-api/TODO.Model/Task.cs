using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TODO.Model
{
    /// <summary>
    /// Task Table used for Code-First Model
    /// </summary>
    [Table("Task")]
    public class Task
    {
        /// <summary>
        /// Primary Key Id
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        /// <summary>
        /// Task Name
        /// </summary>
        [StringLength(300)]
        [Required]
        public string Name { get; set; }

        /// <summary>
        /// Task Due Date
        /// </summary>
        [Required]
        public DateTime DueDate { get; set; }

        /// <summary>
        /// Task Priority
        /// </summary>
        [StringLength(10)]
        [Required]
        public string Priority { get; set; }
    }
}
