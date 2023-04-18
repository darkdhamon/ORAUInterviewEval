using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ORAUInterviewEval.Core.Interfaces;
using ORAUInterviewEval.Core.Models;
using ORAUInterviewEval.Infrastructure.ViewModels;
using ORAUInterviewEval.Web.Extensions;

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
		[Route("Task3")]
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

		[HttpPost]
		[Route("Task6")]
		
		public DtResponse<UserViewModel> Task6([FromForm] DtRequest request)
		{
			var response = new DtResponse<UserViewModel>();
			/**
			 * Assume that TaskService.GetUsers is returning a IQueryable powered by EntityFramework
			 */
			var userQuery = TaskService.GetUsers().Select(u=> new UserViewModel(){Name = $"{u.FirstName} {u.LastName}", Email = u.Email}).AsQueryable();
			response.RecordsTotal = userQuery.Count();
			// implement where clause for search
			if(!request.Search.Value.IsNullOrWhiteSpace())
				userQuery = userQuery.Where(user => (user.Name).Contains(request.Search.Value)||user.Email.Contains(request.Search.Value));

			response.RecordsFiltered = userQuery.Count();
			// Implement Ordering
			// Assumption only care about one degree of ordering
			var primaryOrdering = request.Order.FirstOrDefault();
			if (primaryOrdering != null)
			{
				switch (primaryOrdering.Column)
				{
					case 0: // Order by name
						switch (primaryOrdering.Dir)
						{
							case "asc":
								userQuery = userQuery.OrderBy(u => u.Name);
								break;
							case "desc":
								userQuery = userQuery.OrderByDescending(u => u.Name);
								break;
							default:
								// Do Nothing
								break;
						}
						break;
					case 1: // Order by email
						switch (primaryOrdering.Dir)
						{
							case "asc":
								userQuery = userQuery.OrderBy(u => u.Email);
								break;
							case "desc":
								userQuery = userQuery.OrderByDescending(u => u.Email);
								break;
							default:
								// Do Nothing
								break;
						}
						break;
					default:
							//do nothing
						break;
				}
			}

			// implement paging
			var resultUsers = userQuery.Skip(request.Start).Take(request.Length);
			response.Draw = request.Draw;
			response.Data = resultUsers.ToList();
			return response;
		}
	}

	public class UserViewModel
	{
		public string Name { get; set; }
		public string Email { get; set; }
	}
}
