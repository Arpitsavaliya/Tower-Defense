using System;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager2 : MonoBehaviour
{
    public static BuildManager2 instance;
    private GameObject turretToBuild;

    [Header ("Turret Data (Arrays share order)")]
    [SerializeField]
    private List<GameObject> turrets;
    [SerializeField]
    private List<int> turretCosts;

    private int turretCost;
    public bool isBuildingAllowed;//added this so building turrets will start on click from shop

    private void Start()
    {
        turretToBuild = turrets[0];
    }

    private void Awake()
    {
        if (instance != null)
        {
            Debug.Log("Theres more than one instance!");
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
        if (turretNum < Mathf.Min(turrets.Count, turretCosts.Count))
        {
            turretToBuild = turrets[turretNum];
            turretCost = turretCosts[turretNum];
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
