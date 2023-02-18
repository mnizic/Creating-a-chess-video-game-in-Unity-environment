using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Igra : MonoBehaviour
{
    GameObject NaPotezuText;
    public bool bijeliNaPotezu;
    public Polje[,] SvaPolja = new Polje[8, 8];
    public PrikazSuceljaPromocije prikazSuceljaPromocije;
    //public int[] TrenutnoOznacenoPoljeKoordinate = new int[2];
    public Polje TrenutnoOznacenoPolje;
    public Figura TrenutnoOznacenaFigura;
    public bool DopustiOznacavanjePolja = false;
    public int brojPoteza = 1;
    public Figura PosljednjaPomaknutaFigura = null;

    void Start()
    {
        bijeliNaPotezu = true;
        Polje[] PoljeSvihPolja = GameObject.FindObjectsOfType<Polje>();

        foreach (Polje item in PoljeSvihPolja)
        {
            SvaPolja[item.xRed, item.yStupac] = item;
        }
        //TrenutnoOznacenoPolje = SvaPolja[TrenutnoOznacenoPoljeKoordinate[0], TrenutnoOznacenoPoljeKoordinate[1]];
        NaPotezuText = GameObject.Find("NaPotezu");
    }

    private bool ListaSadrziPosebanPotez(List<ObicanIliPosebanPotez> Lista, Polje polje)
    {
        foreach (ObicanIliPosebanPotez item in Lista)
        {
            if (item.LegalanPotez == polje && item.PosebanPotez)
            {
                return true;
            }
        }
        return false;
    }

    private void UkloniFiguruIzPolja(Polje ParentPolje)
    {
        foreach (Transform child in ParentPolje.transform)
        {
            child.SetParent(null, false);
            child.GetComponent<Canvas>().enabled = false;
            child.GetComponent<Canvas>().sortingOrder = -1;
        }
        ParentPolje.FiguraNaPolju = null;
    }
    
    private void PomakniFiguruNaPolje(Figura Figura, Polje Polje)
    {
        Figura.PoljeOdFigure.FiguraNaPolju = null;
        Polje.FiguraNaPolju = Figura;

        Figura.transform.SetParent(Polje.gameObject.transform, false);        
        Polje.PostaviKoordinateFigura();

        Figura.PostaviPoljeOdFigure();
        Figura.odigraniPotezi++;

        brojPoteza++;
    }

    private void KrajPoteza()
    {
        DopustiOznacavanjePolja = false;
        TrenutnoOznacenaFigura = null;
        TrenutnoOznacenoPolje = null;

        foreach (Polje item in this.SvaPolja)
        {
            item.GetComponentInParent<Image>().color = new Color(item.GetComponentInParent<Image>().color.r, item.GetComponentInParent<Image>().color.g, item.GetComponentInParent<Image>().color.b, 1);
        }

        bijeliNaPotezu = (bijeliNaPotezu == true) ? false : true;
        if (bijeliNaPotezu) NaPotezuText.GetComponent<Text>().text = "Bijeli na potezu";
        if (!bijeliNaPotezu) NaPotezuText.GetComponent<Text>().text = "Crni na potezu";
    }

    private void ObicnoKretanjeFigura()
    {
        UkloniFiguruIzPolja(TrenutnoOznacenoPolje);
        PomakniFiguruNaPolje(TrenutnoOznacenaFigura, TrenutnoOznacenoPolje);
        KrajPoteza();
    }

    public void ProvjeriOznaceno()
    {
        DopustiOznacavanjePolja = true;
        if((TrenutnoOznacenoPolje != null) && (!ListaSadrziPosebanPotez(TrenutnoOznacenaFigura.legalniPotezi, TrenutnoOznacenoPolje)))
        {
            PosljednjaPomaknutaFigura = TrenutnoOznacenaFigura;

            ObicnoKretanjeFigura();
        }
        else if(TrenutnoOznacenoPolje != null)
        {
            if ((TrenutnoOznacenaFigura is BijeliPijun) && (TrenutnoOznacenoPolje.xRed == 5))
            {
                PosljednjaPomaknutaFigura = TrenutnoOznacenaFigura;
                UkloniFiguruIzPolja(this.SvaPolja[TrenutnoOznacenoPolje.xRed - 1, TrenutnoOznacenoPolje.yStupac]);
                PomakniFiguruNaPolje(TrenutnoOznacenaFigura, TrenutnoOznacenoPolje);
                KrajPoteza();
            }
            else if ((TrenutnoOznacenaFigura is BijeliPijun) && (TrenutnoOznacenoPolje.xRed == 7))
            {
                PosljednjaPomaknutaFigura = TrenutnoOznacenaFigura;
                ObicnoKretanjeFigura();
                prikazSuceljaPromocije.UpravljacBijelihFigura(PosljednjaPomaknutaFigura.PoljeOdFigure);
            }
            else if ((TrenutnoOznacenaFigura is CrniPijun) && (TrenutnoOznacenoPolje.xRed == 2))
            {
                PosljednjaPomaknutaFigura = TrenutnoOznacenaFigura;
                UkloniFiguruIzPolja(this.SvaPolja[TrenutnoOznacenoPolje.xRed + 1, TrenutnoOznacenoPolje.yStupac]);
                PomakniFiguruNaPolje(TrenutnoOznacenaFigura, TrenutnoOznacenoPolje);
                KrajPoteza();
            }
            else if ((TrenutnoOznacenaFigura is CrniPijun) && (TrenutnoOznacenoPolje.xRed == 0))
            {
                PosljednjaPomaknutaFigura = TrenutnoOznacenaFigura;
                ObicnoKretanjeFigura();
                prikazSuceljaPromocije.UpravljacCrnihFigura(PosljednjaPomaknutaFigura.PoljeOdFigure);
            }
            else if (TrenutnoOznacenaFigura is Kralj)
            {
                PosljednjaPomaknutaFigura = TrenutnoOznacenaFigura;

                PomakniFiguruNaPolje(TrenutnoOznacenaFigura, TrenutnoOznacenoPolje);
                if(TrenutnoOznacenoPolje.yStupac == 2)
                {
                    PomakniFiguruNaPolje(this.SvaPolja[TrenutnoOznacenaFigura.xRed, 0].FiguraNaPolju, this.SvaPolja[TrenutnoOznacenaFigura.xRed, 3]);
                }
                else
                {
                    PomakniFiguruNaPolje(this.SvaPolja[TrenutnoOznacenaFigura.xRed, 7].FiguraNaPolju, this.SvaPolja[TrenutnoOznacenaFigura.xRed, 5]);
                }
                KrajPoteza();
            }
        }
    }

    public void NovaIgraButtonHandler()
    {
        //Start();
        //Application.LoadLevel(Application.loadedLevel);
        UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
