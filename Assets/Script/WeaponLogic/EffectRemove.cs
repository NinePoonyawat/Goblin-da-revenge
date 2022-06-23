using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectRemove : MonoBehaviour
{ 
    public float lifetimeDuration;
    private float lifetime;

    void Start() {    
        
        lifetime = Time.time + lifetimeDuration;
    }

    void Update() {
        if (Time.time >= lifetime) Destroy(gameObject);
    }
}
