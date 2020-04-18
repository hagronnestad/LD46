using Assets.Scripts.Interfaces;
using UnityEngine;

namespace Assets.Scripts.Enemies {
    class EnemyBase : MonoBehaviour, IHealthSystem {

        private float _health;

        float IHealthSystem.Health { get => _health; set => _health = value; }

        public void Damage(float amount) {
            _health -= amount;
            if (_health < 0f) _health = 0f;

            if (_health == 0) Kill();
        }

        public void Heal(float amount) {
            _health += amount;
            if (_health > 1.0f) _health = 1.0f;
        }

        public void Kill() {
            Destroy(this);
        }
    }
}
