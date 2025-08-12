using UnityEngine;

public class VendingMachine : MonoBehaviour
{
    public Animator animator;
    public int estoque = 0;
    public int moedas = 0;
    public GameObject Port;
    private Interface.IVendingState currentState;
    
    void Start()
    {
        animator = GetComponent<Animator>();
        Port.SetActive(true);
        if (estoque == 0)
        {
            SetState(new StateSemRefrigerantes(this));
        }
        else
        {
            SetState(new StateSemMoedas(this));
        }
    }

    public void SetState(Interface.IVendingState state)
    {
        currentState = state;
        UpdateAnimatorParameters();
    }

    private void UpdateAnimatorParameters()
    {
        
        animator.SetBool("isEmpty", estoque == 0);
        animator.SetBool("hasCoin", currentState is StateComMoedas);
        animator.SetBool("inMaintenance", currentState is StateManutencao);
        
    }

    // Métodos chamados pelos botões
    public void InsertCoin()
    {
        Debug.Log("InsertCoin chamado");
        currentState?.InsertCoin();
    }

    public void Cancel()
    {
        Debug.Log("Cancel chamado");
        currentState?.Cancel();
    }

    public void Order()
    {
        Debug.Log("Order chamado");
        currentState?.Order();
    }

    public void Maintenance()
    {
        Debug.Log("Maintenance chamado");
        currentState?.Maintenance();
    }
    
    public void DispensarRefrigerante()
    {
        estoque--;
        Debug.Log("Latinha liberada!");
        UpdateAnimatorParameters();
    }
}
