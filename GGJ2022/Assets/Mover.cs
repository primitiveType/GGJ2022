using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
    [SerializeField] private Vector3 Position = new Vector3(-.2f, 0, 0);
  

    public void Move()
    {
        transform.localPosition = Position;
    }
}
