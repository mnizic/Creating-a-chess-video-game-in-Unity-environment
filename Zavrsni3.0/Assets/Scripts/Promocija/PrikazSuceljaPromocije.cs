using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrikazSuceljaPromocije : MonoBehaviour
{
    public GameObject PromocijaSucelje;
    public GameObject BijeleFigure;
    public GameObject CrneFigure;

    public List<PromocijaOnClick> SveFigureOdabir = new List<PromocijaOnClick>();

    void Awake()
    {
        foreach(PromocijaOnClick item in this.transform.GetComponentsInChildren<PromocijaOnClick>(true))
        {
            SveFigureOdabir.Add(item);
        }    
    }

    public void UpravljacBijelihFigura(Polje poljePijun)
    {
        this.PromocijaSucelje.SetActive(true);

        this.BijeleFigure.SetActive(true);
        foreach(PromocijaOnClick item in SveFigureOdabir)
        {
            item.DohvatiPoljePijuna(poljePijun);
        }        
    }

    public void UpravljacCrnihFigura(Polje poljePijun)
    {
        this.PromocijaSucelje.SetActive(true);

        this.CrneFigure.SetActive(true);
        foreach (PromocijaOnClick item in SveFigureOdabir)
        {
            item.DohvatiPoljePijuna(poljePijun);
        }
    }

    public void PovratakNaIgru()
    {
        this.PromocijaSucelje.SetActive(false);
        this.BijeleFigure.SetActive(false);
        this.CrneFigure.SetActive(false);
    }
}
