using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebProgramlama.Models;
using System.ComponentModel.DataAnnotations;


namespace WebProgramlama.Controllers
{
    public class AdminController : Controller
    {
        ImdbEntities ent = new ImdbEntities();

        #region // Film
        [WebProgramlama.Attributes.AdminRoleControl] 
        public ActionResult Film()
        {
            var film = ent.Film.ToList();
            return View(film);
        }

        [WebProgramlama.Attributes.AdminRoleControl]
        public ActionResult FilmEkle()
        {
            return View();
        }

         [WebProgramlama.Attributes.AdminRoleControl] 
        public ActionResult FilmSil(int FilmID)
        {
            try
            {
                ent.Film.Remove(ent.Film.First(d => d.FilmID == FilmID));
                ent.SaveChanges();
                return RedirectToAction("Film", "Admin");
            }
            catch (Exception ex)
            {
                throw new Exception("Silerken hata oluştu", ex.InnerException);
            }

        }
         [WebProgramlama.Attributes.AdminRoleControl] 
        public ActionResult FilmDuzenle(int FilmID)
        {
            var _filmDuzenle = ent.Film.Where(x => x.FilmID == FilmID).FirstOrDefault();
            return View(_filmDuzenle);
        }

        [HttpPost]
        [WebProgramlama.Attributes.AdminRoleControl] 
        public ActionResult FilmEkle(Film f, HttpPostedFileBase file)
        {
            try
            {
                Film _film = new Film();
                if (file != null && file.ContentLength > 0)
                {
                    MemoryStream memoryStream = file.InputStream as MemoryStream;
                    if (memoryStream == null)
                    {
                        memoryStream = new MemoryStream();
                        file.InputStream.CopyTo(memoryStream);
                    }
                    _film.Fotograf = memoryStream.ToArray();
                }

                _film.Ad = f.Ad;
                _film.Slogan = f.Slogan;
                _film.Konusu = f.Konusu;
                _film.CikisTarihi = f.CikisTarihi;
                _film.Sure = f.Sure;
                _film.Butce = f.Butce;
                _film.Facebook = f.Facebook;
                _film.Yas = f.Yas;

                ent.Film.Add(_film);
                ent.SaveChanges();
                return RedirectToAction("Film", "Admin");
            }
            catch (Exception ex)
            {
                throw new Exception("Eklerken hata oluştu" + ex.InnerException);
            }
        }

        [HttpPost]
        [WebProgramlama.Attributes.AdminRoleControl] 
        public ActionResult FilmDuzenle(Film film, HttpPostedFileBase file)
        {
            try
            {
                var _filmDuzenle = ent.Film.Where(x => x.FilmID == film.FilmID).FirstOrDefault();
                if (file != null && file.ContentLength > 0)
                {
                    MemoryStream memoryStream = file.InputStream as MemoryStream;
                    if (memoryStream == null)
                    {
                        memoryStream = new MemoryStream();
                        file.InputStream.CopyTo(memoryStream);
                    }
                    _filmDuzenle.Fotograf = memoryStream.ToArray();
                }
                _filmDuzenle.Ad = film.Ad;
                _filmDuzenle.Slogan = film.Slogan;
                _filmDuzenle.Konusu = film.Konusu;
                _filmDuzenle.CikisTarihi = film.CikisTarihi;
                _filmDuzenle.Sure = film.Sure;
                _filmDuzenle.Butce = film.Butce;
                _filmDuzenle.Facebook = film.Facebook;
                _filmDuzenle.Yas = film.Yas;
                ent.SaveChanges();
                return RedirectToAction("Film", "Admin");
            }
            catch (Exception ex)
            {
                throw new Exception("Güncellerken hata oluştu " + ex.Message);
            }

        }
        #endregion

        #region //Tür
        [WebProgramlama.Attributes.AdminRoleControl] 
        public ActionResult Tur()
        {
            var tur = ent.TurTip.ToList();
            return View(tur);
        }

        [WebProgramlama.Attributes.AdminRoleControl] 
        public ActionResult TurEkle()
        {
            return View();
        }

