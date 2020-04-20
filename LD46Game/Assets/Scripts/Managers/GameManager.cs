using Assets.Scripts.Audio;
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

        private Animator _wizardHealthBarAnimator;

        public GameState CurrentGameState;

        private bool _playEnergyFullCoolDown = false;

        private void Awake() {
            if (Instance == null) Instance = this;

            CurrentGameState = GameState.NotStarted;
            Time.timeScale = 1;

            _wizardHealthBarAnimator = WizardHealthBar.gameObject.GetComponent<Animator>();
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

            if (WizardHealthBar.Health < 0.9f) {
                ResetPlayEnergyFullCoolDown();
            }

            _wizardHealthBarAnimator.SetFloat("Health", WizardHealthBar.Health);
        }

        private void LateUpdate() {
            if (WizardHealthBar.Health == 0) GameOver();
        }

        public void UseWizardEnergy(float amount) {
            WizardHealthBar.Health -= amount;
            if (WizardHealthBar.Health < 0f) WizardHealthBar.Health = 0f;
        }

        public void GainWizardEnergy(float amount) {
            WizardHealthBar.Health += amount;
            if (WizardHealthBar.Health >= 1.0f) {
                WizardHealthBar.Health = 1.0f;
                // TODO: Add sound indicating energy fully charged

                if (!_playEnergyFullCoolDown) {
                    _playEnergyFullCoolDown = true;

                    AudioManager.Instance.Play("energy_full", 0.4f);
                    //Invoke(nameof(ResetPlayEnergyFullCoolDown), 1.5f);
                }
            }
        }

        private void ResetPlayEnergyFullCoolDown() {
            _playEnergyFullCoolDown = false;
        }

        public void GameOver() {
            if (CurrentGameState == GameState.GameOver) return;
            CurrentGameState = GameState.GameOver;
            GetComponent<AudioSource>().Pause();
            Time.timeScale = 0;

            ScrollPopUp.OpenScroll("Game Over", new List<string>() {
                "Thee drained all the wizards energy!"

            }, () => {
                RestartGame();
            });
        }

        public void TogglePauseMenu() {
            if (CurrentGameState != GameState.Paused && CurrentGameState != GameState.GameOver) {
                PauseMenu.OpenPauseMenu();
            } else {
                PauseMenu.ClosePauseMenu();
            }
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