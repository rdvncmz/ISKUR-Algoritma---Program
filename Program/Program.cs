using System;
using System.Collections;
using System.Collections.Generic;

namespace iskur_Odev
{


    class Program
    {
        static string harf;
        static bool ProgramKapat = false;
        static bool bayrak = true; //Verigir metotu için bayrak yapısında kullanılan bool değişken
        static void Main()
        {
            if (!ProgramKapat) // programı kapat false de yani VeriGir metoduna girecek HarfKontrol metotundaki kontrollerdeki x case sine düşerse ProgramKapat değişkeni true olacak ve Main metotu VeriGir metotuna giremeyecek ve program kapatılacak 
                VeriGir();
        }


        private static void HerseyiListele()
        {
            Console.Clear();
            Console.Write("Girilen herşey : ");
            Sayilar.HerseyYazdir();
            Menu();
        }

        private static void MetinleriListele()
        {
            Console.Clear();
            Console.Write("Metinler : ");
            Metinler.TumMetinleriYazdir();
            Menu();
        }

        private static void SayilariListele()
        {
            Console.Clear();
            Console.Write("Girilen sayılar : ");
            Sayilar.SayilariYazdir();
            Menu();
        }

        private static void SessizHarf()
        {
            Console.Clear();
            Console.Write("Toplam sessiz harf sayısı : ");
            Metinler.SessizHarfSayisiYazdir();
            Menu();
        }

        private static void SesliHarf()
        {
            Console.Clear();
            Console.Write("Toplam sesli harf sayısı : ");
            Metinler.SesliHarfSayisiYazdir();
            Menu();
        }

        private static void CiftSayilar()
        {
            Console.Clear();
            Console.Write("Çift sayılar : ");
            Sayilar.CiftSayiYazdir();
            Menu();
        }

        private static void TekSayilar()
        {
            Console.Clear();
            Console.Write("Tek sayılar : ");
            Sayilar.TekSayiYazdir();
            Menu();
        }

        private static void HarfKontrol()
        {
            switch (harf)
            {
                case "a": // Tek Sayılar
                    TekSayilar();
                    break;

                case "b": // Çift Sayılar
                    CiftSayilar();
                    break;

                case "c": // Sesli Harf
                    SesliHarf();
                    break;

                case "d": // Sessiz Harf
                    SessizHarf();
                    break;

                case "e": // Sayıları Listele
                    SayilariListele();
                    break;

                case "f": // Metinleri Listele
                    MetinleriListele();
                    break;

                case "g": // Herşeyi Listele
                    HerseyiListele();
                    break;

                case "x": // Çıkış
                    Console.WriteLine("Program Sonlandı");
                    ProgramKapat = true; // Main metodundaki if kontrolü false de program kapatılması için ProgramKapat değişkeni true ya çekilmesi gerek
                    Main();
                    break;

                default:
                Console.WriteLine("Yanlış giriş yapıldı program kapatılıyor");
                break;
            }
        }
        private static void HarfAl()
        {
            Console.WriteLine("Yapmak istediğiniz işlemi seçin");
            harf = Console.ReadLine();
            HarfKontrol();

        }
        private static void VeriGir()
        {
            Console.WriteLine("Girişleri yapınız. \n(Sonlandırmak için giriş yapmadan ENTER'a basınız)");

            while (bayrak)
            {
                string veri = Console.ReadLine();

                if (veri == "") // girilen veri boş olduğunda yani sadece ENTER a basıldığında menü gösterilecek
                {
                    Console.WriteLine("Veriler alındı");
                    bayrak = false;
                    Menu();
                }
                else
                {
                    try
                    { // eğer girilen veri integer ise buraya
                        string sayisalVeri = veri; // sayisalVeri dedğişkenini veri değişleni integera dönüştükten önce tutulmak için yapılıyor o yüzden hala string olarak kalıyor. Önce integer sonra string e dönüştürürsek eğer başında '0' varsa o gidiyor

                        Convert.ToInt32(veri); // string mi integer mi buradan anlıyoruz. Eğer strşng ise integer a dönüşemeyeceği için catch a düşecek
                        Sayilar.sayiEkle(sayisalVeri);
                    }
                    catch
                    { //string ise buraya girecek
                        Metinler.MetinEkle(veri);
                    }

                }



            }
        }

        private static void Menu()
        {
            Console.WriteLine("(a) girişlerimdeki tek sayıları listele \n"
            +"(b) girişlerimdeki çift sayıları listele\n"
            +"(c) girişlerimdeki metinlerde kullanılan toplam sesli harf sayısı?\n"
            +"(d) girişlerimdeki metinlerde kullanılan toplam sessiz harf sayısı?\n"
            +"(e) girişlerimdeki sayıları listele\n(f) girişlerimdeki metinleri listele\n"
            +"(g) tüm girişlerimi listele\n"
            +"(x) ÇIKIŞ");
            HarfAl();

        }
    }


    class TutulanHersey
    {
        static protected ArrayList girilenHersey = new ArrayList();

        static public void HerseyYazdir()
        {
            string virgulluHersey = "";
            foreach (var item in girilenHersey)
            {
                virgulluHersey += ", " + item;
            }
            string hersey = virgulluHersey.Substring(2, virgulluHersey.Length - 2); //artık başında virdül yok

            System.Console.WriteLine(hersey);
        }
    }
    class Sayilar : TutulanHersey
    {
        static private List<int> numerikSekildeSayi = new List<int>();
        // Sayılar 05 gibi girildiğinde 5 diye tutulacak

