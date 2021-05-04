using System;

namespace Orange_Let_s_Meet_Client_Lib.Model
{
    public class TimeNode
    {
        public TimeSpan Start { get; set; }
        public TimeSpan End { get; set; }

        public TimeNode() { }

        public TimeNode(TimeSpan start, TimeSpan end)
            : this()
        {
            this.Start = start;
            this.End = end;
        }

        public TimeNode(int h1, int m1, int h2, int m2)
            : this(new TimeSpan(h1, m1, 0), new TimeSpan(h2, m2, 0)) { }

        public override string ToString() =>
            $"[\"{Start:hh\\:mm}\",\"{End:hh\\:mm}\"]";
    }
}
