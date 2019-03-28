﻿using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using SA;

public class PerspectiveChange : StateAction
{
    private GameModeManager states;
    private readonly string isoState;
    private readonly string perspectiveState;
    private readonly string menuState;


    public PerspectiveChange(GameModeManager states, string isoState, string perspectiveState, string menuState)
    {
        this.states = states;
        this.isoState = isoState;
        this.perspectiveState = perspectiveState;
        this.menuState = menuState;
    }

    public override bool Execute()
    {
        //states.playerTransform = states.cameraScript.PlayerClicked(states.commandPoints);
       states.cameraScript.IsoMovement();
        if (states.cameraScript.PlayerClicked(states.commandPoints) && states.currentState == states.GetState("tacticState") ) //change key down to player selected or something
        {
            states.cameraScript.CameraTransition();
            //states.cameraScript.CameraMovement(states.cameraScript.PlayerClicked(states.commandPoints)); //I want to update this!!
            //Debug.Log(states.currentState);
            states.commandPoints -= 1;
            states.SetState(perspectiveState);
            return true;
        }
        if (Input.GetKeyDown(KeyCode.Escape) ) //change key down to menu input pressed
        {
            //Debug.Log("ortho state");
            //states.cameraScript.orthoOn = true;
            //states.cameraScript.IsoCameraTransition();
            states.SetState(menuState);
            return true;
        }

       
        return false;
    }
}
