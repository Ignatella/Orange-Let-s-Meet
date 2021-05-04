using Orange_Let_s_Meet_Client_Lib.Model;
using System;
using System.Collections.Generic;

namespace Orange_Let_s_Meet_Client.Dtos
{
    internal class MeetingPlan
    {
        public TimeSpan Duration { get; set; }

        public List<Timetable> ParticipantTimetables { get; set; }
    }
}
