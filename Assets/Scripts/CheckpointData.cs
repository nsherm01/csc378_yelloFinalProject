using UnityEngine;
using UnityEngine.SceneManagement;

[System.Serializable]
public class CheckpointData
{
    public string sceneName;
    public Vector3 position;

    public CheckpointData(string sceneName, Vector3 position)
    {
        this.sceneName = sceneName;
        this.position = position;
    }
}
