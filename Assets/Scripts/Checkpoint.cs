using UnityEngine;
using UnityEngine.SceneManagement;

public class Checkpoint : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Checkpoint collision occurred!");

            CheckpointManager checkpointManager = FindObjectOfType<CheckpointManager>();
            if (checkpointManager != null)
            {
                checkpointManager.SetCheckpoint(SceneManager.GetActiveScene().name, transform.position);
                PlayerController.FirstCheckpoint = true;
            }
        }
    }
}
