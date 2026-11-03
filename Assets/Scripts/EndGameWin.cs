using UnityEngine;

public class EndGameWin : MonoBehaviour
{
    [SerializeField] private GameObject winText = null;
    [SerializeField] private int playersRequired = 2;

    private int playersInside = 0;

    private void Start()
    {
        winText.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.isTrigger) return;
        if (other.GetComponentInParent<PlayerController_Script>() == null) return;

        playersInside++;
        if (playersInside >= playersRequired)
        {
            winText.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.isTrigger) return;
        if (other.GetComponentInParent<PlayerController_Script>() == null) return;

        playersInside--;
    }
}