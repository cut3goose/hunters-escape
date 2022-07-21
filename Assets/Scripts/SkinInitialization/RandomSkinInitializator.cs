using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class RandomSkinInitializator : MonoBehaviour
{
    [SerializeField] private List<GameObject> availableSkins;

    private void ActivateRandomSkin()
    {
        var selectedSkin = GetRandomSkin();
        availableSkins.Remove(selectedSkin);
        DestroyUnusedSkins();
        
        selectedSkin.SetActive(true);
    }

    private GameObject GetRandomSkin()
    {
        var randomID = Random.Range(0, availableSkins.Count);
        return availableSkins[randomID];
    }

    private void DestroyUnusedSkins()
    {
        foreach (var selectedSkin in availableSkins)
        {
            Destroy(selectedSkin);
        }
    }

    #region Init

    private void Awake()
    {
        ActivateRandomSkin();
    }

    #endregion
}
