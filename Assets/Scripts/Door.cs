using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField] private int playersRequired = 2;
    [SerializeField] private string playerTag = "Player";
    [SerializeField] private LevelManager levelManager;

    private int playersInside = 0;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag(playerTag)) return;

        playersInside++;

        if (playersInside >= playersRequired)
        {
            levelManager.NextScene();
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (!other.CompareTag(playerTag)) return;

        playersInside--;
    }
}