using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IStamina
{
    void ConsumeStamina(float amount);
    void RegenStamina(float amount);
    void CheckStaminaCap();
    bool CheckCurrentStamina(float amount);
}
