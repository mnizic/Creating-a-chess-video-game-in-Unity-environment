using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Figura : MonoBehaviour, IPointerDownHandler
{
    public bool bijelaFigura;
    public int xRed;
    public int yStupac;
    public int odigraniPotezi;
    public List<ObicanIliPosebanPotez> legalniPotezi = new List<ObicanIliPosebanPotez>();

    public Igra Canvas;
    public Polje PoljeOdFigure;

    public void OznaciFiguru()
    {
        if (this.bijelaFigura == Canvas.bijeliNaPotezu)
        {
            foreach (Polje item in Canvas.SvaPolja)
            {
                item.GetComponentInParent<Image>().color = new Color(item.GetComponentInParent<Image>().color.r, item.GetComponentInParent<Image>().color.g, item.GetComponentInParent<Image>().color.b, 1);
            }
            ProvjeriLegalnePoteze();

            Canvas.TrenutnoOznacenaFigura = this;
            Canvas.ProvjeriOznaceno();
        }
    }
    
    public void PostaviPoljeOdFigure()
    {
        PoljeOdFigure = this.GetComponentInParent<Polje>();
    }
    
    public virtual void ProvjeriLegalnePoteze()
    {
        legalniPotezi.Clear();
        foreach(Polje item in Canvas.SvaPolja)
        {
            if(item.gameObject.transform.childCount == 0)
            {
                legalniPotezi.Add(new ObicanIliPosebanPotez(item));
            }
            else if (this.bijelaFigura != item.FiguraNaPolju.bijelaFigura)
            {
                legalniPotezi.Add(new ObicanIliPosebanPotez(item));
            }
        }

        foreach (Polje item in Canvas.SvaPolja)
        {
            if (this.legalniPotezi.Count != 0)
            {
                foreach (ObicanIliPosebanPotez potez in legalniPotezi)
                {
                    if (item == potez.LegalanPotez)
                    {
                        item.GetComponentInParent<Image>().color = new Color(item.GetComponentInParent<Image>().color.r, item.GetComponentInParent<Image>().color.g, item.GetComponentInParent<Image>().color.b, 1);
                        break;
                    }
                    else
                    {
                        item.GetComponentInParent<Image>().color = new Color(item.GetComponentInParent<Image>().color.r, item.GetComponentInParent<Image>().color.g, item.GetComponentInParent<Image>().color.b, (float)0.45);
                    }
                }
            }
            else
            {
                item.GetComponentInParent<Image>().color = new Color(item.GetComponentInParent<Image>().color.r, item.GetComponentInParent<Image>().color.g, item.GetComponentInParent<Image>().color.b, (float)0.45);
            }
        }
    }

    public void Initialize(bool _bijelaFigura, int _odigraniPotezi = 1)
    {
        this.bijelaFigura = _bijelaFigura;
        this.odigraniPotezi = _odigraniPotezi;
    }

    void Awake()
    {
        PostaviPoljeOdFigure();
        odigraniPotezi = 0;
        Canvas = GameObject.FindObjectOfType<Igra>();
        PoljeOdFigure.PostaviKoordinateFigura();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if(this.bijelaFigura == Canvas.bijeliNaPotezu)
        {
            OznaciFiguru();
        }
        else if (Canvas.DopustiOznacavanjePolja)
        {
            this.transform.parent.gameObject.GetComponent<Polje>().OznaciPolje();
        }
    }
}
