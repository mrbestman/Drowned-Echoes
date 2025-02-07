using UnityEngine;

public class ObjectiveSystem : MonoBehaviour
{
    public static ObjectiveSystem Instance { get; private set; }
    public ObjectiveManager Objectives { get; private set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            Objectives = new ObjectiveManager();
        }
        else
        {
            Destroy(gameObject);
        }
    }
}

