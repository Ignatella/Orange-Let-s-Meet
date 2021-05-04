using Orange_Let_s_Meet_Lib.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;


namespace Orange_Let_s_Meet_Client_Lib.Model
{
    public class Timetable
    {
        public TimeNode WorkingHours { get; set; }

        public List<TimeNode> Meetings { get; set; }

        public static IEnumerable<TimeNode> FindTimeForMeeting(TimeSpan duration, params Timetable[] timetables)
        {
            List<TimeNode> result = new List<TimeNode>();

            TimeSpan maxStart = timetables.Max(u => u.WorkingHours.Start);
            TimeSpan minEnd = timetables.Min(u => u.WorkingHours.End);

            return
                timetables
                .SelectMany(u => u.Meetings) // flat all meetings array to create one
                .Prepend(new TimeNode(maxStart, maxStart)) // insert 'front' guard
                .Append(new TimeNode(minEnd, minEnd)) // insert 'back' guard
                .Where(t => t.Start >= maxStart && t.End <= minEnd) // get rid of timeNodes when somebody doesn't work
                .OrderBy(t => t.Start)
                .SelectFromTwo((TimeNode curr, TimeNode next, ref TimeNode state) =>
                {
                    if (state == null)
                        state = new TimeNode(curr.Start, curr.End); // execute only on first iteration

                    if (curr.End > state.End)   // =====//////====== state
                        state.End = curr.End;   // =======///////=== curr

                    if (next.Start > state.End) // ==//////======= state 
                                                // ==========////= next (there is free place between timeNodes)
                        if (duration <= next.Start - state.End)
                            return new TimeNode(state.End, next.Start);

                    return null;
                })
                .Where(t => t != null);
        }
    }
}
