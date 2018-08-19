using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LightMap
{
    public class LightMapMagic
    {
        private Settings settings;

        public LightMapMagic(Settings settings)
        {
            this.settings = settings;
        }

        public BeatMap GenerateBeatMapEvents(string jsonFileName)
        {
            // Load the beatmap data from the JSON file
            BeatMap beatMap = LoadBeatMap(jsonFileName);
            if (beatMap == null)
                return null;

            // Perform magic to generate beatmap events
            List<BeatMapEvent> beatMapEvents = GenerateBeatMapEvents(beatMap);
            beatMap.Events = beatMapEvents.ToArray();

            // Do some filename wrangling
            long epoch = (long)(DateTime.UtcNow - new DateTime(1970, 1, 1)).TotalSeconds;
            string folderName = Path.GetDirectoryName(jsonFileName);
            string baseName = Path.GetFileNameWithoutExtension(jsonFileName);
            string extension = Path.GetExtension(jsonFileName);
            string backupFileName = Path.Combine(folderName, baseName + "_"  + epoch + extension);

            // Backup the old file and write the updated beatmap to the original filename
            File.Move(jsonFileName, backupFileName);
            string json = JsonConvert.SerializeObject(beatMap, Formatting.Indented);
            File.WriteAllText(jsonFileName, json);

            return beatMap;
        }

        public BeatMap LoadBeatMap(string jsonFileName)
        {
            using (StreamReader r = new StreamReader(jsonFileName))
            {
                string json = r.ReadToEnd();
                return JsonConvert.DeserializeObject<BeatMap>(json);
            }
        }

        public List<BeatMapEvent> GenerateBeatMapEvents(BeatMap beatMap)
        {
            List<BeatMapEvent> beatMapEvents = new List<BeatMapEvent>();
            
            if (settings.bigLights)
            {
                CreateBigLights(beatMap, beatMapEvents);
            }

            if (settings.noteConvert)
            {
                ConvertNotes(beatMap, beatMapEvents);
            }

            SetLaserSpeed(beatMapEvents);

            return beatMapEvents;
        }

        private void SetLaserSpeed(List<BeatMapEvent> beatMapEvents)
        {
            beatMapEvents.Add(new BeatMapEvent(0, 12, settings.laserSpeed));
            beatMapEvents.Add(new BeatMapEvent(0, 13, settings.laserSpeed));
        }

        private void CreateBigLights(BeatMap beatMap, List<BeatMapEvent> outputEvents)
        {
            double songLength = beatMap.Notes.Max(note => note.Time);
            double? marker = FindMarker(beatMap.Events);
            if (!marker.HasValue)
                return;

            bool flipFlop = true;
            for (double songIndex = marker.Value; songIndex <= songLength; songIndex += settings.spawnSpeed)
            {
                if (songLength - songIndex < settings.spawnSpeed)
                {
                    // End of song, fade out lights
                    if (flipFlop)
                        outputEvents.Add(new BeatMapEvent(songIndex, 1, 7));
                    else
                        outputEvents.Add(new BeatMapEvent(songIndex, 1, 3));
                }
                else
                {
                    if (flipFlop)
                    {
                        outputEvents.Add(new BeatMapEvent(songIndex, 1, 5));
                        if (settings.bigLightFade && songIndex >= 1)
                            outputEvents.Add(new BeatMapEvent(songIndex - 1, 1, 3));
                    }
                    else
                    {
                        outputEvents.Add(new BeatMapEvent(songIndex, 1, 1));
                        if (settings.bigLightFade && songIndex >= 1)
                            outputEvents.Add(new BeatMapEvent(songIndex - 1, 1, 7));
                    }
                }

                flipFlop = !flipFlop;
                if (settings.ringSpins)
                    outputEvents.Add(new BeatMapEvent(songIndex, 8, 0));
            }
        }

        private double? FindMarker(IEnumerable<BeatMapEvent> inputEvents)
        {
            if (inputEvents == null)
                return null;

            var eventTimes = new List<double>();
            foreach (var beatMapEvent in inputEvents)
            {
                if (beatMapEvent.Value == 0)
                    eventTimes.Add(beatMapEvent.Time);
            }

            var histogram = CountDuplicates(eventTimes);
            if (histogram.Count == 0)
                return null;

            var possibleMarkers = new List<double>();
            foreach (var timeOccurence in histogram)
            {
                if (timeOccurence.Value == 7)
                    possibleMarkers.Add(timeOccurence.Key);
            }

            if (possibleMarkers.Count == 0)
                return null;

            return possibleMarkers.Min();
        }

        private Dictionary<double, int> CountDuplicates(IEnumerable<double> list)
        {
            // Alternative implementation using LINQ:
            //list.GroupBy(x => x).ToDictionary(grp => grp.Key, grp => grp.Count());

            var result = new Dictionary<double, int>();

            foreach (var item in list)
            {
                if (!result.ContainsKey(item))
                    result[item] = 0;

                result[item] += 1;
            }

            return result;
        }

        private void ConvertNotes(BeatMap beatMap, List<BeatMapEvent> outputEvents)
        {
            foreach (var note in beatMap.Notes)
            {
                var tuple = CreateEvent(note.CutDirection, note.LineIndex);
                outputEvents.Add(new BeatMapEvent(note.Time, tuple.Item1, tuple.Item2));
            }
        }

        private Tuple<int, int> CreateEvent(int cutDirection, int lineIndex)
        {
            int eventValue = 0, eventType = 0;

            switch (cutDirection)
            {
                case 0: case 2: case 4: case 6:
                    eventValue = 7;
                    break;
                case 1: case 3: case 5: case 7: case 8:
                    eventValue = 3;
                    break;
            }

            switch (lineIndex)
            {
                case 0:
                    eventType = 2;
                    break;
                case 2:
                    eventType = 3;
                    break;
                case 3:
                    eventType = 4;
                    break;
            }

            return Tuple.Create(eventType, eventValue);
        }
    }
}
