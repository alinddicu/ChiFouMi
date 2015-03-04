namespace ChiFouMi.Perfect.Variants
{
    public class CommonVariantDecider
    {
        //if (playerCoup == CoupType.Feuille && computerCoup == CoupType.Ciseaux)
        //{
        //    // emmerde
        //    _dependencies.WriteLine("Pierre contre Feuille!"); // faux
        //    _dependencies.WriteLine("Perdu!");
        //}
        //else if (playerCoup == CoupType.Feuille && computerCoup == CoupType.Pierre)
        //{
        //    // emmerde
        //    _dependencies.WriteLine("Pierre contre Feuille!"); // faux
        //    _dependencies.WriteLine("Perdu!"); // faux
        //}
        //else if (playerCoup == CoupType.Pierre && computerCoup == CoupType.Feuille)
        //{
        //    _dependencies.WriteLine("Pierre contre Feuille!");
        //    _dependencies.WriteLine("Perdu!");
        //}
        //else if (playerCoup == CoupType.Pierre && computerCoup == CoupType.Ciseaux)
        //{
        //    _dependencies.WriteLine("Pierre contre Ciseaux!");
        //    _dependencies.WriteLine("Gagne!");
        //}
        //else if (playerCoup == CoupType.Ciseaux && computerCoup == CoupType.Pierre)
        //{
        //    _dependencies.WriteLine("Ciseaux contre Pierre!");
        //    _dependencies.WriteLine("Perdu!");
        //}
        //else if (playerCoup == CoupType.Ciseaux && computerCoup == CoupType.Feuille)
        //{
        //    _dependencies.WriteLine("Ciseaux contre Feuille!");
        //    _dependencies.WriteLine("Gagne!");
        //}
        //else if (playerCoup == CoupType.Pierre && computerCoup == CoupType.Pierre)
        //{
        //    _dependencies.WriteLine("Pierre contre Pierre!");
        //    _dependencies.WriteLine("Egalite!");
        //}
        //else if (playerCoup == CoupType.Feuille && computerCoup == CoupType.Feuille)
        //{
        //    _dependencies.WriteLine("Feuille contre Feuille!");
        //    _dependencies.WriteLine("Egalite!");
        //}
        //else if (playerCoup == CoupType.Ciseaux && computerCoup == CoupType.Ciseaux)
        //{
        //    _dependencies.WriteLine("Ciseaux contre Ciseaux!");
        //    _dependencies.WriteLine("Egalite!");
        //}

        private static CommonVariantRule[] _rules =
        {
            new CommonVariantRule(CoupType.Feuille, CoupType.Ciseaux, PlayerTurnResult.Perdu, "Pierre contre Feuille!")
        };
    }
}