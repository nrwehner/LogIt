using LogIt.Data;
using LogIt.Models.Home;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogIt.Services
{
    public class HomeService
    {
        private ApplicationDbContext _db = new ApplicationDbContext();
        private readonly string _userId;
        private readonly DateTime _today;

        public HomeIndex GetModel()
        {
            return 
                new HomeIndex 
                { 
                   Object = new HomeObject
                   {
                       UserId=_userId,
                       Today=_today
                   }
                };
        }

        public HomeService(string userId,DateTime today)
        {
            _userId = userId;
            _today = today;
        }
    }
}
