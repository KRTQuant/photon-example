using System.Collections;
using System.Collections.Generic;
using ExitGames.Client.Photon;
using ExitGames.Client.Photon.StructWrapping;
using KQuantA.Network;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine;

public class PlayerManager : MonoSingleton<PlayerManager>
{
    [SerializeField] private GameObject playerPrefab;

    public void SpawnInstance()
    {
        Debug.Log("Spawn Instance was called");
        GameObject instance = Instantiate(this.playerPrefab);
        PhotonView photonView = instance.GetComponent<PhotonView>();

        if(PhotonNetwork.AllocateViewID(photonView))
        {
            object[] data = new object[]
            {
                instance.transform.position, instance.transform.rotation, photonView.ViewID
            };

            RaiseEventOptions eventConfigs = new RaiseEventOptions
            {
                Receivers = ReceiverGroup.Others,
                CachingOption = EventCaching.AddToRoomCache
            };

            SendOptions optionConfigs = new SendOptions
            {
                Reliability = true
            };

            PhotonNetwork.RaiseEvent(NetworkEvent.SpawnInstance, data, eventConfigs, optionConfigs);
        }
    } 
}
