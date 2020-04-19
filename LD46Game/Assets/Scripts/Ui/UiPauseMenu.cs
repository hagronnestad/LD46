using Assets.Scripts.Managers;
using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

namespace Assets.Scripts.Ui {

    public class UiPauseMenu : MonoBehaviour {

        public GameObject pauseFirstButton;

        public GameObject Container;

        public Button ResumeButton;
        public Button RestartButton;

        private void Awake() {
            pauseFirstButton = GameObject.FindGameObjectWithTag("Resume Button");
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

            EventSystem.current.SetSelectedGameObject(null);

            EventSystem.current.SetSelectedGameObject(pauseFirstButton);
        }

        public void ClosePauseMenu() {
            GameManager.Instance.ResumeGame();
            Container.SetActive(false);
        }
    }

}