using UnityEngine;
using UnityEngine.SceneManagement;

public class FlatformDoor : ObjectInteract
{
    public override void Interact()
    {
        base.Interact();
        SceneManager.LoadScene("TerrainMoveTest");
    }
}