        [WebProgramlama.Attributes.AdminRoleControl] 
        public ActionResult TurSil(int TurTipID)
        {
            try
            {
                ent.TurTip.Remove(ent.TurTip.First(d => d.TurTipID == TurTipID));
                ent.SaveChanges();
                return RedirectToAction("Tur", "Admin");
            }
            catch (Exception ex)
            {
                throw new Exception("Silerken hata oluştu", ex.InnerException);
            }

        }
        [WebProgramlama.Attributes.AdminRoleControl] 
        public ActionResult TurDuzenle(int turTipID)
        {
            var _turTipDuzenle = ent.TurTip.Where(x => x.TurTipID == turTipID).FirstOrDefault();
            return View(_turTipDuzenle);
        }

        [HttpPost]
        [WebProgramlama.Attributes.AdminRoleControl] 
        public ActionResult TurEkle(TurTip t)
        {
            try
            {
                TurTip _turTip = new TurTip();
                _turTip.Ad = t.Ad;
                ent.TurTip.Add(_turTip);
                ent.SaveChanges();
                return RedirectToAction("Tur", "Admin");
            }
            catch (Exception ex)
            {
                throw new Exception("Eklerken hata oluştu" + ex.InnerException);
            }
        }

        [HttpPost]
        [WebProgramlama.Attributes.AdminRoleControl] 
        public ActionResult TurDuzenle(TurTip tur)
        {
            try
            {
                var _turDuzenle = ent.TurTip.Where(x => x.TurTipID == tur.TurTipID).FirstOrDefault();
                _turDuzenle.Ad = tur.Ad;

                ent.SaveChanges();
                return RedirectToAction("Tur", "Admin");
            }
            catch (Exception ex)
            {
                throw new Exception("Güncellerken hata oluştu " + ex.Message);
            }

        }
        #endregion

        #region //Uyruk
        [WebProgramlama.Attributes.AdminRoleControl] 
        public ActionResult Uyruk()
        {
            var uyruk = ent.Uyruk.ToList();
            return View(uyruk);
        }
        [WebProgramlama.Attributes.AdminRoleControl] 
        public ActionResult UyrukEkle()
        {
            return View();
        }
        [WebProgramlama.Attributes.AdminRoleControl] 
        public ActionResult UyrukSil(int UyrukID)
        {
            try
            {
                ent.Uyruk.Remove(ent.Uyruk.First(d => d.UyrukID == UyrukID));
                ent.SaveChanges();
                return RedirectToAction("Uyruk", "Admin");
            }
            catch (Exception ex)
            {
                throw new Exception("Silerken hata oluştu", ex.InnerException);
            }
        }
        [WebProgramlama.Attributes.AdminRoleControl] 
        public ActionResult UyrukDuzenle(int UyrukID)
        {
            var _uyrukDuzenle = ent.Uyruk.Where(x => x.UyrukID == UyrukID).FirstOrDefault();
            return View(_uyrukDuzenle);
        }

        [HttpPost]
        [WebProgramlama.Attributes.AdminRoleControl] 
        public ActionResult UyrukEkle(Uyruk u)
        {
            try
            {
                Uyruk _uyruk = new Uyruk();
                _uyruk.Ad = u.Ad;
                ent.Uyruk.Add(_uyruk);
                ent.SaveChanges();
                return RedirectToAction("Uyruk", "Admin");
            }
            catch (Exception ex)
            {
                throw new Exception("Eklerken hata oluştu" + ex.InnerException);
            }
        }

        [HttpPost]
        [WebProgramlama.Attributes.AdminRoleControl] 
        public ActionResult UyrukDuzenle(Uyruk uyruk)
        {
            try
            {
                var _uyrukDuzenle = ent.Uyruk.Where(x => x.UyrukID == uyruk.UyrukID).FirstOrDefault();
                _uyrukDuzenle.Ad = uyruk.Ad;

                ent.SaveChanges();
                return RedirectToAction("Uyruk", "Admin");
            }
            catch (Exception ex)
            {
                throw new Exception("Güncellerken hata oluştu " + ex.Message);
            }

        }

        #endregion

