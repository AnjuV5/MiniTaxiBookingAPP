using Microsoft.AspNetCore.Mvc;
using MiniTaxiBookingApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MiniTaxiBookingApplication.Controllers
{
    //[Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {

        MiniTaxingBookingAppContext _databaseContext;
        public BookingController(MiniTaxingBookingAppContext databaseContext)
        {
            _databaseContext = databaseContext;
        }



        // POST api/<BookingController>
        [HttpPost]
        [Route("Booking/InsertBooking")]
        public bool InsertBooking(BookingDatum bookingData)
        {
            try
            {

                var output = (from bookingDatadB in _databaseContext.BookingData
                              where bookingDatadB.BookingNo == bookingData.BookingNo
                              select bookingDatadB.Id).Count();

                if (output > 0)
                {
                    return false;
                }
                else
                {
                   
                    bookingData.Id = 0;
                    bookingData.BookingDate = bookingData.BookingDate;
                    bookingData.BookingNo = bookingData.BookingNo;
                    bookingData.BookingStatus = bookingData.BookingStatus;
                    bookingData.BookingType = bookingData.BookingType;
                    
                    _databaseContext.Add(bookingData);
                    _databaseContext.SaveChanges();

                    return true;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        // POST api/values
        [HttpPost]
        [Route("Booking/GetAllBookings/{userName}")]
        public BookingDatum[] GetAllBookings(string userName)
        {
            try
            {
                if (string.IsNullOrEmpty(userName))
                {
                    return null;
                }
                string bookingStatus = string.Empty;
                var getUserID = (from user in _databaseContext.Users
                                 where user.UserName == userName
                                 select user.Id).SingleOrDefault();

                var BookingDetails = (from book in _databaseContext.BookingData
                                      select new BookingDatum
                                      {
                                          BookingNo = book.BookingNo,
                                          BookingStatus = book.BookingStatus,
                                          BookingType = book.BookingType,
                                          BookingDate=book.BookingDate,
                                          EmiratesId=book.EmiratesId,
                                          CreatedBy=book.CreatedBy,
                                          CreatedDate=book.CreatedDate,
                                          Latitude=book.Latitude,
                                          Longitude=book.Longitude
                                      }).ToList();

                return BookingDetails.ToArray();
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPost]
        [Route("Booking/UpdateBookingStatus/")]
        public bool UpdateBookingStatus(BookingDatum booking)
        {
            try
            {
                string bookingStatus = string.Empty;

                BookingDatum bookingData = (from bookingDatadB in _databaseContext.BookingData
                                            where bookingDatadB.BookingNo == Convert.ToUInt32(booking.Id)
                                            select bookingDatadB).FirstOrDefault();

                if (bookingData == null) throw new Exception("");

                bookingData.BookingStatus = booking.BookingStatus;

                _databaseContext.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
