using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Assets.Scripts.Audio {

    public class AudioManager : MonoBehaviour {

        public static AudioManager Instance;

        public List<AudioClipWrapper> AudioClips;
        public AudioSource AudioSource;


        private void Awake() {
            if (Instance == null) {
                Instance = this;
            }
        }

        public void Play(string name, float volumeScale = 1f) {
            var audio = AudioClips.FirstOrDefault(x => x.Name == name);

            if (audio == null) return;

            Play(audio.AudioClip, volumeScale);
        }

        public void Play(AudioClip audioClip, float volumeScale = 1f) {
            AudioSource.PlayOneShot(audioClip, volumeScale);
        }

    }

}
