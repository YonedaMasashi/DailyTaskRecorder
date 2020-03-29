using DailyTaskRecorder.Domain.Models.Setting;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DailyTaskRecorder.Presentaion.Repository {
    class TimeIntervalRepository : ITimeIntervalRepository {
        private class InnerTimeInterval {
            int _workInterval = 25;
            [JsonProperty("WorkInterval")]
            public int WorkInterval {
                get { return _workInterval; }
                set { _workInterval = value; }
            }

            int _breakInterval = 5;
            [JsonProperty("BreakInterval")]
            public int BreakInterval {
                get { return _breakInterval; }
                set { _breakInterval = value; }
            }
        }

        private readonly string CONFIG_FILE_PATH;

        public TimeIntervalRepository() {
            string exePath = System.Reflection.Assembly.GetExecutingAssembly().Location;
            string dirPath = Path.GetDirectoryName(exePath);
            CONFIG_FILE_PATH = dirPath + @"\DailyTaskRecorderConfig.json";
        }

        public TimeInterval Load() {
            if (File.Exists(CONFIG_FILE_PATH) == false) throw new IOException("Configファイルがありません :" + CONFIG_FILE_PATH);
 
            using (System.IO.StreamReader sr = new System.IO.StreamReader(CONFIG_FILE_PATH)) {
                string json = sr.ReadToEnd();
                var deserialized = JsonConvert.DeserializeObject<InnerTimeInterval>(json);
                return new TimeInterval(
                    new IntervalMinute(deserialized.WorkInterval),
                    new IntervalMinute(deserialized.BreakInterval));
            }
        }

        public void Save(TimeInterval timeInterval) {
            var innerInterval = new InnerTimeInterval();
            innerInterval.WorkInterval = timeInterval.WorkInterval.Value;
            innerInterval.BreakInterval = timeInterval.BreakInterval.Value;

            var json = JsonConvert.SerializeObject(innerInterval);
            using (System.IO.StreamWriter sw =
                new System.IO.StreamWriter(CONFIG_FILE_PATH,
                    false,
                    System.Text.Encoding.UTF8)) {
                sw.WriteLine(json);
            }
        }
    }
}
