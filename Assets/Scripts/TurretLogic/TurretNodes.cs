
using System;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class TurretNodes : MonoBehaviour
{
    public static TurretNodes instance;
    public Vector3 posOffset;

    private GameObject Turret;
    PlayerStats playerStats;

    /*[SerializeField]
    private GameObject TurretPlayer;*/

    private void Start()
    {
        playerStats = GameObject.FindGameObjectWithTag("GameController").GetComponent<PlayerStats>();
        //startSprite = rend.sprite;
    }
    private void OnMouseEnter()
    {
        if (!BuildManager2.instance.isBuildingAllowed) return;
        if (Turret != null)
            return;
    }

    private void OnMouseExit()
    {
        if (!BuildManager2.instance.isBuildingAllowed) return;   
    }
    public GameObject getTurret()
    {
        return Turret;
    }
    private void OnMouseDown()
    {
        if (!BuildManager2.instance.isBuildingAllowed) return;    
        if (Turret != null)
        {
            Debug.Log("Cannot Build here - TODO: Display on Screen");
            return;
        }
        if (BuildManager2.instance.GetTurretCost() > PlayerStats.Money)
        {
            Debug.Log("Cannot Build - Not Enough Funds.");
            return;
        }
        //Deduct Money from PlayerStats
        playerStats.UpdateMoney(PlayerStats.Money - BuildManager2.instance.GetTurretCost());


        GameObject TurretToBuild = BuildManager2.instance.GetTurretToBuild();
        Turret = (GameObject)Instantiate(TurretToBuild, transform.position + posOffset, transform.rotation);
        BuildManager2.instance.isBuildingAllowed = false;

        resetAllNodes();
        OnMouseExit();

    }
    private void resetAllNodes()
    {
        GameObject[] TurretNodes = GameObject.FindGameObjectsWithTag("TurretNode");
        foreach (GameObject nodes in TurretNodes)
        {
            nodes.GetComponent<SpriteRenderer>().color = Color.white;
        }
    }

}
