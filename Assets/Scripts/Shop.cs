
using UnityEngine;

public class Shop : MonoBehaviour
{

    public TurretStats.TurretBluePrint standardTurret;
    public TurretStats.TurretBluePrint missileLauncher;

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





