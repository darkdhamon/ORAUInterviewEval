using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ORAUInterviewEval.Core.Interfaces;
using ORAUInterviewEval.Infrastructure.ViewModels;

namespace ORAUInterviewEval.Web.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class BusinessApiController : ControllerBase
	{
		public ITaskService TaskService { get; }
		public BusinessApiController(ITaskService taskService)
		{
			TaskService = taskService;
		}

		[HttpPost]
		public ApiResponse<string> Task3([FromBody] Task3ViewModel model)
		{
			var response = new ApiResponse<string>();
			if (!ModelState.IsValid)
			{
				
				foreach (var modelStateKey in ModelState.Keys)
				{
					response.Errors.Add(modelStateKey, ModelState[modelStateKey].AttemptedValue);
					response.Result = "Request has validation errors.";
				}
				return response;
			}

			try
			{
				TaskService.SaveComment(model.Comment);
				response.Succeeded = true;
				response.Result = "Comment Saved.";
			}
			catch (Exception ex)
			{
				response.Errors.Add("Exception", ex.Message);
				response.Result = ex.Message;
			}
			return response;
		}
	}
}
