using UnityEngine.UI;
using UnityEngine;

public class MoneyUI : MonoBehaviour
{

    public bool isRed;

    public static MoneyUI instance;

    private void Start()
    {
        instance = this;
    }

    public Text moneyText;
    void Update()
    {
        if (isRed)
        {
            moneyText.color = Color.red;
            moneyText.text = "$" + PlayerStats.money.ToString();
        }
        else
        {
            moneyText.color = Color.white;
            moneyText.text = "$" + PlayerStats.money.ToString();
        }
    }



}
