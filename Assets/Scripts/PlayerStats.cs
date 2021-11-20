using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public static int money;
    public int startMoney = 400;

    public static int lives;
    public int startLives = 20;

    public static int selectedMoney;
    public int selectedStartMoney = 400;

    private void Start()
    {
        selectedMoney = selectedStartMoney;
        money = startMoney;
        lives = startLives;
    }
}
