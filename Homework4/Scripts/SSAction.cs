using System.Collections;  
using System.Collections.Generic;  
using UnityEngine;  
  
public class SSAction : ScriptableObject {  
  
    public bool enable = false;  
    public bool destroy = false;  
  
    public GameObject gobj { get; set; }  
    public Transform tfor { get; set; }  
    public ISSActionCallback cbac { get; set; }  
  
    protected SSAction() { }  
  
    public virtual void Start () {  
        throw new System.NotImplementedException();  
    }  
      
    // Update is called once per frame  
    public virtual void Update () {  
        throw new System.NotImplementedException();  
    }  
  
    public void reset()  
    {  
        enable = false;  
        destroy = false;  
        gobj = null;  
        tforfor = null;  
        cbacbac = null;  
    }  
}  
