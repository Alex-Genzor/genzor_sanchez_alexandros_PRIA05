using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [Header(" Panels" )]
    [SerializeField] private GameObject connectionPanel;
    [SerializeField] private GameObject waitingPanel;
    [SerializeField] private GameObject gamePanel;
    
    // Start is called before the first frame update
    void Start()
    {
        ShowConnectionPanel();
        
    }

    // Update is called once per frame
    void Update()
    {
        
        
    }

    private void ShowConnectionPanel()
    {
        connectionPanel.SetActive(true);
        waitingPanel.SetActive(false);
        gamePanel.SetActive(false);
        
    }

    private void ShowWaitingPanel()
    {
        connectionPanel.SetActive(false);
        waitingPanel.SetActive(true);
        gamePanel.SetActive(false);
        
    }

    private void ShowGamePanel()
    {
        connectionPanel.SetActive(false);
        waitingPanel.SetActive(false);
        gamePanel.SetActive(true);
        
    }

    public void HostBtnCallback()
    {
        NetworkManager.Singleton.StartHost();
        ShowWaitingPanel();

    }

    public void ClientBtnCallback()
    {
        NetworkManager.Singleton.StartClient();
        ShowGamePanel();
        
    }
    
}
