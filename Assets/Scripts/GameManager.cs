using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager i { get; private set; }
    public GameObject[] rooms;
    public int currentRoom = -1;
    private GameObject currRoomInstantce;

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
        SpawnRoom(i.currentRoom);
    }

    private void SpawnRoom(int RoomNum)
    {
        currRoomInstantce = Instantiate(rooms[RoomNum]);
        currRoomInstantce.transform.position = Vector3.zero;
    }

    public void ResetRoom()
    {
        Destroy(currRoomInstantce);
        SpawnRoom(currentRoom);
    }

    public void SpawnNextRoom()
    {
        currentRoom += 1;
        currentRoom %= rooms.Length;
        SpawnRoom(currentRoom);
    }


}
