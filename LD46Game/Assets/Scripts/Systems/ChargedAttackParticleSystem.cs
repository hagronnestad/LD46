using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

namespace Assets.Scripts.Systems {

    public class ChargedAttackParticleSystem : MonoBehaviour {


        [SerializeField] public Light2D Light;
        [SerializeField] public ParticleSystem ParticleSystem;
        [SerializeField] public List<Sprite> Sprites;

        private List<ParticleSystem> _particleSystems;

        private void Awake() {
            _particleSystems = new List<ParticleSystem>();

            foreach (var s in Sprites) {
                var ps = Instantiate(ParticleSystem, transform);
                ps.textureSheetAnimation.SetSprite(0, s);
                _particleSystems.Add(ps);
            }
        }

        public void Play() {
            _particleSystems.ForEach(x => x.Play());
            Light.gameObject.SetActive(true);
            Destroy(gameObject, 0.15f);
        }

        // Start is called before the first frame update
        void Start() {

        }

        // Update is called once per frame
        void Update() {

        }

    }

}