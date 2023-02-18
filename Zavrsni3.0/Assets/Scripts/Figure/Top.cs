using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Top : Figura
{
    public override void ProvjeriLegalnePoteze()
    {
        Polje provjeriPoljeIznad = null;
        Polje provjeriPoljeDesno = null;
        Polje provjeriPoljeIspod = null;
        Polje provjeriPoljeLijevo = null;
        legalniPotezi.Clear();
        foreach (Polje item in Canvas.SvaPolja)
        {
            if (((item.xRed == this.xRed) || (item.yStupac == this.yStupac)))
            {
                legalniPotezi.Add(new ObicanIliPosebanPotez(item));
                if(item.gameObject.transform.childCount != 0)
                {
                    if(item.xRed < this.xRed)
                    {
                        provjeriPoljeIspod = item;
                    }
                    else if(item.yStupac < this.yStupac)
                    {
                        provjeriPoljeLijevo = item;
                    }
                    else if(item.yStupac > this.yStupac)
                    {
                        if(provjeriPoljeDesno == null)
                        {
                            provjeriPoljeDesno = item;
                        }
                    }
                    else if(item.xRed > this.xRed)
                    {
                        if(provjeriPoljeIznad == null)
                        {
                            provjeriPoljeIznad = item;
                        }
                    }
                }
            }
        }

        List<ObicanIliPosebanPotez> pomocnaListaLegalniPotezi = new List<ObicanIliPosebanPotez>();

        pomocnaListaLegalniPotezi.AddRange(legalniPotezi);

        foreach(ObicanIliPosebanPotez item in pomocnaListaLegalniPotezi)
        {
            if((item.LegalanPotez.gameObject.transform.childCount != 0 && item.LegalanPotez.FiguraNaPolju.bijelaFigura == this.bijelaFigura) ||
                (provjeriPoljeDesno != null && item.LegalanPotez.yStupac > provjeriPoljeDesno.yStupac) ||
                (provjeriPoljeIznad != null && item.LegalanPotez.xRed > provjeriPoljeIznad.xRed))
            {
                legalniPotezi.Remove(item);
            }
        }

        pomocnaListaLegalniPotezi.Reverse();
        bool pronadenoLijevo = false;
        bool pronadenoDolje = false;

        foreach(ObicanIliPosebanPotez item in pomocnaListaLegalniPotezi)
        {
            if(pronadenoLijevo && (item.LegalanPotez.yStupac < provjeriPoljeLijevo.yStupac))
            {
                legalniPotezi.Remove(item);
            }
            else if(pronadenoDolje && (item.LegalanPotez.xRed < provjeriPoljeIspod.xRed))
            {
                legalniPotezi.Remove(item);
            }

            if(provjeriPoljeLijevo != null && item.LegalanPotez == provjeriPoljeLijevo)
            {
                pronadenoLijevo = true;
            }
            else if(provjeriPoljeIspod != null && item.LegalanPotez == provjeriPoljeIspod)
            {
                pronadenoDolje = true;
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
