using Melanchall.DryWetMidi.Interaction;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lane : MonoBehaviour
{
    public Melanchall.DryWetMidi.MusicTheory.NoteName noteRestriction;
    //public KeyCode input;
    public GameObject notePrefab;
    List<Note> notes = new List<Note>();
    public List<double> timeStamps = new List<double>();

    int spawnIndex = 0; //keeps track of note spawned
    //int inputIndex = 0; 
    
    // Start is called before the first frame update
    void Start()
    {

    }
    public void SetTimeStamps(Melanchall.DryWetMidi.Interaction.Note[] array)
    {
        foreach (var note in array) //go through all midi notes in Song Manager array
        {
            if (note.NoteName == noteRestriction) //only get notes from a certain key for a certain lane in array
            {
                var metricTimeSpan = TimeConverter.ConvertTo<MetricTimeSpan>(note.Time, SongManager.midiFile.GetTempoMap()); //get time of midi note
               timeStamps.Add((double)metricTimeSpan.Minutes * 60f + metricTimeSpan.Seconds + (double)metricTimeSpan.Milliseconds / 1000f); //add it to array in metric time
            }
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (spawnIndex < timeStamps.Count) //if there are notes, keep on running
        {
            //check if note in midi song is at note spawn time (keep in account extra time for player to press note (.noteTime)
            if (SongManager.GetAudioSourceTime() >= timeStamps[spawnIndex] - SongManager.Instance.noteTime) 
            {
                var note = Instantiate(notePrefab, transform);
                
                notes.Add(note.GetComponent<Note>());
             
                //note.GetComponent<Note>().assignedTime = (float)timeStamps[spawnIndex];
                spawnIndex++;
            }
        }

        //if (inputIndex < timeStamps.Count)
        //{
        //    double timeStamp = timeStamps[inputIndex];
        //    double marginOfError = SongManager.Instance.marginOfError;
        //    double audioTime = SongManager.GetAudioSourceTime() - (SongManager.Instance.inputDelayInMilliseconds / 1000.0);

        //    if (Input.GetKeyDown(input))
        //    {
        //        if (Math.Abs(audioTime - timeStamp) < marginOfError)
        //        {
        //            Hit();
        //            print($"Hit on {inputIndex} note");
        //            Destroy(notes[inputIndex].gameObject);
        //            inputIndex++;
        //        }
        //        else
        //        {
        //            print($"Hit inaccurate on {inputIndex} note with {Math.Abs(audioTime - timeStamp)} delay");
        //        }
        //    }
        //    if (timeStamp + marginOfError <= audioTime)
        //    {
        //        Miss();
        //        print($"Missed {inputIndex} note");
        //        inputIndex++;
        //    }
        //}

    }
    //private void Hit()
    //{
    //    ScoreManager.Hit();
    //}
    //private void Miss()
    //{
    //    ScoreManager.Miss();
    //}
}
