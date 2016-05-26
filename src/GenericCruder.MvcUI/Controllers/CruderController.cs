using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using ETL.GenericCruder.Core;
using ETL.GenericCruder.MvcUI.Infrastructure;
using System.Net;

namespace ETL.GenericCruder.MvcUI.Controllers
{
    //[AllowCors(Order=1)]
    //[ResponseToOptionsRequsetImmediately(Order=2)]
    public class CruderController<T> : CruderControllerBase
        where T : class, IHasId
    {
        IRepository<T> _repository;
        public CruderController(IRepository<T> repository)
        {
            _repository = repository;
        }

        public ActionResult GetAll()
        {
            IEnumerable<T> all = _repository.GetAll();
            return Json(all, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetById(int? id)
        {
            T selected = null;
            if (id.HasValue)
            {
                selected = _repository.GetById(id.Value);
            }
            return Json(selected, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Save(T entity)
        {
            StorageOperationResult result = _repository.Save(entity);
            return PrepareUpdateResult(result);
        }

        [HttpPost]
        public ActionResult SaveMany(IEnumerable<T> entities)
        {
            StorageOperationResult result;
            if (entities!=null)
            {
                result = _repository.SaveMany(entities);
            }
            else
            {
                StorageOperationError error = new StorageOperationError(0, null, "No data recieved in server for SaveMany operation.");
                result = new StorageOperationResult() { Errors = new StorageOperationError[] { error } };
            }
            return PrepareUpdateResult(result);
        }

        [HttpPost]
        public ActionResult Delete(int? id)
        {
            StorageOperationResult result;
            if (id.HasValue)
            {
                result = _repository.Delete(id.Value);
            }
            else
            {
                StorageOperationError error = new StorageOperationError(0, null, "No Id argument received in server for delete operation");
                result = new StorageOperationResult() { Errors = new StorageOperationError[] { error } };
            }
            return PrepareUpdateResult(result);
        }

        private ActionResult PrepareUpdateResult(StorageOperationResult storageResult)
        {
            HttpStatusCode status = storageResult.Errors != null && storageResult.Errors.Any() ? HttpStatusCode.BadRequest : HttpStatusCode.OK;
            Response.StatusCode = (int)status;
            return Json(storageResult);
        }
    }
}