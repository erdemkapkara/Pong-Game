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
    [HideInInspector] public string empty = " ";
    [HideInInspector] public int score1 = 0, score2 = 0;
    [HideInInspector] public int LevelCount = 1;
    LevelEditor leveleditor;
    LevelEditor level1;
    LevelEditor level2;
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
            NextLevel(LevelCount);
            LevelCount++;
            ResetScore();
            
        }
        else
        {
            UIManager.FinishGame(2);
            LevelCount = 1;
            ResetScore();
        }
    }
    public void NextLevel(int levelcount)
    {
        switch (levelcount)
        {
            case 1:
                break;
            case 2:
                break;
            case 3:
                break;
            case 4:
                break;
            case 5:
                break;
            case 6:
                break;
            case 7:
                break;
            case 8:
                break;
            case 9:
                break;
            case 10:
                break;

            default:
                break;
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
    public void PlayGame()
    {

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
