using ExitGames.Client.Photon;
using Photon.Pun;
using UnityEngine;
using Photon.Realtime;
using Unity.VisualScripting;

namespace KQuantA.Network
{
    public class NetworkService : MonoPCBSingleton<NetworkService>
    {
        #region Action
        public void RequestConnect()
        {
            PhotonNetwork.ConnectUsingSettings();
        }

        public void CreateRoom()
        {
            PhotonNetwork.CreateRoom(null);
        }

        public void JoinRandomRoom()
        {
            PhotonNetwork.JoinRandomRoom();
        }

        public void LoadScene(string sceneName)
        {
            PhotonNetwork.LoadLevel(sceneName);
        }

        public void SetNickName(string nickname)
        {
            PhotonNetwork.NickName = nickname;
        }
        #endregion
    }
}