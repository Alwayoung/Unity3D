using System;  
using System.Collections;  
using System.Collections.Generic;  
using UnityEngine;  
  
public class CCActionManager : SSActionManager, ISSActionCallback {  
      
    public FirstSceneControl sceneController;  
    public List<CCFlyAction> Fly;  
    public int DNum = 0;  
  
    private List<SSAction> used = new List<SSAction>();  
    private List<SSAction> free = new List<SSAction>();  
  
    SSAction GetSSAction()  
    {  
        SSAction act = null;  
        if (free.Count > 0)  
        {  
            act = free[0];  
            free.Remove(free[0]);  
        }  
        else  
        {  
            act = ScriptableObject.Instantiate<CCFlyAction>(Fly[0]);  
        }  
  
        used.Add(act);  
        return act;  
    }  
      
    public void FreeSSAction(SSAction act)  
    {  
        SSAction abc = null;  
        foreach (SSAction i in used)  
        {  
            if (action.GetInstanceID() == i.GetInstanceID())  
            {  
                abc = i;  
            }  
        }  
        if (abc != null)  
        {  
            abc.reset();  
            free.Add(abc);  
            used.Remove(abc);  
        }  
    }  
  
    protected new void Start()  
    {  
        sceneController = (FirstSceneControl)Director.getInstance().currentSceneControl;  
        sceneController.actionManager = this;  
        Fly.Add(CCFlyAction.GetSSAction());  
          
    }  
  
    public void SSActionEvent(SSAction source,  
        SSActionEventType events = SSActionEventType.Competeted,  
        int intParam = 0,  
        string strParam = null,  
        UnityEngine.Object objectParam = null)  
    {  
        if (source is CCFlyAction)  
        {  
            DNum--;  
            DiskFactory df = Singleton<DiskFactory>.Instance;  
            df.FreeDisk(source.gameobject);  
            FreeSSAction(source);  
        }  
    }  
  
    public void StartThrow(Queue<GameObject> diskQueue)  
    {  
        foreach (GameObject abc in diskQueue)  
        {  
            RunAction(abc, GetSSAction(), (ISSActionCallback)this);  
        }  
    }  
}  
