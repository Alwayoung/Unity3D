using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SPatrol : MonoBehaviour {
    public bool isEnabled = false;
    public float speedd = 1.0f;

    public bool hasBeenEscapedFrom = false;

    public int currPointNo;
    private Vector3 nextTarget; 
    public List<Vector3> RectPoints; 

    public bool hasDiscoverAPlayer = false;
    public Transform chasingPlayer;

    public Action<SPatrol, Transform> OnDiscoverPlayer;

    public Action<SPatrol> OnCollisionPlayer;

    public Action<SPatrol> OnLeavePlayer;

    public SPatrol SetFromData(SPatrolData spa) {
        this.RectPoints = spa.RectPoints;
        this.speedd = spa.speedd;
        this.hasBeenEscapedFrom = false;
        return this;
    }


    public SPatrol StartPatrol() {
        hasDiscoverAPlayer = false;
        chasingPlayer = null;
        nextTarget = RectPoints[currPointNo];
        isEnabled = true;
        return this;
    }

    public SPatrol InitPosition() {
        transform.position = RectPoints[0];
        return this;
    }

    public SPatrol ClearCallbacks() {
        OnCollisionPlayer = null;
        OnLeavePlayer = null;
        OnDiscoverPlayer = null;
        return this;
    }

    public SPatrol InitColor() {
        Renderer render = GetComponent<Renderer>();
        render.material.shader = Shader.Find("Transparent/Diffuse");
        render.material.color = Color.red;

        return this;
    }

    public SPatrol SetEscapedColor() {
        Renderer render = GetComponent<Renderer>();
        render.material.shader = Shader.Find("Transparent/Diffuse");
        render.material.color = Color.green;

        return this;
    }

    public void ChangeDirection() {
        if (++currPointNo == RectPoints.Count)
            currPointNo -= RectPoints.Count;
        nextTarget = RectPoints[currPointNo];
    }


    void Start () {
        isEnabled = true;
        currPointNo = 0;
    }

    void Update () {
        if (isEnabled) {
            float step = speedd * Time.deltaTime;
            Vector3 tmpTarget = hasDiscoverAPlayer ? chasingPlayer.position : nextTarget;
            transform.localPosition = Vector3.MoveTowards(transform.position, tmpTarget, step);
            
            if (hasDiscoverAPlayer == false) {
                if (Vector3.Distance(transform.position, nextTarget) < 0.5f) {
                    ChangeDirection();
                }
            }
        }
    }

    void OnCollisionEnter(Collision other) {
        if (other.gameObject.tag.Contains("Player")) {
            if (OnCollisionPlayer != null)
                OnCollisionPlayer(this);
        } else {
            nextTarget = RectPoints[++currPointNo];
        }
    }

    void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag.Contains("Player")) {
            if (OnDiscoverPlayer != null)
                OnDiscoverPlayer(this, other.transform);
        } 
    }

    void OnTriggerExit(Collider other) {
        if (other.gameObject.tag.Contains("Player")) {
            if (OnLeavePlayer != null)
                OnLeavePlayer(this);
        }
    }
}
