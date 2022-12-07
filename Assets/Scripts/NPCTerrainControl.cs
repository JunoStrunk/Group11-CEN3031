using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCTerrainControl : MonoBehaviour
{
    public LayerMask terrainLayer;

    void Start()
    {
        // Calculate height of food so it's always a fixed amount above terrain
        float terrainPos;
        RaycastHit terrHit;

        // Set hit information for where raycast from object hits terrain
        Physics.Raycast(transform.position, Vector3.down, out terrHit, 2 + 10, terrainLayer);
        // Set hit position to terrainPos
        terrainPos = terrHit.point.y;

        transform.position = new Vector3(transform.position.x, terrainPos + 0.7f, transform.position.z);
    }
}
