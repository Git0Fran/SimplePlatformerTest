using UnityEngine;

public class PushableBox : MonoBehaviour
{
    [SerializeField] private Rigidbody2D body = null;
    private bool bigPlayerTouching = false;

    private void Awake()
    {
        if (body == null) body = GetComponent<Rigidbody2D>();
    }







    private void FixedUpdate()
    {
        if (bigPlayerTouching)
        {
            body.constraints = RigidbodyConstraints2D.FreezeRotation;
        }
        else
        {
            body.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezeRotation;
        }

        // Reset->>>OnCollisionStay2D sets it again if a big player is still touching
        bigPlayerTouching = false;
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        PlayerController_Script player = collision.gameObject.GetComponentInParent<PlayerController_Script>();
        if (player != null && player.IsBig)
        {
            bigPlayerTouching = true;
        }
    }
}