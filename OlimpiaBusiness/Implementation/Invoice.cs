using OlimpiaBusiness.Interfaces;
using OlimpiaInfraestructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Text.RegularExpressions;

namespace OlimpiaBusiness.Implementation
{
    public class Invoice : IInvoice
    {
        #region Public Methods
        /// <summary>
        /// Método que permite validar un array de facturas para ver si cumple con las condiciones
        /// </summary>
        /// <param name="invoice">Array de tipo InvoiceModel con la información de las facturas</param>
        /// <returns>Retorna un objeto de tipo ResponseModel con el mensaje de exito o fallo en el procesamiento.</returns>
        public ResponseModel ProcessInvoices(List<InvoiceModel> ltsInvoice) {

            ResponseModel response = new ResponseModel("", true);
            try
            {
                if (ltsInvoice == null || ltsInvoice.Count == 0) {
                    throw new Exception("No existen registros para procesar");
                }

                ValidateDuplicateInvoice(ltsInvoice);
                ltsInvoice.ForEach(invoice => ValidateFields(invoice));

                response.Error = false;
                response.Message = $"El valor total de las facturas es: {ReturnTotalValueInvoices(ltsInvoice)}";

            }
            catch (Exception ex)
            {
                response.Error = true;
                response.Message = ex.Message;
            }

            return response;
        }

        /// <summary>
        /// Método que permite validar si una factura cumple con los requisitos basicos
        /// </summary>
        /// <param name="invoice">Objeto de tipo InvoiceModel con la información de la factura</param>
        /// <returns>Retorna un objeto de tipo ResponseModel con el mensaje de exito o fallo en la validacion.</returns>
        public ResponseModel ValidateUniqueInvoice(InvoiceModel invoice)
        {
            ResponseModel response = new ResponseModel("", true);
            try
            {
                if (invoice == null)
                {
                    throw new Exception("No existen una factura para procesar");
                }

                ValidateFields(invoice);
                response.Error = false;
                response.Message = "La Factura cumple con todos los parametros";

            }
            catch (Exception ex)
            {
                response.Error = true;
                response.Message = ex.Message;
            }

            return response;        
        }

        /// <summary>
        /// Método que permite calcular el valor total del iva en una factura
        /// </summary>
        /// <param name="invoice">Objeto de tipo InvoiceModel con la información de la factura</param>
        /// <returns>Retorna un objeto de tipo ResponseModel con el valor total del iva.</returns>
        public ResponseModel CalculateVatValue(InvoiceModel invoice) {

            ResponseModel response = new ResponseModel("", true);
            try
            {
                if (invoice == null)
                {
                    throw new Exception("No existen una factura para procesar");
                }

                response.Error = false;
                response.Message = $"El valor total del iva es {ReturnTotalValueWithVat(invoice)}";

            }
            catch (Exception ex)
            {
                response.Error = true;
                response.Message = ex.Message;
            }

            return response;
        }
        #endregion

        #region Private Methods
        /// <summary>
        /// Método que permite calcular el valor total del iva en una factura
        /// </summary>
        /// <param name="invoice">Objeto de tipo InvoiceModel con la información de la factura</param>
        /// <returns>Retorna un double con el valor total del iva.</returns>
        private double ReturnTotalValueWithVat(InvoiceModel invoice) {
            try {
                return (invoice.TotalValue * invoice.VatPercentage / 100);
            }
            catch (Exception)
            {
                throw new Exception($"Ocurrio un error al intentar calcular el valor total del iva en la factura {invoice.Id}");
            }
        }

        /// <summary>
        /// Método que permite calcular el valor total de un array de facturas
        /// </summary>
        /// <param name="invoice">Array de tipo InvoiceModel con la información de las facturas</param>
        /// <returns>Retorna un double con el valor total de las facturas.</returns>
        private double ReturnTotalValueInvoices(List<InvoiceModel> ltsInvoices) {
            return ltsInvoices.Sum(invoice => invoice.TotalValue);
        }

