using System;
using System.Collections.Generic;
using UnityEngine;

public class TransparentMaterialsActivator : MonoBehaviour
{
    public event EventHandler<bool> OnMaterialTransparencyChanged;
    
    [SerializeField] private List<AssociatedTransparentMaterial> associatedMaterials;

    private MeshRenderer _renderer;
    private bool _lastState = true;
    
    public void ChangeVisibilityState(bool newState)
    {
        if (newState == _lastState) return;
         
        for (int i = 0; i < _renderer.materials.Length; i++)
        {
            SetNewMaterial(associatedMaterials[i], i, newState);
        }

        _lastState = newState;
        OnMaterialTransparencyChanged?.Invoke(this, newState);
    }

    private void SetNewMaterial(AssociatedTransparentMaterial associatedMaterial, int replacedMaterialIndex,
        bool newState)
    {
        var replacedMaterial = GetReplacedMaterial(associatedMaterial, newState);
        
        var materials = _renderer.materials;
        materials[replacedMaterialIndex] = replacedMaterial;
        _renderer.materials = materials;
    }

    private Material GetReplacedMaterial(AssociatedTransparentMaterial associatedMaterial, bool newState)
    {
        return newState ? associatedMaterial.OriginalMaterial : associatedMaterial.TransparentMaterial;
    }

    #region Init

    private void Awake()
    {
        TryGetComponent(out _renderer);
    }

    #endregion
}
