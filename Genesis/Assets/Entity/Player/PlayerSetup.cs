using Mirror;
using UnityEngine;

public class PlayerSetup : NetworkBehaviour
{
    public Behaviour[] componentsToDisable;

    private void Start()
    {
        if (!isLocalPlayer)
        {
            foreach (var component in componentsToDisable)
            {
                component.enabled = false;
            }
        }
    }
}
