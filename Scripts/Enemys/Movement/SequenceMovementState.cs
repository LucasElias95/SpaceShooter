using UnityEngine;

public class SequenceMovementState : MovementBaseState
{
    private EnemyStepMovement[] enemyStepMovement;
    private float currentTime;
    private int indiceCurrentStep;

    public SequenceMovementState(EnemyStepMovement[] enemyStepMovement)
    {
        this.enemyStepMovement = enemyStepMovement;
        this.currentTime = 0;
        this.indiceCurrentStep = 0;
    }

    public override void Atualizar()
    {
        this.currentTime += Time.deltaTime;
    }


    public float CurrentTime{
        get{
            return this.currentTime;
        }
    }

    public void AdvancedNextStep()
    {
        this.indiceCurrentStep++;
        if (this.indiceCurrentStep == this. enemyStepMovement.Length)
        {
            this.indiceCurrentStep = 0;
        }
        this.currentTime = 0f;
    }

    public EnemyStepMovement CurrentStep{
        get{
            return this.enemyStepMovement[this.indiceCurrentStep];
        }
    }
}
