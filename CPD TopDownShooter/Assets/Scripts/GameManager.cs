using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Checks if the game has ended and restarts the game after a delay.
/// </summary>
public class GameManager : MonoBehaviour
{
    bool gameHasEnded = false;

    public float restartDelay = 1f;


    public void EndGame()
    {
        if (gameHasEnded == false)
        {

            gameHasEnded = true;

            Debug.Log("Game Over");
            Invoke("Restart", restartDelay);
        }
    }

    void Restart()
    {
            SceneManager.LoadScene("GameOver");
    }
}
