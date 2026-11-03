using Unity.VisualScripting;
using UnityEngine;

public class KillVolume : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision != null && collision.gameObject != null)
        {
            PlayerController_Script player =  collision.gameObject.GetComponent<PlayerController_Script>();
            player.RespawnPlayer();
        }
    
    }
}
