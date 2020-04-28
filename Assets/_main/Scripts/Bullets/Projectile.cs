using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Object_Material
{
    LEATHER,
    IRON,
    SILVER,
    GOLD
}

public enum Modifier
{
    NONE,
    POISON,
    FIRE,
    ICE,
    ELECTRIC
}

[CreateAssetMenu(fileName = "New Projectile", menuName = "Projectile")]
public class Projectile : ScriptableObject
{
    [Header("Basic Stats")]
    public float damage;
    public float speed;

    [Header("Setup")]
    public Object_Material material;
    public Modifier modifier;
    public Weapon weapon;

    public void Fire()
    {

    }
}
