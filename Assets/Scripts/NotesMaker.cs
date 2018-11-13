using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NotesMaker : MonoBehaviour
{

    private AudioSource _audioSource;
    private float _startTime = 0;
    private CSVWriter _CSVWriter;

    private bool _isPlaying = false;
    public GameObject startButton;

    void Start()
    {
        _audioSource = GameObject.Find("GameMusic").GetComponent<AudioSource>();
        _CSVWriter = GameObject.Find("CSVWriter").GetComponent<CSVWriter>();
    }

    void Update()
    {
        if (_isPlaying)
        {
            DetectKeys();
        }
    }

    public void StartMusic()
    {
        Debug.Log("StartMusic()");
        startButton.SetActive(false);
        _audioSource.Play();
        _isPlaying = true;
    }

    void DetectKeys()
    {
        if (Input.GetKeyDown(KeyCode.D))
        {
            Debug.Log("D");
            WriteNotesTiming(0);
        }

        if (Input.GetKeyDown(KeyCode.F))
        {
            Debug.Log("F");
            WriteNotesTiming(1);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Space");
            WriteNotesTiming(2);
        }

        if (Input.GetKeyDown(KeyCode.J))
        {
            Debug.Log("J");
            WriteNotesTiming(3);
        }

        if (Input.GetKeyDown(KeyCode.K))
        {
            Debug.Log("K");
            WriteNotesTiming(4);
        }
    }

    void WriteNotesTiming(int num)
    {
        Debug.Log(GetTiming());
        _CSVWriter.WriteCSV(GetTiming().ToString() + "," + num.ToString());
    }

    float GetTiming()
    {
        return Time.time - _startTime;
    }
}
