
using UnityEngine;

public class Shop : MonoBehaviour
{

    public TurretStats.TurretBluePrint standardTurret;
    public TurretStats.TurretBluePrint missileLauncher;
    public TurretStats.TurretBluePrint laserTurret;

    private BuildManager buildManager;

    private void Start()
    {
        buildManager = BuildManager.instance;
    }

    public void SelectStandardTurret()
    {
        buildManager.SelectTurretToBuild(standardTurret);
    }

    public void SelectMissileLauncher()
    {
        buildManager.SelectTurretToBuild(missileLauncher);
    }

    public void SelectLaserTurret()
    {
        buildManager.SelectTurretToBuild(laserTurret);
    }

    

}

namespace TurretStats
{

    [System.Serializable]
    public class TurretBluePrint
    {
        public GameObject prefab;
        public int cost;
    }
}





