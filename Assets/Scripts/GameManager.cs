using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager i { get; private set; }
    public GameObject normalRoom;
    public GameObject randomRoom;
    private GameObject currRoomInstantce;
    public bool isTestingRandom = true;
    public Material[] skyboxes;

    private void Awake()
    {
        if (i != null && i != this)
        {
            Destroy(this);
        }
        else
        {
            i = this;
        }
    }

    private void Start()
    {
        if (!isTestingRandom)
        {
            SpawnRoom(normalRoom);
        }
        
    }

    private void SpawnRoom(GameObject room)
    {
        currRoomInstantce = Instantiate(room);
        currRoomInstantce.transform.position = Vector3.zero;
    }

    public void ResetRoom()
    {
        Destroy(currRoomInstantce);
        SpawnRoom(normalRoom);
    }

    public void Randomize()
    {
        RenderSettings.skybox = skyboxes[Random.Range(0, skyboxes.Length)];
        Destroy(currRoomInstantce);
        SpawnRoom(randomRoom);
    }


}
