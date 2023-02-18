using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class PijunUCrnogTopa : PromocijaOnClick
{
    public override void PromovirajPijuna(Polje poljePijun)
    {
        UkloniPijuna(poljePijun);
        Top DodanaFigura = poljePijun.GetComponentInChildren<Canvas>().gameObject.AddComponent<Top>();

        DodanaFigura.Initialize(false);

        poljePijun.FiguraNaPolju.gameObject.GetComponentInChildren<RawImage>().texture = this.SpriteFigure;
        prikazSuceljaPromocije.PovratakNaIgru();
    }
}
