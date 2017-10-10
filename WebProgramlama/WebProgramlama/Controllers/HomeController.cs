using WebProgramlama.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;


namespace WebProgramlama.Controllers
{
    public class HomeController : Controller
    {

        ImdbEntities ent = new ImdbEntities();
        public ActionResult About(int? id)
        {
            AboutDto obj = new AboutDto();

            if (id == null)
            {
                AnaSayfaDTO.sayi = ent.Film.First().FilmID;
            }
            else
            {
                AnaSayfaDTO.sayi = ent.Film.Find(id).FilmID;
            }

            obj.film = ent.Film.Where(x => x.FilmID == AnaSayfaDTO.sayi).FirstOrDefault();

            List<FilmTur> filmTurList = ent.FilmTur.Include("Film").ToList();
            List<FilmTur> turList = new List<FilmTur>();
            turList = filmTurList.Where(x => x.FilmID == obj.film.FilmID).ToList();

            string filmTurleri = "";
            foreach (FilmTur filmTur in turList)
            {
                filmTurleri += filmTur.TurTip.Ad + ",";
            }
            if (!String.IsNullOrEmpty(filmTurleri))
            {
                filmTurleri = filmTurleri.Remove(filmTurleri.Length - 1);
            }
            obj.filmTurleri = filmTurleri;

            return View(obj);
        }

        public ActionResult Gallery(int? id)
        {
            AnaSayfaDTO obj = new AnaSayfaDTO();
            if (id == null && AnaSayfaDTO.sayi != 0)
            {
                obj.film = ent.Film.Where(x => x.FilmID == AnaSayfaDTO.sayi).ToList();
            }
            else if (id == null)
            {
                AnaSayfaDTO.sayi = ent.Film.First().FilmID;
                obj.film = ent.Film.Where(x => x.FilmID == AnaSayfaDTO.sayi).ToList();
            }
            else
            {
                AnaSayfaDTO.sayi = ent.Film.Find(id).FilmID;
                obj.film = ent.Film.Where(x => x.FilmID == AnaSayfaDTO.sayi).ToList();
            }
            obj.galeri = obj.film.FirstOrDefault().Galeri.ToList();
            obj.galeri = obj.galeri.Where(x => x.FilmID == ent.Film.Find(AnaSayfaDTO.sayi).FilmID).ToList();
            return View(obj);
        }

        public ActionResult Player(int? id)
        {
            AnaSayfaDTO obj = new AnaSayfaDTO();
            if (id == null && AnaSayfaDTO.sayi != 0)
            {
                obj.film = ent.Film.Where(x => x.FilmID == AnaSayfaDTO.sayi).ToList();
            }
            else if (id == null)
            {
                AnaSayfaDTO.sayi = ent.Film.First().FilmID;
                obj.film = ent.Film.Where(x => x.FilmID == AnaSayfaDTO.sayi).ToList();
            }
            else
            {
                AnaSayfaDTO.sayi = ent.Film.Find(id).FilmID;
                obj.film = ent.Film.Where(x => x.FilmID == AnaSayfaDTO.sayi).ToList();
            }
            obj.oyuncuFilm = ent.OyuncuFilm.Where(x => x.FilmID == AnaSayfaDTO.sayi).ToList();
            return View(obj);
        }
        public ActionResult RegisterMessage()
        {
            return View();
        }
        public ActionResult Register()
        {
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }
        public ActionResult GoogleSearch()
        {
            return View();
        }
        public ActionResult ChangeCulture(string lang, string returnUrl)
        {
            Session["Culture"] = new CultureInfo(lang);
            return Redirect(returnUrl);
        }

        public ActionResult Aktivasyon(string Email, string aktivasyonkodu)
        {
            var ent = new ImdbEntities();
            var uye = ent.Uyelik.Where(x => x.Email == Email && x.Aktivasyon == aktivasyonkodu).FirstOrDefault();
            if (uye != null)
            {
                uye.Onay = true;
                ent.SaveChanges();
                return View();
            }
            return RedirectToAction("Index", "Film");
        }

