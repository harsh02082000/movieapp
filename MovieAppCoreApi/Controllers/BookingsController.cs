﻿using BookMyShowBussiness.services;
using BookMyShowEntity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace MovieAppCoreApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingsController : ControllerBase
    {

        private BookingService _bookingService;
        public BookingsController(BookingService bookingService)
        {
            _bookingService = bookingService;
        }
        [HttpGet("GetBookings")]
        public IEnumerable<Booking> GetBookings()
        {
            return _bookingService.GetBookings();
        }
        [HttpGet("GetBookingById")]
        public Booking GetBookingById(int bookingId)
        {
            return _bookingService.GetBookingByid(bookingId);
        }


        [HttpPost("AddBooking")]
        public IActionResult AddBooking([FromBody] Booking booking)
        {
            _bookingService.AddBooking(booking);
            return Ok("Booking created successfully!!");
        }
        [HttpDelete("DeleteBooking")]
        public IActionResult DeleteBooking(int bookingId)
        {
            _bookingService.DeleteBooking(bookingId);
            return Ok("Booking deleted successfully!!");
        }
        [HttpPut("UpdateBooking")]
        public IActionResult UpdateBooking([FromBody] Booking booking)
        {
            _bookingService.UpdateBooking(booking);
            return Ok("Booking updated successfully!!");
        }
    }
}
