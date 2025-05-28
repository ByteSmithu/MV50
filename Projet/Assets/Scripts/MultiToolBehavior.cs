using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class MultiToolBehavior : ToolBehavior
{
    public int currentToolId = 0;
    public GameObject display;

    public List<GameObject> tools;
    private ToolBehavior activeTool;
    private bool isFree = true;

    private void Start()
    {
        ActivateTool();
    }

    private void ActivateTool()
    {
        for (int i = 0; i < tools.Count; i++)
        {
            if (i == currentToolId)
            {
                activeTool = tools[i].GetComponent<ToolBehavior>();
                activeTool.activate();
                display.GetComponent<TextMeshPro>().text = tools[i].name;
            }
            else
            {
                tools[i].GetComponent<ToolBehavior>().deactivate();
            }
        }
    }


    public override void OnTriggerAction(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            isFree = false;
        }

        if (context.canceled)
        {
            isFree = true;
        }
        activeTool.OnTriggerAction(context);
    }

    public override void OnGripAction(InputAction.CallbackContext context)
    {
        activeTool.OnGripAction(context);
    }

    public override void OnAButtonAction(InputAction.CallbackContext context)
    {
        activeTool.OnAButtonAction(context);
    }

    public override void OnBButtonAction(InputAction.CallbackContext context)
    {
        
        if (context.started && isFree)
        {
            LineRenderer lr_current = tools[currentToolId].GetComponent<LineRenderer>();
            lr_current.enabled = false;
            currentToolId = (currentToolId + 1) % tools.Count;
            if (currentToolId != 0)
            {
                LineRenderer lr_next = tools[currentToolId].GetComponent<LineRenderer>();
                lr_next.enabled = true;
            }
            ActivateTool();
        }
    }
}
