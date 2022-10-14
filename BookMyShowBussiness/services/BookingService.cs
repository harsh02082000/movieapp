using BookMyShowData.Repository;
using BookMyShowEntity;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookMyShowBussiness.services
{
    public class BookingService
    {
        IBookingRepository _bookingRepository;
        public BookingService(IBookingRepository bookingRepository)
        {
            _bookingRepository = bookingRepository;
        }
        public void AddBooking(Booking booking)
        {
            _bookingRepository.AddBooking(booking);
        }
        public void UpdateBooking(Booking booking)
        {
            _bookingRepository.UpdateBooking(booking);
        }
        public void DeleteBooking(int bookingId)
        {
            _bookingRepository.DeleteBooking(bookingId);
        }
   
        public IEnumerable<Booking> GetBookings()
        {
            return _bookingRepository.GetBookings();
        }
        public Booking GetBookingByid(int bookingId)
        {
            return _bookingRepository.GetBookingById(bookingId);
        }
    }
}
