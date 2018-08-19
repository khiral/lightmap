using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace LightMap
{
    public class BeatMap
    {
        [JsonProperty("_version")]
        public string Version { get; set; }
        [JsonProperty("_beatsPerMinute")]
        public double BeatsPerMinute { get; set; }
        [JsonProperty("_beatsPerBar")]
        public int BeatsPerBar { get; set; }
        [JsonProperty("_noteJumpSpeed")]
        public int NoteJumpSpeed { get; set; }
        [JsonProperty("_shuffle")]
        public int Shuffle { get; set; }
        [JsonProperty("_shufflePeriod")]
        public double ShufflePeriod { get; set; }

        [JsonProperty("_events")]
        public BeatMapEvent[] Events { get; set; }
        [JsonProperty("_notes")]
        public BeatMapNote[] Notes { get; set; }
        [JsonProperty("_obstacles")]
        public BeatMapObstacle[] Obstacles { get; set; }
    }

    public class BeatMapEvent
    {
        public BeatMapEvent() { }

        public BeatMapEvent(double time, int type, int value)
        {
            Time = time;
            Type = type;
            Value = value;
        }

        [JsonProperty("_time")]
        public double Time { get; set; }
        [JsonProperty("_type")]
        public int Type { get; set; }
        [JsonProperty("_value")]
        public int Value { get; set; }
    }

    public class BeatMapNote
    {
        [JsonProperty("_time")]
        public double Time { get; set; }
        [JsonProperty("_lineIndex")]
        public int LineIndex { get; set; }
        [JsonProperty("_lineLayer")]
        public int LineLayer { get; set; }
        [JsonProperty("_type")]
        public int Type { get; set; }
        [JsonProperty("_cutDirection")]
        public int CutDirection { get; set; }
    }

    public class BeatMapObstacle
    {
        [JsonProperty("_time")]
        public double Time { get; set; }
        [JsonProperty("_lineIndex")]
        public int LineIndex { get; set; }
        [JsonProperty("_type")]
        public int Type { get; set; }
        [JsonProperty("_duration")]
        public double Duration { get; set; }
        [JsonProperty("_width")]
        public int Width { get; set; }
    }
}
