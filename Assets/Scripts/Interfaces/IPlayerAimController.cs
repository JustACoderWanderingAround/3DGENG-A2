using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// An interface for all classes that pick up on the player aiming.
/// Not possible to use system.action for this because the lerps in these classes require constant updates.
/// </summary>
public interface IPlayerAimController
{
    public abstract void SetMainWeapon(Weapon mainWeapon);
    public abstract Weapon GetMainWeapon();
    public abstract void OnAim();
    public abstract void OnUpdate();
}
