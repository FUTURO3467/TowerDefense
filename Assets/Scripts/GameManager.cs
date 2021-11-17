
using UnityEngine;

public class GameManager : MonoBehaviour
{

    private bool gameEnded = false;

    void Update()
    {
        if (gameEnded)
        {
            return;
        }
        else if (PlayerStats.lives <= 0)
        {
            EndGame();
        }
    }

    void EndGame()
    {
        print("Perdu");
        gameEnded = true;
    }

}
