using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Ground : MonoBehaviour {
    BuildingManager buildingManager;

    //Ground Color
    private Color startColor;
    public Color onColor;

    private Renderer rend;

    [Header("Optional")]
    public GameObject building;
    public Vector3 Offset;

    private void Start()
    {
        rend = GetComponent<Renderer>();
        startColor = rend.material.color;
        buildingManager = BuildingManager.instance;
    }

    public Vector3 GetBuildPosition()
    {
        return transform.position + Offset;
    }                        //Placement position

    private void OnMouseEnter()                                 //Ground will chage color when the mouse on the ground
    {
        GetComponent<Renderer>().material.color = onColor;      //change cube's color when the mouse on the cube

        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }

        if (!buildingManager.CanBuild)
        {
            return;
        }
    }

    private void OnMouseExit()
    {
        rend.material.color = startColor;
    }

    private void OnMouseDown()
    {
        if(building != null)
        {
            Debug.Log("The ground already placed a building!");
            return;
        }
        buildingManager.Build(this);

        if (!buildingManager.CanBuild)
        {
            return;
        }
    } 
}
