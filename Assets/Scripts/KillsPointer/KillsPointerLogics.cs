using UnityEngine;

public class KillsPointerLogics : KillsPointer
{
    [SerializeField] private KillsPointerActivationConfig activationConfig;
    
    private bool _isActivated;
    
    private void Update()
    {
        if (_isActivated)
        {
            return;
        }

        var timeLeft = TimerRoundLimitMonoBehaviour.Instance.TimerRoundLimit.TimeLeft;
        var enemiesKilled = LevelStatistics.Instance.EnemiesKilled;
        if (enemiesKilled < activationConfig.KillLessThanToActivate
            && timeLeft < activationConfig.TimeLessThanActivate && timeLeft > 0)
        {
            StartBlinking();
            _isActivated = true;
        }
    }
}