using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI txt1;
    public TextMeshProUGUI txt2;
    public TextMeshProUGUI txt3;
    private int score1 = 0, score2 = 0;

    public GameSettings gameSettings;

    private string win = "You Won The Game!!!";
    private string lost = "You Lost The Game!!!";
    private string empty = " ";

    public Button ButtonClick;
    public Button ButtonPlay;
    public Button ButtonPlayAgain;
    public Button Exit;
    public BallController Ballcontroller;
    public GameObject Ball;
    public GameObject Players;
    public int CountDownTime;
    public TextMeshProUGUI CountDownText;
    public TextMeshProUGUI NextLevelText;
    private int LevelCount=1;
    private int MaxScore { get { return gameSettings.MaxScore; } }

    private static GameManager _instance;
    public static GameManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = GameObject.FindObjectOfType<GameManager>();
            }

            return _instance;
        }
    }
    void Awake()
    {
        if (_instance)
        {
            Destroy(this);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }        
    }

    public void FinishGame()
    {
        if (score1 > score2)
        {

            txt3.text = win;
            LevelCount++;
            ResetScore();
            NextLevel();
        }
        else
        {
            txt3.text = lost;


            Button PlayAgainButton = ButtonPlayAgain.GetComponent<Button>();
            PlayAgainButton.onClick.AddListener(PlayAgain);

            Button ButtonExit = Exit.GetComponent<Button>();
            ButtonExit.onClick.AddListener(GameExit);
            LevelCount = 1;
            ResetScore();
        }
     
    }
    IEnumerator CountDownToStart()
    {
        while (CountDownTime >= 0)
        {
            CountDownText.text = CountDownTime.ToString();
            yield return new WaitForSeconds(1f);
            CountDownTime--;
        }
        CountDownText.gameObject.SetActive(false);
        yield return new WaitForSeconds(2f);
        Ball.SetActive(true);
        Players.SetActive(true);
    }
    IEnumerator NextLevelLoading()
    {
        CountDownTime = 5;
        while (CountDownTime >= 0)
        {
            NextLevelText.text ="Loading"+" "+"Level"+" "+LevelCount+" "+CountDownTime.ToString()+" "+"...";
            yield return new WaitForSeconds(1f);
            CountDownTime--;
        }
        yield return new WaitForSeconds(2f);
        CountDownText.gameObject.SetActive(false);
    }
    public void GameExit()
    {
        Application.Quit();
    }
    public void PlayAgain()
    {
        //Ballcontroller.FinishGame();
    }
    public void NextLevel()
    {
        StartCoroutine(NextLevelLoading());
    }
    public void ResetScore()
    {
        score1 = 0;
        score2 = 0;
        txt1.text = score1.ToString();
        txt2.text = score2.ToString();
        txt3.text = empty;
        //Ball.SetActive(true);
        Ballcontroller.ResetScore();  
    }
    public void UpdateScore(int player)
    {
        if (player == 1)
        {
            score2++;
            txt2.text = score2.ToString();
        }
        else if (player == 2)
        {
            score1++;
            txt1.text = score1.ToString();
        }
    }
    public void PlayGame()
    {
        Ball.SetActive(false);
        Players.SetActive(false);
        StartCoroutine(CountDownToStart());
    }
    void Start()
    {
        Button btn = ButtonClick.GetComponent<Button>();
        btn.onClick.AddListener(ResetScore);
        
        Button PlayButton = ButtonPlay.GetComponent<Button>();
        PlayButton.onClick.AddListener(PlayGame);
    }

    void Update()
    {
        if (score1 >= MaxScore || score2 >= MaxScore)
        {
            FinishGame(); 
        }
    }
}
