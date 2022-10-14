using BookMyShowEntity;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookMyShowData.Repository
{
    public interface IShowTimingRepository
    {
        void AddShowTiming(ShowTiming showTiming);

        void UpdateShowTiming(ShowTiming showTiming);

        void DeleteShowTiming(int showtimingId);

        ShowTiming GetShowTimingById(int showTimingId);
        IEnumerable<ShowTiming> GetShowTimings();
    }
}
