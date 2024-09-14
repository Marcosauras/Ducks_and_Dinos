using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class World : MonoBehaviour {

    public Material material;
    public BlockType[] blocktypes;

}

[System.Serializable]
public class BlockType {

    public string blockName;
    public bool isSolid;

}