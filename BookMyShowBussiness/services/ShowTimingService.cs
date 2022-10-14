using BookMyShowData.Repository;
using BookMyShowEntity;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookMyShowBussiness.services
{
    public class ShowTimingService
    {
        IShowTimingRepository _showTimingRepository;
        public ShowTimingService(IShowTimingRepository showTimingRepository)
        {
            _showTimingRepository = showTimingRepository;
        }
        public void AddShowTiming(ShowTiming showTiming)
        {
            _showTimingRepository.AddShowTiming(showTiming);
        }
        public void UpdateShowTiming(ShowTiming showTiming)
        {
            _showTimingRepository.UpdateShowTiming(showTiming);
        }
        public void DeleteShowTiming(int showtimingId)
        {
            _showTimingRepository.DeleteShowTiming(showtimingId);
        }
     
        public IEnumerable<ShowTiming> GetShowTimings()
        {
            return _showTimingRepository.GetShowTimings();
        }
        public ShowTiming GetShowTimingByid(int showTimingId)
        {
            return _showTimingRepository.GetShowTimingById(showTimingId);
        }
    }
}
