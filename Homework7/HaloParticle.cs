using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HaloParticle {

    public HaloParticle(float rad = 0, float ang = 0) {
        radius = rad;
        angle = ang;
    }
    public float radius {
        get;
        set;
    }
    public float angle {
        get;
        set;
    }
}
