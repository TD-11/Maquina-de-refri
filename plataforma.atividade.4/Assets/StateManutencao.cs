using UnityEngine;

public class StateManutencao : Interface.IVendingState
{
    private VendingMachine machine;

    public StateManutencao(VendingMachine machine) => this.machine = machine;

    public void InsertCoin()
    {
        Debug.Log("Máquina vazia");
    }

    public void Cancel()
    {
        Debug.Log("Botão cancel não faz nada em manutenção");
    }

    public void Order()
    {
        Debug.Log("Venda desativada em manutenção");
    }

    public void Maintenance()
    {
        Debug.Log("Saindo do modo manutenção");
        machine.Port.SetActive(false);
        if (machine.moedas == 0)
        {
            machine.moedas = 3;
        }
        
        if (machine.estoque == 0)
        {
            machine.estoque = 3;
        }
        else
        {
            if (machine.moedas > 0)
            {
                machine.SetState(new StateComMoedas(machine));
            }
            else
            {
                machine.SetState(new StateSemMoedas(machine));
            }
        }
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
