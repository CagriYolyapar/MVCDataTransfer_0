using MVCDataTransfer_0.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCDataTransfer_0.Controllers
{
    public class DataTransferUsageController : Controller
    {
        // MVC'de DataTransfer nesneleri ile de veri göndermemiz mümkündür...
        //BU yöntemde model göndermedigimiz icin karsı tarafın bir model karsılamasına gerek yoktur...
        //Bu nesneler ilkel tipler veya ilkel tip gibi davranan tiplerin transferleri icin tasarlanmıstır...Kendileri her ne kadar potansiyel olarak kompleks tipleri destekleseler de biz bu nesneler ile kompleks tipleri transfer etmeyi hic istemeyiz...Cünkü test edilebilirlikleri yoktur sadece ilkel tiplerin transferi icin saglıklı görülebilirler...


        //ViewData
        //ViewBag
        //TempData


        //1=> ViewData: Action'dan View'a veri göndermeye yarayan nesnenizdir...Kendisi veriyi object halde tutar...Dolayısıyla eger kompleks bir tipte calısıyor iseniz(tavsiye edilmez) unboxing'e maruz kalmak zorundadır...Action'dan Action'a veri gönderemez

        //2=> ViewBag: ViewData'nın daha gelişmiş bir versiyonudur...Kendisi ViewData ile aynı görevi yapar ve aynı özellikleri icerir...Tek farklı veriyi dynamic tipte tutar..Unboxing'e gerek kalmaz...

        //3=> TempData: Action'dan Action'a veri gönderebilen tek DataTransfer nesnenizdir...Aynı zamanda ViewBag ve ViewData gibi Action'dan View'a da veri gönderebilse de bu ilgili data transfer nesnesini böyle durumlarda degil Action'dan Action'a veri transfer etmek istedigimiz durumlarda kullanırız...

        //Tüm DataTransfer nesneleri key, value mantıgında calısır...
        public ActionResult ViewDataUsage()
        {
            ViewData["anahtar"] = "Merhaba bu anahtarın degeridir";
            ViewData["anahtar"] = 1;

            Product p = new Product
            {
                ID = 1,
                Name = "Tadelle",
                Price = 3.4M
            };

            List<Product> urunler = new List<Product>
           {
               p
           };
            ViewData["urun"] = p;
            ViewData["urunler"] = urunler;
            return View();
        }

        public ActionResult ViewBagUsage()
        {
            //ViewBag verileri dynamic tipte tutar...Kendisini yazdıktan sonra . sembolü ile anahtarını verirsiniz ve istediginiz degeri atayabilirsiniz...

            //Bu ürün ismi bos gecilemez

            //Bu kullanıcı bulunamadı

            //Sepetinizde ürün kalmadı

            //Sipariş onaylandı

            ViewBag.Message = "Mail gönderildi";

            ViewBag.Urunsayisi = 1001;

            Product p = new Product
            {
                ID = 1,
                Name = "Cizi",
                Price = 2.3M
            };

            ViewBag.Urun = p;






            return View();
        }


        //TempData(TemporaryData) (gecici data) Normal sartlarda 1 kullanımlıktır...Yani bu yontemle tasıdıgınız verinin ömrü bir front end sayfasında kullanıldıgı anda  dolar...

        //TempData verisinin ömrünü uzatmak istedigimizde ilgili ömrün bitecegi yerde TempData.Keep() metodu kullanılır...Bu metodun iki overload'ı vardır. Bir overload'i hic argüman almaz ve o ana kadar yaratmıs oldugunuz bütüm TempData'ların ömrünü 1 kullanımlık uzatır...İkinci argümanı ise bir key alıp sadece o key'e TempData'nın ömrünü bir kullanımlık uzatır...

        public ActionResult TempDataUsage()
        {
            TempData["key"] = 1;
            //int a = Convert.ToInt32(TempData["key"]);
            object a = TempData["key"];
            return View();
        }


        public ActionResult DenemeUsage1()
        {
            int b = Convert.ToInt32(TempData["key"]);
            TempData.Keep("key");
            return View();
        }

        public ActionResult DenemeUsage2()
        {
            return View();
        }
    }
}