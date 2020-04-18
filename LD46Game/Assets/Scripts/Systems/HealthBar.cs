using Assets.Scripts.Interfaces;
using UnityEngine;

namespace Assets.Scripts.Systems {

    public class HealthBar : MonoBehaviour {

        public GameObject Background;
        public GameObject Bar;

        public IHealthSystem healthSystem;

        private void Awake() {
            healthSystem = (IHealthSystem) transform.parent.gameObject.GetComponent<MonoBehaviour>();
        }

        // Update is called once per frame
        void Update() {
            Bar.transform.localScale = new Vector3(Background.transform.localScale.x * healthSystem.GetHealth(), Background.transform.localScale.y, Background.transform.localScale.z);
        }
    }
}