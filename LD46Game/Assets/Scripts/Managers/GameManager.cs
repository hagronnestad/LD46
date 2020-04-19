using Assets.Scripts.Enums;
using Assets.Scripts.Ui;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts.Managers {
    public class GameManager : MonoBehaviour {

        public static GameManager Instance;

        public UiHealth WizardHealthBar;
        public ScrollPopUp ScrollPopUp;
        public UiPauseMenu PauseMenu;

        public GameState CurrentGameState;

        private void Awake() {
            if (Instance == null) Instance = this;

            CurrentGameState = GameState.NotStarted;
            Time.timeScale = 1;
        }


        // Start is called before the first frame update
        void Start() {
            //ScrollPopUp.OpenScroll("Test", new List<string>() {
            //    "This is the first text!",
            //    "This is the second text!",
            //});
        }

        // Update is called once per frame
        void Update() {

            //if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown("joystick 1 button 7")) {

            //    if (CurrentGameState != GameState.Paused && CurrentGameState != GameState.GameOver) {
            //        PauseMenu.OpenPauseMenu();
            //    }

            //    else {
            //        PauseMenu.ClosePauseMenu();
            //    }

            //}

        }

        public void UseWizardEnergy(float amount) {
            WizardHealthBar.Health -= amount;
            if (WizardHealthBar.Health < 0f) WizardHealthBar.Health = 0f;

            if (WizardHealthBar.Health == 0) GameOver();
        }

        public void GainWizardEnergy(float amount) {
            WizardHealthBar.Health += amount;
            if (WizardHealthBar.Health > 1.0f) WizardHealthBar.Health = 1.0f;
        }

        public void GameOver() {
            if (CurrentGameState == GameState.GameOver) return;
            CurrentGameState = GameState.GameOver;

            ScrollPopUp.OpenScroll("Game Over", new List<string>() {
                "Oh no! You have greatly failed your quest by draining all the energy and sacrificing the mage in the process!",
                "You did not keep it alive!"

            }, () => {
                RestartGame();
            });
        }


        public void PauseGame() {
            CurrentGameState = GameState.Paused;
            Time.timeScale = 0;
        }

        public void ResumeGame() {
            CurrentGameState = GameState.Playing;
            Time.timeScale = 1;
        }

        public void RestartGame() {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

    }
}