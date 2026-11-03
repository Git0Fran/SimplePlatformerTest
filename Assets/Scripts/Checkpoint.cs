using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    [SerializeField]
    private GameObject inactiveState = null;
    [SerializeField]
    private GameObject activatedState = null;


    private void Awake()
    {
        inactiveState.SetActive(true);
        activatedState.SetActive(false);
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision != null && collision.gameObject != null)
        {
            inactiveState.SetActive(false);
            activatedState.SetActive(true);
            GetComponent<Collider2D>().enabled = false;
            CheckpointManager.Instance.SetHitCheckpoint(this);
        }
    }
}
