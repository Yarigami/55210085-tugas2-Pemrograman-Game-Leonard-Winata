using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReactiveTarget : MonoBehaviour
{
    public void ReactToHit()
    {
        //Debug.Log("Target Hit");
        WanderingAI behavior = GetComponent<WanderingAI>();
        if (behavior != null)
        {
            behavior.SetAlive(false);
        }
        StartCoroutine(Die());
    }

    private IEnumerator Die()
    {
        this.transform.Rotate(-75, 0, 0);
        yield return new WaitForSeconds(1.5f);  
        Destroy(this.gameObject);
    }

    void Update()
    {
       
    }
}
