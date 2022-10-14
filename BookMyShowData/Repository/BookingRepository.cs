﻿using BookMyShowEntity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static BookMyShowData.MovieDAL;

namespace BookMyShowData.Repository
{
    public class BookingRepository:IBookingRepository
    {
        MovieDbContext _movieDbContext;
        public BookingRepository(MovieDbContext movieDbContext)
        {
            _movieDbContext = movieDbContext;
        }
        public void AddBooking(Booking booking)
        {
            _movieDbContext.bookings.Add(booking);
            _movieDbContext.SaveChanges();
        }
        public void DeleteBooking(int bookingId)
        {
            var booking = _movieDbContext.bookings.Find(bookingId);
            _movieDbContext.bookings.Remove(booking);
            _movieDbContext.SaveChanges();
        }
       
        public IEnumerable<Booking> GetBookings()
        {
            return _movieDbContext.bookings.Include(obj => obj.user).Include(obj => obj.showTiming).ToList();
        }
        public void UpdateBooking(Booking booking)
        {
            _movieDbContext.Entry(booking).State = EntityState.Modified;
            _movieDbContext.SaveChanges();
        }
        public Booking GetBookingById(int bookingId)
        {
            return _movieDbContext.bookings.Find(bookingId);
        }
    }
}
