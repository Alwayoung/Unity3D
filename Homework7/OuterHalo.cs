using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OuterHalo : MonoBehaviour {

    public ParticleSystem particleSystem;
    private ParticleSystem.Particle[] particleArr;
    private int haloResolution = 3000;
    private float minRadiuss = 2F;
    private float maxRadiuss = 4.5F;
    private HaloParticle[] haloParticlee;

    void Start () {
        particleSystem = this.GetComponent<ParticleSystem> ();
        particleArr = new ParticleSystem.Particle[haloResolution];
        haloParticlee = new HaloParticle[haloResolution];
        particleSystem.maxParticles = haloResolution;
        particleSystem.Emit (haloResolution);
        particleSystem.GetParticles (particleArr);
        for (int i = 0; i < haloResolution; i++) {
            float deltaMinRadius = Random.Range (1, ((minRadiuss+maxRadiuss)/2)/minRadiuss);
            float deltaMaxRadius = Random.Range (((minRadiuss+maxRadiuss)/2)/maxRadiuss, 1);
            float radius = Random.Range (minRadiuss * deltaMinRadius, maxRadiuss * deltaMaxRadius);

            float angle = Random.Range(0, Mathf.PI * 2);

            haloParticlee [i] = new HaloParticle (radius, angle);
            particleArr [i].position = new Vector3 (radius * Mathf.Cos(angle), radius * Mathf.Sin(angle), 0);
        }
        particleSystem.SetParticles (particleArr, particleArr.Length);
    }

    void Update () {
        for (int i = 0; i < haloResolution; i++) {
            haloParticlee [i].angle -= Random.Range (0, 1F/360);
            particleArr [i].position = new Vector3 (haloParticlee[i].radius * Mathf.Cos(haloParticlee[i].angle), haloParticlee[i].radius * Mathf.Sin(haloParticle[i].angle), 0);
        }
        particleSystem.SetParticles (particleArr, particleArr.Length);
    }
}
