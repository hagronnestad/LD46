using UnityEngine;
using Random = UnityEngine.Random;

namespace Assets.Scripts.Systems {

    public class CameraShake : MonoBehaviour {

        public bool Shaking;
        private float ShakeDecay;
        private float ShakeIntensity;
        private Vector3 OriginalPos;
        private Quaternion OriginalRot;

        void Start() {
            Shaking = false;
        }

        // Update is called once per frame
        void Update() {
            if (ShakeIntensity > 0) {
                transform.position = OriginalPos + Random.insideUnitSphere * ShakeIntensity;
                transform.rotation = new Quaternion(
                    OriginalRot.x + Random.Range(-ShakeIntensity, ShakeIntensity) * .2f,
                    OriginalRot.y + Random.Range(-ShakeIntensity, ShakeIntensity) * .2f,
                    OriginalRot.z + Random.Range(-ShakeIntensity, ShakeIntensity) * .2f,
                    OriginalRot.w + Random.Range(-ShakeIntensity, ShakeIntensity) * .2f
                );

                ShakeIntensity -= ShakeDecay;

            } else if (Shaking) {
                transform.position = OriginalPos;
                transform.rotation = OriginalRot;

                Shaking = false;
            }
        }

        public void DoShake(float intensity = 0.1f, float decay = 0.02f) {
            OriginalPos = transform.position;
            OriginalRot = transform.rotation;

            ShakeIntensity = intensity;
            ShakeDecay = decay;
            Shaking = true;
        }

    }
}
