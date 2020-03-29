using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyTaskRecorder.Domain.Models.Setting {
    public class TimeInterval {

        public TimeInterval(IntervalMinute workInterval, IntervalMinute breakInterval) {
            if (workInterval == null) throw new ArgumentNullException(nameof(workInterval));
            if (breakInterval == null) throw new ArgumentNullException(nameof(breakInterval));

            WorkInterval = workInterval;
            BreakInterval = breakInterval;
        }

        public IntervalMinute WorkInterval { get; private set; }

        public IntervalMinute BreakInterval { get; private set; }

        public override string ToString() {
            var sb = new StringBuilder();
            sb.Append("WorkInterval:" + WorkInterval + ", ");
            sb.Append("BreakInterval:" + BreakInterval + ", ");

            return sb.ToString();
        }
    }
}
