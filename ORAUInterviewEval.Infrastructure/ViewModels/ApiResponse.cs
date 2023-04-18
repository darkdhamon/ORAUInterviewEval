using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORAUInterviewEval.Infrastructure.ViewModels
{
	public class ApiResponse<TObject>
	{
		public Dictionary<string, string> Errors { get; set; } = new();
		public bool HasErrors => Errors.Keys.Any();
		public bool Succeeded { get; set; }
		public TObject Result { get; set; } = default!;
	}
}
