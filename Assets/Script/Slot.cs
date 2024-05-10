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
        // Inicializa los números aleatorios.
       
    }

    // Función para generar dos números aleatorios.
    private void GenerateRandomNumbers()
    {
        number1 = Random.Range(0, 10);
        number2 = Random.Range(0, 10);
    }

    private void DetermineOperation()
    {
        addNumbers = Random.Range(0, 2) == 0; // 0 indica que se restan, 1 indica que se suman
    }

    // Función para actualizar la interfaz de usuario con los números generados.
    private void UpdateUI()
    {
        numberText1.text = number1.ToString();
        numberText2.text = number2.ToString();
        resultText.text = (addNumbers ? number1 + number2 : number1 - number2).ToString();

    }


    // Función para activar la máquina tragamonedas y verificar el resultado.
    public void SpinSlotMachine()
    {
        DetermineOperation();
        GenerateRandomNumbers(); // Genera nuevos números al girar la máquina.
        UpdateUI(); // Actualiza la interfaz de usuario con los nuevos números.

      

        // Aumenta la variable si el resultado es 7.
        int result = addNumbers ? number1 + number2 : number1 - number2;

        // Establece el valor de variableToIncrease según el resultado.
        staff.damage = result;
    }
}
