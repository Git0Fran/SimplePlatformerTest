using UnityEngine;

public class CheckpointManager : MonoBehaviour
{
    private Checkpoint lastsavedCheckpoint = null;
    private static CheckpointManager instance;
    public static CheckpointManager Instance { get { return instance; } }


    private void Awake()
    {


        if (instance == null)
        {
            instance = this;
        }
        else 
        {
            Destroy(gameObject);
        }
    }



    public void SetHitCheckpoint(Checkpoint checkpoint)
    {
        lastsavedCheckpoint = checkpoint;
    }

    public bool TryGetLastCheckpointPosition(out Vector3 checkpointPosition)
    {
        checkpointPosition = Vector3.zero;
        if (lastsavedCheckpoint == null)
        {
            return false;
        }
        checkpointPosition = lastsavedCheckpoint.transform.position;
        return true;
    }
}
