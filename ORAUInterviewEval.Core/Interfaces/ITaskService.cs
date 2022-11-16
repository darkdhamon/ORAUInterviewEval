using ORAUInterviewEval.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORAUInterviewEval.Core.Interfaces
{
    public interface ITaskService
    {
        void SaveEmail(string email);

        void SaveComment(string comment);

        void SaveProfile(ProfileModel profile);
		List<ApplicationUser> GetUsers();
	}

    public class ProfileModel
    {
        public string FullName { get; set; }

        public List<ContactModel> Contacts { get; set; }

    }

    public class ContactModel
    {
        public string Address { get; set; }

        public string City { get; set; }

    }

}
