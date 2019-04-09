﻿using UnityEngine;
using UnityEngine.UI;
using Valve.VR.InteractionSystem;

public class ButtonTrigger : UIElement
{
    //-------------------------------------------------
    protected override void OnHandHoverBegin(Hand hand)
    {
        base.OnHandHoverBegin(hand);
        if (!hand.noSteamVRFallbackCamera)
            InputModule.instance.Submit(gameObject);
    }
}
