using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dama : Figura
{
    public override void ProvjeriLegalnePoteze()
    {
        Polje provjeriPoljeIznad = null;
        Polje provjeriPoljeDesno = null;
        Polje provjeriPoljeIspod = null;
        Polje provjeriPoljeLijevo = null;

        Polje provjeriGL = null;
        Polje provjeriGD = null;
        Polje provjeriDD = null;
        Polje provjeriDL = null;
        
        legalniPotezi.Clear();
        foreach (Polje item in Canvas.SvaPolja)
        {
            if ((((item.xRed == this.xRed) || 
                (item.yStupac == this.yStupac))) ||
                (((item.xRed - this.xRed) == (item.yStupac - this.yStupac)) ||
                ((item.xRed - this.xRed) == -(item.yStupac - this.yStupac))))
            {
                legalniPotezi.Add(new ObicanIliPosebanPotez(item));
                if (item.gameObject.transform.childCount != 0)
                {
                    if (item.xRed < this.xRed && item.yStupac == this.yStupac)
                    {
                        provjeriPoljeIspod = item;
                    }
                    else if (item.yStupac < this.yStupac && item.xRed == this.xRed)
                    {
                        provjeriPoljeLijevo = item;
                    }
                    else if (item.yStupac > this.yStupac && item.xRed == this.xRed)
                    {
                        if (provjeriPoljeDesno == null)
                        {
                            provjeriPoljeDesno = item;
                        }
                    }
                    else if (item.xRed > this.xRed && item.yStupac == this.yStupac)
                    {
                        if (provjeriPoljeIznad == null)
                        {
                            provjeriPoljeIznad = item;
                        }
                    }
                    else if (item.xRed < this.xRed && item.yStupac > this.yStupac)
                    {
                        provjeriDD = item;
                    }
                    else if (item.xRed < this.xRed && item.yStupac < this.yStupac)
                    {
                        provjeriDL = item;
                    }
                    else if (item.xRed > this.xRed && item.yStupac < this.yStupac)
                    {
                        if (provjeriGL == null)
                        {
                            provjeriGL = item;
                        }
                    }
                    else if (item.xRed > this.xRed && item.yStupac > this.yStupac)
                    {
                        if (provjeriGD == null)
                        {
                            provjeriGD = item;
                        }
                    }
                }
            }
        }

        List<ObicanIliPosebanPotez> pomocnaListaLegalniPotezi = new List<ObicanIliPosebanPotez>();

        pomocnaListaLegalniPotezi.AddRange(legalniPotezi);

        foreach (ObicanIliPosebanPotez item in pomocnaListaLegalniPotezi)
        {
            if ((item.LegalanPotez.gameObject.transform.childCount != 0 && item.LegalanPotez.FiguraNaPolju.bijelaFigura == this.bijelaFigura) ||
                (provjeriPoljeDesno != null && item.LegalanPotez.yStupac > provjeriPoljeDesno.yStupac && item.LegalanPotez.xRed == provjeriPoljeDesno.xRed) ||
                (provjeriPoljeIznad != null && item.LegalanPotez.xRed > provjeriPoljeIznad.xRed && item.LegalanPotez.yStupac == provjeriPoljeIznad.yStupac) ||
                (provjeriGL != null && (item.LegalanPotez.xRed > provjeriGL.xRed && item.LegalanPotez.yStupac < provjeriGL.yStupac)) ||
                (provjeriGD != null && (item.LegalanPotez.xRed > provjeriGD.xRed && item.LegalanPotez.yStupac > provjeriGD.yStupac)))
            {
                legalniPotezi.Remove(item);
            }
        }

        pomocnaListaLegalniPotezi.Reverse();
        bool pronadenoLijevo = false;
        bool pronadenoDolje = false;

        bool pronadenoDL = false;
        bool pronadenoDD = false;

        foreach (ObicanIliPosebanPotez item in pomocnaListaLegalniPotezi)
        {
            if ((pronadenoLijevo && (item.LegalanPotez.yStupac < provjeriPoljeLijevo.yStupac && item.LegalanPotez.xRed == provjeriPoljeLijevo.xRed) || 
                (pronadenoDolje && (item.LegalanPotez.xRed < provjeriPoljeIspod.xRed && item.LegalanPotez.yStupac == provjeriPoljeIspod.yStupac))) ||
                ((pronadenoDL && (item.LegalanPotez.xRed < provjeriDL.xRed && item.LegalanPotez.yStupac < provjeriDL.yStupac))||
                (pronadenoDD && (item.LegalanPotez.xRed < provjeriDD.xRed && item.LegalanPotez.yStupac > provjeriDD.yStupac))))
            {
                legalniPotezi.Remove(item);
            }


            if (provjeriPoljeLijevo != null && item.LegalanPotez == provjeriPoljeLijevo)
            {
                pronadenoLijevo = true;
            }
            else if (provjeriPoljeIspod != null && item.LegalanPotez == provjeriPoljeIspod)
            {
                pronadenoDolje = true;
            }
            else if(provjeriDL != null && item.LegalanPotez == provjeriDL)
            {
                pronadenoDL = true;
            }
            else if (provjeriDD != null && item.LegalanPotez == provjeriDD)
            {
                pronadenoDD = true;
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
