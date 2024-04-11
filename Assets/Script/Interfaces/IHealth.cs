using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IHealth
{
    void ConsumeHealth(float amount);
    void RegenHealth(float amount);
    void RestoreHealth(float amount);
    void CheckHealthCap();
}
