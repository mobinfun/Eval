using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Pajoohesh.EVS.Domain;

namespace dotnetfundaAngularJS.Controllers
{
    public class MehvarController : Controller
    {
        // GET: Mehvar

        private readonly IRepository<Mehvar> _mehvarRepository = null;
        private readonly IRepository<Shakhes> _shakhesRepository = null;
        private readonly IRepository<CodeType> _codetypeRepository = null;
        private bool _success = false;
        public MehvarController()
        {
            _mehvarRepository = new Repository<Mehvar>();
            _shakhesRepository = new Repository<Shakhes>();
            _codetypeRepository = new Repository<CodeType>();
        }

        public MehvarController(IRepository<Mehvar> mehvaRepository, IRepository<CodeType> codetypeRepository, IRepository<Shakhes> shakhesRepository)
        {
            _mehvarRepository = mehvaRepository;
            _codetypeRepository = codetypeRepository;
            _shakhesRepository = shakhesRepository;
        }

        public JsonResult MehvarList()
        {

            var k = _codetypeRepository.SelectAll().Where(p => p.CodeTypeName == "EvalSystemType").ToList();
            
            List<Mehvar> mehvarlist = new List<Mehvar>();


            //string tags = string.Empty;
            try
            {
                var mehvars = _mehvarRepository.SelectAll().ToList();
                //foreach (Post post in posts)
                //{
                //    var allpostags = postagrepository.SelectAll().Where(p => p.PostId == post.PostId);
                //    foreach (var postag in allpostags)
                //    {
                //        var tagName = tagrepository.SelectAll().Where(t => t.TagId == postag.TagId).ToList();
                //        foreach (var tag in tagName)
                //        {
                //            tags = tag.Tag + ";" + tags;
                //        }
                //    }
                //    postTags.Add(new PostModel { PostId = post.PostId, Title = post.Title, Content = post.Content, Tags = tags, Author = post.Author, CreatedDate = post.CreatedDate });
                //    tags = string.Empty;
                //}
                return Json(mehvars, JsonRequestBehavior.AllowGet);

            }
            catch (Exception e)
            {
            }
            return Json(mehvarlist, JsonRequestBehavior.AllowGet);
        }

        public JsonResult SystemCodeList()
        {

            var sysCodelist = _codetypeRepository.SelectAll().Where(p => p.CodeTypeName == "EvalSystemType").ToList();

           // List<Code> sysCodelist = new List<Code>();

            
            //string tags = string.Empty;
            try
            {
                List<Code> codes = new List<Code>();
                sysCodelist = _codetypeRepository.SelectAll().Where(p => p.CodeTypeName == "EvalSystemType").ToList();
                foreach (Code post in sysCodelist[0].Code)
                {
                    codes.Add(post);
                   
                }
                return Json(codes, JsonRequestBehavior.AllowGet);

            }
            catch (Exception e)
            {
            }
            return Json(sysCodelist, JsonRequestBehavior.AllowGet);
        }


        public ActionResult Delete(string mehvaId)
        {
            try
            {
                bool success = DeleteShakesByMehvartId(Convert.ToInt32(mehvaId));
                if (success)
                {
                    _mehvarRepository.Delete(Convert.ToInt32(mehvaId));
                    _success = _mehvarRepository.Save();
                }
                return new HttpStatusCodeResult(HttpStatusCode.Created);  // OK = 200
            }
            catch
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
        }


        [NonAction]
        public bool DeleteShakesByMehvartId(int id)
        {
            try
            {
                var tags = _shakhesRepository.SelectAll().Where(t => t.MehvarId == id);
                foreach (var t in tags)
                {
                    _shakhesRepository.Delete(t.ShakhesId);
                }
                _success = _shakhesRepository.Save();
                return _success;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public ActionResult NewMehvar(Mehvar model)
        {
            try
            {
                var objmehvar = new Mehvar
                {
                    Name = model.Name,
                    PositiveModality = model.PositiveModality,
                    SystemType = model.SystemType
                    
                };
                _mehvarRepository.Insert(objmehvar);
                _success = _mehvarRepository.Save();
                return new HttpStatusCodeResult(HttpStatusCode.Created);  // OK = 200
            }
            catch
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
        }

        public JsonResult Edit(string id)
        {
           var objMehvar = new Mehvar();
            try
            {
                objMehvar = _mehvarRepository.SelectByID(Convert.ToInt64(id));
                
                return Json(objMehvar, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {

            }
            return Json(objMehvar, JsonRequestBehavior.AllowGet);
        }

        public ActionResult EditMehvar(Mehvar model)
        {
            try
            {
                var objmehvar = new Mehvar
                {
                    Name = model.Name,
                    PositiveModality = model.PositiveModality,
                    SystemType = model.SystemType,
                    MehvarId = model.MehvarId

                };
                _mehvarRepository.Update(objmehvar);
                _success = _mehvarRepository.Save();
                return new HttpStatusCodeResult(HttpStatusCode.Created);  // OK = 200
            }
            catch
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
        }



    }
}