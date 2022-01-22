using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeskManager : MonoBehaviour
{
    public GameObject[] tableTopStuff;
    public int numOfItems = 4;
    public int randMargin = 2;
    void Start()
    {
        transform.Rotate(0, Random.Range(0,350), 0, Space.Self);
        StartCoroutine(SpawnUnits(Random.Range(numOfItems - randMargin, numOfItems + randMargin + 1)));
    }
    private IEnumerator SpawnUnits(int num)
    {
        yield return new WaitForSeconds(2f);
        for (int i = 0; i < num; i++)
        {
            float randx = Random.Range(-0.6f, 0.6f);
            float randz = Random.Range(-0.3f, 0.3f);
            GameObject item = Instantiate(tableTopStuff[Random.Range(0,tableTopStuff.Length)]);
            item.transform.parent = gameObject.transform;
            item.transform.localPosition = new Vector3(randx, 1, randz);
            item.transform.Rotate(0, Random.Range(0, 350), 0, Space.Self);
            yield return new WaitForSeconds(0.3f);
        }
    }

}
