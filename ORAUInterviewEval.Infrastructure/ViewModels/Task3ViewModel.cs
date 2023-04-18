using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORAUInterviewEval.Infrastructure.ViewModels
{
    public class Task3ViewModel
    {
        [Required]
        [MaxLength(100, ErrorMessage = "Comment must not contain over 100 characters")]
        public string Comment { get; set; }
    }
}
