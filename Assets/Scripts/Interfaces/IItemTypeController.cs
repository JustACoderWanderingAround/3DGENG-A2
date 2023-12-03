using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class IItemTypeController : MonoBehaviour
{
    public abstract IItem GetMainItem();
    public abstract void UseLeftMouseButton();
    public abstract void UseRightMouseButton();
    public abstract void SetMainItem(IItem newMainItem);

}
