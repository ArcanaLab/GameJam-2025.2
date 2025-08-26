using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IBullet
{
    BulletProperties Properties { get; set; }
    void Travel();
}
