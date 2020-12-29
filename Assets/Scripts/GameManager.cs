using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject ballPrefab;
    public GameObject playerPrefab;
    public Text scoreText;
    public Text ballsText;
    public Text levelText;
    public Text highScoreText;

    public GameObject panelMenu;
    public GameObject panelPlay;
    public GameObject panelLevelCompleted;
    public GameObject panelLevelFailed;

    public GameObject[] levels;

    public static GameManager Instance { get; private set; }

    public enum State { MENU,INIT,PLAY,LEVELCOMPLETED,LOADLEVEL,GAMEOVER};

    State state;

    private int score;
    GameObject currentBall;
    GameObject currentLevel;
    bool isSwitchingState;

    public int Score
    {
        get { return score; }
        set { score = value; 
        scoreText.text="SCORE: "+score;
        }
    }

    private int level;

    public int Level
    {
        get { return level; }
        set { level = value;
            levelText.text = "LEVEL: " + level;
        }
    }

    private int balls;

    public int Balls
    {
        get { return balls; }
        set { balls = value;
            ballsText.text = "Balls: " + balls;
        }
    }





    void Start()
    {
        Instance = this;
        SwitchState(State.MENU);
    }

    public void playClicked()
    {
        SwitchState(State.INIT);
    }
    public void doExitGame()
    {
        Application.Quit();
    }





    public void SwitchState(State newState,float delay = 0)
    {
        StartCoroutine(SwitchDelay(newState, delay));
    }

    IEnumerator SwitchDelay(State newState,float delay)
    {
        isSwitchingState = true;
        yield return new WaitForSeconds(delay);
        EndState();
        state = newState;
        BeginState(newState);
        isSwitchingState = false;
    }


    void BeginState(State newState)
    {
        switch (newState)
        {
            case State.MENU:
                Cursor.visible = true;
                if (currentLevel != null)
                {
                    Destroy(currentLevel);
                }

                highScoreText.text = "HIGHSCORE: " + PlayerPrefs.GetInt("highscore");
                panelMenu.SetActive(true);
                break;
            case State.INIT:
                Cursor.visible = false;
                panelPlay.SetActive(true);
                Score = 0;
                Level = 0;
                Balls = 3;
                if(currentLevel!=null)
                {
                    Destroy(currentLevel);
                }

                Instantiate(playerPrefab);
                SwitchState(State.LOADLEVEL);
                break;
            case State.PLAY:
                break;
            case State.LEVELCOMPLETED:
                Destroy(currentLevel);
                Destroy(currentBall);
                panelLevelCompleted.SetActive(true);
                Level++;
                SwitchState(State.LOADLEVEL,2f);
                break;
            case State.LOADLEVEL:
                if(level>=levels.Length)
                {
                    SwitchState(State.GAMEOVER);
                }
                else
                {
                    currentLevel = Instantiate(levels[level]);
                    SwitchState(State.PLAY);
                }
                break;
            case State.GAMEOVER:
                if(Score>PlayerPrefs.GetInt("highscore"))
                {
                    PlayerPrefs.SetInt("highscore", Score);
                }
                panelLevelFailed.SetActive(true);
                break;
        }
    }

    void Update()
    {
        switch (state)
        {
            case State.MENU:
                break;
            case State.INIT:
                break;
            case State.PLAY:
                if(currentBall==null)
                {
                    if(Balls>0)
                    {
                        currentBall = Instantiate(ballPrefab);
                    }
                    else
                    {
                        SwitchState(State.GAMEOVER);
                    }
                }

                if(currentLevel!=null && currentLevel.transform.childCount==0&& isSwitchingState==false)
                {
                    SwitchState(State.LEVELCOMPLETED);


                }

                break;
            case State.LEVELCOMPLETED:
                break;
            case State.LOADLEVEL:
                break;
            case State.GAMEOVER:
                if(Input.anyKeyDown)
                {
                    SwitchState(State.MENU);
                }
                
                break;
        }

    }

    void EndState()
    {
        switch (state)
        {
            case State.MENU:
                panelMenu.SetActive(false);
                break;
            case State.INIT:
                break;
            case State.PLAY:
                break;
            case State.LEVELCOMPLETED:
                panelLevelCompleted.SetActive(false);
                break;
            case State.LOADLEVEL:
                break;
            case State.GAMEOVER:
                panelPlay.SetActive(false);
                panelLevelFailed.SetActive(false);
                break;
        }

    }





}
