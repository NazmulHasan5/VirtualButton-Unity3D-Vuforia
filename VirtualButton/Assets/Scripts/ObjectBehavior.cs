using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class ObjectBehavior : MonoBehaviour
{
    public Transform cloudRotate;
    public GameObject AugmentedOBJ;
    private bool enaBTN = false;
    private bool aniBTN = false;
    void Start()
    {
        VirtualButtonBehaviour[] virtualBTN = GetComponentsInChildren<VirtualButtonBehaviour>();
        for(int i = 0; i< virtualBTN.Length; i++)
        {
            virtualBTN[i].RegisterOnButtonPressed(onPressed);
            virtualBTN[i].RegisterOnButtonReleased(onReleased);
        }
    }

    private void Update()
    {
        if (aniBTN)
        {
            cloudRotate.Rotate(0, 1, 0);
        }
    }

    private void onPressed(VirtualButtonBehaviour vb)
    {
        string name = vb.name;
        if(name == "Ani-BTN")
        {
            aniBTN = true;
        }
        else if(name == "Enable-BTN"){
            enaBTN = !enaBTN;
            AugmentedOBJ.SetActive(!enaBTN);
        }
    }

    private void onReleased(VirtualButtonBehaviour vb)
    {
        string name = vb.name;
        if (name == "Ani-BTN")
        {
            aniBTN = false;
        }
    }
}
