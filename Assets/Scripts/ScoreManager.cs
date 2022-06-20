using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ScoreManager : MonoBehaviour
{

    public List<int> listScore;
    public List<TMPro.TMP_Text> listText;
    public List<PaddleController> listPaddle;
    public List<GoalController> listGoal;
    public SpawnManager spawnManager;
    public UnityEvent<int> onPlayerOneLeftCallback;

    private int playerCount = 4;

    public void UpdateTextScore()
    {
        for (int i = 0; i < listScore.Count; i++)
        {
            listText[i].text = listScore[i].ToString() + " Poin";
        }
    }

    public void AddScore(int indexPlayer)
    {
        listScore[indexPlayer]++;
        listText[indexPlayer].text = listScore[indexPlayer].ToString() + " Poin";
        CheckScore(indexPlayer);
    }

    public void CheckScore(int indexPlayer)
    {
        if (listScore[indexPlayer] >= 15)
        {
            listPaddle[indexPlayer].DisablePlayer();
            listGoal[indexPlayer].BecomeWall();
            playerCount--;
        }
        if (playerCount == 1)
        {
            for (int i = spawnManager.listBall.Count - 1; i >= 0; i--)
            {
                Destroy(spawnManager.listBall[i].gameObject);
            }
            for (int i = 0; i < listPaddle.Count; i++)
            {
                if (listPaddle[i].gameObject.activeSelf)
                {
                    onPlayerOneLeftCallback.Invoke(i);
                    break;
                }
            }
        }
    }

}