        #region //Oyuncu
        [WebProgramlama.Attributes.AdminRoleControl] 
        public ActionResult Oyuncu()
        {
            var oyuncu = ent.Oyuncu.ToList();
            return View(oyuncu);
        }
        [WebProgramlama.Attributes.AdminRoleControl] 
        public ActionResult OyuncuEkle()
        {
            ViewBag.Uyruk = new SelectList(ent.Uyruk.OrderBy(x => x.Ad).ToList(), "UyrukId", "Ad");
            return View();
        }
        [WebProgramlama.Attributes.AdminRoleControl] 
        public ActionResult OyuncuSil(int OyuncuID)
        {
            try
            {
                ent.Oyuncu.Remove(ent.Oyuncu.First(d => d.OyuncuID == OyuncuID));
                ent.SaveChanges();
                return RedirectToAction("Oyuncu", "Admin");
            }
            catch (Exception ex)
            {
                throw new Exception("Silerken hata oluştu", ex.InnerException);
            }
        }
        [WebProgramlama.Attributes.AdminRoleControl] 
        public ActionResult OyuncuDuzenle(int OyuncuID)
        {
            ViewBag.Uyruk = new SelectList(ent.Uyruk.OrderBy(x => x.Ad).ToList(), "UyrukId", "Ad");
            var _oyuncuDuzenle = ent.Oyuncu.Where(x => x.OyuncuID == OyuncuID).FirstOrDefault();
            return View(_oyuncuDuzenle);
        }

        [HttpPost]
        [WebProgramlama.Attributes.AdminRoleControl] 
        public ActionResult OyuncuEkle(Oyuncu o, HttpPostedFileBase file)
        {
            try
            {
                Oyuncu _oyuncu = new Oyuncu();
                if (file != null && file.ContentLength > 0)
                {
                    MemoryStream memoryStream = file.InputStream as MemoryStream;
                    if (memoryStream == null)
                    {
                        memoryStream = new MemoryStream();
                        file.InputStream.CopyTo(memoryStream);
                    }
                    _oyuncu.Fotograf = memoryStream.ToArray();
                }
                _oyuncu.Ad = o.Ad;
                _oyuncu.Soyad = o.Soyad;
                _oyuncu.DogumTarihi = o.DogumTarihi;
                _oyuncu.OlumTarihi = o.OlumTarihi;
                _oyuncu.UyrukID = o.UyrukID;
                _oyuncu.Biyografi = o.Biyografi;
                _oyuncu.Facebook = o.Facebook;
                _oyuncu.Twitter = o.Twitter;

                ent.Oyuncu.Add(_oyuncu);
                ent.SaveChanges();
                return RedirectToAction("Oyuncu", "Admin");
            }
            catch (Exception ex)
            {
                throw new Exception("Eklerken hata oluştu" + ex.InnerException);
            }
        }

        [HttpPost]
        [WebProgramlama.Attributes.AdminRoleControl] 
        public ActionResult OyuncuDuzenle(Oyuncu o, HttpPostedFileBase file)
        {
            try
            {
                var _oyuncuDuzenle = ent.Oyuncu.Where(x => x.OyuncuID == o.OyuncuID).FirstOrDefault();
                if (file != null && file.ContentLength > 0)
                {
                    MemoryStream memoryStream = file.InputStream as MemoryStream;
                    if (memoryStream == null)
                    {
                        memoryStream = new MemoryStream();
                        file.InputStream.CopyTo(memoryStream);
                    }
                    _oyuncuDuzenle.Fotograf = memoryStream.ToArray();
                }
                _oyuncuDuzenle.Ad = o.Ad;
                _oyuncuDuzenle.Soyad = o.Soyad;
                _oyuncuDuzenle.DogumTarihi = o.DogumTarihi;
                _oyuncuDuzenle.OlumTarihi = o.OlumTarihi;
                _oyuncuDuzenle.UyrukID = o.UyrukID;
                _oyuncuDuzenle.Biyografi = o.Biyografi;
                _oyuncuDuzenle.Facebook = o.Facebook;
                _oyuncuDuzenle.Twitter = o.Twitter;

                ent.SaveChanges();
                return RedirectToAction("Oyuncu", "Admin");
            }
            catch (Exception ex)
            {
                throw new Exception("Eklerken hata oluştu" + ex.InnerException);
            }
        }

        #endregion

