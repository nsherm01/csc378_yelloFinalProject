using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CheckpointManager : MonoBehaviour
{
    private static CheckpointManager instance;

    public CheckpointData currentCheckpoint;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void SetCheckpoint(string sceneName, Vector3 position)
    {
        currentCheckpoint = new CheckpointData(sceneName, position);
        Debug.Log($"Checkpoint set at {sceneName} - {position}");
    }

    public void LoadCheckpoint()
    {
        if (currentCheckpoint != null)
        {
            Debug.Log($"Loading checkpoint at {currentCheckpoint.sceneName} - {currentCheckpoint.position}");
            StartCoroutine(LoadSceneAndPosition(currentCheckpoint.sceneName, currentCheckpoint.position));
        }
        else
        {
            Debug.LogWarning("No checkpoint set!");
        }
    }

    private IEnumerator LoadSceneAndPosition(string sceneName, Vector3 position)
    {
        Debug.Log($"Starting to load scene {sceneName}");
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(sceneName);

        while (!asyncLoad.isDone)
        {
            Debug.Log("Loading scene...");
            yield return null;
        }

        Debug.Log("Scene loaded. Finding player...");
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            Debug.Log($"Player found. Moving to position {position}");
            player.transform.position = position;
        }
        else
        {
            Debug.LogError("Player not found in the scene!");
        }
    }
}
