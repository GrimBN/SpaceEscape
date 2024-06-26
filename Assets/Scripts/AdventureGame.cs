﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AdventureGame : MonoBehaviour
{
    [SerializeField] Text textComponent;
    [SerializeField] State startingState;
    
    State state;
  
    void Start()
    {
        state = startingState;
        textComponent.text = state.GetStateStory();
    }

    void Update()
    {
        ManageState();
    }

    private void ManageState()
    {
        var nextStates = state.GetNextStates();

        if (state.GetSubStateFlag() && Input.GetKeyDown(KeyCode.Space))
        {
            state = nextStates[0];
            textComponent.text = state.GetStateStory();

            if(state.GetSubStateFlag())
            {
                textComponent.text += "\n\n(Press 'Space' to continue...)";
            }
        }
        else if (!state.GetSubStateFlag())
        {
            for (int index = 0 ; index < nextStates.Length; index++)
            {
                if (Input.GetKeyDown(KeyCode.Alpha1 + index))
                {
                    state = nextStates[index];
                    textComponent.text = state.GetStateStory();
                    if(state.GetSubStateFlag())
                    {
                        textComponent.text += "\n\n(Press 'Space' to continue...)";
                    }
                }

                else if (Input.GetKeyDown(KeyCode.Q))
                {
                    state = startingState;
                    textComponent.text = state.GetStateStory();
                }
            }           
        }
    }
}