        /// <summary>
        /// Permite ejecutar todas las validaciones de los campos de una factura para indicar si cumple con los requisitos
        /// </summary>
        /// <param name="invoice">Objeto de tipo InvoiceModel con la información de la factura</param>
        /// <returns>Si algun parametro no cumple las condiciones genera una excepcion con su respectivo error.</returns>
        private void ValidateFields(InvoiceModel invoice)
        {
            if (!IdIsPositive(invoice))
            {
                throw new Exception($"El campo Id de la factura {invoice.Id} no es un numero positivo");
            }

            if (!NitIsNumeric(invoice))
            {
                throw new Exception($"El campo Nit de la factura {invoice.Id} debe ser numerico");
            }

            if (!TotalValueIsPositive(invoice)) {
                throw new Exception($"El valor total de la factura {invoice.Id} debe ser un numero positivo");
            }

            if (!ValidateVatPercentage(invoice))
            {
                throw new Exception($"El porcentaje de iva de la factura {invoice.Id} no es valido");
            }
        }

        /// <summary>
        /// Permite validar si el porcentaje de una factura se encuentra en un rango de 0 a 100
        /// </summary>
        /// <param name="invoice">Objeto de tipo InvoiceModel con la información de la factura</param>
        /// <returns>Retorna un booleano indicando si el porcentaje se encuentra dentro del rango establecido</returns>
        private bool ValidateVatPercentage(InvoiceModel invoice) {

            try
            {
                return Enumerable.Range(0, 100).Contains(invoice.VatPercentage);
            }
            catch (Exception) {
                throw new Exception($"Ocurrio un error al intentar validar el porcentaje de iva en la factura {invoice.Id}");
            }
        }

        /// <summary>
        /// Permite validar si en un array de facturas existe duplicidad
        /// </summary>
        /// <param name="invoice">Array de tipo InvoiceModel con la información de las facturas</param>
        /// <returns>Si existe duplicidad genera una excepcion.</returns>
        private void ValidateDuplicateInvoice(List<InvoiceModel> invoices) {
            
            foreach (var grouping in invoices.GroupBy(t => t.Id).Where(t => t.Count() != 1))
            {
                throw new Exception($"La factura '{grouping.Key}' existe en {grouping.Count()} veces.");
            }
            
        }

        /// <summary>
        /// Permite validar si el total de la factura es un numero positivo
        /// </summary>
        /// <param name="invoice">objeto de tipo InvoiceModel con la información de la factura</param>
        /// <returns>Retorna un booleano indicando si el valor total es positivo o no.</returns>
        private bool TotalValueIsPositive(InvoiceModel invoice)
        {
            try {
                return IsPositive(invoice.TotalValue);
            } catch (Exception)
            {
                throw new Exception($"Ocurrio un error al intentar validar el valor total de la factura {invoice.Id}");
            }
        }

        /// <summary>
        /// Permite validar si el campo Id un numero es positivo
        /// </summary>
        /// <param name="invoice">objeto de tipo InvoiceModel con la información de la factura</param>
        /// <returns>Retorna un booleano indicando si es positivo o no.</returns>
        private bool IdIsPositive(InvoiceModel invoice) {
            try {
                return IsPositive(invoice.Id);
            }
            catch (Exception) {
                throw new Exception($"Ocurrio un error al intentar validar el campo Id de la factura {invoice.Id}");
            }
        }

        /// <summary>
        /// Permite validar si un numero es positivo
        /// </summary>
        /// <param name="value">objeto de tipo double o int con el valor a validar</param>
        /// <returns>Retorna un booleano indicando si es positivo o no.</returns>
        private bool IsPositive(double value) {
            if (value > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Permite validar si el campo Nit es de tipo numerico
        /// </summary>
        /// <param name="invoice">objeto de tipo InvoiceModel con la información de la factura</param>
        /// <returns>Retorna un booleano indicando si es numerico o no el campo.</returns>
        private bool NitIsNumeric(InvoiceModel invoice) {

            try
            {
                string Pattern = "^[0-9]+$";
                Match m = Regex.Match(invoice.Nit, Pattern);
                if (m.Success) {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception) {
                throw new Exception($"Ocurrio un error al intentar validar el campo Nit de la factura {invoice.Id}");
            }

        }
        #endregion
    }
}
