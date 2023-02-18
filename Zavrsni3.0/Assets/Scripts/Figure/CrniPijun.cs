using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CrniPijun : Figura
{
    public override void ProvjeriLegalnePoteze()
    {
        legalniPotezi.Clear();
        foreach (Polje item in Canvas.SvaPolja)
        {
            //-2 samo ako mu je prvi potez
            if (((this.odigraniPotezi == 0) && ((item.xRed == (this.xRed - 2)) && (item.yStupac == this.yStupac)) && (Canvas.SvaPolja[this.xRed - 1, this.yStupac].gameObject.transform.childCount == 0)) && (item.gameObject.transform.childCount == 0))
            {
                legalniPotezi.Add(new ObicanIliPosebanPotez(item));
            }
            else if ((item.xRed == 2) && ((Canvas.SvaPolja[item.xRed + 1, yStupac].gameObject.transform.childCount != 0) && 
                (Canvas.SvaPolja[item.xRed + 1, item.yStupac].FiguraNaPolju is BijeliPijun) &&
                (item.xRed == this.xRed - 1) && ((item.yStupac == this.yStupac - 1) || (item.yStupac == this.yStupac + 1)) && 
                (Canvas.PosljednjaPomaknutaFigura == Canvas.SvaPolja[item.xRed + 1, item.yStupac].FiguraNaPolju)))
            {
                legalniPotezi.Add(new ObicanIliPosebanPotez(item, true));
            }
            else if (((item.xRed == (this.xRed - 1)) && (item.yStupac == (this.yStupac - 1)) && (item.gameObject.transform.childCount != 0)) ||
                ((item.xRed == (this.xRed - 1)) && (item.yStupac == (this.yStupac + 1)) && (item.gameObject.transform.childCount != 0)) ||
                ((item.xRed == (this.xRed - 1)) && (item.yStupac == (this.yStupac)) && (item.gameObject.transform.childCount == 0)))
            {
                if ((item.gameObject.transform.childCount == 0) || (this.bijelaFigura != item.FiguraNaPolju.bijelaFigura))
                {
                    if (item.xRed != 0)
                    {
                        legalniPotezi.Add(new ObicanIliPosebanPotez(item));
                    }
                    else
                    {
                        legalniPotezi.Add(new ObicanIliPosebanPotez(item, true));
                    }
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