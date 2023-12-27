using System.Collections;
using System.Collections.Generic;
using StarterAssets;
using UnityEngine;

public class TodoClap : MonoBehaviour
{
    // Reference player controller
    ThirdPersonController thirdPersonController;
    public GameObject player;
    public GameObject target;

    public Vector3 tempPosition;

    // Start is called before the first frame update
    void Start()
    {
        thirdPersonController = gameObject.GetComponent<ThirdPersonController>();
    }

    // Update is called once per frame
    void Update()
    {
       if (Input.GetKeyDown(KeyCode.F))
       {
            StartCoroutine("Teleport");
       }
    }

    public void Swap()
    {
        tempPosition = player.transform.position;
        player.transform.position = target.transform.position;
        target.transform.position = tempPosition;
    }

    IEnumerator Teleport()
    {
        thirdPersonController.disabled = true;
        yield return new WaitForSeconds(0.1f);
        Swap();
        yield return new WaitForSeconds(0.1f);
        thirdPersonController.disabled = false;
    }
}
