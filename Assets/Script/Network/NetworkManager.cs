using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Unity.VisualScripting;
using Photon.Realtime;
using ExitGames.Client.Photon;

namespace KQuantA.Network
{
    public class NetworkManager : MonoPCBSingleton<NetworkManager>, IOnEventCallback, IConnectionCallbacks, ILobbyCallbacks, IInRoomCallbacks
    {
        private NetworkService NetworkService => NetworkService.Instance;
        private PlayerManager PlayerManager => PlayerManager.Instance;

        protected override void Awake()
        {
            base.Awake();
            PhotonNetwork.AutomaticallySyncScene = true;
            PhotonNetwork.AddCallbackTarget(this);
        }

        protected void OnDestroy()
        {
            PhotonNetwork.RemoveCallbackTarget(this);
        }

        public void RequestConnect()
        {
            if (PhotonNetwork.IsConnected)
            {
                this.NetworkService.JoinRandomRoom();
                return;
            }
        
            this.NetworkService.RequestConnect();
            this.NetworkService.LoadScene("Game");
        }

        public void SetNickname(string nickname)
        {
            this.NetworkService.SetNickName(nickname);
        }

        #region Callback Handler
        public void OnEvent(EventData photonEvent)
        {
            
        }

        public override void OnConnectedToMaster()
        {
            base.OnConnectedToMaster();
            Debug.Log("Connected to master server");
            this.NetworkService.JoinRandomRoom();
        }

        public override void OnJoinedRoom()
        {
            base.OnJoinedRoom();
            Debug.Log("Join room successful");
            this.PlayerManager.SpawnInstance();
        }

        public override void OnCreatedRoom()
        {
            base.OnCreatedRoom();
            Debug.Log("Create room succeed");
            this.PlayerManager.SpawnInstance();
        }

        public override void OnJoinRoomFailed(short returnCode, string message)
        {
            Debug.Log("Failed to join random room");
            base.OnJoinRoomFailed(returnCode, message);

            this.NetworkService.CreateRoom();
        }
        #endregion
    }
}