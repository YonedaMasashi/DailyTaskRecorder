using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyTaskRecorder.Domain.Models.Task
{
    public class CategoryName : IEquatable<TaskName>
    {
        public string Value { get; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <remarks>value object</remarks>
        public CategoryName(string value)
        {
            if (value == null) throw new ArgumentNullException(nameof(value));
            if (value.Length <= 0) throw new ArgumentException("カテゴリ名を入力してください。", nameof(value));
            Value = value;
        }

        public bool Equals(TaskName other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return string.Equals(Value, other.Value);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((TaskName)obj);
        }

        public override int GetHashCode()
        {
            return (Value != null ? Value.GetHashCode() : 0);
        }

        public override string ToString()
        {
            return Value;
        }
    }
}
