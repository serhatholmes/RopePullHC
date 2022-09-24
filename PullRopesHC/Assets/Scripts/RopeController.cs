using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RopeController : MonoBehaviour
{
    public static RopeController Instance { get; private set;}

    public int value {get; set;}

    private void Awake() {
        
        Instance = this;
    }

    private void Update() {
        
        Debug.Log("value"+ value);
    }
}
