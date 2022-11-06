using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RopeController : MonoBehaviour
{
    public static RopeController Instance { get; private set;}

    public int value {get; set;}

    [SerializeField] private Transform topLine;
    [SerializeField] private Transform botLine;

    [SerializeField] private Vector2 minMaxValue;

    private Vector2 minMaxVerticalPosition;

    private void Awake() {
        
        Instance = this;
    }

    private void Start() {
        
        minMaxVerticalPosition = new Vector2(botLine.position.y, topLine.position.y);
    }

    private void FixedUpdate() {
        
        var position = transform.position;
        var normalize = Mathf.InverseLerp(minMaxValue.x,minMaxValue.y, value);
        var verticalPosition = Mathf.Lerp(minMaxVerticalPosition.x, minMaxVerticalPosition.y, normalize);
        position.y = verticalPosition;

        var currentVerticalPosition = Mathf.Lerp(transform.position.y, verticalPosition, .1f);
        transform.position = position;

        if(Mathf.Abs(Mathf.Abs(transform.position.y) - Mathf.Abs(minMaxVerticalPosition.y)) < 0.1f){

            Debug.Log("Game Finish");
			if (transform.position.y > 0)
				Debug.Log("Red Win");
			else
				Debug.Log("Blue Win");
			Time.timeScale = 0;
        }

    }
}
