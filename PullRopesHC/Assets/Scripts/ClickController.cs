using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ClickController : MonoBehaviour , IPointerDownHandler
{
    private int pullValue = 10;
    [SerializeField] private bool isAI;
    [SerializeField] private bool isBot;
    public void OnPointerDown(PointerEventData eventData){

        if(isAI) return;

        Debug.Log("click");

        Pull();
    }

    private void Pull(){

        RopeController.Instance.value += pullValue;
    }

    private void Start() {

        pullValue = GameManager.Instance.pullPower;
        if(isBot){
            pullValue *= -1;
        }
        
        if(isAI){

            StartCoroutine(AutoClick());
        }
    }

    IEnumerator AutoClick(){

        while(true){

            var data = GameManager.Instance.rangeDelayAI;
			var second = Random.Range(data.x, data.y);
            yield return new WaitForSeconds(second);
            Pull();
        }
    }
}
