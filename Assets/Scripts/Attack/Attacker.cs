using System.Collections;
using UnityEngine;

public class Attacker : MonoBehaviour, IAffectedByGameState
{
    [SerializeField] private AttackerConfig config;

    private bool _canAttack = true;
    private bool _isActive = true;
    
    private void Update()
    {
        if (!_canAttack || !_isActive) return;
        
        var foundTarget = TryFindPlayer();
        if (!foundTarget) return;

        StartCoroutine(Attack());
    }

    private IEnumerator Attack()
    {
        _canAttack = false;
        
        yield return new WaitForSeconds(config.AttackDelay);
        
        var foundTarget = TryFindPlayer();
        if (!foundTarget)
        {
            _canAttack = true;
            yield break;
        }
        
        foundTarget.TryApplyDamage(config.Damage, DamageType.Attack,true, transform.forward);
        _canAttack = true;
    }

    #region Auxiliary Actions

    private Health TryFindPlayer()
    {
        var foundTarget = RaycastHelper.TryFindObject<Health>(transform.position,
            transform.forward, config.CheckDistance, config.Masks);
        
        return foundTarget;
    }

    #endregion

    #region State Change Reactions

    public void ChangeState(GameState newState)
    {
        if (newState == GameState.Lose || newState == GameState.Win)
        {
            _isActive = false;
        }
    }

    #endregion
}