        #region //Galeri
        [WebProgramlama.Attributes.AdminRoleControl] 
        public ActionResult Galeri()
        {
            var galeri = ent.Galeri.ToList();
            return View(galeri);
        }
        [WebProgramlama.Attributes.AdminRoleControl] 
        public ActionResult GaleriEkle()
        {
            ViewBag.Film = new SelectList(ent.Film.OrderBy(x => x.Ad).ToList(), "FilmId", "Ad");
            return View();
        }
        [WebProgramlama.Attributes.AdminRoleControl] 
        public ActionResult GaleriSil(int GaleriID)
        {
            try
            {
                ent.Galeri.Remove(ent.Galeri.First(d => d.GaleriID == GaleriID));
                ent.SaveChanges();
                return RedirectToAction("Galeri", "Admin");
            }
            catch (Exception ex)
            {
                throw new Exception("Silerken hata oluştu", ex.InnerException);
            }
        }
        [WebProgramlama.Attributes.AdminRoleControl] 
        public ActionResult GaleriDuzenle(int GaleriID)
        {
            ViewBag.Film = new SelectList(ent.Film.OrderBy(x => x.Ad).ToList(), "FilmId", "Ad");
            var _galeriDuzenle = ent.Galeri.Where(x => x.GaleriID == GaleriID).FirstOrDefault();
            return View(_galeriDuzenle);
        }

        [HttpPost]
        [WebProgramlama.Attributes.AdminRoleControl] 
        public ActionResult GaleriEkle(Galeri g, HttpPostedFileBase file)
        {
            try
            {
                Galeri _galeri = new Galeri();
                if (file != null && file.ContentLength > 0)
                {
                    MemoryStream memoryStream = file.InputStream as MemoryStream;
                    if (memoryStream == null)
                    {
                        memoryStream = new MemoryStream();
                        file.InputStream.CopyTo(memoryStream);
                    }
                    _galeri.GaleriFoto = memoryStream.ToArray();
                }
                _galeri.FilmID = g.FilmID;

                ent.Galeri.Add(_galeri);
                ent.SaveChanges();
                return RedirectToAction("Galeri", "Admin");
            }
            catch (Exception ex)
            {
                throw new Exception("Eklerken hata oluştu" + ex.InnerException);
            }
        }

        [HttpPost]
        [WebProgramlama.Attributes.AdminRoleControl] 
        public ActionResult GaleriDuzenle(Galeri g, HttpPostedFileBase file)
        {
            try
            {
                var _galeriDuzenle = ent.Galeri.Where(x => x.GaleriID == g.GaleriID).FirstOrDefault();
                if (file != null && file.ContentLength > 0)
                {
                    MemoryStream memoryStream = file.InputStream as MemoryStream;
                    if (memoryStream == null)
                    {
                        memoryStream = new MemoryStream();
                        file.InputStream.CopyTo(memoryStream);
                    }
                    _galeriDuzenle.GaleriFoto = memoryStream.ToArray();
                }
                _galeriDuzenle.FilmID = g.FilmID;

                ent.SaveChanges();
                return RedirectToAction("Galeri", "Admin");
            }
            catch (Exception ex)
            {
                throw new Exception("Eklerken hata oluştu" + ex.InnerException);
            }
        }

        #endregion

        #region //OyuncuFilm
        
        [WebProgramlama.Attributes.AdminRoleControl] 
        public ActionResult OyuncuFilm()
        {
            var oyuncuFilm = ent.OyuncuFilm.ToList();
            return View(oyuncuFilm);
        }

