using System.Collections.Generic;
using UnityEngine;

public class ShopManager : Singleton<ShopManager>
{
    [SerializeField] private List<SkinData> skins;
    [SerializeField] private Transform iconsContainer;
    [SerializeField] private SkinIcon skinIconPrefab;
    // TODO: load player owned skins data
    
    public void CloseShop()
    {
        
    }

    public void SelectSkin(SkinData skinData)
    {
        
    }

    public void ChooseSkin()
    {
        
    }

    private void GenerateIcons()
    {
        for (int i = 0; i < iconsContainer.childCount; i++)
        {
            var child = iconsContainer.GetChild(i);
            child.gameObject.SetActive(false);
            child.SetParent(null);
            Destroy(child);
        }

        foreach (var selectedSkinData in skins)
        {
            var createdIcon = Instantiate(skinIconPrefab, iconsContainer);
            createdIcon.SkinData = selectedSkinData;
        }
    }

    protected override void Awake()
    {
        base.Awake();
        
        GenerateIcons();
    }
}
