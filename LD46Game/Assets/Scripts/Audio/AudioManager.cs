using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Assets.Scripts.Audio {

    public class AudioManager : MonoBehaviour {

        public static AudioManager Instance;

        public List<AudioClipWrapper> AudioClips;
        public AudioSource AudioSource;

        private void Awake() {
            if (Instance == null) Instance = this;
        }

        public void Play(string name) {
            var audio = AudioClips.FirstOrDefault(x => x.Name == name);

            if (audio == null) return;

            Play(audio.AudioClip);
        }

        public void Play(AudioClip audioClip) {
            AudioSource.PlayOneShot(audioClip);
        }

    }

}
