using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Excel = Microsoft.Office.Interop.Excel;

namespace ProgTech
{
    class Program
    {
        static void Main(string[] args)
        {
            //Excel.Application xlApp = new Excel.Application();
            //Excel.Workbook xlWorkbook = xlApp.Workbooks.Open(AppDomain.CurrentDomain.BaseDirectory + @"Pizza\Pizza.xlsx");
            //Excel._Worksheet xlWorksheet = xlWorkbook.Sheets[1];
            //Excel.Range xlRange = xlWorksheet.UsedRange;

            Console.WriteLine("Válassz nyelvet (magyar vagy angol):");
            string lang = Console.ReadLine();
            Nyelv nyelv = new Nyelv(lang);
            nyelv.Load();
            Console.Clear();
            bool x1 = true;
            bool x2 = true;
            List<string> l = new List<string>();
            AdottPizza p = new AdottPizza();
            PizzaTipus a = new AlapPizza();
            PizzaTipus v = new VegaPizza();
            Console.WriteLine("Válassz pizza típust:");
            Console.WriteLine("1 = normál");
            Console.WriteLine("2 = vega");
            int t = int.Parse(Console.ReadLine());
            if (t == 1)
                p.TipusChange(a, lang);
            else if (t == 2)
                p.TipusChange(v, lang);
            else x1 = false;
            Console.Clear();

            if (x1)
            {
                p.Feltet();
                string f = Console.ReadLine();
                l = f.Split(',').ToList();
                Pizza pizza = new AlapPizza();
                Pizza z = p.tipus;
                foreach (string y in l)
                {
                    if (y == nyelv.sa)
                    {
                        pizza = new Sajt(z);
                        z = pizza;
                    }
                    else if (y == nyelv.so)
                    {
                        if (p.tipus == a)
                        {
                            pizza = new Sonka(z);
                            z = pizza;
                        }
                    }
                    else if (y == nyelv.fs)
                    {
                        pizza = new FüstöltSajt(z);
                        z = pizza;
                    }
                    else if (y == nyelv.go)
                    {
                        pizza = new Gomba(z);
                        z = pizza;
                    }
                    else if (y == nyelv.sz)
                    {
                        if (p.tipus == a)
                        {
                            pizza = new Szalámi(z);
                            z = pizza;
                        }
                    }
                    else if (y == nyelv.ku)
                    {
                        pizza = new Kukorica(z);
                        z = pizza;
                    }
                    else if (y == nyelv.ha)
                    {
                        pizza = new Hagyma(z);
                        z = pizza;
                    }
                    else x2 = false;
                }
                Console.Clear();
                if (x2)
                    Console.WriteLine(pizza.GetInfo());
                else Console.WriteLine("Nem megfelelő feltét!");
            }
            else Console.WriteLine("Nem megfelelő!");

            Console.ReadKey();
        }
    }

    public class Nyelv
    {
        public Nyelv(string lang)
        {
            this.lang = lang;
        }

        public string lang;
        public string sa;
        public string fs;
        public string so;
        public string ku;
        public string go;
        public string ha;
        public string sz;
        public string sa2;
        public string fs2;
        public string so2;
        public string ku2;
        public string go2;
        public string ha2;
        public string sz2;

        public void Load()
        {
            Excel.Application xlApp = new Excel.Application();
            Excel.Workbook xlWorkbook = xlApp.Workbooks.Open(AppDomain.CurrentDomain.BaseDirectory + @"Pizza\Pizza2.xlsx");
            Excel._Worksheet xlWorksheet = xlWorkbook.Sheets[1];
            Excel.Range xlRange = xlWorksheet.UsedRange;

            if (lang == "magyar")
            {
                sa = xlRange.Cells[1, 1].Value;
                fs = xlRange.Cells[2, 1].Value;
                so = xlRange.Cells[3, 1].Value;
                sz = xlRange.Cells[6, 1].Value;
                ha = xlRange.Cells[7, 1].Value;
                go = xlRange.Cells[4, 1].Value;
                ku = xlRange.Cells[5, 1].Value;
                sa2 = xlRange.Cells[1, 2].Value;
                fs2 = xlRange.Cells[2, 2].Value;
                so2 = xlRange.Cells[3, 2].Value;
                sz2 = xlRange.Cells[6, 2].Value;
                ha2 = xlRange.Cells[7, 2].Value;
                go2 = xlRange.Cells[4, 2].Value;
                ku2 = xlRange.Cells[5, 2].Value;
            }
            else
            {
                sa = xlRange.Cells[1, 3].Value;
                fs = xlRange.Cells[2, 3].Value;
                so = xlRange.Cells[3, 3].Value;
                sz = xlRange.Cells[6, 3].Value;
                ha = xlRange.Cells[7, 3].Value;
                go = xlRange.Cells[4, 3].Value;
                ku = xlRange.Cells[5, 3].Value;
                sa2 = xlRange.Cells[1, 4].Value;
                fs2 = xlRange.Cells[2, 4].Value;
                so2 = xlRange.Cells[3, 4].Value;
                sz2 = xlRange.Cells[6, 4].Value;
                ha2 = xlRange.Cells[7, 4].Value;
                go2 = xlRange.Cells[4, 4].Value;
                ku2 = xlRange.Cells[5, 4].Value;
            }
        }
    }

