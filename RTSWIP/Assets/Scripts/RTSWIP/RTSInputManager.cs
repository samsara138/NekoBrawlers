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

    void Update()
    {
        // Check for mouse click
        if (Input.GetMouseButtonDown(0))
        {
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
                        selectedUnit.navMeshAgent.SetDestination(hit.point);
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
