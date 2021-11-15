
using UnityEngine;
using UnityEngine.EventSystems;
public class Node : MonoBehaviour
{

    public Vector3 positionOffset;

    public GameObject turret;
    public Color hoverColor;
    private Color startColor;
    public Color ErrorColor;
    private Renderer rend;

    private BuildManager buildManager;

    private void Start()
    {
        buildManager = BuildManager.instance;
        rend = GetComponent<Renderer>();
        startColor = rend.material.color;
    }


    private void OnMouseDown()
    {
        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }

        if (!buildManager.canBuild)
        {
            return;
        }

        if(turret != null)
        {
            print("Il y a déja une tourelle");
            return;
        }
        buildManager.BuildTurretOn(this);

    }

    private void OnMouseEnter()
    {
        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }

        if (!buildManager.canBuild)
        {
            return;
        }


        if (buildManager.hasMoney && turret == null)
        {
            rend.material.color = hoverColor;
        }
        else
        {
            rend.material.color = ErrorColor;
        }
    }
    private void OnMouseExit()
    {
        rend.material.color = startColor;
    }

    public Renderer getRend()
    {
        return rend;
    }

}
