using Newtonsoft.Json;
using Orange_Let_s_Meet_Client.Dtos;
using Orange_Let_s_Meet_Client_Lib.Model;
using System;
using System.IO;

namespace Orange_Let_s_Meet_Client_Lib
{
    class Program
    {
        static void Main(string[] args)
        {
            var plan = JsonConvert.DeserializeObject<MeetingPlan>(File.ReadAllText(@"SeedData.json"));

            var result = Timetable.FindTimeForMeeting(plan.Duration, plan.ParticipantTimetables.ToArray());

            Console.WriteLine($"Meeting with duration: {plan.Duration:hh\\:mm} can be planned at:");
            Console.WriteLine();
            Console.Write("[");

            foreach (var n in result)
                Console.Write(n);

            Console.Write("]\n");
        }
    }
}
 