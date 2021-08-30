using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveEnemy : MonoBehaviour
{
    [SerializeField] private float speedEnemy;
    private SpawnEnemies spawnEnemies;
    [SerializeField] private Rigidbody rb;
    private int curWayPoint = 0;

    private Transform p0;
    private Transform p1;
    private Transform p2;
    private Transform p3;

    [Range(0, 1)]
    private float t;


    void Update()
    {
            rb.MovePosition(Vector3.MoveTowards(transform.position, Bezier.GetPoint(p0.position, p1.position, p2.position, p3.position, t), Time.deltaTime * speedEnemy));
            transform.rotation = Quaternion.LookRotation(Bezier.GetFirstDerivative(p0.position, p1.position, p2.position, p3.position, t));
            if (Vector3.Distance(transform.position, Bezier.GetPoint(p0.position, p1.position, p2.position, p3.position, t )) < 0.0005f)
            {
                t += 0.001f;
            }
        
    }
    public void SetSpawn(SpawnEnemies spawn)
    {
        spawnEnemies = spawn;
        p0 = spawnEnemies.p0;
        p1 = spawnEnemies.p1;
        p2 = spawnEnemies.p2;
        p3 = spawnEnemies.p3;
        
    }
    private void OnDrawGizmos()
    {
        int sigmentsNumber = 40;
        Vector3 preveosePoint = p0.position;
        for (int i = 0; i < sigmentsNumber + 1; i++)
        {
            float parameter = (float)i / sigmentsNumber;
            Vector3 point = Bezier.GetPoint(p0.position, p1.position, p2.position, p3.position, parameter);
            Gizmos.DrawLine(preveosePoint, point);
            preveosePoint = point;
        }
    }
}
