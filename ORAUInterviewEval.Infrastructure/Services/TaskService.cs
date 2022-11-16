using ORAUInterviewEval.Core.Interfaces;
using ORAUInterviewEval.Core.Models;
using ORAUInterviewEval.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORAUInterviewEval.Infrastructure.Services
{
    public class TaskService : ITaskService
    {
        private AppDbContext _db { get; set; }

        public TaskService(AppDbContext db)
        {
            _db = db;
        }





        public void SaveEmail(string email)
        {
            //NOTE: Magic business logic would go here...
            //No need to implement (outside of scope of requirements)
        }

        public void SaveComment(string comment)
        {
            //NOTE: Magic business logic would go here...
            //No need to implement (outside of scope of requirements)
        }

        public void SaveProfile(ProfileModel profile)
        {
            //NOTE: Magic business logic would go here...
            //No need to implement (outside of scope of requirements)
        }


        public List<ApplicationUser> GetUsers()
        {
            var result = _db.Users;
            return result.ToList();
        }

    }
}