        static private List<int> TekSayi = new List<int>();
        // tek sayılar tutulacak

        static private List<int> CiftSayi = new List<int>();
        //çift sayılar tutulacak


        public static List<int> NumerikHaldeSayi { get => numerikSekildeSayi; set => numerikSekildeSayi = value; }

        public static void sayiEkle(string sayi)
        {
            int _sayi; // string halde olan sayıyı int halde tutacak olan değişken
            _sayi = Convert.ToInt32(sayi); // sayı string halde int haline dönüştürülüyor

            girilenHersey.Add(sayi); // herşeyi yazdırmak istediğimiz arrayList e atıyoruz



            numerikSekildeSayi.Add(_sayi); // 05 gibi bi halde ise 5 halinde dönüştürülüp atılıyor


            if (_sayi % 2 == 0)
            {
                CiftSayi.Add(_sayi); // çift ise buraya
            }
            else
            {
                TekSayi.Add(_sayi); // tek ise buraya
            }

        }

        public static void TekSayiYazdir()
        {
            string tekSayiYazdirVirgullu = ""; //başında virgül var
            foreach (var t in TekSayi)
            {
                tekSayiYazdirVirgullu += ", " + t.ToString();
            }
            string tekSayiYazdir = tekSayiYazdirVirgullu.Substring(2, tekSayiYazdirVirgullu.Length - 2); //artık başında virdül yok
            Console.WriteLine(tekSayiYazdir);
        }

        public static void CiftSayiYazdir()
        {
            string ciftSayiYazdirVirgullu = ""; //başında virgül var
            foreach (var c in CiftSayi)
            {
                ciftSayiYazdirVirgullu += ", " + c.ToString();
            }
            string ciftSayiYazdir = ciftSayiYazdirVirgullu.Substring(2, ciftSayiYazdirVirgullu.Length - 2); //artık başında virdül yok
            Console.WriteLine(ciftSayiYazdir);
        }

        public static void SayilariYazdir()
        {
            string sayiYazdirVirgullu = ""; //başında virgül var
            foreach (var c in numerikSekildeSayi)
            {
                sayiYazdirVirgullu += ", " + c.ToString();
            }
            string sayiYazdir = sayiYazdirVirgullu.Substring(2, sayiYazdirVirgullu.Length - 2); //artık başında virdül yok
            Console.WriteLine(sayiYazdir);
        }

    }

    class Metinler : TutulanHersey
    {
        private static string _metin;
        static private int _sesliHarfSayisi = 0;
        static private int _sessizHarfSayisi = 0;
        static private List<string> tumMetinler = new List<string>();
        public static List<string> TumMetinler { get => tumMetinler; }
        public static int SesliHarfSayisi { get => _sesliHarfSayisi; set => _sesliHarfSayisi = value; }
        public static int SessizHarfSayisi { get => _sessizHarfSayisi; set => _sessizHarfSayisi = value; }

        public static void MetinEkle(string metin)
        {
            _metin = metin;
            tumMetinler.Add(metin);

            girilenHersey.Add(metin);
        }

        public static void SesliHarfSayisiYazdir()
        {
            foreach (var kelime in TumMetinler)
            {
                kelime.ToLower(); //kontrol daha rahat olsun diye küçük harfe getirdik
                foreach (var harf in kelime)
                {
                    if (harf == 'a' || harf == 'e' || harf == 'ı' || harf == 'i' || harf == 'o' || harf == 'ö' || harf == 'u' || harf == 'ü')
                    {
                        SesliHarfSayisi++; // bir artırdık
                    }
                }
            }

            Console.WriteLine(_sesliHarfSayisi);
            _sesliHarfSayisi = 0; // sessiz harf sayısında anlattım
        }

        public static void SessizHarfSayisiYazdir()
        {
            foreach (var kelime in TumMetinler) // girilen tüm metinleri alıyor
            {
                kelime.ToLower(); //küçük harfe çeviriyoruzki kontrol daha rahat olsun
                foreach (var harf in kelime)
                {
                    if (harf == 'b' || harf == 'c' || harf == 'ç' || harf == 'd' || harf == 'f' || harf == 'g' || harf == 'ğ' || harf == 'h' || harf == 'j' || harf == 'k' || harf == 'l' || harf == 'm' || harf == 'n' || harf == 'p' || harf == 'r' || harf == 's' || harf == 'ş' || harf == 't' || harf == 'v' || harf == 'y' || harf == 'z' || harf == 'q' || harf == 'w' || harf == 'x')
                    {
                        _sessizHarfSayisi++; // eğer sessiz harflerden en az biri varsa sessiz harf sayısını 1 artırıyoruz
                    }
                }
            }

            Console.WriteLine(_sessizHarfSayisi);
            _sessizHarfSayisi = 0; // sessiz harf sayısı metotu bir daha çağırıldığında önceki kullanımın üzerine saymaya başlıyor. örn 3 ise 6 oluyor bunun önüne geçmek için bunu yapıyoruz
        }

        public static void TumMetinleriYazdir()
        {
            string metinVirgullu = "";
            foreach (var item in TumMetinler)
            {
                metinVirgullu += ", " + item; //", "item , item 
            }

            string sayiYazdir = metinVirgullu.Substring(2, metinVirgullu.Length - 2); //item, item , item
            Console.WriteLine(sayiYazdir);

        }

    }


}
