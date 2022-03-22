using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public GameSettings gameSettings;
    public BallController Ballcontroller;
    public UIManager UIManager;
    public LevelEditor leveleditor;
    [HideInInspector] public string empty = " ";
    [HideInInspector] public int score1 = 0, score2 = 0;
    [HideInInspector] public int LevelCount = 1;
    //[SerializeField] LevelEditor Level1, Level2, Level3, Level4, Level5, Level6, Level7, Level8, Level9, Level10;
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
            UIManager.FinishGame(1);
            LevelCount++;
            Ballcontroller.NextLevel(LevelCount);
            ResetScore();
            
        }
        else
        {
            UIManager.FinishGame(2);
            LevelCount = 1;
            ResetScore();
        }
    }
 
    public void ResetScore()
    {
        score1 = 0;
        score2 = 0;
        UIManager.ResetScore();
        Ballcontroller.ResetScore();  
    }
    public void UpdateScore(int player)
    {
        if (player == 1)
        {
            score2++;
            UIManager.txt1.text = score2.ToString();
        }
        else if (player == 2)
        {
            score1++;
            UIManager.txt2.text = score1.ToString();
        }
    }

    void Start()
    {
    }

    void Update()
    {
        if (score1 >= MaxScore || score2 >= MaxScore)
        {
            FinishGame(); 
        }
    }
}
