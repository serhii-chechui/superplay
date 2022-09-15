using System.Collections.Generic;
using UnityEngine;

namespace Superplay.VFX.Config
{
    [CreateAssetMenu(fileName = "VFXManagerConfig", menuName = "Superplay/VFX/VFXManagerConfig", order = 0)]
    public class VFXManagerConfig : ScriptableObject
    {
        [SerializeField]
        private List<VFXManagerConfigData> effectList = new List<VFXManagerConfigData>();

        public VFXHandler GetEffectHandlerByType(VFXTypes type)
        {
            return effectList.Find(x => x.type == type).handler;
        }
    }
}