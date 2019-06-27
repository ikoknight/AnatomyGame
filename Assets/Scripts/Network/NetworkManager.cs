using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NetworkManager : MonoBehaviour
{

    public List<GameObject> listaPlayers;

    const string VERSION = "v0.0.1";
    public string roomName = "OASIS";

    public string playerPrefabName = "Player";


    public Transform spawnPoint;

    void Start()
    {
        PhotonNetwork.ConnectUsingSettings(VERSION);


    }
    void OnJoinedLobby()
    {
        RoomOptions roomOptions = new RoomOptions() { IsVisible = false, MaxPlayers = 5 };
        PhotonNetwork.JoinOrCreateRoom(roomName, roomOptions, TypedLobby.Default);
    }

    void OnJoinedRoom()
    {
        listaPlayers.Add(PhotonNetwork.Instantiate(playerPrefabName, spawnPoint.transform.position, spawnPoint.rotation,0));
    }
}
