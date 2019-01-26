﻿using System.Collections;           
using Lockstep.Client;                  
using Lockstep.Client.Interfaces;
using Lockstep.Commands;
using Lockstep.Core;             
using UnityEngine;           
                              
public class RTSNetworkedSimulation : MonoBehaviour
{      
    public static RTSNetworkedSimulation Instance;

    public string ServerIp = "127.0.0.1";
    public int ServerPort = 9050;

    public Simulation Simulation;
    public LockstepSystems Systems;
    public RTSEntityDatabase EntityDatabase;

    public bool Connected => _client.Connected; 

    private readonly LiteNetLibClient _client = new LiteNetLibClient();  

    private void Awake()
    {                                
        Instance = this;

        Systems = new LockstepSystems(Contexts.sharedInstance, new UnityGameService(EntityDatabase));

        Simulation = new Simulation(Systems, _client); 
        Simulation.RegisterCommand(() => new SpawnCommand());
        Simulation.RegisterCommand(() => new NavigateCommand());

        Simulation.Ticked += id =>
        {
            //_dataReceiver.Receive(MessageTag.HashCode, new HashCode {FrameNumber = id, Value = _systems.HashCode});
        };
    }


    public void Execute(ISerializableCommand command)
    {
        Simulation.Execute(command);
    }

    private void Start()
    {
        _client.Start();
        StartCoroutine(AutoConnect());
    }

    private void OnDestroy()
    {
        _client.Stop();   
    }


    void Update()
    {
        _client.Update();

        Simulation.Update(Time.deltaTime * 1000);
    }   

    void OnGUI()
    {
        if (Simulation.Running)
        {
            GUILayout.BeginVertical(GUILayout.Width(100f));
            GUI.color = Color.white;
            GUILayout.Label("HashCode: " + Contexts.sharedInstance.gameState.hashCode.value);
            GUILayout.EndVertical();
        }
    }

    public IEnumerator AutoConnect()
    {
        while (!Connected)
        {
            _client.Connect(ServerIp, ServerPort);
            yield return new WaitForSeconds(1);
        }

        yield return null;
    }
}
