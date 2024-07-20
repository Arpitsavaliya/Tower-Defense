using System;
using UnityEngine;

public class BuildManager2 : MonoBehaviour
{
    public static BuildManager2 instance;
    private GameObject turretToBuild;
    public GameObject StandardTurretPrefab;
    public GameObject turret2;
    public GameObject turret3;
    public int turretCost1;
    public int turretCost2;
    public int turretCost3;
    private int turretCost;
    public Boolean isBuildingAllowed;//added this so building turrets will start on click from shop

    private void Start()
    {
        turretToBuild = StandardTurretPrefab;
    }

    private void Awake()
    {
        if (instance != null)
        {
            Debug.Log("Theres more than one instance then");
            return;
        }
        instance = this;
    }
    public GameObject GetTurretToBuild()
    {
        return turretToBuild;
    }
    public int GetTurretCost()
    {
        return turretCost;
    }


    public void setTurret(int turretNum)
    {
        Debug.Log("setTurret" + turretNum);
        
        if (turretNum == 1)
        {
            turretToBuild = StandardTurretPrefab;
            turretCost = turretCost1;
        }
        else if (turretNum == 2)
        {
            turretToBuild = turret2;
            turretCost = turretCost2;
        }
        else if (turretNum == 3)
        {
            turretToBuild = turret3;
            turretCost = turretCost3;
        }
        isBuildingAllowed = true;
        lightUpAvailableNode();
}

    private void lightUpAvailableNode()
    {
        GameObject[] TurretNodes = GameObject.FindGameObjectsWithTag("TurretNode");
        foreach (GameObject nodes in TurretNodes)
        {
            if(nodes.GetComponent<TurretNodes>().getTurret() != null) {
                nodes.GetComponent<SpriteRenderer>().color = Color.red;
            }
            else
            {
                nodes.GetComponent<SpriteRenderer>().color = Color.green;
            }
        }
    }
}
