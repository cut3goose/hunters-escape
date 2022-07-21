using System.Collections;
using UnityEngine;

public class HPRegeneration : MonoBehaviour
{
    [SerializeField] private HPRegenerationConfig regenerationConfig;

    private Coroutine _regenerationCoroutine;
    private Health _regeneratedHealth;
    
    public void StartRegenerationCoroutine()
    {
        _regenerationCoroutine = StartCoroutine(RegenerateHP());
    }

    public void ResetRegenerationCoroutine()
    {
        if (_regenerationCoroutine == null) return;
        
        StopCoroutine(_regenerationCoroutine);
        _regenerationCoroutine = null;
    }

    private IEnumerator RegenerateHP()
    {
        if (_regenerationCoroutine != null) yield break;
        
        yield return new WaitForSeconds(regenerationConfig.RegeneraionTime);
        
        ResetRegenerationCoroutine();
        _regeneratedHealth.TryRestoreHealth(regenerationConfig.RegenerationAmount);
    }

    #region Init

    private void Awake()
    {
        TryGetComponent(out _regeneratedHealth);
    }

    #endregion
}