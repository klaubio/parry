using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Slot : MonoBehaviour
{
    public TextMeshProUGUI numberText1;
    public TextMeshProUGUI numberText2;
    public TextMeshProUGUI resultText;
    public int variableToIncrease = 1;
    private int number1;
    private int number2;
    private bool addNumbers;

    public Staff staff;
    private void Start()
    {
        // Inicializa los n�meros aleatorios.
       
    }

    // Funci�n para generar dos n�meros aleatorios.
    private void GenerateRandomNumbers()
    {
        number1 = Random.Range(0, 10);
        number2 = Random.Range(0, 10);
    }

    private void DetermineOperation()
    {
        addNumbers = Random.Range(0, 2) == 0; // 0 indica que se restan, 1 indica que se suman
    }

    // Funci�n para actualizar la interfaz de usuario con los n�meros generados.
    private void UpdateUI()
    {
        numberText1.text = number1.ToString();
        numberText2.text = number2.ToString();
        resultText.text = (addNumbers ? number1 + number2 : number1 - number2).ToString();

    }


    // Funci�n para activar la m�quina tragamonedas y verificar el resultado.
    public void SpinSlotMachine()
    {
        DetermineOperation();
        GenerateRandomNumbers(); // Genera nuevos n�meros al girar la m�quina.
        UpdateUI(); // Actualiza la interfaz de usuario con los nuevos n�meros.

      

        // Aumenta la variable si el resultado es 7.
        int result = addNumbers ? number1 + number2 : number1 - number2;

        // Establece el valor de variableToIncrease seg�n el resultado.
        staff.damage = result;
    }
}
