using System.Collections;  
using System.Collections.Generic;  
using UnityEngine;  
using UnityEngine.UI;  
  
public class Bulletin : MonoBehaviour {  
  
    private Button yourButton;  
    public Text text;  
    private int frame = 20;  
    
    void Start()  
    {  
        Button but = this.gameObject.GetComponent<Button>();  
        but.onClick.AddListener(TaskOnClick);  
    }  
  
    IEnumerator rotateIn()  
    {  
        float rox = 0;  
        float xoy = 120;  
        for (int i = 0; i < frame; i++)  
        {  
            rox -= 90f / frame;  
            xoy -= 120f / frame;  
            text.transform.rotation = Quaternion.Euler(rox, 0, 0);  
            text.rectTransform.sizeDelta = new Vector2(text.rectTransform.sizeDelta.x, xoy);  
            if (i == frame - 1)  
            {  
                text.gameObject.SetActive(false);  
            }  
            yield return null;  
        }  
    }  
  
    IEnumerator rotateOut()  
    {  
        float rox = -90;  
        float xoy = 0;  
        for (int i = 0; i < frame; i++)  
        {  
            rox += 90f / frame;  
            xoy += 120f / frame;  
            text.transform.rotation = Quaternion.Euler(rox, 0, 0);  
            text.rectTransform.sizeDelta = new Vector2(text.rectTransform.sizeDelta.x, xoy);  
            if (i == 0)  
            {  
                text.gameObject.SetActive(true);  
            }  
            yield return null;  
        }  
    }  
  
  
    void TaskOnClick()  
    {  
        if (text.gameObject.activeSelf)  
        {  
            StartCoroutine(rotateIn());  
        }  
        else  
        {  
            StartCoroutine(rotateOut());  
        }  
          
    }  
}  
