using System.Collections;  
using System.Collections.Generic;  
using UnityEngine;  
  
public class Singleton<T> : MonoBehaviour where T : MonoBehaviour  
{  
  
    protected static T inst;  
  
    public static T Instance  
    {  
        get  
        {  
            if (inst == null)  
            {  
                inst = (T)FindObjectOfType(typeof(T));  
                if (inst == null)  
                {  
                    Debug.LogError("An instance of " + typeof(T)  
                        + " is needed in the scene, but there is none.");  
                }  
            }  
            return inst;  
        }  
    }  
}  
