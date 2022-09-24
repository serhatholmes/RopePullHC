using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ClickController : MonoBehaviour , IPointerDownHandler
{
    [SerializeField] private int pullValue = 10;
    public void OnPointerDown(PointerEventData eventData){

        Debug.Log("click");

        RopeController.Instance.value += pullValue;
    }
}
