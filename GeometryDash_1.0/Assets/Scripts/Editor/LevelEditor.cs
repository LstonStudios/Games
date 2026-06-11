using UnityEngine;
using System.Collections.Generic;

public class LevelEditor : MonoBehaviour
{
    private const int MAX_OBJECTS = 36;

    [SerializeField] private List<GameObject> placeableObjects = new List<GameObject>();
    private List<GameObject> placedObjects = new List<GameObject>();
    private int currentObjectIndex = 0;

    public void PlaceObject(Vector3 position, int objectIndex)
    {
        if (placedObjects.Count >= MAX_OBJECTS)
        {
            Debug.LogWarning($"Maximum object limit ({MAX_OBJECTS}) reached!");
            return;
        }

        if (objectIndex >= 0 && objectIndex < placeableObjects.Count)
        {
            GameObject prefab = placeableObjects[objectIndex];
            GameObject instance = Instantiate(prefab, position, Quaternion.identity);
            placedObjects.Add(instance);
            Debug.Log($"Object placed. Total: {placedObjects.Count}/{MAX_OBJECTS}");
        }
    }

    public void RemoveObject(GameObject obj)
    {
        if (placedObjects.Contains(obj))
        {
            placedObjects.Remove(obj);
            Destroy(obj);
            Debug.Log($"Object removed. Total: {placedObjects.Count}/{MAX_OBJECTS}");
        }
    }

    public void ClearLevel()
    {
        foreach (GameObject obj in placedObjects)
        {
            Destroy(obj);
        }
        placedObjects.Clear();
        Debug.Log("Level cleared");
    }

    public int GetObjectCount() => placedObjects.Count;
    public int GetMaxObjects() => MAX_OBJECTS;
    public List<GameObject> GetPlacedObjects() => new List<GameObject>(placedObjects);
}
