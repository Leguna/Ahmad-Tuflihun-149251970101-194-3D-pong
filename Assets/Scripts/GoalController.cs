using UnityEngine;

public class GoalController : MonoBehaviour
{
    public PlayerType goalOwner;
    [SerializeField] private float targetScaleY = 15;
    [SerializeField] private float speedScale = 5;

    private bool isWall;
    private Vector3 defaultScale;
    private Vector3 targetScale;
    private Vector3 velocity;

    private void Start()
    {
        defaultScale = transform.localScale;
        targetScale = new Vector3(defaultScale.x, targetScaleY, defaultScale.z);
    }

    private void Update()
    {
        if (isWall && transform.localScale.y < 14)
        {
            ChangeWallScale();
        }
    }

    public void ChangeWallScale()
    {
        transform.localScale = Vector3.SmoothDamp(transform.localScale, targetScale, ref velocity, Time.deltaTime*speedScale);
    }

    public void BecomeWall()
    {
        GetComponent<Collider>().isTrigger = false;
        isWall = true;
    }

}
