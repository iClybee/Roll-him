using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class MovingWall : MonoBehaviour
{
    [SerializeField] private Transform posA, posB;
    [SerializeField] private float speed;

    Vector3 targetPos;

    private void Start()
    {
        targetPos = posB.position;
    }

    private void FixedUpdate()
    {
        if (Vector3.Distance(transform.position, posB.position) < 0.05f)
        {
            targetPos = posA.position;
            
        }

        else if (Vector3.Distance(transform.position, posA.position) < 0.05f)
        {
            targetPos = posB.position;
        }

        transform.position = Vector3.MoveTowards(transform.position, targetPos, speed * Time.fixedDeltaTime);
    }
}