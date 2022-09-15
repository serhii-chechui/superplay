using System.Collections.Generic;
using UnityEngine;

namespace Superplay.VFX
{
    public class ParticlesController : MonoBehaviour
    {
        [SerializeField]
        private ParticleSystem particleSystem;

        [SerializeField]
        private Transform target;
    
        private List<Vector4> customData = new List<Vector4>();
    
        private Camera _mainCam;

        private void Awake()
        {
            particleSystem = GetComponent<ParticleSystem>();
        }

        void Start()
        {
            _mainCam = Camera.main;
        }
    
        void Update()
        {
            particleSystem.GetCustomParticleData(customData, ParticleSystemCustomData.Custom1);
        
            var particleCount = particleSystem.particleCount;
            var particles = new ParticleSystem.Particle[particleCount];
        
            particleSystem.GetParticles(particles);
        
            for (int i = 0; i < particles.Length; i++)
            {
                var targetPosition = target.position;
                var particlePosition = transform.TransformPoint(particles[i].position);

                // set custom data to 1, if close enough to the mouse
                if (Vector2.Distance(targetPosition, particlePosition) < 0.01f)
                {
                    customData[i] = new Vector4(1, 0, 0, 0);
                }
                // otherwise, fade the custom data back to 0
                else
                {
                    float particleLife = particles[i].remainingLifetime / particleSystem.main.startLifetimeMultiplier;

                    if (customData[i].x > 0)
                    {
                        float x = customData[i].x;
                        x = Mathf.Max(x - Time.deltaTime, 0.0f);
                        customData[i] = new Vector4(x, 0, 0, 0);
                    }
                }
            }

            particleSystem.SetCustomParticleData(customData, ParticleSystemCustomData.Custom1);
        }
    }
}
