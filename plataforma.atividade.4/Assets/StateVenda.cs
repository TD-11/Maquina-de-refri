using UnityEngine;

public class StateVenda : Interface.IVendingState
{
    private VendingMachine machine;

    public StateVenda(VendingMachine machine)
    {
        this.machine = machine;

        // Dispara o trigger de venda no Animator
        machine.animator.SetTrigger("buy");

        // Executa a lógica de liberar refrigerante
        machine.DispensarRefrigerante();

        // Após a venda, decide o próximo estado
        if (machine.estoque == 0)
        {
            machine.SetState(new StateSemRefrigerantes(machine));
        }
        else
        {
            machine.SetState(new StateSemMoedas(machine));
        }
    }

    public void InsertCoin()
    {
        Debug.Log("Venda em andamento. Aguarde...");
    }

    public void Cancel()
    {
        Debug.Log("Venda em andamento. Não é possível cancelar.");
    }

    public void Order()
    {
        Debug.Log("Venda em andamento. Já está sendo processada.");
    }

    public void Maintenance()
    {
        Debug.Log("Venda em andamento. Aguarde o fim da venda.");
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