        [WebProgramlama.Attributes.AdminRoleControl] 
        public ActionResult OyuncuFilmEkle()
        {
            ViewBag.Oyuncu = new SelectList(ent.Oyuncu.OrderBy(x => x.Ad).ToList(), "OyuncuId", "Ad");
            ViewBag.Film = new SelectList(ent.Film.OrderBy(x => x.Ad).ToList(), "FilmId", "Ad");
            return View();
        }
        [WebProgramlama.Attributes.AdminRoleControl] 
        public ActionResult OyuncuFilmSil(int OyuncuFilmID)
        {
            try
            {
                ent.OyuncuFilm.Remove(ent.OyuncuFilm.First(d => d.OyuncuFilmID == OyuncuFilmID));
                ent.SaveChanges();
                return RedirectToAction("OyuncuFilm", "Admin");
            }
            catch (Exception ex)
            {
                throw new Exception("Silerken hata oluştu", ex.InnerException);
            }
        }
        [WebProgramlama.Attributes.AdminRoleControl] 
        public ActionResult OyuncuFilmDuzenle(int oyuncuFilmID)
        {
            ViewBag.Oyuncu = new SelectList(ent.Oyuncu.OrderBy(x => x.Ad).ToList(), "OyuncuId", "Ad");
            ViewBag.Film = new SelectList(ent.Film.OrderBy(x => x.Ad).ToList(), "FilmId", "Ad");
            var _oyuncuFilmDuzenle = ent.OyuncuFilm.Where(x => x.OyuncuFilmID == oyuncuFilmID).FirstOrDefault();
            return View(_oyuncuFilmDuzenle);
        }


        [HttpPost]
        [WebProgramlama.Attributes.AdminRoleControl] 
        public ActionResult OyuncuFilmEkle(OyuncuFilm o)
        {
            try
            {
                OyuncuFilm _oyuncuFilm = new OyuncuFilm();
                _oyuncuFilm.FilmID = o.FilmID;
                _oyuncuFilm.OyuncuID = o.OyuncuID;

                ent.OyuncuFilm.Add(_oyuncuFilm);
                ent.SaveChanges();
                return RedirectToAction("OyuncuFilm", "Admin");
            }
            catch (Exception ex)
            {
                throw new Exception("Eklerken hata oluştu" + ex.InnerException);
            }
        }

        [HttpPost]
        [WebProgramlama.Attributes.AdminRoleControl] 
        public ActionResult oyuncuFilmDuzenle(OyuncuFilm o)
        {
            try
            {
                var _oyuncuFilmDuzenle = ent.OyuncuFilm.Where(x => x.OyuncuFilmID == o.OyuncuFilmID).FirstOrDefault();
                _oyuncuFilmDuzenle.OyuncuID = o.OyuncuID;
                _oyuncuFilmDuzenle.FilmID = o.FilmID;

                ent.SaveChanges();
                return RedirectToAction("OyuncuFilm", "Admin");
            }
            catch (Exception ex)
            {
                throw new Exception("Eklerken hata oluştu" + ex.InnerException);
            }
        }

        #endregion

        #region //FilmTur
        [WebProgramlama.Attributes.AdminRoleControl] 
        public ActionResult FilmTur()
        {
            var filmTur = ent.FilmTur.ToList();
            return View(filmTur);
        }
        [WebProgramlama.Attributes.AdminRoleControl] 

        public ActionResult FilmTurEkle()
        {
            ViewBag.Film = new SelectList(ent.Film.OrderBy(x => x.Ad).ToList(), "FilmId", "Ad");
            ViewBag.Tur = new SelectList(ent.TurTip.OrderBy(x => x.Ad).ToList(), "TurTipID", "Ad");
            return View();
        }
        [WebProgramlama.Attributes.AdminRoleControl] 
        public ActionResult FilmTurSil(int FilmTurID)
        {
            try
            {
                ent.FilmTur.Remove(ent.FilmTur.First(d => d.FilmTurID == FilmTurID));
                ent.SaveChanges();
                return RedirectToAction("FilmTur", "Admin");
            }
            catch (Exception ex)
            {
                throw new Exception("Silerken hata oluştu", ex.InnerException);
            }
        }
        [WebProgramlama.Attributes.AdminRoleControl] 
        public ActionResult FilmTurDuzenle(int FilmTurID)
        {
            ViewBag.Film = new SelectList(ent.Film.OrderBy(x => x.Ad).ToList(), "FilmId", "Ad");
            ViewBag.Tur = new SelectList(ent.TurTip.OrderBy(x => x.Ad).ToList(), "TurTipID", "Ad");
            var _filmTurDuzenle = ent.FilmTur.Where(x => x.FilmTurID == FilmTurID).FirstOrDefault();
            return View(_filmTurDuzenle);
        }

