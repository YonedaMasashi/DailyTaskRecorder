using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyTaskRecorder.Domain.Models.Setting {
    public class IntervalMinute : IEquatable<IntervalMinute> {

        public int Value { get; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <remarks>value object</remarks>
        public IntervalMinute(int value) {
            Value = value;
        }

        public bool Equals(IntervalMinute other) {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return string.Equals(Value, other.Value);
        }

        public override bool Equals(object obj) {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((IntervalMinute)obj);
        }

        public override int GetHashCode() {
            return Value;
        }

        public override string ToString() {
            return Value.ToString();
        }
    }
}
