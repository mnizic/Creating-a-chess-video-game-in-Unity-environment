using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class PijunUCrnogLovca : PromocijaOnClick
{
    public override void PromovirajPijuna(Polje poljePijun)
    {
        UkloniPijuna(poljePijun);
        Lovac DodanaFigura = poljePijun.GetComponentInChildren<Canvas>().gameObject.AddComponent<Lovac>();

        DodanaFigura.Initialize(false);

        poljePijun.FiguraNaPolju.gameObject.GetComponentInChildren<RawImage>().texture = this.SpriteFigure;
        prikazSuceljaPromocije.PovratakNaIgru();
    }
}
