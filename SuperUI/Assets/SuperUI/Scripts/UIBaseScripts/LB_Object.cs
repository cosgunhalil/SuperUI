//27.05.20 - Halil Cosgun

namespace LB.SuperUI.BaseComponents
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public abstract class LB_Object : MonoBehaviour
    {
        public abstract void PreInit();
        public abstract void Init();
        public abstract void LateInit();
    }
}

