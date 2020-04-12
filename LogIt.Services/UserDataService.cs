using LogIt.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogIt.Services
{
    public class UserDataService
    {
        private ApplicationDbContext _db = new ApplicationDbContext();
        private readonly string _userId;

        public UserDataService(string userId)
        {
            _userId = userId;
        }
    }
}
