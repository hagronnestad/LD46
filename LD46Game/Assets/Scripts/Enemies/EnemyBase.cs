using Assets.Scripts.Interfaces;
using Assets.Scripts.Managers;
using UnityEngine;

namespace Assets.Scripts.Enemies {
    public class EnemyBase : MonoBehaviour, IHealthSystem {

        public ParticleSystem BloodSpatterDamage;
        public ParticleSystem BloodSpatterKill;

        public void Kill() {
            GameManager.Instance.GainWizardEnergy(0.05f);

            var bs = Instantiate(BloodSpatterKill, transform.position, Quaternion.identity);
            Destroy(bs.gameObject, bs.main.duration);

            Destroy(gameObject);
        }


        // IHealthSystem implementation

        public float Health;

        public void Damage(float amount) {
            Health -= amount;
            if (Health < 0f) Health = 0f;

            var bs = Instantiate(BloodSpatterDamage, transform.position, Quaternion.identity);
            Destroy(bs.gameObject, bs.main.duration);

            if (Health == 0) Kill();
        }

        public float GetHealth() {
            return Health;
        }

        public void Heal(float amount) {
            Health += amount;
            if (Health > 1.0f) Health = 1.0f;
        }

        public void SetHealth(float value) {
            Health = value;
        }
    }
}
