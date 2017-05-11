using Statecraft.Common.JsonModels.Requests;
using Statecraft.Services.Interfaces;
using Statecraft.Services.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Statecraft.Services.Controllers
{
    [Route("orders")]
    public class OrdersController : ApiController
    {
        private IOrdersRepository _ordersRepo;

        public OrdersController(IOrdersRepository ordersRepo)
        {
            _ordersRepo = ordersRepo;
        }


        [HttpPost]
        public HttpResponseMessage SaveOrders(SaveOrdersRequest saveOrdersRequest)
        {
            if (!ModelState.IsValid)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }

            try
            {
                _ordersRepo.SaveOrders(saveOrdersRequest.GameId, saveOrdersRequest.Orders);
            }
            catch (Exception)
            {
                //TODO: log
                throw new HttpResponseException(HttpStatusCode.InternalServerError);
            }

            return Request.CreateResponse(HttpStatusCode.Created);
        }
    }
}
