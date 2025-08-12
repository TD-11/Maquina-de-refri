using UnityEngine;

public class StateComMoedas : Interface.IVendingState
{
    private VendingMachine machine;

    public StateComMoedas(VendingMachine machine) => this.machine = machine;

    public void InsertCoin()
    {
        if (machine.moedas > 0)
        {
            Debug.Log("Moeda inserida");
            machine.moedas--;
        }
        else
        {
            Debug.Log("Sem moedas");
        }
    }

    public void Cancel()
    {
        Debug.Log("Compra cancelada, devolvendo moeda");
        machine.moedas++;
        machine.SetState(new StateComMoedas(machine));
    }

    public void Order()
    {
        machine.Port.SetActive(false);
        
        if (machine.estoque > 0)
        {
            Debug.Log("Liberando refrigerante...");
            machine.estoque--;
        }
        
        if (machine.estoque == 0)
        {
            machine.SetState(new StateSemRefrigerantes(machine));
        }
        else if (machine.moedas > 0)
        {
           machine.SetState(new StateComMoedas(machine));
        }
        else if (machine.moedas == 0)
        {
            machine.SetState(new StateSemMoedas(machine));
        }
    }

    public void Maintenance()
    {
        Debug.Log("Modo manutenção não permitido com refrigerante");
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
