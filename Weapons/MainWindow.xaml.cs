using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Weapons
{
    abstract public class Weapon //абстрактный класс оружие
    {
        public string Model { get; set; } //называние модели
        public double BlastRadius { get; set; } //радиус поражения
        public double ShotsPerMinute { get; set; } //скорострельность выстрел/минута
        public double RechargeSpeed { get; set; } //скорость перезарядки (в минутах)
        public int Magazine { get; set; } //ёмкость "магазина"
        public double Damage { get; set; } //урон

        public Weapon (String N, double BR, double SPM, double RS, int M, double D)
        {
            Model = N;
            BlastRadius = BR;
            ShotsPerMinute = SPM;
            RechargeSpeed = RS;
            Magazine = M;
            Damage = D;
        }
    }

    abstract public class Cold : Weapon //абстрактный холодное
    {
        public double Size { get; set; } //максимальный размер

        public Cold (double S, String N, double BR, double SPM, double RS, int M, double D) 
            : base (N,BR,SPM,RS,M,D)
        {
            Size = S;
        }
    }

    abstract public class Projectile : Cold //метательное
    {
        public Projectile (double S, String N, double BR, double SPM, double RS, int M, double D) 
            : base (S, N, BR, SPM, RS, M, D)
        {
        }
    }

    public class Bow : Projectile //лук
    {
        public double ArrowSize; //размер стрелы
        public Bow (double AS, double S, String N, double BR, double SPM, double RS, int M, double D) 
            : base (S, N, BR, SPM, RS, M, D)
        {
            ArrowSize = AS;
        }
    }

    public class CrossBow : Projectile //арбалет
    {
        public double BoltSize; //размер болта
        public CrossBow (double BS, double S, String N, double BR, double SPM, double RS, int M, double D)
            : base (S, N, BR, SPM, RS, M, D)
        {
            BoltSize = BS;
        }
    }

    public class ThrowingKnife : Projectile //метательный нож
    {
        public double Weight; //вес
        public ThrowingKnife (double W, double S, String N, double BR, double SPM, double RS, int M, double D)
            : base (S, N, BR, SPM, RS, M, D)
        {
            Weight = W;
        }
    }
    abstract public class Cutting : Cold //режущее
    {
        public Cutting (double S, String N, double BR, double SPM, double RS, double D)
            : base (S, N, BR, SPM, RS, 1, D)
        {
        }
    }

    public class Knife : Cutting //нож
    {
        public Knife (double S, String N, double BR, double SPM, double RS, double D)
            :base (S, N, BR, SPM, RS, D)
        {
        }
    }

    public class Sword : Cutting //меч
    {
        public double Weight; //вес
        public Sword (double W, double S, String N, double BR, double SPM, double RS, double D)
            : base (S, N, BR, SPM, RS, D)
        {
            Weight = W;
        }
    }

    public class BattleAxe : Cutting //топор
    {
        public BattleAxe (double S, String N, double BR, double SPM, double RS, double D)
            : base (S, N, BR, SPM, RS, D)
        {
        }
    }

    abstract public class Strike : Cold //ударно-дробящее
    {
        public Strike (double S, String N, double BR, double SPM, double RS, double D)
            : base (S, N, BR, SPM, RS, 1, D)
        {
        }
    }

    public class Baton : Strike //дубинка
    {
        public Baton (double S, String N, double BR, double SPM, double RS, double D)
            : base (S, N, BR, SPM, RS, D)
        {
        }
    }

    public class Rock : Strike //камень
    {
        public string Country; //страна происхождения
        public Rock (string CNTR, double S, String N, double BR, double SPM, double RS, double D)
        : base (S, N, BR, SPM, RS, D)
        {
            Country = CNTR;
        }
    }

    abstract public class FireArm : Weapon //огнестрельное
    {
        public double Recoil { get; set; } //отдача в джоулях

        public FireArm (double R, String N, double BR, double SPM, double RS, int M, double D)
            : base (N, BR, SPM, RS, M, D)
        {
            Recoil = R;
        }
    }

    public class Pistol : FireArm //пистолет
    {
        public Pistol (double R, String N, double BR, double SPM, double RS, int M, double D)
            : base (R, N, BR, SPM, RS, M, D)
        {
        }
    }

    abstract public class Rifle : FireArm //абстрактный винтовка
    {
        public Rifle (double R, String N, double BR, double SPM, double RS, int M, double D)
            : base (R, N, BR, SPM, RS, M, D)
        {
        }
    }

    public class Assault : Rifle //штурмовая
    {
        public Assault (double R, String N, double BR, double SPM, double RS, int M, double D)
            : base (R, N, BR, SPM, RS, M, D)
        {
        }
    }
    
    public class Sniper : Rifle //снайперская
    {
        int CS; //кратность прицела
        public Sniper (int cs, double R, String N, double BR, double SPM, double RS, int M, double D)
            : base (R, N, BR, SPM, RS, M, D)
        {
            CS = cs;
        }
    }

    public class ShotGun : FireArm //дробовик
    {
        public ShotGun (double R, String N, double BR, double SPM, double RS, int M, double D)
            : base (R, N, BR, SPM, RS, M, D)
        {
        }
    }

    public class MachineGun : FireArm //пулемёт
    {
        public MachineGun (double R, String N, double BR, double SPM, double RS, int M, double D)
            : base (R, N, BR, SPM, RS, M, D)
        {
        }
    }

    public class SubMachine : FireArm //пистолет-пулемёт
    {
        public SubMachine (double R, String N, double BR, double SPM, double RS, int M, double D)
            : base (R, N, BR, SPM, RS, M, D)
        {
        }
    }

    abstract public class Nuclear : Weapon
    {
        public double Power { get; set; } //мощность в джоулях

        public Nuclear (double P, String N, double BR, double SPM, double RS, int M, double D)
            : base (N, BR, SPM, RS, M, D)
        {
            Power = P;
        }
    }

    public class Rocket : Nuclear
    {
        public Rocket (double P, String N, double BR, double SPM, double RS, double D)
            : base (P, N, BR, SPM, RS, 1, D)
        {
        }
    }

    public partial class MainWindow : Window
    {
        static void Resize(ref Weapon[] array, int newSize)
        {
            Weapon[] newArray = new Weapon[newSize];
            for (int i = 0; i < newSize-1; i++)
            {
                newArray[i] = array[i];
            }
            array = newArray;
        }

        Weapon[] Weapons = new Weapon[0];

        List<string> ColdWeaponType = new List<string> { "Метательное", "Колюще-режущее", "Ударно-дробящее" };
        List<string> FireArmWeaponType = new List<string> { "Пистолет", "Винтовка", "Дробовик" , "Пулемёт", "Пистолет-пулемёт"};
        List<string> NuclearWeaponType = new List<string> { "Ракета" };
        List<string> ThrowingWeaponType = new List<string> { "Лук", "Арбалет", "Метательный нож" };
        List<string> CuttingWeaponType = new List<string> { "Нож", "Меч", "Топор"};
        List<string> StrikeWeaponType = new List<string> { "Дубинка", "Камень"};
        List<string> RifleType = new List<string> { "Штурмовая", "Снайперская" };

        //Характеристики:
        string M = "модель, ";
        string BR = "радиус поражения, ";
        string SPM = "скорострельность, ";
        string RS = "скорость перезарядки, ";
        string MAG = "вместимость мазагина, ";
        string DMG = "урон, ";
        string SZ = "максимальный размер, ";
        string AS = "размер стрелы, ";
        string BS = "размер болта, ";
        string W = "вес, ";
        string C = "страну, ";
        string R = "мощность отдачи, ";
        string CS = "кратность прицела, ";
        string P = "мощность, ";

        int check = 0;

        public MainWindow()
        {
            InitializeComponent();

            CB_1.IsEnabled = true;
            CB_2.IsEnabled = false;
            CB_3.IsEnabled = false;

            B_Add.Content = "Ввести характеристики";
        }

        private void CB_1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            CB_2.IsEnabled = true;
            switch (CB_1.SelectedIndex)
            {
                case 0:
                    
                    CB_2.ItemsSource = ColdWeaponType;
                    break;
                case 1:
                    CB_2.ItemsSource = FireArmWeaponType;
                    break;
                case 2:
                    CB_2.ItemsSource = NuclearWeaponType;
                    break;
            }

        }

        private void CB_2_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (CB_1.SelectedIndex == 0 || CB_2.SelectedIndex == 1)
            {
                CB_3.IsEnabled = true;
                if (CB_1.SelectedIndex == 0)
                {
                    switch (CB_2.SelectedIndex)
                    {
                        case 0:
                            CB_3.ItemsSource = ThrowingWeaponType;
                            break;
                        case 1:
                            CB_3.ItemsSource = CuttingWeaponType;
                            break;
                        case 2:
                            CB_3.ItemsSource = StrikeWeaponType;
                            break;
                    }
                }
                else
                {
                    CB_3.ItemsSource = RifleType;
                }
            }
            else
            {
                CB_3.SelectedIndex = -1;
                CB_3.IsEnabled = false;
            }
        }

        private void B_Add_Click(object sender, RoutedEventArgs e)
        {
            TB_One.Text = "";

            if (CB_1.SelectedIndex == -1 || CB_2.SelectedIndex == -1)
            {
                TB_One.Text += "Выберите тип оружия!";
                return;
            }
            if (check == 0)
            {
                string T = "Введите: ";

                switch (CB_1.SelectedIndex)
                {
                    case 0: //холодное
                        switch(CB_2.SelectedIndex)
                        {
                            case 0: //метательное
                                switch(CB_3.SelectedIndex)
                                {
                                    case 0: //лук
                                        T += AS + SZ + M + BR + SPM + RS + MAG + DMG;
                                        break;
                                    case 1: //арбалет
                                        T += BS + SZ + M + BR + SPM + RS + MAG + DMG;
                                        break;
                                    case 2: //метательный нож
                                        T += W + SZ + M + BR + SPM + RS + MAG + DMG;
                                        break;
                                }
                                break;
                            case 1: //режущее
                                switch (CB_3.SelectedIndex)
                                {
                                    case 0: //нож
                                        T += SZ + M + BR + SPM + RS + DMG;
                                        break;
                                    case 1: //меч
                                        T += W + SZ + M + BR + SPM + RS + DMG;
                                        break;
                                    case 2: //топор
                                        T += SZ + M + BR + SPM + RS + DMG;
                                        break;
                                }
                                break;
                            case 2: //дробящее
                                switch (CB_3.SelectedIndex)
                                {
                                    case 0: //дубинка
                                        T += SZ + M + BR + SPM + RS + DMG;
                                        break;
                                    case 1: //камень
                                        T += C + SZ + M + BR + SPM + RS + DMG;
                                        break;
                                }
                                break;
                        }
                        break;
                    case 1: //огнестрельное
                        switch(CB_2.SelectedIndex)
                        {
                            case 0: //пистолет
                                T += R + M + BR + SPM + RS + MAG + DMG;
                                break;
                            case 1: //винтовка
                                switch (CB_3.SelectedIndex)
                                {
                                    case 0: //штурмовая
                                        T += R + M + BR + SPM + RS + MAG + DMG;
                                        break;
                                    case 1: //снайперская
                                        T += CS + R + M + BR + SPM + RS + MAG + DMG;
                                        break;
                                }
                                break;
                            case 2: //дробовик
                                T += R + M + BR + SPM + RS + MAG + DMG;
                                break;
                            case 3: //пулемёт
                                T += R + M + BR + SPM + RS + MAG + DMG;
                                break;
                            case 4: //пп
                                T += R + M + BR + SPM + RS + MAG + DMG;
                                break;
                        }
                        break;
                    case 2: //ядерное - ракета
                        T += P + M + BR + SPM + RS + DMG;
                        break;
                }
                T += "и нажмите ДОБАВИТЬ.";
                TB_One.Text += T;
                B_Add.Content = "Добавить";
            }
            else if (check == 1)
            {
                switch (CB_1.SelectedIndex)
                {
                    case 0: //холодное
                        switch (CB_2.SelectedIndex)
                        {
                            case 0: //метательное
                                switch (CB_3.SelectedIndex)
                                {
                                    case 0: //лук
                                        T += AS + SZ + M + BR + SPM + RS + MAG + DMG;
                                        break;
                                    case 1: //арбалет
                                        T += BS + SZ + M + BR + SPM + RS + MAG + DMG;
                                        break;
                                    case 2: //метательный нож
                                        T += W + SZ + M + BR + SPM + RS + MAG + DMG;
                                        break;
                                }
                                break;
                            case 1: //режущее
                                switch (CB_3.SelectedIndex)
                                {
                                    case 0: //нож
                                        T += SZ + M + BR + SPM + RS + DMG;
                                        break;
                                    case 1: //меч
                                        T += W + SZ + M + BR + SPM + RS + DMG;
                                        break;
                                    case 2: //топор
                                        T += SZ + M + BR + SPM + RS + DMG;
                                        break;
                                }
                                break;
                            case 2: //дробящее
                                switch (CB_3.SelectedIndex)
                                {
                                    case 0: //дубинка
                                        T += SZ + M + BR + SPM + RS + DMG;
                                        break;
                                    case 1: //камень
                                        T += C + SZ + M + BR + SPM + RS + DMG;
                                        break;
                                }
                                break;
                        }
                        break;
                    case 1: //огнестрельное
                        switch (CB_2.SelectedIndex)
                        {
                            case 0: //пистолет
                                T += R + M + BR + SPM + RS + MAG + DMG;
                                break;
                            case 1: //винтовка
                                switch (CB_3.SelectedIndex)
                                {
                                    case 0: //штурмовая
                                        T += R + M + BR + SPM + RS + MAG + DMG;
                                        break;
                                    case 1: //снайперская
                                        T += CS + R + M + BR + SPM + RS + MAG + DMG;
                                        break;
                                }
                                break;
                            case 2: //дробовик
                                T += R + M + BR + SPM + RS + MAG + DMG;
                                break;
                            case 3: //пулемёт
                                T += R + M + BR + SPM + RS + MAG + DMG;
                                break;
                            case 4: //пп
                                T += R + M + BR + SPM + RS + MAG + DMG;
                                break;
                        }
                        break;
                    case 2: //ядерное - ракета
                        T += P + M + BR + SPM + RS + DMG;
                        break;
                }
            }
        }
    }
}
