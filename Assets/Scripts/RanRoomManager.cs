using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RanRoomManager : MonoBehaviour
{
    public int unitCount = 8;
    public int randMargin = 2;
    public GameObject unitDesk;
    public float SpawnHeight = 0.2f;
    private List<Vector3> localList = new List<Vector3>();
    void Start()
    {
        StartCoroutine(SpawnUnits(Random.Range(unitCount - randMargin, unitCount + randMargin+1)));
    }
    private IEnumerator SpawnUnits(int num)
    {
        for(int i = 0; i < num; i++)
        {  
            GameObject desk = Instantiate(unitDesk);
            desk.transform.position = getNewLocaltion();
            desk.transform.parent = gameObject.transform;
            yield return new WaitForSeconds(0.3f);
        }
    }

    private Vector3 getNewLocaltion()
    {
        Vector3 newLocation = getRandLocaltion();
        while (isTooClose(newLocation))
        {
            newLocation = getRandLocaltion();
        }
        localList.Add(newLocation);
        return newLocation;
    }

    private Vector3 getRandLocaltion()
    {
        float randx = Random.Range(16.5f, 25.0f);
        float randz = Random.Range(-9.5f, 9.5f);
        return new Vector3(randx, SpawnHeight, randz);
    }

    private bool isTooClose(Vector3 newLocal)
    {
        foreach (Vector3 local in localList)
        {
            if (Vector3.Distance(local, newLocal) < 2f)
            {
                return true;
            }
        }
        return false;
    }
}
