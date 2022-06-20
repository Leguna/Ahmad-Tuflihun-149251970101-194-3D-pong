using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject gameOverUI;
    public TMPro.TMP_Text winnerText;
    public GameObject scoreUI;

    public void GoToMainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void ReplayGame()
    {
        SceneManager.LoadScene(1);
    }

    public void GameOver(int playerIndex)
    {
        gameOverUI.SetActive(true);
        scoreUI.SetActive(false);
        winnerText.text = "Player " + (playerIndex+1).ToString() + " Win";
    }

    public void ExitGame()
    {
        Application.Quit();
    }

}
