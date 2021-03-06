﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyTaskRecorder.Domain.Models.Task
{
    public enum Em_TaskStatus
    {
        Waiting = 1,
        Working = 2,
        Completed = 3
    }

    public class TaskStatusEnumUtil
    {
        public static Em_TaskStatus ConvEnum(string statusString)
        {
            if (statusString == Em_TaskStatus.Waiting.ToString())
            {
                return Em_TaskStatus.Waiting;
            }
            else if (statusString == Em_TaskStatus.Working.ToString())
            {
                return Em_TaskStatus.Working;
            }
            else
            {
                return Em_TaskStatus.Completed;
            }
        }

        public static List<string> GetEnumValueList() {
            string[] statusList = Enum.GetNames(typeof(Em_TaskStatus));
            return statusList.ToList();
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <remarks>value object</remarks>
    public class TaskStatus : IEquatable<TaskStatus>
    {
        public Em_TaskStatus Value { get; }

        public TaskStatus (Em_TaskStatus value)
        {
            Value = value;
        }

        public bool Equals(TaskStatus other)
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
            return Equals((TaskId)obj);
        }

        public override int GetHashCode()
        {
            return Value.GetHashCode();
        }

        public override string ToString()
        {
            return Value.ToString();
        }
    }
}
