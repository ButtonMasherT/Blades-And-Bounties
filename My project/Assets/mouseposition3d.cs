using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mouseposition3d : MonoBehaviour
{
    [SerializeField] private Camera mainCamera;
    [SerializeField] private LayerMask layerMask;
  
    private void Update()
    {
        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
        if (!Physics.Raycast(ray, out RaycastHit raycastHit, float.MaxValue, layerMask))
        {
            return;
        }
        transform.position = raycastHit.point;

    }
}
