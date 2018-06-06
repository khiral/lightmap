# lightmap
Takes a BeatSaber .json song file and creates lighting events.

Compiles anywhere you have Go 1.10, and will function on Windows, Linux, or Mac.

Windows allows you to drop the .json beatmap onto the .exe file.  Linux/Mac you'll need to run on the command line with `./lightmap beatmap.json`

Renames the original `beatmap.json` file to `beatmap_OLD.json` and outputs the new file as `beatmap.json` in the same location as the binary.

It's not clever, I suppose maybe it'll get more complex as time goes on and more people start to use it.  I might even make a UI for it (HAH !)
