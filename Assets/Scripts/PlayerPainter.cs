using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;

public class PlayerPainter : NetworkBehaviour
{
    [Header(" Elements ")] 
    [SerializeField] private SpriteRenderer[] spriteRender;
    
    void Start()
    {
        
        
    }
    
    void Update()
    {
        
        
    }

    public override void OnNetworkSpawn()
    {
        base.OnNetworkSpawn();

        if (!IsServer && IsOwner)
            ColorizeServerRpc(Color.red);

    }

    [ServerRpc]
    private void ColorizeServerRpc(Color colour)
    {
        ColorizeClientRpc(colour);
        
    }

    [ClientRpc]
    private void ColorizeClientRpc(Color colour)
    {
        foreach (SpriteRenderer sprite in spriteRender)
            sprite.color = colour;
        
    }
    
}
