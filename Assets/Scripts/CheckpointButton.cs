using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointButton : MonoBehaviour
{
    private static CheckpointButton instance;

    void Awake()
    {
        // Check if an instance of PersistentButton already exists
        if (instance == null)
        {
            // If not, set the instance to this and mark it as not destroyable
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            // If an instance already exists, destroy this one to avoid duplicates
            Destroy(gameObject);
        }
    }
}
