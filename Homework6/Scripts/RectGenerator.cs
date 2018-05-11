using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RectGenerator : MonoBehaviour {

    public float PositionRange = 20.0f;
    public float defaultSideLength = 5.0f;
    public float yPosition = 1.0f;

    public List<Vector3> GetRandomRect(int sidees = 4, float SideLen = 0) {
        List<Vector3> ret = new List<Vector3> ();

        if (SideLen == 0) {
            SideLen = defaultSideLength;
        }
        SideLen = Random.Range(10f, 20f);
        Vector3 leftDown = new Vector3 (Random.Range(-PositionRange, PositionRange), yPosition, Random.Range(-PositionRange, PositionRange));
        Vector3 rightDown = leftDown + Vector3.right * SideLen;
        Vector3 leftUp = leftDown + Vector3.forward * SideLen;
        Vector3 rightUp = rightDown + Vector3.forward * SideLen;

        Vector3 tmpp = leftDown + Vector3.forward * SideLen * Random.Range(0f, 1f);
        ret.Add(tmpp);
        tmpp = leftUp + Vector3.right * SideLen * Random.Range(0f, 1f);
        ret.Add(tmpp);
        tmpp = rightUp + Vector3.forward * (-SideLen) * Random.Range(0f, 1f);
        ret.Add(tmpp);

        if (sidees >= 4) {
            tmpp = rightDown + Vector3.right * (-SideLen) * Random.Range(0f, 0.5f);
            ret.Add(tmpp);
            if (sidees == 5) {
                tmpp = rightDown + Vector3.right * (-SideLen) * Random.Range(0.5f, 1f);
                ret.Add(tmpp);
            }
        }
        
        return ret;
    }
    
}
