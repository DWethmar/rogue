using UnityEngine;
using System.Collections;

class MouseModify : MonoBehaviour
{
    public Camera camera;

    public void start()
    {
        Debug.Log("Ok");
    }

    public void update()
    {
        //
        RaycastHit hit;
        Ray ray = camera.ScreenPointToRay(Input.mousePosition);

        if (Input.GetMouseButtonUp(1) && Physics.Raycast(ray, out hit))
        {
            Transform objectHit = hit.transform;
            EditTerrain.SetBlock(hit, new BlockAir());
            Debug.Log("hit");
        }
        else
        {
            Debug.Log("no hit");
        }
        //
    }
}