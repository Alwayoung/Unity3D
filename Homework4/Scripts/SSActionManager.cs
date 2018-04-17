using System.Collections;  
using System.Collections.Generic;  
using UnityEngine;  
  
public class SSActionManager : MonoBehaviour {  
  
    private Dictionary<int, SSAction> actions = new Dictionary<int, SSAction>();          
    private List<SSAction> waitingAdd = new List<SSAction>();                           
    private List<int> waitingDelete = new List<int>();                                    
  
      
    protected void Start()  
    {  
  
    }  
  
    protected void Update()  
    {  
        foreach (SSAction act in waitingAdd) actions[act.GetInstanceID()] = act;  
        waitingAdd.Clear();  
    
        foreach (KeyValuePair<int, SSAction> kv in actions)  
        {  
            SSAction act = kv.Value;  
            if (act.destroy)  
            {  
                waitingDelete.Add(act.GetInstanceID());  
            }  
            else if (act.enable)  
            {  
                act.Update();  
            }  
        }  
  
        foreach (int keyy in waitingDelete)  
        {  
            SSAction act = actions[keyy];  
            actions.Remove(keyy);  
            DestroyObject(act);  
        }  
        waitingDelete.Clear();  
    }  
  
    public void RunAction(GameObject gameobject, SSAction action, ISSActionCallback manager)  
    {  
        action.gameobject = gameobject;  
        action.transform = gameobject.transform;  
        action.callback = manager;  
        waitingAdd.Add(action);  
        action.Start();  
    }  
}  
