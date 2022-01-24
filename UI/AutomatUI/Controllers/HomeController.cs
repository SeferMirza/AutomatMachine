using AutomatUI.Models;
using Data.Repository;
using Common;
using Microsoft.AspNetCore.Mvc;
using Model;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Diagnostics;
using System.Net;

namespace AutomatUI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IRepository _repository;

        public HomeController(ILogger<HomeController> logger, IRepository repository)
        {
            _logger = logger;
            _repository = repository;
        }

        public IActionResult Index()
        {
            FillRepo();
            ViewModel model = new ViewModel();
            model.slots = _repository.GetProducts();
            return View(model);
        }

        void FillRepo()
        {
            for (var i = 0; i < 19; i++)
            {
                Slot Slot = new Slot()
                {
                    Foods = new FoodSlot(),
                    Drinks = new DrinkSlot()
                };
                Slot.Foods.SlotId = i;
                Slot.Foods.Food.Name = "Food" + i;
                Slot.Foods.Food.Id = i;
                Slot.Foods.Food.Count = new Random().Next(1, 8);
                Slot.Foods.Food.Price = new Random().Next(3, 25);
                if (i < 10)
                {
                    Slot.Drinks.SlotId = i + 19;
                    Slot.Drinks.Drink.Name = "Drink" + i;
                    Slot.Drinks.Drink.Id = i;
                    Slot.Drinks.Drink.Count = new Random().Next(3, 8);
                    Slot.Drinks.Drink.Price = new Random().Next(3, 15);
                    Slot.Drinks.Drink.isHot = Convert.ToBoolean(new Random().Next(0, 2));
                }
                _repository.Add(Slot);
            }
        }

        [HttpPost]
        public IActionResult Index(ViewModel model)
        {
            var result = new JsonMessage();
            result.Result = false;
            result.Icon = "error";
            result.Title = "Başarısız!";

            Slot item = _repository.GetSlotById(model.SlotId);

            //işlem tutarı için değişken
            float tutar = 0;
            bool sayiYeterlimi = true;
            float nakit = 100;
            //istekten sonra dönen kart bilgilerinin tutulduğu nesne
            CardResultDTO CardInfo = new CardResultDTO();

            if (item != null)
            {
                if (item.Drinks.SlotId == model.SlotId)
                {
                    tutar = model.Adet * item.Drinks.Drink.Price;
                    sayiYeterlimi = (model.Adet < item.Drinks.Drink.Count) ? true : false;
                }
                else
                {
                    tutar = model.Adet * item.Foods.Food.Price;
                    sayiYeterlimi = (model.Adet <= item.Foods.Food.Count) ? true : false;
                }

                if (sayiYeterlimi)
                {
                    try
                    {
                        if (model.OdemeYontemi != "Nakit")
                        {
                            //7230 APIGateway port
                            string url = @"https://localhost:7230/" + model.OdemeYontemi + "/" + model.OdemeYontemiNumara;

                            string html = string.Empty;
                            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                            request.AutomaticDecompression = DecompressionMethods.GZip;


                            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                            using (Stream stream = response.GetResponseStream())
                            using (StreamReader reader = new StreamReader(stream))
                            {
                                html = reader.ReadToEnd();
                            }

                            CardInfo = JsonConvert.DeserializeObject<CardResultDTO>(html);

                            //ödeneme yöntemi nakit değilse default değer karttaki bakiye ile değiştirilip işleme devam ediliyor
                            nakit = CardInfo.Balance;
                        }

                        if (nakit < tutar)
                        {
                            result.Body = "Yeterli Bakiyeniz Yok!";
                        }
                        else
                        {
                            Plug plug = new Plug();
                            plug.Miktar = model.Adet;
                            plug.UrunAdi = model.UrunAdi;
                            plug.Tutar = tutar;
                            plug.Kalan = nakit - tutar;
                            plug.OdemeSekli = model.OdemeYontemi;

                            result.Data = plug;

                            result.Title = "Başarılı!";
                            result.Body = "İşlem Tamam!";
                            result.Result = true;
                            result.Icon = "success";
                        }

                    }
                    catch
                    {
                        result.Body = model.OdemeYontemi + " bilgilerinize erişilemedi! \nLütfen servisleri kontrol ediniz.";
                        result.Icon = "warning";
                    }
                }
                else
                {
                    result.Body = "Ürün sayısı yeterli değil";
                }
            }
            else
            {
                result.Body = "Ürün bulunamadı";
            }

            model.slots = _repository.GetProducts();
            return Json(result);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}