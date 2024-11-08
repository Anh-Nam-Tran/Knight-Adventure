using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Death : CoreComponent
{
    [SerializeField] private GameObject[] deathParticles;
    
    private ParticleManager ParticleManager;
    private Resource Resource;
    
    public void Die()
    {
        foreach (var particle in deathParticles)
        {
            ParticleManager.StartParticles(particle);
        }
        
        core.transform.parent.gameObject.SetActive(false);
    }

    private void OnEnable()
    {
        Resource.Health.OnCurrentValueZero += Die;
    }

    private void OnDisable()
    {
        Resource.Health.OnCurrentValueZero -= Die;
    }
}
