using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using GMAT_Admin;
using GMAT_Admin.Models;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Security.AccessControl;

namespace GMAT_Admin.Controllers
{
    public class TurfImagesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: TurfImages
        public ActionResult Index()
        {
            return View(db.TurfImages.ToList());
        }

        // GET: TurfImages/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TurfImages turfImages = db.TurfImages.Find(id);
            if (turfImages == null)
            {
                return HttpNotFound();
            }
            return View(turfImages);
        }

        public Image byteArrayToImage(byte[] byteArrayIn)
        {
            MemoryStream ms = new MemoryStream(byteArrayIn);
            Image returnImage = Image.FromStream(ms);
            return returnImage;
        }

        // GET: TurfImages/Create

        [Route("Create")]
        [HttpPost]
        public ActionResult Create(TurfImages model)
        {
            HttpPostedFileBase file = Request.Files["ImageData"];
            // return null;
            //string fileName = Path.GetFileName(file.FileName);
            //Bitmap bmp = new Bitmap(file.FileName);
            ////ImageCodecInfo jpgEncoder = GetEncoder(ImageFormat.Jpeg);

            //ImageFormat format=ImageFormat.Jpeg;
            


            using (Bitmap bmp1 = new Bitmap(file.FileName))
            {

                ImageCodecInfo jpgEncoder = GetEncoder(ImageFormat.Jpeg);

                // Create an Encoder object based on the GUID  
                // for the Quality parameter category.  
                Encoder myEncoder = Encoder.Quality;

                // Create an EncoderParameters object.  
                // An EncoderParameters object has an array of EncoderParameter  
                // objects. In this case, there is only one  
                // EncoderParameter object in the array.  
                EncoderParameters myEncoderParameters = new EncoderParameters(1);

                EncoderParameter myEncoderParameter = new EncoderParameter(myEncoder, 50L);
                myEncoderParameters.Param[0] = myEncoderParameter;
                string newPath = "~/Content/Images/1";
                              
                bmp1.Save(Url.Content(@"C:\Users\Santosh\Projects\GMAT Admin\GMAT Admin\Content\Images"), jpgEncoder, myEncoderParameters);
            }
            return null;


        }

      

        public ActionResult Create()
        {
            return View();
        }

        // POST: TurfImages/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        //public ActionResult Create([Bind(Include = "Id,TurfId,ImageUrl")] TurfImages turfImages)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.TurfImages.Add(turfImages);
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }

        //    return View(turfImages);
        //}

        // GET: TurfImages/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TurfImages turfImages = db.TurfImages.Find(id);
            if (turfImages == null)
            {
                return HttpNotFound();
            }
            return View(turfImages);
        }

        // POST: TurfImages/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,TurfId,ImageUrl")] TurfImages turfImages)
        {
            if (ModelState.IsValid)
            {
                db.Entry(turfImages).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(turfImages);
        }

        // GET: TurfImages/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TurfImages turfImages = db.TurfImages.Find(id);
            if (turfImages == null)
            {
                return HttpNotFound();
            }
            return View(turfImages);
        }

        // POST: TurfImages/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TurfImages turfImages = db.TurfImages.Find(id);
            db.TurfImages.Remove(turfImages);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private ImageCodecInfo GetEncoder(ImageFormat format)
        {
            ImageCodecInfo[] codecs = ImageCodecInfo.GetImageDecoders();
            foreach (ImageCodecInfo codec in codecs)
            {
                if (codec.FormatID == format.Guid)
                {
                    return codec;
                }
            }
            return null;
        }

    }
}
