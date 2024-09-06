using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SkinIcon : MonoBehaviour
{
    public SkinData SkinData;

    [SerializeField] private TextMeshProUGUI costText;
    [SerializeField] private RawImage skinIcon;

    public void SelectSkin()
    {
        ShopManager.Instance.SelectSkin(SkinData);
    }

    private void Start()
    {
        costText.text = SkinData.Cost.ToString();
        skinIcon.texture = SkinData.ShopIcon;
    }
}