using System.Collections;
using System;
using UnityEngine;
using UnityEngine.UI;

[Serializable]
public class PoljeStil
{
    public Texture NovaSlika;
    //public Figura FiguraKlasa;
}
public class PoljeFigura : MonoBehaviour
{
    public static PoljeFigura Instanca;

    public PoljeStil[] StiloviPolja;

    private void Awake()
    {
        Instanca = this;    
    }
}
