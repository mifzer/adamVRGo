using UnityEngine;

public class Shop : MonoBehaviour {

    public TurretBlueprint standardTurret;
    public TurretBlueprint missileLauncher;
    public static Shop shopInstance = null;
    BuildManager buildManager;

    private void Awake()
    {
        if (shopInstance == null)
            shopInstance = this;
    }
   

    void Start ()
    {
        buildManager = BuildManager.instance;
        SelectStandardTurret();
    }

    public void SelectStandardTurret()
    {
        Debug.Log("Standard Turret Selected");
        buildManager.SelectTurretToBuild(standardTurret);
    }

    public void SelectMissileLauncher()
    {
        Debug.Log("Missile Launcher selected");
        buildManager.SelectTurretToBuild(missileLauncher);
    }
		
}
