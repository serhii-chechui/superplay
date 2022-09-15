using System.Collections.Generic;
using Superplay.VFX.Config;
using UnityEngine;

namespace Superplay.VFX
{
    public class VFXManager : MonoBehaviour
    {
        [SerializeField]
        private VFXManagerConfig vfxManagerConfig;

        public void Initialize()
        {
            
        }

        public void SpawnVFX(VFXTypes vfxType, Transform effectParent = null, bool playImmediately = false)
        {
            var effect = vfxManagerConfig.GetEffectHandlerByType(vfxType);

            if (effect != null)
            {
                var effectInstance = Instantiate(effect);

                if (effectParent != null)
                {
                    effectInstance.transform.SetParent(effectParent);
                }
                
                if (playImmediately)
                {
                    effectInstance.PlayEffect();
                }
            }
            else
            {
                Debug.LogError("Sorry but there is no {vfxType} was found in the VFXManagerConfig.");
            }
        }
    }
}