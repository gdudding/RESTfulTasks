using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
/// <summary>
/// This establishes the model for a Task for use with our service.  It is just comprised of a TaskId and a TaskDescription for simplicity.
/// </summary>
namespace RESTfulTasks.Models
{
    public class Task
    {
        public int TaskId { get; set; }
        [Required]
        public string TaskDescription { get; set; }
    }
}