using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;

public class Polje : MonoBehaviour, IPointerDownHandler
{
    public int xRed;
    public int yStupac;
    public Figura FiguraNaPolju = null;
    public Igra Canvas;

    public void PostaviKoordinateFigura()
    {
        FiguraNaPolju = GetComponentInChildren<Figura>();
        FiguraNaPolju.xRed = xRed;
        FiguraNaPolju.yStupac = yStupac;
        FiguraNaPolju.PoljeOdFigure = this;
    }

    private void Start()
    {
        Canvas = GameObject.FindObjectOfType<Igra>();
        if (this.gameObject.transform.childCount != 0)
        {           
            PostaviKoordinateFigura();
        }
    }

    private bool ListaSadrziPolje(List<ObicanIliPosebanPotez> Lista, Polje polje)
    {
        foreach(ObicanIliPosebanPotez item in Lista)
        {
            if(item.LegalanPotez == polje)
            {
                return true;
            }
        }
        return false;
    }

    void Update()
    {
        
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        OznaciPolje();
    }

    public void OznaciPolje()
    {
        if((Canvas.DopustiOznacavanjePolja) && (this.gameObject.transform.childCount == 0) && (ListaSadrziPolje(Canvas.TrenutnoOznacenaFigura.legalniPotezi, this)))
        {
            Canvas.TrenutnoOznacenoPolje = this;
            Canvas.ProvjeriOznaceno();
        }
        else if (this.gameObject.transform.childCount > 0 && FiguraNaPolju.bijelaFigura == Canvas.bijeliNaPotezu)
        {
            FiguraNaPolju.OznaciFiguru();
            
        }
        else if(this.gameObject.transform.childCount > 0 && FiguraNaPolju.bijelaFigura != Canvas.bijeliNaPotezu &&
            Canvas.DopustiOznacavanjePolja && (ListaSadrziPolje(Canvas.TrenutnoOznacenaFigura.legalniPotezi, this)))
        {
            Canvas.TrenutnoOznacenoPolje = this;
            Canvas.ProvjeriOznaceno();
            
        }
        else
        {
            Canvas.TrenutnoOznacenaFigura = null;
            Canvas.DopustiOznacavanjePolja = false;
            foreach(Polje item in Canvas.SvaPolja)
            {
                item.GetComponentInParent<Image>().color = new Color(item.GetComponentInParent<Image>().color.r, item.GetComponentInParent<Image>().color.g, item.GetComponentInParent<Image>().color.b, 1);
            }
        }
    }
}