        [HttpPost]
        [WebProgramlama.Attributes.AdminRoleControl] 
        public ActionResult FilmTurEkle(FilmTur f)
        {
            try
            {
                FilmTur _filmTur = new FilmTur();
                _filmTur.FilmID = f.FilmID;
                _filmTur.TurID = f.TurID;

                ent.FilmTur.Add(_filmTur);
                ent.SaveChanges();
                return RedirectToAction("FilmTur", "Admin");
            }
            catch (Exception ex)
            {
                throw new Exception("Eklerken hata oluştu" + ex.InnerException);
            }
        }

        [HttpPost]
        [WebProgramlama.Attributes.AdminRoleControl] 
        public ActionResult FilmTurDuzenle(FilmTur f)
        {
            try
            {
                var _filmTurDuzenle = ent.FilmTur.Where(x => x.FilmTurID == f.FilmTurID).FirstOrDefault();
                _filmTurDuzenle.FilmID = f.FilmID;
                _filmTurDuzenle.TurID = f.TurID;

                ent.SaveChanges();
                return RedirectToAction("FilmTur", "Admin");
            }
            catch (Exception ex)
            {
                throw new Exception("Eklerken hata oluştu" + ex.InnerException);
            }
        }

        #endregion

        #region //Üyelik
        [WebProgramlama.Attributes.AdminRoleControl] 
        public ActionResult Uyelik()
        {
            var uyelik = ent.Uyelik.ToList();
            return View(uyelik);
        }
        [WebProgramlama.Attributes.AdminRoleControl] 
        public ActionResult UyelikEkle()
        {
            return View();
        }

        [WebProgramlama.Attributes.AdminRoleControl] 
        public ActionResult UyelikSil(int UyelikID)
        {
            try
            {
                ent.Uyelik.Remove(ent.Uyelik.First(d => d.UyelikID == UyelikID));
                ent.SaveChanges();
                return RedirectToAction("Uyelik", "Admin");
            }
            catch (Exception ex)
            {
                throw new Exception("Silerken hata oluştu", ex.InnerException);
            }

        }
        [WebProgramlama.Attributes.AdminRoleControl] 
        public ActionResult UyelikDuzenle(int UyelikID)
        {
          var _UyelikDuzenle = ent.Uyelik.Where(x => x.UyelikID == UyelikID).FirstOrDefault();
            return View(_UyelikDuzenle);
        }
   
        [HttpPost]
        [WebProgramlama.Attributes.AdminRoleControl] 
        public ActionResult UyelikEkle(Uyelik u)
        {
   
            try
            {
                Uyelik _uyelik = new Uyelik();
                _uyelik.Ad = u.Ad;
                _uyelik.Soyad = u.Soyad;
                _uyelik.Email = u.Email;
                _uyelik.Sifre = u.Sifre;
                _uyelik.Role = u.Role;
                _uyelik.Aktivasyon = u.Aktivasyon;
                _uyelik.Onay = u.Onay;
                _uyelik.KayitTarihi = u.KayitTarihi;
                ent.Uyelik.Add(_uyelik);
                ent.SaveChanges();
                return RedirectToAction("Uyelik", "Admin");
            }
            catch (Exception ex)
            {
                throw new Exception("Eklerken hata oluştu" + ex.InnerException);
            }
        }

        [HttpPost]
        [WebProgramlama.Attributes.AdminRoleControl] 
        public ActionResult UyelikDuzenle(Uyelik u)
        {
            try
            {
                var _uyelikDuzenle = ent.Uyelik.Where(x => x.UyelikID == u.UyelikID).FirstOrDefault();
                _uyelikDuzenle.Ad = u.Ad;
                _uyelikDuzenle.Soyad = u.Soyad;
                _uyelikDuzenle.Email = u.Email;
                _uyelikDuzenle.Sifre = u.Sifre;
                _uyelikDuzenle.Role = u.Role;
                _uyelikDuzenle.Aktivasyon = u.Aktivasyon;
                _uyelikDuzenle.Onay = u.Onay;
                _uyelikDuzenle.KayitTarihi = u.KayitTarihi;
                ent.SaveChanges();
                return RedirectToAction("Uyelik", "Admin");
            }
            catch (Exception ex)
            {
                throw new Exception("Güncellerken hata oluştu " + ex.Message);
            }

        }
        #endregion

    }

}