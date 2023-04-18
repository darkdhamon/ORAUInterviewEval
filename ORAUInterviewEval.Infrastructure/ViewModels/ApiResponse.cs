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

	public class DtRequest
	{
		public int Draw { get; set; }
		public int Start { get; set; }
		public int Length { get; set; }
		public DtSearch? Search { get; set; }
		public List<DtOrderBy>? Order { get; set; }
	}

	public class DtSearch
	{
		public string? Value { get; set; }
	}

	public class DtResponse<TObject>
	{
		public int Draw { get; set; }
		public int RecordsTotal { get; set; }
		public int RecordsFiltered { get; set; }
		public List<TObject> Data { get; set; }
	}

	public class DtOrderBy
	{
		public int Column { get; set; }
		public string? Dir { get; set; }
	}
}
