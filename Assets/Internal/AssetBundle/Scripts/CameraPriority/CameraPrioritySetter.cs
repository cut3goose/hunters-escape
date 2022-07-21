using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class CameraPrioritySetter : MonoBehaviour
{
    [field: SerializeField] public List<AssignedCamera> Cameras { get; private set; }

    private CinemachineBrain _cinemachineBrain;
    
    private const int ActivePriority = 100;
    private const int InactivePriority = 1;

    public void PrioritizeCameraOfType(GameState assignmentType)
    {
        foreach (var selectedCamera in Cameras)
        {
            if (selectedCamera.RelatedState != assignmentType) continue;
            
            _cinemachineBrain.m_DefaultBlend.m_Time = selectedCamera.TransitionSpeed;
            PrioritizeCamera(selectedCamera.Camera);
            
            break;
        }
    }

    public void PrioritizeCamera(CinemachineVirtualCamera cameraToPrioritize)
    {
        cameraToPrioritize.Priority = ActivePriority;
        
        foreach (var selectedCamera in Cameras)
        {
            selectedCamera.Camera.Priority = InactivePriority;
        }
    }

    #region Init

    private void Awake()
    {
        _cinemachineBrain = FindObjectOfType<CinemachineBrain>();
    }

    #endregion
}
