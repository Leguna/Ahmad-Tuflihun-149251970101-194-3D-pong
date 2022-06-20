using UnityEngine;
using UnityEngine.Events;

public class BallController : MonoBehaviour
{
    public SpawnManager spawnManager;
    public ScoreManager scoreManager;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Goal")
        {
            int paddleNumber = (int)other.gameObject.GetComponent<GoalController>().goalOwner-1;
            scoreManager.AddScore(paddleNumber);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Dinding")
        {
            spawnManager.RemoveBall(gameObject);
            Destroy(gameObject);
        }
    }
}
