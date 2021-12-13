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

        public void Check()
        {
            if (BlastRadius < 0)
            {
                MessageBox.Show("Вы ввели отрицательно число, но ничего - я исправлю)");
                BlastRadius = Math.Abs(BlastRadius);
            }
            if (ShotsPerMinute < 0)
            {
                MessageBox.Show("Вы ввели отрицательно число, но ничего - я исправлю)");
                BlastRadius = Math.Abs(BlastRadius);
            }
            if (RechargeSpeed < 0)
            {
                MessageBox.Show("Вы ввели отрицательно число, но ничего - я исправлю)");
                BlastRadius = Math.Abs(BlastRadius);
            }
            if (Damage < 0)
            {
                MessageBox.Show("Вы ввели отрицательно число, но ничего - я исправлю)");
                BlastRadius = Math.Abs(BlastRadius);
            }
        }
        public Weapon (String N, double BR, double SPM, double RS, int M, double D)
        {
            Model = N;
            BlastRadius = BR;
            ShotsPerMinute = SPM;
            RechargeSpeed = RS;
            Magazine = M;
            Damage = D;
        }

        public override string ToString()
        {
            return "Модель "+ Model + " имеет радиус поражения " + BlastRadius + " метров, скорострельность " + ShotsPerMinute + " выстрелов в минуту, скорость перезарядки " + RechargeSpeed + " минут и средний урон " + Damage + " единиц урона.";
        }

        public bool ParaEquals(object obj1) //Equals, но для характеристик
        {
            Weapon w = (Weapon)obj1;
            return ((w.BlastRadius == BlastRadius) && (w.ShotsPerMinute == ShotsPerMinute) && (w.RechargeSpeed == RechargeSpeed) && (w.Magazine == Magazine) && (w.Damage == Damage));
        }

        public bool TrueEquals(object obj2) //нелогично называть его просто Equals, так что назвал его TrueEquals и не стал переопределять оригинальный - в этом нет смысла
        {
            Weapon w = (Weapon)obj2;
            return ((w.Model == Model) && (w.BlastRadius == BlastRadius) && (w.ShotsPerMinute == ShotsPerMinute) && (w.RechargeSpeed == RechargeSpeed) && (w.Magazine == Magazine) && (w.Damage == Damage));
        }
    }

    abstract public class Cold : Weapon //абстрактный холодное
    {
        public double Size { get; set; } //максимальный размер

        public Cold (String N, double BR, double SPM, double RS, int M, double D, double S) 
            : base (N,BR,SPM,RS,M,D)
        {
            Size = S;
        }

        public override string ToString()
        {
            return "Модель " + Model + " имеет радиус поражения " + BlastRadius + " метров, скорострельность " + ShotsPerMinute + " выстрелов в минуту, скорость перезарядки " + RechargeSpeed + " минут, средний урон " + Damage + " единиц урона и размер " + Size + " метров.";
        }
    }

    abstract public class Projectile : Cold //метательное
    {
        public Projectile (String N, double BR, double SPM, double RS, int M, double D, double S) 
            : base (N, BR, SPM, RS, M, D, S)
        {
        }
    }

    public class Bow : Projectile //лук
    {
        public double ArrowSize; //размер стрелы
        public Bow (String N, double BR, double SPM, double RS, int M, double D, double S, double AS) 
            : base (N, BR, SPM, RS, M, D, S)
        {
            ArrowSize = AS;
        }

        public override string ToString()
        {
            return "Модель " + Model + " имеет радиус поражения " + BlastRadius + " метров, скорострельность " + ShotsPerMinute + " выстрелов в минуту, скорость перезарядки " + RechargeSpeed + " минут, средний урон " + Damage + " единиц урона, размер " + Size + " метров и длину стрелы, равную " + ArrowSize + " метров.";
        }
    }

    public class CrossBow : Projectile //арбалет
    {
        public double BoltSize; //размер болта
        public CrossBow (String N, double BR, double SPM, double RS, int M, double D, double S, double BS)
            : base (N, BR, SPM, RS, M, D, S)
        {
            BoltSize = BS;
        }

        public override string ToString()
        {
            return "Модель " + Model + " имеет радиус поражения " + BlastRadius + " метров, скорострельность " + ShotsPerMinute + " выстрелов в минуту, скорость перезарядки " + RechargeSpeed + " минут, средний урон " + Damage + " единиц урона, размер " + Size + " метров и длину болта, равную " + BoltSize + " метров.";
        }
    }

    public class ThrowingKnife : Projectile //метательный нож
    {
        public double Weight; //вес
        public ThrowingKnife (String N, double BR, double SPM, double RS, int M, double D, double S, double W)
            : base (N, BR, SPM, RS, M, D, S)
        {
            Weight = W;
        }

        public override string ToString()
        {
            return "Модель " + Model + " имеет радиус поражения " + BlastRadius + " метров, скорострельность " + ShotsPerMinute + " выстрелов в минуту, скорость перезарядки " + RechargeSpeed + " минут, средний урон " + Damage + " единиц урона, размер " + Size + " метров и вес " + Weight + " килограммов.";
        }
    }
    abstract public class Cutting : Cold //режущее
    {
        public Cutting (String N, double BR, double SPM, double RS, double D, double S)
            : base (N, BR, SPM, RS, 1, D, S)
        {
        }
    }

    public class Knife : Cutting //нож
    {
        public Knife (String N, double BR, double SPM, double RS, double D, double S)
            :base (N, BR, SPM, RS, D, S)
        {
        }
    }

    public class Sword : Cutting //меч
    {
        public double Weight; //вес
        public Sword (String N, double BR, double SPM, double RS, double D, double S, double W)
            : base (N, BR, SPM, RS, D, S)
        {
            Weight = W;
        }

        public override string ToString()
        {
            return "Модель " + Model + " имеет радиус поражения " + BlastRadius + " метров, скорострельность " + ShotsPerMinute + " выстрелов в минуту, скорость перезарядки " + RechargeSpeed + " минут, средний урон " + Damage + " единиц урона, размер " + Size + " метров и вес " + Weight + " килограммов.";
        }
    }

    public class BattleAxe : Cutting //топор
    {
        public BattleAxe (String N, double BR, double SPM, double RS, double D, double S)
            : base (N, BR, SPM, RS, D, S)
        {
        }
    }

    abstract public class Strike : Cold //ударно-дробящее
    {
        public Strike (String N, double BR, double SPM, double RS, double D, double S)
            : base (N, BR, SPM, RS, 1, D, S)
        {
        }
    }

    public class Baton : Strike //дубинка
    {
        public Baton (String N, double BR, double SPM, double RS, double D, double S)
            : base (N, BR, SPM, RS, D, S)
        {
        }
    }

    public class Rock : Strike //камень
    {
        public string Country; //страна происхождения
        public Rock (String N, double BR, double SPM, double RS, double D, double S, string CNTR)
        : base (N, BR, SPM, RS, D, S)
        {
            Country = CNTR;
        }

        public override string ToString()
        {
            return "Модель " + Model + " имеет радиус поражения " + BlastRadius + " метров, скорострельность " + ShotsPerMinute + " выстрелов в минуту, скорость перезарядки " + RechargeSpeed + " минут, средний урон " + Damage + " единиц урона, размер " + Size + " метров и страну происхождения " + Country + ".";
        }
    }

    abstract public class FireArm : Weapon //огнестрельное
    {
        public double Recoil { get; set; } //отдача в джоулях

        public FireArm (String N, double BR, double SPM, double RS, int M, double D, double R)
            : base (N, BR, SPM, RS, M, D)
        {
            Recoil = R;
        }

        public override string ToString()
        {
            return "Модель " + Model + " имеет радиус поражения " + BlastRadius + " метров, скорострельность " + ShotsPerMinute + " выстрелов в минуту, скорость перезарядки " + RechargeSpeed + " минут, средний урон " + Damage + " единиц урона и отдачу " + Recoil + " джоулей.";
        }
    }

    public class Pistol : FireArm //пистолет
    {
        public Pistol (String N, double BR, double SPM, double RS, int M, double D, double R)
            : base (N, BR, SPM, RS, M, D, R)
        {
        }
    }

    abstract public class Rifle : FireArm //абстрактный винтовка
    {
        public Rifle (String N, double BR, double SPM, double RS, int M, double D, double R)
            : base (N, BR, SPM, RS, M, D, R)
        {
        }
    }

    public class Assault : Rifle //штурмовая
    {
        public Assault (String N, double BR, double SPM, double RS, int M, double D, double R)
            : base (N, BR, SPM, RS, M, D, R)
        {
        }
    }
    
    public class Sniper : Rifle //снайперская
    {
        int CS; //кратность прицела
        public Sniper (String N, double BR, double SPM, double RS, int M, double D, double R, int cs)
            : base (N, BR, SPM, RS, M, D, R)
        {
            CS = cs;
        }

        public override string ToString()
        {
            return "Модель " + Model + " имеет радиус поражения " + BlastRadius + " метров, скорострельность " + ShotsPerMinute + " выстрелов в минуту, скорость перезарядки " + RechargeSpeed + " минут, средний урон " + Damage + " единиц урона, отдачу " + Recoil + " джоулей и кратность прицела " + CS;
        }
    }

    public class ShotGun : FireArm //дробовик
    {
        public ShotGun (String N, double BR, double SPM, double RS, int M, double D, double R)
            : base (N, BR, SPM, RS, M, D, R)
        {
        }
    }

    public class MachineGun : FireArm //пулемёт
    {
        public MachineGun (String N, double BR, double SPM, double RS, int M, double D, double R)
            : base (N, BR, SPM, RS, M, D, R)
        {
        }
    }

    public class SubMachine : FireArm //пистолет-пулемёт
    {
        public SubMachine (String N, double BR, double SPM, double RS, int M, double D, double R)
            : base (N, BR, SPM, RS, M, D, R)
        {
        }
    }

    abstract public class Nuclear : Weapon
    {
        public double Power { get; set; } //мощность в джоулях

        public Nuclear (String N, double BR, double SPM, double RS, int M, double D, double P)
            : base (N, BR, SPM, RS, M, D)
        {
            Power = P;
        }

        public override string ToString()
        {
            return "Модель " + Model + " имеет радиус поражения " + BlastRadius + " метров, скорострельность " + ShotsPerMinute + " выстрелов в минуту, скорость перезарядки " + RechargeSpeed + " минут, средний урон " + Damage + " единиц урона и мощность взрыва " + Power + " в тратиловом эквиваленте.";
        }
    }

    public class Rocket : Nuclear
    {
        public Rocket (String N, double BR, double SPM, double RS, double D, double P)
            : base (N, BR, SPM, RS, 1, D, P)
        {
        }
    }

    public partial class MainWindow : Window
    {
        //static void Resize(ref Weapon[] array, int newSize)
        //{
        //    Weapon[] newArray = new Weapon[newSize];
        //    for (int i = 0; i < newSize - 1; i++)
        //    {
        //        newArray[i] = array[i];
        //    }
        //    array = newArray;
        //}

        int number = 0;

        List<Weapon> Weapons = new List<Weapon>();

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
        string MAGDM = "вместимость магазина (ни на что не полияет XD), ";
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
            if (CB_1.SelectedIndex == -1 || CB_2.SelectedIndex == -1)
            {
                TB_One.Text = "Выберите тип оружия!";
                return;
            }

            if (check == 0)
            {
                TB_One.Text = "";

                string T = "Введите: ";

                switch (CB_1.SelectedIndex)
                {
                    case 0: //холодное
                        if (CB_3.SelectedIndex == -1)
                        {
                            TB_One.Text = "Выберите тип оружия!";
                            return;
                        }
                        switch (CB_2.SelectedIndex)
                        {
                            case 0: //метательное
                                switch (CB_3.SelectedIndex)
                                {
                                    case 0: //лук
                                        T += M + BR + SPM + RS + MAG + DMG + SZ + AS;
                                        break;
                                    case 1: //арбалет
                                        T += M + BR + SPM + RS + MAG + DMG + SZ + BS; ;
                                        break;
                                    case 2: //метательный нож
                                        T += M + BR + SPM + RS + MAG + DMG + SZ + W;
                                        break;
                                }
                                break;
                            case 1: //режущее
                                switch (CB_3.SelectedIndex)
                                {
                                    case 0: //нож
                                        T += M + BR + SPM + RS + MAGDM + DMG + SZ;
                                        break;
                                    case 1: //меч
                                        T += M + BR + SPM + RS + MAGDM + DMG + SZ + W;
                                        break;
                                    case 2: //топор
                                        T += M + BR + SPM + RS + MAGDM + DMG + SZ;
                                        break;
                                }
                                break;
                            case 2: //дробящее
                                switch (CB_3.SelectedIndex)
                                {
                                    case 0: //дубинка
                                        T += M + BR + SPM + RS + MAGDM + DMG + SZ;
                                        break;
                                    case 1: //камень
                                        T += M + BR + SPM + RS + MAGDM + DMG + SZ + C;
                                        break;
                                }
                                break;
                        }
                        break;
                    case 1: //огнестрельное
                        switch (CB_2.SelectedIndex)
                        {
                            case 0: //пистолет
                                T += M + BR + SPM + RS + MAG + DMG + R;
                                break;
                            case 1: //винтовка
                                if (CB_3.SelectedIndex == -1)
                                {
                                    TB_One.Text = "Выберите тип оружия!";
                                    return;
                                }

                                switch (CB_3.SelectedIndex)
                                {
                                    case 0: //штурмовая
                                        T += M + BR + SPM + RS + MAG + DMG + R;
                                        break;
                                    case 1: //снайперская
                                        T += M + BR + SPM + RS + MAG + DMG + R + CS;
                                        break;
                                }
                                break;
                            case 2: //дробовик
                                T += M + BR + SPM + RS + MAG + DMG + R;
                                break;
                            case 3: //пулемёт
                                T += M + BR + SPM + RS + MAG + DMG + R;
                                break;
                            case 4: //пп
                                T += M + BR + SPM + RS + MAG + DMG + R;
                                break;
                        }
                        break;
                    case 2: //ядерное - ракета
                        T += M + BR + SPM + RS + MAGDM + DMG + P;
                        break;
                }

                T += "и нажмите ДОБАВИТЬ.";
                TB_One.Text += T;
                TB_Remember.Text = "Напоминание! " + T;
                B_Add.Content = "Добавить";
                check = 1;
            }
            else if (check == 1)
            {
                //Array.Resize(ref Weapons, number + 1);

                CB_1.IsEnabled = false;
                CB_2.IsEnabled = false;
                CB_3.IsEnabled = false;

                string[] separatingStrings = {" ", ";", "; "};

                try
                {
                    string[] inputdata1 = TB_One.Text.Split(separatingStrings, System.StringSplitOptions.RemoveEmptyEntries);

                    string Model1 = inputdata1[0];
                    double BlastRad1 = double.Parse(inputdata1[1]);
                    double ShPeMi1 = double.Parse(inputdata1[2]);
                    double ReSp1 = double.Parse(inputdata1[3]);
                    int MAG1 = int.Parse(inputdata1[4]);
                    double D1 = double.Parse(inputdata1[5]);
                }
                catch (Exception)
                {
                    MessageBox.Show("Неверный формат данных!!!");
                    return;
                }
                
                string[] inputdata = TB_One.Text.Split(separatingStrings, System.StringSplitOptions.RemoveEmptyEntries);

                string Model = inputdata[0];
                double BlastRad = double.Parse(inputdata[1]);
                double ShPeMi = double.Parse(inputdata[2]);
                double ReSp = double.Parse(inputdata[3]);
                int MAG = int.Parse(inputdata[4]);
                double D = double.Parse(inputdata[5]);
                //////
                double SorRorP;
                /////
                double AorBSorWorCNTRorCS;
                string CNTR;
                int CS;

                switch (CB_1.SelectedIndex)
                {
                    case 0: //холодное
                        try
                        {
                            double strch = double.Parse(inputdata[6]);
                        }
                        catch
                        {
                            MessageBox.Show("Неверный формат данных!!!");
                            return;
                        }

                        SorRorP = double.Parse(inputdata[6]);
                        switch (CB_2.SelectedIndex)
                        {
                            case 0: //метательное
                                try
                                {
                                    double strch = double.Parse(inputdata[7]);
                                }
                                catch
                                {
                                    MessageBox.Show("Неверный формат данных!!!");
                                    return;
                                }

                                AorBSorWorCNTRorCS = double.Parse(inputdata[7]);
                                switch (CB_3.SelectedIndex)
                                {
                                    case 0: //лук T += AS + SZ + M + BR + SPM + RS + MAG + DMG;
                                        Weapons.Add(new Bow(Model, BlastRad, ShPeMi, ReSp, MAG, D, SorRorP, AorBSorWorCNTRorCS));
                                        break;
                                    case 1: //арбалет T += BS + SZ + M + BR + SPM + RS + MAG + DMG;
                                        Weapons.Add(new CrossBow(Model, BlastRad, ShPeMi, ReSp, MAG, D, SorRorP, AorBSorWorCNTRorCS));
                                        break;
                                    case 2: //метательный нож T += W + SZ + M + BR + SPM + RS + MAG + DMG;
                                        Weapons.Add(new ThrowingKnife(Model, BlastRad, ShPeMi, ReSp, MAG, D, SorRorP, AorBSorWorCNTRorCS));
                                        break;
                                }
                                break;
                            case 1: //режущее
                                switch (CB_3.SelectedIndex)
                                {
                                    case 0: //нож T += SZ + M + BR + SPM + RS + DMG;
                                        Weapons.Add(new Knife(Model, BlastRad, ShPeMi, ReSp, D, SorRorP));
                                        break;
                                    case 1: //меч T += W + SZ + M + BR + SPM + RS + DMG;
                                        try
                                        {
                                            double strch = double.Parse(inputdata[7]);
                                        }
                                        catch
                                        {
                                            MessageBox.Show("Неверный формат данных!!!");
                                            return;
                                        }

                                        AorBSorWorCNTRorCS = double.Parse(inputdata[7]);
                                        Weapons.Add(new Sword(Model, BlastRad, ShPeMi, ReSp, D, SorRorP,AorBSorWorCNTRorCS));
                                        break;
                                    case 2: //топор T += SZ + M + BR + SPM + RS + DMG;
                                        Weapons.Add(new BattleAxe(Model, BlastRad, ShPeMi, ReSp, D, SorRorP));
                                        break;
                                }
                                break;
                            case 2: //дробящее
                                switch (CB_3.SelectedIndex)
                                {
                                    case 0: //дубинка T += SZ + M + BR + SPM + RS + DMG;
                                        Weapons.Add(new Baton(Model, BlastRad, ShPeMi, ReSp, D, SorRorP));
                                        break;
                                    case 1: //камень T += C + SZ + M + BR + SPM + RS + DMG;
                                        try
                                        {
                                            string strch = inputdata[7];
                                        }
                                        catch
                                        {
                                            MessageBox.Show("Неверный формат данных!!!");
                                            return;
                                        }

                                        CNTR = inputdata[7];
                                        Weapons.Add(new Rock(Model, BlastRad, ShPeMi, ReSp, D, SorRorP, CNTR));
                                        break;
                                }
                                break;
                        }
                        break;
                    case 1: //огнестрельное
                        try
                        {
                            double strch = double.Parse(inputdata[6]);
                        }
                        catch
                        {
                            MessageBox.Show("Неверный формат данных!!!");
                            return;
                        }

                        SorRorP = double.Parse(inputdata[6]);
                        switch (CB_2.SelectedIndex)
                        {
                            case 0: //пистолет T += R + M + BR + SPM + RS + MAG + DMG;
                                Weapons.Add(new Pistol(Model, BlastRad, ShPeMi, ReSp, MAG, D, SorRorP));
                                break;
                            case 1: //винтовка
                                switch (CB_3.SelectedIndex)
                                {
                                    case 0: //штурмовая T += R + M + BR + SPM + RS + MAG + DMG;
                                        Weapons.Add(new Assault(Model, BlastRad, ShPeMi, ReSp, MAG, D, SorRorP));
                                        break;
                                    case 1: //снайперская T += CS + R + M + BR + SPM + RS + MAG + DMG;
                                        try
                                        {
                                            double strch = int.Parse(inputdata[7]);
                                        }
                                        catch
                                        {
                                            MessageBox.Show("Неверный формат данных!!!");
                                            return;
                                        }

                                        CS = int.Parse(inputdata[7]);
                                        Weapons.Add(new Sniper(Model, BlastRad, ShPeMi, ReSp, MAG, D, SorRorP, CS));
                                        break;
                                }
                                break;
                            case 2: //дробовик T += R + M + BR + SPM + RS + MAG + DMG;
                                Weapons.Add(new ShotGun(Model, BlastRad, ShPeMi, ReSp, MAG, D, SorRorP));
                                break;
                            case 3: //пулемёт T += R + M + BR + SPM + RS + MAG + DMG;
                                Weapons.Add(new MachineGun(Model, BlastRad, ShPeMi, ReSp, MAG, D, SorRorP));
                                break;
                            case 4: //пп T += R + M + BR + SPM + RS + MAG + DMG;
                                Weapons.Add(new SubMachine(Model, BlastRad, ShPeMi, ReSp, MAG, D, SorRorP));
                                break;
                        }
                        break;
                    case 2: //ядерное - ракета T += P + M + BR + SPM + RS + DMG;
                        try
                        {
                            double strch = double.Parse(inputdata[6]);
                        }
                        catch
                        {
                            MessageBox.Show("Неверный формат данных!!!");
                            return;
                        }

                        SorRorP = double.Parse(inputdata[6]);
                        Weapons.Add(new Rocket(Model, BlastRad, ShPeMi, ReSp, D, SorRorP));
                        break;
                }
                Weapons[number].Check();
                CB_CH1.IsEnabled = true;
                CB_CH2.IsEnabled = true;
                CB_1.SelectedIndex = -1;
                CB_2.SelectedIndex = -1;
                CB_3.SelectedIndex = -1;
                CB_1.IsEnabled = true;
                CB_2.IsEnabled = false;
                CB_3.IsEnabled = false;
                CB_CH1.Items.Add((number + 1).ToString());
                CB_CH2.Items.Add((number + 1).ToString());
                number++;
                DG_OUT.ItemsSource = Weapons;
                DG_OUT.Items.Refresh();
                TB_One.Text = "Успешно!";
                TB_One.IsReadOnly = true;
                B_Add.Content = "Введите характеристики";
                TB_Remember.Text = "";
                check = 0;
            }
            return;
        }

        private void TB_One_GotFocus(object sender, RoutedEventArgs e)
        {
            if (check == 1)
            {
                TB_One.IsReadOnly = false;
                TB_One.Text = "";
            }
            return;
        }

        private void B_INFO_Click(object sender, RoutedEventArgs e)
        {
            if (CB_CH1.SelectedIndex == -1)
            {
                MessageBox.Show("Выберите оружие!");
                return;
            }
            TB_One.Text = Weapons[CB_CH1.SelectedIndex].ToString();
            return;
        }

        private void B_EQUALS_Click(object sender, RoutedEventArgs e)
        {
            if (CB_CH1.SelectedIndex == -1 || CB_CH2.SelectedIndex == -1)
            {
                MessageBox.Show("Выберите оружие!");
                return;
            }

            if (Weapons[CB_CH1.SelectedIndex].TrueEquals(Weapons[CB_CH2.SelectedIndex]))
            {
                TB_One.Text = "Это две абсолютно одинаковые единицы оружия!";
            }
            else if (Weapons[CB_CH1.SelectedIndex].ParaEquals(Weapons[CB_CH2.SelectedIndex]))
            {
                TB_One.Text = "Эти две единицы оружия равны по характеристикам, но не по названию модели... Как такое может быть?";
            }
            else
            {
                TB_One.Text = "Это две совершенно разные единицы оружия!";
            }
            return;
        }

        private void B_Clear_Click(object sender, RoutedEventArgs e)
        {
            CB_CH1.Items.Clear();
            CB_CH1.IsEnabled = false;
            CB_CH2.Items.Clear();
            CB_CH2.IsEnabled = false;
            Weapons.Clear();
            //DG_OUT.Items.Clear();
            DG_OUT.Items.Refresh();
            number = 0;
            TB_One.Text = "База удалена!";
            return;
        }
    }
}