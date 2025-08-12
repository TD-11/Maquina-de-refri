using UnityEngine;

public class StateSemRefrigerantes : Interface.IVendingState
{
    private VendingMachine machine;

    public StateSemRefrigerantes(VendingMachine machine) => this.machine = machine;

    public void InsertCoin()
    {
        Debug.Log("Máquina vazia, não aceita moedas");
    }

    public void Cancel()
    {
        Debug.Log("Nada para cancelar");
    }

    public void Order()
    {
        Debug.Log("Máquina vazia");
        machine.Port.SetActive(true);
    }

    public void Maintenance()
    {
        machine.SetState(new StateManutencao(machine));
        
    }
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    //override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    //override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    //override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}

    // OnStateMove is called right after Animator.OnAnimatorMove()
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that processes and affects root motion
    //}

    // OnStateIK is called right after Animator.OnAnimatorIK()
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that sets up animation IK (inverse kinematics)
    //}
}
