using Assets.Scripts.Managers;
using System;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Ui {

    public class UiPauseMenu : MonoBehaviour {

        public GameObject Container;

        public Button ResumeButton;
        public Button RestartButton;

        private void Awake() {
            ResumeButton.onClick.AddListener(OnClick_Resume);
            RestartButton.onClick.AddListener(OnClick_Restart);
        }

        private void OnClick_Resume() {
            ClosePauseMenu();
            GameManager.Instance.ResumeGame();
        }

        private void OnClick_Restart() {
            GameManager.Instance.RestartGame();
        }

        // Start is called before the first frame update
        void Start() {

        }

        // Update is called once per frame
        void Update() {

        }


        public void OpenPauseMenu() {
            GameManager.Instance.PauseGame();
            Container.SetActive(true);
        }

        public void ClosePauseMenu() {
            GameManager.Instance.ResumeGame();
            Container.SetActive(false);
        }
    }

}