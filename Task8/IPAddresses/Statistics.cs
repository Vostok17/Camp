using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IPAddresses
{
    internal class Statistics
    {
        public List<(string ip, TimeOnly time, DayOfWeek day)> Data { get; set; }

        public Statistics() { }
        public Statistics(List<(string ip, TimeOnly time, DayOfWeek day)> data)
        {
            Data = data;
        }

        public List<(string ip, int count)> GetCountOfVisits()
        {
            return Data
                .GroupBy(x => x.ip)
                .Select(x => (x.Key, x.Count()))
                .ToList();
        }
        public List<(string ip, DayOfWeek day)> GetTheMostPopularDays()
        {
            var ipDayCount = Data
                .GroupBy(x => (x.ip, x.day))
                .Select(g => (g.Key.ip, g.Key.day, Count: g.Count()));

            return ipDayCount
                .GroupBy(x => x.ip, (key, g) => g.OrderByDescending(e => e.Count).First())
                .Select(x => (x.ip, x.day))
                .ToList();
        }
        public List<(string ip, TimeOnly time)> GetTheMostActiveHours()
        {
            var userIPs = Data.Select(x => x.ip).Distinct();

            var res = new List<(string ip, TimeOnly time)>();
            foreach (var userIP in userIPs)
            {
                TimeOnly time;
                int maxCount = 0;
                foreach (var item in Data.Where(x => x.ip == userIP))
                {
                    int count = Data
                        .Where(x => x.time.IsBetween(item.time, item.time.AddHours(1)) && x.ip == userIP)
                        .Select(x => x).Count();

                    if (count > maxCount)
                    {
                        maxCount = count;
                        time = item.time;
                    }
                }
                res.Add((userIP, time));
            }
            return res;
        }
        public List<(DayOfWeek day, TimeOnly time)> GetTheMostActiveHoursForSite()
        {
            var days = Data.Select(x => x.day).Distinct();

            var res = new List<(DayOfWeek day, TimeOnly time)>();
            foreach (var day in days)
            {
                TimeOnly time;
                int maxCount = 0;
                foreach (var item in Data.Where(x => x.day == day))
                {
                    int count = Data
                        .Where(x => x.time.IsBetween(item.time, item.time.AddHours(1)) && x.day == day)
                        .Select(x => x).Count();

                    if (count > maxCount)
                    {
                        maxCount = count;
                        time = item.time;
                    }
                }
                res.Add((day, time));
            }
            return res;
        }
    }
}
