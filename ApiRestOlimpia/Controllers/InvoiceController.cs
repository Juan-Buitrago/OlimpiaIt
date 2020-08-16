using OlimpiaBusiness.Implementation.Exercise2;
using OlimpiaBusiness.Interfaces.Exercise2;
using OlimpiaInfraestructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ApiRestOlimpia.Controllers
{
    [RoutePrefix("Invoice")]
    public class InvoiceController : ApiController
    {
        #region Dependency Injection
        private readonly IInvoice _InvoiceService;
        #endregion

        public InvoiceController(IInvoice InvoiceService)
        {
            _InvoiceService = InvoiceService;
        }

        #region Méthods
        [HttpPost]
        [Route("ProcessInvoices")]
        public IHttpActionResult ProcessInvoices([FromBody] List<InvoiceModel> invoices)
        {
            return Json(_InvoiceService.ProcessInvoices(invoices));
        }

        [HttpPost]
        [Route("ValidateUniqueInvoice")]
        public IHttpActionResult ValidateUniqueInvoice([FromBody] InvoiceModel invoice)
        {
            return Json(_InvoiceService.ValidateUniqueInvoice(invoice));
        }

        [HttpPost]
        [Route("CalculateVatValue")]
        public IHttpActionResult CalculateVatValue([FromBody] InvoiceModel invoice)
        {
            return Json(_InvoiceService.CalculateVatValue(invoice));
        }
        #endregion
    }
}
