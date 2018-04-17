using System.Collections;  
using System.Collections.Generic;  
using UnityEngine;  
  
public class Director : System.Object {    
    public ISceneControl currentSceneControl { get; set; }   
    private static Director dirr;  
  
    private Director()  
    {  
  
    }  
  
    public static Director getInstance()  
    {  
        if (dirr == null)  
        {  
            dirr = new Director();  
        }  
        return dirr;  
    }  
}  
