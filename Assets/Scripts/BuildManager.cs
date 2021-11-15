using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{

    #region Singleton
    public static BuildManager instance;
    private void Awake()
    {
        if(instance != null)
        {
            Debug.LogError("Il y a déja un BuildManager");
            return;
        }
        instance = this;
    }
    #endregion

    public GameObject standardTurretPrefab;

    public GameObject MissileLauncherPrefab;

    public GameObject BuildEffect;

    private static TurretStats.TurretBluePrint turretToBuild;

    public bool canBuild { get { return turretToBuild != null; } }
    public bool hasMoney { get { return PlayerStats.money >= turretToBuild.cost; } }

    public void SelectTurretToBuild(TurretStats.TurretBluePrint turret)
    {
        turretToBuild = turret;
    }

    public void BuildTurretOn(Node node)
    {
        if(PlayerStats.money < turretToBuild.cost)
        {
            Debug.Log("Tu n'as pas assez d'argent pour effectuer cette action !");
            return;
        }

        PlayerStats.money -= turretToBuild.cost;
        GameObject turret = (GameObject)Instantiate(turretToBuild.prefab, node.transform.position + node.positionOffset, Quaternion.identity);
        node.turret = turret;
        Renderer rend = node.getRend();
        rend.material.color = node.ErrorColor;
        GameObject effect = (GameObject)Instantiate(BuildEffect, node.transform.position + node.positionOffset, Quaternion.identity);
        Destroy(effect, 1f);

    }

}
