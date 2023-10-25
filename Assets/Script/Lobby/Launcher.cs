using System.Collections;
using System.Collections.Generic;
using KQuantA.Network;
using TMPro;
using UnityEngine;

namespace KQuantA.Game
{
    public class Launcher : MonoBehaviour
    {   
        [SerializeField] private TextMeshProUGUI nameInputField;

        private NetworkManager NetworkManager => NetworkManager.Instance;

        public void Connect()
        {
            Debug.Log("Connect was call");
            this.NetworkManager.SetNickname(this.nameInputField.text);
            this.NetworkManager.RequestConnect();
        }
    }
}