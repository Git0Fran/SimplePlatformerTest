using UnityEngine;

public class BigPressurePlate : MonoBehaviour
{
    [SerializeField] private MovingPlatform platform = null;
    [SerializeField] private Transform plateSprite = null;
    [SerializeField] private float sinkDistance = 0.1f;
    [SerializeField] private float sinkSpeed = 2.0f;

    private Vector3 upPosition;
    private Vector3 downPosition;
    private Vector3 targetPosition;

    private void Awake()
    {
        upPosition = plateSprite.localPosition;
        downPosition = upPosition + Vector3.down * sinkDistance;
        targetPosition = upPosition;
    }

    private void Update()
    {
        plateSprite.localPosition = Vector3.MoveTowards(plateSprite.localPosition, targetPosition, sinkSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.isTrigger) return;

        PlayerController_Script player = collision.GetComponentInParent<PlayerController_Script>();
        if (player != null && player.IsBig)
        {
            platform.MoveToEnd();
            targetPosition = downPosition;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.isTrigger) return;

        PlayerController_Script player = collision.GetComponentInParent<PlayerController_Script>();
        if (player != null && player.IsBig)
        {
            platform.MoveToStart();
            targetPosition = upPosition;
        }
    }
}