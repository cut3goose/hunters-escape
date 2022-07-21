using UnityEngine;

public class LogoDisplayController : MonoBehaviour
{
    [SerializeField] private GameObject logo;
    [SerializeField] private GameObject gdpr;
    
    private void Update()
    {
        if (gdpr.activeInHierarchy)
        {
            logo.SetActive(false);
        }
        else
        {
            logo.SetActive(true);
        }
    }
}
