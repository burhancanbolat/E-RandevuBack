﻿using Ardalis.SmartEnum;

namespace E_RandevuDomain.Enums;

public sealed class DepartmentEnum : SmartEnum<DepartmentEnum>
{
    public static readonly DepartmentEnum Acil = new("Acil", 1);
    public static readonly DepartmentEnum Radyoloji = new("Radyoloji", 2);
    public static readonly DepartmentEnum Kardioloji = new("Kardioloji", 3);
    public static readonly DepartmentEnum Dermatoloji = new("Dermatoloji", 4);
    public static readonly DepartmentEnum Endokrinoloji = new("Endokrinoloji", 5);
    public static readonly DepartmentEnum Gastroenteroloji = new("Gastroenteroloji", 6);
    public static readonly DepartmentEnum GenelCerrahi = new("Genel Cerrahi", 7);
    public static readonly DepartmentEnum JinekolojiveObstetrik = new("JinekolojiveObstetrik", 8);
    public static readonly DepartmentEnum Hematoloji = new("Hematoloji", 9);
    public static readonly DepartmentEnum EnfeksiyonHastalıklari = new("EnfeksiyonHastalıkları", 10);
    public static readonly DepartmentEnum Nefroloji = new("Nefroloji", 11);
    public static readonly DepartmentEnum Nüroloji = new("Nüroloji", 12);
    public static readonly DepartmentEnum Ortopedi = new("Ortopedi", 13);
    public static readonly DepartmentEnum Pediatri = new("Pediatri", 14);
    public static readonly DepartmentEnum Psikiyatri = new("Psikiyatri", 15);
    public static readonly DepartmentEnum Pulmonoloji = new("Pulmonoloji", 16);




    public DepartmentEnum(string name, int value) : base(name, value)
    {
    }
}
