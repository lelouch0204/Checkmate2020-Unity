using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CookieController : MonoBehaviour
{
    [HideInInspector]
    public string token;

    // Start is called before the first frame update
    void Awake()
    {
        token = httpCookie.GetCookie("jwt");
    }
}
