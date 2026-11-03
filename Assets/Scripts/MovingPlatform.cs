using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    [SerializeField] private Vector3 moveDirection = Vector3.right;
    [SerializeField] private float distance = 5.0f;
    [SerializeField] private float speed = 2.0f;

    private Vector3 startPosition;
    private Vector3 endPosition;
    private Vector3 targetPosition;

    private void Awake()
    {
        startPosition = transform.position;
        endPosition = startPosition + moveDirection.normalized * distance;
        targetPosition = startPosition;
    }

    private void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
    }

    public void MoveToEnd()
    {
        targetPosition = endPosition;
    }

    public void MoveToStart()
    {
        targetPosition = startPosition;
    }
}