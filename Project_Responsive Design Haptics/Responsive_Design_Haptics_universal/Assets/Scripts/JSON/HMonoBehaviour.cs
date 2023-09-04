
// MonoBehaviour with tweaks for haptic grammar parsing //

using System.Collections        ;
using System.Collections.Generic;
using UnityEngine               ;
using System.IO                 ;
using System                    ;

public abstract class HMonoBehaviour : MonoBehaviour
{
    public abstract void SetVariables(Dictionary<string, string> variable_dictionary);
}