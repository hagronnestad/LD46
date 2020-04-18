using Assets.Scripts.Interfaces;
using UnityEngine;

namespace Assets.Scripts.Enemies {
    public class EnemyBase : MonoBehaviour, IHealthSystem {

        public void Kill() {
            Destroy(gameObject);
        }


        // IHealthSystem implementation

        public float Health;

        public void Damage(float amount) {
            Health -= amount;
            if (Health < 0f) Health = 0f;

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
