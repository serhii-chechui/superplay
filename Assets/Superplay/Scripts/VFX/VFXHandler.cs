using UnityEngine;

namespace Superplay.VFX
{
    public class VFXHandler : MonoBehaviour
    {
        [SerializeField]
        private ParticleSystem particleSystem;

        private void Awake()
        {
            particleSystem = GetComponent<ParticleSystem>();
        }

        public void PlayEffect()
        {
            particleSystem.Play();
        }
    }
}