    interface Pizza
    {
        string GetInfo();
    }

    public abstract class PizzaTipus : Pizza
    {
        public abstract string GetInfo();

        public abstract void Feltet(string lang);
    }

    public class AlapPizza : PizzaTipus
    {
        Nyelv nyelv;
        public override string GetInfo()
        {
            return "pizza";
        }

        public override void Feltet(string lang)
        {
            nyelv = new Nyelv(lang);
            nyelv.Load();

            Console.WriteLine("Válassz feltétet:");
            Console.WriteLine(nyelv.sa + " - " + nyelv.sa2);
            Console.WriteLine(nyelv.so + " - " + nyelv.so2);
            Console.WriteLine(nyelv.sz + " - " + nyelv.sz2);
            Console.WriteLine(nyelv.ha + " - " + nyelv.ha2);
            Console.WriteLine(nyelv.fs + " - " + nyelv.fs2);
            Console.WriteLine(nyelv.ku + " - " + nyelv.ku2);
            Console.WriteLine(nyelv.go + " - " + nyelv.go2);
            Console.Write("Feltétek vesszővel elválasztva: ");
        }
    }

    class VegaPizza : PizzaTipus
    {
        Nyelv nyelv;
        public override string GetInfo()
        {
            return "vega pizza";
        }

        public override void Feltet(string lang)
        {
            nyelv = new Nyelv(lang);
            nyelv.Load();

            Console.WriteLine("Válassz feltétet:");
            Console.WriteLine(nyelv.sa + " - " + nyelv.sa2);
            Console.WriteLine(nyelv.ha + " - " + nyelv.ha2);
            Console.WriteLine(nyelv.fs + " - " + nyelv.fs2);
            Console.WriteLine(nyelv.ku + " - " + nyelv.ku2);
            Console.WriteLine(nyelv.go + " - " + nyelv.go2);
            Console.Write("Feltétek vesszővel elválasztva: ");
        }
    }

    public class AdottPizza
    {
        public PizzaTipus tipus;
        public string lang;

        public void TipusChange(PizzaTipus tipus, string lang)
        {
            this.tipus = tipus;
            this.lang = lang;
        }

        public string GetInfo()
        {
            return tipus.GetInfo();
        }

        public void Feltet()
        {
            tipus.Feltet(lang);
        }
    }

    class Sonka : Pizza
    {
        public Sonka(Pizza pizza)
        {
            this.pizza = pizza;
        }

        public Pizza pizza;

        public string GetInfo()
        {
            return "sonkás " + pizza.GetInfo();
        }
    }

    class Sajt : Pizza
    {
        public Sajt(Pizza pizza)
        {
            this.pizza = pizza;
        }

        public Pizza pizza;

        public string GetInfo()
        {
            return "sajtos " + pizza.GetInfo();
        }
    }

    class Gomba : Pizza
    {
        public Gomba(Pizza pizza)
        {
            this.pizza = pizza;
        }

        public Pizza pizza;

        public string GetInfo()
        {
            return "gombás " + pizza.GetInfo();
        }
    }

    class Hagyma : Pizza
    {
        public Hagyma(Pizza pizza)
        {
            this.pizza = pizza;
        }

        public Pizza pizza;

        public string GetInfo()
        {
            return "hagymás " + pizza.GetInfo();
        }
    }

    class Szalámi : Pizza
    {
        public Szalámi(Pizza pizza)
        {
            this.pizza = pizza;
        }

        public Pizza pizza;

        public string GetInfo()
        {
            return "szalámis " + pizza.GetInfo();
        }
    }

    class FüstöltSajt : Pizza
    {
        public FüstöltSajt(Pizza pizza)
        {
            this.pizza = pizza;
        }

        public Pizza pizza;

        public string GetInfo()
        {
            return "füstölt sajtos " + pizza.GetInfo();
        }
    }

    class Kukorica : Pizza
    {
        public Kukorica(Pizza pizza)
        {
            this.pizza = pizza;
        }

        public Pizza pizza;

        public string GetInfo()
        {
            return "kukoricás " + pizza.GetInfo();
        }
    }
}
