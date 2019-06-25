using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class adjustPosition : MonoBehaviour
{
    public Tilemap tilemap;
    // Start is called before the first frame update
    void Start()
    {
        Vector3 position = transform.position;
        Vector3Int cell = tilemap.WorldToCell(position);
        Vector3 cellCenter = tilemap.GetCellCenterWorld(cell);
        cellCenter.y -= 1f;
        transform.position = cellCenter;
    }

}
