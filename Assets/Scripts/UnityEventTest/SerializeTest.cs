using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SerializeTest : MonoBehaviour
{
    // struct�� �̰� �� �ʿ�!
    public sType _sType22;
    [Serializable]
    public struct sType
    {
        public int count;
    }
}
