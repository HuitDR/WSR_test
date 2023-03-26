using System.Globalization;

namespace SF2022User00Lib
{
        public class TimeManager
        {
            public static TimeSpan ParseTime(string time)
            {
                return TimeSpan.ParseExact(time, "hh\\:mm", CultureInfo.InvariantCulture);
            }

            public static string FormatTime(TimeSpan time)
            {
                return time.ToString("hh\\:mm");
            }

            public static TimeSpan CalculateDuration(TimeSpan startTime, TimeSpan endTime)
            {
                return endTime - startTime;
            }

            public static bool IsIntersect(TimeSpan start1, TimeSpan end1, TimeSpan start2, TimeSpan end2)
            {
                return start1 < end2 && start2 < end1;
            }
        }

        public class BusySchedule
        {
            private List<TimeSpan> startTimes = new List<TimeSpan>();
            private List<TimeSpan> endTimes = new List<TimeSpan>();

            public void AddBusyTime(TimeSpan startTime, TimeSpan duration)
            {
                startTimes.Add(startTime);
                endTimes.Add(startTime + duration);
            }

            public bool IsFreeTime(TimeSpan startTime, TimeSpan duration)
            {
                for (int i = 0; i < startTimes.Count; i++)
                {
                    if (TimeManager.IsIntersect(startTime, startTime + duration, startTimes[i], endTimes[i]))
                    {
                        return false;
                    }
                }

                return true;
            }
        }

        public class Calculations
        {
            public static List<string> FindFreeTimes(TimeSpan beginWorkingTime, TimeSpan endWorkingTime, TimeSpan consultationTime, BusySchedule busySchedule)
            {
                List<string> freeTimes = new List<string>();

                TimeSpan startTime = beginWorkingTime;
                while (startTime + consultationTime <= endWorkingTime)
                {
                    if (busySchedule.IsFreeTime(startTime, consultationTime))
                    {
                        freeTimes.Add(TimeManager.FormatTime(startTime) + "-" + TimeManager.FormatTime(startTime + consultationTime));
                    }

                    startTime += TimeSpan.FromMinutes(15); // проверяем каждые 15 минут
                }

                return freeTimes;
            }
        }
    
}