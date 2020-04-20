using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Ui {

    public class ScrollPopUp : MonoBehaviour {

        public GameObject Container;

        public Text Title;
        public Text Text;
        public Text PageNo;
        public Button ContinueButton;
        public Action ContinueAction;

        private List<string> _texts;
        private int _currentTextIndex = 0;

        public void OpenScroll(string title, List<string> texts, Action continueAction = null) {
            _currentTextIndex = 0;
            _texts = texts;

            Title.text = title.ToUpper();
            Text.text = _texts[_currentTextIndex].ToUpper();
            PageNo.text = $"{_currentTextIndex + 1}/{_texts.Count}";

            ContinueAction = continueAction;

            Container.SetActive(true);
            ContinueButton.Select();
        }

        public void CloseScroll() {
            Container.SetActive(false);
        }


        private void Awake() {
            //ContinueButton.onClick.AddListener(OnClick_Continue);
        }

        public void OnClick_Continue() {
            _currentTextIndex++;

            if (_currentTextIndex == _texts.Count) {
                CloseScroll();
                ContinueAction?.Invoke();

            } else {
                Text.text = _texts[_currentTextIndex].ToUpper();
                PageNo.text = $"{_currentTextIndex + 1}/{_texts.Count}";
            }
        }
    }
}