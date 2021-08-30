using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    [SerializeField] private GameObject hunterTowerPrefab;
    [SerializeField] private bool empty = true;
    private Vector3 offSet = new Vector3(0,0.5f,0);
    [SerializeField] private GameObject curTower;

    private void OnMouseDown()
    {
        if (empty)
        {
            SpawnHunterTower();
        }
    }
    public void SpawnHunterTower()
    {
        curTower = GameObject.Instantiate(hunterTowerPrefab, transform.position + offSet, Quaternion.identity);
        empty = false;
    }
}
