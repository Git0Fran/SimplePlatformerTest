using UnityEngine;

public class Mushroom : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerController_Script player = collision.GetComponentInParent<PlayerController_Script>();
        if (player == null || player.IsBig) return;

        player.Grow();
        Destroy(gameObject);
    }
}