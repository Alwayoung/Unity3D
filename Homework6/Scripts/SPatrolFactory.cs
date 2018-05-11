using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class SPatrolFactory : MonoBehaviour {
    public RectGenerator rectGene;
    private List<GameObject> use;
    private List<GameObject> fre;
    int PatrolCount = 0;

    [Header("Patrol Prefab")]
    public GameObject PatrolPrefab;

    void Start() {
        rectGene = Singleton<RectGenerator>.Instance;

        use = new List<GameObject> ();
        fre = new List<GameObject> ();
    }

    public void GenPatrol(int number) {
        for (int i = 0; i < number; i++) {
            SPatrolData tmpSpData = ScriptableObject.CreateInstance<SPatrolData>();
            tmpSpData.speed = Random.Range(5f, 15f);
            tmpSpData.RectPoints = rectGene.GetRandomRect();

            GameObject tmpPatrol = null;
            if (fre.Count > 0) {
                Debug.Log("Regenerate from Free");
                tmpPatrol = fre.ToArray () [fre.Count - 1];
                fre.RemoveAt(fre.Count - 1);
            } else {
                Debug.Log("Generate new GameObject");
                PatrolCount++;
                tmpPatrol = Instantiate (PatrolPrefab) as GameObject;
                tmpPatrol.name = "Patrol" + PatrolCount.ToString();
            }
            tmpPatrol.GetComponent<SPatrol>().SetFromData(tmpSpData).ClearCallbacks().InitColor().InitPosition().StartPatrol();

            var spw = tmpPatrol.GetComponent<SPatrol>();
            spw.OnCollisionPlayer += GameEvents.CollidePlayer;
            spw.OnDiscoverPlayer += GameEvents.StartChasing;
            spw.OnLeavePlayer += GameEvents.LeavePlayer;

            use.Add(tmpPatrol);
        }
    }

    public void ReleaseAllPatrols() {
        Debug.Log("Release All");
        for (int i = use.Count - 1; i >= 0; i--) {
            GameObject obje = use[i];
            obje.GetComponent<SPatrol>().InitColor().InitPosition().isEnabled = false;
            free.Add(obje);
            use.RemoveAt(i);
        }
    }
}

public class Singleton<T> : MonoBehaviour where T : MonoBehaviour {
    protected static T instance;

    public static T Instance {
        get {
            if (instance == null) {
                instance = (T) FindObjectOfType (typeof (T));
                if (instance == null) {
                    Debug.LogError ("An instance of " + typeof(T) + " is needed in the scene, but there is none.");
                }
            }
            return instance;
        }
    }
}
