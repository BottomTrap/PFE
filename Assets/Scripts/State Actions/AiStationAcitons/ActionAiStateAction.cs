﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SA;
using RG;


public class ActionAiStateAction : StateAction
{
    private readonly GameModeManager enemyPhaseManager;
    private readonly string tacticAiState;
    private readonly string menuState;
    private readonly string mainMenuState;



    public ActionAiStateAction (GameModeManager enemyPhaseManager, string tacticAiState,string menuState,string mainMenuState)
    {
        this.enemyPhaseManager = enemyPhaseManager;
        this.tacticAiState = tacticAiState;
        this.menuState = menuState;
        this.mainMenuState=mainMenuState;
    }

    public override bool Execute()
    {
        Debug.Log("AI ACTION");
        if (enemyPhaseManager.enemyUnitsScript.currentUnit != null)
        {
            //enemyPhaseManager.cameraScript.StartCoroutine(enemyPhaseManager.cameraScript.CameraTransition(enemyPhaseManager.enemyUnitsScript.currentUnit));
            //Debug.Log("command points"+enemyPhaseManager.enemyUnitsScript.commandPoints);
            var AI = enemyPhaseManager.enemyUnitsScript.currentUnit.GetComponent<AI>();
            //camera follow the action happening
            AI.Action();
            //AI.hasPlayed = true;
            
        }
        else enemyPhaseManager.enemyUnitsScript.commandPoints = 0;

        //enemyPhaseManager.enemyUnitsScript.currentUnit.GetComponent<AI>().score = 0;

        if (enemyPhaseManager.enemyUnitsScript.currentUnit.GetComponent<AI>().hasPlayed)
        {
            enemyPhaseManager.enemyUnitsScript.commandPoints -= 1;
            enemyPhaseManager.SetState(tacticAiState);
            return true;
        }
        //make sure all the actions are being made 
        //get unto tactics state after the unit finished its actions and some half a second delay
        //IEnumarator? Coroutine? to be determined
        //once it finishes, setState etc 
        return true;

        //the ability to push start during that
        //stop the game and put out a prompt
        //that prompt might be able to put the game unto a whole other scene or restart all of this
        
    }
}
