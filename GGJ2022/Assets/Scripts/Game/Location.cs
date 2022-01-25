using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Camera))]
public class Location : MonoBehaviour
{
    public Location Left = null;
    public Location Up = null;
    public Location Right = null;
    public Location Down = null;

    private void OnDrawGizmos()
    {
        var color = Gizmos.color;
        DrawIfNotNull(Left);
        DrawIfNotNull(Up);
        DrawIfNotNull(Right);
        DrawIfNotNull(Down);
        Gizmos.color = color;
    }

    private void DrawIfNotNull(Location location)
    {
        if (location == null)
        {
            return;
        }

        if (location.Down != this && location.Left != this && location.Up != this && location.Right != this)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawLine(transform.position, location.transform.position);
            return;
        }


        Gizmos.color = Color.cyan;
        Gizmos.DrawLine(transform.position, location.transform.position);
    }
}