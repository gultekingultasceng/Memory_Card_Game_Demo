using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MCG.Core.Base
{
    public interface IEnableDisable
    {
        void PerformOnEnable();
        void PerformOnDisable();
    }
}