using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class PijunUBijelogKonja : PromocijaOnClick
{
    public override void PromovirajPijuna(Polje poljePijun)
    {
        UkloniPijuna(poljePijun);
        Konj DodanaFigura = poljePijun.GetComponentInChildren<Canvas>().gameObject.AddComponent<Konj>();

        DodanaFigura.Initialize(true);

        poljePijun.FiguraNaPolju.gameObject.GetComponentInChildren<RawImage>().texture = this.SpriteFigure;
        prikazSuceljaPromocije.PovratakNaIgru();
    }
}
