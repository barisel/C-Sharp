using System;

namespace ValueTypes
{
    enum ErrorCode : ushort {
        None = 0,
        Unknown = 1,
        ConnectionLost = 100,
        OutlierReading = 200
    }
    [Flags]
    enum Season
    {
        Spring,
        Summer,
        Autumn,
        Winter
    }

    [Flags]
    public enum Days
    {
        None = 0b_0000_0000,  // 0
        Monday = 0b_0000_0001,  // 1
        Tuesday = 0b_0000_0010,  // 2
        Wednesday = 0b_0000_0100,  // 4
        Thursday = 0b_0000_1000,  // 8
        Friday = 0b_0001_0000,  // 16
        Saturday = 0b_0010_0000,  // 32
        Sunday = 0b_0100_0000,  // 64
        Weekend = Saturday | Sunday
    }

    //public static void Test()
    //{
    //    Days meetingDays = Days.Monday | Days.Wednesday | Days.Friday;
    //    Console.WriteLine(meetingDays);
    //}
    //Output   : Monday, Wednesday, Friday
}
