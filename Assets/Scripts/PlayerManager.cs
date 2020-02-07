using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerManager : MonoBehaviour
{
    [SerializeField] Transformer clone;
    [SerializeField] Transformer player;
    [SerializeField] SpriteRenderer jojoUI;
    [SerializeField] SpriteRenderer spUI;
    [SerializeField] CheckPointSystem checkPoint;
    bool controllingClone = true;
    GameManager manager;


    private void Awake()
    {
        manager = GetComponent<GameManager>();
        clone.onAction += OnCloneExplodedOrHit;
        player.onAction += OnCloned;
        clone.onDown += TeleportPlayereAtClone;
    }

    public void StartGame()
    {
        OnCloneExplodedOrHit();
        player.transform.position = checkPoint.GetPosition();
    }

    void OnCloned()
    {
        if (controllingClone)
            return;


        clone.Activate(player.transform.position + Vector3.left*2);
        player.Disable();
        controllingClone = true;
        jojoUI.enabled = false;
        spUI.enabled = true;
    }

    public void OnCloneExplodedOrHit()
    {
        if (!controllingClone)
            return;

        player.Activate(player.transform.position);
        clone.Disable();
        clone.gameObject.SetActive(false);
        controllingClone = false;
        jojoUI.enabled = true;
        spUI.enabled = false;
    }
    public void OnPlayerDead()
    {
        if (controllingClone)
            OnCloneExplodedOrHit();
        player.Disable();
        player.gameObject.SetActive(false);
        manager.GameOver();
    }

    public void DisableControls()
    {
        player.Disable();
        clone.Disable();
    }
    public void EnableControls()
    {
        if (controllingClone)
            clone.Enable();
        else
            player.Enable();
    }

    public void EnableTeleportaion()
    {
        checkPoint.canTeleport = true;
    }

    public void TeleportPlayereAtClone()
    {
        if (checkPoint.canTeleport)
        {
            player.transform.position = clone.transform.position;
            OnCloneExplodedOrHit();
        }
    }
}
