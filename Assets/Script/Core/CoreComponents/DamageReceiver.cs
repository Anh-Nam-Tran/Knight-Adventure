using UnityEngine;


    public class DamageReceiver : CoreComponent, IDamageable
    {
        //[SerializeField] private GameObject damageParticles;

        private Resource resource;
        //private ParticleManager particleManager;

        public void Damage(float amount) {
            Debug.Log(core.transform.parent.name + " Damaged!");
            resource.Health.Decrease(DamageCalculation(resource.stat.currentDefense, amount));
            //particleManager.StartParticlesWithRandomRotation(damageParticles);
        }

        public float DamageCalculation(float def, float atk)
        {
            return Mathf.Round(atk * (100 / (100 + def)));
        }

        protected override void Awake()
        {
            base.Awake();

            resource = core.GetCoreComponent<Resource>();
            //particleManager = core.GetCoreComponent<ParticleManager>();
        }
    }
