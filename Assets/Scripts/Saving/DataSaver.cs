using UnityEngine;

public abstract class DataSaver : MonoBehaviour
{
    [SerializeField] protected string ValueName;
    
    public abstract void SaveData();
    public abstract void LoadData();
}
