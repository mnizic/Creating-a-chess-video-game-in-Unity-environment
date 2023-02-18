using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Konj : Figura
{
    public override void ProvjeriLegalnePoteze()
    {
        legalniPotezi.Clear();
        foreach (Polje item in Canvas.SvaPolja)
        {
            if ((((item.xRed == (this.xRed + 1)) && ((item.yStupac == (this.yStupac - 2)))) ||                
                ((item.xRed == (this.xRed + 1)) && ((item.yStupac == (this.yStupac + 2)))) ||
                ((item.xRed == (this.xRed + 2)) && ((item.yStupac == (this.yStupac - 1)))) ||
                ((item.xRed == (this.xRed + 2)) && ((item.yStupac == (this.yStupac + 1)))) ||
                ((item.xRed == (this.xRed - 1)) && ((item.yStupac == (this.yStupac - 2)))) ||
                ((item.xRed == (this.xRed - 1)) && ((item.yStupac == (this.yStupac + 2)))) ||
                ((item.xRed == (this.xRed - 2)) && ((item.yStupac == (this.yStupac - 1)))) ||                
                ((item.xRed == (this.xRed - 2)) && ((item.yStupac == (this.yStupac + 1))))))
            {
                if(item.gameObject.transform.childCount == 0)
                {
                    legalniPotezi.Add(new ObicanIliPosebanPotez(item));
                }
                else if(this.bijelaFigura != item.FiguraNaPolju.bijelaFigura)
                {
                    legalniPotezi.Add(new ObicanIliPosebanPotez(item));
                }
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
