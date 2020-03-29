using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyTaskRecorder.Domain.Models.Setting {
    public interface ITimeIntervalRepository {
        TimeInterval Load();
        void Save(TimeInterval timeInterval);
    }
}
