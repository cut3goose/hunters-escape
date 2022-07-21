using System.Collections.Generic;

public class DataStorage<T>
{
    public List<T> ObjectsInStorage { get; protected set; } = new List<T>();
    
    public void AddObjectToStorage(T objectToAdd)
    {
        ObjectsInStorage.Add(objectToAdd);
    }

    public void RemoveObjectFromStorage(T objectToRemove)
    {
        if (!CheckIfObjectContained(objectToRemove)) return;
        
        ObjectsInStorage.Remove(objectToRemove);
    }

    public bool CheckIfObjectContained(T objectToCheck)
    {
        return ObjectsInStorage.Contains(objectToCheck);
    }
}
