using System.Collections;
using System.Collections.Generic;
using StarterAssets;
using UnityEngine;

public class TodoClap : MonoBehaviour
{
    ThirdPersonController thirdPersonController;
    public GameObject player;
    public GameObject Target;

    public Vector3 playerTempPosition;
    public Vector3 targetTempPosition;

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
        playerTempPosition = player.transform.position;
        targetTempPosition = Target.transform.position;
        player.transform.position = targetTempPosition;
        Target.transform.position = playerTempPosition;
    }

    IEnumerator Teleport()
    {
        thirdPersonController.disabled = true;
        yield return new WaitForSeconds(0.01f);
        Swap();
        yield return new WaitForSeconds(0.01f);
        thirdPersonController.disabled = false;
    }
}
