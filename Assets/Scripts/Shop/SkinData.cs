using System;
using UnityEngine;

[CreateAssetMenu(menuName = "Create Skin Data", fileName = "Skin")]
public class SkinData : ScriptableObject
{
    public string GUID = Guid.NewGuid().ToString();
    public Material SkinMaterial;
    public Texture ShopIcon;
    public int Cost;
}