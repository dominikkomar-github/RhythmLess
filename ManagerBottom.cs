using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class ManagerBottom : MonoBehaviour
{
    public AudioSource Music;
    public bool startPlaying;
    public MoveNoteBottom NoteMov;
    public static ManagerBottom instance;
    public int Score = 0;
    public int PointsForHit = 300;
    public int PointsForMiss = -200;
    public int NotesMissed = 0;

    public TextMeshProUGUI ScoreText;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        if(NotesMissed == 3)
        {
            Debug.Log("GameOver");
            Invoke("Restart", 0.5f);
        }

        if(!startPlaying)
        {
            if(Input.GetKeyDown(KeyCode.Space))
            {
                startPlaying = true;
                NoteMov.started = true;
                Music.Play();
            }
        }
    }

    public void Hit()
    {
        Debug.Log("GOOD HIT");
        Score += PointsForHit;
        ScoreText.text = "Score: " + Score;
    }

    public void Miss()
    {
        Debug.Log("MISS");
        Score += PointsForMiss;
        ScoreText.text = "Score: " + Score;
        NotesMissed++;
    }

    void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
