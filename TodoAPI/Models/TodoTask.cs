using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TodoAPI.Static;

namespace TodoAPI.Models
{
    [Table("tbl_Tasks")]
    public class TodoTask
    {
        [Key]
        public int Id { get; set; }
        public string Task { get; set; }
        public TaskStatus_Enum status { get; set; }
        public string createdDateTime { get; set; }
        public string updatedDateTime { get; set; }
    }
}
