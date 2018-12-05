using Photon.Pun;
using Photon.Realtime;
using UnityEngine;
using UnityEngine.Serialization;

public class NetworkManager : MonoBehaviour {

    [FormerlySerializedAs("PlayerPrefab")] [SerializeField] private GameObject _playerPrefab;
    [FormerlySerializedAs("SpawnPoint")] [SerializeField] private GameObject _spawnPoint;

    private void Start () 
    {
        PhotonNetwork.ConnectUsingSettings();
    }

    private void OnJoinedLobby()
    {
        var myRoomOptions = new RoomOptions {MaxPlayers = 4};
        //PhotonNetwork.playerName = "Player" + Random.Range(1, 500);
        PhotonNetwork.JoinOrCreateRoom("The Game", myRoomOptions, TypedLobby.Default);
    }

    private void OnJoinedRoom()
    {
        PhotonNetwork.Instantiate(_playerPrefab.name, _spawnPoint.transform.position, Quaternion.identity, 0);
    }
}
