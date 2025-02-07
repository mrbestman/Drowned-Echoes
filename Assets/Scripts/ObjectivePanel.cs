using UnityEngine;
using System.Collections.Generic;

public class ObjectivePanel : MonoBehaviour
{
    [SerializeField]
    private ObjectiveDisplay _objectiveDisplayPrefab;

    [SerializeField]
    private Transform _objectiveDisplayParent;

    private readonly List<ObjectiveDisplay> _listDisplay = new();

    void Start()
    {
        // Use ObjectiveSystem instead of GameManager
        foreach (var objective in ObjectiveSystem.Instance.Objectives.Objectives)
        {
            AddObjective(objective);
        }

        ObjectiveSystem.Instance.Objectives.OnObjectiveAdded += AddObjective;
    }

    private void AddObjective(Objective obj)
    {
        var display = Instantiate(_objectiveDisplayPrefab, _objectiveDisplayParent);
        display.Init(obj);
        _listDisplay.Add(display);
    }

    public void Reset()
    {
        for (var i = _listDisplay.Count - 1; i >= 0; i--)
        {
            Destroy(_listDisplay[i].gameObject);
        }
        _listDisplay.Clear();
    }
}

