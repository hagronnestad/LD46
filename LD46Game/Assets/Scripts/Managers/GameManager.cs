using Assets.Scripts.Ui;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Managers {
    public class GameManager : MonoBehaviour {

        public static GameManager Instance;

        public UiHealth WizardHealthBar;
        public ScrollPopUp ScrollPopUp;

        private void Awake() {
            if (Instance == null) Instance = this;
        }


        // Start is called before the first frame update
        void Start() {
            ScrollPopUp.OpenScroll("Test", new List<string>() {
                "This is the first text!",
                "This is the second text!",
            });
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