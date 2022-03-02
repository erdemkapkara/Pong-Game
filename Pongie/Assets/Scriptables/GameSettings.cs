using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "Data", menuName = "Scriptables/GameSettings", order = 2)]

public class GameSettings : ScriptableObject
{
    [SerializeField] internal int MaxScore = 5;
    [SerializeField] internal float BallSpeed =20f;
    [SerializeField] internal float StickSpeed =20f;
}