        [HttpPost]
        public ActionResult UyeEkle(RegisterViewModel RegisterModel)
        {
            var ent = new ImdbEntities();
            Uyelik _kursogrenci = new Uyelik();
            string aktivasyonkodu = Guid.NewGuid().ToString("N").Substring(0, 20).ToUpper();
            _kursogrenci.Ad = RegisterModel.Ad;
            _kursogrenci.Soyad = RegisterModel.Soyad;
            _kursogrenci.Email = RegisterModel.Email;
            _kursogrenci.Sifre = FormsAuthentication.HashPasswordForStoringInConfigFile(RegisterModel.Password, "md5");
            _kursogrenci.Aktivasyon = aktivasyonkodu;
            _kursogrenci.Onay = false;
            _kursogrenci.Role = "Kullanici";
            _kursogrenci.KayitTarihi = DateTime.Now;
            ent.Uyelik.Add(_kursogrenci);
            ent.SaveChanges();
            string mailIcerik = "KARA KUTU AİLESİNE HOSGELDİNIZ<br>www.egitimmerkezi.com a kayıt olduğunuz için teşekkür ederiz. <br> Üyeliğinizi onaylamak için doğrulamak için aşağıdaki linke tıklayınız.<br> ";
            //mailIcerik += "<a href=\"http://egitimmerkezi.sakarya.edu.tr/Home/Aktivasyon?Email=" + RegisterModel.Email + "&AktivasyonKodu=" + aktivasyonkodu + "\" style=\"text-decoration:underline; color:#3ba5d8;\">Üyeliğimi Aktifleştir</a>";
            mailIcerik += "<a href=\"http://localhost:2636/Home/Aktivasyon?Email=" + RegisterModel.Email + "&AktivasyonKodu=" + aktivasyonkodu + "\" style=\"text-decoration:underline; color:#3ba5d8;\">Üyeliğimi Aktifleştir</a>";
            MailGonder(RegisterModel.Email, "Web Sitesi - Kara Kutu", mailIcerik);
            return View("RegisterMessage");
        }
        
        [HttpPost]
        public ActionResult Login(RegisterViewModel LoginModel)
        {
            if (ModelState.IsValid)
            {

                var ent = new ImdbEntities();
                string sifre = FormsAuthentication.HashPasswordForStoringInConfigFile(LoginModel.Password, "md5");
                var uye = ent.Uyelik.Where(x => x.Email == LoginModel.Email && x.Sifre == sifre && x.Onay == true).FirstOrDefault();
                if (uye != null)
                {
                    FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(1,
                         LoginModel.Email, System.DateTime.Now, System.DateTime.Now.AddMinutes(15),
                         true, null, FormsAuthentication.FormsCookiePath);
                    // Encrypt the ticket.
                    string encTicket = FormsAuthentication.Encrypt(ticket);
                    // Create the cookie.
                    Response.Cookies.Add(new HttpCookie(FormsAuthentication.FormsCookieName, encTicket));

                    Session["eposta"] = LoginModel.Email;
                    Session["role"] = uye.Role;
                    return RedirectToAction("Index", "Film");
                }
                else
                {
                    TempData["Mesaj"] = "Kullanıcı Adı veya şifre yanlış, eposta aktivasyon maili onaylanmamıştır";
                }
            }
            return View("Login");
        }


        public static void MailGonder(string kime, string baslik, string mesajIcerik)
        {
            string server = "smtp.gmail.com";
            string kadi = "hasan.kartal1@ogr.sakarya.edu.tr";
            string sifre = "mugiwaraluffy20";
            int port = 587;
            SmtpClient smtpclient = new SmtpClient();
            smtpclient.Port = port; //Smtp Portu (Sunucuya Göre Değişir)
            smtpclient.Host = server;
            smtpclient.EnableSsl = true; //Sunucunun SSL kullanıp kullanmadıgı
            smtpclient.Credentials = new NetworkCredential(kadi, sifre); //Gmail Adresiniz ve Şifreniz
            MailMessage mail = new MailMessage();
            mail.From = new MailAddress(kadi, "Web Programlama"); //Gidecek Mail Adresi ve Görünüm Adınız
            mail.To.Add(kime); //Kime Göndereceğiniz
            mail.Subject = baslik; //Emailin Konusu
            mail.Body = mesajIcerik; //Mesaj İçeriği
            mail.IsBodyHtml = true; //Mesajınızın Gövdesinde HTML destegininin olup olmadıgı
            smtpclient.Send(mail);
        }
        public ActionResult Cikis()
        {
            Session.Abandon();
            return RedirectToAction("Index", "Film");
        }
        public static string RoleGetir(string eposta)
        {
            var ent = new ImdbEntities();
            var uye_rol = ent.Uyelik.FirstOrDefault(x => x.Email == eposta).Role;
            return uye_rol;
        }
        public static string UyeBilgiGetir(string eposta)
        {
            var ent = new ImdbEntities();
            var uye_bilgi = ent.Uyelik.FirstOrDefault(x => x.Email == eposta);
            string adsoyad = uye_bilgi.Ad;
            return adsoyad;
        }
    }


    public class AnaSayfaDTO
    {
        public static int sayi = 0;
        public List<Film> film { get; set; }
        public List<FilmTur> filmTur { get; set; }
        public List<Galeri> galeri { get; set; }
        public List<Oyuncu> oyuncu { get; set; }
        public List<OyuncuFilm> oyuncuFilm { get; set; }
        public List<TurTip> turTip { get; set; }
        public List<Uyruk> uyruk { get; set; }
        public String filmTurleri { get; set; }

    }

    public class AboutDto
    {
        public Film film { get; set; }
        public String filmTurleri { get; set; }
    }
}