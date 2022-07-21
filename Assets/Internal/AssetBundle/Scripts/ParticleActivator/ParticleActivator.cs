using System.Collections.Generic;
using UnityEngine;

public class ParticleActivator : MonoBehaviour
{
    [SerializeField] private string note = "Где используется эта партикл система";

    [Space(5f)] 
    [SerializeField] private List<ParticleSystem> particleSystems;
    [SerializeField] private bool triggerAlreadyPlayed;

    public void TryPlayParticles()
    {
        if (particleSystems.Count == 0)
        {
            return;
        }

        foreach (var selectedParticleSystem in particleSystems)
        {
            ActivateParticleSystem(selectedParticleSystem);
        }
    }

    #region Main Actions

    private void ActivateParticleSystem(ParticleSystem selectedParticleSystem)
    {
        if (selectedParticleSystem.isPlaying && !triggerAlreadyPlayed) return;

        selectedParticleSystem.Play();
    }

    #endregion

    #region Initialization

    private void Start()
    {
        // Just to remove warning in console
        note = note + "!";
    }

    #endregion
}