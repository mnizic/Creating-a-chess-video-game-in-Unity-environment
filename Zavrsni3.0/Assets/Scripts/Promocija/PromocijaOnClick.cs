using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class PromocijaOnClick : MonoBehaviour, IPointerDownHandler
{
    private Polje PoljePijun = null;
    public Texture SpriteFigure;
    public PrikazSuceljaPromocije prikazSuceljaPromocije;

    public void DohvatiPoljePijuna(Polje _poljePijun)
    {
        PoljePijun = _poljePijun;
    }

    public void UkloniPijuna(Polje ocistiPolje)
    {
        DestroyImmediate(ocistiPolje.FiguraNaPolju);
        ocistiPolje.FiguraNaPolju = null;
    }

    public virtual void PromovirajPijuna(Polje poljePijun)
    {
        UkloniPijuna(poljePijun);
        prikazSuceljaPromocije.PovratakNaIgru();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        PromovirajPijuna(PoljePijun);
    }
}
