using OlimpiaBusiness.Implementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OlimpiaInfraestructure.Models;

namespace OlimpiaBusiness.Interfaces
{
   public interface IInvoice
    {
        /// <summary>
        /// Método que permite validar un array de facturas para ver si cumple con las condiciones
        /// </summary>
        /// <param name="invoice">Array de tipo InvoiceModel con la información de las facturas</param>
        /// <returns>Retorna un objeto de tipo ResponseModel con el mensaje de exito o fallo en el procesamiento.</returns>
        ResponseModel ProcessInvoices(List<InvoiceModel> ltsInvoice);

        /// <summary>
        /// Método que permite validar si una factura cumple con los requisitos basicos
        /// </summary>
        /// <param name="invoice">Objeto de tipo InvoiceModel con la información de la factura</param>
        /// <returns>Retorna un objeto de tipo ResponseModel con el mensaje de exito o fallo en la validacion.</returns>
        ResponseModel ValidateUniqueInvoice(InvoiceModel invoice);

        /// <summary>
        /// Método que permite calcular el valor total del iva en una factura
        /// </summary>
        /// <param name="invoice">Objeto de tipo InvoiceModel con la información de la factura</param>
        /// <returns>Retorna un objeto de tipo ResponseModel con el valor total del iva.</returns>
        ResponseModel CalculateVatValue(InvoiceModel invoice);
    }
}
