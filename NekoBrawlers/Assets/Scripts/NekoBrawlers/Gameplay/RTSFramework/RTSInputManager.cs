using Core.Pattern;
using RTSFramework.Interactables;
using RTSFramework.Interactables.Units;
using RTSFramework.UI;
using UnityEngine;


namespace RTSFramework.InputSystem
{

    public class RTSInputManager : Singleton<RTSInputManager>
    {
        private RaycastHit hit;

        private RTSInteractable selectedInteractable = null;

        [SerializeField]
        private Camera gameCamera;

        private Camera HUDCamera;

        private void Start()
        {
            HUDCamera = GameObject.FindGameObjectWithTag("HUDCamera")?.GetComponent<Camera>();
        }

        void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                // First, if HUD is clicked, don't duplicate input to game
                if (!HandleHUDInput())
                {
                    HandleGameInput();
                }
            }
        }

        private bool HandleHUDInput()
        {
            if (HUDCamera)
            {
                Vector2 mousePos = HUDCamera.ScreenToWorldPoint(Input.mousePosition);
                RaycastHit2D hit = Physics2D.Raycast(mousePos, Vector2.zero);
                if (hit.collider != null)
                {
                    return true;
                }
            }
            return false;
        }

        private void HandleGameInput()
        {
            Ray ray = gameCamera.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
                RTSInteractable interable = hit.collider.gameObject.GetComponent<RTSInteractable>();
                if (interable)
                {
                    ClearSelection();
                    switch (interable.InteractableType)
                    {
                        case InteractableType.Unit:
                            selectedInteractable = interable;
                            selectedInteractable.OnSelect();
                            break;
                        case InteractableType.Buliding:
                            selectedInteractable = interable;
                            selectedInteractable.OnSelect();
                            break;

                    }
                }
                else
                {
                    if (selectedInteractable)
                    {
                        switch (selectedInteractable.InteractableType)
                        {
                            case InteractableType.None:
                                break;
                            case InteractableType.Unit:
                                selectedInteractable.RTSUnit.MoveToPoint(hit.point);
                                break;
                            case InteractableType.Buliding:
                                break;
                        }
                    }


                }
            }
            else
            {
                // Clear selection if the click was on empty space
                ClearSelection();
            }
        }

        private void ClearSelection()
        {
            RTSHUDManager.Instance.ClearSkills();
            if (selectedInteractable)
            {
                selectedInteractable.OnDeselect();
                selectedInteractable = null;
            }
        }
    }

}