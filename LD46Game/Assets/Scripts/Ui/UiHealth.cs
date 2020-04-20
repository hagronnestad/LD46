using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Ui {
    public class UiHealth : MonoBehaviour {

        public float Health;

        public Image frame;
        public Image fill;

        // Update is called once per frame
        void Update() {
            fill.rectTransform.sizeDelta = new Vector2(frame.rectTransform.rect.width, frame.rectTransform.rect.height * Health);
        }
    }
}