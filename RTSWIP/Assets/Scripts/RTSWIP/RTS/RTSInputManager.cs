using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class RTSInputManager : MonoBehaviour
{
    private RaycastHit hit;

    private RTSUnit selectedUnit = null;

    [SerializeField]
    private Camera gameCamera;

    private Camera HUDCamera;

    private void Start()
    {
        HUDCamera = GameObject.FindGameObjectWithTag("HUDCamera")?.GetComponent<Camera>();
    }

    void Update()
    {
        // Check for mouse click
        if (Input.GetMouseButtonDown(0))
        {
            if (HUDCamera)
            {
                Ray HUDRay = HUDCamera.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(HUDRay, out hit))
                {
                    return;
                }
            }

            Ray ray = gameCamera.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
                // Check if the object clicked has a selectable component (you can create your own)
                RTSUnit clickedUnit = hit.collider.GetComponent<RTSUnit>();

                if (clickedUnit)
                {
                    selectedUnit = clickedUnit;
                    Debug.Log(clickedUnit.gameObject.name);
                }
                else
                {
                    if (selectedUnit)
                    {
                        selectedUnit.MoveToPoint(hit.point);
                    }
                    else
                    {
                        ClearSelection();
                    }
                }
            }
            else
            {
                // Clear selection if the click was on empty space
                ClearSelection();
            }
        }
    }

    private void ClearSelection()
    {
        selectedUnit = null;
    }
}
