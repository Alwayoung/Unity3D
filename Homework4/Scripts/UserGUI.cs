using System.Collections;  
using System.Collections.Generic;  
using UnityEngine;  
  
public class UserGUI : MonoBehaviour  
{  
    private IUserAction act;  
    bool isFirst = true;   
    void Start () {  
        act = Director.getInstance().currentSceneControl as IUserAction;  
  
    }  
  
    private void OnGUI()  
    {  
        if (Input.GetButtonDown("Fire1"))  
        {  
  
            Vector3 pos = Input.mousePosition;  
            act.hit(pos);  
  
        }  
  
        GUI.Label(new Rect(1000, 0, 400, 400), act.GetScore().ToString());  
  
        if (isFirst && GUI.Button(new Rect(700, 100, 90, 90), "Start")) {  
            isFirst = false;  
            act.setGameState(GameState.ROUND_START);  
        }  
  
        if (!isFirst && act.getGameState() == GameState.ROUND_FINISH && GUI.Button(new Rect(700, 100, 90, 90), "Next Round"))  
        {  
            act.setGameState(GameState.ROUND_START);  
        }  
          
    }  
  
     
}  
