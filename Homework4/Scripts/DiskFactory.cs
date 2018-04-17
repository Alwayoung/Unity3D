using System.Collections;  
using System.Collections.Generic;  
using UnityEngine;  
  
public class DiskFactory : MonoBehaviour{  
  
        
    public GameObject diskPrefab;  
        
    private List<DiskData> used = new List<DiskData>();  
    private List<DiskData> free = new List<DiskData>();  
  
    private void Awake()  
    {  
        diskPrefab = GameObject.Instantiate<GameObject>(Resources.Load<GameObject>("Prefabs/disk"), Vector3.zero, Quaternion.identity);  
        diskPrefab.SetActive(false);  
    }  
  
    public GameObject GetDisk(int rou)  
    {  
        GameObject newDisk = null;  
        if (free.Count > 0)  
        {  
            newDisk = free[0].gameObject;  
            free.Remove(free[0]);  
        }  
        else  
        {  
            newDisk = GameObject.Instantiate<GameObject>(diskPrefab, Vector3.zero, Quaternion.identity);  
            newDisk.AddComponent<DiskData>();  
        }  
            
        int start = 0;  
        if (rou == 1) start = 100;  
        if (rou == 2) start = 250;  
        int selectedColor = Random.Range(start, rou * 499);  
  
        if (selectedColor > 500)  
        {  
            rou = 2;  
        }  
        else if (selectedColor > 300)  
        {  
            rou = 1;  
        }  
        else  
        {  
            rou = 0;  
        }   
            
        switch (rou)  
        {  
             
            case 0:  
                {  
                    newDisk.GetComponent<DiskData>().color = Color.yellow;  
                    newDisk.GetComponent<DiskData>().speed = 4.0f;  
                    float RanX = UnityEngine.Random.Range(-1f, 1f) < 0 ? -1 : 1;  
                    newDisk.GetComponent<DiskData>().direction = new Vector3(RanX, 1, 0);  
                    newDisk.GetComponent<Renderer>().material.color = Color.yellow;  
                    break;  
                }  
            case 1:  
                {  
                    newDisk.GetComponent<DiskData>().color = Color.red;  
                    newDisk.GetComponent<DiskData>().speed = 6.0f;  
                    float RanX = UnityEngine.Random.Range(-1f, 1f) < 0 ? -1 : 1;  
                    newDisk.GetComponent<DiskData>().direction = new Vector3(RanX, 1, 0);  
                    newDisk.GetComponent<Renderer>().material.color = Color.red;  
                    break;  
                }  
            case 2:  
                {  
                    newDisk.GetComponent<DiskData>().color = Color.black;  
                    newDisk.GetComponent<DiskData>().speed = 8.0f;  
                    float RanX = UnityEngine.Random.Range(-1f, 1f) < 0 ? -1 : 1;  
                    newDisk.GetComponent<DiskData>().direction = new Vector3(RanX, 1, 0);  
                    newDisk.GetComponent<Renderer>().material.color = Color.black;  
                    break;  
                }  
        }  
  
        used.Add(newDisk.GetComponent<DiskData>());    
        newDisk.name = newDisk.GetInstanceID().ToString();  
        return newDisk;  
    }  
  
    public void FreeDisk(GameObject disk)  
    {  
        DiskData abc = null;  
        foreach (DiskData i in used)  
        {  
            if (disk.GetInstanceID() == i.gameObject.GetInstanceID())  
            {  
                abc = i;  
            }  
        }  
        if (abc != null) {  
            abc.gameObject.SetActive(false);  
            free.Add(abc);  
            used.Remove(abc);  
        }  
    }  
    
}  
