using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Ui {

    public class ScrollPopUp : MonoBehaviour {

        public GameObject Container;

        public Text Title;
        public Text Text;
        public Text PageNo;
        public Button Continue;

        private List<string> _texts;
        private int _currentTextIndex = 0;

        public void OpenScroll(string title, List<string> texts) {
            _currentTextIndex = 0;
            _texts = texts;

            Title.text = title;
            Text.text = _texts[_currentTextIndex];
            PageNo.text = $"{_currentTextIndex + 1}/{_texts.Count}";

            Container.SetActive(true);
        }

        public void CloseScroll() {
            Container.SetActive(false);
        }


        private void Awake() {
            Continue.onClick.AddListener(OnClick_Continue);
        }

        private void OnClick_Continue() {
            _currentTextIndex++;

            if (_currentTextIndex == _texts.Count) {
                CloseScroll();

            } else {
                Text.text = _texts[_currentTextIndex];
                PageNo.text = $"{_currentTextIndex + 1}/{_texts.Count}";
            }
        }

        // Start is called before the first frame update
        void Start() {

        }

        // Update is called once per frame
        void Update() {

        }
    }

}