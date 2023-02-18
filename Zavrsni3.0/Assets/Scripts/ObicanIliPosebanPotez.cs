using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObicanIliPosebanPotez
{
    public Polje LegalanPotez { get; set; }
    public bool PosebanPotez { get; set; }

    public ObicanIliPosebanPotez(Polje potez, bool potezJePoseban = false)
    {
        LegalanPotez = potez;
        PosebanPotez = potezJePoseban;
    }
}
