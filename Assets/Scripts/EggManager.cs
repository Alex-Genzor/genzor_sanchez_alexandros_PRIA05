using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.Netcode;
using UnityEngine;

public class EggManager : NetworkBehaviour
{
    [Header(" Elements ")]
    [SerializeField] private Egg eggPrefab;
    
    void Start()
    {
        GameStateManager.OnGameStateChanged += GameStateChangedCallback;

    }
    
    void Update()
    {
        
        
    }

    private void GameStateChangedCallback(GameStateManager.State gameState)
    {
        switch (gameState)
        {
            case GameStateManager.State.Game:
                SpawnEgg();

                break;
            
        }
        
    }

    private void SpawnEgg()
    {
        if (!IsServer)
            return;
        
        Egg eggInstance = Instantiate(eggPrefab, Vector2.up * 5, 
            quaternion.identity);
        
        eggInstance.GetComponent<NetworkObject>().Spawn();

    }
    
    public override void OnDestroy()
    {
        base.OnDestroy();
        
    }
    
}
