package main

import (
	"encoding/json"
	"fmt"
	"io/ioutil"
	"os"
	"path"
	"strings"
)

func createEvent(cD int, lI int) (int, int) {
	eV := 0
	eT := 0

	switch cD {
	case 0, 2, 4, 6:
		eV = 7
	case 1, 3, 5, 7, 8:
		eV = 3
	default:
		eV = 0
	}

	switch lI {
	case 0:
		eT = 2
	case 1:
		eT = 0
	case 2:
		eT = 3
	case 3:
		eT = 4
	default:
		eT = 0
	}

	return eV, eT
}

func main() {
	if len(os.Args) < 2 {
		fmt.Println("Missing parameter, provide file name!")
		return
	}
	data, err := ioutil.ReadFile(os.Args[1])
	if err != nil {
		fmt.Println("Can't read file:", os.Args[1])
		panic(err)
	}

	type beatmapEvent struct {
		Time  float64 `json:"_time"`
		Type  int     `json:"_type"`
		Value int     `json:"_value"`
	}

	type beatmap struct {
		Version        string         `json:"_version"`
		BeatsPerMinute int            `json:"_beatsPerMinute"`
		BeatsPerBar    int            `json:"_beatsPerBar"`
		NoteJumpSpeed  int            `json:"_noteJumpSpeed"`
		Shuffle        int            `json:"_shuffle"`
		ShufflePeriod  float64        `json:"_shufflePeriod"`
		Events         []beatmapEvent `json:"_events"`
		Notes          []struct {
			Time         float64 `json:"_time"`
			LineIndex    int     `json:"_lineIndex"`
			LineLayer    int     `json:"_lineLayer"`
			Type         int     `json:"_type"`
			CutDirection int     `json:"_cutDirection"`
		} `json:"_notes"`
		Obstacles []struct {
			Time      float64 `json:"_time"`
			LineIndex int     `json:"_lineIndex"`
			Type      int     `json:"_type"`
			Duration  float64 `json:"_duration"`
			Width     int     `json:"_width"`
		} `json:"_obstacles"`
	}

	var bm beatmap

	json.Unmarshal(data, &bm)
	bm.Events = nil

	for i := 0; i < len(bm.Notes); i++ {
		var eV int
		var eT int
		eV, eT = createEvent(bm.Notes[i].CutDirection, bm.Notes[i].LineIndex)

		bm.Events = append(bm.Events, beatmapEvent{bm.Notes[i].Time, eT, eV})

	}

	fixedJson, _ := json.Marshal(bm)
	backupName := (strings.TrimSuffix(os.Args[1], path.Ext(os.Args[1]))) + "_OLD.json"
	os.Rename(os.Args[1], backupName)
	err = ioutil.WriteFile(os.Args[1], fixedJson, 0644)
}
