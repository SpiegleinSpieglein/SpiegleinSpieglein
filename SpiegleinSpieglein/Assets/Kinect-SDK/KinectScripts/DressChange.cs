using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DressChange : MonoBehaviour, KinectGestures.GestureListenerInterface
{
    public List<GameObject> dresses;

    private int activeIndex = 0;

    public void Start()
    {
        foreach(var dress in dresses)
        {
            dress.SetActive(false);
        }
        dresses[activeIndex].SetActive(true);
    }

    public bool GestureCancelled(uint userId, int userIndex, KinectGestures.Gestures gesture, KinectWrapper.NuiSkeletonPositionIndex joint)
    {
        return true;
    }

    public bool GestureCompleted(uint userId, int userIndex, KinectGestures.Gestures gesture, KinectWrapper.NuiSkeletonPositionIndex joint, Vector3 screenPos)
    {
        switch (gesture)
        {
            case KinectGestures.Gestures.SwipeRight:
                dresses[activeIndex].SetActive(false);
                activeIndex = (activeIndex + 1) % dresses.Count;
                dresses[activeIndex].SetActive(true);
                break;
            case KinectGestures.Gestures.SwipeLeft:
                dresses[activeIndex].SetActive(false);
                activeIndex = (activeIndex - 1) % dresses.Count;
                dresses[activeIndex].SetActive(true);
                break;
        }
        return true;
    }

    public void GestureInProgress(uint userId, int userIndex, KinectGestures.Gestures gesture, float progress, KinectWrapper.NuiSkeletonPositionIndex joint, Vector3 screenPos)
    {
        //throw new System.NotImplementedException();
    }

    public void UserDetected(uint userId, int userIndex)
    {
        //throw new System.NotImplementedException();
    }

    public void UserLost(uint userId, int userIndex)
    {
        //throw new System.NotImplementedException();
    }
}
