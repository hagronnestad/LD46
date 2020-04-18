using Assets.Scripts.Ui;
using UnityEngine;

namespace Assets.Scripts.Managers {
    public class GameManager : MonoBehaviour {

        public static GameManager Instance;

        public UiHealth WizardHealthBar;

        private void Awake() {
            if (Instance == null) Instance = this;
        }


        // Start is called before the first frame update
        void Start() {

        }

        // Update is called once per frame
        void Update() {

        }



        public void UseWizardEnergy(float amount) {
            WizardHealthBar.Health -= amount;
            if (WizardHealthBar.Health < 0f) WizardHealthBar.Health = 0f;
        }

        public void GainWizardEnergy(float amount) {
            WizardHealthBar.Health += amount;
            if (WizardHealthBar.Health > 1.0f) WizardHealthBar.Health = 1.0f;
        }
    }
}