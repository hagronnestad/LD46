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

        // Start is called before the first frame update
        void Start() {

        }

        // Update is called once per frame
        void Update() {
            Bar.transform.localScale = new Vector3(Background.transform.localScale.x * healthSystem.GetHealth(), Background.transform.localScale.y, Background.transform.localScale.z);
        }
    }
}