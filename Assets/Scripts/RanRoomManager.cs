using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RanRoomManager : MonoBehaviour
{
    public int unitCount = 8;
    public int randMargin = 2;
    public GameObject unitDesk;
    public float SpawnHeight = 0.2f;
    void Start()
    {
        StartCoroutine(SpawnUnits(Random.Range(unitCount - randMargin, unitCount + randMargin+1)));
    }
    private IEnumerator SpawnUnits(int num)
    {
        for(int i = 0; i < num; i++)
        { 
            float randx = Random.Range(16.0f, 26.0f);
            float randz = Random.Range(-10.0f, 10.0f);
            GameObject desk = Instantiate(unitDesk);
            desk.transform.position = new Vector3(randx, SpawnHeight, randz);
            desk.transform.parent = gameObject.transform;
            yield return new WaitForSeconds(0.5f);
        }
    }

   
}
