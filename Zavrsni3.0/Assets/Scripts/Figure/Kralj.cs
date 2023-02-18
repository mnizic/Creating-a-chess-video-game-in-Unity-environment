using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Kralj : Figura
{
    public override void ProvjeriLegalnePoteze()
    {
        legalniPotezi.Clear();
        foreach(Polje item in Canvas.SvaPolja)
        {
            if(((((item.yStupac - this.yStupac) <= 1) && ((item.yStupac - this.yStupac) >= -1)) &&(((item.xRed - this.xRed) <= 1) && ((item.xRed - this.xRed) >= -1))))   
            {
                if((item.gameObject.transform.childCount == 0) || (this.bijelaFigura != item.FiguraNaPolju.bijelaFigura))
                {
                    legalniPotezi.Add(new ObicanIliPosebanPotez(item));
                }
            }
            else if((this.odigraniPotezi == 0) && (item.xRed == this.xRed) && 
                (((Canvas.SvaPolja[this.xRed, 0].FiguraNaPolju != null) && (Canvas.SvaPolja[this.xRed, 0].FiguraNaPolju.odigraniPotezi == 0) && (item.yStupac == 2) && 
                (Canvas.SvaPolja[this.xRed, 1].FiguraNaPolju == null) && (Canvas.SvaPolja[this.xRed, 2].FiguraNaPolju == null) && (Canvas.SvaPolja[this.xRed, 3].FiguraNaPolju == null)) || 
                ((Canvas.SvaPolja[this.xRed, 0].FiguraNaPolju != null) && (Canvas.SvaPolja[this.xRed, 0].FiguraNaPolju.odigraniPotezi == 0) && (item.yStupac == 6) && 
                (Canvas.SvaPolja[this.xRed, 5].FiguraNaPolju == null) && (Canvas.SvaPolja[this.xRed, 6].FiguraNaPolju == null))))
            {
                legalniPotezi.Add(new ObicanIliPosebanPotez(item, true)); 
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
}
