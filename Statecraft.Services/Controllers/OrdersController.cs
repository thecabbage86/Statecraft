using Statecraft.Common.DTOs;
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
                IList<OrdersDto> ordersDbos = new List<OrdersDto>();
                foreach (var order in saveOrdersRequest.Orders)
                {
                    ordersDbos.Add(order.ToDbo(saveOrdersRequest.GameId));
                }
                 
                _ordersRepo.SaveOrders(saveOrdersRequest.GameId, ordersDbos);
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
