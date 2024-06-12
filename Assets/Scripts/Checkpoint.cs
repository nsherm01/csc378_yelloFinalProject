using UnityEngine;
using UnityEngine.SceneManagement;

public class Checkpoint : MonoBehaviour
{
    public SpriteRenderer renderer;
    public Sprite curSprite;
    public Sprite notCurSprite;

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

                if (renderer.transform.position == checkpointManager.currentCheckpoint.position)
                {
                    renderer.sprite = curSprite;
                } 
                else
                {
                    renderer.sprite = notCurSprite;
                }
                
            }
        }
    }
}
