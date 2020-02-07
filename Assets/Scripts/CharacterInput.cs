using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterInput : MonoBehaviour, IWalkInput, IJumpInput, ICloneOrBlast, ITeleport
{
    bool canControl=false;

    public float Horizontal { get => canControl? Input.GetAxis("Horizontal"):0; }

    public bool Jump { get => canControl ? Input.GetButtonDown("Jump") : false; }

    public bool Cloned { get => canControl ? Input.GetButtonDown("Action") : false; }

    public bool Teleport { get => canControl ? Input.GetButtonDown("Teleport") : false; }

    public void Enable()
    {
        canControl = true;
    }

    public void Disable()
    {
        canControl = false;
    }
}


public interface IWalkInput
{
    float Horizontal { get; }
}

public interface IJumpInput
{
    bool Jump { get; }
}

public interface ICloneOrBlast
{
    bool Cloned { get; }
}
public interface ITeleport
{
    bool Teleport { get; }
}