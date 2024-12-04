using UnityEngine;
using UnityEngine.Rendering;

public class CostumeChanger : MonoBehaviour
{



    Animator animator;

    int cloth, hat, hair = 0;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        Change();
        
    }
   

    public void Change()
    {
        print(1);
        cloth = Random.Range(1, 21);
        hat = Random.Range(1, 14);
        hair = Random.Range(1, 20);

        animator.SetInteger("Cloth", cloth);
        animator.SetInteger("Hat", hat);
        animator.SetInteger("Hair", hair);
    }


}
