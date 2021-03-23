using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using MiniTaxiBookingApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MiniTaxiBookingApplication.Controllers
{

    [ApiController]
    public class UserController : ControllerBase
    {
        MiniTaxingBookingAppContext _databaseContext;
        public UserController(MiniTaxingBookingAppContext databaseContext)
        {
            _databaseContext = databaseContext;
        }


        [HttpPost]
        [Route("User/InsertUser")]
        public bool InsertUser(User user)
        {
            try
            {

                var output = (from userDb in _databaseContext.Users
                              where userDb.UserName == user.UserName
                              select user.UserName).Count();

                if (output > 0)
                {
                    return false;
                }
                else
                {
                    var userTypeID = (from userType in _databaseContext.UserTypes
                                      where userType.Id == user.UserType
                                      select user.Id).SingleOrDefault();
                    user.Id = 0;
                    user.Password = user.Password;
                    user.UserName = user.UserName;
                    user.CreatedDate = DateTime.Now;
                    user.Address = user.Address;
                    user.ContactNo = user.ContactNo;
                    user.Email = user.Email;
                    user.UserType = user.UserType;
                    _databaseContext.Add(user);
                    _databaseContext.SaveChanges();

                    return true;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPost]
        [Route("User/login")]
        public User login(User user)
        {
            try
            {
                var userDetails = (from userDb in _databaseContext.Users
                                   where userDb.UserName == user.UserName && userDb.Password == user.Password
                                   select userDb).SingleOrDefault();

                 return userDetails;
            }
            catch (Exception)
            {
                throw;
            }
     
        }
    }
}
