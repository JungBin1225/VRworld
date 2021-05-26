using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cliker : MonoBehaviour
{
    public bool clicked()
    {
        return Input.GetMouseButtonDown(0);
    }
}
