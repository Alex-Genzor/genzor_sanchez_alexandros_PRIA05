using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using System;
using UnityEditor;
using UnityEngine;

public class GameStateManager : NetworkBehaviour
{
    public static GameStateManager Instance;
    
    public enum State {Menu, Game, Win, Lose}
    [SerializeField]
    private State _gameState;

    private int _connectedPlayers;
    
    [Header(" Events ")]
    public static Action<State> OnGameStateChanged;
    
    void Start()
    {
        _gameState = State.Menu;
        
    }
    
    void Update()
    {
        
        
    }

    // ---------------------
    
    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);

    }

    public override void OnNetworkSpawn()
    {
        base.OnNetworkSpawn();
        NetworkManager.OnServerStarted += NetworkManagerOnServerStarted;

    }

    private void NetworkManagerOnServerStarted()
    {
        if (!IsServer)
            return;

        _connectedPlayers++;

        NetworkManager.Singleton.OnClientConnectedCallback += 
            SingletonOnClientConnectedCallback;

    }

    private void SingletonOnClientConnectedCallback(ulong obj)
    {
        _connectedPlayers++;
        
        if (_connectedPlayers >= 2)
            StartGame();

    }
    
    private void StartGame() 
    {
        StartGameClientRpc();
        
    }

    [ClientRpc]
    private void StartGameClientRpc()
    {
        _gameState = State.Game;
        OnGameStateChanged?.Invoke(_gameState);

    }

    public override void OnDestroy()
    {
        base.OnDestroy();
        
        NetworkManager.OnServerStarted -= NetworkManagerOnServerStarted;
        NetworkManager.Singleton.OnClientConnectedCallback -= 
            SingletonOnClientConnectedCallback;
        
    }
    
}
