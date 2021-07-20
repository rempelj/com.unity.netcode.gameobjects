using System.Collections.Generic;
using MLAPI.Configuration;
using MLAPI.Messaging;
using MLAPI.SceneManagement;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace MLAPI.EditorTests
{
    public class NetworkManagerMessageSenderTests
    {
        [Test]
        public void MessageSenderAssigned()
        {
            var gameObject = new GameObject(nameof(MessageSenderAssigned));
            var networkManager = gameObject.AddComponent<NetworkManager>();
            var transport = gameObject.AddComponent<DummyTransport>();

            // Set dummy transport that does nothing
            networkManager.NetworkConfig.NetworkTransport = transport;

            InternalMessageSender preManager = networkManager.MessageSender;

            // Start server to cause init
            networkManager.StartServer();

            Debug.Assert(preManager == null);
            Debug.Assert(networkManager.MessageSender != null);

            Object.DestroyImmediate(gameObject);
        }
    }
}
