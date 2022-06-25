using UnityEngine;
using UnityEngine.Events;

public class BallController : MonoBehaviour
{
    public SpawnManager spawnManager;
    public ScoreManager scoreManager;

    public AudioSource audioSource;

    public GameObject smokeParticle;
    public GameObject sparkleParticle;

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

        if (collision.gameObject.tag == TagConstant.wall)
        {
            spawnManager.RemoveBall(gameObject);
            Destroy(gameObject);
            GameObject particle = Instantiate(smokeParticle, collision.contacts[0].point, Quaternion.identity, gameObject.transform);
            Destroy(particle, 2);
        }
        // Sound
        if (collision.gameObject.tag == TagConstant.ball || collision.gameObject.tag == TagConstant.player || collision.gameObject.tag == TagConstant.pole)
        {
            audioSource.Play();
            GameObject particle = Instantiate(sparkleParticle,collision.contacts[0].point,Quaternion.identity,gameObject.transform);
            Destroy(particle, 2);
        }
    }
}
