using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingState : MonoBehaviour
{
    enum State
    {
        ArcheryRange,
        Barracks,
        markey,
        well,
        home
    }

    [SerializeField] State state = State.ArcheryRange;
    [SerializeField] UiManager ui;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            ui.SendMessage("InteractionButtonSetTrue");
            ui.stateNum = (int)state;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            ui.SendMessage("InteractionButtonSetFalse");
        }
    }
}
