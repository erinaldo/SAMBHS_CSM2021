﻿using SAMBHS.Common.BE;
using SAMBHS.Common.DataModel;
using SAMBHS.Common.Resource;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Linq.Dynamic;
using System.Threading.Tasks;
using SAMBHS.CommonWIN.BL;
using System.Data.Objects;
using SAMBHS.Common.BL;
using System.ComponentModel;
using System.Transactions;
namespace SAMBHS.Almacen.BL
{
    public class MovimientoBL
    {
        #region Movimiento
        string CodigoError = "";
        DateTime Fechanull = DateTime.Parse("01/01/1753");
        public List<KeyValueDTO> ObtenerListadoMovimientos(ref OperationResult pobjOperationResult, string pstringPeriodo, string pstringMes, int pintTipoMovimiento)
        {
            try
            {
                var almacenpredeterminado = Globals.ClientSession.i_IdAlmacenPredeterminado.Value.ToString("00");
                string replicationID = Globals.ClientSession.ReplicationNodeID;
                using (var dbcontext = new SAMBHSEntitiesModelWin())
                {
                    var query = (from n in dbcontext.movimiento
                                 where n.i_Eliminado == 0 && n.v_Periodo == pstringPeriodo && n.v_Mes == pstringMes &&
                                        n.i_IdTipoMovimiento == pintTipoMovimiento && n.v_IdMovimiento.Substring(2, 2) == almacenpredeterminado
                                        && n.v_IdMovimiento.Substring(0, 1) == replicationID
                                 orderby n.v_Correlativo ascending
                                 select new
                                 {
                                     n.v_Correlativo,
                                     n.v_IdMovimiento
                                 }
                         );


                    if (query.Any())
                    {
                        var query2 = query.AsEnumerable()
                                    .Select(x => new KeyValueDTO
                                    {
                                        Value1 = x.v_Correlativo,
                                        Value2 = x.v_IdMovimiento
                                    }).ToList();
                        return query2;
                    }
                    else
                    {
                        return new List<KeyValueDTO> { new KeyValueDTO { Value1 = almacenpredeterminado + "000000" } };

                    }
                }


            }
            catch (Exception)
            {

                throw;
            }
        }

        public movimientoDto ObtenerMovimientoCabecera(ref OperationResult pobjOperationResult, string pstrIdMovimiento)
        {
            try
            {
                using (var dbContext = new SAMBHSEntitiesModelWin())
                {
                    //movimientoDto objDtoEntity = null;
                    var objEntity = (from a in dbContext.movimiento

                                     join A in dbContext.cliente on new { a.v_IdCliente } equals new { A.v_IdCliente } into A_join
                                     from A in A_join.DefaultIfEmpty()
                                     join b in dbContext.clientedirecciones on new { cd = a.i_IdDireccionCliente.Value } equals new { cd = b.i_IdDireccionCliente } into b_join
                                     from b in b_join.DefaultIfEmpty()

                                     join c in dbContext.datahierarchy on new { Grupo = 161, eliminado = 0, zona = b.i_IdZona.Value } equals new { Grupo = c.i_GroupId, eliminado = c.i_IsDeleted.Value, zona = c.i_ItemId } into c_join
                                     from c in c_join.DefaultIfEmpty()

                                     where a.v_IdMovimiento == pstrIdMovimiento
                                     select new movimientoDto
                                     {
                                         d_TipoCambio = a.d_TipoCambio,
                                         i_ActualizaIdUsuario = a.i_ActualizaIdUsuario,
                                         i_Eliminado = a.i_Eliminado,
                                         i_EsDevolucion = a.i_EsDevolucion,
                                         i_IdAlmacenDestino = a.i_IdAlmacenDestino,
                                         i_IdAlmacenOrigen = a.i_IdAlmacenOrigen,
                                         i_IdMoneda = a.i_IdMoneda,
                                         i_IdTipoMotivo = a.i_IdTipoMotivo,
                                         i_IdTipoMovimiento = a.i_IdTipoMovimiento,
                                         i_InsertaIdUsuario = a.i_InsertaIdUsuario,
                                         t_ActualizaFecha = a.t_ActualizaFecha,
                                         t_Fecha = a.t_Fecha,
                                         t_InsertaFecha = a.t_InsertaFecha,
                                         v_Correlativo = a.v_Correlativo,
                                         v_Glosa = a.v_Glosa,
                                         v_IdCliente = a.v_IdCliente,
                                         v_IdMovimiento = a.v_IdMovimiento,
                                         v_Mes = a.v_Mes,
                                         v_Periodo = a.v_Periodo,
                                         d_TotalCantidad = a.d_TotalCantidad,
                                         d_TotalPrecio = a.d_TotalPrecio,
                                         v_OrigenTipo = a.v_OrigenTipo,
                                         v_OrigenRegCorrelativo = a.v_OrigenRegCorrelativo,
                                         v_OrigenRegMes = a.v_OrigenRegMes,
                                         v_OrigenRegPeriodo = a.v_OrigenRegPeriodo,
                                         v_NombreCliente = (A.v_ApePaterno + " " + A.v_ApeMaterno + " " + A.v_PrimerNombre + " " + A.v_SegundoNombre + " " + A.v_RazonSocial).Trim(),
                                         i_IdEstablecimiento = a.i_IdEstablecimiento.Value,
                                         i_IdTipoDocumento = a.i_IdTipoDocumento,
                                         v_SerieDocumento = a.v_SerieDocumento,
                                         v_CorrelativoDocumento = a.v_CorrelativoDocumento,
                                         v_NroGuiaVenta = a.v_NroGuiaVenta,
                                         v_IdMovimientoOrigen = a.v_IdMovimientoOrigen,
                                         i_IdZona = c == null ? -1 : c.i_ItemId,

                                     }
                                     ).FirstOrDefault();

                    pobjOperationResult.Success = 1;

                    return objEntity;
                }
            }
            catch (Exception ex)
            {
                pobjOperationResult.Success = 0;
                pobjOperationResult.ExceptionMessage = Utils.ExceptionFormatter(ex);
                return null;
            }
        }

        public movimientoDto ObtenerMovimientoCabeceraDesdeCompras(ref OperationResult pobjOperationResult, int pintIdAlmacen, string strTipo, string strPeriodo, string strMes, string strCorrelativo)
        {
            try
            {
                using (var dbContext = new SAMBHSEntitiesModelWin())
                {

                    var objEntity = (from a in dbContext.movimiento

                                     join A in dbContext.cliente on a.v_IdCliente equals A.v_IdCliente into A_join
                                     from A in A_join.DefaultIfEmpty()

                                     where a.i_Eliminado == 0 && a.v_OrigenTipo == strTipo && a.v_OrigenRegPeriodo == strPeriodo
                                           && a.v_OrigenRegMes == strMes && a.v_OrigenRegCorrelativo == strCorrelativo && a.i_IdAlmacenOrigen == pintIdAlmacen

                                     select new movimientoDto
                                     {
                                         d_TipoCambio = a.d_TipoCambio,
                                         i_ActualizaIdUsuario = a.i_ActualizaIdUsuario,
                                         i_Eliminado = a.i_Eliminado,
                                         i_EsDevolucion = a.i_EsDevolucion,
                                         i_IdAlmacenDestino = a.i_IdAlmacenDestino,
                                         i_IdAlmacenOrigen = a.i_IdAlmacenOrigen,
                                         i_IdMoneda = a.i_IdMoneda,
                                         i_IdTipoMotivo = a.i_IdTipoMotivo,
                                         i_IdTipoMovimiento = a.i_IdTipoMovimiento,
                                         i_InsertaIdUsuario = a.i_InsertaIdUsuario,
                                         t_ActualizaFecha = a.t_ActualizaFecha,
                                         t_Fecha = a.t_Fecha,
                                         t_InsertaFecha = a.t_InsertaFecha,
                                         v_Correlativo = a.v_Correlativo,
                                         v_Glosa = a.v_Glosa,
                                         v_IdCliente = a.v_IdCliente,
                                         v_IdMovimiento = a.v_IdMovimiento,
                                         v_Mes = a.v_Mes,
                                         v_Periodo = a.v_Periodo,
                                         d_TotalCantidad = a.d_TotalCantidad,
                                         d_TotalPrecio = a.d_TotalPrecio,
                                         v_OrigenTipo = a.v_OrigenTipo,
                                         v_OrigenRegCorrelativo = a.v_OrigenRegCorrelativo,
                                         v_OrigenRegMes = a.v_OrigenRegMes,
                                         v_OrigenRegPeriodo = a.v_OrigenRegPeriodo,
                                         v_NombreCliente = (A.v_PrimerNombre + " " + A.v_ApePaterno + " " + A.v_ApeMaterno + " " + A.v_RazonSocial).Trim(),
                                         i_IdEstablecimiento = a.i_IdEstablecimiento,
                                     }
                                     ).FirstOrDefault();

                    pobjOperationResult.Success = 1;

                    return objEntity;
                }
            }
            catch (Exception ex)
            {
                pobjOperationResult.Success = 0;
                pobjOperationResult.ExceptionMessage = Utils.ExceptionFormatter(ex);
                return null;
            }
        }

        public movimientoDto ObtenerMovimientoCabeceraDesdeImportacion(ref OperationResult pobjOperationResult, int pintIdAlmacen, string strTipo, string strPeriodo, string strMes, string strCorrelativo)
        {
            try
            {
                using (var dbContext = new SAMBHSEntitiesModelWin())
                {
                    var objEntity = (from a in dbContext.movimiento

                                     join A in dbContext.cliente on new { C = a.v_IdCliente, eliminado = 0 } equals new { C = A.v_IdCliente, eliminado = A.i_Eliminado.Value } into A_join
                                     from A in A_join.DefaultIfEmpty()

                                     where a.i_Eliminado == 0 && a.v_OrigenTipo == strTipo && a.v_OrigenRegPeriodo == strPeriodo
                                           && a.v_OrigenRegMes == strMes && a.v_OrigenRegCorrelativo == strCorrelativo && a.i_IdAlmacenOrigen == pintIdAlmacen

                                     select new movimientoDto
                                     {
                                         d_TipoCambio = a.d_TipoCambio,
                                         i_ActualizaIdUsuario = a.i_ActualizaIdUsuario,
                                         i_Eliminado = a.i_Eliminado,
                                         i_EsDevolucion = a.i_EsDevolucion,
                                         i_IdAlmacenDestino = a.i_IdAlmacenDestino,
                                         i_IdAlmacenOrigen = a.i_IdAlmacenOrigen,
                                         i_IdMoneda = a.i_IdMoneda,
                                         i_IdTipoMotivo = a.i_IdTipoMotivo,
                                         i_IdTipoMovimiento = a.i_IdTipoMovimiento,
                                         i_InsertaIdUsuario = a.i_InsertaIdUsuario,
                                         t_ActualizaFecha = a.t_ActualizaFecha,
                                         t_Fecha = a.t_Fecha,
                                         t_InsertaFecha = a.t_InsertaFecha,
                                         v_Correlativo = a.v_Correlativo,
                                         v_Glosa = a.v_Glosa,
                                         v_IdCliente = a.v_IdCliente,
                                         v_IdMovimiento = a.v_IdMovimiento,
                                         v_Mes = a.v_Mes,
                                         v_Periodo = a.v_Periodo,
                                         d_TotalCantidad = a.d_TotalCantidad,
                                         d_TotalPrecio = a.d_TotalPrecio,
                                         v_OrigenTipo = a.v_OrigenTipo,
                                         v_OrigenRegCorrelativo = a.v_OrigenRegCorrelativo,
                                         v_OrigenRegMes = a.v_OrigenRegMes,
                                         v_OrigenRegPeriodo = a.v_OrigenRegPeriodo,
                                         v_NombreCliente = A == null ? "CLIENTE NO EXISTE" : (A.v_PrimerNombre + " " + A.v_ApePaterno + " " + A.v_ApeMaterno + " " + A.v_RazonSocial).Trim(),
                                         i_IdEstablecimiento = a.i_IdEstablecimiento.Value,
                                     }
                                             ).FirstOrDefault();

                    pobjOperationResult.Success = 1;

                    return objEntity;
                }
            }
            catch (Exception ex)
            {
                pobjOperationResult.Success = 0;
                pobjOperationResult.ExceptionMessage = Utils.ExceptionFormatter(ex);
                return null;
            }
        }

        public movimientoDto ObtenerMovimientoCabeceraDesdeTransferencia(ref OperationResult pobjOperationResult, int pintIdAlmacen, string strTipo, string strPeriodo, string strMes, string strCorrelativo)
        {
            try
            {
                using (var dbContext = new SAMBHSEntitiesModelWin())
                {
                    var objEntity = (from a in dbContext.movimiento
                                     where a.i_Eliminado == 0 && a.v_OrigenTipo == strTipo && a.v_OrigenRegPeriodo == strPeriodo
                                           && a.v_OrigenRegMes == strMes && a.v_OrigenRegCorrelativo == strCorrelativo && a.i_IdAlmacenOrigen == pintIdAlmacen
                                     select new movimientoDto
                                     {
                                         d_TipoCambio = a.d_TipoCambio,
                                         i_ActualizaIdUsuario = a.i_ActualizaIdUsuario,
                                         i_Eliminado = a.i_Eliminado,
                                         i_EsDevolucion = a.i_EsDevolucion,
                                         i_IdAlmacenDestino = a.i_IdAlmacenDestino,
                                         i_IdAlmacenOrigen = a.i_IdAlmacenOrigen,
                                         i_IdMoneda = a.i_IdMoneda,
                                         i_IdTipoMotivo = a.i_IdTipoMotivo,
                                         i_IdTipoMovimiento = a.i_IdTipoMovimiento,
                                         i_InsertaIdUsuario = a.i_InsertaIdUsuario,
                                         t_ActualizaFecha = a.t_ActualizaFecha,
                                         t_Fecha = a.t_Fecha,
                                         t_InsertaFecha = a.t_InsertaFecha,
                                         v_Correlativo = a.v_Correlativo,
                                         v_Glosa = a.v_Glosa,
                                         v_IdCliente = a.v_IdCliente,
                                         v_IdMovimiento = a.v_IdMovimiento,
                                         v_Mes = a.v_Mes,
                                         v_Periodo = a.v_Periodo,
                                         d_TotalCantidad = a.d_TotalCantidad,
                                         d_TotalPrecio = a.d_TotalPrecio,
                                         v_OrigenTipo = a.v_OrigenTipo,
                                         v_OrigenRegCorrelativo = a.v_OrigenRegCorrelativo,
                                         v_OrigenRegMes = a.v_OrigenRegMes,
                                         v_OrigenRegPeriodo = a.v_OrigenRegPeriodo,
                                         v_NombreCliente = "",
                                     }
                                             ).FirstOrDefault();

                    pobjOperationResult.Success = 1;

                    return objEntity;
                }
            }
            catch (Exception ex)
            {
                pobjOperationResult.Success = 0;
                pobjOperationResult.ExceptionMessage = Utils.ExceptionFormatter(ex);
                return null;
            }
        }

        public movimientoDto ObtenerMovimientoCabeceraDesdeTransferenciaporId(ref OperationResult pobjOperationResult, string IdMovimientoOrigen, int TipoMovimiento)
        {
            try
            {
                using (var dbContext = new SAMBHSEntitiesModelWin())
                {
                    var objEntity = (from a in dbContext.movimiento
                                     where a.i_Eliminado == 0 && a.v_IdMovimientoOrigen == IdMovimientoOrigen && a.i_IdTipoMovimiento == TipoMovimiento
                                     select new movimientoDto
                                     {
                                         d_TipoCambio = a.d_TipoCambio,
                                         i_ActualizaIdUsuario = a.i_ActualizaIdUsuario,
                                         i_Eliminado = a.i_Eliminado,
                                         i_EsDevolucion = a.i_EsDevolucion,
                                         i_IdAlmacenDestino = a.i_IdAlmacenDestino,
                                         i_IdAlmacenOrigen = a.i_IdAlmacenOrigen,
                                         i_IdMoneda = a.i_IdMoneda,
                                         i_IdTipoMotivo = a.i_IdTipoMotivo,
                                         i_IdTipoMovimiento = a.i_IdTipoMovimiento,
                                         i_InsertaIdUsuario = a.i_InsertaIdUsuario,
                                         t_ActualizaFecha = a.t_ActualizaFecha,
                                         t_Fecha = a.t_Fecha,
                                         t_InsertaFecha = a.t_InsertaFecha,
                                         v_Correlativo = a.v_Correlativo,
                                         v_Glosa = a.v_Glosa,
                                         v_IdCliente = a.v_IdCliente,
                                         v_IdMovimiento = a.v_IdMovimiento,
                                         v_Mes = a.v_Mes,
                                         v_Periodo = a.v_Periodo,
                                         d_TotalCantidad = a.d_TotalCantidad,
                                         d_TotalPrecio = a.d_TotalPrecio,
                                         v_OrigenTipo = a.v_OrigenTipo,
                                         v_OrigenRegCorrelativo = a.v_OrigenRegCorrelativo,
                                         v_OrigenRegMes = a.v_OrigenRegMes,
                                         v_OrigenRegPeriodo = a.v_OrigenRegPeriodo,
                                         v_NombreCliente = "",
                                         v_IdMovimientoOrigen = a.v_IdMovimientoOrigen,
                                     }
                                             ).FirstOrDefault();

                    pobjOperationResult.Success = 1;

                    return objEntity;
                }
            }
            catch (Exception ex)
            {
                pobjOperationResult.Success = 0;
                pobjOperationResult.ExceptionMessage = Utils.ExceptionFormatter(ex);
                return null;
            }
        }


        public BindingList<GridmovimientodetalleDto> ObtenerMovimientoDetalles(ref OperationResult pobjOperationResult, string pstrMovimientoId)
        {
            try
            {
                using (var dbContext = new SAMBHSEntitiesModelWin())
                {

                    var periodo = Globals.ClientSession.i_Periodo.ToString();
                    //var ProductoAlmacen = dbContext.productoalmacen.Where(o => o.i_Eliminado == 0 && o.v_Periodo == periodo).ToList();
                    var query = (from m in dbContext.movimiento
                                 join n in dbContext.movimientodetalle on m.v_IdMovimiento equals n.v_IdMovimiento into n_join
                                 from n in n_join.DefaultIfEmpty()

                                 join J1 in dbContext.productodetalle on n.v_IdProductoDetalle equals J1.v_IdProductoDetalle into
                                 J1_join
                                 from J1 in J1_join.DefaultIfEmpty()

                                 join J2 in dbContext.producto on J1.v_IdProducto equals J2.v_IdProducto into J2_join
                                 from J2 in J2_join.DefaultIfEmpty()


                                 join J4 in dbContext.datahierarchy on new { a = J2.i_IdUnidadMedida.Value, b = 17 }
                                 equals new { a = J4.i_ItemId, b = J4.i_GroupId } into J4_join
                                 from J4 in J4_join.DefaultIfEmpty()
                                 where n.i_Eliminado == 0 && n.v_IdMovimiento == pstrMovimientoId
                                 orderby n.v_IdMovimientoDetalle

                                 select new GridmovimientodetalleDto
                                 {
                                     v_IdProductoDetalle = n.v_IdProductoDetalle,
                                     v_NroGuiaRemision = n.v_NroGuiaRemision,
                                     i_IdTipoDocumento = n.i_IdTipoDocumento,
                                     v_NumeroDocumento = n.v_NumeroDocumento,
                                     d_Cantidad = n.d_Cantidad,
                                     i_IdUnidad = n.i_IdUnidad,
                                     d_Precio = n.d_Precio,
                                     d_Total = n.d_Total,
                                     v_NroPedido = n.v_NroPedido,
                                     d_CantidadEmpaque = n.d_CantidadEmpaque,
                                     v_CodigoInterno = J2.v_CodInterno,
                                     v_NombreProducto = J2.v_Descripcion,
                                     UMEmpaque = J4.v_Value1,
                                     Empaque = J2.d_Empaque,
                                     i_IdUnidadMedidaProducto = J2.i_IdUnidadMedida,
                                     v_IdMovimientoDetalle = n.v_IdMovimientoDetalle,
                                     v_IdMovimientoDetalleTransferencia = n.v_IdMovimientoDetalleTransferencia,
                                     v_IdMovimiento = m.v_IdMovimiento,
                                     i_Eliminado = m.i_Eliminado,
                                     i_InsertaIdUsuario = m.i_InsertaIdUsuario,
                                     t_InsertaFecha = m.t_InsertaFecha.Value,
                                     EsServicio = J2.i_EsServicio,
                                     i_EsProductoFinal = n.i_EsProductoFinal ?? 0,
                                     i_ValidarStock = J2.i_ValidarStock ?? 0,
                                     i_IdCentroCosto = n.i_IdCentroCosto,
                                     


                                     i_SolicitarNroLoteIngreso = J2.i_SolicitarNroLoteIngreso ?? 0,
                                     i_SolicitarNroSerieIngreso = J2.i_SolicitarNroSerieIngreso ?? 0,
                                     i_SolicitaOrdenProduccionIngreso = J2.i_SolicitaOrdenProduccionIngreso ?? 0,
                                     i_SolicitarNroSerieSalida = J2.i_SolicitarNroSerieSalida ?? 0,
                                     i_SolicitarNroLoteSalida = J2.i_SolicitarNroLoteSalida ?? 0,
                                     i_SolicitaOrdenProduccionSalida = J2.i_SolicitaOrdenProduccionSalida ?? 0,

                                     v_NroLote = n.v_NroLote,
                                     v_NroSerie = n.v_NroSerie,
                                     t_FechaCaducidad = n.t_FechaCaducidad==null ? Fechanull : n.t_FechaCaducidad.Value ,
                                     v_NroOrdenProduccion =n.v_NroOrdenProduccion ,

                                 }
                    ).ToList();


                    //Select(o =>
                    //     {
                    //decimal Stock =0;
                    //try
                    //{
                    //var letNroPedido =
                    //    Globals.ClientSession.i_IncluirPedidoExportacionCompraVenta == 1
                    //    ? o.v_NroPedido == null ? null : o.v_NroPedido.Trim() != "" ? o.v_NroPedido : null
                    //        : null;
                    // var DatosProductoAlmacen = Globals.ClientSession.i_IncluirPedidoExportacionCompraVenta == 1 ? ProductoAlmacen.Where(p => p.i_IdAlmacen == o.i_IdAlmacenOrigen && p.v_ProductoDetalleId == o.v_IdProductoDetalle && o.v_NroPedido == letNroPedido).ToList()
                    //          : ProductoAlmacen.Where(p => p.i_IdAlmacen == o.i_IdAlmacenOrigen && p.v_ProductoDetalleId == o.v_IdProductoDetalle).ToList();
                    //Stock = DatosProductoAlmacen.Any() ? DatosProductoAlmacen.Sum(x => x.d_StockActual).Value : 0;
                    //}
                    //catch (Exception ex)
                    //{
                    //    Stock = 0;
                    //}
                    //        return new GridmovimientodetalleDto
                    //{

                    //    v_IdProductoDetalle = o.v_IdProductoDetalle,
                    //    v_NroGuiaRemision = o.v_NroGuiaRemision,
                    //    i_IdTipoDocumento = o.i_IdTipoDocumento,
                    //    v_NumeroDocumento = o.v_NumeroDocumento,
                    //    d_Cantidad = o.d_Cantidad,
                    //    i_IdUnidad = o.i_IdUnidad,
                    //    d_Precio = o.d_Precio,
                    //    d_Total = o.d_Total,
                    //    v_NroPedido = o.v_NroPedido,
                    //    d_CantidadEmpaque = o.d_CantidadEmpaque,
                    //    v_CodigoInterno = o.v_CodigoInterno,
                    //    v_NombreProducto = o.v_NombreProducto,
                    //    UMEmpaque = o.UMEmpaque,
                    //    Empaque = o.Empaque,
                    //    i_IdUnidadMedidaProducto = o.i_IdUnidadMedidaProducto,
                    //    v_IdMovimientoDetalle = o.v_IdMovimientoDetalle,
                    //    v_IdMovimientoDetalleTransferencia = o.v_IdMovimientoDetalleTransferencia,
                    //    v_IdMovimiento = o.v_IdMovimiento,
                    //    i_Eliminado = o.i_Eliminado,
                    //    i_InsertaIdUsuario = o.i_InsertaIdUsuario,
                    //    t_InsertaFecha = o.t_InsertaFecha,
                    //    StockActual = Stock,
                    //    EsServicio = o.EsServicio,
                    //    i_EsProductoFinal = o.i_EsProductoFinal,
                    //    i_ValidarStock = o.i_ValidarStock,
                    //    i_IdCentroCosto = o.i_IdCentroCosto,


                    //};
                    //    }).ToList();

                    var Result = new BindingList<GridmovimientodetalleDto>(query);
                    pobjOperationResult.Success = 1;

                    return Result;
                }
            }
            catch (Exception ex)
            {
                pobjOperationResult.Success = 0;
                pobjOperationResult.ExceptionMessage = Utils.ExceptionFormatter(ex);
                return null;
            }
        }

        public BindingList<GridmovimientodetalleDto> ObtenerMovimientoDetallesIngresos(ref OperationResult pobjOperationResult, string pstrMovimientoId)
        {
            try
            {

                using (var dbContext = new SAMBHSEntitiesModelWin())
                {

                    var query = (from m in dbContext.movimientodetalle

                                 join J1 in dbContext.productodetalle on m.v_IdProductoDetalle equals J1.v_IdProductoDetalle into J1_join
                                 from J1 in J1_join.DefaultIfEmpty()

                                 join J2 in dbContext.producto on J1.v_IdProducto equals J2.v_IdProducto into J2_join
                                 from J2 in J2_join.DefaultIfEmpty()

                                 join J4 in dbContext.datahierarchy on new { a = J2.i_IdUnidadMedida.Value, b = 17 }
                                     equals new { a = J4.i_ItemId, b = J4.i_GroupId } into J4_join
                                 from J4 in J4_join.DefaultIfEmpty()

                                 where m.i_Eliminado == 0 && m.v_IdMovimiento == pstrMovimientoId
                                 orderby m.v_IdMovimientoDetalle

                                 select new GridmovimientodetalleDto
                                 {
                                     v_IdProductoDetalle = m.v_IdProductoDetalle,
                                     v_NroGuiaRemision = m.v_NroGuiaRemision,
                                     i_IdTipoDocumento = m.i_IdTipoDocumento,
                                     v_NumeroDocumento = m.v_NumeroDocumento,
                                     d_Cantidad = m.d_Cantidad,
                                     i_IdUnidad = m.i_IdUnidad,
                                     d_Precio = m.d_Precio,
                                     d_Total = m.d_Total,
                                     v_NroPedido = m.v_NroPedido,
                                     d_CantidadEmpaque = m.d_CantidadEmpaque,
                                     v_CodigoInterno = J2.v_CodInterno.Trim(),
                                     v_NombreProducto = J2.v_Descripcion.Trim(),
                                     UMEmpaque = J4.v_Value1,
                                     Empaque = J2.d_Empaque,
                                     i_IdUnidadMedidaProducto = J2.i_IdUnidadMedida,
                                     v_IdMovimientoDetalle = m.v_IdMovimientoDetalle,
                                     v_IdMovimientoDetalleTransferencia = m.v_IdMovimientoDetalleTransferencia,
                                     v_IdMovimiento = m.v_IdMovimiento,
                                     i_Eliminado = m.i_Eliminado,
                                     i_InsertaIdUsuario = m.i_InsertaIdUsuario,
                                     t_InsertaFecha = m.t_InsertaFecha.Value,
                                     EsServicio = J2.i_EsServicio,
                                     i_EsProductoFinal = m.i_EsProductoFinal ?? 0,
                                     i_RegistroTipo = "NoTemporal",
                                     i_IdCentroCosto = m.i_IdCentroCosto,
                                     v_NroSerie = m.v_NroSerie,
                                     v_NroLote = m.v_NroLote,
                                     i_SolicitarNroLoteIngreso = J2.i_SolicitarNroLoteIngreso ?? 0,
                                     i_SolicitarNroSerieIngreso = J2.i_SolicitarNroSerieIngreso ?? 0,
                                     i_SolicitaOrdenProduccionIngreso = J2.i_SolicitaOrdenProduccionIngreso ?? 0,
                                     t_FechaCaducidad = m.t_FechaCaducidad,
                                     t_FechaFabricacion = m.t_FechaFabricacion,
                                     v_NroOrdenProduccion =m.v_NroOrdenProduccion ,

                                 }
                        ).ToList();

                    var result = new BindingList<GridmovimientodetalleDto>(query);

                    pobjOperationResult.Success = 1;

                    return result;
                }
            }
            catch (Exception ex)
            {
                pobjOperationResult.Success = 0;
                pobjOperationResult.ExceptionMessage = Utils.ExceptionFormatter(ex);
                return null;
            }
        }

        public BindingList<movimientodetallerecetafinalDto> ObtenerRecetasFinales(
            ref OperationResult pobjOperationResult, string pstrMovimientoId)
        {
            try
            {
                using (var dbContext = new SAMBHSEntitiesModelWin())
                {
                    var consulta = (from n in dbContext.movimientodetallerecetafinal
                                    join J1 in dbContext.productodetalle on n.v_IdProdInsumo equals J1.v_IdProductoDetalle into
                                        J1_join
                                    from J1 in J1_join.DefaultIfEmpty()
                                    join J2 in dbContext.producto on J1.v_IdProducto equals J2.v_IdProducto into J2_join
                                    from J2 in J2_join.DefaultIfEmpty()
                                    where n.i_Eliminado == 0 && n.v_IdMovimiento.Equals(pstrMovimientoId)
                                    select new movimientodetallerecetafinalDto
                                    {
                                        CodigoInsumo = J2.v_CodInterno,
                                        Foto = J2.b_Foto,
                                        i_ActualizaIdUsuario = n.i_ActualizaIdUsuario,
                                        i_Eliminado = n.i_Eliminado,
                                        i_InsertaIdUsuario = n.i_InsertaIdUsuario,
                                        NombreInsumo = J2.v_Descripcion,
                                        t_ActualizaFecha = n.t_ActualizaFecha,
                                        t_InsertaFecha = n.t_InsertaFecha,
                                        v_IdMovimiento = n.v_IdMovimiento,
                                        v_IdProdInsumo = n.v_IdProdInsumo,
                                        v_IdProdTerminado = n.v_IdProdTerminado,
                                        v_IdRecetaFinal = n.v_IdRecetaFinal,
                                        d_Cantidad = n.d_Cantidad ?? 0,
                                        i_IdAlmacen = n.i_IdAlmacen ?? 1
                                    }).ToList();

                    return new BindingList<movimientodetallerecetafinalDto>(consulta.ToList());

                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<string[]> DevolverNombres(string pstringIdMovimiento, int IdAlmacen)
        {
            using (var dbContext = new SAMBHSEntitiesModelWin())
            {
                var periodo = Globals.ClientSession.i_Periodo.ToString();
                var query = (from n in dbContext.productodetalle

                             join A in dbContext.producto on n.v_IdProducto equals A.v_IdProducto into A_join
                             from A in A_join.DefaultIfEmpty()

                             join J4 in dbContext.datahierarchy on new { a = A.i_IdUnidadMedida.Value, b = 17 }
                             equals new { a = J4.i_ItemId, b = J4.i_GroupId } into J4_join
                             from J4 in J4_join.DefaultIfEmpty()

                             join J5 in dbContext.movimientodetalle on n.v_IdProductoDetalle equals J5.v_IdProductoDetalle into J5_join
                             from J5 in J5_join.DefaultIfEmpty()

                             join B in dbContext.productoalmacen on new { IdProductoDetalle = n.v_IdProductoDetalle, eliminado = 0, _periodo = periodo }
                             equals new { IdProductoDetalle = B.v_ProductoDetalleId, eliminado = B.i_Eliminado.Value, _periodo = B.v_Periodo } into B_join
                             from B in B_join.DefaultIfEmpty().Where(p => p.i_IdAlmacen == IdAlmacen)

                             where J5.v_IdMovimiento == pstringIdMovimiento && J5.i_Eliminado == 0
                             select new
                             {
                                 v_IdProductoDetalle = n.v_IdProductoDetalle,
                                 Nombre = A.v_Descripcion,
                                 CodigoInterno = A.v_CodInterno,
                                 StockActual = B.d_StockActual,
                                 EmpaqueUnidadMedida = J4.v_Value1,
                                 d_Empaque = A.d_Empaque,
                                 UnidadMedida = A.i_IdUnidadMedida
                             }
                ).ToList();

                if (query.Any())
                {
                    List<string[]> Lista = new List<string[]>();
                    foreach (var Fila in query.OrderByDescending(p => p.v_IdProductoDetalle).AsParallel())
                    {
                        string[] Cadena = new string[7];
                        Cadena[0] = Fila.CodigoInterno;
                        Cadena[1] = Fila.Nombre;
                        Cadena[2] = Fila.StockActual.ToString();
                        Cadena[3] = Fila.EmpaqueUnidadMedida;
                        Cadena[4] = Fila.d_Empaque.ToString();
                        Cadena[5] = Fila.v_IdProductoDetalle;
                        Cadena[6] = Fila.UnidadMedida.ToString();
                        Lista.Add(Cadena);
                    }
                    return Lista;
                }
                return null;
            }
        }

        public string[] DevolverNombresProductoAlmacen(string pstringIdProductoDetalle, int idAlmacen)
        {
            using (var dbContext = new SAMBHSEntitiesModelWin())
            {
                var periodo = Globals.ClientSession.i_Periodo.ToString();
                var query = (from n in dbContext.productodetalle

                             join B in dbContext.productoalmacen on new { pd = n.v_IdProductoDetalle, eliminado = 0, _periodo = periodo } equals new { pd = B.v_ProductoDetalleId, eliminado = B.i_Eliminado.Value, _periodo = B.v_Periodo } into B_join
                             from B in B_join.DefaultIfEmpty()

                             join A in dbContext.producto on n.v_IdProducto equals A.v_IdProducto into A_join
                             from A in A_join.DefaultIfEmpty()

                             join J4 in dbContext.datahierarchy on new { a = A.i_IdUnidadMedida.Value, b = 17 }
                             equals new { a = J4.i_ItemId, b = J4.i_GroupId } into J4_join
                             from J4 in J4_join.DefaultIfEmpty()

                             where n.v_IdProductoDetalle == pstringIdProductoDetalle & B.i_IdAlmacen == idAlmacen

                             select new
                             {
                                 Nombre = A.v_Descripcion,
                                 CodigoInterno = A.v_CodInterno,
                                 StockActual = B == null ? 0 : B.d_StockActual == null ? 0 : B.d_StockActual,
                                 EmpaqueUnidadMedida = J4.v_Value1,
                                 d_Empaque = A.d_Empaque.Value,
                                 EsServicio = A.i_EsServicio,
                                 i_idUnidadMedidaProducto = A.i_IdUnidadMedida.Value
                             }
                ).FirstOrDefault();
                if (query != null)
                {
                    string[] Cadena = new string[7];
                    Cadena[0] = query.CodigoInterno;
                    Cadena[1] = query.Nombre;
                    Cadena[2] = query.StockActual.ToString();
                    Cadena[3] = query.EmpaqueUnidadMedida;
                    Cadena[4] = query.d_Empaque.ToString();
                    Cadena[5] = query.EsServicio.ToString();
                    Cadena[6] = query.i_idUnidadMedidaProducto.ToString();
                    return Cadena;
                }
                return null;
            }
        }

        public string InsertarMovimiento(ref OperationResult pobjOperationResult, movimientoDto pobjDtoEntity, List<string> ClientSession, List<movimientodetalleDto> pTemp_Insertar)
        {
            int i = 1;
            string error = "";
            try
            {
                using (var ts = TransactionUtils.CreateTransactionScope())
                {

                    using (var dbContext = new SAMBHSEntitiesModelWin())
                    {


                       
                        dbContext.movimiento.MergeOption = MergeOption.NoTracking;
                        dbContext.movimientodetalle.MergeOption = MergeOption.NoTracking;
                        SecuentialBL objSecuentialBL = new SecuentialBL();
                        movimiento objEntityMovimiento = movimientoAssembler.ToEntity(pobjDtoEntity);
                        MovimientoBL _objMovimientoBL = new MovimientoBL();
                        movimientoDto _movimientoCabeceraNIDto = new movimientoDto();
                        movimientoDto _movimientoCabeceraNSDto = new movimientoDto();
                        movimientodetalleDto _movimientodetallenNIDto = new movimientodetalleDto();
                        List<movimientodetalleDto> _movimientodetalleDtos = new List<movimientodetalleDto>();
                        List<movimientodetalleDto> objEntityMovimientoDetalleNS = new List<movimientodetalleDto>();
                        List<movimientodetalleDto> objEntityMovimientoDetalleNI = new List<movimientodetalleDto>();
                        List<KeyValueDTO> ListaMovimientos = new List<KeyValueDTO>();
                        int SecuentialId = 0;
                        string newIdMovimiento = string.Empty;
                        string newIdMovimientoDetalle = string.Empty;

                        #region Inserta Cabecera
                        objEntityMovimiento.t_InsertaFecha = DateTime.Now;
                        objEntityMovimiento.i_InsertaIdUsuario = Int32.Parse(ClientSession[2]);
                        objEntityMovimiento.i_Eliminado = 0;

                        var intNodeId = int.Parse(ClientSession[0]);
                        SecuentialId = objSecuentialBL.GetNextSecuentialId(intNodeId, 28);
                        newIdMovimiento = Utils.GetNewId(int.Parse(ClientSession[0]), SecuentialId, "MO");
                        objEntityMovimiento.v_IdMovimiento = newIdMovimiento;
                        dbContext.AddTomovimiento(objEntityMovimiento);
                        dbContext.SaveChanges();
                        #endregion

                        #region Inserta Detalles
                        List<KardexList> StockValorizado = new List<KardexList>();
                        if (pobjDtoEntity.i_IdTipoMovimiento == (int)TipoDeMovimiento.Transferencia) // Valorizo todos los productos
                        {
                            var IdEstablecimiento = BuscarIdEstablecimiento(pobjDtoEntity.i_IdAlmacenDestino.Value).i_IdEstablecimiento;
                            List<string> Filters = new List<string>();
                            string strFilter = "", CodigosProductos = "";
                            Filters.Add("IdAlmacen==" + pobjDtoEntity.i_IdAlmacenOrigen.ToString());
                            var fecha = objEntityMovimiento.t_Fecha.Value;
                            foreach (var item in pTemp_Insertar)
                            {
                                CodigosProductos = CodigosProductos + "CodProducto==" + "\"" + item.CodigoProducto + "\"" + " || ";
                            }
                            CodigosProductos = CodigosProductos.Substring(0, CodigosProductos.Length - 4);
                            Filters.Add("(" + (CodigosProductos ?? CodigosProductos) + ")");
                            strFilter = string.Join(" && ", Filters);
                            StockValorizado = new AlmacenBL().ReporteStock(ref pobjOperationResult, IdEstablecimiento, DateTime.Parse("01/01/" + Globals.ClientSession.i_Periodo.ToString()), DateTime.Parse(fecha.Date.Day.ToString() + "/" + fecha.Date.Month.ToString() + "/" + fecha.Date.Year.ToString() + " 23:59"), strFilter, pobjDtoEntity.i_IdMoneda.Value, "", "", "-1", 0, 0, 0, 0, 1, 2, "", DateTime.Now, 0);
                            if (pobjOperationResult.Success == 0) return null;
                        }
                        
                        foreach (movimientodetalleDto movimientodetalleDto in pTemp_Insertar)
                        {
                            movimientodetalle objEntityMovimientoDetalle = movimientodetalleAssembler.ToEntity(movimientodetalleDto);
                            SecuentialId = objSecuentialBL.GetNextSecuentialId(intNodeId, 29);
                            newIdMovimientoDetalle = Utils.GetNewId(int.Parse(ClientSession[0]), SecuentialId, "MT");
                            objEntityMovimientoDetalle.v_IdMovimientoDetalle = newIdMovimientoDetalle;
                            objEntityMovimientoDetalle.v_IdMovimiento = newIdMovimiento;
                            objEntityMovimientoDetalle.t_InsertaFecha = DateTime.Now;
                            objEntityMovimientoDetalle.i_InsertaIdUsuario = Int32.Parse(ClientSession[2]);
                            objEntityMovimientoDetalle.i_Eliminado = 0;
                            dbContext.AddTomovimientodetalle(objEntityMovimientoDetalle);
                            switch (objEntityMovimiento.i_IdTipoMovimiento)
                            {
                                case (int)Common.Resource.TipoDeMovimiento.NotadeIngreso:
                                    ProcesarMovimientoIngresoDetalle(ref pobjOperationResult, pobjDtoEntity.i_IdAlmacenOrigen.Value, objEntityMovimientoDetalle.ToDTO(), ClientSession);
                                    if (pobjOperationResult.Success == 0) return null;
                                    break;
                            }
                            if (pobjDtoEntity.i_IdTipoMovimiento == (int)Common.Resource.TipoDeMovimiento.Transferencia)
                            {
                                _movimientodetallenNIDto = new movimientodetalleDto();
                                _movimientodetallenNIDto.v_IdProductoDetalle = movimientodetalleDto.v_IdProductoDetalle.Trim();
                                _movimientodetallenNIDto.i_IdTipoDocumento = movimientodetalleDto.i_IdTipoDocumento;
                                _movimientodetallenNIDto.v_NumeroDocumento = movimientodetalleDto.v_NumeroDocumento;
                                _movimientodetallenNIDto.d_Cantidad = movimientodetalleDto.d_Cantidad;
                                _movimientodetallenNIDto.i_IdUnidad = movimientodetalleDto.i_IdUnidad;
                                _movimientodetallenNIDto.v_NroGuiaRemision = movimientodetalleDto.v_NroGuiaRemision;
                                //var PrecioAnterioresCompras = BuscarPrecioMovimientos(_movimientodetallenNIDto.v_IdProductoDetalle, objEntityMovimiento.t_Fecha.Value, BuscarIdEstablecimiento(pobjDtoEntity.i_IdAlmacenDestino.Value).i_IdEstablecimiento, pobjDtoEntity.i_IdAlmacenOrigen.Value, pobjDtoEntity.i_IdMoneda.Value);
                                var PrecioAnterioresCompras = BuscarPrecioMovimientosII(_movimientodetallenNIDto.v_IdProductoDetalle, StockValorizado);
                                _movimientodetallenNIDto.d_Precio = Utils.Windows.DevuelveValorRedondeado(PrecioAnterioresCompras, Globals.ClientSession.i_PrecioDecimales.Value);
                                _movimientodetallenNIDto.d_Total = Utils.Windows.DevuelveValorRedondeado(_movimientodetallenNIDto.d_Cantidad.Value * _movimientodetallenNIDto.d_Precio.Value, 2);
                                _movimientodetallenNIDto.v_NroPedido = movimientodetalleDto.v_NroPedido;
                                _movimientodetallenNIDto.v_IdMovimientoDetalleTransferencia = newIdMovimientoDetalle;
                                _movimientodetallenNIDto.d_CantidadEmpaque = movimientodetalleDto.d_CantidadEmpaque;
                                objEntityMovimientoDetalleNI.Add(_movimientodetallenNIDto);

                                var _movsalida = new movimientodetalleDto();
                                _movsalida = (movimientodetalleDto)_movimientodetallenNIDto.Clone();
                                _movsalida.d_Precio = movimientodetalleDto.d_Precio.Value;
                                _movsalida.d_Total = Utils.Windows.DevuelveValorRedondeado(_movsalida.d_Precio.Value * _movsalida.d_Cantidad.Value, 2);
                                objEntityMovimientoDetalleNS.Add(_movsalida);
                            }
                            error = movimientodetalleDto.v_IdProductoDetalle;
                            i = i + 1;


                        }
                        if (pobjDtoEntity.i_IdTipoMovimiento == (int)Common.Resource.TipoDeMovimiento.Transferencia)
                        {
                            #region Inserta CabeceraNotaIngreso
                            _movimientodetalleDtos = new List<movimientodetalleDto>();

                            int MaxMovimiento;
                            if ((pTemp_Insertar.Find(p => p.EsServicio == 0) != null))
                            {
                                ListaMovimientos = new List<KeyValueDTO>();
                                ListaMovimientos = _objMovimientoBL.ObtenerListadoMovimientos(ref pobjOperationResult, pobjDtoEntity.v_Periodo, pobjDtoEntity.v_Mes, (int)TipoDeMovimiento.NotadeIngreso);
                                MaxMovimiento = ListaMovimientos.Any() ? int.Parse(ListaMovimientos[ListaMovimientos.Count() - 1].Value1.ToString()) : 0;
                                _movimientoCabeceraNIDto = new movimientoDto();
                                MaxMovimiento++;
                                _movimientoCabeceraNIDto.d_TipoCambio = pobjDtoEntity.d_TipoCambio;
                                _movimientoCabeceraNIDto.i_IdAlmacenOrigen = pobjDtoEntity.i_IdAlmacenDestino;
                                _movimientoCabeceraNIDto.i_IdMoneda = pobjDtoEntity.i_IdMoneda;
                                _movimientoCabeceraNIDto.i_IdTipoMotivo = 15;//Importación
                                _movimientoCabeceraNIDto.t_Fecha = pobjDtoEntity.t_Fecha;
                                _movimientoCabeceraNIDto.v_Mes = pobjDtoEntity.v_Mes.Trim();
                                _movimientoCabeceraNIDto.v_Periodo = pobjDtoEntity.v_Periodo.Trim();
                                _movimientoCabeceraNIDto.i_IdTipoMovimiento = (int)TipoDeMovimiento.NotadeIngreso;
                                _movimientoCabeceraNIDto.v_Correlativo = MaxMovimiento.ToString("00000000");
                                _movimientoCabeceraNIDto.v_IdCliente = null;
                                _movimientoCabeceraNIDto.v_OrigenTipo = "T";
                                _movimientoCabeceraNIDto.i_EsDevolucion = 0;
                                _movimientoCabeceraNIDto.v_OrigenRegCorrelativo = pobjDtoEntity.v_Correlativo;
                                _movimientoCabeceraNIDto.v_OrigenRegMes = pobjDtoEntity.v_Mes;
                                _movimientoCabeceraNIDto.v_OrigenRegPeriodo = pobjDtoEntity.v_Periodo;
                                _movimientoCabeceraNIDto.d_TotalCantidad = _movimientodetalleDtos.Sum(p => p.d_Cantidad.Value);
                                _movimientoCabeceraNIDto.d_TotalPrecio = _movimientodetalleDtos.Sum(p => p.d_Total.Value);

                                var NuevoEstablecimiento = BuscarIdEstablecimiento(pobjDtoEntity.i_IdAlmacenDestino.Value);

                                _movimientoCabeceraNIDto.i_IdEstablecimiento = NuevoEstablecimiento.i_IdEstablecimiento;

                                var NuevoEstab = BuscarIdEstablecimiento(pobjDtoEntity.i_IdAlmacenOrigen.Value);
                                _movimientoCabeceraNIDto.v_Glosa = " TRANSFERENCIA DE " + NuevoEstab.NombreAlmacen;

                            }


                            #endregion

                            #region Inserta CabeceraNotaSalida
                            if ((pTemp_Insertar.Find(p => p.EsServicio == 0) != null))
                            {
                                ListaMovimientos = new List<KeyValueDTO>();
                                ListaMovimientos = _objMovimientoBL.ObtenerListadoMovimientos(ref pobjOperationResult, pobjDtoEntity.v_Periodo, pobjDtoEntity.v_Mes, (int)TipoDeMovimiento.NotadeSalida);
                                MaxMovimiento = ListaMovimientos.Any() ? int.Parse(ListaMovimientos[ListaMovimientos.Count() - 1].Value1.ToString()) : 0;
                                _movimientoCabeceraNSDto = new movimientoDto();
                                MaxMovimiento++;
                                _movimientoCabeceraNSDto.d_TipoCambio = pobjDtoEntity.d_TipoCambio;
                                _movimientoCabeceraNSDto.i_IdAlmacenOrigen = pobjDtoEntity.i_IdAlmacenOrigen;
                                _movimientoCabeceraNSDto.i_IdAlmacenDestino = pobjDtoEntity.i_IdAlmacenDestino;
                                _movimientoCabeceraNSDto.i_IdMoneda = pobjDtoEntity.i_IdMoneda;
                                _movimientoCabeceraNSDto.i_IdTipoMotivo = 16;//Compra nacional
                                _movimientoCabeceraNSDto.t_Fecha = pobjDtoEntity.t_Fecha;
                                _movimientoCabeceraNSDto.v_Mes = pobjDtoEntity.v_Mes.Trim();
                                _movimientoCabeceraNSDto.v_Periodo = pobjDtoEntity.v_Periodo.Trim();
                                _movimientoCabeceraNSDto.i_IdTipoMovimiento = (int)TipoDeMovimiento.NotadeSalida;
                                _movimientoCabeceraNSDto.v_Correlativo = MaxMovimiento.ToString("00000000");
                                _movimientoCabeceraNSDto.v_IdCliente = pobjDtoEntity.v_IdCliente;
                                _movimientoCabeceraNSDto.v_OrigenTipo = "T";
                                _movimientoCabeceraNSDto.i_EsDevolucion = 0;
                                _movimientoCabeceraNSDto.v_OrigenRegCorrelativo = pobjDtoEntity.v_Correlativo;
                                _movimientoCabeceraNSDto.v_OrigenRegMes = pobjDtoEntity.v_Mes;
                                _movimientoCabeceraNSDto.v_OrigenRegPeriodo = pobjDtoEntity.v_Periodo;
                                _movimientoCabeceraNSDto.d_TotalPrecio = pobjDtoEntity.d_TotalPrecio;
                                _movimientoCabeceraNSDto.i_IdEstablecimiento = pobjDtoEntity.i_IdEstablecimiento;
                                _movimientoCabeceraNSDto.i_IdTipoDocumento = pobjDtoEntity.i_IdTipoDocumento;
                                _movimientoCabeceraNSDto.v_SerieDocumento = pobjDtoEntity.v_SerieDocumento;
                                _movimientoCabeceraNSDto.v_CorrelativoDocumento = pobjDtoEntity.v_CorrelativoDocumento;

                                var NuevoEstablecimiento = BuscarIdEstablecimiento(pobjDtoEntity.i_IdAlmacenDestino.Value);
                                _movimientoCabeceraNSDto.v_Glosa = " TRANSFERENCIA A " + NuevoEstablecimiento.NombreAlmacen;

                            }
                            #endregion

                            _movimientoCabeceraNIDto.d_TotalCantidad = objEntityMovimientoDetalleNI.Sum(p => p.d_Cantidad.Value);
                            _movimientoCabeceraNIDto.d_TotalPrecio = objEntityMovimientoDetalleNI.Sum(p => p.d_Total.Value);
                            _movimientoCabeceraNSDto.d_TotalCantidad = objEntityMovimientoDetalleNS.Sum(p => p.d_Cantidad.Value);
                            _movimientoCabeceraNSDto.d_TotalPrecio = objEntityMovimientoDetalleNS.Sum(p => p.d_Total.Value);
                            _movimientoCabeceraNIDto.v_IdMovimientoOrigen = newIdMovimiento;
                            _movimientoCabeceraNSDto.v_IdMovimientoOrigen = newIdMovimiento;

                            _objMovimientoBL.InsertarMovimiento(ref pobjOperationResult, _movimientoCabeceraNIDto, Globals.ClientSession.GetAsList(), objEntityMovimientoDetalleNI); //Inserta Nota Ingreso
                            if (pobjOperationResult.Success == 0) return null;
                            _objMovimientoBL.InsertarMovimiento(ref pobjOperationResult, _movimientoCabeceraNSDto, Globals.ClientSession.GetAsList(), objEntityMovimientoDetalleNS);//Inserta Nota Salida
                            if (pobjOperationResult.Success == 0) return null;
                        }
                        dbContext.SaveChanges();
                        #endregion

                        

                        switch (objEntityMovimiento.i_IdTipoMovimiento)
                        {
                            case (int)TipoDeMovimiento.NotadeSalida:
                                ProcesarMovimientoSalida(ref pobjOperationResult, newIdMovimiento, ClientSession);
                                if (pobjOperationResult.Success == 0) return null;
                                break;

                            case (int)TipoDeMovimiento.Transferencia:
                                break;
                        }

                        if (pobjOperationResult.Success == 0) return null;

                        if (objEntityMovimiento.i_IdTipoMovimiento == 1) ActualizarCostoSegunUltimoMovimiento(ref pobjOperationResult, objEntityMovimiento.ToDTO(), pTemp_Insertar);
                        if (pobjOperationResult.Success == 0) return null;
                        pobjOperationResult.Success = 1;
                        ts.Complete();
                        return newIdMovimiento;
                    }
                }

            }
            catch (Exception ex)
            {
                pobjOperationResult.Success = 0;
                pobjOperationResult.AdditionalInformation = "MovimientoBL.InsertarMovimiento()" + "Información adicional :" + error + " i :" + i.ToString();
                pobjOperationResult.ErrorMessage = ex.Message;
                pobjOperationResult.ExceptionMessage = ex.InnerException != null ? ex.InnerException.Message : string.Empty;
                Utils.ExceptionToLog(Globals.ClientSession.i_SystemUserId, pobjOperationResult);
                return null;
            }
        }

        public decimal BuscarPrecioMovimientos_(string IdProductoDetalle, DateTime fecha, int Establecimiento, int Almacen, int MonedaOperacion)
        {


            using (SAMBHSEntitiesModelWin dbContext = new SAMBHSEntitiesModelWin())
            {
                DateTime fechaInicio = DateTime.Parse("01/01/" + Globals.ClientSession.i_Periodo.ToString());
                fecha = fecha.Date;

                //Se agrego que tambien los movimientos pueden ser ventas
                //se hace una valorizacion 
                List<movimientodetalleDto> NI = (
                          from a in dbContext.movimiento

                          join b in dbContext.movimientodetalle on new { MovDetalle = a.v_IdMovimiento, eliminado = 0 } equals new { MovDetalle = b.v_IdMovimiento, eliminado = b.i_Eliminado.Value } into b_join

                          from b in b_join.DefaultIfEmpty()

                          where
                          a.i_IdTipoMovimiento == (int)Common.Resource.TipoDeMovimiento.NotadeIngreso
                          && b.v_IdProductoDetalle == IdProductoDetalle && a.i_Eliminado == 0
                          && (a.v_OrigenTipo == "C" || a.v_OrigenTipo == null || a.v_OrigenTipo == "" || a.v_OrigenTipo == "I")
                          && b.d_Precio != 0
                          && a.i_IdAlmacenOrigen == Almacen
                          && a.i_IdEstablecimiento == Establecimiento && a.i_Eliminado == 0

                          orderby a.t_Fecha.Value
                          select new movimientodetalleDto
                          {


                              d_Precio = b == null ? 0 : b.d_Precio == null ? 0 : a.i_IdMoneda == (int)Currency.Soles ? b.d_Precio * b.d_Cantidad : b.d_Precio * a.d_TipoCambio * b.d_Cantidad,
                              d_PrecioCambio = b == null ? 0 : a.i_IdMoneda == (int)Currency.Dolares ? b.d_Precio * b.d_Cantidad : a.d_TipoCambio == 0 ? 0 : (b.d_Precio / a.d_TipoCambio) * b.d_Cantidad,   //Precio Dolares
                              t_ActualizaFecha = a.t_Fecha,
                              v_IdMovimiento = a.v_IdMovimiento,
                              i_IdTipoDocumento = b.i_IdTipoDocumento.Value,
                              v_NumeroDocumento = b.v_NumeroDocumento,
                              d_Cantidad = b.d_Cantidad.Value,
                              i_Eliminado = a.i_IdTipoMovimiento.Value,
                              i_IdUnidad = a.i_IdTipoMotivo,

                          }).ToList();

                if (NI.Any())
                {
                    NI = NI.Where(x => x.t_ActualizaFecha.Value.Date <= fecha).OrderBy(x => x.i_IdTipoDocumento).ThenBy(x => x.v_NumeroDocumento).OrderBy(x => x.t_ActualizaFecha.Value.Date).ToList();
                    if (NI.Any())
                    {

                        var Cantidad = NI.Sum(l => l.d_Cantidad).Value;
                        return MonedaOperacion == (int)Currency.Soles ? Cantidad == 0 ? 0 : Utils.Windows.DevuelveValorRedondeado(NI.Sum(x => x.d_Precio).Value / NI.Sum(l => l.d_Cantidad).Value, 6) : Cantidad == 0 ? 0 : Utils.Windows.DevuelveValorRedondeado(NI.Average(x => x.d_PrecioCambio).Value / NI.Sum(l => l.d_Cantidad).Value, 6);

                    }
                    else
                    {
                        return 0;
                    }
                }
                else
                {
                    return 0;
                }
            }



        }


        //public decimal BuscarPrecioMovimientos(string IdProductoDetalle, DateTime fecha, int Establecimiento, int Almacen, int MonedaOperacion)// Antes del 10 de Octubre
        //{
        //    OperationResult objOperationResult = new OperationResult();
        //    var jj = new ProductoBL().ObtenerProductoDesdeProdDetalle(ref  objOperationResult, IdProductoDetalle);
        //    var codProducto = jj.v_CodInterno;
        //    List<KardexList> aptitudeCertificate = new AlmacenBL().ReporteStock(ref objOperationResult, Establecimiento, DateTime.Parse("01/01/" + Globals.ClientSession.i_Periodo.ToString()), DateTime.Parse(fecha.Date.Day.ToString() + "/" + fecha.Date.Month.ToString() + "/" + fecha.Date.Year.ToString() + " 23:59"), "IdAlmacen==" + Almacen.ToString(), MonedaOperacion, codProducto.Trim(), "", "-1", 0, 0, 0, 0, 1, 2, "", DateTime.Now, 0);
        //    if (aptitudeCertificate.Any())
        //    {
        //        return Utils.Windows.DevuelveValorRedondeado(aptitudeCertificate.LastOrDefault().Salida_Precio ?? 0, 6);
        //    }
        //    else
        //    {
        //        return 0;
        //    }


        //}

        public decimal BuscarPrecioMovimientosII(string IdProductoDetalle, List<KardexList> StockValorizado) //10 octubre del 2017
        {
            OperationResult objOperationResult = new OperationResult();
            var ProdStockValorizado = StockValorizado.Where(o => o.v_IdProductoDetalle == IdProductoDetalle).LastOrDefault();
            if (ProdStockValorizado != null)
            {
                return Utils.Windows.DevuelveValorRedondeado(ProdStockValorizado.Saldo_Precio ?? 0, 6);
            }
            else
            {
                return 0;
            }


        }

        public EstablecimientoNuevo BuscarIdEstablecimiento(int IdAlmacenDestino)
        {
            int IdAlmacen = -1;
            EstablecimientoNuevo Estab = new EstablecimientoNuevo();
            using (SAMBHSEntitiesModelWin dbContext = new SAMBHSEntitiesModelWin())
            {


                var Almacen = (from a in dbContext.establecimientoalmacen
                               join b in dbContext.almacen on new { IdAlmacen = a.i_IdAlmacen.Value, eliminado = 0 } equals new { IdAlmacen = b.i_IdAlmacen, eliminado = b.i_Eliminado.Value } into b_join
                               from b in b_join.DefaultIfEmpty()
                               where a.i_Eliminado == 0 && a.i_IdAlmacen == IdAlmacenDestino

                               select new EstablecimientoNuevo
                               {
                                   i_IdEstablecimiento = a.i_IdEstablecimiento.Value,
                                   NombreAlmacen = b.v_Nombre,
                               }).FirstOrDefault();

                return Almacen;
            }
        }

        public void InsertarCargaInicial(ref OperationResult pobjOperationResult, movimientoDto pobjDtoEntity, List<string> ClientSession, List<movimientodetalleDto> pTemp_Insertar)
        {
            try
            {
                using (TransactionScope ts = TransactionUtils.CreateTransactionScope())
                {
                    SAMBHSEntitiesModelWin dbContext = new SAMBHSEntitiesModelWin();
                    dbContext.movimiento.MergeOption = System.Data.Objects.MergeOption.NoTracking;
                    dbContext.movimientodetalle.MergeOption = System.Data.Objects.MergeOption.NoTracking;
                    SecuentialBL objSecuentialBL = new SecuentialBL();
                    movimiento objEntityMovimiento = movimientoAssembler.ToEntity(pobjDtoEntity);
                    movimientodetalleDto pobjDtoMovimientoDetalle = new movimientodetalleDto();
                    MovimientoBL _objMovimientoBL = new MovimientoBL();
                    movimientoDto _movimientoDto = new movimientoDto();
                    movimientoDto _movimientoCabeceraNIDto = new movimientoDto();
                    movimientoDto _movimientoCabeceraNSDto = new movimientoDto();
                    movimientodetalleDto _movimientodetalleDto = new movimientodetalleDto();
                    movimientodetalleDto _movimientodetallenNIDto = new movimientodetalleDto();
                    List<movimientodetalleDto> _movimientodetalleDtos = new List<movimientodetalleDto>();
                    List<movimientodetalleDto> objEntityMovimientoDetalleNS = new List<movimientodetalleDto>();
                    List<movimientodetalleDto> objEntityMovimientoDetalleNI = new List<movimientodetalleDto>();
                    List<KeyValueDTO> ListaMovimientos = new List<KeyValueDTO>();
                    int SecuentialId = 0;
                    string newIdMovimiento = string.Empty;
                    string newIdMovimientoDetalle = string.Empty;
                    int intNodeId;


                    #region Inserta Cabecera
                    objEntityMovimiento.t_InsertaFecha = DateTime.Now;
                    objEntityMovimiento.i_InsertaIdUsuario = Int32.Parse(ClientSession[2]);
                    objEntityMovimiento.i_Eliminado = 0;

                    intNodeId = int.Parse(ClientSession[0]);
                    SecuentialId = objSecuentialBL.GetNextSecuentialId(intNodeId, 28);
                    newIdMovimiento = Utils.GetNewId(int.Parse(ClientSession[0]), SecuentialId, "MO");
                    objEntityMovimiento.v_IdMovimiento = newIdMovimiento;
                    dbContext.AddTomovimiento(objEntityMovimiento);
                    dbContext.SaveChanges();
                    #endregion

                    #region Inserta Detalles

                    foreach (movimientodetalleDto movimientodetalleDto in pTemp_Insertar)
                    {
                        movimientodetalle objEntityMovimientoDetalle = movimientodetalleAssembler.ToEntity(movimientodetalleDto);
                        SecuentialId = objSecuentialBL.GetNextSecuentialId(intNodeId, 29);
                        newIdMovimientoDetalle = Utils.GetNewId(int.Parse(ClientSession[0]), SecuentialId, "MT");
                        objEntityMovimientoDetalle.v_IdMovimientoDetalle = newIdMovimientoDetalle;
                        objEntityMovimientoDetalle.v_IdMovimiento = newIdMovimiento;
                        objEntityMovimientoDetalle.t_InsertaFecha = DateTime.Now;
                        objEntityMovimientoDetalle.i_InsertaIdUsuario = Int32.Parse(ClientSession[2]);
                        objEntityMovimientoDetalle.i_Eliminado = 0;
                        dbContext.AddTomovimientodetalle(objEntityMovimientoDetalle);

                    }

                    #endregion
                    dbContext.SaveChanges();
                    pobjOperationResult.Success = 1;
                    Utils.Windows.GeneraHistorial(LogEventType.CREACION, Globals.ClientSession.v_UserName, "movimiento", newIdMovimiento);
                    ts.Complete();
                    return;
                }

            }
            catch (Exception ex)
            {
                pobjOperationResult.Success = 0;
                pobjOperationResult.AdditionalInformation = "MovimientoBL.InsertarMovimiento()";
                pobjOperationResult.ErrorMessage = ex.Message;
                pobjOperationResult.ExceptionMessage = ex.InnerException != null ? ex.InnerException.Message : string.Empty;
                Utils.ExceptionToLog(Globals.ClientSession.i_SystemUserId, pobjOperationResult);
                return;
            }
        }

        public string ObtenerIdMovimientoDetalleGuiaRemision(string pstrIdMovimiento, string IdProductoDetalle)
        {
            SAMBHSEntitiesModelWin dbContext = new SAMBHSEntitiesModelWin();

            var query = (from n in dbContext.movimientodetalle

                         where n.i_Eliminado == 0 && n.v_IdMovimiento == pstrIdMovimiento && n.v_IdProductoDetalle == IdProductoDetalle

                         select new { n.v_IdMovimientoDetalle }).FirstOrDefault();
            return query != null ? query.v_IdMovimientoDetalle : null;

        }

        public string ObtenerIdMovimientoDetalle(string pstrIdMovimiento, string pstrIdMovimientoDetalleTransferencia)
        {
            SAMBHSEntitiesModelWin dbContext = new SAMBHSEntitiesModelWin();

            var query = (from n in dbContext.movimientodetalle

                         where n.i_Eliminado == 0 && n.v_IdMovimiento == pstrIdMovimiento && n.v_IdMovimientoDetalleTransferencia == pstrIdMovimientoDetalleTransferencia

                         select new { n.v_IdMovimientoDetalle }).FirstOrDefault();
            return query.v_IdMovimientoDetalle;

        }

        public string ObtenerIdMovimientoDetalle_(string pstrIdMovimiento, string pstrIdMovimientoDetalleTransferencia)
        {
            SAMBHSEntitiesModelWin dbContext = new SAMBHSEntitiesModelWin();

            var query = (from n in dbContext.movimientodetalle

                         where n.i_Eliminado == 0 && n.v_IdMovimiento == pstrIdMovimiento && n.v_IdMovimientoDetalleTransferencia == pstrIdMovimientoDetalleTransferencia

                         select new { n.v_IdMovimientoDetalle }).FirstOrDefault();
            return query.v_IdMovimientoDetalle;

        }

        public string ObtenerIdMovimientoDetalleTransferencia(string pstrIdMovimiento, string pstrIdMovimientoDetalle)
        {
            SAMBHSEntitiesModelWin dbContext = new SAMBHSEntitiesModelWin();

            var query = (from n in dbContext.movimientodetalle

                         where n.i_Eliminado == 0 && n.v_IdMovimientoDetalle == pstrIdMovimientoDetalle

                         select new { n.v_IdMovimientoDetalleTransferencia }).FirstOrDefault();
            return query.v_IdMovimientoDetalleTransferencia;

        }

        public void ActualizarMovimiento(ref OperationResult pobjOperationResult, movimientoDto pobjDtoEntity, List<string> ClientSession, List<movimientodetalleDto> pTemp_Insertar, List<movimientodetalleDto> pTemp_Editar, List<movimientodetalleDto> pTemp_Eliminar)
        {
            try
            {
                using (TransactionScope ts = TransactionUtils.CreateTransactionScope())
                {
                    using (SAMBHSEntitiesModelWin dbContext = new SAMBHSEntitiesModelWin())
                    {
                        SecuentialBL objSecuentialBL = new SecuentialBL();
                        movimiento objEntityMovimiento = movimientoAssembler.ToEntity(pobjDtoEntity);
                        movimientodetalleDto pobjDtoMovimientoDetalle = new movimientodetalleDto();

                        movimientodetalleDto _movimientodetalleNIDto = new movimientodetalleDto();
                        movimientodetalleDto _movimientodetalleNSDto = new movimientodetalleDto();
                        List<movimientodetalleDto> objEntityMovimientoDetalleNI = new List<movimientodetalleDto>();
                        List<movimientodetalleDto> objEntityMovimientoDetalleNS = new List<movimientodetalleDto>();
                        List<movimientodetalleDto> objEntityMovimientoDetalleNI_Editar = new List<movimientodetalleDto>();
                        List<movimientodetalleDto> objEntityMovimientoDetalleNS_Editar = new List<movimientodetalleDto>();
                        List<movimientodetalleDto> objEntityMovimientoDetalleNI_Eliminar = new List<movimientodetalleDto>();
                        List<movimientodetalleDto> objEntityMovimientoDetalleNS_Eliminar = new List<movimientodetalleDto>();

                        movimientodetalleDto objMovimientoDetalleDtoNI = new movimientodetalleDto();
                        movimientodetalleDto objMovimientoDetalleDtoNS = new movimientodetalleDto();

                        MovimientoBL _objMovimientoBL = new MovimientoBL();
                        OperationResult objOperationResult = new OperationResult();
                        movimientoDto _movimientoCabeceraNIDto = new movimientoDto();
                        movimientoDto _movimientoCabeceraNSDto = new movimientoDto();
                        bool ActualizarPrecio = false;
                        bool PrecioyaseActualizo = false;
                        string IdMovDetalle = string.Empty;
                        DateTime fecha = DateTime.Now, Newfecha = DateTime.Now;
                        // movimientodetalleDto movimientoDetalleDtoNI = new movimientodetalleDto();
                        // movimientodetalleDto movimientoDetalleDtoNS = new movimientodetalleDto();
                        int SecuentialId = 0;
                        string newIdMovimientoDetalle = string.Empty;
                        int intNodeId;
                        List<KardexList> StockValorizado = new List<KardexList>();
                        #region Actualiza Cabecera

                        switch (pobjDtoEntity.i_IdTipoMovimiento)
                        {
                            case (int)Common.Resource.TipoDeMovimiento.NotadeIngreso:
                                if (pobjDtoEntity.i_EsDevolucion == 1)
                                {
                                    RevertirMovimientoIngreso(ref pobjOperationResult, pobjDtoEntity.v_IdMovimiento, ClientSession);
                                }
                                break;

                            case (int)Common.Resource.TipoDeMovimiento.NotadeSalida:
                                if (pobjDtoEntity.i_EsDevolucion == 1)
                                {
                                    RevertirMovimientoSalida(ref pobjOperationResult, pobjDtoEntity.v_IdMovimiento, ClientSession);
                                }
                                break;
                        }

                        intNodeId = int.Parse(ClientSession[0]);
                        var objEntitySource = (from a in dbContext.movimiento
                                               where a.v_IdMovimiento == pobjDtoEntity.v_IdMovimiento
                                               select a).FirstOrDefault();

                        if (pobjDtoEntity.i_IdTipoMovimiento == (int)Common.Resource.TipoDeMovimiento.Transferencia)
                        {

                            fecha = objEntitySource.t_Fecha.Value.Date;
                            Newfecha = pobjDtoEntity.t_Fecha.Value.Date;
                            ActualizarPrecio = fecha == Newfecha ? false : true;

                        }
                        pobjDtoEntity.t_ActualizaFecha = DateTime.Now;
                        pobjDtoEntity.i_ActualizaIdUsuario = Int32.Parse(ClientSession[2]);

                        movimiento objEntity = movimientoAssembler.ToEntity(pobjDtoEntity);
                        dbContext.movimiento.ApplyCurrentValues(objEntity);



                        #endregion

                        #region Actualiza CabeceraNotaIngreso - Salida
                        if (pobjDtoEntity.i_IdTipoMovimiento == (int)Common.Resource.TipoDeMovimiento.Transferencia)
                        {


                            var IdEstablecimiento = BuscarIdEstablecimiento(pobjDtoEntity.i_IdAlmacenDestino.Value).i_IdEstablecimiento;
                            List<string> Filters = new List<string>();
                            string strFilter = "", ListaCodigosProductos = "";
                            Filters.Add("IdAlmacen==" + pobjDtoEntity.i_IdAlmacenOrigen.ToString());
                            var fechaT = objEntityMovimiento.t_Fecha.Value;
                            var NuevosProductos = pTemp_Insertar.Concat(pTemp_Editar).ToList();
                            foreach (var item in NuevosProductos)
                            {
                                var CodigoProducto = new ProductoBL().ObtenerProductoDesdeProdDetalle(ref  objOperationResult, item.v_IdProductoDetalle);
                                ListaCodigosProductos = ListaCodigosProductos + "CodProducto==" + "\"" + CodigoProducto.v_CodInterno.Trim () + "\"" + " || ";
                            }
                            if (!string.IsNullOrEmpty(ListaCodigosProductos))
                            {
                                ListaCodigosProductos = ListaCodigosProductos.Substring(0, ListaCodigosProductos.Length - 4);
                                Filters.Add("(" + (ListaCodigosProductos ?? ListaCodigosProductos) + ")");
                                strFilter = string.Join(" && ", Filters);
                                StockValorizado = new AlmacenBL().ReporteStock(ref pobjOperationResult, IdEstablecimiento, DateTime.Parse("01/01/" + Globals.ClientSession.i_Periodo.ToString()), DateTime.Parse(fechaT.Date.Day.ToString() + "/" + fechaT.Date.Month.ToString() + "/" + fechaT.Date.Year.ToString() + " 23:59"), strFilter, pobjDtoEntity.i_IdMoneda.Value, "", "", "-1", 0, 0, 0, 0, 1, 2, "", DateTime.Now, 0);
                                if (pobjOperationResult.Success == 0) return;
                            }
                            
                            _movimientoCabeceraNIDto = new movimientoDto();
                            _movimientoCabeceraNIDto = _objMovimientoBL.ObtenerMovimientoCabeceraDesdeTransferenciaporId(ref objOperationResult, pobjDtoEntity.v_IdMovimiento, (int)TipoDeMovimiento.NotadeIngreso);
                            if (_movimientoCabeceraNIDto != null)
                            {
                                _movimientoCabeceraNIDto.d_TipoCambio = pobjDtoEntity.d_TipoCambio;
                                _movimientoCabeceraNIDto.i_IdAlmacenOrigen = pobjDtoEntity.i_IdAlmacenDestino;
                                _movimientoCabeceraNIDto.i_IdMoneda = pobjDtoEntity.i_IdMoneda;
                                _movimientoCabeceraNIDto.t_Fecha = pobjDtoEntity.t_Fecha;
                                _movimientoCabeceraNIDto.v_Mes = pobjDtoEntity.v_Mes;
                                _movimientoCabeceraNIDto.i_EsDevolucion = 0;
                                _movimientoCabeceraNIDto.v_IdCliente = null;

                                var NuevoEstab = BuscarIdEstablecimiento(pobjDtoEntity.i_IdAlmacenDestino.Value);
                                _movimientoCabeceraNIDto.i_IdEstablecimiento = NuevoEstab.i_IdEstablecimiento;


                                _movimientoCabeceraNIDto.v_OrigenRegCorrelativo = pobjDtoEntity.v_Correlativo;
                                _movimientoCabeceraNIDto.v_OrigenRegMes = pobjDtoEntity.v_Mes;
                                _movimientoCabeceraNIDto.v_OrigenRegPeriodo = pobjDtoEntity.v_Periodo;

                            }

                            _movimientoCabeceraNSDto = new movimientoDto();
                            //_movimientoCabeceraNSDto = _objMovimientoBL.ObtenerMovimientoCabeceraDesdeTransferencia(ref objOperationResult, pobjDtoEntity.i_IdAlmacenOrigen.Value, "T", pobjDtoEntity.v_AnioGuardado, pobjDtoEntity.v_MesGuardado, pobjDtoEntity.v_CorrelativoGuardado);
                            _movimientoCabeceraNSDto = _objMovimientoBL.ObtenerMovimientoCabeceraDesdeTransferenciaporId(ref objOperationResult, pobjDtoEntity.v_IdMovimiento, (int)TipoDeMovimiento.NotadeSalida);
                            if (_movimientoCabeceraNSDto != null)
                            {
                                //_EsNotadeCredito = cboDocumento.Value.ToString() == "7" | cboDocumento.Value.ToString() == "8" ? true : false;
                                _movimientoCabeceraNSDto.d_TipoCambio = pobjDtoEntity.d_TipoCambio;
                                _movimientoCabeceraNSDto.i_IdAlmacenOrigen = pobjDtoEntity.i_IdAlmacenOrigen;
                                _movimientoCabeceraNSDto.i_IdMoneda = pobjDtoEntity.i_IdMoneda;
                                _movimientoCabeceraNSDto.t_Fecha = pobjDtoEntity.t_Fecha;
                                _movimientoCabeceraNSDto.v_Mes = pobjDtoEntity.v_Mes;
                                _movimientoCabeceraNSDto.i_EsDevolucion = 0;
                                _movimientoCabeceraNSDto.v_IdCliente = null;
                                _movimientoCabeceraNSDto.i_IdEstablecimiento = pobjDtoEntity.i_IdEstablecimiento;

                                _movimientoCabeceraNSDto.v_OrigenRegCorrelativo = pobjDtoEntity.v_Correlativo;
                                _movimientoCabeceraNSDto.v_OrigenRegMes = pobjDtoEntity.v_Mes;
                                _movimientoCabeceraNSDto.v_OrigenRegPeriodo = pobjDtoEntity.v_Periodo;
                            }
                        }

                        #endregion

                        #region Actualiza Detalle

                        #region Temporales Insertar

                        foreach (movimientodetalleDto movimientodetalleDto in pTemp_Insertar)
                        {
                            movimientodetalle objEntityMovimientoDetalle = movimientodetalleAssembler.ToEntity(movimientodetalleDto);
                            SecuentialId = objSecuentialBL.GetNextSecuentialId(intNodeId, 29);
                            newIdMovimientoDetalle = Utils.GetNewId(int.Parse(ClientSession[0]), SecuentialId, "MT");
                            objEntityMovimientoDetalle.v_IdMovimientoDetalle = newIdMovimientoDetalle;
                            objEntityMovimientoDetalle.t_InsertaFecha = DateTime.Now;
                            objEntityMovimientoDetalle.i_InsertaIdUsuario = Int32.Parse(ClientSession[2]);
                            objEntityMovimientoDetalle.i_Eliminado = 0;
                            dbContext.AddTomovimientodetalle(objEntityMovimientoDetalle);

                            if (pobjDtoEntity.i_IdTipoMovimiento == (int)Common.Resource.TipoDeMovimiento.Transferencia)
                            {
                                #region NotaIngreso
                                _movimientodetalleNIDto = new movimientodetalleDto();
                                _movimientodetalleNIDto.v_IdProductoDetalle = movimientodetalleDto.v_IdProductoDetalle.Trim();
                                _movimientodetalleNIDto.i_IdTipoDocumento = movimientodetalleDto.i_IdTipoDocumento;
                                _movimientodetalleNIDto.v_NumeroDocumento = movimientodetalleDto.v_NumeroDocumento;
                                _movimientodetalleNIDto.d_Cantidad = movimientodetalleDto.d_Cantidad;
                                _movimientodetalleNIDto.i_IdUnidad = movimientodetalleDto.i_IdUnidad;
                                _movimientodetalleNIDto.v_NroGuiaRemision = movimientodetalleDto.v_NroGuiaRemision;
                                //var PrecioAnterioresCompras=BuscarPrecioMovimientos(_movimientodetalleNIDto.v_IdProductoDetalle, objEntityMovimiento.t_Fecha.Value, BuscarIdEstablecimiento(pobjDtoEntity.i_IdAlmacenDestino.Value).i_IdEstablecimiento, pobjDtoEntity.i_IdAlmacenOrigen.Value, pobjDtoEntity.i_IdMoneda.Value);
                                 var PrecioAnterioresCompras = BuscarPrecioMovimientosII(_movimientodetalleNIDto.v_IdProductoDetalle, StockValorizado); 
                                _movimientodetalleNIDto.d_Precio = PrecioAnterioresCompras;
                                _movimientodetalleNIDto.d_Total = Utils.Windows.DevuelveValorRedondeado(_movimientodetalleNIDto.d_Cantidad.Value * _movimientodetalleNIDto.d_Precio.Value, 2);
                                _movimientodetalleNIDto.v_NroPedido = movimientodetalleDto.v_NroPedido;
                                _movimientodetalleNIDto.v_IdMovimientoDetalleTransferencia = newIdMovimientoDetalle;
                                _movimientodetalleNIDto.v_IdMovimiento = _movimientoCabeceraNIDto.v_IdMovimiento;
                                _movimientodetalleNIDto.d_CantidadEmpaque = movimientodetalleDto.d_CantidadEmpaque;
                                #endregion
                                #region NotaSalida
                                _movimientodetalleNSDto = new movimientodetalleDto();
                                _movimientodetalleNSDto.v_IdProductoDetalle = movimientodetalleDto.v_IdProductoDetalle.Trim();
                                _movimientodetalleNSDto.i_IdTipoDocumento = movimientodetalleDto.i_IdTipoDocumento;
                                _movimientodetalleNSDto.v_NumeroDocumento = movimientodetalleDto.v_NumeroDocumento;
                                _movimientodetalleNSDto.d_Cantidad = movimientodetalleDto.d_Cantidad;
                                _movimientodetalleNSDto.i_IdUnidad = movimientodetalleDto.i_IdUnidad;
                                _movimientodetalleNSDto.d_Precio = movimientodetalleDto.d_Precio;
                                //_movimientodetalleNSDto.d_Total = movimientodetalleDto.d_Cantidad * movimientodetalleDto.d_Precio;
                                _movimientodetalleNSDto.d_Total = Utils.Windows.DevuelveValorRedondeado(_movimientodetalleNSDto.d_Precio.Value * _movimientodetalleNSDto.d_Cantidad.Value, 2);

                                _movimientodetalleNSDto.v_NroPedido = movimientodetalleDto.v_NroPedido;
                                _movimientodetalleNSDto.v_IdMovimientoDetalleTransferencia = newIdMovimientoDetalle;
                                _movimientodetalleNSDto.v_IdMovimiento = _movimientoCabeceraNSDto.v_IdMovimiento;
                                _movimientodetalleNSDto.d_Cantidad = movimientodetalleDto.d_Cantidad;
                                _movimientodetalleNSDto.d_CantidadEmpaque = movimientodetalleDto.d_CantidadEmpaque;
                                #endregion
                                objEntityMovimientoDetalleNI.Add(_movimientodetalleNIDto);
                                objEntityMovimientoDetalleNS.Add(_movimientodetalleNSDto);

                            }

                            dbContext.SaveChanges();

                            switch (pobjDtoEntity.i_IdTipoMovimiento)
                            {
                                case (int)Common.Resource.TipoDeMovimiento.NotadeIngreso:
                                    ProcesarMovimientoIngresoDetalle(ref pobjOperationResult, pobjDtoEntity.i_IdAlmacenOrigen.Value, movimientodetalleDto, ClientSession);
                                    break;
                                case (int)Common.Resource.TipoDeMovimiento.NotadeSalida:
                                    ProcesarMovimientoSalidaDetalle(ref pobjOperationResult, pobjDtoEntity.i_IdAlmacenOrigen.Value, movimientodetalleDto, ClientSession);
                                    break;
                                case (int)Common.Resource.TipoDeMovimiento.Transferencia:

                                    break;
                            }



                        }
                        #endregion

                        #region Temporales Editar
                        int i = 0;
                        foreach (movimientodetalleDto movimientodetalleDto in pTemp_Editar)
                        {


                            movimientodetalle _objEntity = movimientodetalleDto.ToEntity();
                            var query = (from n in dbContext.movimientodetalle
                                         where n.v_IdMovimientoDetalle == movimientodetalleDto.v_IdMovimientoDetalle
                                         select n).FirstOrDefault();

                            if (query == null) continue;

                            var Almacen = (from n in dbContext.movimientodetalle
                                           join J1 in dbContext.movimiento on n.v_IdMovimiento equals J1.v_IdMovimiento
                                           where J1.v_IdMovimiento == query.v_IdMovimiento
                                           select new { J1.i_IdAlmacenOrigen }).FirstOrDefault();

                            _objEntity.t_ActualizaFecha = DateTime.Now;
                            _objEntity.i_ActualizaIdUsuario = Int32.Parse(ClientSession[2]);

                            switch (pobjDtoEntity.i_IdTipoMovimiento)
                            {
                                case (int)Common.Resource.TipoDeMovimiento.NotadeIngreso:
                                    RevertirMovimientoIngresoDetalle(ref pobjOperationResult, query.v_IdMovimientoDetalle, Almacen.i_IdAlmacenOrigen.Value, ClientSession);
                                    ProcesarMovimientoIngresoDetalle(ref pobjOperationResult, Almacen.i_IdAlmacenOrigen.Value, movimientodetalleDto, ClientSession);
                                    break;
                                case (int)Common.Resource.TipoDeMovimiento.NotadeSalida:
                                    RevertirMovimientoSalidaDetalle(ref pobjOperationResult, query.v_IdMovimientoDetalle, Almacen.i_IdAlmacenOrigen.Value, ClientSession);
                                    ProcesarMovimientoSalidaDetalle(ref pobjOperationResult, Almacen.i_IdAlmacenOrigen.Value, movimientodetalleDto, ClientSession);
                                    break;
                                case (int)Common.Resource.TipoDeMovimiento.Transferencia:
                                    break;
                            }
                            dbContext.movimientodetalle.ApplyCurrentValues(_objEntity);
                            if (pobjDtoEntity.i_IdTipoMovimiento == (int)Common.Resource.TipoDeMovimiento.Transferencia)
                            {
                                #region NotaIngreso
                                IdMovDetalle = movimientodetalleDto.v_IdMovimientoDetalle;
                                objMovimientoDetalleDtoNI = new movimientodetalleDto();
                                var movimientoDetalleDtoNI = new movimientodetalleDto();
                                movimientoDetalleDtoNI = (movimientodetalleDto)movimientodetalleDto.Clone();

                                if (ActualizarPrecio)
                                {
                                    //var PrecioAnterioresCompras = BuscarPrecioMovimientos(movimientodetalleDto.v_IdProductoDetalle, objEntityMovimiento.t_Fecha.Value, BuscarIdEstablecimiento(pobjDtoEntity.i_IdAlmacenDestino.Value).i_IdEstablecimiento, pobjDtoEntity.i_IdAlmacenOrigen.Value, pobjDtoEntity.i_IdMoneda.Value);
                                   var PrecioAnterioresCompras = BuscarPrecioMovimientosII(movimientodetalleDto.v_IdProductoDetalle, StockValorizado);
                                    movimientoDetalleDtoNI.d_Precio = PrecioAnterioresCompras;
                                    PrecioyaseActualizo = true;
                                }
                                else
                                {
                                    //var PrecioAnterioresCompras = BuscarPrecioMovimientos(movimientodetalleDto.v_IdProductoDetalle, fecha, BuscarIdEstablecimiento(pobjDtoEntity.i_IdAlmacenDestino.Value).i_IdEstablecimiento, pobjDtoEntity.i_IdAlmacenOrigen.Value, pobjDtoEntity.i_IdMoneda.Value);
                                    var PrecioAnterioresCompras = BuscarPrecioMovimientosII(movimientodetalleDto.v_IdProductoDetalle, StockValorizado);
                                    movimientoDetalleDtoNI.d_Precio = PrecioAnterioresCompras;
                                    PrecioyaseActualizo = true;
                                }

                                movimientoDetalleDtoNI.d_Total = Utils.Windows.DevuelveValorRedondeado(movimientoDetalleDtoNI.d_Cantidad.Value * movimientoDetalleDtoNI.d_Precio.Value, 2);
                                #endregion
                                #region NotaSalida
                                var movimientoDetalleDtoNS = new movimientodetalleDto();
                                movimientoDetalleDtoNS = (movimientodetalleDto)movimientodetalleDto.Clone();
                                objMovimientoDetalleDtoNI = movimientoDetalleDtoNI;
                                string pstrIdMovDetalles = _objMovimientoBL.ObtenerIdMovimientoDetalle(_movimientoCabeceraNIDto.v_IdMovimiento, IdMovDetalle);
                                string IdMovimiento = _movimientoCabeceraNIDto.v_IdMovimiento;
                                string pstrIdMovDetalleTransferencia = _objMovimientoBL.ObtenerIdMovimientoDetalleTransferencia(_movimientoCabeceraNIDto.v_IdMovimiento, pstrIdMovDetalles);

                                objMovimientoDetalleDtoNI.v_IdMovimientoDetalle = pstrIdMovDetalles;
                                objMovimientoDetalleDtoNI.v_IdMovimiento = IdMovimiento;
                                objMovimientoDetalleDtoNI.v_IdMovimientoDetalleTransferencia = pstrIdMovDetalleTransferencia;

                                objMovimientoDetalleDtoNI.v_NroGuiaRemision = movimientodetalleDto.v_NroGuiaRemision;
                                objMovimientoDetalleDtoNS = new movimientodetalleDto();

                                string pstrIdMovDetallesNS = _objMovimientoBL.ObtenerIdMovimientoDetalle(_movimientoCabeceraNSDto.v_IdMovimiento, IdMovDetalle);
                                string idMovimientoNS = _movimientoCabeceraNSDto.v_IdMovimiento;
                                string pstrIdMovimientoDetalleTransferencia = _objMovimientoBL.ObtenerIdMovimientoDetalleTransferencia(_movimientoCabeceraNSDto.v_IdMovimiento, pstrIdMovDetallesNS);

                                objMovimientoDetalleDtoNS.v_IdMovimientoDetalle = pstrIdMovDetallesNS;
                                objMovimientoDetalleDtoNS.v_IdMovimiento = idMovimientoNS;
                                objMovimientoDetalleDtoNS.v_IdMovimientoDetalleTransferencia = pstrIdMovimientoDetalleTransferencia;
                                objMovimientoDetalleDtoNS.v_IdProductoDetalle = movimientodetalleDto.v_IdProductoDetalle;
                                objMovimientoDetalleDtoNS.v_NroGuiaRemision = movimientodetalleDto.v_NroGuiaRemision;
                                objMovimientoDetalleDtoNS.v_NroPedido = movimientodetalleDto.v_NroPedido;
                                objMovimientoDetalleDtoNS.v_NumeroDocumento = movimientodetalleDto.v_NumeroDocumento;
                                objMovimientoDetalleDtoNS.i_IdTipoDocumento = movimientodetalleDto.i_IdTipoDocumento;
                                objMovimientoDetalleDtoNS.i_Eliminado = 0;
                                objMovimientoDetalleDtoNS.i_IdUnidad = movimientodetalleDto.i_IdUnidad;
                                objMovimientoDetalleDtoNS.d_Precio = movimientodetalleDto.d_Precio;
                                objMovimientoDetalleDtoNS.d_Total = Utils.Windows.DevuelveValorRedondeado(movimientodetalleDto.d_Total.Value, 2);
                                objMovimientoDetalleDtoNS.i_InsertaIdUsuario = movimientodetalleDto.i_InsertaIdUsuario;
                                objMovimientoDetalleDtoNS.d_Cantidad = movimientodetalleDto.d_Cantidad;
                                objMovimientoDetalleDtoNS.t_InsertaFecha = movimientodetalleDto.t_InsertaFecha;
                                objMovimientoDetalleDtoNS.d_CantidadEmpaque = movimientodetalleDto.d_CantidadEmpaque;
                                #endregion

                                objEntityMovimientoDetalleNI_Editar.Add(objMovimientoDetalleDtoNI);
                                objEntityMovimientoDetalleNS_Editar.Add(objMovimientoDetalleDtoNS);
                            }
                            i = i + 1;

                        }
                        #endregion

                        #region EditarTransferencia
                        //Se edita en caso solo se haya cambiado la fecha y ningun dato de la grilla

                        if (pobjDtoEntity.i_IdTipoMovimiento == (int)Common.Resource.TipoDeMovimiento.Transferencia && PrecioyaseActualizo == false && ActualizarPrecio == true)
                        {
                            List<movimientodetalleDto> ListaDetalleTransfer = new List<movimientodetalleDto>();

                            var DetalleTransferencias = (from a in dbContext.movimientodetalle
                                                         join b in dbContext.movimiento on new { IdMov = a.v_IdMovimiento, eliminado = 0 } equals new { IdMov = b.v_IdMovimiento, eliminado = b.i_Eliminado.Value } into b_join
                                                         from b in b_join.DefaultIfEmpty()

                                                         where a.i_Eliminado == 0 && b.v_IdMovimiento == pobjDtoEntity.v_IdMovimiento

                                                         select a).ToList();

                            ListaDetalleTransfer = movimientodetalleAssembler.ToDTOs(DetalleTransferencias).ToList();

                            foreach (var detalleTransferencia in ListaDetalleTransfer)
                            {

                                movimientodetalle _objEntity = movimientodetalleAssembler.ToEntity(detalleTransferencia);
                                var query = (from n in dbContext.movimientodetalle
                                             where n.v_IdMovimientoDetalle == detalleTransferencia.v_IdMovimientoDetalle
                                             select n).FirstOrDefault();

                                var Almacen = (from n in dbContext.movimientodetalle
                                               join J1 in dbContext.movimiento on n.v_IdMovimiento equals J1.v_IdMovimiento
                                               where J1.v_IdMovimiento == query.v_IdMovimiento
                                               select new { J1.i_IdAlmacenOrigen }).FirstOrDefault();

                                _objEntity.t_ActualizaFecha = DateTime.Now;
                                _objEntity.i_ActualizaIdUsuario = Int32.Parse(ClientSession[2]);
                                dbContext.movimientodetalle.ApplyCurrentValues(_objEntity);

                                IdMovDetalle = detalleTransferencia.v_IdMovimientoDetalle;
                                objMovimientoDetalleDtoNI = new movimientodetalleDto();
                                var movimientoDetalleDtoNI = new movimientodetalleDto();
                                movimientoDetalleDtoNI = (movimientodetalleDto)detalleTransferencia.Clone();
                                if (ActualizarPrecio)
                                {
                                    //var PrecioAnterioresCompras = BuscarPrecioMovimientos(detalleTransferencia.v_IdProductoDetalle, objEntityMovimiento.t_Fecha.Value, BuscarIdEstablecimiento(pobjDtoEntity.i_IdAlmacenDestino.Value).i_IdEstablecimiento, pobjDtoEntity.i_IdAlmacenOrigen.Value, pobjDtoEntity.i_IdMoneda.Value); ;
                                    var PrecioAnterioresCompras = BuscarPrecioMovimientosII(detalleTransferencia.v_IdProductoDetalle, StockValorizado);
                                    movimientoDetalleDtoNI.d_Precio = PrecioAnterioresCompras;
                                    PrecioyaseActualizo = true;
                                }
                                else
                                {
                                    //var PrecioAnterioresCompras = BuscarPrecioMovimientos(detalleTransferencia.v_IdProductoDetalle, fecha, BuscarIdEstablecimiento(pobjDtoEntity.i_IdAlmacenDestino.Value).i_IdEstablecimiento, pobjDtoEntity.i_IdAlmacenOrigen.Value, pobjDtoEntity.i_IdMoneda.Value);
                                    var PrecioAnterioresCompras = BuscarPrecioMovimientosII(detalleTransferencia.v_IdProductoDetalle, StockValorizado);
                                    movimientoDetalleDtoNI.d_Precio = PrecioAnterioresCompras;
                                    PrecioyaseActualizo = true;
                                }

                                movimientoDetalleDtoNI.d_Total = Utils.Windows.DevuelveValorRedondeado(movimientoDetalleDtoNI.d_Precio.Value * movimientoDetalleDtoNI.d_Cantidad.Value, 2);

                                var movimientoDetalleDtoNS = new movimientodetalleDto();
                                movimientoDetalleDtoNS = (movimientodetalleDto)detalleTransferencia.Clone();
                                objMovimientoDetalleDtoNI = movimientoDetalleDtoNI;


                                string pstrIdMovDetalles = _objMovimientoBL.ObtenerIdMovimientoDetalle(_movimientoCabeceraNIDto.v_IdMovimiento, IdMovDetalle);
                                string IdMovimiento = _movimientoCabeceraNIDto.v_IdMovimiento;
                                string pstrIdMovDetalleTransferencia = _objMovimientoBL.ObtenerIdMovimientoDetalleTransferencia(_movimientoCabeceraNIDto.v_IdMovimiento, pstrIdMovDetalles);

                                objMovimientoDetalleDtoNI.v_IdMovimientoDetalle = pstrIdMovDetalles;
                                objMovimientoDetalleDtoNI.v_IdMovimiento = IdMovimiento;
                                objMovimientoDetalleDtoNI.v_IdMovimientoDetalleTransferencia = pstrIdMovDetalleTransferencia;

                                objMovimientoDetalleDtoNS = new movimientodetalleDto();


                                string pstrIdMovDetallesNS = _objMovimientoBL.ObtenerIdMovimientoDetalle(_movimientoCabeceraNSDto.v_IdMovimiento, IdMovDetalle);
                                string idMovimientoNS = _movimientoCabeceraNSDto.v_IdMovimiento;
                                string pstrIdMovimientoDetalleTransferencia = _objMovimientoBL.ObtenerIdMovimientoDetalleTransferencia(_movimientoCabeceraNSDto.v_IdMovimiento, pstrIdMovDetallesNS);


                                objMovimientoDetalleDtoNS.v_IdMovimientoDetalle = pstrIdMovDetallesNS;
                                objMovimientoDetalleDtoNS.v_IdMovimiento = idMovimientoNS;
                                objMovimientoDetalleDtoNS.v_IdMovimientoDetalleTransferencia = pstrIdMovimientoDetalleTransferencia;
                                objMovimientoDetalleDtoNS.v_IdProductoDetalle = detalleTransferencia.v_IdProductoDetalle;
                                objMovimientoDetalleDtoNS.v_NroGuiaRemision = detalleTransferencia.v_NroGuiaRemision;
                                objMovimientoDetalleDtoNS.v_NroPedido = detalleTransferencia.v_NroPedido;
                                objMovimientoDetalleDtoNS.v_NumeroDocumento = detalleTransferencia.v_NumeroDocumento;
                                objMovimientoDetalleDtoNS.i_IdTipoDocumento = detalleTransferencia.i_IdTipoDocumento;
                                objMovimientoDetalleDtoNS.i_Eliminado = 0;
                                objMovimientoDetalleDtoNS.i_IdUnidad = detalleTransferencia.i_IdUnidad;
                                objMovimientoDetalleDtoNS.d_Precio = detalleTransferencia.d_Precio;
                                objMovimientoDetalleDtoNS.d_Total = Utils.Windows.DevuelveValorRedondeado(detalleTransferencia.d_Total.Value, 2);
                                objMovimientoDetalleDtoNS.i_InsertaIdUsuario = detalleTransferencia.i_InsertaIdUsuario;
                                objMovimientoDetalleDtoNS.d_Cantidad = detalleTransferencia.d_Cantidad;
                                objMovimientoDetalleDtoNS.t_InsertaFecha = detalleTransferencia.t_InsertaFecha;
                                objMovimientoDetalleDtoNS.d_CantidadEmpaque = detalleTransferencia.d_CantidadEmpaque;

                                objEntityMovimientoDetalleNI_Editar.Add(objMovimientoDetalleDtoNI);
                                objEntityMovimientoDetalleNS_Editar.Add(objMovimientoDetalleDtoNS);



                            }
                        }

                        #endregion

                        #region Temporales Eliminar


                        foreach (movimientodetalleDto movimientodetalleDto in pTemp_Eliminar)
                        {
                            try
                            {
                                movimientodetalle _objEntity = movimientodetalleAssembler.ToEntity(movimientodetalleDto);
                                var query = (from n in dbContext.movimientodetalle
                                             where n.v_IdMovimientoDetalle == movimientodetalleDto.v_IdMovimientoDetalle
                                             select n).FirstOrDefault();

                                var Cabecera = (from n in dbContext.movimiento
                                                where n.v_IdMovimiento == query.v_IdMovimiento
                                                select new { n.v_IdMovimiento }).FirstOrDefault();

                                var DetallesCabecera = (from n in dbContext.movimientodetalle
                                                        where n.v_IdMovimiento == query.v_IdMovimiento
                                                        select n);

                                if (DetallesCabecera.Count() == 1)
                                {
                                    EliminarMovimiento(ref pobjOperationResult, Cabecera.v_IdMovimiento, ClientSession);
                                }
                                else
                                {
                                    if (query != null)
                                    {
                                        query.t_ActualizaFecha = DateTime.Now;
                                        query.i_ActualizaIdUsuario = Int32.Parse(ClientSession[2]);
                                        query.i_Eliminado = 1;
                                    }

                                    switch (pobjDtoEntity.i_IdTipoMovimiento)
                                    {
                                        case (int)Common.Resource.TipoDeMovimiento.NotadeIngreso:
                                            RevertirMovimientoIngresoDetalle(ref pobjOperationResult, query.v_IdMovimientoDetalle, int.Parse(movimientodetalleDto.i_IdAlmacen), ClientSession);
                                            if (pobjOperationResult.Success == 0) return;
                                            break;
                                        case (int)Common.Resource.TipoDeMovimiento.NotadeSalida:
                                            RevertirMovimientoSalidaDetalle(ref pobjOperationResult, query.v_IdMovimientoDetalle, int.Parse(movimientodetalleDto.i_IdAlmacen), ClientSession);
                                            if (pobjOperationResult.Success == 0) return;
                                            break;
                                        case (int)Common.Resource.TipoDeMovimiento.Transferencia:

                                            break;
                                    }
                                    dbContext.movimientodetalle.ApplyCurrentValues(query);
                                    dbContext.SaveChanges();
                                    //Si no hay detalles en esta cabecera de movimiento entonces se elimina la cabecera tambien...
                                    var objEntitySourceDetallesMov = (from a in dbContext.movimientodetalle
                                                                      where a.v_IdMovimiento == query.v_IdMovimiento && a.i_Eliminado == 0
                                                                      select a).ToList();
                                    if (!objEntitySourceDetallesMov.Any())
                                    {
                                        EliminarMovimiento(ref pobjOperationResult, query.v_IdMovimiento, ClientSession);
                                    }
                                }


                                if (pobjDtoEntity.i_IdTipoMovimiento == (int)Common.Resource.TipoDeMovimiento.Transferencia)
                                {

                                    movimientodetalleDto objMovimientoDetalleNIEliminar = new movimientodetalleDto();
                                    IdMovDetalle = movimientodetalleDto.v_IdMovimientoDetalle;
                                    objMovimientoDetalleNIEliminar.v_IdMovimientoDetalle = _objMovimientoBL.ObtenerIdMovimientoDetalle(_movimientoCabeceraNIDto.v_IdMovimiento, IdMovDetalle);
                                    objMovimientoDetalleNIEliminar.i_IdAlmacen = pobjDtoEntity.i_IdAlmacenDestino.ToString();

                                    var eliminarCantidad = dbContext.movimientodetalle.Where(x => x.v_IdMovimientoDetalle == objMovimientoDetalleNIEliminar.v_IdMovimientoDetalle).FirstOrDefault();

                                    objMovimientoDetalleNIEliminar.d_Total = eliminarCantidad.d_Total.Value;

                                    movimientodetalleDto objMovimientoDetalleNSEliminar = new movimientodetalleDto();
                                    objMovimientoDetalleNSEliminar.v_IdMovimientoDetalle = _objMovimientoBL.ObtenerIdMovimientoDetalle(_movimientoCabeceraNSDto.v_IdMovimiento, IdMovDetalle);
                                    objMovimientoDetalleNSEliminar.i_IdAlmacen = pobjDtoEntity.i_IdAlmacenOrigen.ToString();
                                    objEntityMovimientoDetalleNI_Eliminar.Add(objMovimientoDetalleNIEliminar);
                                    objEntityMovimientoDetalleNS_Eliminar.Add(objMovimientoDetalleNSEliminar);
                                }
                            }
                            catch (Exception ex)
                            {

                                throw;
                            }


                        }
                        #endregion

                        #endregion

                        if (pobjDtoEntity.i_IdTipoMovimiento == (int)Common.Resource.TipoDeMovimiento.Transferencia)
                        {


                            var IngresosAnterios = (from j in dbContext.movimientodetalle
                                                    where j.v_IdMovimiento == _movimientoCabeceraNIDto.v_IdMovimiento && j.i_Eliminado == 0

                                                    select new
                                                    {
                                                        MovimientoDetalle = j.v_IdMovimientoDetalle,
                                                        Total = j.d_Total,
                                                    }).ToList();

                            var NoEditaron = IngresosAnterios.Select(x => x.MovimientoDetalle).ToList().Except(objEntityMovimientoDetalleNI_Editar.Select(x => x.v_IdMovimientoDetalle).ToList()).ToList();
                            var CantidadesNoEditaron = IngresosAnterios.Where(h => NoEditaron.Contains(h.MovimientoDetalle)).ToList();


                            _movimientoCabeceraNIDto.d_TotalCantidad = pobjDtoEntity.d_TotalCantidad;
                            _movimientoCabeceraNIDto.d_TotalPrecio = CantidadesNoEditaron.Sum(x => x.Total) + objEntityMovimientoDetalleNI.Sum(x => x.d_Total.Value) + objEntityMovimientoDetalleNI_Editar.Sum(x => x.d_Total.Value) - objEntityMovimientoDetalleNI_Eliminar.Sum(x => x.d_Total.Value);
                            _movimientoCabeceraNSDto.i_IdTipoDocumento = pobjDtoEntity.i_IdTipoDocumento;
                            _movimientoCabeceraNSDto.v_SerieDocumento = pobjDtoEntity.v_SerieDocumento;
                            _movimientoCabeceraNSDto.v_CorrelativoDocumento = pobjDtoEntity.v_CorrelativoDocumento;
                            _movimientoCabeceraNSDto.d_TotalCantidad = pobjDtoEntity.d_TotalCantidad;
                            _movimientoCabeceraNSDto.d_TotalPrecio = pobjDtoEntity.d_TotalPrecio;



                            _objMovimientoBL.ActualizarMovimiento(ref objOperationResult, _movimientoCabeceraNIDto, Globals.ClientSession.GetAsList(), objEntityMovimientoDetalleNI, objEntityMovimientoDetalleNI_Editar, objEntityMovimientoDetalleNI_Eliminar); //NotaIngreso
                            _objMovimientoBL.ActualizarMovimiento(ref objOperationResult, _movimientoCabeceraNSDto, Globals.ClientSession.GetAsList(), objEntityMovimientoDetalleNS, objEntityMovimientoDetalleNS_Editar, objEntityMovimientoDetalleNS_Eliminar); //NotaSalida

                        }

                        dbContext.SaveChanges();
                        pobjOperationResult.Success = 1;
                        Utils.Windows.GeneraHistorial(LogEventType.ACTUALIZACION, Globals.ClientSession.v_UserName, "movimiento", pobjDtoEntity.v_IdMovimiento);

                        if (objEntityMovimiento.i_IdTipoMovimiento == 1)
                        {
                            ActualizarCostoSegunUltimoMovimiento(ref pobjOperationResult, objEntitySource.ToDTO(), pTemp_Insertar.Concat(pTemp_Editar).ToList());
                        }
                        if (pobjOperationResult.Success == 0) return;
                        ts.Complete();
                        return;
                    }
                }

            }
            catch (Exception ex)
            {
                pobjOperationResult.Success = 0;
                pobjOperationResult.AdditionalInformation = "MovimientoBL.ActualizarMovimiento()";
                pobjOperationResult.ErrorMessage = ex.Message;
                pobjOperationResult.ExceptionMessage = ex.InnerException != null ? ex.InnerException.Message : string.Empty;
                Utils.ExceptionToLog(Globals.ClientSession.i_SystemUserId, pobjOperationResult);
                return;
            }
        }

        public void ActualizarDocumentosTransferencias(ref OperationResult pobjOperationResult, string mes, string periodo, string correlativo, List<movimientodetalleDto> pTemp_Editar)
        {
            try
            {
                pobjOperationResult.Success = 1;
                using (TransactionScope ts = TransactionUtils.CreateTransactionScope())
                {
                    using (SAMBHSEntitiesModelWin dbContext = new SAMBHSEntitiesModelWin())
                    {

                        var CabeceraIngreso = dbContext.movimiento.Where(o => o.v_OrigenTipo == "T" && o.v_OrigenRegMes == mes && o.v_OrigenRegPeriodo == periodo && o.v_OrigenRegCorrelativo == correlativo && o.i_IdTipoMovimiento == 1).FirstOrDefault();
                        var CabeceraSalida = dbContext.movimiento.Where(o => o.v_OrigenTipo == "T" && o.v_OrigenRegMes == mes && o.v_OrigenRegPeriodo == periodo && o.v_OrigenRegCorrelativo == correlativo && o.i_IdTipoMovimiento == 2).FirstOrDefault();
                        var DetallesNotaIngreso = dbContext.movimientodetalle.Where(o => o.v_IdMovimiento == CabeceraIngreso.v_IdMovimiento && o.i_Eliminado == 0).ToList().ToDTOs();
                        var DetallesNotaSalida = dbContext.movimientodetalle.Where(o => o.v_IdMovimiento == CabeceraSalida.v_IdMovimiento && o.i_Eliminado == 0).ToList().ToDTOs();



                        foreach (movimientodetalleDto movimientodetalleDto in pTemp_Editar)
                        {


                            movimientodetalle _objEntity = movimientodetalleDto.ToEntity();
                            var query = (from n in dbContext.movimientodetalle
                                         where n.v_IdMovimientoDetalle == movimientodetalleDto.v_IdMovimientoDetalle
                                         select n).FirstOrDefault();

                            _objEntity = query;
                            _objEntity.i_IdTipoDocumento = movimientodetalleDto.i_IdTipoDocumento;
                            _objEntity.v_NroGuiaRemision = movimientodetalleDto.v_NroGuiaRemision;
                            _objEntity.v_NumeroDocumento = movimientodetalleDto.v_NumeroDocumento;

                            dbContext.movimientodetalle.ApplyCurrentValues(_objEntity);

                        }



                        foreach (movimientodetalleDto detalleNotaIngreso in DetallesNotaIngreso)
                        {

                            var Cambios = pTemp_Editar.Where(o => o.v_IdProductoDetalle == detalleNotaIngreso.v_IdProductoDetalle).FirstOrDefault();
                            if (Cambios != null)
                            {
                                movimientodetalle _objEntity1 = detalleNotaIngreso.ToEntity();
                                var query = (from n in dbContext.movimientodetalle
                                             where n.v_IdMovimientoDetalle == detalleNotaIngreso.v_IdMovimientoDetalle
                                             select n).FirstOrDefault();
                                _objEntity1 = query;
                                _objEntity1.i_IdTipoDocumento = Cambios.i_IdTipoDocumento;
                                _objEntity1.v_NroGuiaRemision = Cambios.v_NroGuiaRemision;
                                _objEntity1.v_NumeroDocumento = Cambios.v_NumeroDocumento;
                                if (query == null) continue;
                                dbContext.movimientodetalle.ApplyCurrentValues(_objEntity1);
                            }
                        }

                        foreach (movimientodetalleDto detalleNotaSalida in DetallesNotaSalida)
                        {
                            var Cambios = pTemp_Editar.Where(o => o.v_IdProductoDetalle == detalleNotaSalida.v_IdProductoDetalle).FirstOrDefault();
                            if (Cambios != null)
                            {
                                movimientodetalle _objEntity2 = detalleNotaSalida.ToEntity();
                                var query = (from n in dbContext.movimientodetalle
                                             where n.v_IdMovimientoDetalle == detalleNotaSalida.v_IdMovimientoDetalle
                                             select n).FirstOrDefault();
                                _objEntity2 = query;
                                _objEntity2.i_IdTipoDocumento = Cambios.i_IdTipoDocumento;
                                _objEntity2.v_NroGuiaRemision = Cambios.v_NroGuiaRemision;
                                _objEntity2.v_NumeroDocumento = Cambios.v_NumeroDocumento;
                                if (query == null) continue;
                                dbContext.movimientodetalle.ApplyCurrentValues(_objEntity2);
                            }
                        }


                        dbContext.SaveChanges();
                        ts.Complete();
                    }
                }

            }
            catch (Exception ex)
            {
                pobjOperationResult.Success = 0;
                pobjOperationResult.AdditionalInformation = "MovimientoBL.ActualizarMovimiento()";
                pobjOperationResult.ErrorMessage = ex.Message;
                pobjOperationResult.ExceptionMessage = ex.InnerException != null ? ex.InnerException.Message : string.Empty;
                Utils.ExceptionToLog(Globals.ClientSession.i_SystemUserId, pobjOperationResult);
                return;

            }

        }
        public List<string> ObtenerCabeceraNotaISEmitidasTransferencia(ref  OperationResult pobjOperationResult, string pstridMovimiento)
        {
            try
            {

                pobjOperationResult.Success = 1;
                SAMBHSEntitiesModelWin dbContext = new SAMBHSEntitiesModelWin();

                //var Transferencia = (from a in dbContext.movimiento
                //                     where a.i_Eliminado == 0 && a.v_IdMovimiento == pstridMovimiento
                //                     select new
                //                     {
                //                         Periodo = a.v_Periodo.Trim(),
                //                         Mes = a.v_Mes.Trim(),
                //                         Correlativo = a.v_Correlativo.Trim(),

                //                     }).FirstOrDefault();
                //if (Transferencia != null)
                //{
                //var NotasDeIngresosSalidas = (from a in dbContext.movimiento
                //                              where a.v_OrigenTipo == "T" && a.v_OrigenRegPeriodo.Trim() == Transferencia.Periodo && a.v_OrigenRegMes.Trim() == Transferencia.Mes
                //                              && a.v_OrigenRegCorrelativo.Trim() == Transferencia.Correlativo && a.i_Eliminado == 0
                //                              select new { a.v_IdMovimiento }).ToList();


                var NotasDeIngresosSalidas = (from a in dbContext.movimiento
                                              where a.v_IdMovimientoOrigen == pstridMovimiento && a.i_IdTipoMovimiento != 3 && a.i_Eliminado == 0
                                              select new { a.v_IdMovimiento }).ToList();


                List<string> Lista = new List<string>();
                foreach (var NIS in NotasDeIngresosSalidas)
                {


                    string Cadena = NIS.v_IdMovimiento;
                    Lista.Add(Cadena);

                }
                return Lista;
                //}
                //else
                //{

                //    return null;
                //}
            }
            catch (Exception ex)
            {
                pobjOperationResult.Success = 0;
                pobjOperationResult.AdditionalInformation = "MovimientoBL.ObtenerCabeceraNotaISEmitidasTransferencia()";
                pobjOperationResult.ErrorMessage = ex.Message;
                pobjOperationResult.ExceptionMessage = ex.InnerException != null ? ex.InnerException.Message : string.Empty;
                Utils.ExceptionToLog(Globals.ClientSession.i_SystemUserId, pobjOperationResult);
                return null;

            }



        }



        public List<string> ObtenerCabeceraNotaISEmitidasTransferenciaEliminar(ref  OperationResult pobjOperationResult, string pstridMovimiento)
        {
            try
            {

                pobjOperationResult.Success = 1;
                SAMBHSEntitiesModelWin dbContext = new SAMBHSEntitiesModelWin();

                var Transferencia = (from a in dbContext.movimiento
                                     where a.i_Eliminado == 0 && a.v_IdMovimiento == pstridMovimiento
                                     select new
                                     {
                                         Periodo = a.v_Periodo.Trim(),
                                         Mes = a.v_Mes.Trim(),
                                         Correlativo = a.v_Correlativo.Trim(),

                                     }).FirstOrDefault();
                if (Transferencia != null)
                {
                    var NotasDeIngresosSalidas = (from a in dbContext.movimiento
                                                  where a.v_OrigenTipo == "T" && a.v_OrigenRegPeriodo.Trim() == Transferencia.Periodo && a.v_OrigenRegMes.Trim() == Transferencia.Mes
                                                  && a.v_OrigenRegCorrelativo.Trim() == Transferencia.Correlativo && a.i_Eliminado == 0
                                                  select new { a.v_IdMovimiento }).ToList();




                    List<string> Lista = new List<string>();
                    foreach (var NIS in NotasDeIngresosSalidas)
                    {


                        string Cadena = NIS.v_IdMovimiento;
                        Lista.Add(Cadena);

                    }
                    return Lista;
                }
                else
                {

                    return null;
                }
            }
            catch (Exception ex)
            {
                pobjOperationResult.Success = 0;
                pobjOperationResult.AdditionalInformation = "MovimientoBL.ObtenerCabeceraNotaISEmitidasTransferencia()";
                pobjOperationResult.ErrorMessage = ex.Message;
                pobjOperationResult.ExceptionMessage = ex.InnerException != null ? ex.InnerException.Message : string.Empty;
                Utils.ExceptionToLog(Globals.ClientSession.i_SystemUserId, pobjOperationResult);
                return null;

            }



        }


        public List<string> ListaIngresosSalidasTransferencias(ref  OperationResult objOperationResult)
        {

            using (SAMBHSEntitiesModelWin dbContext = new SAMBHSEntitiesModelWin())
            {
                var periodo = Globals.ClientSession.i_Periodo.ToString();

                var ListaIds = (from a in dbContext.movimiento
                                where a.v_Periodo == periodo && a.i_Eliminado == 0 && a.v_OrigenTipo == "T" && a.i_IdAlmacenOrigen == Globals.ClientSession.i_IdAlmacenPredeterminado.Value

                                select a.v_IdMovimiento).ToList();

                return ListaIds;

            }
        }

        public void EliminarMovimiento(ref OperationResult pobjOperationResult, string pstrMovimientoId, List<string> ClientSession)
        {
            try
            {
                using (TransactionScope ts = TransactionUtils.CreateTransactionScope())
                {
                    SAMBHSEntitiesModelWin dbContext = new SAMBHSEntitiesModelWin();

                    #region Elimina Cabecera
                    // Obtener la entidad fuente
                    var objEntitySource = (from a in dbContext.movimiento
                                           where a.v_IdMovimiento == pstrMovimientoId
                                           select a).FirstOrDefault();

                    // Crear la entidad con los datos actualizados
                    objEntitySource.t_ActualizaFecha = DateTime.Now;
                    objEntitySource.i_ActualizaIdUsuario = Int32.Parse(ClientSession[2]);
                    objEntitySource.i_Eliminado = 1;
                    #endregion

                    #region Elimina Detalles
                    //Eliminar detalles del movimiento eliminado.
                    var objEntitySourceDetallesMov = (from a in dbContext.movimientodetalle
                                                      where a.v_IdMovimiento == pstrMovimientoId && a.i_Eliminado == 0
                                                      select a).ToList();

                    foreach (var RegistroMovimientosDetalle in objEntitySourceDetallesMov)
                    {
                        RegistroMovimientosDetalle.t_ActualizaFecha = DateTime.Now;
                        RegistroMovimientosDetalle.i_ActualizaIdUsuario = Int32.Parse(ClientSession[2]);
                        RegistroMovimientosDetalle.i_Eliminado = 1;
                    }
                    #endregion

                    switch (objEntitySource.i_IdTipoMovimiento)
                    {
                        case (int)Common.Resource.TipoDeMovimiento.NotadeIngreso:
                            RevertirMovimientoIngreso(ref pobjOperationResult, objEntitySource.v_IdMovimiento, ClientSession);
                            break;
                        case (int)Common.Resource.TipoDeMovimiento.NotadeSalida:
                            RevertirMovimientoSalida(ref pobjOperationResult, objEntitySource.v_IdMovimiento, ClientSession);
                            break;
                        case (int)Common.Resource.TipoDeMovimiento.Transferencia:
                            //////////////////////////////////////////////////////
                            break;
                    }

                    if (objEntitySource.v_NroGuiaVenta != null && objEntitySource.v_NroGuiaVenta != string.Empty)
                    {
                        var guiaremision = objEntitySource.v_NroGuiaVenta.Split('-');
                        ActualizarGuiaRemisionDespachada(ref pobjOperationResult, guiaremision[0], guiaremision[1], 1, 0);
                    }
                    if (pobjOperationResult.Success == 0) return;
                    dbContext.SaveChanges();
                    pobjOperationResult.Success = 1;
                    Utils.Windows.GeneraHistorial(LogEventType.ELIMINACION, Globals.ClientSession.v_UserName, "movimiento", pstrMovimientoId);

                    if (objEntitySource.i_IdTipoMovimiento == 1) ActualizarCostoSegunUltimoMovimiento(ref pobjOperationResult, objEntitySource.ToDTO(), objEntitySourceDetallesMov.ToDTOs(), true);
                    if (pobjOperationResult.Success == 0) return;

                    ts.Complete();
                    return;
                }

            }
            catch (Exception ex)
            {
                pobjOperationResult.Success = 0;
                pobjOperationResult.AdditionalInformation = "MovimientoBL.EliminarMovimiento()";
                pobjOperationResult.ErrorMessage = ex.Message;
                pobjOperationResult.ExceptionMessage = ex.InnerException != null ? ex.InnerException.Message : string.Empty;
                Utils.ExceptionToLog(Globals.ClientSession.i_SystemUserId, pobjOperationResult);
                return;
            }
        }

        public void EliminarCargaInicial(string pstrPeriodo)
        {
            using (TransactionScope ts = TransactionUtils.CreateTransactionScope())
            {
                using (SAMBHSEntitiesModelWin dbContext = new SAMBHSEntitiesModelWin())
                {

                    var query = (from n in dbContext.movimiento

                                 where n.i_Eliminado == 0 && n.i_IdTipoMotivo == 5 && n.v_Periodo == pstrPeriodo && n.v_Mes == "01"

                                 select n).ToList();
                    foreach (var item in query)
                    {
                        var Eliminar = (from n in dbContext.movimientodetalle
                                        where n.v_IdMovimiento == item.v_IdMovimiento && n.i_Eliminado == 0
                                        select n).ToList();

                        foreach (var itemEliminar in Eliminar)
                        {
                            dbContext.DeleteObject(itemEliminar);
                        }
                        dbContext.DeleteObject(item);

                        Utils.Windows.GeneraHistorial(LogEventType.ELIMINACION, Globals.ClientSession.v_UserName, "movimiento", item.v_IdMovimiento);

                    }
                    dbContext.SaveChanges();
                }

                ts.Complete();
            }

        }

        public bool ExistenciaCargaInicial(string pstrPeriodo, int Establecimiento, int Almacen)
        {
            using (SAMBHSEntitiesModelWin dbContext = new SAMBHSEntitiesModelWin())
            {

                var query = (from n in dbContext.movimiento

                             where n.i_Eliminado == 0 && n.i_IdTipoMotivo == 5 && n.v_Periodo == pstrPeriodo && n.v_Mes == "01" && n.i_IdEstablecimiento == Establecimiento && n.i_IdAlmacenOrigen == Almacen

                             select n).ToList();
                if (query.Any())
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }


        }



        public List<productoshortDto> ListarBusquedaProductoAlmacen(ref OperationResult pobjOperationResult, string pstrSortExpression, string pstrFilterExpression, int pintIdAlmacen)
        {
            try
            {
               
                using (var dbContext = new SAMBHSEntitiesModelWin())
                {
                    var periodo = Globals.ClientSession.i_Periodo.ToString();

                    var query = (from n in dbContext.producto

                                 join D in dbContext.productodetalle on new { IdProducto = n.v_IdProducto, eliminado = 0 } equals new { IdProducto = D.v_IdProducto, eliminado = D.i_Eliminado.Value } into D_join
                                 from D in D_join.DefaultIfEmpty()

                                 join J3 in dbContext.datahierarchy on new { a = n.i_IdUnidadMedida.Value, b = 17, eliminado = 0 }
                                                                equals new { a = J3.i_ItemId, b = J3.i_GroupId, eliminado = J3.i_IsDeleted.Value } into J3_join
                                 from J3 in J3_join.DefaultIfEmpty()

                                 join J5 in dbContext.linea on new { n.v_IdLinea } equals new { J5.v_IdLinea } into J5_join
                                 from J5 in J5_join.DefaultIfEmpty()

                                 join J6 in dbContext.productoalmacen on new { idAlmacen = pintIdAlmacen, eliminado = 0, idProductoDetalle = D.v_IdProductoDetalle, p = periodo }
                                                                      equals new { idAlmacen = J6.i_IdAlmacen, eliminado = J6.i_Eliminado.Value, idProductoDetalle = J6.v_ProductoDetalleId, p = J6.v_Periodo } into J6_join
                                 from J6 in J6_join.DefaultIfEmpty()

                                 join J7 in dbContext.datahierarchy on new { a = n.i_IdPerfilDetraccion.Value, b = 176 }
                                     equals new { a = J7.i_ItemId, b = J7.i_GroupId } into J7_join
                                 from J7 in J7_join.DefaultIfEmpty()

                                 where n.i_Eliminado == 0 && n.i_EsActivoFijo == 0 && D_join.Any(p => p.v_IdProductoDetalle == J6.v_ProductoDetalleId) && n.i_EsActivo == 1

                                 select new productoshortDto
                                 {
                                     v_IdProducto = n.v_IdProducto,
                                     i_IdUnidadMedida = n.i_IdUnidadMedida,
                                     v_IdProductoDetalle = D == null ? "" : D.v_IdProductoDetalle,
                                     v_Descripcion = n.v_Descripcion,
                                     v_CodInterno = n.v_CodInterno,
                                     i_EsServicio = n.i_EsServicio,
                                     i_EsLote = n.i_EsLote,
                                     i_IdTipoProducto = n.i_IdTipoProducto,
                                     EmpaqueUnidadMedida = J3 == null ? "" : J3.v_Value1,
                                     d_Empaque = n.d_Empaque,
                                     i_ValidarStock = n.i_ValidarStock,
                                     i_EsAfectoPercepcion = n.i_EsAfectoPercepcion,
                                     d_TasaPercepcion = n.d_TasaPercepcion,
                                     i_PrecioEditable = n.i_PrecioEditable,
                                     NroCuentaVenta = J5.v_NroCuentaVenta,
                                     NroCuentaCompra = J5.v_NroCuentaCompra,
                                     d_Precio = n.d_PrecioCosto ?? 0,
                                     PrecioVenta = n.d_PrecioVenta ?? 0,
                                     stockActual = J6 != null ? J6.d_StockActual ?? 0 : 0,
                                     EsProductoFinal = n.i_IdTipoProducto.Value == Constants.ProductoTerminadoID,
                                     i_IdAlmacen = J6 != null ? J6.i_IdAlmacen : pintIdAlmacen,
                                     ValorUM = string.IsNullOrEmpty(J3.v_Value2) ? "1" : J3.v_Value2,
                                     UM = "UNIDADES",
                                     v_Descripcion2 = n.v_Descripcion2,
                                     TasaDetraccion = J7 != null ? J7.v_Value2 : "0",
                                     TopeDetraccion = J7 != null ? J7.v_Field : "0",
                                     i_SolicitarNroSerieSalida =n.i_SolicitarNroSerieSalida ?? 0,
                                     i_SolicitarNroLoteSalida = n.i_SolicitarNroLoteSalida ?? 0,
                                     i_SolicitaOrdenProduccionSalida = n.i_SolicitaOrdenProduccionSalida ?? 0,

                                     i_SolicitarNroLoteIngreso = n.i_SolicitarNroLoteIngreso ?? 0,
                                     i_SolicitarNroSerieIngreso = n.i_SolicitarNroSerieIngreso ?? 0,
                                     i_SolicitaOrdenProduccionIngreso = n.i_SolicitaOrdenProduccionIngreso ?? 0,


                                     v_NroLote = J6.v_NroLote,
                                     v_NroSerie = J6.v_NroSerie,
                                     t_FechaCaducidad = J6.t_FechaCaducidad==null ?Fechanull: J6.t_FechaCaducidad.Value ,
                                    
                                 }).ToList().Select(x => new productoshortDto
                                {
                                    v_IdProducto = x.v_IdProducto,
                                    TasaDetraccion = x.TasaDetraccion,
                                    TopeDetraccion = x.TopeDetraccion,
                                    i_IdUnidadMedida = x.i_IdUnidadMedida,
                                    v_IdProductoDetalle = x.v_IdProductoDetalle,
                                    v_Descripcion = x.v_Descripcion,
                                    v_CodInterno = x.v_CodInterno,
                                    i_EsServicio = x.i_EsServicio,
                                    i_EsLote = x.i_EsLote,
                                    i_IdTipoProducto = x.i_IdTipoProducto,
                                    EmpaqueUnidadMedida = x.EmpaqueUnidadMedida,
                                    d_Empaque = x.d_Empaque,
                                    i_ValidarStock = x.i_ValidarStock,
                                    i_EsAfectoPercepcion = x.i_EsAfectoPercepcion,
                                    d_TasaPercepcion = x.d_TasaPercepcion,
                                    i_PrecioEditable = x.i_PrecioEditable,
                                    NroCuentaVenta = x.NroCuentaVenta,
                                    NroCuentaCompra = x.NroCuentaCompra,
                                    d_Precio = x.d_Precio ?? 0,
                                    PrecioVenta = x.PrecioVenta,
                                    stockActual = x.stockActual,
                                    EsProductoFinal = x.EsProductoFinal,
                                    StockActualUM = x.ValorUM == "0" || x.stockActual == 0 ? 0 : Math.Round(x.stockActual.Value, 0) / Math.Round(decimal.Parse(x.ValorUM),0),
                                    SaldoUM = x.ValorUM == "0" || x.stockActual == 0 ? 0 : x.stockActual / decimal.Parse(x.ValorUM),
                                    UM = x.UM,
                                    v_Descripcion2 = x.v_Descripcion2,
                                    i_SolicitarNroSerieSalida = x.i_SolicitarNroSerieSalida ,
                                    i_SolicitarNroLoteSalida = x.i_SolicitarNroLoteSalida,
                                    i_SolicitaOrdenProduccionSalida = x.i_SolicitaOrdenProduccionSalida,
                                    i_SolicitarNroSerieIngreso = x.i_SolicitarNroSerieSalida,
                                    i_SolicitarNroLoteIngreso = x.i_SolicitarNroLoteSalida,
                                    i_SolicitaOrdenProduccionIngreso = x.i_SolicitaOrdenProduccionIngreso ,
                                    v_NroSerie = x.v_NroSerie,
                                    v_NroLote = x.v_NroLote,
                                    t_FechaCaducidad = x.t_FechaCaducidad,
                                });

                    List<productoshortDto> objData = query.GroupBy(x => new { x.v_IdProducto }) 
                             .Select(group =>
                                 {
                                     var j = group.FirstOrDefault();
                                     j.StockActualUM = group.Sum(i => i.StockActualUM);
                                     j.SaldoUM = group.Sum(i => i.SaldoUM);
                                     return j;
                                 }).ToList();
                    //List<productoshortDto> objData = query.ToList().OrderBy (o=>o.t_FechaCaducidad ).ToList ();
                    pobjOperationResult.Success = 1;
                    return objData;
                }
            }
            catch (Exception ex)
            {
                pobjOperationResult.Success = 0;
                pobjOperationResult.ExceptionMessage = Utils.ExceptionFormatter(ex);
                return null;
            }
        }

        public List<productoshortDto> ListarBusquedaProductos(ref OperationResult pobjOperationResult, string pstrSortExpression, int TipoProducto=-1)
        {
            try
            {
                using (var dbContext = new SAMBHSEntitiesModelWin())
                {
                    var query = (from n in dbContext.producto

                                 join D in dbContext.productodetalle on n.v_IdProducto equals D.v_IdProducto into D_join
                                 from D in D_join.DefaultIfEmpty()

                                 join J3 in dbContext.datahierarchy on new { a = n.i_IdUnidadMedida.Value, b = 17 }
                                                                equals new { a = J3.i_ItemId, b = J3.i_GroupId } into J3_join
                                 from J3 in J3_join.DefaultIfEmpty()
                                
                                 where n.i_Eliminado == 0 && n.i_EsActivo == 1 &&  (n.i_IdTipoProducto==TipoProducto || TipoProducto ==-1)

                                 && n.v_IdProducto != "N002-PD000000000"
                                 select new productoshortDto
                                 {
                                     v_IdProducto = n.v_IdProducto,
                                     i_IdUnidadMedida = n.i_IdUnidadMedida,
                                     v_IdProductoDetalle = D.v_IdProductoDetalle,
                                     v_Descripcion = n.v_Descripcion,
                                     v_CodInterno = n.v_CodInterno,
                                     i_EsServicio = n.i_EsServicio,
                                     i_EsLote = n.i_EsLote,
                                     i_IdTipoProducto = n.i_IdTipoProducto,
                                     EmpaqueUnidadMedida = J3.v_Value1,
                                     d_Empaque = n.d_Empaque,
                                     i_ValidarStock = n.i_ValidarStock,
                                     i_EsAfectoPercepcion = n.i_EsAfectoPercepcion,
                                     d_TasaPercepcion = n.d_TasaPercepcion,
                                     stockActual = 0,
                                     d_Precio = 0,
                                     d_separacion = 0,
                                     v_NroPedidoExportacion = null,
                                     v_Descripcion2 = n.v_Descripcion2,
                                     //Saldo=0,

                                 }
                         );

                    //if (!string.IsNullOrEmpty(pstrFilterExpression))
                    //{
                    //    query = query.Where(pstrFilterExpression);
                    //}
                    if (!string.IsNullOrEmpty(pstrSortExpression))
                    {
                        query = query.OrderBy(pstrSortExpression);
                    }

                    List<productoshortDto> objData = query.ToList();
                    pobjOperationResult.Success = 1;
                    return objData;
                }
            }
            catch (Exception ex)
            {
                pobjOperationResult.Success = 0;
                pobjOperationResult.ExceptionMessage = Utils.ExceptionFormatter(ex);
                return null;
            }
        }

        public List<productoshortDto> ListarBusquedaServicios(ref OperationResult pobjOperationResult, string pstrSortExpression, string pstrFilterExpression, string pstrIdCliente, int pintIdAlmacen)
        {
            try
            {
                string periodo = Globals.ClientSession.i_Periodo.ToString();
                SAMBHSEntitiesModelWin dbContext = new SAMBHSEntitiesModelWin();

                var Cliente = dbContext.cliente.FirstOrDefault(p => p.v_IdCliente == pstrIdCliente);

                int idListaPrecios = Cliente != null ? Cliente.i_IdListaPrecios.Value : 1;

                var listaPrecioDto = dbContext.listaprecio.FirstOrDefault(p => p.i_IdAlmacen == pintIdAlmacen && p.i_IdLista == idListaPrecios && p.i_Eliminado == 0);

                var dsListaPreciosDetalle =
                       dbContext.listapreciodetalle.Where(
                           p =>
                               p.listaprecio.i_IdAlmacen == pintIdAlmacen && p.listaprecio.i_IdLista == idListaPrecios &&
                               p.i_Eliminado == 0).ToDictionary(p => string.Join(",", p.v_IdProductoDetalle, p.i_IdAlmacen ?? 1), o => new[] { o.d_Precio ?? 0, o.d_Descuento ?? 0 });

                var query = (from n in dbContext.producto

                             join D in dbContext.productodetalle on n.v_IdProducto equals D.v_IdProducto into D_join
                             from D in D_join.DefaultIfEmpty()

                             join J3 in dbContext.datahierarchy on new { a = n.i_IdUnidadMedida.Value, b = 17 }
                                                            equals new { a = J3.i_ItemId, b = J3.i_GroupId } into J3_join
                             from J3 in J3_join.DefaultIfEmpty()

                             join J4 in dbContext.productoalmacen on new { a = D.v_IdProductoDetalle, b = pintIdAlmacen, eliminado = 0, _periodo = periodo }
                                                            equals new { a = J4.v_ProductoDetalleId, b = J4.i_IdAlmacen, eliminado = J4.i_Eliminado.Value, _periodo = J4.v_Periodo } into J4_join
                             from J4 in J4_join.DefaultIfEmpty()

                             join J5 in dbContext.linea on n.v_IdLinea equals J5.v_IdLinea into J5_join
                             from J5 in J5_join.DefaultIfEmpty()

                             join J6 in dbContext.datahierarchy on new { a = n.i_IdPerfilDetraccion.Value, b = 176 }
                                    equals new { a = J6.i_ItemId, b = J6.i_GroupId } into J6_join
                             from J6 in J6_join.DefaultIfEmpty()

                             where n.i_Eliminado == 0 && n.i_EsServicio == 1 && n.i_EsActivoFijo == 0 && n.i_EsActivo == 1

                             select new
                             {
                                 v_IdProducto = n.v_IdProducto,
                                 i_IdUnidadMedida = n.i_IdUnidadMedida ?? -1,
                                 v_IdProductoDetalle = D.v_IdProductoDetalle,
                                 v_Descripcion = n.v_Descripcion,
                                 v_CodInterno = n.v_CodInterno,
                                 i_EsServicio = n.i_EsServicio ?? 0,
                                 i_EsLote = n.i_EsLote ?? 0,
                                 i_IdTipoProducto = n.i_IdTipoProducto ?? 0,
                                 EmpaqueUnidadMedida = J3.v_Value1,
                                 NroCuentaVenta = J5.v_NroCuentaVenta,
                                 NroCuentaCompra = J5.v_NroCuentaCompra,
                                 ProductoAlmacen = J4 != null ? J4.v_IdProductoAlmacen : null,
                                 AfectoDetraccion = n.i_EsAfectoDetraccion,
                                 AfectoPercepcion = n.i_EsAfectoPercepcion ?? 0,
                                 NombreEditable = n.i_NombreEditable ?? 0,
                                 TasaPercepcion = n.d_TasaPercepcion ?? 0,
                                 PrecioEditable = n.i_PrecioEditable ?? 0,
                                 ValidarStock = n.i_ValidarStock ?? 0,
                                 i_IdAlmacen = J4 != null ? J4.i_IdAlmacen : -1,
                                 v_NroPedido = J4.v_NroPedido,
                                 v_Descripcion2 = n.v_Descripcion2,
                                 TasaDetraccion = J6 != null ? J6.v_Value2 : "0",
                                 TopeDetraccion = J6 != null ? J6.v_Field : "0",
                                 

                                 i_SolicitarNroLoteIngreso = n.i_SolicitarNroLoteIngreso ?? 0,
                                 i_SolicitarNroSerieIngreso = n.i_SolicitarNroSerieIngreso ?? 0,
                                 i_SolicitaOrdenProduccionIngreso = n.i_SolicitaOrdenProduccionIngreso ?? 0,
                                 i_SolicitarNroSerieSalida = n.i_SolicitarNroSerieSalida ?? 0,
                                 i_SolicitarNroLoteSalida = n.i_SolicitarNroLoteSalida ?? 0,
                                 i_SolicitaOrdenProduccionSalida = n.i_SolicitaOrdenProduccionSalida ?? 0,

                             }
                             ).ToList().Select(p =>
                             {
                                 try
                                 {
                                     var obj = new ProducDetalleAlmacen
                                     {
                                         IdProductoDetalle = p.v_IdProductoDetalle,
                                         IdAlmacen = p.i_IdAlmacen
                                     };
                                     var objListaPrecioDetalle = ObtenerPrecioDescuentoNuevo(string.Join(",", obj.IdProductoDetalle, obj.IdAlmacen), dsListaPreciosDetalle);

                                     return new productoshortDto
                                     {
                                         v_IdProducto = p.v_IdProducto,
                                         v_IdProductoDetalle = p.v_IdProductoDetalle,
                                         v_Descripcion = p.v_Descripcion,
                                         v_CodInterno = p.v_CodInterno,
                                         i_EsServicio = p.i_EsServicio,
                                         i_EsLote = p.i_EsLote,
                                         i_IdTipoProducto = p.i_IdTipoProducto,
                                         i_IdUnidadMedida = p.i_IdUnidadMedida,
                                         EmpaqueUnidadMedida = p.EmpaqueUnidadMedida,
                                         i_EsAfectoDetraccion = p.AfectoDetraccion,
                                         i_NombreEditable = p.NombreEditable,
                                         i_EsAfectoPercepcion = p.AfectoPercepcion,
                                         d_TasaPercepcion = p.TasaPercepcion,
                                         i_PrecioEditable = p.PrecioEditable,
                                         d_Precio =
                                             objListaPrecioDetalle[0],
                                         d_Descuento =
                                             objListaPrecioDetalle[1],
                                         IdMoneda = listaPrecioDto != null ? listaPrecioDto.i_IdMoneda ?? -1 : -1,
                                         NroCuentaVenta = p.NroCuentaVenta,
                                         NroCuentaCompra = p.NroCuentaCompra,
                                         i_ValidarStock = p.ValidarStock,
                                         IdAlmacen = p.i_IdAlmacen,
                                         v_NroPedidoExportacion = p.v_NroPedido,
                                         v_Descripcion2 = p.v_Descripcion2,
                                         TasaDetraccion = p.TasaDetraccion,
                                         TopeDetraccion = p.TopeDetraccion,

                                         i_SolicitarNroLoteIngreso = p.i_SolicitarNroLoteIngreso ,
                                         i_SolicitarNroSerieIngreso = p.i_SolicitarNroSerieIngreso ,
                                         i_SolicitaOrdenProduccionIngreso = p.i_SolicitaOrdenProduccionIngreso,
                                         i_SolicitarNroSerieSalida = p.i_SolicitarNroSerieSalida ,
                                         i_SolicitarNroLoteSalida = p.i_SolicitarNroLoteSalida ,
                                         i_SolicitaOrdenProduccionSalida = p.i_SolicitaOrdenProduccionSalida ,
                                         t_FechaCaducidad = (DateTime?)null
                                     };
                                 }
                                 catch (Exception ex)
                                 {
                                     return null;
                                 }

                             }
                            ).AsQueryable(); ;

                var objData = query.ToList();
                pobjOperationResult.Success = 1;
                return objData;
            }
            catch (Exception ex)
            {
                pobjOperationResult.Success = 0;
                pobjOperationResult.ExceptionMessage = Utils.ExceptionFormatter(ex);
                return null;
            }
        }

        public List<producto> ListaProductos()
        {
            using (SAMBHSEntitiesModelWin dbContext = new SAMBHSEntitiesModelWin())
            {
                return dbContext.producto.Where(o => o.i_Eliminado == 0).ToList();
            }
        }

        public List<productodetalle> ListaProductosDetalles()
        {
            using (SAMBHSEntitiesModelWin dbContext = new SAMBHSEntitiesModelWin())
            {
                return dbContext.productodetalle.Where(o => o.i_Eliminado == 0).ToList();
            }
        }
        public int ValidarStock(ref OperationResult pobjOperationResult, string strIdProductoDetalle, List<producto> producto, List<productodetalle> productodetalle)
        {
            try
            {

                SAMBHSEntitiesModelWin dbContext = new SAMBHSEntitiesModelWin();
                try
                {
                    var query = (from a in producto

                                 join b in productodetalle on new { Prod = a.v_IdProducto, eliminado = 0 } equals new { Prod = b.v_IdProducto, eliminado = b.i_Eliminado.Value } into a_join

                                 from b in a_join.DefaultIfEmpty()

                                 where b.v_IdProductoDetalle == strIdProductoDetalle && a.i_Eliminado == 0
                                 select new { i_ValidarStock = a.i_ValidarStock == null ? 0 : a.i_ValidarStock }).FirstOrDefault();

                    pobjOperationResult.Success = 1;
                    return query.i_ValidarStock.Value;
                }
                catch (Exception ex)
                {

                    pobjOperationResult.Success = 0;
                    return 0;
                }

            }
            catch (Exception ex)
            {
                pobjOperationResult.Success = 0;
                pobjOperationResult.AdditionalInformation = "PedidoBL.ValidarStock()";
                pobjOperationResult.ErrorMessage = ex.Message;
                pobjOperationResult.ExceptionMessage = ex.InnerException != null
                    ? ex.InnerException.Message
                    : string.Empty;
                Utils.ExceptionToLog(Globals.ClientSession.i_SystemUserId, pobjOperationResult);
                return 0;
            }


        }
        public List<productoalmacen> ListaProductoAlmacen(string periodo)
        {

            using (SAMBHSEntitiesModelWin dbContext = new SAMBHSEntitiesModelWin())
            {
                return dbContext.productoalmacen.Where(o => o.v_Periodo == periodo && o.i_Eliminado == 0).ToList();
            }

        }
        public productoalmacenDto ObtenerStockProductoAlmacen(ref OperationResult pobjOperationResult, string strProductoDetalle, int idAlmacen, string NroPedido, List<productoalmacen> productoalmacen, string NroSerie, string NroLote)
        {
            decimal StockActual = 0;
            using (SAMBHSEntitiesModelWin dbContext = new SAMBHSEntitiesModelWin())
            {
                string periodo = Globals.ClientSession.i_Periodo.ToString();
                productoalmacen query = new productoalmacen();
                if (NroPedido == null)
                {
                    if (NroSerie == null && NroLote == null)
                    {
                        query = (from n in productoalmacen
                                 where n.v_ProductoDetalleId == strProductoDetalle && n.v_Periodo == periodo && n.i_IdAlmacen == idAlmacen && n.i_Eliminado.Value == 0
                                 && n.v_NroPedido == null && n.v_NroLote == null && n.v_NroSerie == null
                                 select n).FirstOrDefault();
                    }
                    else
                    {
                        if (NroSerie != null)
                        {
                            query = (from n in productoalmacen
                                     where n.v_ProductoDetalleId == strProductoDetalle && n.v_Periodo == periodo && n.i_IdAlmacen == idAlmacen && n.i_Eliminado.Value == 0
                                     && n.v_NroPedido == null && n.v_NroSerie != null && n.v_NroSerie.Trim() == NroSerie.Trim()
                                     select n).FirstOrDefault();
                        }
                        else
                        {
                            query = (from n in productoalmacen
                                     where n.v_ProductoDetalleId == strProductoDetalle && n.v_Periodo == periodo && n.i_IdAlmacen == idAlmacen && n.i_Eliminado.Value == 0
                                     && n.v_NroPedido == null && n.v_NroLote != null && n.v_NroLote.Trim() == NroLote.Trim()
                                     select n).FirstOrDefault();
                        }


                    }
                    if (query != null)
                    {
                        StockActual = Convert.ToDecimal(query.d_StockActual);
                    }
                    return query.ToDTO();
                }
                else
                {

                    if (NroSerie == null && NroLote == null)
                    {
                        query = (from n in productoalmacen
                                 where n.v_ProductoDetalleId == strProductoDetalle && n.v_Periodo == periodo && n.i_IdAlmacen == idAlmacen && n.i_Eliminado.Value == 0
                                  && n.v_NroPedido.Trim() == NroPedido.Trim() && n.v_NroSerie == null && n.v_NroLote == null
                                 select n).FirstOrDefault();

                        if (NroSerie != null)
                        {
                            query = (from n in productoalmacen
                                     where n.v_ProductoDetalleId == strProductoDetalle && n.v_Periodo == periodo && n.i_IdAlmacen == idAlmacen && n.i_Eliminado.Value == 0
                                      && n.v_NroPedido.Trim() == NroPedido && n.v_NroSerie != null && n.v_NroSerie.Trim() == NroSerie.Trim()
                                     select n).FirstOrDefault();
                        }
                        else
                        {
                            query = (from n in productoalmacen
                                     where n.v_ProductoDetalleId == strProductoDetalle && n.v_Periodo == periodo && n.i_IdAlmacen == idAlmacen && n.i_Eliminado.Value == 0
                                      && n.v_NroPedido.Trim() == NroPedido && n.v_NroLote != null && n.v_NroLote.Trim() == NroLote.Trim()
                                     select n).FirstOrDefault();
                        }
                    }
                    if (query != null)
                    {
                        StockActual = Convert.ToDecimal(query.d_StockActual);
                    }
                    return query.ToDTO();
                }
            }



        }

        public decimal ObtenerCantidadMovimientoDetalle(ref OperationResult pobjOperationResult, string strIdMovimientoDetalle)
        {
            decimal stockAnterior = 0;

            SAMBHSEntitiesModelWin dbContext = new SAMBHSEntitiesModelWin();
            var query = (from n in dbContext.movimientodetalle
                         where n.v_IdMovimientoDetalle == strIdMovimientoDetalle
                         select new { n.d_Cantidad }).FirstOrDefault();
            if (query != null)
            {

                stockAnterior = Convert.ToDecimal(query.d_Cantidad);
            }
            return stockAnterior;

        }

        public List<productoshortDto> ListarBusquedaProductoAlmacenPV(ref OperationResult pobjOperationResult, int pintIdAlmacen, string pstrIdCliente, bool conStock)
        {
            try
            {
                using (var dbContext = new SAMBHSEntitiesModelWin())
                {
                    var RucEmpresa = new NodeBL().ReporteEmpresa().FirstOrDefault().RucEmpresaPropietaria.Trim();
                    List<CostoNotasIngresoPedido> ListaSaldosIniciales = new List<CostoNotasIngresoPedido>();
                    //var SeparacionesTodas = dbContext.productoalmacen.Where(o => o.i_Eliminado == 0).ToList();

                    if (RucEmpresa == Constants.RucWortec)
                    {
                        ListaSaldosIniciales = SaldosIniciales(Globals.ClientSession.i_Periodo.ToString());
                    }

                    var periodo = Globals.ClientSession.i_Periodo.ToString();

                    var Cliente = dbContext.cliente.FirstOrDefault(p => p.v_IdCliente == pstrIdCliente);

                    var IdListaPrecios = Cliente != null ? (Cliente.i_IdListaPrecios ?? 1) : 1;

                    var ListaPrecioDto =
                        dbContext.listaprecio.FirstOrDefault(
                            p => p.i_IdAlmacen == pintIdAlmacen && p.i_IdLista == IdListaPrecios && p.i_Eliminado == 0);

                 
                    var dsListaPreciosDetalle =
                        dbContext.listapreciodetalle.Where(
                            p =>
                                p.listaprecio.i_IdAlmacen == pintIdAlmacen && p.listaprecio.i_IdLista == IdListaPrecios &&
                                p.i_Eliminado == 0).ToDictionary(p => string.Join(",", p.v_IdProductoDetalle, p.i_IdAlmacen ?? 1), o => new[] { o.d_Precio ?? 0, o.d_Descuento ?? 0 });



                    //var prodBuscado = dbContext.listapreciodetalle.Where(o => o.i_Eliminado == 0 &&  o.listaprecio.i_IdAlmacen == pintIdAlmacen && o.listaprecio.i_IdLista == IdListaPrecios && o.v_IdProductoDetalle == "N001-PE000023770").ToList();

                    IQueryable query;
                    if (conStock)
                    {
                        #region Query Con Stock

                        query = (from n in dbContext.producto
                                 join D in dbContext.productodetalle on n.v_IdProducto equals D.v_IdProducto into D_join
                                 from D in D_join.DefaultIfEmpty()

                                 join J3 in dbContext.productoalmacen on new { a = D.v_IdProductoDetalle, b = pintIdAlmacen, eliminado = 0, _periodo = periodo } equals new { a = J3.v_ProductoDetalleId, b = J3.i_IdAlmacen, eliminado = J3.i_Eliminado.Value, _periodo = J3.v_Periodo } into J3_join
                                 from J3 in J3_join.DefaultIfEmpty()

                                 join J4 in dbContext.datahierarchy on new { a = n.i_IdUnidadMedida ?? 1, b = 17 }
                                     equals new { a = J4.i_ItemId, b = J4.i_GroupId } into J4_join
                                 from J4 in J4_join.DefaultIfEmpty()

                                 join J5 in dbContext.linea on n.v_IdLinea equals J5.v_IdLinea into J5_join
                                 from J5 in J5_join.DefaultIfEmpty()

                                 where
                                     n.i_Eliminado == 0 && n.i_EsServicio == 0 && n.i_EsActivoFijo == 0 && n.i_EsActivo == 1
                                     && (J3.d_StockActual ?? 0) > 0 &&
                                     D_join.Any(p => p.v_IdProductoDetalle == J3.v_ProductoDetalleId)
                                 // <---linea clave

                                 select new
                                 {
                                     v_IdProducto = n.v_IdProducto,
                                     v_IdProductoDetalle = D.v_IdProductoDetalle,
                                     v_Descripcion = n.v_Descripcion,
                                     v_CodInterno = n.v_CodInterno,
                                     i_EsServicio = n.i_EsServicio,
                                     i_EsLote = n.i_EsLote,
                                     i_IdTipoProducto = n.i_IdTipoProducto,
                                     stockActual = J3.d_StockActual,
                                     v_IdProductoAlmacen = J3.v_IdProductoAlmacen,
                                     d_separacion = J3.d_SeparacionTotal ?? 0,
                                     i_IdUnidadMedida = n.i_IdUnidadMedida,
                                     EmpaqueUnidadMedida = J4.v_Value1,
                                     d_Empaque = n.d_Empaque,
                                     i_EsAfectoDetraccion = n.i_EsAfectoDetraccion,
                                     i_NombreEditable = n.i_NombreEditable,
                                     StockDisponible = J3 != null ? (J3.d_StockActual ?? 0) - (J3.d_SeparacionTotal ?? 0) : 0,
                                     i_ValidarStock = n.i_ValidarStock,
                                     i_EsAfectoPercepcion = n.i_EsAfectoPercepcion,
                                     d_TasaPercepcion = n.d_TasaPercepcion,
                                     i_PrecioEditable = n.i_PrecioEditable,
                                     ProductoAlmacen = J3.v_IdProductoAlmacen,
                                     NroCuentaVenta = J5.v_NroCuentaVenta,
                                     NroCuentaCompra = J5.v_NroCuentaCompra,
                                     i_IdAlmacen = J3.i_IdAlmacen,
                                     i_IdTipoTributo = n.i_IdTipoTributo,
                                     v_NroPedidoExportacion = J3.v_NroPedido,
                                     ValorUM = string.IsNullOrEmpty(J4.v_Value2) ? "1" : J4.v_Value2,
                                     UM = "UNIDADES",
                                     Observaciones = n.v_Caracteristica,
                                     AfectoIsc = n.i_EsAfectoIsc,
                                     StockMinimo = n.d_StockMinimo == null ? 1 : J3 == null || J3.d_StockActual == null ? 1 : J3.d_StockActual <= n.d_StockMinimo ? 1 : 0,
                                     v_Descripcion2 = n.v_Descripcion2,
                                     i_SolicitarNroLoteIngreso = n.i_SolicitarNroLoteIngreso ?? 0,
                                     i_SolicitarNroSerieIngreso = n.i_SolicitarNroSerieIngreso ?? 0,
                                     i_SolicitaOrdenProduccionIngreso = n.i_SolicitaOrdenProduccionIngreso ?? 0,
                                     i_SolicitarNroSerieSalida = n.i_SolicitarNroSerieSalida ?? 0,
                                     i_SolicitarNroLoteSalida = n.i_SolicitarNroLoteSalida ?? 0,
                                     i_SolicitaOrdenProduccionSalida = n.i_SolicitaOrdenProduccionSalida ?? 0,

                                     v_NroLote = J3.v_NroLote,
                                     v_NroSerie = J3.v_NroSerie,
                                     t_FechaCaducidad = J3.t_FechaCaducidad ==null ? Fechanull :J3.t_FechaCaducidad.Value  ,
                                     d_PrecioVenta = n.d_PrecioVenta
                                 }).ToList().Select(p =>
                                  {
                                      var PrecioWortec = Constants.RucWortec == RucEmpresa
                                          ? ListaSaldosIniciales.Where(
                                              a =>
                                                  a.v_IdProductoDetalle == p.v_IdProductoDetalle &&
                                                  a.NroPedido == p.v_NroPedidoExportacion).ToList()
                                          : null;

                                      ProducDetalleAlmacen obj = new ProducDetalleAlmacen();
                                      obj.IdProductoDetalle = p.v_IdProductoDetalle;
                                      obj.IdAlmacen = p.i_IdAlmacen;
                                      var objListaPrecioDetalle = ObtenerPrecioDescuentoNuevo(string.Join(",", obj.IdProductoDetalle, obj.IdAlmacen), dsListaPreciosDetalle);

                                      return new productoshortDto
                                      {
                                          v_IdProducto = p.v_IdProducto,
                                          v_IdProductoDetalle = p.v_IdProductoDetalle,
                                          v_Descripcion = p.v_Descripcion,
                                          v_CodInterno = p.v_CodInterno,
                                          i_EsServicio = p.i_EsServicio,
                                          i_EsLote = p.i_EsLote,
                                          i_IdTipoProducto = p.i_IdTipoProducto,
                                          stockActual = p.stockActual,
                                          v_IdProductoAlmacen = p.v_IdProductoAlmacen,
                                          d_separacion = p.d_separacion,
                                          i_IdTipoTributo = p.i_IdTipoTributo,
                                          i_IdUnidadMedida = p.i_IdUnidadMedida,
                                          EmpaqueUnidadMedida = p.EmpaqueUnidadMedida,
                                          d_Empaque = p.d_Empaque,
                                          i_EsAfectoDetraccion = p.i_EsAfectoDetraccion,
                                          i_NombreEditable = p.i_NombreEditable,
                                          StockDisponible = p.StockDisponible,
                                          i_ValidarStock = p.i_ValidarStock,
                                          i_EsAfectoPercepcion = p.i_EsAfectoPercepcion,
                                          d_TasaPercepcion = p.d_TasaPercepcion,
                                          i_PrecioEditable = p.i_PrecioEditable,
                                          d_Precio = p.d_PrecioVenta,// Constants.RucWortec == RucEmpresa ? PrecioWortec.Any() ? Utils.Windows.DevuelveValorRedondeado(PrecioWortec.Average(x => x.Costo), 4) : 0 : objListaPrecioDetalle[0],
                                          d_Descuento = objListaPrecioDetalle[1],
                                          IdMoneda = ListaPrecioDto != null ? ListaPrecioDto.i_IdMoneda.Value : -1,
                                          NroCuentaVenta = p.NroCuentaVenta,
                                          NroCuentaCompra = p.NroCuentaCompra,
                                          IdAlmacen = p.i_IdAlmacen,
                                          v_NroPedidoExportacion = p.v_NroPedidoExportacion,
                                          StockActualUM = p.ValorUM == "0" ? 0 : p.stockActual / int.Parse(p.ValorUM),
                                          SeparacionActualUM = p.ValorUM == "0" ? 0 : p.d_separacion / int.Parse(p.ValorUM),
                                          //SeparacionActualUM = !Separacion.Any() ? 0 : Separacion.Sum(o => o.d_SeparacionTotal).Value == 0 ? 0 : (Separacion.Sum(o => o.d_SeparacionTotal).Value) / int.Parse(p.ValorUM),
                                          SaldoUM = p.ValorUM == "0" ? 0 : (p.stockActual / int.Parse(p.ValorUM)) - p.d_separacion / int.Parse(p.ValorUM),
                                          UM = p.UM,
                                          Observacion = p.Observaciones.Trim(),
                                          EsAfectoIsc = p.AfectoIsc.HasValue && p.AfectoIsc == 1,
                                          StockMinimo = p.StockMinimo,
                                          v_Descripcion2 = p.v_Descripcion2,

                                          i_SolicitarNroLoteIngreso = p.i_SolicitarNroLoteIngreso ,
                                          i_SolicitarNroSerieIngreso = p.i_SolicitarNroSerieIngreso,
                                          i_SolicitaOrdenProduccionIngreso = p.i_SolicitaOrdenProduccionIngreso,
                                          i_SolicitarNroSerieSalida = p.i_SolicitarNroSerieSalida,
                                          i_SolicitarNroLoteSalida = p.i_SolicitarNroLoteSalida ,
                                          i_SolicitaOrdenProduccionSalida = p.i_SolicitaOrdenProduccionSalida,



                                          v_NroLote = p.v_NroLote,
                                          v_NroSerie = p.v_NroSerie,
                                          t_FechaCaducidad = p.t_FechaCaducidad,

                                      };

                                  }).AsQueryable();

                        #endregion
                    }
                    else
                    {
                        #region Query Sin Importar Stock

                        query = (from n in dbContext.producto
                                 join D in dbContext.productodetalle on n.v_IdProducto equals D.v_IdProducto into D_join
                                 from D in D_join.DefaultIfEmpty()

                                 join J4 in dbContext.datahierarchy on new { a = n.i_IdUnidadMedida.Value, b = 17 }
                                     equals new { a = J4.i_ItemId, b = J4.i_GroupId } into J4_join
                                 from J4 in J4_join.DefaultIfEmpty()

                                 join J5 in dbContext.linea on n.v_IdLinea equals J5.v_IdLinea into J5_join
                                 from J5 in J5_join.DefaultIfEmpty()

                                 join J6 in dbContext.productoalmacen on new { a = D.v_IdProductoDetalle, b = pintIdAlmacen, eliminado = 0, _periodo = periodo }
                                     equals new { a = J6.v_ProductoDetalleId, b = J6.i_IdAlmacen, eliminado = J6.i_Eliminado.Value, _periodo = J6.v_Periodo } into J6_join
                                 from J6 in J6_join.DefaultIfEmpty()

                                 where n.i_Eliminado == 0 && n.i_EsServicio == 0 && n.i_EsActivoFijo == 0 && n.i_EsActivo == 1
                                 && D_join.Any(p => p.v_IdProductoDetalle.Equals(J6.v_ProductoDetalleId))
                                 select new
                                 {
                                     v_IdProducto = n.v_IdProducto,
                                     v_IdProductoDetalle = D.v_IdProductoDetalle,
                                     v_Descripcion = n.v_Descripcion,
                                     v_CodInterno = n.v_CodInterno,
                                     i_EsServicio = n.i_EsServicio,
                                     i_EsLote = n.i_EsLote,
                                     i_IdTipoProducto = n.i_IdTipoProducto,
                                     i_IdUnidadMedida = n.i_IdUnidadMedida,
                                     EmpaqueUnidadMedida = J4.v_Value1,
                                     d_Empaque = n.d_Empaque,
                                     i_EsAfectoDetraccion = n.i_EsAfectoDetraccion,
                                     i_NombreEditable = n.i_NombreEditable,
                                     i_ValidarStock = n.i_ValidarStock,
                                     i_EsAfectoPercepcion = n.i_EsAfectoPercepcion,
                                     d_TasaPercepcion = n.d_TasaPercepcion,
                                     i_PrecioEditable = n.i_PrecioEditable,
                                     NroCuentaVenta = J5.v_NroCuentaVenta,
                                     NroCuentaCompra = J5.v_NroCuentaCompra,
                                     NroPedido = J6.v_NroPedido,
                                     stockActual = J6.d_StockActual,
                                     v_IdProductoAlmacen = J6.v_IdProductoAlmacen,
                                     d_Separacion = J6.d_SeparacionTotal == null ? 0 : J6.d_SeparacionTotal,
                                     d_StockActual = J6.d_StockActual,
                                     i_IdAlmacen = J6.i_IdAlmacen,
                                     v_NroPedidoExportacion = J6.v_NroPedido,
                                     ValorUM = string.IsNullOrEmpty(J4.v_Value2) ? "0" : J4.v_Value2,
                                     UM = "UNIDADES",
                                     AfectoIsc = n.i_EsAfectoIsc,
                                     StockMinimo = n.d_StockMinimo == null ? 1 : J6 == null || J6.d_StockActual == null ? 1 : J6.d_StockActual <= n.d_StockMinimo ? 1 : 0,
                                     v_Descripcion2 = n.v_Descripcion2,
                                     i_IdTipoTributo = n.i_IdTipoTributo,
                                     i_SolicitarNroLoteIngreso = n.i_SolicitarNroLoteIngreso ?? 0,
                                     i_SolicitarNroSerieIngreso = n.i_SolicitarNroSerieIngreso ?? 0,
                                     i_SolicitaOrdenProduccionIngreso = n.i_SolicitaOrdenProduccionIngreso ?? 0,
                                     i_SolicitarNroSerieSalida = n.i_SolicitarNroSerieSalida ?? 0,
                                     i_SolicitarNroLoteSalida = n.i_SolicitarNroLoteSalida ?? 0,
                                     i_SolicitaOrdenProduccionSalida = n.i_SolicitaOrdenProduccionSalida ?? 0,



                                     v_NroLote = J6.v_NroLote,
                                     v_NroSerie = J6.v_NroSerie,
                                     t_FechaCaducidad = J6.t_FechaCaducidad==null ? Fechanull : J6.t_FechaCaducidad.Value  ,
                                     d_PrecioVenta=n.d_PrecioVenta
                                 }).ToList().Select(p =>
                                 {
                                     decimal d;
                                     var PrecioWortec = Constants.RucWortec == RucEmpresa
                                         ? ListaSaldosIniciales.Where(
                                             a =>
                                                 a.v_IdProductoDetalle == p.v_IdProductoDetalle &&
                                                 a.NroPedido == p.v_NroPedidoExportacion).Sum(a => a.Costo)
                                         : 0;

                                     ProducDetalleAlmacen obj = new ProducDetalleAlmacen();
                                     obj.IdProductoDetalle = p.v_IdProductoDetalle;
                                     obj.IdAlmacen = p.i_IdAlmacen;
                                     var objListaPrecioDetalle = ObtenerPrecioDescuentoNuevo(string.Join(",", obj.IdProductoDetalle, obj.IdAlmacen), dsListaPreciosDetalle);
                                     return new productoshortDto
                                     {
                                         i_IdTipoTributo = p.i_IdTipoTributo,
                                         v_IdProducto = p.v_IdProducto,
                                         v_IdProductoDetalle = p.v_IdProductoDetalle,
                                         v_Descripcion = p.v_Descripcion,
                                         v_CodInterno = p.v_CodInterno,
                                         i_EsServicio = p.i_EsServicio,
                                         i_EsLote = p.i_EsLote,
                                         i_IdTipoProducto = p.i_IdTipoProducto,
                                         stockActual = p.v_IdProductoAlmacen != null ? p.stockActual ?? 0 : 0,
                                         v_IdProductoAlmacen = p.v_IdProductoAlmacen,
                                         d_separacion = p.v_IdProductoAlmacen != null ? p.d_Separacion ?? 0 : 0,
                                         i_IdUnidadMedida = p.i_IdUnidadMedida,
                                         EmpaqueUnidadMedida = p.EmpaqueUnidadMedida,
                                         d_Empaque = p.d_Empaque,
                                         i_EsAfectoDetraccion = p.i_EsAfectoDetraccion,
                                         i_NombreEditable = p.i_NombreEditable,
                                         StockDisponible = p.d_StockActual,
                                         i_ValidarStock = p.i_ValidarStock,
                                         i_EsAfectoPercepcion = p.i_EsAfectoPercepcion,
                                         d_TasaPercepcion = p.d_TasaPercepcion,
                                         i_PrecioEditable = p.i_PrecioEditable,
                                         d_Precio = p.d_PrecioVenta, //p.v_IdProductoAlmacen != null ? RucEmpresa == Constants.RucWortec ? PrecioWortec != null ? PrecioWortec : 0 : objListaPrecioDetalle[0] : 0,
                                         d_Descuento =
                                             p.v_IdProductoAlmacen != null ? objListaPrecioDetalle[1] : 0,
                                         IdMoneda = ListaPrecioDto != null ? ListaPrecioDto.i_IdMoneda.Value : -1,
                                         NroCuentaVenta = p.NroCuentaVenta,
                                         NroCuentaCompra = p.NroCuentaCompra,
                                         IdAlmacen =
                                             p.v_IdProductoAlmacen != null ? -1 : p.i_IdAlmacen == null ? -1 : p.i_IdAlmacen,
                                         v_NroPedidoExportacion = p.NroPedido,
                                         StockActualUM = p.stockActual == 0 || p.ValorUM == "0" ? 0 : p.stockActual / (decimal.TryParse(p.ValorUM, out d) ? d : 0),
                                         SeparacionActualUM = p.d_Separacion == 0 || p.ValorUM == "0" ? 0 : p.d_Separacion / (decimal.TryParse(p.ValorUM, out d) ? d : 0),
                                         SaldoUM =
                                             p.ValorUM == "0"
                                                 ? 0
                                                 : p.stockActual != 0 && p.ValorUM != "0" && p.d_Separacion != 0
                                                     ? (p.stockActual / (decimal.TryParse(p.ValorUM, out d) ? d : 0)) -
                                                       p.d_Separacion / (decimal.TryParse(p.ValorUM, out d) ? d : 0)
                                                     : p.stockActual == 0 && p.ValorUM != "0" && p.d_Separacion != 0
                                                         ? -p.d_Separacion / (decimal.TryParse(p.ValorUM, out d) ? d : 0)
                                                         : p.d_Separacion == 0 && p.ValorUM != "0" && p.stockActual != 0
                                                             ? (p.stockActual / (decimal.TryParse(p.ValorUM, out d) ? d : 0))
                                                             : 0,
                                         UM = p.UM,
                                         EsAfectoIsc = p.AfectoIsc.HasValue && p.AfectoIsc == 1,
                                         StockMinimo = p.StockMinimo,
                                         v_Descripcion2 = p.v_Descripcion2,

                                         i_SolicitarNroLoteIngreso = p.i_SolicitarNroLoteIngreso ,
                                         i_SolicitarNroSerieIngreso = p.i_SolicitarNroSerieIngreso ,
                                         i_SolicitaOrdenProduccionIngreso = p.i_SolicitaOrdenProduccionIngreso ,
                                         i_SolicitarNroSerieSalida = p.i_SolicitarNroSerieSalida ,
                                         i_SolicitarNroLoteSalida = p.i_SolicitarNroLoteSalida,
                                         i_SolicitaOrdenProduccionSalida = p.i_SolicitaOrdenProduccionSalida ,

                                         v_NroSerie = p.v_NroSerie,
                                         v_NroLote = p.v_NroLote,
                                         t_FechaCaducidad = p.t_FechaCaducidad,
                                     };
                                 }).AsQueryable();

                        #endregion

                    }

                    List<productoshortDto> objData = query.Cast<productoshortDto>().ToList().OrderBy (o=>o.t_FechaCaducidad).ToList ();
                    pobjOperationResult.Success = 1;
                    return objData;
                }
            }
            catch (Exception ex)
            {
                pobjOperationResult.Success = 0;
                pobjOperationResult.ErrorMessage = ex.Message;
                pobjOperationResult.ExceptionMessage = ex.InnerException != null ? ex.InnerException.Message : string.Empty;
                pobjOperationResult.AdditionalInformation = "MovimientoBL.ListarBusquedaProductoAlmacenPV()";
                return null;
            }
        }

        public List<productoshortDto> ListarBusquedaProductoAlmacenPV(ref OperationResult pobjOperationResult, int pintIdAlmacen, bool conStock)
        {
            try
            {
                using (var dbContext = new SAMBHSEntitiesModelWin())
                {
                    var RucEmpresa = Globals.ClientSession.v_RucEmpresa;
                    var ListaSaldosIniciales = new List<CostoNotasIngresoPedido>();

                    if (RucEmpresa == Constants.RucWortec)
                    {
                        ListaSaldosIniciales = SaldosIniciales(Globals.ClientSession.i_Periodo.ToString());
                    }

                    var periodo = Globals.ClientSession.i_Periodo.ToString();

                    IQueryable query;
                    if (conStock)
                    {
                        #region Query Con Stock

                        query = (from n in dbContext.producto
                                 join D in dbContext.productodetalle on n.v_IdProducto equals D.v_IdProducto into D_join
                                 from D in D_join.DefaultIfEmpty()

                                 join J3 in dbContext.productoalmacen on new { a = D.v_IdProductoDetalle, b = pintIdAlmacen, eliminado = 0, _periodo = periodo } equals new { a = J3.v_ProductoDetalleId, b = J3.i_IdAlmacen, eliminado = J3.i_Eliminado.Value, _periodo = J3.v_Periodo } into J3_join
                                 from J3 in J3_join.DefaultIfEmpty()

                                 join J4 in dbContext.datahierarchy on new { a = n.i_IdUnidadMedida.Value, b = 17 }
                                     equals new { a = J4.i_ItemId, b = J4.i_GroupId } into J4_join
                                 from J4 in J4_join.DefaultIfEmpty()

                                 join J5 in dbContext.linea on n.v_IdLinea equals J5.v_IdLinea into J5_join
                                 from J5 in J5_join.DefaultIfEmpty()

                                 join J6 in dbContext.datahierarchy on new { a = n.i_IdPerfilDetraccion.Value, b = 176 }
                                     equals new { a = J6.i_ItemId, b = J6.i_GroupId } into J6_join
                                 from J6 in J6_join.DefaultIfEmpty()

                                 where n.i_Eliminado == 0 && n.i_EsServicio == 0 && n.i_EsActivoFijo == 0 && n.i_EsActivo == 1
                                       && J3.d_StockActual > 0 &&
                                       J3_join.Any(p => p.v_ProductoDetalleId == D.v_IdProductoDetalle)    // <---linea clave

                                 select new
                                 {
                                     v_IdProducto = n.v_IdProducto,
                                     v_IdProductoDetalle = D.v_IdProductoDetalle,
                                     v_Descripcion = n.v_Descripcion,
                                     v_CodInterno = n.v_CodInterno,
                                     i_EsServicio = n.i_EsServicio,
                                     i_EsLote = n.i_EsLote,
                                     n.d_PrecioVenta,
                                     i_IdTipoProducto = n.i_IdTipoProducto,
                                     stockActual = J3.d_StockActual,
                                     v_IdProductoAlmacen = J3.v_IdProductoAlmacen,
                                     d_separacion = J3.d_SeparacionTotal ?? 0,
                                     i_IdUnidadMedida = n.i_IdUnidadMedida,
                                     EmpaqueUnidadMedida = J4.v_Value1,
                                     d_Empaque = n.d_Empaque,
                                     i_EsAfectoDetraccion = n.i_EsAfectoDetraccion,
                                     TasaDetraccion = J6 != null ? J6.v_Value2 : "0",
                                     TopeDetraccion = J6 != null ? J6.v_Field : "0",
                                     i_NombreEditable = n.i_NombreEditable,
                                     StockDisponible = J3.d_StockActual - J3.d_SeparacionTotal,
                                     i_ValidarStock = n.i_ValidarStock,
                                     i_EsAfectoPercepcion = n.i_EsAfectoPercepcion,
                                     d_TasaPercepcion = n.d_TasaPercepcion,
                                     i_PrecioEditable = n.i_PrecioEditable,
                                     ProductoAlmacen = J3.v_IdProductoAlmacen,
                                     NroCuentaVenta = J5.v_NroCuentaVenta,
                                     NroCuentaCompra = J5.v_NroCuentaCompra,
                                     i_IdAlmacen = J3.i_IdAlmacen,
                                     v_NroPedidoExportacion = J3.v_NroPedido,
                                     ValorUM = string.IsNullOrEmpty(J4.v_Value2) ? "0" : J4.v_Value2,
                                     UM = "UNIDADES",
                                     Observaciones = n.v_Caracteristica,
                                     AfectoIsc = n.i_EsAfectoIsc,
                                     StockMinimo = n.d_StockMinimo == null ? 1 : J3 == null || J3.d_StockActual == null ? 1 : J3.d_StockActual <= n.d_StockMinimo ? 1 : 0,
                                     v_Descripcion2 = n.v_Descripcion2,

                                     i_SolicitarNroLoteIngreso = n.i_SolicitarNroLoteIngreso ?? 0,
                                     i_SolicitarNroSerieIngreso = n.i_SolicitarNroSerieIngreso ?? 0,
                                     i_SolicitaOrdenProduccionIngreso = n.i_SolicitaOrdenProduccionIngreso ?? 0,
                                     i_SolicitarNroSerieSalida = n.i_SolicitarNroSerieSalida ?? 0,
                                     i_SolicitarNroLoteSalida = n.i_SolicitarNroLoteSalida ?? 0,
                                     i_SolicitaOrdenProduccionSalida = n.i_SolicitaOrdenProduccionSalida ?? 0,

                                     v_NroLote = J3.v_NroLote,
                                     v_NroSerie = J3.v_NroSerie,
                                     t_FechaCaducidad = J3.t_FechaCaducidad == null ? Fechanull: J3.t_FechaCaducidad,

                                 }).ToList().Select(p =>
                                 {
                                     var PrecioWortec = Constants.RucWortec == RucEmpresa
                                         ? ListaSaldosIniciales.Where(
                                             a =>
                                                 a.v_IdProductoDetalle == p.v_IdProductoDetalle &&
                                                 a.NroPedido == p.v_NroPedidoExportacion).ToList()
                                         : null;
                                     return new productoshortDto
                                     {
                                         TasaDetraccion = p.TasaDetraccion,
                                         TopeDetraccion = p.TopeDetraccion,
                                         v_IdProducto = p.v_IdProducto,
                                         v_IdProductoDetalle = p.v_IdProductoDetalle,
                                         v_Descripcion = p.v_Descripcion,
                                         v_CodInterno = p.v_CodInterno,
                                         i_EsServicio = p.i_EsServicio,
                                         i_EsLote = p.i_EsLote,
                                         i_IdTipoProducto = p.i_IdTipoProducto,
                                         stockActual = p.stockActual,
                                         v_IdProductoAlmacen = p.v_IdProductoAlmacen,
                                         d_separacion = p.d_separacion,
                                         i_IdUnidadMedida = p.i_IdUnidadMedida,
                                         EmpaqueUnidadMedida = p.EmpaqueUnidadMedida,
                                         d_Empaque = p.d_Empaque,
                                         i_EsAfectoDetraccion = p.i_EsAfectoDetraccion,
                                         i_NombreEditable = p.i_NombreEditable,
                                         StockDisponible = p.StockDisponible,
                                         i_ValidarStock = p.i_ValidarStock,
                                         i_EsAfectoPercepcion = p.i_EsAfectoPercepcion,
                                         d_TasaPercepcion = p.d_TasaPercepcion,
                                         i_PrecioEditable = p.i_PrecioEditable,
                                         d_Precio = Constants.RucWortec == RucEmpresa ? (PrecioWortec.Any() ? Utils.Windows.DevuelveValorRedondeado(PrecioWortec.Average(x => x.Costo), 4)
                                                     : 0)
                                                 : p.d_PrecioVenta,
                                         d_Descuento = 0,
                                         IdMoneda = 1,
                                         NroCuentaVenta = p.NroCuentaVenta,
                                         NroCuentaCompra = p.NroCuentaCompra,
                                         IdAlmacen = p.i_IdAlmacen,
                                         v_NroPedidoExportacion = p.v_NroPedidoExportacion,
                                         StockActualUM = p.stockActual / int.Parse(p.ValorUM),
                                         SeparacionActualUM = p.d_separacion / int.Parse(p.ValorUM),
                                         SaldoUM = (p.stockActual / int.Parse(p.ValorUM)) - p.d_separacion / int.Parse(p.ValorUM),
                                         UM = p.UM,
                                         Observacion = p.Observaciones.Trim(),
                                         EsAfectoIsc = p.AfectoIsc.HasValue && p.AfectoIsc == 1,
                                         StockMinimo = p.StockMinimo,
                                         v_Descripcion2 = p.v_Descripcion2,

                                         i_SolicitarNroLoteIngreso = p.i_SolicitarNroLoteIngreso ,
                                         i_SolicitarNroSerieIngreso = p.i_SolicitarNroSerieIngreso ,
                                         i_SolicitaOrdenProduccionIngreso = p.i_SolicitaOrdenProduccionIngreso ,
                                         i_SolicitarNroSerieSalida = p.i_SolicitarNroSerieSalida ,
                                         i_SolicitarNroLoteSalida = p.i_SolicitarNroLoteSalida ,
                                         i_SolicitaOrdenProduccionSalida = p.i_SolicitaOrdenProduccionSalida ,



                                         v_NroLote = p.v_NroLote,
                                         v_NroSerie = p.v_NroSerie,
                                         t_FechaCaducidad = p.t_FechaCaducidad.Value,
                                     };

                                 }).AsQueryable();


                        #endregion
                    }
                    else
                    {
                        #region Query Sin Importar Stock

                        query = (from n in dbContext.producto
                                 join D in dbContext.productodetalle on n.v_IdProducto equals D.v_IdProducto into D_join
                                 from D in D_join.DefaultIfEmpty()

                                 join J4 in dbContext.datahierarchy on new { a = n.i_IdUnidadMedida.Value, b = 17 }
                                     equals new { a = J4.i_ItemId, b = J4.i_GroupId } into J4_join
                                 from J4 in J4_join.DefaultIfEmpty()

                                 join J5 in dbContext.linea on n.v_IdLinea equals J5.v_IdLinea into J5_join
                                 from J5 in J5_join.DefaultIfEmpty()

                                 join J6 in dbContext.productoalmacen on new { a = D.v_IdProductoDetalle, b = pintIdAlmacen, eliminado = 0, _periodo = periodo }
                                     equals new { a = J6.v_ProductoDetalleId, b = J6.i_IdAlmacen, eliminado = J6.i_Eliminado.Value, _periodo = J6.v_Periodo } into J6_join
                                 from J6 in J6_join.DefaultIfEmpty()

                                 join J7 in dbContext.datahierarchy on new { a = n.i_IdPerfilDetraccion.Value, b = 176 }
                                     equals new { a = J7.i_ItemId, b = J7.i_GroupId } into J7_join
                                 from J7 in J7_join.DefaultIfEmpty()

                                 where n.i_Eliminado == 0 && n.i_EsServicio == 0 && n.i_EsActivoFijo == 0 && n.i_EsActivo == 1
                                 && D_join.Any(p => p.v_IdProductoDetalle.Equals(J6.v_ProductoDetalleId))
                                 select new
                                 {
                                     v_IdProducto = n.v_IdProducto,
                                     v_IdProductoDetalle = D.v_IdProductoDetalle,
                                     v_Descripcion = n.v_Descripcion,
                                     v_CodInterno = n.v_CodInterno,
                                     i_EsServicio = n.i_EsServicio,
                                     i_EsLote = n.i_EsLote,
                                     n.d_PrecioVenta,
                                     i_IdTipoProducto = n.i_IdTipoProducto,
                                     i_IdUnidadMedida = n.i_IdUnidadMedida,
                                     EmpaqueUnidadMedida = J4.v_Value1,
                                     d_Empaque = n.d_Empaque,
                                     i_EsAfectoDetraccion = n.i_EsAfectoDetraccion,
                                     i_NombreEditable = n.i_NombreEditable,
                                     i_ValidarStock = n.i_ValidarStock,
                                     i_EsAfectoPercepcion = n.i_EsAfectoPercepcion,
                                     d_TasaPercepcion = n.d_TasaPercepcion,
                                     i_PrecioEditable = n.i_PrecioEditable,
                                     NroCuentaVenta = J5.v_NroCuentaVenta,
                                     NroCuentaCompra = J5.v_NroCuentaCompra,
                                     NroPedido = J6.v_NroPedido,
                                     stockActual = J6.d_StockActual,
                                     v_IdProductoAlmacen = J6.v_IdProductoAlmacen,
                                     d_Separacion = J6.d_SeparacionTotal == null ? 0 : J6.d_SeparacionTotal,
                                     d_StockActual = J6.d_StockActual,
                                     i_IdAlmacen = J6.i_IdAlmacen,
                                     v_NroPedidoExportacion = J6.v_NroPedido,
                                     ValorUM = string.IsNullOrEmpty(J4.v_Value2) ? "0" : J4.v_Value2,
                                     UM = "UNIDADES",
                                     AfectoIsc = n.i_EsAfectoIsc,
                                     StockMinimo = n.d_StockMinimo == null ? 1 : J6 == null || J6.d_StockActual == null ? 1 : J6.d_StockActual <= n.d_StockMinimo ? 1 : 0,
                                     v_Descripcion2 = n.v_Descripcion2,
                                     TasaDetraccion = J7 != null ? J7.v_Value2 : "0",
                                     TopeDetraccion = J7 != null ? J7.v_Field : "0",

                                    

                                     i_SolicitarNroLoteIngreso = n.i_SolicitarNroLoteIngreso ?? 0,
                                     i_SolicitarNroSerieIngreso = n.i_SolicitarNroSerieIngreso ?? 0,
                                     i_SolicitaOrdenProduccionIngreso = n.i_SolicitaOrdenProduccionIngreso ?? 0,
                                     i_SolicitarNroSerieSalida = n.i_SolicitarNroSerieSalida ?? 0,
                                     i_SolicitarNroLoteSalida = n.i_SolicitarNroLoteSalida ?? 0,
                                     i_SolicitaOrdenProduccionSalida = n.i_SolicitaOrdenProduccionSalida ?? 0,


                                     v_NroLote = J6.v_NroLote,
                                     v_NroSerie = J6.v_NroSerie,
                                     t_FechaCaducidad = J6.t_FechaCaducidad == null ? Fechanull : J6.t_FechaCaducidad.Value ,

                                 }).ToList().Select(p =>
                                 {
                                     var PrecioWortec = Constants.RucWortec == RucEmpresa
                                         ? ListaSaldosIniciales.Where(
                                             a =>
                                                 a.v_IdProductoDetalle == p.v_IdProductoDetalle &&
                                                 a.NroPedido == p.v_NroPedidoExportacion).Sum(a => a.Costo)
                                         : 0;
                                     return new productoshortDto
                                     {
                                         v_IdProducto = p.v_IdProducto,
                                         v_IdProductoDetalle = p.v_IdProductoDetalle,
                                         v_Descripcion = p.v_Descripcion,
                                         v_CodInterno = p.v_CodInterno,
                                         i_EsServicio = p.i_EsServicio,
                                         i_EsLote = p.i_EsLote,
                                         i_IdTipoProducto = p.i_IdTipoProducto,
                                         stockActual = p.v_IdProductoAlmacen != null ? p.stockActual ?? 0 : 0,
                                         v_IdProductoAlmacen = p.v_IdProductoAlmacen,
                                         d_separacion = p.v_IdProductoAlmacen != null ? p.d_Separacion ?? 0 : 0,
                                         i_IdUnidadMedida = p.i_IdUnidadMedida,
                                         EmpaqueUnidadMedida = p.EmpaqueUnidadMedida,
                                         d_Empaque = p.d_Empaque,
                                         i_EsAfectoDetraccion = p.i_EsAfectoDetraccion,
                                         i_NombreEditable = p.i_NombreEditable,
                                         StockDisponible = p.d_StockActual,
                                         i_ValidarStock = p.i_ValidarStock,
                                         i_EsAfectoPercepcion = p.i_EsAfectoPercepcion,
                                         d_TasaPercepcion = p.d_TasaPercepcion,
                                         i_PrecioEditable = p.i_PrecioEditable,
                                         d_Precio = p.v_IdProductoAlmacen != null ? RucEmpresa == Constants.RucWortec ? PrecioWortec != null ? PrecioWortec : 0 : p.d_PrecioVenta : 0,
                                         d_Descuento = 0,
                                         IdMoneda = 1,
                                         NroCuentaVenta = p.NroCuentaVenta,
                                         NroCuentaCompra = p.NroCuentaCompra,
                                         IdAlmacen =
                                             p.v_IdProductoAlmacen != null ? -1 : p.i_IdAlmacen == null ? -1 : p.i_IdAlmacen,
                                         v_NroPedidoExportacion = p.NroPedido,
                                         StockActualUM = p.stockActual == 0 || p.ValorUM == "0" ? 0 : p.stockActual / int.Parse(p.ValorUM),
                                         SeparacionActualUM = p.d_Separacion == 0 || p.ValorUM == "0" ? 0 : p.d_Separacion / int.Parse(p.ValorUM),
                                         SaldoUM =
                                             p.ValorUM == "0"
                                                 ? 0
                                                 : p.stockActual != 0 && p.ValorUM != "0" && p.d_Separacion != 0
                                                     ? (p.stockActual / int.Parse(p.ValorUM)) -
                                                       p.d_Separacion / int.Parse(p.ValorUM)
                                                     : p.stockActual == 0 && p.ValorUM != "0" && p.d_Separacion != 0
                                                         ? -p.d_Separacion / int.Parse(p.ValorUM)
                                                         : p.d_Separacion == 0 && p.ValorUM != "0" && p.stockActual != 0
                                                             ? (p.stockActual / int.Parse(p.ValorUM))
                                                             : 0,
                                         UM = p.UM,
                                         EsAfectoIsc = p.AfectoIsc.HasValue && p.AfectoIsc == 1,
                                         StockMinimo = p.StockMinimo,
                                         v_Descripcion2 = p.v_Descripcion2,
                                         TasaDetraccion = p.TasaDetraccion,
                                         TopeDetraccion = p.TopeDetraccion,
                                         i_SolicitarNroLoteIngreso = p.i_SolicitarNroLoteIngreso,
                                         i_SolicitarNroSerieIngreso = p.i_SolicitarNroSerieIngreso,
                                         i_SolicitaOrdenProduccionIngreso = p.i_SolicitaOrdenProduccionIngreso,
                                         i_SolicitarNroSerieSalida = p.i_SolicitarNroSerieSalida,
                                         i_SolicitarNroLoteSalida = p.i_SolicitarNroLoteSalida,
                                         i_SolicitaOrdenProduccionSalida = p.i_SolicitaOrdenProduccionSalida,

                                         v_NroSerie = p.v_NroSerie,
                                         v_NroLote = p.v_NroLote,
                                         t_FechaCaducidad = p.t_FechaCaducidad,
                                     };
                                 }).AsQueryable();

                        #endregion

                    }

                    List<productoshortDto> objData = query.Cast<productoshortDto>().ToList().OrderBy (o=>o.t_FechaCaducidad).ToList ();
                    pobjOperationResult.Success = 1;
                    return objData;
                }
            }
            catch (Exception ex)
            {
                pobjOperationResult.Success = 0;
                pobjOperationResult.ErrorMessage = ex.Message;
                pobjOperationResult.ExceptionMessage = ex.InnerException != null ? ex.InnerException.Message : string.Empty;
                pobjOperationResult.AdditionalInformation = "MovimientoBL.ListarBusquedaProductoAlmacenPV()";
                return null;
            }
        }

        public List<CostoNotasIngresoPedido> SaldosIniciales(string Periodo)
        {

            using (SAMBHSEntitiesModelWin dbContex = new SAMBHSEntitiesModelWin())
            {
                var SaldosIniciales = (from a in dbContex.movimientodetalle

                                       join b in dbContex.movimiento on new { m = a.v_IdMovimiento, eliminado = 0 } equals new { m = b.v_IdMovimiento, eliminado = b.i_Eliminado.Value } into b_join

                                       from b in b_join.DefaultIfEmpty()

                                       join c in dbContex.cliente on new { c = b.v_IdCliente, eliminado = 0 } equals new { c = c.v_IdCliente, eliminado = c.i_Eliminado.Value } into c_join

                                       from c in c_join.DefaultIfEmpty()

                                       join d in dbContex.documento on new { d = a.i_IdTipoDocumento.Value, eliminado = 0 } equals new { d = d.i_CodigoDocumento, eliminado = d.i_Eliminado.Value } into d_join

                                       from d in d_join.DefaultIfEmpty()

                                       join e in dbContex.productodetalle on new { pd = a.v_IdProductoDetalle, eliminado = 0 } equals new { pd = e.v_IdProductoDetalle, eliminado = e.i_Eliminado.Value } into e_join

                                       from e in e_join.DefaultIfEmpty()
                                       where a.i_Eliminado == 0
                                        && b.i_IdTipoMovimiento == (int)TipoDeMovimiento.NotadeIngreso
                                        && b.v_Periodo == Periodo
                                       select new
                                       {
                                           NroPedido = a.v_NroPedido.Trim(),

                                           Costo = b.i_IdMoneda == (int)Currency.Dolares ? b.v_OrigenTipo == "I" ? a.d_Precio : a.d_PrecioCambio : a.d_Precio / b.d_TipoCambio,
                                           v_IdProductoDetalle = e.v_IdProductoDetalle,



                                       }).ToList().AsQueryable().Select(x => new CostoNotasIngresoPedido
                                       {

                                           Costo = x.Costo ?? 0,
                                           v_IdProductoDetalle = x.v_IdProductoDetalle,
                                           NroPedido = x.NroPedido,
                                       }).ToList();

                //var ff = SaldosIniciales.Where(j => j.v_IdProductoDetalle == "N001-PE000003891").ToList();
                //var hh = ff.Select(h => h.Costo).Average();

                return SaldosIniciales;


            }
        }



        public productoalmacen ObtenerProductoAlmacen(string pstrIdProductoDetalle, List<productoalmacen> ds)
        {
            return ds.FirstOrDefault(p => p.v_ProductoDetalleId == pstrIdProductoDetalle);
        }

        private static decimal[] ObtenerPrecioDescuento(string pstrIdProductoAlmacen, IDictionary<string, decimal[]> ds)
        {
            try
            {
                decimal[] result;
                return ds.TryGetValue(pstrIdProductoAlmacen, out result) ? result : new[] { 0M, 0M };
            }
            catch (Exception)
            {
                return new[] { 0M, 0M };
            }
        }

        private static decimal[] ObtenerPrecioDescuentoNuevo(string obj, IDictionary<string, decimal[]> ds)
        {
            try
            {
                decimal[] result;
                // return ds.TryGetValue(obj, out result) ? result : new[] { 0M, 0M };

                if (ds.TryGetValue(obj, out result))
                {
                    return result;
                }
                else
                {
                    return new[] { 0M, 0M };
                }
            }
            catch (Exception)
            {
                return new[] { 0M, 0M };
            }
        }

        public List<productoshortDto> ListarBusquedaProductoAlmacenNS(ref OperationResult pobjOperationResult, string pstrSortExpression, string pstrFilterExpression, int pintIdAlmacen)
        {
            try
            {
                List<CostoNotasIngresoPedido> ListaSaldosIniciales = new List<CostoNotasIngresoPedido>();
                var RucEmpresa = new NodeBL().ReporteEmpresa().FirstOrDefault().RucEmpresaPropietaria.Trim();
                string periodo = Globals.ClientSession.i_Periodo.ToString();
                if (RucEmpresa == Constants.RucWortec)
                {
                    ListaSaldosIniciales = SaldosIniciales(Globals.ClientSession.i_Periodo.ToString());
                }
                SAMBHSEntitiesModelWin dbContext = new SAMBHSEntitiesModelWin();

                var query = (from n in dbContext.producto
                             join D in dbContext.productodetalle on new { p = n.v_IdProducto, eliminado = 0 } equals new { p = D.v_IdProducto, eliminado = D.i_Eliminado.Value } into D_join
                             from D in D_join.DefaultIfEmpty()

                             join J3 in dbContext.productoalmacen on new { a = D.v_IdProductoDetalle, b = pintIdAlmacen, eliminado = 0, _periodo = periodo }
                                                            equals new { a = J3.v_ProductoDetalleId, b = J3.i_IdAlmacen, eliminado = J3.i_Eliminado.Value, _periodo = J3.v_Periodo } into J3_join
                             from J3 in J3_join.DefaultIfEmpty()

                             join J4 in dbContext.datahierarchy on new { a = n.i_IdUnidadMedida.Value, b = 17, eliminado = 0 }
                                                           equals new { a = J4.i_ItemId, b = J4.i_GroupId, eliminado = J4.i_IsDeleted.Value } into J4_join
                             from J4 in J4_join.DefaultIfEmpty()

                             join J5 in dbContext.linea on new { l = n.v_IdLinea, eliminado = 0 } equals new { l = J5.v_IdLinea, eliminado = J5.i_Eliminado.Value } into J5_join
                             from J5 in J5_join.DefaultIfEmpty()

                             where n.i_Eliminado == 0 && n.i_EsServicio == 0 && n.i_EsActivoFijo == 0 && n.i_EsActivo == 1


                             select new productoshortDto
                             {
                                 v_IdProducto = n.v_IdProducto,
                                 v_IdProductoDetalle = D.v_IdProductoDetalle,
                                 v_Descripcion = n.v_Descripcion,
                                 v_CodInterno = n.v_CodInterno,
                                 i_EsServicio = n.i_EsServicio == null ? 0 : n.i_EsServicio,
                                 i_EsLote = n.i_EsLote == null ? 0 : n.i_EsLote,
                                 i_IdTipoProducto = n.i_IdTipoProducto == null ? -1 : n.i_IdTipoProducto,
                                 stockActual = J3 == null ? 0 : J3.d_StockActual ?? 0,
                                 v_IdProductoAlmacen = J3 == null ? null : J3.v_IdProductoAlmacen,
                                 d_separacion = J3 == null ? 0 : J3.d_SeparacionTotal ?? 0,
                                 i_IdUnidadMedida = n.i_IdUnidadMedida,
                                 EmpaqueUnidadMedida = J4.v_Value1,
                                 d_Empaque = n.d_Empaque,
                                 i_EsAfectoDetraccion = n.i_EsAfectoDetraccion == null ? 0 : n.i_EsAfectoDetraccion,
                                 i_NombreEditable = n.i_NombreEditable == null ? 0 : n.i_NombreEditable,
                                 StockDisponible = J3 == null ? 0 : J3.d_StockActual == null && J3.d_SeparacionTotal == null ? 0 : J3.d_StockActual == null ? -J3.d_SeparacionTotal.Value : J3.d_SeparacionTotal == null ? J3.d_StockActual : J3.d_StockActual - J3.d_SeparacionTotal,
                                 i_ValidarStock = n.i_ValidarStock == null ? 0 : n.i_ValidarStock,
                                 i_EsAfectoPercepcion = n.i_EsAfectoPercepcion == null ? 0 : n.i_EsAfectoPercepcion,
                                 d_TasaPercepcion = n.d_TasaPercepcion == null ? 0 : n.d_TasaPercepcion,
                                 i_PrecioEditable = n.i_PrecioEditable == null ? 0 : n.i_PrecioEditable,
                                 NroCuentaVenta = J5.v_NroCuentaVenta,
                                 NroCuentaCompra = J5.v_NroCuentaCompra,
                                 IdAlmacen = J3 == null ? -1 : J3.i_IdAlmacen,
                                 v_NroPedidoExportacion = J3 == null ? null : J3.v_NroPedido,
                                 ValorUM = string.IsNullOrEmpty(J4.v_Value2) ? "0" : J4.v_Value2,
                                 EsAfectoIsc = n.i_EsAfectoIsc.HasValue && n.i_EsAfectoIsc == 1,
                                 UM = "UNIDADES",
                                 StockMinimo = n.d_StockMinimo == null ? 1 : J3 == null || J3.d_StockActual == null ? 1 : J3.d_StockActual <= n.d_StockMinimo ? 1 : 0,
                                 v_Descripcion2 = n.v_Descripcion2,

                                 i_SolicitarNroLoteIngreso = n.i_SolicitarNroLoteIngreso ?? 0,
                                 i_SolicitarNroSerieIngreso = n.i_SolicitarNroSerieIngreso ?? 0,
                                 i_SolicitaOrdenProduccionIngreso = n.i_SolicitaOrdenProduccionIngreso ?? 0,
                                 i_SolicitarNroSerieSalida = n.i_SolicitarNroSerieSalida ?? 0,
                                 i_SolicitarNroLoteSalida = n.i_SolicitarNroLoteSalida ?? 0,
                                 i_SolicitaOrdenProduccionSalida = n.i_SolicitaOrdenProduccionSalida ?? 0,

                                 v_NroLote = J3.v_NroLote,
                                 v_NroSerie = J3.v_NroSerie,
                                 t_FechaCaducidad = J3.t_FechaCaducidad == null ? Fechanull : J3.t_FechaCaducidad.Value ,
                                 d_Precio =n.d_PrecioCosto ??0,

                             }
                             ).ToList().Select(x =>
                             {
                                 var PrecioWortec = Constants.RucWortec == RucEmpresa ? ListaSaldosIniciales.Where(a => a.v_IdProductoDetalle == x.v_IdProductoDetalle && a.NroPedido == x.v_NroPedidoExportacion).ToList() : null;

                                 return new productoshortDto
                                 {
                                     v_IdProducto = x.v_IdProducto,
                                     v_IdProductoDetalle = x.v_IdProductoDetalle,
                                     v_Descripcion = x.v_Descripcion,
                                     v_CodInterno = x.v_CodInterno,
                                     i_EsServicio = x.i_EsServicio,
                                     i_EsLote = x.i_EsLote,
                                     i_IdTipoProducto = x.i_IdTipoProducto,
                                     stockActual = Math.Round(x.stockActual.Value, 0),
                                     v_IdProductoAlmacen = x.v_IdProductoAlmacen,
                                     d_separacion = x.d_separacion,
                                     i_IdUnidadMedida = x.i_IdUnidadMedida,
                                     EmpaqueUnidadMedida = x.EmpaqueUnidadMedida,
                                     d_Empaque = x.d_Empaque,
                                     i_EsAfectoDetraccion = x.i_EsAfectoDetraccion,
                                     i_NombreEditable = x.i_NombreEditable,
                                     StockDisponible = x.StockDisponible,
                                     i_ValidarStock = x.i_ValidarStock,
                                     i_EsAfectoPercepcion = x.i_EsAfectoPercepcion,
                                     d_TasaPercepcion = x.d_TasaPercepcion,
                                     i_PrecioEditable = x.i_PrecioEditable,
                                     NroCuentaVenta = x.NroCuentaVenta,
                                     NroCuentaCompra = x.NroCuentaCompra,
                                     IdAlmacen = x.IdAlmacen,
                                     v_NroPedidoExportacion = x.v_NroPedidoExportacion,
                                     d_Precio =  RucEmpresa == Constants.RucHormiguita ? x.d_Precio  :  RucEmpresa == Constants.RucWortec ? (PrecioWortec.Any() ? Utils.Windows.DevuelveValorRedondeado(PrecioWortec.Average(z => z.Costo), 4) : 0) : 0,
                                     StockActualUM = x.stockActual == 0 ? 0 : x.stockActual / decimal.Parse(x.ValorUM),
                                     SeparacionActualUM = x.d_separacion == 0 ? 0 : x.d_separacion / decimal.Parse(x.ValorUM),
                                     SaldoUM = x.stockActual == 0 || x.d_separacion == 0 ? 0 : (x.stockActual / decimal.Parse(x.ValorUM)) - x.d_separacion / decimal.Parse(x.ValorUM),
                                     UM = x.UM,
                                     EsAfectoIsc = x.EsAfectoIsc,
                                     StockMinimo = x.StockMinimo,
                                     v_Descripcion2 = x.v_Descripcion2,
                                     IdMoneda = 1,


                                     i_SolicitarNroLoteIngreso = x.i_SolicitarNroLoteIngreso,
                                     i_SolicitarNroSerieIngreso = x.i_SolicitarNroSerieIngreso,
                                     i_SolicitaOrdenProduccionIngreso = x.i_SolicitaOrdenProduccionIngreso,
                                     i_SolicitarNroSerieSalida = x.i_SolicitarNroSerieSalida,
                                     i_SolicitarNroLoteSalida = x.i_SolicitarNroLoteSalida,
                                     i_SolicitaOrdenProduccionSalida = x.i_SolicitaOrdenProduccionSalida,



                                     v_NroLote = x.v_NroLote,
                                     v_NroSerie = x.v_NroSerie,
                                     t_FechaCaducidad = x.t_FechaCaducidad,
                                    
                                 };
                             }).ToList().AsQueryable();
                List<productoshortDto> objData = query.ToList().OrderBy(o => o.t_FechaCaducidad).ToList();
                pobjOperationResult.Success = 1;
                return objData;
            }
            catch (Exception ex)
            {
                pobjOperationResult.Success = 0;
                pobjOperationResult.ExceptionMessage = Utils.ExceptionFormatter(ex);
                return null;
            }
        }

        public List<productoshortDto> ListarBusquedaProductoAlmacenNSPrecios(ref OperationResult pobjOperationResult, string pstrSortExpression, string pstrFilterExpression, int pintIdAlmacen, string pstrIdCliente)
        {
            try
            {
                List<CostoNotasIngresoPedido> ListaSaldosIniciales = new List<CostoNotasIngresoPedido>();
                var RucEmpresa = new NodeBL().ReporteEmpresa().FirstOrDefault().RucEmpresaPropietaria.Trim();
                SAMBHSEntitiesModelWin dbContext = new SAMBHSEntitiesModelWin();
                //var SeparacionesTodas = dbContext.productoalmacen.Where(o => o.i_Eliminado == 0).ToList();
                if (RucEmpresa == Constants.RucWortec)
                {
                    ListaSaldosIniciales = SaldosIniciales(Globals.ClientSession.i_Periodo.ToString());
                }

                var periodo = Globals.ClientSession.i_Periodo.ToString();

                var Cliente = dbContext.cliente.FirstOrDefault(p => p.v_IdCliente == pstrIdCliente);

                var IdListaPrecios = Cliente != null ? (Cliente.i_IdListaPrecios ?? 1) : 1;

                var ListaPrecioDto =
                    dbContext.listaprecio.FirstOrDefault(
                        p => p.i_IdAlmacen == pintIdAlmacen && p.i_IdLista == IdListaPrecios && p.i_Eliminado == 0);

                var dsListaPreciosDetalle =
                    dbContext.listapreciodetalle.Where(
                        p =>
                            p.listaprecio.i_IdAlmacen == pintIdAlmacen && p.listaprecio.i_IdLista == IdListaPrecios &&
                            p.i_Eliminado == 0).ToDictionary(p => string.Join(",", p.v_IdProductoDetalle, p.i_IdAlmacen ?? 1), o => new[] { o.d_Precio ?? 0, o.d_Descuento ?? 0 });

                var query = (from n in dbContext.producto
                             join D in dbContext.productodetalle on new { p = n.v_IdProducto, eliminado = 0 } equals new { p = D.v_IdProducto, eliminado = D.i_Eliminado.Value } into D_join
                             from D in D_join.DefaultIfEmpty()

                             join J3 in dbContext.productoalmacen on new { a = D.v_IdProductoDetalle, b = pintIdAlmacen, eliminado = 0, _periodo = periodo }
                                                            equals new { a = J3.v_ProductoDetalleId, b = J3.i_IdAlmacen, eliminado = J3.i_Eliminado.Value, _periodo = J3.v_Periodo } into J3_join
                             from J3 in J3_join.DefaultIfEmpty()

                             join J4 in dbContext.datahierarchy on new { a = n.i_IdUnidadMedida.Value, b = 17, eliminado = 0 }
                                                           equals new { a = J4.i_ItemId, b = J4.i_GroupId, eliminado = J4.i_IsDeleted.Value } into J4_join
                             from J4 in J4_join.DefaultIfEmpty()

                             join J5 in dbContext.linea on new { l = n.v_IdLinea, eliminado = 0 } equals new { l = J5.v_IdLinea, eliminado = J5.i_Eliminado.Value } into J5_join
                             from J5 in J5_join.DefaultIfEmpty()

                             where n.i_Eliminado == 0 && n.i_EsServicio == 0 && n.i_EsActivoFijo == 0 && n.i_EsActivo == 1 &&
                              D_join.Any(p => p.v_IdProductoDetalle == J3.v_ProductoDetalleId)

                             select new productoshortDto
                             {
                                 v_IdProducto = n.v_IdProducto,
                                 v_IdProductoDetalle = D.v_IdProductoDetalle,
                                 v_Descripcion = n.v_Descripcion,
                                 v_CodInterno = n.v_CodInterno,
                                 i_EsServicio = n.i_EsServicio == null ? 0 : n.i_EsServicio,
                                 i_EsLote = n.i_EsLote == null ? 0 : n.i_EsLote,
                                 i_IdTipoProducto = n.i_IdTipoProducto == null ? -1 : n.i_IdTipoProducto,
                                 stockActual = J3 == null ? 0 : J3.d_StockActual ?? 0,
                                 v_IdProductoAlmacen = J3 == null ? null : J3.v_IdProductoAlmacen,
                                 d_separacion = J3 == null ? 0 : J3.d_SeparacionTotal ?? 0,
                                 i_IdUnidadMedida = n.i_IdUnidadMedida,
                                 EmpaqueUnidadMedida = J4.v_Value1,
                                 d_Empaque = n.d_Empaque,
                                 i_EsAfectoDetraccion = n.i_EsAfectoDetraccion == null ? 0 : n.i_EsAfectoDetraccion,
                                 i_NombreEditable = n.i_NombreEditable == null ? 0 : n.i_NombreEditable,
                                 StockDisponible = J3 == null ? 0 : J3.d_StockActual == null && J3.d_SeparacionTotal == null ? 0 : J3.d_StockActual == null ? -J3.d_SeparacionTotal.Value : J3.d_SeparacionTotal == null ? J3.d_StockActual : J3.d_StockActual - J3.d_SeparacionTotal,
                                 i_ValidarStock = n.i_ValidarStock == null ? 0 : n.i_ValidarStock,
                                 i_EsAfectoPercepcion = n.i_EsAfectoPercepcion == null ? 0 : n.i_EsAfectoPercepcion,
                                 d_TasaPercepcion = n.d_TasaPercepcion == null ? 0 : n.d_TasaPercepcion,
                                 i_PrecioEditable = n.i_PrecioEditable == null ? 0 : n.i_PrecioEditable,
                                 NroCuentaVenta = J5.v_NroCuentaVenta,
                                 NroCuentaCompra = J5.v_NroCuentaCompra,
                                 IdAlmacen = J3 == null ? -1 : J3.i_IdAlmacen,
                                 v_NroPedidoExportacion = J3 == null ? null : J3.v_NroPedido,
                                 ValorUM = string.IsNullOrEmpty(J4.v_Value2) ? "0" : J4.v_Value2,
                                 EsAfectoIsc = n.i_EsAfectoIsc.HasValue && n.i_EsAfectoIsc == 1,
                                 UM = "UNIDADES",
                                 i_IdAlmacen = J3.i_IdAlmacen,
                                 StockMinimo = n.d_StockMinimo == null ? 1 : J3 == null || J3.d_StockActual == null ? 1 : J3.d_StockActual <= n.d_StockMinimo ? 1 : 0,
                                 v_Descripcion2 = n.v_Descripcion2,

                                 i_SolicitarNroLoteIngreso = n.i_SolicitarNroLoteIngreso ?? 0,
                                 i_SolicitarNroSerieIngreso = n.i_SolicitarNroSerieIngreso ?? 0,
                                 i_SolicitaOrdenProduccionIngreso = n.i_SolicitaOrdenProduccionIngreso ?? 0,
                                 i_SolicitarNroSerieSalida = n.i_SolicitarNroSerieSalida ?? 0,
                                 i_SolicitarNroLoteSalida = n.i_SolicitarNroLoteSalida ?? 0,
                                 i_SolicitaOrdenProduccionSalida = n.i_SolicitaOrdenProduccionSalida ?? 0,

                                 v_NroLote = J3.v_NroLote,
                                 v_NroSerie = J3.v_NroSerie,
                                 t_FechaCaducidad = J3.t_FechaCaducidad == null ? Fechanull: J3.t_FechaCaducidad.Value ,

                             }
                             ).ToList().Select(x =>
                             {

                                 var PrecioWortec = Constants.RucWortec == RucEmpresa ? ListaSaldosIniciales.Where(a => a.v_IdProductoDetalle == x.v_IdProductoDetalle && a.NroPedido == x.v_NroPedidoExportacion).ToList() : null;
                                 ProducDetalleAlmacen obj = new ProducDetalleAlmacen();
                                 obj.IdProductoDetalle = x.v_IdProductoDetalle;
                                 obj.IdAlmacen = x.i_IdAlmacen;
                                 var objListaPrecioDetalle = ObtenerPrecioDescuentoNuevo(string.Join(",", obj.IdProductoDetalle, obj.IdAlmacen), dsListaPreciosDetalle);
                                 //var Separacion = SeparacionesTodas.Where(o => o.v_ProductoDetalleId == x.v_IdProductoDetalle && o.i_IdAlmacen == x.i_IdAlmacen).ToList();
                                 return new productoshortDto
                                 {
                                     v_IdProducto = x.v_IdProducto,
                                     v_IdProductoDetalle = x.v_IdProductoDetalle,
                                     v_Descripcion = x.v_Descripcion,
                                     v_CodInterno = x.v_CodInterno,
                                     i_EsServicio = x.i_EsServicio,
                                     i_EsLote = x.i_EsLote,
                                     i_IdTipoProducto = x.i_IdTipoProducto,
                                     stockActual = x.stockActual,
                                     v_IdProductoAlmacen = x.v_IdProductoAlmacen,
                                     d_separacion = x.d_separacion,
                                     //d_separacion = Separacion .Any ()? Separacion.Sum (o=>o.d_SeparacionTotal).Value :0,
                                     i_IdUnidadMedida = x.i_IdUnidadMedida,
                                     EmpaqueUnidadMedida = x.EmpaqueUnidadMedida,
                                     d_Empaque = x.d_Empaque,
                                     i_EsAfectoDetraccion = x.i_EsAfectoDetraccion,
                                     i_NombreEditable = x.i_NombreEditable,
                                     StockDisponible = x.StockDisponible,
                                     i_ValidarStock = x.i_ValidarStock,
                                     i_EsAfectoPercepcion = x.i_EsAfectoPercepcion,
                                     d_TasaPercepcion = x.d_TasaPercepcion,
                                     i_PrecioEditable = x.i_PrecioEditable,
                                     NroCuentaVenta = x.NroCuentaVenta,
                                     NroCuentaCompra = x.NroCuentaCompra,
                                     IdAlmacen = x.IdAlmacen,
                                     v_NroPedidoExportacion = x.v_NroPedidoExportacion,
                                     d_Precio = Constants.RucWortec == RucEmpresa ? PrecioWortec.Any() ? Utils.Windows.DevuelveValorRedondeado(PrecioWortec.Average(z => z.Costo), 4) : 0 : objListaPrecioDetalle[0],
                                     d_Descuento = objListaPrecioDetalle[1],
                                     IdMoneda = ListaPrecioDto != null ? ListaPrecioDto.i_IdMoneda.Value : -1,
                                     StockActualUM = x.stockActual == 0 ? 0 : x.stockActual / int.Parse(x.ValorUM),
                                     SeparacionActualUM = x.d_separacion == 0 ? 0 : x.d_separacion / int.Parse(x.ValorUM),
                                     //SeparacionActualUM = !Separacion.Any() ? 0 : Separacion.Sum(o => o.d_SeparacionTotal).Value ==0 ?0 :(Separacion.Sum(o => o.d_SeparacionTotal).Value) / int.Parse(x.ValorUM),
                                     SaldoUM = x.stockActual == 0 || x.d_separacion == 0 ? 0 : (x.stockActual / int.Parse(x.ValorUM)) - x.d_separacion / int.Parse(x.ValorUM),
                                     UM = x.UM,
                                     EsAfectoIsc = x.EsAfectoIsc,
                                     StockMinimo = x.StockMinimo,
                                     v_Descripcion2 = x.v_Descripcion2,
                                     i_SolicitarNroLoteIngreso = x.i_SolicitarNroLoteIngreso,
                                     i_SolicitarNroSerieIngreso = x.i_SolicitarNroSerieIngreso,
                                     i_SolicitaOrdenProduccionIngreso = x.i_SolicitaOrdenProduccionIngreso,
                                     i_SolicitarNroSerieSalida = x.i_SolicitarNroSerieSalida,
                                     i_SolicitarNroLoteSalida = x.i_SolicitarNroLoteSalida,
                                     i_SolicitaOrdenProduccionSalida = x.i_SolicitaOrdenProduccionSalida,
                                     v_NroLote = x.v_NroLote,
                                     v_NroSerie = x.v_NroSerie,
                                     t_FechaCaducidad = x.t_FechaCaducidad,
                                 };
                             }).ToList().AsQueryable();
                List<productoshortDto> objData = query.ToList().OrderBy (o=>o.t_FechaCaducidad ).ToList ();
                pobjOperationResult.Success = 1;
                return objData;
            }
            catch (Exception ex)
            {
                pobjOperationResult.Success = 0;
                pobjOperationResult.ExceptionMessage = Utils.ExceptionFormatter(ex);
                return null;
            }
        }

        public List<productoshortDto> ListarBusquedaConsultaProductoStock(ref OperationResult pobjOperationResult, string pstrSortExpression, string pstrFilterExpression, int pintIdAlmacen, bool SoloStockMayor0, bool SoloStockDiferente0, int FormatCant)
        {
            try
            {
                string periodo = Globals.ClientSession.i_Periodo.ToString();
                List<productoshortDto> ListaProductosDTO = new List<productoshortDto>();
                OperationResult objOperationResult = new OperationResult();
                SAMBHSEntitiesModelWin dbContext = new SAMBHSEntitiesModelWin();
                var query = (from n in dbContext.producto
                             join D in dbContext.productodetalle on new { p = n.v_IdProducto, eliminado = 0 } equals new { p = D.v_IdProducto, eliminado = D.i_Eliminado.Value } into D_join
                             from D in D_join.DefaultIfEmpty()

                             join J1 in dbContext.datahierarchy on new { a = n.i_IdUnidadMedida.Value, b = 17, eliminado = 0 }
                                                          equals new { a = J1.i_ItemId, b = J1.i_GroupId, eliminado = J1.i_IsDeleted.Value } into J1_join
                             from J1 in J1_join.DefaultIfEmpty()

                             join J3 in dbContext.productoalmacen on new { a = D.v_IdProductoDetalle, b = pintIdAlmacen, eliminado = 0, pstrPeriodo = periodo }
                                                            equals new { a = J3.v_ProductoDetalleId, b = J3.i_IdAlmacen, eliminado = J3.i_Eliminado.Value, pstrPeriodo = J3.v_Periodo } into J3_join
                             from J3 in J3_join.DefaultIfEmpty()

                             join J4 in dbContext.datahierarchy on new { a = n.i_IdUnidadMedida.Value, b = 17, eliminado = 0 }
                                                           equals new { a = J4.i_ItemId, b = J4.i_GroupId, eliminado = J4.i_IsDeleted.Value } into J4_join
                             from J4 in J4_join.DefaultIfEmpty()

                             join J5 in dbContext.datahierarchy on new { Grupo = 17, eliminado = 0, Um = n.i_IdUnidadMedida.Value } equals new { Grupo = J5.i_GroupId, eliminado = J5.i_IsDeleted.Value, Um = J5.i_ItemId } into J5_join
                             from J5 in J5_join.DefaultIfEmpty()

                             where n.i_Eliminado == 0 && n.i_EsServicio == 0

                             && n.i_EsActivoFijo == 0
                             select new productoshortDto
                             {
                                 v_IdProducto = n.v_IdProducto,
                                 v_IdProductoDetalle = D.v_IdProductoDetalle,
                                 v_Descripcion = n.v_Descripcion,
                                 v_CodInterno = n.v_CodInterno,
                                 i_EsServicio = n.i_EsServicio,
                                 i_EsLote = n.i_EsLote,
                                 i_IdTipoProducto = n.i_IdTipoProducto,
                                 stockActual = J3.d_StockActual == null ? 0 : J3.d_StockActual,
                                 v_IdProductoAlmacen = J3.v_IdProductoAlmacen,
                                 d_separacion = J3.d_SeparacionTotal == null ? 0 : J3.d_SeparacionTotal,
                                 i_IdUnidadMedida = n.i_IdUnidadMedida,
                                 EmpaqueUnidadMedida = J4.v_Value1,
                                 d_Empaque = n.d_Empaque,
                                 i_EsAfectoDetraccion = n.i_EsAfectoDetraccion,
                                 i_NombreEditable = n.i_NombreEditable,
                                 StockDisponible = J3.d_StockActual == null ? 0 - J3.d_SeparacionTotal : J3.d_SeparacionTotal == null ? J3.d_StockActual : J3.d_StockActual - J3.d_SeparacionTotal,
                                 i_ValidarStock = n.i_ValidarStock,
                                 i_EsAfectoPercepcion = n.i_EsAfectoPercepcion,
                                 d_TasaPercepcion = n.d_TasaPercepcion,
                                 i_PrecioEditable = n.i_PrecioEditable,
                                 EmpaqueUnidadMedidaFinal = "",
                                 ValorUM = J5.v_Value2.Trim(),

                             });
                if (!string.IsNullOrEmpty(pstrFilterExpression))
                {
                    query = query.Where(pstrFilterExpression);

                }
                if (!string.IsNullOrEmpty(pstrSortExpression))
                {
                    query = query.OrderBy(pstrSortExpression);
                }

                List<productoshortDto> objData = query.ToList();

                var gg = objData.Where(o => string.IsNullOrEmpty(o.ValorUM)).ToList();
                var hh = objData.Select(o => o.ValorUM).Distinct().ToList();
                objData = objData.ToList().Select(n => new productoshortDto
                {
                    v_IdProducto = n.v_IdProducto,
                    v_IdProductoDetalle = n.v_IdProductoDetalle,
                    v_Descripcion = n.v_Descripcion,
                    v_CodInterno = n.v_CodInterno,
                    i_EsServicio = n.i_EsServicio,
                    i_EsLote = n.i_EsLote,
                    i_IdTipoProducto = n.i_IdTipoProducto,
                    stockActual = n.stockActual == 0 || decimal.Parse(n.ValorUM) == 0 ? 0 : FormatCant == (int)FormatoCantidad.Unidades ? n.stockActual : n.stockActual.Value / decimal.Parse(n.ValorUM),
                    v_IdProductoAlmacen = n.v_IdProductoAlmacen,
                    d_separacion = n.d_separacion == 0 || decimal.Parse(n.ValorUM) == 0 ? 0 : FormatCant == (int)FormatoCantidad.Unidades ? n.d_separacion : n.d_separacion / decimal.Parse(n.ValorUM),
                    i_IdUnidadMedida = n.i_IdUnidadMedida,
                    EmpaqueUnidadMedida = n.EmpaqueUnidadMedida,
                    d_Empaque = n.d_Empaque,
                    i_EsAfectoDetraccion = n.i_EsAfectoDetraccion,
                    i_NombreEditable = n.i_NombreEditable,
                    StockDisponible = n.StockDisponible == 0 || decimal.Parse(n.ValorUM) == 0 || n.StockDisponible == null ? 0 : FormatCant == (int)FormatoCantidad.Unidades ? n.StockDisponible : decimal.Parse(n.ValorUM) == 0 ? 0 : n.StockDisponible / decimal.Parse(n.ValorUM),
                    i_ValidarStock = n.i_ValidarStock,
                    i_EsAfectoPercepcion = n.i_EsAfectoPercepcion,
                    d_TasaPercepcion = n.d_TasaPercepcion.Value,
                    i_PrecioEditable = n.i_PrecioEditable,
                    EmpaqueUnidadMedidaFinal = FormatCant == (int)FormatoCantidad.Unidades ? "UNIDADES" : n.EmpaqueUnidadMedida,


                }).ToList();
                List<productoshortDto> queryFiltrado = new List<productoshortDto>();

                if (SoloStockMayor0)
                {
                    queryFiltrado = (from n in objData
                                     where n.stockActual > 0 || n.StockDisponible > 0
                                     select n).ToList();

                }
                else if (SoloStockDiferente0)
                {
                    queryFiltrado = (from n in objData
                                     where n.stockActual <= 0
                                     select n).ToList();
                }

                else
                {
                    queryFiltrado = objData;
                }

                pobjOperationResult.Success = 1;
                return queryFiltrado;


            }
            catch (Exception ex)
            {

                pobjOperationResult.Success = 0;
                pobjOperationResult.AdditionalInformation = "MovimientoBL. ListarBusquedaConsultaProductoStock()\nLinea:" + ex.StackTrace.Substring(ex.StackTrace.LastIndexOf(' '));
                pobjOperationResult.ErrorMessage = ex.Message;
                pobjOperationResult.ExceptionMessage = pobjOperationResult.ExceptionMessage != null ? ex.InnerException.Message : string.Empty;
                return null;
            }
        }

        public List<productoshortDto> ListarBusquedaConsultaProductoStockManguifajas(ref OperationResult pobjOperationResult, string pstrSortExpression, int pintIdAlmacen, bool SoloStockMayor0, bool SoloStockDiferente0, int FormatCant, bool TodosProductos)
        {
            try
            {

                string periodo = Globals.ClientSession.i_Periodo.ToString();
                List<productoshortDto> ListaProductosDTO = new List<productoshortDto>();
                OperationResult objOperationResult = new OperationResult();
                SAMBHSEntitiesModelWin dbContext = new SAMBHSEntitiesModelWin();
                DateTime fecha1 = DateTime.Parse("01/01/" + Globals.ClientSession.i_Periodo.ToString());
                DateTime fecha2 = DateTime.Now;
                var Establecimiento = BuscarIdEstablecimiento(pintIdAlmacen).i_IdEstablecimiento;
                var Kardex = new AlmacenBL().ReporteStockConsolidado(ref objOperationResult, fecha1, fecha2, "", "-1", Establecimiento, "", "-1", false, false, false, false, -1, pintIdAlmacen, FormatCant);
                var KardexAgrupado = Kardex.ToList().GroupBy(o => o.v_IdProductoDetalle).Select(y =>
                           {
                               var primero = y.FirstOrDefault() != null ? y.FirstOrDefault() : new ReporteStockConsolidado();
                               return new ReporteStockConsolidado
                               {

                                   cantidad = y.Sum(o => o.cantidad),
                                   cantidadAlmacen1 = y.Sum(o => o.cantidadAlmacen1),
                                   v_IdProductoDetalle = primero.v_IdProductoDetalle,
                                   IdProducto = primero.IdProducto,



                               };
                           });

                var KardexDictionary = KardexAgrupado.ToDictionary(o => o.v_IdProductoDetalle, o => o);


                var query = (from n in dbContext.producto
                             join D in dbContext.productodetalle on new { p = n.v_IdProducto, eliminado = 0 } equals new { p = D.v_IdProducto, eliminado = D.i_Eliminado.Value } into D_join
                             from D in D_join.DefaultIfEmpty()

                             join J1 in dbContext.datahierarchy on new { a = n.i_IdUnidadMedida.Value, b = 17, eliminado = 0 }
                                                          equals new { a = J1.i_ItemId, b = J1.i_GroupId, eliminado = J1.i_IsDeleted.Value } into J1_join
                             from J1 in J1_join.DefaultIfEmpty()

                             join J3 in dbContext.productoalmacen on new { a = D.v_IdProductoDetalle, b = pintIdAlmacen, eliminado = 0 }
                                                            equals new { a = J3.v_ProductoDetalleId, b = J3.i_IdAlmacen, eliminado = J3.i_Eliminado.Value } into J3_join
                             from J3 in J3_join.DefaultIfEmpty()

                             join J4 in dbContext.datahierarchy on new { a = n.i_IdUnidadMedida.Value, b = 17, eliminado = 0 }
                                                           equals new { a = J4.i_ItemId, b = J4.i_GroupId, eliminado = J4.i_IsDeleted.Value } into J4_join
                             from J4 in J4_join.DefaultIfEmpty()

                             join J5 in dbContext.datahierarchy on new { Grupo = 17, eliminado = 0, Um = n.i_IdUnidadMedida.Value }
                                equals new { Grupo = J5.i_GroupId, eliminado = J5.i_IsDeleted.Value, Um = J5.i_ItemId } into J5_join
                             from J5 in J5_join.DefaultIfEmpty()

                             join J6 in dbContext.listaprecio on new { Almacen = pintIdAlmacen, ListaPrecio = 1, eliminado = 0 } equals new { Almacen = J6.i_IdAlmacen.Value, ListaPrecio = J6.i_IdLista.Value, eliminado = J6.i_Eliminado.Value } into J6_join

                             from J6 in J6_join.DefaultIfEmpty()

                             join J7 in dbContext.listapreciodetalle on new { prodDetalle = J3.v_ProductoDetalleId, IdListaPrecioDetalle = J6.v_IdListaPrecios, eliminado = 0, almacen = J3.i_IdAlmacen } equals new { prodDetalle = J7.v_IdProductoDetalle, IdListaPrecioDetalle = J7.v_IdListaPrecios, eliminado = J7.i_Eliminado.Value, almacen = J7.i_IdAlmacen.Value } into J7_join

                             from J7 in J7_join.DefaultIfEmpty()

                             join J8 in dbContext.linea on new { linea = n.v_IdLinea, eliminado = 0 } equals new { linea = J8.v_IdLinea, eliminado = J8.i_Eliminado.Value } into J8_join

                             from J8 in J8_join.DefaultIfEmpty()

                             where n.i_Eliminado == 0 && n.i_EsServicio == 0

                             && n.i_EsActivoFijo == 0 && J3.v_Periodo == periodo
                             select new
                             {
                                 v_IdProducto = n.v_IdProducto,
                                 v_IdProductoDetalle = D.v_IdProductoDetalle,
                                 v_Descripcion = n.v_Descripcion,
                                 v_CodInterno = n.v_CodInterno,
                                 i_EsServicio = n.i_EsServicio,
                                 i_EsLote = n.i_EsLote,
                                 i_IdTipoProducto = n.i_IdTipoProducto,
                                 v_IdProductoAlmacen = J3.v_IdProductoAlmacen,
                                 d_separacion = J3.d_SeparacionTotal ?? 0,
                                 i_IdUnidadMedida = n.i_IdUnidadMedida,
                                 EmpaqueUnidadMedida = J4.v_Value1,
                                 d_Empaque = n.d_Empaque,
                                 i_EsAfectoDetraccion = n.i_EsAfectoDetraccion,
                                 i_NombreEditable = n.i_NombreEditable,
                                 i_ValidarStock = n.i_ValidarStock,
                                 i_EsAfectoPercepcion = n.i_EsAfectoPercepcion,
                                 d_TasaPercepcion = n.d_TasaPercepcion,
                                 i_PrecioEditable = n.i_PrecioEditable,
                                 EmpaqueUnidadMedidaFinal = "",
                                 ValorUM = string.IsNullOrEmpty(J5.v_Value2) ? "1" : J5.v_Value2.Trim(),
                                 PrecioVenta = J7 == null ? 0 : J7.d_Precio ?? 0,
                                 d_Costo = n.d_PrecioCosto ?? 0,
                                 Moneda = J6 == null || J6.i_IdMoneda == null ? "" : J6.i_IdMoneda == (int)Currency.Soles ? "SOLES" : "DOLARES",
                                 Linea = J8.v_Nombre,
                                 Ubicacion = n.v_Ubicacion,
                             }).ToList().Select(n =>
                                 {

                                     ReporteStockConsolidado stockActualPa;
                                     stockActualPa = KardexDictionary.TryGetValue(n.v_IdProductoDetalle, out stockActualPa) ? stockActualPa : new ReporteStockConsolidado();
                                     var StockActual = pintIdAlmacen == -1 ? stockActualPa != null ? stockActualPa.cantidad ?? 0 : 0 : stockActualPa != null ? stockActualPa.cantidadAlmacen1 ?? 0 : 0;
                                     var Separacion = FormatCant == (int)FormatoCantidad.Unidades ? n.d_separacion : decimal.Parse(n.ValorUM) == 0 ? 0 : n.d_separacion / decimal.Parse(n.ValorUM);
                                     //var StockDisponible =   StockActual - n.d_separacion;
                                     var StockDisponible = StockActual - Separacion;
                                     CodigoError = n.v_IdProducto;
                                     return new productoshortDto
                                  {

                                      v_IdProducto = n.v_IdProducto,
                                      v_IdProductoDetalle = n.v_IdProductoDetalle,
                                      v_Descripcion = n.v_Descripcion,
                                      v_CodInterno = n.v_CodInterno,
                                      i_EsServicio = n.i_EsServicio,
                                      i_EsLote = n.i_EsLote,
                                      i_IdTipoProducto = n.i_IdTipoProducto,
                                      i_IdUnidadMedida = n.i_IdUnidadMedida,
                                      EmpaqueUnidadMedida = n.EmpaqueUnidadMedida,
                                      d_Empaque = n.d_Empaque,
                                      i_EsAfectoDetraccion = n.i_EsAfectoDetraccion,
                                      i_NombreEditable = n.i_NombreEditable,
                                      i_ValidarStock = n.i_ValidarStock,
                                      i_EsAfectoPercepcion = n.i_EsAfectoPercepcion,
                                      d_TasaPercepcion = n.d_TasaPercepcion,
                                      i_PrecioEditable = n.i_PrecioEditable,
                                      StockDisponible = StockDisponible,
                                      stockActual = StockActual,
                                      d_separacion = n.d_separacion == 0 || decimal.Parse(n.ValorUM) == 0 ? 0 : FormatCant == (int)FormatoCantidad.Unidades ? n.d_separacion : n.d_separacion / decimal.Parse(n.ValorUM),
                                      EmpaqueUnidadMedidaFinal = FormatCant == (int)FormatoCantidad.Unidades ? "UNIDADES" : n.EmpaqueUnidadMedida,
                                      PrecioVenta = Math.Round(n.PrecioVenta, 2),
                                      d_Costo = Math.Round(n.d_Costo, 2),
                                      Moneda = n.Moneda,
                                      v_IdProductoAlmacen = n.v_IdProductoAlmacen,
                                      Linea = n.Linea,
                                      Ubicacion = n.Ubicacion,

                                  };

                                 }).ToList().AsQueryable();

                if (!string.IsNullOrEmpty(pstrSortExpression))
                {
                    query = query.OrderBy(pstrSortExpression);
                }

                List<productoshortDto> objData = query.ToList();

                List<productoshortDto> queryFiltrado = new List<productoshortDto>();

                if (SoloStockMayor0)
                {
                    queryFiltrado = (from n in objData
                                     where n.stockActual > 0 || n.StockDisponible > 0
                                     select n).ToList();

                }
                else if (SoloStockDiferente0)
                {
                    queryFiltrado = (from n in objData
                                     where n.stockActual <= 0
                                     select n).ToList();
                }

                else
                {
                    queryFiltrado = objData;
                }

                pobjOperationResult.Success = 1;
                return queryFiltrado;


            }
            catch (Exception ex)
            {

                pobjOperationResult.Success = 0;
                pobjOperationResult.AdditionalInformation = "MovimientoBL. ListarBusquedaConsultaProductoStock()\nLinea:" + CodigoError + ex.StackTrace.Substring(ex.StackTrace.LastIndexOf(' '));
                pobjOperationResult.ErrorMessage = ex.Message;
                pobjOperationResult.ExceptionMessage = pobjOperationResult.ExceptionMessage != null ? ex.InnerException.Message : string.Empty;
                return null;
            }
        }

        private string Buscar(ref OperationResult pobjOperationResult, string IdProductoDetalle)
        {
            // EmpaqueUnidadMedidaFinal = n.d_Empaque == 1 && J1.v_Value2 == "1" ? J1.v_Value1 : "UNIDAD",
            // string UnidadMinima = "UNIDAD";

            try
            {
                string xx = "";

                using (SAMBHSEntitiesModelWin dbContext = new SAMBHSEntitiesModelWin())
                {
                    var Movimientos = (from a in dbContext.producto

                                       join b in dbContext.productodetalle on new { IdProducto = a.v_IdProducto, eliminado = 0 } equals new { IdProducto = b.v_IdProducto, eliminado = b.i_Eliminado.Value } into b_join

                                       from b in b_join.DefaultIfEmpty()

                                       join c in dbContext.movimientodetalle on new { IdProd = b.v_IdProductoDetalle, eliminado = 0 } equals new { IdProd = c.v_IdProductoDetalle, eliminado = c.i_Eliminado.Value } into c_join

                                       from c in c_join.DefaultIfEmpty()

                                       join J1 in dbContext.datahierarchy on new { a = a.i_IdUnidadMedida.Value, b = 17, eliminado = 0 } //UnidadMedidaProducto
                                                             equals new { a = J1.i_ItemId, b = J1.i_GroupId, eliminado = J1.i_IsDeleted.Value } into J1_join
                                       from J1 in J1_join.DefaultIfEmpty()

                                       //join J2 in dbContext.datahierarchy on new { a = a.i_IdUnidadMedida, b = 17, eliminado = 0 }  //UnidadMedidaMovimiento
                                       //                                    equals new {a= J2 }

                                       where c.v_IdProductoDetalle == IdProductoDetalle && a.i_Eliminado == 0

                                       select new
                                       {

                                           UnidadMedida = c.i_IdUnidad == a.i_IdUnidadMedida ? J1.v_Value1 : "UNIDAD",
                                           UnidadMinimaProducto = J1.v_Value1,
                                           UnidadMedidaMovimiento = c.i_IdUnidad.Value,
                                           UnidadMedidaProducto = a.i_IdUnidadMedida.Value,

                                       });

                    string UnidadMinimaProducto = Movimientos.Count() > 0 ? Movimientos.FirstOrDefault().UnidadMinimaProducto.Trim() : "";
                    int NumeroRegistros = Movimientos.Count();
                    int xxx = Movimientos.Where(x => x.UnidadMedida == UnidadMinimaProducto).Count();
                    xx = Movimientos.Where(x => x.UnidadMedida == UnidadMinimaProducto).Count() == NumeroRegistros ? UnidadMinimaProducto : "UNIDAD";

                    //bool UnidadReturn = true;
                    //foreach (var item in Movimientos)
                    //{
                    //    if (UnidadReturn)
                    //    {
                    //        if (item.UnidadMedida != UnidadMinima)
                    //        {
                    //            UnidadMinima = item.UnidadMedida;
                    //            UnidadReturn = false;
                    //        }
                    //    }
                    //}
                }
                // return UnidadMinima;
                pobjOperationResult.Success = 1;
                return xx;
            }
            catch (Exception ex)
            {
                pobjOperationResult.Success = 0;
                pobjOperationResult.AdditionalInformation = "MovimientoBL.Buscar()\nLinea:" + ex.StackTrace.Substring(ex.StackTrace.LastIndexOf(' '));
                pobjOperationResult.ErrorMessage = ex.Message;
                pobjOperationResult.ExceptionMessage = pobjOperationResult.ExceptionMessage != null ? ex.InnerException.Message : string.Empty;
                return "";


            }

        }

        public string[] DevolverClientePorNroDocumento(ref OperationResult pobjOperationResult, string NroDocumento)
        {
            try
            {
                SAMBHSEntitiesModelWin dbContext = new SAMBHSEntitiesModelWin();

                var query = (from n in dbContext.cliente
                             where n.i_Eliminado == 0 && n.v_FlagPantalla == "C" && n.v_NroDocIdentificacion == NroDocumento
                             select n
                             ).FirstOrDefault();

                pobjOperationResult.Success = 1;

                if (query != null)
                {
                    string[] Cadena = new string[4];
                    Cadena[0] = query.v_IdCliente;
                    Cadena[1] = query.v_CodCliente;
                    Cadena[2] = (query.v_PrimerNombre + " " + query.v_ApePaterno + " " + query.v_ApeMaterno + " " + query.v_RazonSocial).Trim();
                    Cadena[3] = query.i_IdListaPrecios.Value.ToString();
                    return Cadena;
                }
                else
                {
                    return null;
                }

            }
            catch (Exception ex)
            {
                pobjOperationResult.Success = 0;
                pobjOperationResult.ExceptionMessage = Utils.ExceptionFormatter(ex);
                return null;
            }
        }

        public productoshortDto DevolverArticuloPorCodInterno(string pstrCodInterno, int pintIdAlmacen)
        {
            try
            {
                using (SAMBHSEntitiesModelWin dbContext = new SAMBHSEntitiesModelWin())
                {

                    var query2 = (from n in dbContext.producto
                                  join D in dbContext.productodetalle on n.v_IdProducto equals D.v_IdProducto into D_join
                                  from D in D_join.DefaultIfEmpty()

                                  join J4 in dbContext.datahierarchy on new { a = n.i_IdUnidadMedida.Value, b = 17 }
                                                                equals new { a = J4.i_ItemId, b = J4.i_GroupId } into J4_join
                                  from J4 in J4_join.DefaultIfEmpty()

                                  where n.i_Eliminado == 0 && n.v_CodInterno == pstrCodInterno

                                  select new productoshortDto
                                  {
                                      v_IdProducto = n.v_IdProducto,
                                      v_IdProductoDetalle = D.v_IdProductoDetalle,
                                      v_Descripcion = n.v_Descripcion,
                                      v_CodInterno = n.v_CodInterno,
                                      i_EsServicio = n.i_EsServicio,
                                      i_EsLote = n.i_EsLote,
                                      i_IdTipoProducto = n.i_IdTipoProducto,
                                      i_IdUnidadMedida = n.i_IdUnidadMedida,
                                      EmpaqueUnidadMedida = J4.v_Value1,
                                      d_Empaque = n.d_Empaque,
                                      i_EsAfectoDetraccion = n.i_EsAfectoDetraccion,
                                      i_NombreEditable = n.i_NombreEditable,
                                      i_ValidarStock = n.i_ValidarStock,
                                      i_EsAfectoPercepcion = n.i_EsAfectoPercepcion,
                                      d_TasaPercepcion = n.d_TasaPercepcion

                                  }
                         ).FirstOrDefault();

                    return query2;

                }
            }
            catch (Exception)
            {

                throw;
            }
        }


        #region Procesos de Nota de Ingreso
        private void ProcesarMovimientoIngreso(ref OperationResult pobjOperationResult, string pstrMovimientoId, List<string> ClientSession)
        {
            int SecuentialId = 0;
            string newIdProductoAlmacen = string.Empty;
            int intNodeId;
            string periodo = Globals.ClientSession.i_Periodo.ToString();
            try
            {
                using (TransactionScope ts = TransactionUtils.CreateTransactionScope())
                {
                    SAMBHSEntitiesModelWin dbContext = new SAMBHSEntitiesModelWin();
                    SecuentialBL objSecuentialBL = new SecuentialBL();

                    movimiento objEntity = (from A in dbContext.movimiento
                                            where A.v_IdMovimiento == pstrMovimientoId
                                            select A).FirstOrDefault();

                    List<movimientodetalle> objEntityDetailList = (from A in dbContext.movimientodetalle
                                                                   where A.v_IdMovimiento == objEntity.v_IdMovimiento
                                                                   select A).ToList();

                    //Recorrer el detalle del movimiento
                    if (objEntityDetailList != null)
                    {
                        foreach (var objEntityDetail in objEntityDetailList)
                        {
                            // Actualizar el stock del producto en el almacén correspondiente
                            productoalmacen itemStock = new productoalmacen();

                            if (objEntityDetail.v_NroPedido != null && objEntityDetail.v_NroPedido != string.Empty && Globals.ClientSession.i_IncluirPedidoExportacionCompraVenta == 1) // Se agrego Wortec
                            {
                                itemStock = (from A in dbContext.productoalmacen
                                             where A.i_IdAlmacen == objEntity.i_IdAlmacenOrigen && A.i_Eliminado == 0
                                              && A.v_ProductoDetalleId == objEntityDetail.v_IdProductoDetalle && A.v_Periodo == periodo && A.v_NroPedido.Trim() == objEntityDetail.v_NroPedido.Trim()
                                             select A).FirstOrDefault();

                            }
                            else
                            {

                                itemStock = (from A in dbContext.productoalmacen
                                             where A.i_IdAlmacen == objEntity.i_IdAlmacenOrigen && A.i_Eliminado == 0
                                              && A.v_ProductoDetalleId == objEntityDetail.v_IdProductoDetalle && A.v_Periodo == periodo
                                             select A).FirstOrDefault();
                            }

                            // Si el producto no existe en el almacén. Crearlo y asignarle su stock actual
                            if (itemStock == null)
                            {
                                itemStock = new productoalmacen();
                                intNodeId = int.Parse(ClientSession[0]);
                                SecuentialId = objSecuentialBL.GetNextSecuentialId(intNodeId, 30);
                                newIdProductoAlmacen = Utils.GetNewId(int.Parse(ClientSession[0]), SecuentialId, "PA");
                                itemStock.v_IdProductoAlmacen = newIdProductoAlmacen;

                                itemStock.i_IdAlmacen = objEntity.i_IdAlmacenOrigen.Value;
                                itemStock.v_ProductoDetalleId = objEntityDetail.v_IdProductoDetalle;
                                itemStock.d_StockMinimo = 0;
                                itemStock.d_StockMaximo = objEntityDetail.d_CantidadEmpaque;
                                itemStock.d_StockActual = objEntity.i_EsDevolucion == 1 ? objEntityDetail.d_CantidadEmpaque * -1 : objEntityDetail.d_CantidadEmpaque;
                                itemStock.d_SeparacionTotal = 0;
                                itemStock.i_Eliminado = 0;
                                itemStock.v_Periodo = Globals.ClientSession.i_Periodo.ToString();
                                itemStock.v_NroPedido = objEntityDetail.v_NroPedido == null ? null : objEntityDetail.v_NroPedido.Trim();

                                // Auditoría
                                itemStock.i_InsertaIdUsuario = int.Parse(ClientSession[2]);
                                itemStock.t_InsertaFecha = DateTime.Now;

                                // Agregar el elemento de stock a la BD
                                dbContext.AddToproductoalmacen(itemStock);
                            }
                            else
                            {

                                itemStock.d_StockActual = objEntity.i_EsDevolucion == 0 ? itemStock.d_StockActual + objEntityDetail.d_CantidadEmpaque : itemStock.d_StockActual - objEntityDetail.d_CantidadEmpaque;

                                // Auditoría
                                itemStock.i_ActualizaIdUsuario = int.Parse(ClientSession[2]);
                                itemStock.t_ActualizaFecha = DateTime.Now;
                            }
                        }
                        // Guardar todo en la BD
                        dbContext.SaveChanges();
                        pobjOperationResult.Success = 1;
                        ts.Complete();
                        return;
                    }
                }

            }
            catch (Exception ex)
            {
                pobjOperationResult.Success = 0;
                pobjOperationResult.AdditionalInformation = "MovimientoBL.ProcesarMovimientoIngreso()";
                pobjOperationResult.ErrorMessage = ex.Message;
                pobjOperationResult.ExceptionMessage = ex.InnerException != null ? ex.InnerException.Message : string.Empty;
                Utils.ExceptionToLog(Globals.ClientSession.i_SystemUserId, pobjOperationResult);
                return;
            }
        }

        private void RevertirMovimientoIngreso(ref OperationResult pobjOperationResult, string pstrMovimientoId, List<string> ClientSession)
        {
            try
            {
                using (TransactionScope ts = TransactionUtils.CreateTransactionScope())
                {
                    SAMBHSEntitiesModelWin dbContext = new SAMBHSEntitiesModelWin();

                    movimiento objEntity = (from A in dbContext.movimiento
                                            where A.v_IdMovimiento == pstrMovimientoId
                                            select A).FirstOrDefault();

                    List<movimientodetalle> objEntityDetailList = (from A in dbContext.movimientodetalle
                                                                   where A.v_IdMovimiento == objEntity.v_IdMovimiento && A.i_Eliminado == 0
                                                                   select A).ToList();

                    //Recorrer el detalle del movimiento
                    if (objEntityDetailList != null)
                    {
                        foreach (var objEntityDetail in objEntityDetailList)
                        {
                            var periodo = Globals.ClientSession.i_Periodo.ToString();
                            productoalmacen itemStock = new productoalmacen();
                            if (objEntityDetail.v_NroPedido != null && objEntityDetail.v_NroPedido.Trim() != string.Empty && Globals.ClientSession.i_IncluirPedidoExportacionCompraVenta == 1) //Se agrego Wortec
                            {

                                if (string.IsNullOrEmpty(objEntityDetail.v_NroSerie) && string.IsNullOrEmpty(objEntityDetail.v_NroLote))
                                {

                                    itemStock = (from A in dbContext.productoalmacen
                                                 where A.i_IdAlmacen == objEntity.i_IdAlmacenOrigen && A.v_Periodo == periodo
                                                  && A.v_ProductoDetalleId == objEntityDetail.v_IdProductoDetalle && A.i_Eliminado == 0
                                                  && A.v_NroPedido.Trim() == objEntityDetail.v_NroPedido.Trim()
                                                 && A.v_NroSerie == null && A.v_NroLote == null
                                                 select A).FirstOrDefault();
                                }
                                else
                                {
                                    if (!string.IsNullOrEmpty(objEntityDetail.v_NroLote))
                                    {
                                        itemStock = (from A in dbContext.productoalmacen
                                                     where A.i_IdAlmacen == objEntity.i_IdAlmacenOrigen && A.v_Periodo == periodo
                                                      && A.v_ProductoDetalleId == objEntityDetail.v_IdProductoDetalle && A.i_Eliminado == 0
                                                      && A.v_NroPedido.Trim() == objEntityDetail.v_NroPedido.Trim()
                                                     && A.v_NroLote.Trim() == objEntityDetail.v_NroLote.Trim()
                                                     select A).FirstOrDefault();
                                    }
                                    else
                                    {
                                        itemStock = (from A in dbContext.productoalmacen
                                                     where A.i_IdAlmacen == objEntity.i_IdAlmacenOrigen && A.v_Periodo == periodo
                                                      && A.v_ProductoDetalleId == objEntityDetail.v_IdProductoDetalle && A.i_Eliminado == 0
                                                      && A.v_NroPedido.Trim() == objEntityDetail.v_NroPedido.Trim()
                                                     && A.v_NroSerie.Trim() == objEntityDetail.v_NroSerie.Trim()
                                                     select A).FirstOrDefault();

                                    }

                                }

                            }
                            else
                            {
                                // Actualizar el stock del producto en el almacén correspondiente

                                if (string.IsNullOrEmpty(objEntityDetail.v_NroLote) && string.IsNullOrEmpty(objEntityDetail.v_NroSerie))
                                {
                                    itemStock = (from A in dbContext.productoalmacen
                                                 where A.i_IdAlmacen == objEntity.i_IdAlmacenOrigen && A.v_Periodo == periodo
                                                  && A.v_ProductoDetalleId == objEntityDetail.v_IdProductoDetalle && A.i_Eliminado == 0
                                                  && (A.v_NroPedido == null || A.v_NroPedido == "")
                                                  && A.v_NroSerie == null && A.v_NroLote == null
                                                 select A).FirstOrDefault();
                                }
                                else
                                {
                                    if (!string.IsNullOrEmpty(objEntityDetail.v_NroLote))
                                    {
                                        itemStock = (from A in dbContext.productoalmacen
                                                     where A.i_IdAlmacen == objEntity.i_IdAlmacenOrigen && A.v_Periodo == periodo
                                                      && A.v_ProductoDetalleId == objEntityDetail.v_IdProductoDetalle && A.i_Eliminado == 0
                                                      && (A.v_NroPedido == null || A.v_NroPedido == "")
                                                      && A.v_NroLote.Trim() == objEntityDetail.v_NroLote.Trim()
                                                     select A).FirstOrDefault();

                                    }
                                    else
                                    {
                                        itemStock = (from A in dbContext.productoalmacen
                                                     where A.i_IdAlmacen == objEntity.i_IdAlmacenOrigen && A.v_Periodo == periodo
                                                      && A.v_ProductoDetalleId == objEntityDetail.v_IdProductoDetalle && A.i_Eliminado == 0
                                                      && (A.v_NroPedido == null || A.v_NroPedido == "")
                                                      && A.v_NroSerie.Trim() == objEntityDetail.v_NroSerie.Trim()
                                                     select A).FirstOrDefault();


                                    }
                                }
                            }


                            itemStock.d_StockActual = objEntity.i_EsDevolucion == 0 ? itemStock.d_StockActual - objEntityDetail.d_CantidadEmpaque : itemStock.d_StockActual + objEntityDetail.d_CantidadEmpaque;
                            // Auditoría
                            itemStock.i_ActualizaIdUsuario = int.Parse(ClientSession[2]);
                            itemStock.t_ActualizaFecha = DateTime.Now;
                        }
                        // Guardar todo en la BD
                        dbContext.SaveChanges();
                        pobjOperationResult.Success = 1;
                        ts.Complete();
                        return;
                    }
                }

            }
            catch (Exception ex)
            {
                pobjOperationResult.Success = 0;
                pobjOperationResult.AdditionalInformation = "MovimientoBL.RevertirMovimientoIngreso()";
                pobjOperationResult.ErrorMessage = ex.Message;
                pobjOperationResult.ExceptionMessage = ex.InnerException != null ? ex.InnerException.Message : string.Empty;
                Utils.ExceptionToLog(Globals.ClientSession.i_SystemUserId, pobjOperationResult);
                return;
            }
        }

        private void RevertirMovimientoIngresoDetalle(ref OperationResult pobjOperationResult, string v_IdMovimientoDetalle, int i_IdAlmacen, List<string> ClientSession)
        {
            try
            {
                using (TransactionScope ts = TransactionUtils.CreateTransactionScope())
                {
                    var dbContext = new SAMBHSEntitiesModelWin();

                    var objEntity = (from A in dbContext.movimientodetalle
                                     where A.v_IdMovimientoDetalle == v_IdMovimientoDetalle
                                     select A).FirstOrDefault();

                    var objCabecera = (from A in dbContext.movimiento
                                       where A.v_IdMovimiento == objEntity.v_IdMovimiento
                                       select new { A.i_EsDevolucion }).FirstOrDefault();

                    //Recorrer el detalle del movimiento
                    if (objEntity != null)
                    {
                        var periodo = Globals.ClientSession.i_Periodo.ToString();
                        // Actualizar el stock del producto en el almacén correspondiente
                        productoalmacen itemStock = new productoalmacen();

                        if (objEntity.v_NroPedido != null && objEntity.v_NroPedido != string.Empty && Globals.ClientSession.i_IncluirPedidoExportacionCompraVenta == 1)//se agrego wortec
                        {

                            if (string.IsNullOrEmpty(objEntity.v_NroSerie) && string.IsNullOrEmpty(objEntity.v_NroLote))
                            {

                                itemStock = (from A in dbContext.productoalmacen
                                             where A.i_IdAlmacen == i_IdAlmacen && A.v_Periodo == periodo && A.i_Eliminado.Value == 0
                                             && A.v_ProductoDetalleId == objEntity.v_IdProductoDetalle && A.v_NroPedido.Trim() == objEntity.v_NroPedido.Trim()
                                             && A.v_NroSerie == null && A.v_NroLote == null
                                             select A).FirstOrDefault();
                            }
                            else
                            {
                                if (!string.IsNullOrEmpty(objEntity.v_NroLote))
                                {
                                    itemStock = (from A in dbContext.productoalmacen
                                                 where A.i_IdAlmacen == i_IdAlmacen && A.v_Periodo == periodo && A.i_Eliminado.Value == 0
                                                 && A.v_ProductoDetalleId == objEntity.v_IdProductoDetalle && A.v_NroPedido.Trim() == objEntity.v_NroPedido.Trim()
                                                 && A.v_NroLote.Trim() == objEntity.v_NroLote.Trim()
                                                 select A).FirstOrDefault();
                                }
                                else
                                {
                                    itemStock = (from A in dbContext.productoalmacen
                                                 where A.i_IdAlmacen == i_IdAlmacen && A.v_Periodo == periodo && A.i_Eliminado.Value == 0
                                                 && A.v_ProductoDetalleId == objEntity.v_IdProductoDetalle && A.v_NroPedido.Trim() == objEntity.v_NroPedido.Trim()
                                                 && A.v_NroSerie.Trim() == objEntity.v_NroSerie.Trim()
                                                 select A).FirstOrDefault();
                                }

                            }

                        }
                        else
                        {

                            if (string.IsNullOrEmpty(objEntity.v_NroSerie) && string.IsNullOrEmpty(objEntity.v_NroLote))
                            {
                                itemStock = (from A in dbContext.productoalmacen
                                             where A.i_IdAlmacen == i_IdAlmacen && A.v_Periodo == periodo && A.i_Eliminado.Value == 0
                                             && A.v_ProductoDetalleId == objEntity.v_IdProductoDetalle
                                             && (A.v_NroPedido == null || A.v_NroPedido == "")
                                              && A.v_NroSerie == null && A.v_NroLote == null  // se agrego esta fila cuando se agrego el lote y la serie
                                             select A).FirstOrDefault();
                            }
                            else
                            {
                                if (!string.IsNullOrEmpty(objEntity.v_NroSerie))
                                {
                                    itemStock = (from A in dbContext.productoalmacen
                                                 where A.i_IdAlmacen == i_IdAlmacen && A.v_Periodo == periodo && A.i_Eliminado.Value == 0
                                                 && A.v_ProductoDetalleId == objEntity.v_IdProductoDetalle
                                                 && (A.v_NroPedido == null || A.v_NroPedido == "")
                                                 && A.v_NroSerie.Trim() == objEntity.v_NroSerie.Trim()
                                                 select A).FirstOrDefault();
                                }
                                else
                                {
                                    itemStock = (from A in dbContext.productoalmacen
                                                 where A.i_IdAlmacen == i_IdAlmacen && A.v_Periodo == periodo && A.i_Eliminado.Value == 0
                                                 && A.v_ProductoDetalleId == objEntity.v_IdProductoDetalle
                                                 && (A.v_NroPedido == null || A.v_NroPedido == "")
                                                 && A.v_NroLote.Trim() == objEntity.v_NroLote.Trim()
                                                 select A).FirstOrDefault();
                                }

                            }
                        }

                        itemStock.d_StockActual = objCabecera.i_EsDevolucion == 0 ? itemStock.d_StockActual - objEntity.d_CantidadEmpaque : itemStock.d_StockActual + objEntity.d_CantidadEmpaque;
                        // Auditoría
                        itemStock.i_ActualizaIdUsuario = int.Parse(ClientSession[2]);
                        itemStock.t_ActualizaFecha = DateTime.Now;

                        // Guardar todo en la BD
                        dbContext.SaveChanges();
                        pobjOperationResult.Success = 1;
                        ts.Complete();
                        return;
                    }
                }

            }
            catch (Exception ex)
            {
                pobjOperationResult.Success = 0;
                pobjOperationResult.AdditionalInformation = "MovimientoBL.RevertirMovimientoIngresoDetalle()";
                pobjOperationResult.ErrorMessage = ex.Message;
                pobjOperationResult.ExceptionMessage = ex.InnerException != null ? ex.InnerException.Message : string.Empty;
                Utils.ExceptionToLog(Globals.ClientSession.i_SystemUserId, pobjOperationResult);
                return;
            }
        }

        private void ProcesarMovimientoIngresoDetalle(ref OperationResult pobjOperationResult, int i_IdAlmacen, movimientodetalleDto movimientodetalleDto, List<string> ClientSession)
        {
            try
            {
                using (TransactionScope ts = TransactionUtils.CreateTransactionScope())
                {

                    int SecuentialId = 0;
                    string newIdProductoAlmacen = string.Empty;
                    int intNodeId;
                    SAMBHSEntitiesModelWin dbContext = new SAMBHSEntitiesModelWin();
                    SecuentialBL objSecuentialBL = new SecuentialBL();
                    var periodo = Globals.ClientSession.i_Periodo.ToString();
                    var objCabecera = (from A in dbContext.movimiento
                                       where A.v_IdMovimiento == movimientodetalleDto.v_IdMovimiento
                                       select new { A.i_EsDevolucion, A.i_IdTipoMovimiento }).FirstOrDefault();

                    productoalmacen itemStock = new productoalmacen();

                    if (movimientodetalleDto.v_NroPedido != null && movimientodetalleDto.v_NroPedido.Trim() != string.Empty && Globals.ClientSession.i_IncluirPedidoExportacionCompraVenta == 1) //Se agrego por Wortec
                    {

                        if (string.IsNullOrEmpty(movimientodetalleDto.v_NroLote) && string.IsNullOrEmpty(movimientodetalleDto.v_NroSerie))
                        {
                            /// El query inicial antes de agregar los lotes y series
                            /// 
                            //itemStock = (from A in dbContext.productoalmacen
                            //             where A.i_IdAlmacen == i_IdAlmacen && A.v_Periodo == periodo && A.i_Eliminado == 0
                            //             && A.v_ProductoDetalleId == movimientodetalleDto.v_IdProductoDetalle && A.v_NroPedido.Trim() == movimientodetalleDto.v_NroPedido.Trim()
                            //             select A).FirstOrDefault();


                            itemStock = (from A in dbContext.productoalmacen
                                         where A.i_IdAlmacen == i_IdAlmacen && A.v_Periodo == periodo && A.i_Eliminado == 0
                                         && A.v_ProductoDetalleId == movimientodetalleDto.v_IdProductoDetalle && A.v_NroPedido.Trim() == movimientodetalleDto.v_NroPedido.Trim()
                                         && A.v_NroLote == null && A.v_NroSerie == null
                                         select A).FirstOrDefault();

                        }
                        else
                        {
                            if (!string.IsNullOrEmpty(movimientodetalleDto.v_NroLote))
                            {
                                itemStock = (from A in dbContext.productoalmacen
                                             where A.i_IdAlmacen == i_IdAlmacen && A.v_Periodo == periodo && A.i_Eliminado == 0
                                             && A.v_ProductoDetalleId == movimientodetalleDto.v_IdProductoDetalle && A.v_NroPedido.Trim() == movimientodetalleDto.v_NroPedido.Trim()
                                             && A.v_NroLote.Trim() == movimientodetalleDto.v_NroLote.Trim()
                                             select A).FirstOrDefault();
                            }
                            else
                            {
                                itemStock = (from A in dbContext.productoalmacen
                                             where A.i_IdAlmacen == i_IdAlmacen && A.v_Periodo == periodo && A.i_Eliminado == 0
                                             && A.v_ProductoDetalleId == movimientodetalleDto.v_IdProductoDetalle && A.v_NroPedido.Trim() == movimientodetalleDto.v_NroPedido.Trim()
                                             && A.v_NroSerie == movimientodetalleDto.v_NroSerie.Trim()
                                             select A).FirstOrDefault();
                            }

                        }


                    }
                    else
                    {

                        // Actualizar el stock del producto en el almacén correspondiente
                        if (string.IsNullOrEmpty(movimientodetalleDto.v_NroLote) && string.IsNullOrEmpty(movimientodetalleDto.v_NroSerie))
                        {
                            /// El query inicial antes de agregar los lotes y series
                            itemStock = (from A in dbContext.productoalmacen
                                         where A.i_IdAlmacen == i_IdAlmacen && A.v_Periodo == periodo && A.i_Eliminado == 0
                                         && A.v_ProductoDetalleId == movimientodetalleDto.v_IdProductoDetalle
                                         && (A.v_NroPedido == null || A.v_NroPedido == "")
                                         && A.v_NroLote == null && A.v_NroSerie == null   //se agrego por la serie y el lote
                                         select A).FirstOrDefault();
                        }
                        else
                        {
                            if (!string.IsNullOrEmpty(movimientodetalleDto.v_NroLote))
                            {
                                itemStock = (from A in dbContext.productoalmacen
                                             where A.i_IdAlmacen == i_IdAlmacen && A.v_Periodo == periodo && A.i_Eliminado == 0
                                             && A.v_ProductoDetalleId == movimientodetalleDto.v_IdProductoDetalle
                                             && (A.v_NroPedido == null || A.v_NroPedido == "")
                                             && A.v_NroLote.Trim() == movimientodetalleDto.v_NroLote.Trim()
                                             select A).FirstOrDefault();
                            }
                            else
                            {
                                itemStock = (from A in dbContext.productoalmacen
                                             where A.i_IdAlmacen == i_IdAlmacen && A.v_Periodo == periodo && A.i_Eliminado == 0
                                             && (A.v_NroPedido == null || A.v_NroPedido == "")
                                             && A.v_ProductoDetalleId == movimientodetalleDto.v_IdProductoDetalle
                                             && A.v_NroSerie.Trim() == movimientodetalleDto.v_NroSerie.Trim()
                                             select A).FirstOrDefault();
                            }


                        }
                    }

                    if (objCabecera != null && objCabecera.i_IdTipoMovimiento.Value != 3)
                    {
                        var cantidadEmpaque = movimientodetalleDto.d_CantidadEmpaque ?? movimientodetalleDto.d_Cantidad;
                        if (itemStock != null)
                        {
                            itemStock.d_StockActual = (objCabecera.i_EsDevolucion == 0 || objCabecera.i_EsDevolucion == null) ? itemStock.d_StockActual == null ? cantidadEmpaque : itemStock.d_StockActual.Value + cantidadEmpaque : itemStock.d_StockActual - cantidadEmpaque;
                            itemStock.v_Periodo = Globals.ClientSession.i_Periodo.ToString(); ///  ¿¿¿¿ Está biennn ?
                            itemStock.i_ActualizaIdUsuario = int.Parse(ClientSession[2]);
                            itemStock.t_ActualizaFecha = DateTime.Now;
                            //itemStock.v_NroPedido = movimientodetalleDto.v_NroPedido == null ? null : movimientodetalleDto.v_NroPedido.Trim(); //Se agrego Wortec

                        }
                        else
                        {
                            itemStock = new productoalmacen();
                            intNodeId = int.Parse(ClientSession[0]);
                            SecuentialId = objSecuentialBL.GetNextSecuentialId(intNodeId, 30);
                            newIdProductoAlmacen = Utils.GetNewId(int.Parse(ClientSession[0]), SecuentialId, "PA");
                            itemStock.v_IdProductoAlmacen = newIdProductoAlmacen;
                            itemStock.v_Periodo = Globals.ClientSession.i_Periodo.ToString();
                            itemStock.i_IdAlmacen = i_IdAlmacen;
                            itemStock.v_ProductoDetalleId = movimientodetalleDto.v_IdProductoDetalle;
                            itemStock.d_StockMinimo = 0;
                            itemStock.d_StockActual = cantidadEmpaque;
                            itemStock.d_SeparacionTotal = 0;
                            itemStock.d_StockMaximo = 0;

                            itemStock.i_Eliminado = 0;
                            itemStock.v_Periodo = Globals.ClientSession.i_Periodo.ToString();
                            itemStock.v_NroPedido = movimientodetalleDto.v_NroPedido == null ? null : movimientodetalleDto.v_NroPedido.Trim(); //Se agrego Wortec


                            itemStock.v_NroSerie = movimientodetalleDto.v_NroSerie == null ? null : movimientodetalleDto.v_NroSerie.Trim(); //Datos para Trazabilidad lotes y series
                            itemStock.v_NroLote = movimientodetalleDto.v_NroLote == null ? null : movimientodetalleDto.v_NroLote.Trim();
                            if (!string.IsNullOrEmpty(itemStock.v_NroSerie) || !string.IsNullOrEmpty(itemStock.v_NroLote))
                                itemStock.t_FechaCaducidad = movimientodetalleDto.t_FechaCaducidad;


                            // Auditoría
                            itemStock.i_InsertaIdUsuario = int.Parse(ClientSession[2]);
                            itemStock.t_InsertaFecha = DateTime.Now;

                            // Agregar el elemento de stock a la BD
                            dbContext.AddToproductoalmacen(itemStock);
                        }

                        // Guardar todo en la BD
                        dbContext.SaveChanges();
                        pobjOperationResult.Success = 1;
                    }
                    ts.Complete();
                }

            }
            catch (Exception ex)
            {
                pobjOperationResult.Success = 0;
                pobjOperationResult.AdditionalInformation = "MovimientoBL.ProcesarMovimientoIngresoDetalle()";
                pobjOperationResult.ErrorMessage = ex.Message;
                pobjOperationResult.ExceptionMessage = ex.InnerException != null ? ex.InnerException.Message : string.Empty;
                Utils.ExceptionToLog(Globals.ClientSession.i_SystemUserId, pobjOperationResult);
                return;
            }
        }


        public movimiento VerificarFechaCaducidadxLote(string v_IdProductoDetalle, string v_IdMovimientoDetalle, string Lote, DateTime FechaVenc)
        {

            using (SAMBHSEntitiesModelWin dbContext = new SAMBHSEntitiesModelWin())
            {
                movimiento movFec = new movimiento();
                if (v_IdMovimientoDetalle == null)
                {
                    movFec = (from a in dbContext.movimientodetalle
                              join b in dbContext.movimiento on new { mov = a.v_IdMovimiento, eliminado = 0 } equals new { mov = b.v_IdMovimiento, eliminado = b.i_Eliminado.Value } into b_join
                              from b in b_join.DefaultIfEmpty()
                              where a.i_Eliminado == 0 && a.v_IdProductoDetalle == v_IdProductoDetalle
                              && a.v_NroLote == Lote && a.t_FechaCaducidad != FechaVenc
                              select b).FirstOrDefault();

                }
                else
                {

                    movFec = (from a in dbContext.movimientodetalle
                              join b in dbContext.movimiento on new { mov = a.v_IdMovimiento, eliminado = 0 } equals new { mov = b.v_IdMovimiento, eliminado = b.i_Eliminado.Value } into b_join
                              from b in b_join.DefaultIfEmpty()
                              where a.i_Eliminado == 0 && a.v_IdProductoDetalle == v_IdProductoDetalle && a.v_IdMovimientoDetalle != v_IdMovimientoDetalle
                              && a.v_NroLote == Lote && a.t_FechaCaducidad != FechaVenc
                              select b).FirstOrDefault();
                }
                return movFec;


            }

        }




        #endregion

        #region NotaSalida
        public void ProcesarMovimientoSalida(ref OperationResult pobjOperationResult, string pstrMovimientoId, List<string> ClientSession)
        {
            //int SecuentialId = 0;
            string newIdProductoAlmacen = string.Empty;
            try
            {
                using (TransactionScope ts = TransactionUtils.CreateTransactionScope())
                {
                    SAMBHSEntitiesModelWin dbContext = new SAMBHSEntitiesModelWin();
                    SecuentialBL objSecuentialBL = new SecuentialBL();

                    movimiento objEntity = (from A in dbContext.movimiento
                                            where A.v_IdMovimiento == pstrMovimientoId
                                            select A).FirstOrDefault();

                    List<movimientodetalle> objEntityDetailList = (from A in dbContext.movimientodetalle
                                                                   where A.v_IdMovimiento == objEntity.v_IdMovimiento
                                                                   select A).ToList();

                    //Recorrer el detalle del movimiento
                    if (objEntityDetailList != null)
                    {
                        foreach (var objEntityDetail in objEntityDetailList)
                        {
                            var periodo = Globals.ClientSession.i_Periodo.ToString();
                            // Actualizar el stock del producto en el almacén correspondiente
                            productoalmacen itemStock = new productoalmacen();
                            if (objEntityDetail.v_NroPedido != null && objEntityDetail.v_NroPedido.Trim() != string.Empty && Globals.ClientSession.i_IncluirPedidoExportacionCompraVenta == 1) //Se agrego wortec
                            {
                                if (string.IsNullOrEmpty(objEntityDetail.v_NroLote) && string.IsNullOrEmpty(objEntityDetail.v_NroSerie))
                                {
                                    itemStock = (from A in dbContext.productoalmacen
                                                 where A.i_IdAlmacen == objEntity.i_IdAlmacenOrigen && A.v_Periodo == periodo && A.i_Eliminado == 0
                                                  && A.v_ProductoDetalleId == objEntityDetail.v_IdProductoDetalle && A.v_NroPedido.Trim() == objEntityDetail.v_NroPedido.Trim()
                                                  && A.v_NroLote == null && A.v_NroSerie == null
                                                 select A).FirstOrDefault();
                                }
                                else
                                {
                                    if (!string.IsNullOrEmpty(objEntityDetail.v_NroSerie))
                                    {
                                        itemStock = (from A in dbContext.productoalmacen
                                                     where A.i_IdAlmacen == objEntity.i_IdAlmacenOrigen && A.v_Periodo == periodo && A.i_Eliminado == 0
                                                      && A.v_ProductoDetalleId == objEntityDetail.v_IdProductoDetalle && A.v_NroPedido.Trim() == objEntityDetail.v_NroPedido.Trim()
                                                      && A.v_NroSerie.Trim() == objEntityDetail.v_NroSerie.Trim()
                                                     select A).FirstOrDefault();
                                    }
                                    else
                                    {
                                        itemStock = (from A in dbContext.productoalmacen
                                                     where A.i_IdAlmacen == objEntity.i_IdAlmacenOrigen && A.v_Periodo == periodo && A.i_Eliminado == 0
                                                      && A.v_ProductoDetalleId == objEntityDetail.v_IdProductoDetalle && A.v_NroPedido.Trim() == objEntityDetail.v_NroPedido.Trim()
                                                      && A.v_NroLote.Trim() == objEntityDetail.v_NroLote.Trim()
                                                     select A).FirstOrDefault();
                                    }
                                }

                            }
                            else
                            {


                                if (string.IsNullOrEmpty(objEntityDetail.v_NroLote) && string.IsNullOrEmpty(objEntityDetail.v_NroSerie))
                                {
                                    itemStock = (from A in dbContext.productoalmacen
                                                 where A.i_IdAlmacen == objEntity.i_IdAlmacenOrigen && A.v_Periodo == periodo && A.i_Eliminado == 0
                                                  && A.v_ProductoDetalleId == objEntityDetail.v_IdProductoDetalle
                                                  && (A.v_NroPedido == null || A.v_NroPedido == "")
                                                  && A.v_NroLote == null && A.v_NroSerie == null
                                                 select A).FirstOrDefault();
                                }

                                else
                                {
                                    if (!string.IsNullOrEmpty(objEntityDetail.v_NroLote))
                                    {
                                        itemStock = (from A in dbContext.productoalmacen
                                                     where A.i_IdAlmacen == objEntity.i_IdAlmacenOrigen && A.v_Periodo == periodo && A.i_Eliminado == 0
                                                      && A.v_ProductoDetalleId == objEntityDetail.v_IdProductoDetalle
                                                      && (A.v_NroPedido == null || A.v_NroPedido == "")
                                                      && A.v_NroLote.Trim() == objEntityDetail.v_NroLote.Trim()
                                                     select A).FirstOrDefault();
                                    }
                                    else
                                    {
                                        itemStock = (from A in dbContext.productoalmacen
                                                     where A.i_IdAlmacen == objEntity.i_IdAlmacenOrigen && A.v_Periodo == periodo && A.i_Eliminado == 0
                                                      && A.v_ProductoDetalleId == objEntityDetail.v_IdProductoDetalle
                                                      && (A.v_NroPedido == null || A.v_NroPedido == "")
                                                      && A.v_NroSerie.Trim() == objEntityDetail.v_NroSerie.Trim()
                                                     select A).FirstOrDefault();
                                    }

                                }
                            }

                            if (itemStock != null)
                            {
                                itemStock.d_StockActual = objEntity.i_EsDevolucion == 0 ? itemStock.d_StockActual - objEntityDetail.d_CantidadEmpaque : itemStock.d_StockActual + objEntityDetail.d_CantidadEmpaque;
                                // Auditoría
                                itemStock.i_ActualizaIdUsuario = int.Parse(ClientSession[2]);
                                itemStock.t_ActualizaFecha = DateTime.Now;
                                // itemStock.v_NroPedido = objEntityDetail.v_NroPedido == null ? null : objEntityDetail.v_NroPedido.Trim(); //Se agrego wortec
                            }
                            else
                            {
                                // Agregado el 09/10/2015 eqc.
                                itemStock = new productoalmacen();
                                int intNodeId = int.Parse(ClientSession[0]);
                                int SecuentialId = objSecuentialBL.GetNextSecuentialId(intNodeId, 30);
                                newIdProductoAlmacen = Utils.GetNewId(int.Parse(ClientSession[0]), SecuentialId, "PA");
                                itemStock.v_IdProductoAlmacen = newIdProductoAlmacen;
                                itemStock.i_IdAlmacen = objEntity.i_IdAlmacenOrigen.Value;
                                itemStock.v_ProductoDetalleId = objEntityDetail.v_IdProductoDetalle;
                                itemStock.d_StockMinimo = 0;
                                itemStock.d_StockActual = objEntityDetail.d_CantidadEmpaque * -1;
                                itemStock.i_Eliminado = 0;
                                itemStock.v_Periodo = Globals.ClientSession.i_Periodo.ToString();
                                itemStock.v_NroPedido = objEntityDetail.v_NroPedido == null ? null : objEntityDetail.v_NroPedido.Trim(); //Se agrego wortec
                                itemStock.v_NroLote = string.IsNullOrEmpty(objEntityDetail.v_NroLote) ? null : objEntityDetail.v_NroLote;
                                itemStock.v_NroSerie = string.IsNullOrEmpty(objEntityDetail.v_NroSerie) ? null : objEntityDetail.v_NroSerie;
                               
                                if (!string.IsNullOrEmpty(itemStock.v_NroSerie) || !string.IsNullOrEmpty(itemStock.v_NroLote))
                                    itemStock.t_FechaCaducidad = objEntityDetail.t_FechaCaducidad;
                                // Auditoría
                                itemStock.i_InsertaIdUsuario = int.Parse(ClientSession[2]);
                                itemStock.t_InsertaFecha = DateTime.Now;
                                // Agregar el elemento de stock a la BD
                                dbContext.AddToproductoalmacen(itemStock);
                            }
                        }

                        // Guardar todo en la BD
                        dbContext.SaveChanges();
                        pobjOperationResult.Success = 1;
                        ts.Complete();
                        return;
                    }
                    else
                    {
                        pobjOperationResult.Success = 0;
                        pobjOperationResult.AdditionalInformation = "No se encontró el Movimiento";
                    }
                }
            }
            catch (Exception ex)
            {
                pobjOperationResult.Success = 0;
                pobjOperationResult.AdditionalInformation = "MovimientoBL.ProcesarMovimientoSalida()";
                pobjOperationResult.ErrorMessage = ex.Message;
                pobjOperationResult.ExceptionMessage = ex.InnerException != null ? ex.InnerException.Message : string.Empty;
                Utils.ExceptionToLog(Globals.ClientSession.i_SystemUserId, pobjOperationResult);
                return;
            }
        }

        public void RevertirMovimientoSalida(ref OperationResult pobjOperationResult, string pstrMovimientoId, List<string> ClientSession)
        {
            try
            {
                using (TransactionScope ts = TransactionUtils.CreateTransactionScope())
                {
                    SAMBHSEntitiesModelWin dbContext = new SAMBHSEntitiesModelWin();

                    movimiento objEntity = (from A in dbContext.movimiento
                                            where A.v_IdMovimiento == pstrMovimientoId
                                            select A).FirstOrDefault();

                    List<movimientodetalle> objEntityDetailList = (from A in dbContext.movimientodetalle
                                                                   where A.v_IdMovimiento == objEntity.v_IdMovimiento
                                                                   select A).ToList();

                    //Recorrer el detalle del movimiento
                    if (objEntityDetailList != null)
                    {
                        foreach (var objEntityDetail in objEntityDetailList)
                        {
                            var periodo = Globals.ClientSession.i_Periodo.ToString();
                            // Actualizar el stock del producto en el almacén correspondiente
                            productoalmacen itemStock = new productoalmacen();

                            if (objEntityDetail.v_NroPedido != null && objEntityDetail.v_NroPedido.Trim() != string.Empty && Globals.ClientSession.i_IncluirPedidoExportacionCompraVenta == 1)// agrego Wortec
                            {

                                if (string.IsNullOrEmpty(objEntityDetail.v_NroSerie) && string.IsNullOrEmpty(objEntityDetail.v_NroLote))
                                {

                                    itemStock = (from A in dbContext.productoalmacen
                                                 where A.i_IdAlmacen == objEntity.i_IdAlmacenOrigen && A.v_Periodo == periodo && A.i_Eliminado == 0
                                                  && A.v_ProductoDetalleId == objEntityDetail.v_IdProductoDetalle && A.v_NroPedido.Trim() == objEntityDetail.v_NroPedido.Trim()
                                                  && A.v_NroSerie == null && A.v_NroLote == null
                                                 select A).FirstOrDefault();
                                }
                                else
                                {
                                    if (!string.IsNullOrEmpty(objEntityDetail.v_NroSerie))
                                    {
                                        itemStock = (from A in dbContext.productoalmacen
                                                     where A.i_IdAlmacen == objEntity.i_IdAlmacenOrigen && A.v_Periodo == periodo && A.i_Eliminado == 0
                                                      && A.v_ProductoDetalleId == objEntityDetail.v_IdProductoDetalle && A.v_NroPedido.Trim() == objEntityDetail.v_NroPedido.Trim()
                                                      && A.v_NroSerie.Trim() == objEntityDetail.v_NroSerie.Trim()
                                                     select A).FirstOrDefault();
                                    }
                                    else
                                    {
                                        itemStock = (from A in dbContext.productoalmacen
                                                     where A.i_IdAlmacen == objEntity.i_IdAlmacenOrigen && A.v_Periodo == periodo && A.i_Eliminado == 0
                                                      && A.v_ProductoDetalleId == objEntityDetail.v_IdProductoDetalle && A.v_NroPedido.Trim() == objEntityDetail.v_NroPedido.Trim()
                                                      && A.v_NroLote.Trim() == objEntityDetail.v_NroLote.Trim()
                                                     select A).FirstOrDefault();

                                    }

                                }

                            }

                            else
                            {
                                if (string.IsNullOrEmpty(objEntityDetail.v_NroLote) && string.IsNullOrEmpty(objEntityDetail.v_NroSerie))
                                {
                                    itemStock = (from A in dbContext.productoalmacen
                                                 where A.i_IdAlmacen == objEntity.i_IdAlmacenOrigen && A.v_Periodo == periodo && A.i_Eliminado == 0
                                                  && A.v_ProductoDetalleId == objEntityDetail.v_IdProductoDetalle
                                                  && (A.v_NroPedido == null || A.v_NroPedido == "")
                                                  && A.v_NroLote == null && A.v_NroSerie == null
                                                 select A).FirstOrDefault();
                                }
                                else
                                {
                                    if (!string.IsNullOrEmpty(objEntityDetail.v_NroSerie))
                                    {
                                        itemStock = (from A in dbContext.productoalmacen
                                                     where A.i_IdAlmacen == objEntity.i_IdAlmacenOrigen && A.v_Periodo == periodo && A.i_Eliminado == 0
                                                      && A.v_ProductoDetalleId == objEntityDetail.v_IdProductoDetalle
                                                      && (A.v_NroPedido == null || A.v_NroPedido == "")
                                                      && A.v_NroSerie.Trim() == objEntityDetail.v_NroSerie.Trim()
                                                     select A).FirstOrDefault();
                                    }
                                    else
                                    {
                                        itemStock = (from A in dbContext.productoalmacen
                                                     where A.i_IdAlmacen == objEntity.i_IdAlmacenOrigen && A.v_Periodo == periodo && A.i_Eliminado == 0
                                                      && A.v_ProductoDetalleId == objEntityDetail.v_IdProductoDetalle
                                                      && (A.v_NroPedido == null || A.v_NroPedido == "")
                                                      && A.v_NroLote.Trim() == objEntityDetail.v_NroLote.Trim()
                                                     select A).FirstOrDefault();
                                    }

                                }
                            }

                            itemStock.d_StockActual = objEntity.i_EsDevolucion == 0 ? itemStock.d_StockActual + objEntityDetail.d_CantidadEmpaque : itemStock.d_StockActual - objEntityDetail.d_CantidadEmpaque;
                            // Auditoría
                            itemStock.i_ActualizaIdUsuario = int.Parse(ClientSession[2]);
                            itemStock.t_ActualizaFecha = DateTime.Now;
                        }
                        // Guardar todo en la BD
                        dbContext.SaveChanges();
                        pobjOperationResult.Success = 1;
                        ts.Complete();
                        return;
                    }
                }

            }
            catch (Exception ex)
            {
                pobjOperationResult.Success = 0;
                pobjOperationResult.AdditionalInformation = "MovimientoBL.RevertirMovimientoSalida()";
                pobjOperationResult.ErrorMessage = ex.Message;
                pobjOperationResult.ExceptionMessage = ex.InnerException != null ? ex.InnerException.Message : string.Empty;
                Utils.ExceptionToLog(Globals.ClientSession.i_SystemUserId, pobjOperationResult);
                return;
            }
        }

        private void RevertirMovimientoSalidaDetalle(ref OperationResult pobjOperationResult, string v_IdMovimientoDetalle, int i_IdAlmacen, List<string> ClientSession)
        {
            try
            {
                using (TransactionScope ts = TransactionUtils.CreateTransactionScope())
                {
                    SAMBHSEntitiesModelWin dbContext = new SAMBHSEntitiesModelWin();



                    movimientodetalle objEntity = (from A in dbContext.movimientodetalle
                                                   where A.v_IdMovimientoDetalle == v_IdMovimientoDetalle
                                                   select A).FirstOrDefault();

                    var objCabecera = (from A in dbContext.movimiento
                                       where A.v_IdMovimiento == objEntity.v_IdMovimiento
                                       select new { A.i_EsDevolucion }).FirstOrDefault();



                    //Recorrer el detalle del movimiento
                    if (objEntity != null)
                    {
                        var periodo = Globals.ClientSession.i_Periodo.ToString();
                        // Actualizar el stock del producto en el almacén correspondiente
                        productoalmacen itemStock = new productoalmacen();

                        if (objEntity.v_NroPedido != null && objEntity.v_NroPedido != string.Empty && Globals.ClientSession.i_IncluirPedidoExportacionCompraVenta == 1) //Se agrego wortec
                        {
                            if (string.IsNullOrEmpty(objEntity.v_NroSerie) && string.IsNullOrEmpty(objEntity.v_NroLote))
                            {
                                itemStock = (from A in dbContext.productoalmacen
                                             where A.i_IdAlmacen == i_IdAlmacen && A.v_Periodo == periodo && A.i_Eliminado == 0
                                             && A.v_ProductoDetalleId == objEntity.v_IdProductoDetalle
                                             && A.v_NroPedido.Trim() == objEntity.v_NroPedido.Trim()
                                             && A.v_NroLote == null && A.v_NroSerie == null
                                             select A).FirstOrDefault();
                            }
                            else
                            {
                                if (!string.IsNullOrEmpty(objEntity.v_NroSerie))
                                {
                                    itemStock = (from A in dbContext.productoalmacen
                                                 where A.i_IdAlmacen == i_IdAlmacen && A.v_Periodo == periodo && A.i_Eliminado == 0
                                                 && A.v_ProductoDetalleId == objEntity.v_IdProductoDetalle
                                                 && A.v_NroPedido.Trim() == objEntity.v_NroPedido.Trim()
                                                 && A.v_NroSerie.Trim() == objEntity.v_NroSerie.Trim()
                                                 select A).FirstOrDefault();
                                }
                                else
                                {
                                    itemStock = (from A in dbContext.productoalmacen
                                                 where A.i_IdAlmacen == i_IdAlmacen && A.v_Periodo == periodo && A.i_Eliminado == 0
                                                 && A.v_ProductoDetalleId == objEntity.v_IdProductoDetalle && A.v_NroPedido.Trim() == objEntity.v_NroPedido.Trim()
                                                 && A.v_NroLote.Trim() == objEntity.v_NroLote.Trim()
                                                 select A).FirstOrDefault();
                                }
                            }

                        }
                        else
                        {
                            if (string.IsNullOrEmpty(objEntity.v_NroSerie) && string.IsNullOrEmpty(objEntity.v_NroLote))
                            {

                                itemStock = (from A in dbContext.productoalmacen
                                             where A.i_IdAlmacen == i_IdAlmacen && A.v_Periodo == periodo && A.i_Eliminado == 0
                                             && A.v_ProductoDetalleId == objEntity.v_IdProductoDetalle
                                             && (A.v_NroPedido == null || A.v_NroPedido == "")
                                             && A.v_NroSerie == null && A.v_NroLote == null
                                             select A).FirstOrDefault();
                            }
                            else
                            {
                                if (!string.IsNullOrEmpty(objEntity.v_NroSerie))
                                {
                                    itemStock = (from A in dbContext.productoalmacen
                                                 where A.i_IdAlmacen == i_IdAlmacen && A.v_Periodo == periodo && A.i_Eliminado == 0
                                                 && A.v_ProductoDetalleId == objEntity.v_IdProductoDetalle
                                                 && (A.v_NroPedido == null || A.v_NroPedido == "")
                                                 && A.v_NroSerie.Trim() == objEntity.v_NroSerie.Trim()
                                                 select A).FirstOrDefault();
                                }
                                else
                                {
                                    itemStock = (from A in dbContext.productoalmacen
                                                 where A.i_IdAlmacen == i_IdAlmacen && A.v_Periodo == periodo && A.i_Eliminado == 0
                                                 && A.v_ProductoDetalleId == objEntity.v_IdProductoDetalle
                                                 && (A.v_NroPedido == null || A.v_NroPedido == "")
                                                 && A.v_NroLote.Trim() == objEntity.v_NroLote.Trim()
                                                 select A).FirstOrDefault();
                                }

                            }
                        }

                        // itemStock.d_StockActual = itemStock.d_StockActual + objEntity.d_Cantidad;
                        itemStock.d_StockActual = objCabecera.i_EsDevolucion == 0 ? itemStock.d_StockActual + objEntity.d_CantidadEmpaque : itemStock.d_StockActual - objEntity.d_CantidadEmpaque;
                        // Auditoría
                        itemStock.i_ActualizaIdUsuario = int.Parse(ClientSession[2]);
                        itemStock.t_ActualizaFecha = DateTime.Now;

                        // Guardar todo en la BD
                        dbContext.SaveChanges();
                        pobjOperationResult.Success = 1;
                        ts.Complete();
                        return;
                    }
                }

            }
            catch (Exception ex)
            {
                pobjOperationResult.Success = 0;
                pobjOperationResult.AdditionalInformation = "MovimientoBL.RevertirMovimientoSalidaDetalle()";
                pobjOperationResult.ErrorMessage = ex.Message;
                pobjOperationResult.ExceptionMessage = ex.InnerException != null ? ex.InnerException.Message : string.Empty;
                Utils.ExceptionToLog(Globals.ClientSession.i_SystemUserId, pobjOperationResult);
                return;
            }
        }

        private void ProcesarMovimientoSalidaDetalle(ref OperationResult pobjOperationResult, int i_IdAlmacen, movimientodetalleDto movimientodetalleDto, List<string> ClientSession)
        {
            try
            {
                using (TransactionScope ts = TransactionUtils.CreateTransactionScope())
                {
                    int SecuentialId = 0;
                    string newIdProductoAlmacen = string.Empty;
                    int intNodeId;
                    SAMBHSEntitiesModelWin dbContext = new SAMBHSEntitiesModelWin();
                    SecuentialBL objSecuentialBL = new SecuentialBL();
                    var periodo = Globals.ClientSession.i_Periodo.ToString();
                    var objCabecera = (from A in dbContext.movimiento
                                       where A.v_IdMovimiento == movimientodetalleDto.v_IdMovimiento
                                       select new { A.i_EsDevolucion, A.i_IdTipoMovimiento }).FirstOrDefault();



                    movimientodetalle objEntity = (from A in dbContext.movimientodetalle
                                                   where A.v_IdMovimientoDetalle == movimientodetalleDto.v_IdMovimientoDetalle
                                                   select A).FirstOrDefault();
                    productoalmacen itemStock = new productoalmacen();

                    if (movimientodetalleDto.v_NroPedido != null && movimientodetalleDto.v_NroPedido != string.Empty && Globals.ClientSession.i_IncluirPedidoExportacionCompraVenta == 1) //Se agregó Wortec
                    {


                        if (string.IsNullOrEmpty(movimientodetalleDto.v_NroLote) && string.IsNullOrEmpty(movimientodetalleDto.v_NroSerie))
                        {
                            itemStock = (from A in dbContext.productoalmacen
                                         where A.i_IdAlmacen == i_IdAlmacen && A.v_Periodo == periodo
                                         && A.v_ProductoDetalleId == movimientodetalleDto.v_IdProductoDetalle && A.i_Eliminado.Value == 0 && A.v_NroPedido.Trim() == movimientodetalleDto.v_NroPedido.Trim()
                                         && A.v_NroLote == null && A.v_NroSerie == null
                                         select A).FirstOrDefault();
                        }
                        else
                        {
                            if (!string.IsNullOrEmpty(movimientodetalleDto.v_NroLote))
                            {
                                itemStock = (from A in dbContext.productoalmacen
                                             where A.i_IdAlmacen == i_IdAlmacen && A.v_Periodo == periodo
                                             && A.v_ProductoDetalleId == movimientodetalleDto.v_IdProductoDetalle && A.i_Eliminado.Value == 0 && A.v_NroPedido.Trim() == movimientodetalleDto.v_NroPedido.Trim()
                                             && A.v_NroLote.Trim() == movimientodetalleDto.v_NroLote.Trim()
                                             select A).FirstOrDefault();
                            }
                            else
                            {
                                itemStock = (from A in dbContext.productoalmacen
                                             where A.i_IdAlmacen == i_IdAlmacen && A.v_Periodo == periodo
                                             && A.v_ProductoDetalleId == movimientodetalleDto.v_IdProductoDetalle && A.i_Eliminado.Value == 0 && A.v_NroPedido.Trim() == movimientodetalleDto.v_NroPedido.Trim()
                                             && A.v_NroSerie.Trim() == movimientodetalleDto.v_NroSerie.Trim()
                                             select A).FirstOrDefault();
                            }

                        }
                    }
                    else
                    {
                        if (string.IsNullOrEmpty(movimientodetalleDto.v_NroLote) && string.IsNullOrEmpty(movimientodetalleDto.v_NroSerie))
                        {

                            itemStock = (from A in dbContext.productoalmacen
                                         where A.i_IdAlmacen == i_IdAlmacen && A.v_Periodo == periodo
                                         && A.v_ProductoDetalleId == movimientodetalleDto.v_IdProductoDetalle && A.i_Eliminado.Value == 0
                                         && (A.v_NroPedido == null || A.v_NroPedido == "")
                                         && A.v_NroLote == null && A.v_NroSerie == null
                                         select A).FirstOrDefault();
                        }
                        else
                        {
                            if (string.IsNullOrEmpty(movimientodetalleDto.v_NroLote))
                            {
                                itemStock = (from A in dbContext.productoalmacen
                                             where A.i_IdAlmacen == i_IdAlmacen && A.v_Periodo == periodo
                                             && A.v_ProductoDetalleId == movimientodetalleDto.v_IdProductoDetalle && A.i_Eliminado.Value == 0
                                              && (A.v_NroPedido == null || A.v_NroPedido == "")
                                             && A.v_NroLote.Trim() == movimientodetalleDto.v_NroLote.Trim()
                                             select A).FirstOrDefault();
                            }
                            else
                            {
                                itemStock = (from A in dbContext.productoalmacen
                                             where A.i_IdAlmacen == i_IdAlmacen && A.v_Periodo == periodo
                                             && A.v_ProductoDetalleId == movimientodetalleDto.v_IdProductoDetalle && A.i_Eliminado.Value == 0
                                              && (A.v_NroPedido == null || A.v_NroPedido == "")
                                             && A.v_NroSerie.Trim() == movimientodetalleDto.v_NroSerie.Trim()
                                             select A).FirstOrDefault();
                            }

                        }
                    }

                    if (objCabecera != null && objCabecera.i_IdTipoMovimiento.Value != 3)
                    {
                        var cantidadEmpaque = movimientodetalleDto.d_CantidadEmpaque ?? movimientodetalleDto.d_Cantidad;
                        if (itemStock != null)
                        {
                            itemStock.d_StockActual = (objCabecera.i_EsDevolucion == 0 || objCabecera.i_EsDevolucion == null) ? itemStock.d_StockActual - cantidadEmpaque : itemStock.d_StockActual + cantidadEmpaque;
                            itemStock.v_Periodo = Globals.ClientSession.i_Periodo.ToString();
                            itemStock.i_ActualizaIdUsuario = int.Parse(ClientSession[2]);
                            itemStock.t_ActualizaFecha = DateTime.Now;

                        }
                        else
                        {
                            itemStock = new productoalmacen();
                            intNodeId = int.Parse(ClientSession[0]);
                            SecuentialId = objSecuentialBL.GetNextSecuentialId(intNodeId, 30);
                            newIdProductoAlmacen = Utils.GetNewId(int.Parse(ClientSession[0]), SecuentialId, "PA");
                            itemStock.v_IdProductoAlmacen = newIdProductoAlmacen;
                            itemStock.v_Periodo = Globals.ClientSession.i_Periodo.ToString();
                            itemStock.i_IdAlmacen = i_IdAlmacen;
                            itemStock.v_ProductoDetalleId = movimientodetalleDto.v_IdProductoDetalle;
                            itemStock.d_StockMinimo = 0;
                            itemStock.d_StockActual = cantidadEmpaque * -1;
                            itemStock.i_Eliminado = 0;
                            itemStock.v_Periodo = Globals.ClientSession.i_Periodo.ToString();
                            itemStock.v_NroPedido = movimientodetalleDto.v_NroPedido == null ? null : movimientodetalleDto.v_NroPedido.Trim();

                            // Auditoría
                            itemStock.i_InsertaIdUsuario = int.Parse(ClientSession[2]);
                            itemStock.t_InsertaFecha = DateTime.Now;

                            // Agregar el elemento de stock a la BD
                            dbContext.AddToproductoalmacen(itemStock);
                        }

                        pobjOperationResult.Success = 1;
                        // Guardar todo en la BD
                        dbContext.SaveChanges();
                    }
                    ts.Complete();
                }

            }
            catch (Exception ex)
            {
                pobjOperationResult.Success = 0;
                pobjOperationResult.AdditionalInformation = "MovimientoBL.ProcesarMovimientoSalidaDetalle()";
                pobjOperationResult.ErrorMessage = ex.Message;
                pobjOperationResult.ExceptionMessage = ex.InnerException != null ? ex.InnerException.Message : string.Empty;
                Utils.ExceptionToLog(Globals.ClientSession.i_SystemUserId, pobjOperationResult);
                return;
            }
        }
        #endregion

        public string DevolverTipoCambioPorFecha(ref OperationResult pobjOperationResult, DateTime Fecha)
        {
            try
            {

                var query = new TipoCambioBL().DevolverTipoCambioPorFechaVenta(ref pobjOperationResult, Fecha);
                if (pobjOperationResult.Success == 0) return "0";
                return query;
            }
            catch (Exception ex)
            {
                pobjOperationResult.Success = 0;
                pobjOperationResult.AdditionalInformation = "MovimientoBL.DevolverTipoCambioPorFecha()";
                pobjOperationResult.ErrorMessage = ex.Message;
                pobjOperationResult.ExceptionMessage = ex.InnerException != null ? ex.InnerException.Message : string.Empty;
                Utils.ExceptionToLog(Globals.ClientSession.i_SystemUserId, pobjOperationResult);
                return null;
            }
        }

        /// <summary>
        /// Obtiene la guia de remision convertida en detalle de nota de ingreso para ser importada por la interfaz de nota d ingreso.
        /// </summary>
        /// <param name="pobjOperationResult"></param>
        /// <param name="pstrSerie">Serie de la guia de remision</param>
        /// <param name="pstrCorrelativo">Correlativo de la guia de remision</param>
        /// <returns></returns>
        public List<GridmovimientodetalleDto> ObtenerGuiaRemision(ref OperationResult pobjOperationResult, string pstrSerie,
            string pstrCorrelativo)
        {
            try
            {
                using (var dbContext = new SAMBHSEntitiesModelWin())
                {
                    #region Revisar si Existe
                    var guiaRemisionExiste =
                                    dbContext.guiaremision.Any(
                                        p =>
                                            p.v_SerieGuiaRemision == pstrSerie && p.v_NumeroGuiaRemision == pstrCorrelativo &&
                                            p.i_Eliminado == 0);
                    #endregion

                    if (guiaRemisionExiste)
                    {
                        #region Obtiene la guia de remision y revisa si ya fue usada
                        var guiaRemision = dbContext.guiaremision.FirstOrDefault(
                                            p =>
                                                p.v_SerieGuiaRemision == pstrSerie && p.v_NumeroGuiaRemision == pstrCorrelativo &&
                                                p.i_Eliminado == 0);

                        if (guiaRemision.i_UsadoEnIngresoAlmacen == 1)
                            throw new ArgumentNullException("La Guía de Remisión Seleccionada Ya fue Usada!.");
                        #endregion

                        int IdTipoDocumento = guiaRemision.i_IdTipoDocumento.Value;

                        #region Consulta
                        var consulta = (from n in dbContext.guiaremisiondetalle

                                        join J1 in dbContext.productodetalle on n.v_IdProductoDetalle equals J1.v_IdProductoDetalle into J1_join
                                        from J1 in J1_join.DefaultIfEmpty()

                                        where n.i_Eliminado == 0 && n.guiaremision.v_IdGuiaRemision == guiaRemision.v_IdGuiaRemision

                                        select new GridmovimientodetalleDto
                                        {
                                            v_IdProductoDetalle = n.v_IdProductoDetalle,
                                            v_NroGuiaRemision = pstrSerie + "-" + pstrCorrelativo,
                                            d_Cantidad = n.d_Cantidad,
                                            d_CantidadEmpaque = n.d_CantidadEmpaque,
                                            i_IdUnidad = n.i_IdUnidadMedida,
                                            d_Precio = n.d_Precio,
                                            d_Total = n.d_Total,
                                            v_CodigoInterno = J1.producto.v_CodInterno,
                                            v_NombreProducto = J1.producto.v_Descripcion,
                                            Empaque = J1.producto.d_Empaque,
                                            i_IdUnidadMedidaProducto = J1.producto.i_IdUnidadMedida,
                                            i_IdTipoDocumento = -1
                                        }).ToList();
                        #endregion

                        pobjOperationResult.Success = 1;
                        return consulta;
                    }


                    throw new ArgumentNullException("La Guía de Remisión Seleccionada no Existe!.");
                }
            }
            catch (Exception ex)
            {
                pobjOperationResult.Success = 0;
                pobjOperationResult.AdditionalInformation = "MovimientoBL.ObtenerGuiaRemision()";
                pobjOperationResult.ErrorMessage = ex.Message;
                pobjOperationResult.ExceptionMessage = ex.InnerException != null ? ex.InnerException.Message : string.Empty;
                Utils.ExceptionToLog(Globals.ClientSession.i_SystemUserId, pobjOperationResult);
                return null;
            }
        }



        public guiaremisionDto ValidarGuiaRemision(ref OperationResult objOperationResult, string pstrSerie, string pstrCorrelativo, int Almacen)
        {

            try
            {
                objOperationResult.Success = 1;
                using (var dbContext = new SAMBHSEntitiesModelWin())
                {
                    var guiaRemisionExiste = (from p in dbContext.guiaremision
                                              join a in dbContext.almacen on new { almacen = p.i_IdAlmacenDestino.Value, eliminado = 0 } equals new { almacen = a.i_IdAlmacen, eliminado = a.i_Eliminado.Value }
                                              where p.v_SerieGuiaRemision == pstrSerie && p.v_NumeroGuiaRemision == pstrCorrelativo &&
                                             p.i_Eliminado == 0 && (p.i_IdAlmacenDestino == Almacen || Almacen == -1)

                                              select new guiaremisionDto
                                              {
                                                  AgenciaTransportes = a.v_Nombre,
                                                  v_Correlativo = p.v_SerieGuiaRemision + " " + p.v_NumeroGuiaRemision,

                                              }).FirstOrDefault();

                    return guiaRemisionExiste;
                }
            }
            catch (Exception ex)
            {
                objOperationResult.Success = 0;
                return null;
            }
        }
        public void ActualizarGuiaRemisionDespachada(ref OperationResult objOperationResult, string pstrSerie, string pstrCorrelativo, int TipoEstado = 2, int UsadoIngresoAlmacen = 1)
        {
            try
            {
                using (var dbContext = new SAMBHSEntitiesModelWin())
                {
                    var guiaRemision = dbContext.guiaremision.FirstOrDefault(
                        p =>
                            p.v_SerieGuiaRemision == pstrSerie && p.v_NumeroGuiaRemision == pstrCorrelativo &&
                            p.i_Eliminado == 0);

                    if (guiaRemision != null)
                    {
                        guiaRemision.i_UsadoEnIngresoAlmacen = UsadoIngresoAlmacen;
                        if (Globals.ClientSession.v_RucEmpresa == Constants.RucHormiguita) guiaRemision.i_IdEstado = TipoEstado;
                        dbContext.guiaremision.ApplyCurrentValues(guiaRemision);
                        dbContext.SaveChanges();
                        objOperationResult.Success = 1;
                    }

                }
            }
            catch (Exception ex)
            {
                objOperationResult.Success = 0;
                objOperationResult.AdditionalInformation = "MovimientoBL.ActualizarGuiaRemisionDespachada()";
                objOperationResult.ErrorMessage = ex.Message;
                objOperationResult.ExceptionMessage = ex.InnerException != null ? ex.InnerException.Message : string.Empty;
                Utils.ExceptionToLog(Globals.ClientSession.i_SystemUserId, objOperationResult);
            }
        }

        #endregion

        #region Bandeja
        public List<movimientoDto> ListarBusquedaMovimientos(ref OperationResult pobjOperationResult, string pstrSortExpression, string pstrFilterExpression, DateTime F_Ini, DateTime F_Fin, int pintTipoMovimiento, int Establecimiento)
        {
            try
            {
                using (var dbContext = new SAMBHSEntitiesModelWin())
                {

                    int _b = pintTipoMovimiento == 1
                        ? 19
                        : pintTipoMovimiento == 2 ? 20 : pintTipoMovimiento == 3 ? 22 : 0;

                    var query = (from n in dbContext.movimiento

                                 join A in dbContext.almacen on new { ao = n.i_IdAlmacenOrigen.Value, eliminado = 0 } equals
                                 new { ao = A.i_IdAlmacen, eliminado = A.i_Eliminado.Value } into A_join
                                 from A in A_join.DefaultIfEmpty()

                                 join B in dbContext.cliente on n.v_IdCliente equals B.v_IdCliente into B_join
                                 from B in B_join.DefaultIfEmpty()

                                 join J1 in dbContext.datahierarchy on new { i_TipoMotivo = n.i_IdTipoMotivo.Value, b = _b }
                                 equals new { i_TipoMotivo = J1.i_ItemId, b = J1.i_GroupId } into J1_join
                                 from J1 in J1_join.DefaultIfEmpty()

                                 join J2 in dbContext.systemuser on new { i_UpdateUserId = n.i_ActualizaIdUsuario.Value }
                                 equals new { i_UpdateUserId = J2.i_SystemUserId } into J2_join
                                 from J2 in J2_join.DefaultIfEmpty()

                                 join J3 in dbContext.systemuser on new { i_InsertUserId = n.i_InsertaIdUsuario.Value }
                                 equals new { i_InsertUserId = J3.i_SystemUserId } into J3_join
                                 from J3 in J3_join.DefaultIfEmpty()

                                 join J4 in dbContext.almacen on new { ad = n.i_IdAlmacenDestino.Value, eliminado = 0 } equals
                                 new { ad = J4.i_IdAlmacen, eliminado = J4.i_Eliminado.Value } into J4_join
                                 from J4 in J4_join.DefaultIfEmpty()

                                 join J5 in dbContext.documento on new { doccabecera = n.i_IdTipoDocumento.Value, eliminado = 0 } equals new { doccabecera = J5.i_CodigoDocumento, eliminado = J5.i_Eliminado.Value } into J5_join
                                 from J5 in J5_join.DefaultIfEmpty()
                                 where
                                 n.i_Eliminado == 0 && n.t_Fecha >= F_Ini && n.t_Fecha <= F_Fin &&
                                 n.i_IdTipoMovimiento == pintTipoMovimiento

                                // && n.i_IdEstablecimiento ==Globals.ClientSession.i_IdEstablecimiento.Value 
                                && (n.i_IdEstablecimiento == Establecimiento || Establecimiento == -1)
                                 select new movimientoDto
                                 {
                                     v_IdMovimiento = n.v_IdMovimiento,
                                     v_Periodo = n.v_Periodo,
                                     v_Mes = n.v_Mes,
                                     v_Correlativo = n.v_Correlativo,
                                     i_IdAlmacenOrigen = n.i_IdAlmacenOrigen,
                                     i_IdAlmacenDestino = n.i_IdAlmacenDestino,
                                     v_IdCliente = n.v_IdCliente,
                                     i_IdTipoMovimiento = n.i_IdTipoMovimiento,
                                     t_Fecha = n.t_Fecha,
                                     d_TipoCambio = n.d_TipoCambio,
                                     i_IdTipoMotivo = n.i_IdTipoMotivo,
                                     i_IdMoneda = n.i_IdMoneda,
                                     v_Glosa = n.v_Glosa,
                                     i_EsDevolucion = n.i_EsDevolucion,
                                     i_Eliminado = n.i_Eliminado,
                                     i_InsertaIdUsuario = n.i_InsertaIdUsuario,
                                     t_InsertaFecha = n.t_InsertaFecha,
                                     i_ActualizaIdUsuario = n.i_ActualizaIdUsuario,
                                     t_ActualizaFecha = n.t_ActualizaFecha,
                                     v_MesCorrelativo = n.v_Mes + "-" + n.v_Correlativo,
                                     v_AlmacenOrigen = A.v_Nombre,
                                     v_NombreProveedor =
                                     (B.v_ApePaterno + " " + B.v_ApeMaterno + " " + B.v_PrimerNombre + " " +
                                      B.v_SegundoNombre + " " + B.v_RazonSocial).Trim(),
                                     v_DescripcionMotivo = J1.v_Value1,
                                     v_UsuarioModificacion = J2.v_UserName,
                                     v_UsuarioCreacion = J3.v_UserName,
                                     RegistroOrigen = n.v_OrigenTipo + " " + n.v_OrigenRegMes + "-" + n.v_OrigenRegCorrelativo,
                                     v_AlmacenDestino = J4.v_Nombre,
                                     i_IdEstablecimiento = n.i_IdEstablecimiento.Value,
                                     Moneda = n.i_IdMoneda == 1 ? "S" : "D",
                                     i_IdTipoDocumento = n.i_IdTipoDocumento ?? -1,
                                     v_SerieDocumento = n.v_SerieDocumento,
                                     v_CorrelativoDocumento = n.v_CorrelativoDocumento,
                                     NroDocumentoCabecera = J5 != null ? J5.v_Siglas + " " + n.v_SerieDocumento + "-" + n.v_CorrelativoDocumento : "",
                                 }
                    );

                    if (!string.IsNullOrEmpty(pstrFilterExpression))
                    {
                        query = query.Where(pstrFilterExpression);
                    }
                    if (!string.IsNullOrEmpty(pstrSortExpression))
                    {
                        query = query.OrderBy(pstrSortExpression);
                    }

                    List<movimientoDto> objData = query.ToList();
                    pobjOperationResult.Success = 1;
                    return objData;
                }
            }
            catch (Exception ex)
            {
                pobjOperationResult.Success = 0;
                pobjOperationResult.ExceptionMessage = Utils.ExceptionFormatter(ex);
                return null;
            }
        }

        public List<KeyValueDTO> BuscarProveedoresParaCombo(ref OperationResult pobjOperationResult, string pstrRucRazonSocial, string Flag)
        {
            try
            {
                SAMBHSEntitiesModelWin dbcontext = new SAMBHSEntitiesModelWin();
                var query = (from n in dbcontext.cliente
                             where n.i_Eliminado == 0 &&
                                   n.v_PrimerNombre.Contains(pstrRucRazonSocial) | n.v_SegundoNombre.Contains(pstrRucRazonSocial) | n.v_ApeMaterno.Contains(pstrRucRazonSocial)
                                   | n.v_ApePaterno.Contains(pstrRucRazonSocial) | n.v_RazonSocial.Contains(pstrRucRazonSocial) | n.v_NroDocIdentificacion.Contains(pstrRucRazonSocial)
                                   && n.v_FlagPantalla == Flag && pstrRucRazonSocial.Trim() != ""

                             orderby n.v_RazonSocial ascending
                             select new
                             {
                                 v_IdCliente = n.v_IdCliente,
                                 v_RazonSocial = (n.v_PrimerNombre + " " + n.v_ApePaterno + " " + n.v_ApeMaterno + " " + n.v_RazonSocial).Trim(),
                                 v_NroDocIdentificacion = n.v_NroDocIdentificacion
                             }
                             );

                var query2 = query.AsEnumerable()
                            .Select(x => new KeyValueDTO
                            {
                                Id = x.v_IdCliente,
                                Value1 = x.v_NroDocIdentificacion + " | " + x.v_RazonSocial
                            }).ToList();

                return query2;
            }
            catch (Exception)
            {

                throw;
            }
        }
        #endregion

        public bool ExisteNroRegistro(string Periodo, string Mes, string Correlativo, int TipoMovimiento)
        {
            using (var dbContext = new SAMBHSEntitiesModelWin())
            {
                string replicationID = Globals.ClientSession.ReplicationNodeID;
                var Registro = (from n in dbContext.movimiento
                                where n.i_Eliminado == 0 && n.v_Periodo == Periodo && n.v_Mes == Mes && n.v_Correlativo == Correlativo
                                && n.i_IdTipoMovimiento == TipoMovimiento && n.v_IdMovimiento.Substring(0, 1) == replicationID
                                select n.v_IdMovimiento).FirstOrDefault();

                return Registro == null;
            }
        }

        #region Kardex

        public List<movimientodetalleDto> ObtenerDetalleKardex(ref OperationResult objOperationResult, int idAlmacen, string pstrProductoDetalle, int FormatoCant)
        {
            try
            {
                SAMBHSEntitiesModelWin dbContext = new SAMBHSEntitiesModelWin();
                string periodo = Globals.ClientSession.i_Periodo.ToString();
                var query = (from n in dbContext.movimiento

                             join D in dbContext.movimientodetalle on new { IdMovimiento = n.v_IdMovimiento, eliminado = 0 } equals new { IdMovimiento = D.v_IdMovimiento, eliminado = D.i_Eliminado.Value } into D_join
                             from D in D_join.DefaultIfEmpty()

                             join A in dbContext.cliente on new { IdCliente = n.v_IdCliente, eliminado = 0 } equals new { IdCliente = A.v_IdCliente, eliminado = A.i_Eliminado.Value } into A_join
                             from A in A_join.DefaultIfEmpty()

                             join B in dbContext.productodetalle on new { IdProductoDetalle = D.v_IdProductoDetalle, eliminado = 0 } equals new { IdProductoDetalle = B.v_IdProductoDetalle, eliminado = B.i_Eliminado.Value } into B_join

                             from B in B_join.DefaultIfEmpty()

                             join C in dbContext.producto on new { IdProducto = B.v_IdProducto, eliminado = 0 } equals new { IdProducto = C.v_IdProducto, eliminado = C.i_Eliminado.Value } into C_join

                             from C in C_join.DefaultIfEmpty()

                             join E in dbContext.datahierarchy on new { Grupo = 17, eliminado = 0, UnidadMedida = D.i_IdUnidad.Value } equals new { Grupo = E.i_GroupId, eliminado = E.i_IsDeleted.Value, UnidadMedida = E.i_ItemId } into E_join

                             from E in E_join.DefaultIfEmpty()

                             join F in dbContext.almacen on new { IdAlmacen = n.i_IdAlmacenDestino.Value, eliminado = 0 } equals new { IdAlmacen = F.i_IdAlmacen, eliminado = F.i_Eliminado.Value } into F_join

                             from F in F_join.DefaultIfEmpty()

                             join K in dbContext.datahierarchy on new { Grupo = 17, eliminado = 0, Um = C.i_IdUnidadMedida.Value } equals new { Grupo = K.i_GroupId, eliminado = K.i_IsDeleted.Value, Um = K.i_ItemId } into K_join

                             from K in K_join.DefaultIfEmpty()

                             where D.v_IdProductoDetalle == pstrProductoDetalle & n.i_IdAlmacenOrigen == idAlmacen && n.i_Eliminado == 0 && n.v_Periodo == periodo


                             && n.i_IdTipoMovimiento != (int)TipoDeMovimiento.Transferencia
                             // orderby n.t_Fecha , n.i_IdTipoMovimiento
                             orderby n.t_Fecha.Value, n.v_Mes.Trim() + "-" + n.v_Correlativo.Trim(), n.i_IdTipoMovimiento

                             select new movimientodetalleDto
                             {


                                 t_InsertaFecha = n.t_InsertaFecha,
                                 TipoDocumento = (n.i_IdTipoMovimiento == (int)TipoDeMovimiento.NotadeIngreso) ? "NI" : (n.i_IdTipoMovimiento == (int)TipoDeMovimiento.NotadeSalida) ? "NS" : "TRANSF.",
                                 v_NroGuiaRemision = D.v_NroGuiaRemision,
                                 v_NumeroDocumento = n.v_Mes + "-" + n.v_Correlativo,
                                 v_NombreClienteProveedor = n.v_OrigenTipo == "T" ? " D E     T R A N S F E R E N C I A" : (A.v_PrimerNombre + " " + A.v_ApePaterno + " " + A.v_ApeMaterno + " " + A.v_RazonSocial).Trim(),
                                 Ingresos = n.i_IdTipoMovimiento == 1 ? D.d_CantidadEmpaque == null ? D.d_Cantidad : D.d_CantidadEmpaque : 0,
                                 Salidas = n.i_IdTipoMovimiento == 2 ? D.d_CantidadEmpaque == null ? D.d_Cantidad : D.d_CantidadEmpaque : 0,
                                 Transferencias = n.i_IdTipoMovimiento == (int)TipoDeMovimiento.Transferencia ? D.d_CantidadEmpaque == null ? D.d_Cantidad : D.d_CantidadEmpaque : 0,
                                 TipoMovimiento = n.i_IdTipoMovimiento,
                                 v_NroPedido = D.v_NroPedido,
                                 moneda = n.i_IdMoneda == 1 ? "S/" : "US$.",
                                 d_Precio = D.d_Precio,
                                 Fecha = n.t_Fecha,
                                 EsDevolucion = n.i_EsDevolucion == null ? 0 : n.i_EsDevolucion,
                                 UnidadMIngreso = n.i_IdTipoMovimiento == (int)TipoDeMovimiento.NotadeIngreso ? E.v_Value1 : "",
                                 UnidadMSalida = n.i_IdTipoMovimiento == (int)TipoDeMovimiento.NotadeSalida ? E.v_Value1 : "",
                                 UnidadMTransferenia = n.i_IdTipoMovimiento == (int)TipoDeMovimiento.Transferencia ? E.v_Value1 : "",
                                 d_CantidadEmpaque = D.d_CantidadEmpaque.Value,
                                 UnidadMSaldo = C.d_Empaque.Value == 1 && E.v_Value2 == "1" ? E.v_Value1 : "UNIDAD",
                                 IngresosCantidadEmpaque = n.i_IdTipoMovimiento.Value == (int)TipoDeMovimiento.NotadeIngreso ? D.d_CantidadEmpaque == null ? 0 : D.d_CantidadEmpaque.Value : 0,
                                 SalidasCantidadEmpaque = n.i_IdTipoMovimiento.Value == (int)TipoDeMovimiento.NotadeSalida ? D.d_CantidadEmpaque == null ? 0 : D.d_CantidadEmpaque.Value : 0,
                                 v_IdMovimientoDetalle = D.v_IdMovimientoDetalle,
                                 AlmacenDestino = n.i_IdTipoMovimiento == (int)TipoDeMovimiento.Transferencia ? F.v_Nombre.Trim() : "",
                                 v_IdMovimiento = n.v_IdMovimiento,
                                 Origen = n.v_OrigenTipo == null ? "" : n.v_OrigenTipo,
                                 ValorUm = K.v_Value2,

                             }).ToList().Select(x => new movimientodetalleDto
                             {
                                 t_InsertaFecha = x.t_InsertaFecha,
                                 TipoDocumento = x.TipoDocumento,
                                 v_NroGuiaRemision = x.v_NroGuiaRemision,
                                 v_NumeroDocumento = x.v_NumeroDocumento,
                                 v_NombreClienteProveedor = x.v_NombreClienteProveedor,
                                 Ingresos = FormatoCant == (int)FormatoCantidad.Unidades ? x.Ingresos : x.Ingresos / int.Parse(x.ValorUm),
                                 Salidas = FormatoCant == (int)FormatoCantidad.Unidades ? x.Salidas : x.Salidas / int.Parse(x.ValorUm),
                                 Transferencias = x.Transferencias,
                                 TipoMovimiento = x.TipoMovimiento,
                                 v_NroPedido = x.v_NroPedido,
                                 moneda = x.moneda,
                                 d_Precio = x.d_Precio,
                                 Fecha = x.Fecha,
                                 EsDevolucion = x.EsDevolucion,
                                 UnidadMIngreso = x.UnidadMIngreso,
                                 UnidadMSalida = x.UnidadMSalida,
                                 UnidadMTransferenia = x.UnidadMTransferenia,
                                 d_CantidadEmpaque = x.d_CantidadEmpaque.Value,
                                 UnidadMSaldo = x.UnidadMSaldo,
                                 IngresosCantidadEmpaque = FormatoCant == (int)FormatoCantidad.Unidades ? x.IngresosCantidadEmpaque : x.IngresosCantidadEmpaque / int.Parse(x.ValorUm),
                                 SalidasCantidadEmpaque = FormatoCant == (int)FormatoCantidad.Unidades ? x.SalidasCantidadEmpaque : x.SalidasCantidadEmpaque / int.Parse(x.ValorUm),
                                 v_IdMovimientoDetalle = x.v_IdMovimientoDetalle,
                                 AlmacenDestino = x.AlmacenDestino,
                                 v_IdMovimiento = x.v_IdMovimiento,
                                 Origen = x.Origen,

                             }).ToList();

                objOperationResult.Success = 1;
                return query;

            }
            catch (Exception e)
            {
                objOperationResult.Success = 0;
                return null;
            }

        }
        public List<movimientodetalleDto> ObtenerDetalleKardexManguifajas(ref OperationResult objOperationResult, int idAlmacen, string pstrProductoDetalle, int FormatoCant)
        {
            try
            {
                SAMBHSEntitiesModelWin dbContext = new SAMBHSEntitiesModelWin();
                string periodo = Globals.ClientSession.i_Periodo.ToString();

                var query = (from n in dbContext.movimiento

                             join D in dbContext.movimientodetalle on new { IdMovimiento = n.v_IdMovimiento, eliminado = 0 } equals new { IdMovimiento = D.v_IdMovimiento, eliminado = D.i_Eliminado.Value } into D_join
                             from D in D_join.DefaultIfEmpty()

                             join A in dbContext.cliente on new { IdCliente = n.v_IdCliente, eliminado = 0 } equals new { IdCliente = A.v_IdCliente, eliminado = A.i_Eliminado.Value } into A_join
                             from A in A_join.DefaultIfEmpty()

                             join B in dbContext.productodetalle on new { IdProductoDetalle = D.v_IdProductoDetalle, eliminado = 0 } equals new { IdProductoDetalle = B.v_IdProductoDetalle, eliminado = B.i_Eliminado.Value } into B_join

                             from B in B_join.DefaultIfEmpty()

                             join C in dbContext.producto on new { IdProducto = B.v_IdProducto, eliminado = 0 } equals new { IdProducto = C.v_IdProducto, eliminado = C.i_Eliminado.Value } into C_join

                             from C in C_join.DefaultIfEmpty()

                             join E in dbContext.datahierarchy on new { Grupo = 17, eliminado = 0, UnidadMedida = D.i_IdUnidad.Value } equals new { Grupo = E.i_GroupId, eliminado = E.i_IsDeleted.Value, UnidadMedida = E.i_ItemId } into E_join

                             from E in E_join.DefaultIfEmpty()

                             join F in dbContext.almacen on new { IdAlmacen = n.i_IdAlmacenDestino.Value, eliminado = 0 } equals new { IdAlmacen = F.i_IdAlmacen, eliminado = F.i_Eliminado.Value } into F_join

                             from F in F_join.DefaultIfEmpty()

                             join K in dbContext.datahierarchy on new { Grupo = 17, eliminado = 0, Um = C.i_IdUnidadMedida.Value } equals new { Grupo = K.i_GroupId, eliminado = K.i_IsDeleted.Value, Um = K.i_ItemId } into K_join

                             from K in K_join.DefaultIfEmpty()

                             join L in dbContext.documento on new { Doc = D.i_IdTipoDocumento.Value, eliminado = 0 } equals new { Doc = L.i_CodigoDocumento, eliminado = L.i_Eliminado.Value } into L_join

                             from L in L_join.DefaultIfEmpty()

                             where D.v_IdProductoDetalle == pstrProductoDetalle & n.i_IdAlmacenOrigen == idAlmacen && n.i_Eliminado == 0 && n.v_Periodo == periodo

                             && n.i_IdTipoMovimiento != (int)TipoDeMovimiento.Transferencia
                             // orderby n.t_Fecha , n.i_IdTipoMovimiento
                             orderby n.t_Fecha.Value, n.v_Mes.Trim() + "-" + n.v_Correlativo.Trim(), n.i_IdTipoMovimiento

                             select new movimientodetalleDto
                             {


                                 t_InsertaFecha = n.t_InsertaFecha,
                                 TipoDocumento = L != null ? L.v_Siglas : (n.i_IdTipoMovimiento == (int)TipoDeMovimiento.NotadeIngreso) ? "NI" : (n.i_IdTipoMovimiento == (int)TipoDeMovimiento.NotadeSalida) ? "NS" : "TRANSF.",
                                 v_NroGuiaRemision = D.v_NroGuiaRemision,
                                 v_NumeroDocumento = L != null ? D.v_NumeroDocumento.Trim() : n.v_Mes + "-" + n.v_Correlativo,
                                 v_NombreClienteProveedor = n.v_OrigenTipo == "T" ? " D E     T R A N S F E R E N C I A" : (A.v_PrimerNombre + " " + A.v_ApePaterno + " " + A.v_ApeMaterno + " " + A.v_RazonSocial).Trim(),
                                 Ingresos = n.i_IdTipoMovimiento == 1 ? D.d_CantidadEmpaque == null ? D.d_Cantidad : D.d_CantidadEmpaque : 0,
                                 Salidas = n.i_IdTipoMovimiento == 2 ? D.d_CantidadEmpaque == null ? D.d_Cantidad : D.d_CantidadEmpaque : 0,
                                 Transferencias = n.i_IdTipoMovimiento == (int)TipoDeMovimiento.Transferencia ? D.d_CantidadEmpaque == null ? D.d_Cantidad : D.d_CantidadEmpaque : 0,
                                 TipoMovimiento = n.i_IdTipoMovimiento,
                                 v_NroPedido = D.v_NroPedido,
                                 moneda = n.i_IdMoneda == 1 ? "S/" : "US$.",
                                 d_Precio = D.d_Precio,
                                 Fecha = n.t_Fecha,
                                 EsDevolucion = n.i_EsDevolucion == null ? 0 : n.i_EsDevolucion,
                                 UnidadMIngreso = n.i_IdTipoMovimiento == (int)TipoDeMovimiento.NotadeIngreso ? E.v_Value1 : "",
                                 UnidadMSalida = n.i_IdTipoMovimiento == (int)TipoDeMovimiento.NotadeSalida ? E.v_Value1 : "",
                                 UnidadMTransferenia = n.i_IdTipoMovimiento == (int)TipoDeMovimiento.Transferencia ? E.v_Value1 : "",
                                 d_CantidadEmpaque = D.d_CantidadEmpaque.Value,
                                 UnidadMSaldo = C.d_Empaque.Value == 1 && E.v_Value2 == "1" ? E.v_Value1 : "UNIDAD",
                                 IngresosCantidadEmpaque = n.i_IdTipoMovimiento.Value == (int)TipoDeMovimiento.NotadeIngreso ? D.d_CantidadEmpaque == null ? 0 : D.d_CantidadEmpaque.Value : 0,
                                 SalidasCantidadEmpaque = n.i_IdTipoMovimiento.Value == (int)TipoDeMovimiento.NotadeSalida ? D.d_CantidadEmpaque == null ? 0 : D.d_CantidadEmpaque.Value : 0,
                                 v_IdMovimientoDetalle = D.v_IdMovimientoDetalle,
                                 AlmacenDestino = n.i_IdTipoMovimiento == (int)TipoDeMovimiento.Transferencia ? F.v_Nombre.Trim() : "",
                                 v_IdMovimiento = n.v_IdMovimiento,
                                 Origen = n.v_OrigenTipo == null ? "" : n.v_OrigenTipo,
                                 ValorUm = K.v_Value2,
                                 CodigoProducto = C.v_CodInterno.Trim() + " - " + C.v_Descripcion.Trim(),
                                 i_TipoDocumento = D.i_IdTipoDocumento.Value,


                             }).ToList().Select(x => new movimientodetalleDto
                             {
                                 t_InsertaFecha = x.t_InsertaFecha,
                                 TipoDocumento = x.TipoDocumento,
                                 v_NroGuiaRemision = x.v_NroGuiaRemision,
                                 v_NumeroDocumento = x.v_NumeroDocumento,
                                 v_NombreClienteProveedor = x.v_NombreClienteProveedor,
                                 Ingresos = FormatoCant == (int)FormatoCantidad.Unidades ? x.Ingresos : x.Ingresos / int.Parse(x.ValorUm),
                                 Salidas = FormatoCant == (int)FormatoCantidad.Unidades ? x.Salidas : x.Salidas / int.Parse(x.ValorUm),
                                 Transferencias = x.Transferencias,
                                 TipoMovimiento = x.TipoMovimiento,
                                 v_NroPedido = x.v_NroPedido,
                                 moneda = x.moneda,
                                 d_Precio = x.d_Precio,
                                 Fecha = x.Fecha,
                                 EsDevolucion = x.EsDevolucion,
                                 UnidadMIngreso = x.UnidadMIngreso,
                                 UnidadMSalida = x.UnidadMSalida,
                                 UnidadMTransferenia = x.UnidadMTransferenia,
                                 d_CantidadEmpaque = x.d_CantidadEmpaque.Value,
                                 UnidadMSaldo = x.UnidadMSaldo,
                                 IngresosCantidadEmpaque = FormatoCant == (int)FormatoCantidad.Unidades ? x.IngresosCantidadEmpaque : x.IngresosCantidadEmpaque / int.Parse(x.ValorUm),
                                 SalidasCantidadEmpaque = FormatoCant == (int)FormatoCantidad.Unidades ? x.SalidasCantidadEmpaque : x.SalidasCantidadEmpaque / int.Parse(x.ValorUm),
                                 v_IdMovimientoDetalle = x.v_IdMovimientoDetalle,
                                 AlmacenDestino = x.AlmacenDestino,
                                 v_IdMovimiento = x.v_IdMovimiento,
                                 Origen = x.Origen,
                                 CodigoProducto = x.CodigoProducto,
                                 i_TipoDocumento = x.i_TipoDocumento,

                             }).ToList();

                objOperationResult.Success = 1;
                return query;

            }
            catch (Exception e)
            {
                objOperationResult.Success = 0;
                return null;
            }

        }



        public List<movimientodetalleDto> ObtenerDetalleKardexManguifajasFecha(ref OperationResult objOperationResult, int idAlmacen, string pstrProductoDetalle, int FormatoCant, DateTime FechaDesde, DateTime FechaHasta)
        {
            try
            {
                SAMBHSEntitiesModelWin dbContext = new SAMBHSEntitiesModelWin();

                DateTime InicioAnio = DateTime.Parse("01/01/" + FechaDesde.Year.ToString());

                List<movimientodetalleDto> detallesKardex = new List<movimientodetalleDto>();


                detallesKardex = (from n in dbContext.movimiento

                                  join D in dbContext.movimientodetalle on new { IdMovimiento = n.v_IdMovimiento, eliminado = 0 } equals new { IdMovimiento = D.v_IdMovimiento, eliminado = D.i_Eliminado.Value } into D_join
                                  from D in D_join.DefaultIfEmpty()

                                  join A in dbContext.cliente on new { IdCliente = n.v_IdCliente, eliminado = 0 } equals new { IdCliente = A.v_IdCliente, eliminado = A.i_Eliminado.Value } into A_join
                                  from A in A_join.DefaultIfEmpty()

                                  join B in dbContext.productodetalle on new { IdProductoDetalle = D.v_IdProductoDetalle, eliminado = 0 } equals new { IdProductoDetalle = B.v_IdProductoDetalle, eliminado = B.i_Eliminado.Value } into B_join

                                  from B in B_join.DefaultIfEmpty()

                                  join C in dbContext.producto on new { IdProducto = B.v_IdProducto, eliminado = 0 } equals new { IdProducto = C.v_IdProducto, eliminado = C.i_Eliminado.Value } into C_join

                                  from C in C_join.DefaultIfEmpty()

                                  join E in dbContext.datahierarchy on new { Grupo = 17, eliminado = 0, UnidadMedida = D.i_IdUnidad.Value } equals new { Grupo = E.i_GroupId, eliminado = E.i_IsDeleted.Value, UnidadMedida = E.i_ItemId } into E_join

                                  from E in E_join.DefaultIfEmpty()

                                  join F in dbContext.almacen on new { IdAlmacen = n.i_IdAlmacenDestino.Value, eliminado = 0 } equals new { IdAlmacen = F.i_IdAlmacen, eliminado = F.i_Eliminado.Value } into F_join

                                  from F in F_join.DefaultIfEmpty()

                                  join K in dbContext.datahierarchy on new { Grupo = 17, eliminado = 0, Um = C.i_IdUnidadMedida.Value } equals new { Grupo = K.i_GroupId, eliminado = K.i_IsDeleted.Value, Um = K.i_ItemId } into K_join

                                  from K in K_join.DefaultIfEmpty()

                                  join L in dbContext.documento on new { Doc = D.i_IdTipoDocumento.Value, eliminado = 0 } equals new { Doc = L.i_CodigoDocumento, eliminado = L.i_Eliminado.Value } into L_join

                                  from L in L_join.DefaultIfEmpty()

                                  where D.v_IdProductoDetalle == pstrProductoDetalle & n.i_IdAlmacenOrigen == idAlmacen && n.i_Eliminado == 0

                                  && n.i_IdTipoMovimiento != (int)TipoDeMovimiento.Transferencia


                                  && n.t_Fecha.Value >= InicioAnio && n.t_Fecha.Value <= FechaHasta



                                  orderby n.t_Fecha.Value, n.v_Mes.Trim() + "-" + n.v_Correlativo.Trim(), n.i_IdTipoMovimiento

                                  select new movimientodetalleDto
                                  {


                                      t_InsertaFecha = n.t_InsertaFecha,
                                      TipoDocumento = L != null ? L.v_Siglas : (n.i_IdTipoMovimiento == (int)TipoDeMovimiento.NotadeIngreso) ? "NI" : (n.i_IdTipoMovimiento == (int)TipoDeMovimiento.NotadeSalida) ? "NS" : "TRANSF.",
                                      v_NroGuiaRemision = D.v_NroGuiaRemision,
                                      v_NumeroDocumento = L != null ? D.v_NumeroDocumento.Trim() : n.v_Mes + "-" + n.v_Correlativo,
                                      v_NombreClienteProveedor = n.v_OrigenTipo == "T" ? " D E     T R A N S F E R E N C I A" : (A.v_PrimerNombre + " " + A.v_ApePaterno + " " + A.v_ApeMaterno + " " + A.v_RazonSocial).Trim(),
                                      Transferencias = n.i_IdTipoMovimiento == (int)TipoDeMovimiento.Transferencia ? D.d_CantidadEmpaque == null ? D.d_Cantidad : D.d_CantidadEmpaque : 0,
                                      TipoMovimiento = n.i_IdTipoMovimiento,
                                      v_NroPedido = D.v_NroPedido,
                                      moneda = n.i_IdMoneda == 1 ? "S/" : "US$.",
                                      d_Precio = D.d_Precio,
                                      Fecha = n.t_Fecha,
                                      EsDevolucion = n.i_EsDevolucion == null ? 0 : n.i_EsDevolucion,
                                      //UnidadMIngreso = n.i_IdTipoMovimiento == (int)TipoDeMovimiento.NotadeIngreso ? E.v_Value1 : "",
                                      //UnidadMSalida = n.i_IdTipoMovimiento == (int)TipoDeMovimiento.NotadeSalida ? E.v_Value1 : "",
                                      //UnidadMTransferenia = n.i_IdTipoMovimiento == (int)TipoDeMovimiento.Transferencia ? E.v_Value1 : "",
                                      //UnidadMSaldo = C.d_Empaque.Value == 1 && E.v_Value2 == "1" ? E.v_Value1 : "UNIDAD",

                                      d_CantidadEmpaque = D.d_CantidadEmpaque.Value,
                                      UnidadMIngreso = n.i_IdTipoMovimiento == (int)TipoDeMovimiento.NotadeIngreso ? FormatoCant == ((int)FormatoCantidad.Unidades) ? "UNIDAD" : E.v_Value1 : "",
                                      UnidadMSalida = n.i_IdTipoMovimiento == (int)TipoDeMovimiento.NotadeSalida ? FormatoCant == ((int)FormatoCantidad.Unidades) ? "UNIDAD" : E.v_Value1 : "",
                                      UnidadMTransferenia = n.i_IdTipoMovimiento == (int)TipoDeMovimiento.Transferencia ? FormatoCant == ((int)FormatoCantidad.Unidades) ? "UNIDAD" : E.v_Value1 : "",
                                      UnidadMSaldo = string.IsNullOrEmpty(E.v_Value1) ? "1" : E.v_Value1,
                                      IngresosCantidadEmpaque = n.i_IdTipoMovimiento == 1 ? n.i_EsDevolucion == 1 ? D.d_CantidadEmpaque == null ? D.d_Cantidad.Value * -1 : D.d_CantidadEmpaque.Value * -1 : D.d_CantidadEmpaque == null ? D.d_Cantidad.Value : D.d_CantidadEmpaque.Value : 0,
                                      SalidasCantidadEmpaque = n.i_IdTipoMovimiento == 2 ? n.i_EsDevolucion == 1 ? D.d_CantidadEmpaque == null ? D.d_Cantidad.Value * -1 : D.d_CantidadEmpaque.Value * -1 : D.d_CantidadEmpaque == null ? D.d_Cantidad.Value : D.d_CantidadEmpaque.Value : 0,
                                      v_IdMovimientoDetalle = D.v_IdMovimientoDetalle,
                                      AlmacenDestino = n.i_IdTipoMovimiento == (int)TipoDeMovimiento.Transferencia ? F.v_Nombre.Trim() : "",
                                      v_IdMovimiento = n.v_IdMovimiento,
                                      Origen = n.v_OrigenTipo == null ? "" : n.v_OrigenTipo,
                                      ValorUm = string.IsNullOrEmpty(K.v_Value2) ? "1" : K.v_Value2,
                                      CodigoProducto = C.v_CodInterno.Trim(),
                                      i_TipoDocumento = D.i_IdTipoDocumento.Value,
                                      Ingresos = n.i_IdTipoMovimiento == 1 ? n.i_EsDevolucion == 1 ? D.d_CantidadEmpaque == null ? D.d_Cantidad * -1 : D.d_CantidadEmpaque * -1 : D.d_CantidadEmpaque == null ? D.d_Cantidad : D.d_CantidadEmpaque : 0,
                                      Salidas = n.i_IdTipoMovimiento == 2 ? n.i_EsDevolucion == 1 ? D.d_CantidadEmpaque == null ? D.d_Cantidad * -1 : D.d_CantidadEmpaque * -1 : D.d_CantidadEmpaque == null ? D.d_Cantidad : D.d_CantidadEmpaque : 0,
                                      TipoMotivo = n.i_IdTipoMotivo ?? 0,
                                      DescripcionProducto = C.v_Descripcion.Trim(),
                                      v_IdMovimientoOrigen = n.v_IdMovimientoOrigen,


                                  }).ToList().Select(x => new movimientodetalleDto
                              {
                                  t_InsertaFecha = x.t_InsertaFecha,
                                  TipoDocumento = x.TipoDocumento,
                                  v_NroGuiaRemision = x.v_NroGuiaRemision,
                                  v_NumeroDocumento = x.v_NumeroDocumento,
                                  v_NombreClienteProveedor = x.v_NombreClienteProveedor,
                                  Ingresos = FormatoCant == (int)FormatoCantidad.Unidades ? x.Ingresos : x.Ingresos == 0 || x.ValorUm == "0" ? 0 : x.Ingresos / int.Parse(x.ValorUm),
                                  Salidas = FormatoCant == (int)FormatoCantidad.Unidades ? x.Salidas : x.Salidas == 0 || x.ValorUm == "0" ? 0 : x.Salidas / int.Parse(x.ValorUm),
                                  Transferencias = x.Transferencias,
                                  TipoMovimiento = x.TipoMovimiento,
                                  v_NroPedido = x.v_NroPedido,
                                  moneda = x.moneda,
                                  d_Precio = x.d_Precio,
                                  Fecha = x.Fecha,
                                  EsDevolucion = x.EsDevolucion,
                                  UnidadMIngreso = x.UnidadMIngreso,
                                  UnidadMSalida = x.UnidadMSalida,
                                  UnidadMTransferenia = x.UnidadMTransferenia,
                                  d_CantidadEmpaque = x.d_CantidadEmpaque.Value,
                                  UnidadMSaldo = x.UnidadMSaldo,
                                  IngresosCantidadEmpaque = FormatoCant == (int)FormatoCantidad.Unidades ? x.IngresosCantidadEmpaque : x.IngresosCantidadEmpaque == 0 || x.ValorUm == "0" ? 0 : x.IngresosCantidadEmpaque / int.Parse(x.ValorUm),
                                  SalidasCantidadEmpaque = FormatoCant == (int)FormatoCantidad.Unidades ? x.SalidasCantidadEmpaque : x.SalidasCantidadEmpaque == 0 || x.ValorUm == "0" ? 0 : x.SalidasCantidadEmpaque / int.Parse(x.ValorUm),
                                  v_IdMovimientoDetalle = x.v_IdMovimientoDetalle,
                                  AlmacenDestino = x.AlmacenDestino,
                                  v_IdMovimiento = x.v_IdMovimiento,
                                  Origen = x.Origen,
                                  CodigoProducto = x.CodigoProducto + " " + x.DescripcionProducto,
                                  i_TipoDocumento = x.i_TipoDocumento,
                                  IngresosTotal = x.IngresosTotal,
                                  SalidasTotal = x.SalidasTotal,
                                  TipoMotivo = x.TipoMotivo,
                                  DescripcionProducto = x.DescripcionProducto,
                                  v_IdMovimientoOrigen = x.v_IdMovimientoOrigen,
                              }).ToList();
                //}
                objOperationResult.Success = 1;
                List<movimientodetalleDto> Lista = new List<movimientodetalleDto>();
                //if (FechaDesde.Month.ToString("00") != "01")
                //{
                var f = DateTime.Parse(FechaDesde.ToShortDateString() + " 23:59");
                var FechaAnt = f.AddDays(-1);
                List<movimientodetalleDto> Sald = new List<movimientodetalleDto>();
                Sald = detallesKardex.Select(item => (movimientodetalleDto)item.Clone()).ToList();
                var ListaSaldosAnt = Sald.ToList().Where(l => l.Fecha <= FechaAnt).GroupBy(l => l.v_NombreProducto).ToList().Select(d =>
                {
                    var k = d.LastOrDefault();
                    k.IngresosCantidadEmpaque = d.Sum(l => l.IngresosCantidadEmpaque) - d.Sum(l => l.SalidasCantidadEmpaque);
                    k.TipoMovimiento = 1;
                    k.TipoDocumento = "INICIAL";
                    DateTime date = FechaAnt;  //DateTime.Parse("01/" + FechaInicioReport.Month.ToString("00") + "/" + FechaInicioReport.Year.ToString()); // DateTime.Parse("01/" + pdtFechaInicio.Value.Month.ToString("00") + "/" + pdtFechaInicio.Value.Year.ToString());
                    k.Fecha = date; //date.ToString("dd-MMM");
                    k.t_Fecha = date;
                    k.v_NroGuiaRemision = "";
                    k.v_NumeroDocumento = "";
                    k.v_NombreClienteProveedor = "";
                    k.Ingresos = null;
                    k.Salidas = null;
                    k.Transferencias = null;
                    k.TipoMovimiento = 1;
                    k.v_NroPedido = null;
                    k.moneda = null;
                    k.UnidadMIngreso = null;
                    k.UnidadMSalida = null;
                    k.UnidadMTransferenia = null;
                    k.d_Precio = null;
                    k.EsDevolucion = 0;
                    k.Origen = "II";
                    return k;
                }).ToList();
                var Lista2 = detallesKardex.Where(l => l.Fecha > FechaAnt).ToList();
                Lista = ListaSaldosAnt.Concat(Lista2).ToList();

                return Lista;


            }
            catch (Exception e)
            {
                objOperationResult.Success = 0;
                return null;
            }

        }





        public string ObtenerIdDiferentesProceso(ref OperationResult objOperationResult, ListaProcesos Proceso, int TipoDoc, string serie, string correlativo)
        {
            try
            {
                objOperationResult.Success = 1;


                KeyValueDTO ProcesoVentaCompra = new KeyValueDTO();
                using (SAMBHSEntitiesModelWin dbContext = new SAMBHSEntitiesModelWin())
                {

                    switch (Proceso)
                    {
                        case ListaProcesos.Venta:

                            ProcesoVentaCompra = (from a in dbContext.venta

                                                  where a.i_Eliminado == 0 && a.i_IdTipoDocumento == TipoDoc && a.v_SerieDocumento.Trim() == serie.Trim() && a.v_CorrelativoDocumento.Trim() == correlativo.Trim()

                                                  select new KeyValueDTO
                                                  {

                                                      Value1 = a.v_IdVenta,

                                                  }).FirstOrDefault();
                            break;

                        case ListaProcesos.Compra:

                            ProcesoVentaCompra = (from a in dbContext.compra

                                                  where a.i_Eliminado == 0 && a.i_IdTipoDocumento == TipoDoc && a.v_SerieDocumento.Trim() == serie.Trim() && a.v_CorrelativoDocumento.Trim() == correlativo.Trim()

                                                  select new KeyValueDTO
                                                  {

                                                      Value1 = a.v_IdCompra,

                                                  }).FirstOrDefault();
                            break;

                        case ListaProcesos.GuiaRemision:
                            ProcesoVentaCompra = (from a in dbContext.guiaremision
                                                  where a.i_Eliminado == 0 && a.i_IdTipoGuia == TipoDoc && a.v_SerieGuiaRemision.Trim() == serie.Trim() && a.v_NumeroGuiaRemision.Trim() == correlativo.Trim()

                                                  select new KeyValueDTO
                                                  {
                                                      Value1 = a.v_IdGuiaRemision,
                                                  }).FirstOrDefault();



                            break;

                        case ListaProcesos.Importacion:



                            ProcesoVentaCompra = (from a in dbContext.importacion
                                                  join b in dbContext.datahierarchy on new { doc = a.i_IdSerieDocumento.Value, eliminado = 0 } equals new { doc = b.i_ItemId, eliminado = b.i_IsDeleted.Value } into b_join
                                                  from b in b_join.DefaultIfEmpty()
                                                  where a.i_Eliminado == 0 && a.i_IdTipoDocumento == TipoDoc && b.v_Value2.Trim() == serie.Trim() && a.v_CorrelativoDocumento == correlativo.Trim()
                                                  select new KeyValueDTO
                                                  {
                                                      Value1 = a.v_IdImportacion,
                                                  }).FirstOrDefault();

                            break;





                    }

                    return ProcesoVentaCompra == null ? null : ProcesoVentaCompra.Value1;

                }

            }
            catch (Exception ex)
            {
                objOperationResult.Success = 0;
                return "";
            }



        }
        #endregion

        public string[] _DevolverIdProductoDetalle(string pstrCodigo)
        {
            try
            {
                SAMBHSEntitiesModelWin dbContext = new SAMBHSEntitiesModelWin();
                string[] Result = new string[3];

                var Codigo = (from n in dbContext.productodetalle
                              join J1 in dbContext.producto on n.v_IdProducto equals J1.v_IdProducto into J1_Join
                              from J1 in J1_Join.DefaultIfEmpty()
                              where J1.v_CodInterno == pstrCodigo
                              select new { n.v_IdProductoDetalle, J1.i_IdUnidadMedida, J1.d_Empaque }).FirstOrDefault();
                if (Codigo != null)
                {
                    Result[0] = Codigo.v_IdProductoDetalle;
                    Result[1] = Codigo.i_IdUnidadMedida.ToString();
                    Result[2] = Codigo.d_Empaque.ToString();
                    return Result;
                }
                else
                {
                    return null;
                }

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        #region Recalculo de Stocks
        public void RecalcularStock(ref OperationResult pobjOperationResult, int pintIdAlmacen, int pintPeriodo, int pintMes, int pintDia, List<string> TempFiltroArticulos = null)
        {
            try
            {
                using (TransactionScope ts = TransactionUtils.CreateTransactionScope())
                {
                    using (SAMBHSEntitiesModelWin dbContext = new SAMBHSEntitiesModelWin())
                    {
                        #region vacía todos los stocks del almacen
                        TempFiltroArticulos = TempFiltroArticulos != null && !TempFiltroArticulos.Any() ? null : TempFiltroArticulos;
                        var Stocks = new List<productoalmacen>();
                        var periodo = Globals.ClientSession.i_Periodo.ToString();
                        if (pintIdAlmacen != -1)
                        {
                            Stocks = dbContext.productoalmacen.Where(p => p.v_Periodo == periodo && p.i_IdAlmacen == pintIdAlmacen && p.i_Eliminado == 0).ToList();
                            if (TempFiltroArticulos != null)
                                Stocks = Stocks.Where(p => TempFiltroArticulos.Contains(p.v_ProductoDetalleId)).ToList();
                        }
                        else
                        {
                            Stocks = dbContext.productoalmacen.Where(p => p.v_Periodo == periodo && p.i_Eliminado == 0).ToList();
                            if (TempFiltroArticulos != null)
                                Stocks = Stocks.Where(p => TempFiltroArticulos.Contains(p.v_ProductoDetalleId)).ToList();
                        }

                        Stocks.ForEach(p =>
                        {
                            p.d_StockActual = 0;
                            dbContext.productoalmacen.ApplyCurrentValues(p);
                        });
                        dbContext.SaveChanges();
                        #endregion

                        #region Obtiene las salidas y entradas del almacen
                        var Movimientos = dbContext.movimiento.Where(p => p.i_Eliminado == 0).ToList();

                        List<movimientodetalle> ingresos;
                        List<movimientodetalle> salidas;

                        if (pintIdAlmacen == -1)
                        {
                            ingresos = (from n in dbContext.movimiento

                                        join J1 in dbContext.movimientodetalle on n.v_IdMovimiento equals J1.v_IdMovimiento into J1_join
                                        from J1 in J1_join.DefaultIfEmpty()

                                        where n.i_Eliminado == 0 && n.t_Fecha.Value.Year == pintPeriodo && n.i_IdTipoMovimiento == 1
                                        && J1.i_Eliminado == 0 && n.t_Fecha.Value.Month >= pintMes && n.t_Fecha.Value.Day >= pintDia

                                        select J1).ToList();

                            salidas = (from n in dbContext.movimiento

                                       join J1 in dbContext.movimientodetalle on n.v_IdMovimiento equals J1.v_IdMovimiento into J1_join
                                       from J1 in J1_join.DefaultIfEmpty()

                                       where n.i_Eliminado == 0 && n.t_Fecha.Value.Year == pintPeriodo && n.i_IdTipoMovimiento == 2
                                       && J1.i_Eliminado == 0 && n.t_Fecha.Value.Month >= pintMes && n.t_Fecha.Value.Day >= pintDia

                                       select J1).ToList();
                        }
                        else
                        {
                            ingresos = (from n in dbContext.movimiento

                                        join J1 in dbContext.movimientodetalle on n.v_IdMovimiento equals J1.v_IdMovimiento into J1_join
                                        from J1 in J1_join.DefaultIfEmpty()

                                        where n.i_Eliminado == 0 && n.t_Fecha.Value.Year == pintPeriodo && n.i_IdTipoMovimiento == 1
                                        && n.i_IdAlmacenOrigen == pintIdAlmacen && n.t_Fecha.Value.Month >= pintMes && n.t_Fecha.Value.Day >= pintDia
                                        && J1.i_Eliminado == 0

                                        select J1).ToList();

                            salidas = (from n in dbContext.movimiento

                                       join J1 in dbContext.movimientodetalle on n.v_IdMovimiento equals J1.v_IdMovimiento into J1_join
                                       from J1 in J1_join.DefaultIfEmpty()

                                       where n.i_Eliminado == 0 && n.t_Fecha.Value.Year == pintPeriodo && n.i_IdTipoMovimiento == 2
                                       && n.i_IdAlmacenOrigen == pintIdAlmacen && n.t_Fecha.Value.Month >= pintMes && n.t_Fecha.Value.Day >= pintDia
                                       && J1.i_Eliminado == 0

                                       select J1).ToList();
                        }

                        if (TempFiltroArticulos != null && TempFiltroArticulos.Any())
                        {
                            var movimientosFiltrados = dbContext.movimientodetalle.Where(m => TempFiltroArticulos.Contains(m.v_IdProductoDetalle) && m.i_Eliminado == 0)
                                    .Select(n => n.v_IdMovimiento).Distinct().ToList();

                            ingresos = ingresos.Where(m => movimientosFiltrados.Contains(m.v_IdMovimiento)).ToList();
                            salidas = salidas.Where(m => movimientosFiltrados.Contains(m.v_IdMovimiento)).ToList();
                        }

                        #endregion

                        #region Se recalculan los stocks
                        Globals.ProgressbarStatus.i_TotalProgress = ingresos.Count + salidas.Count;

                        foreach (var Ingreso in ingresos.AsParallel())
                        {
                            int Almacen = Movimientos.FirstOrDefault(p => p.v_IdMovimiento == Ingreso.v_IdMovimiento).i_IdAlmacenOrigen.Value;

                            ProcesarMovimientoIngresoDetalle(ref pobjOperationResult, Almacen, Ingreso.ToDTO(), Globals.ClientSession.GetAsList());
                            if (pobjOperationResult.Success == 0) return;
                            Globals.ProgressbarStatus.i_Progress++;
                        }

                        foreach (var Salida in salidas.AsParallel())
                        {
                            int Almacen = Movimientos.FirstOrDefault(p => p.v_IdMovimiento == Salida.v_IdMovimiento).i_IdAlmacenOrigen.Value;
                            ProcesarMovimientoSalidaDetalle(ref pobjOperationResult, Almacen, Salida.ToDTO(), Globals.ClientSession.GetAsList());
                            if (pobjOperationResult.Success == 0) return;
                            Globals.ProgressbarStatus.i_Progress++;
                        }
                        #endregion

                        pobjOperationResult.Success = 1;
                        ts.Complete();
                    }
                }
            }
            catch (Exception ex)
            {
                pobjOperationResult.Success = 0;
                pobjOperationResult.AdditionalInformation = "MovimientoBL.RecalcularStock()\nLinea:" + ex.StackTrace.Substring(ex.StackTrace.LastIndexOf(' '));
                pobjOperationResult.ErrorMessage = ex.Message;
                pobjOperationResult.ExceptionMessage = ex.InnerException != null ? ex.InnerException.Message : string.Empty; ;
            }
        }
        #endregion

        #region Acciones a realizar si la empresa actualiza costos en compras.
        /// <summary>
        /// Actualiza los costos de cada uno de los productos que se encuentran en la nota de ingreso si cumple la condicion de ser su ultimo ingreso
        /// </summary>
        /// <param name="pobjOperationResult"></param>
        /// <param name="pobjMovimientoEntrada"></param>
        /// <param name="pobjMovimientoEntradaDetalle"></param>
        /// <param name="eliminacion"></param>
        private static void ActualizarCostoSegunUltimoMovimiento(ref OperationResult pobjOperationResult, movimientoDto pobjMovimientoEntrada, List<movimientodetalleDto> pobjMovimientoEntradaDetalle, bool eliminacion = false)
        {
            try
            {
                pobjOperationResult.Success = 1;
                if (Globals.ClientSession.i_ActualizarCostosProductos != 1) return;
                if (!pobjMovimientoEntradaDetalle.Any()) return;

                using (var ts = TransactionUtils.CreateTransactionScope())
                {
                    using (var dbContext = new SAMBHSEntitiesModelWin())
                    {
                        if (pobjMovimientoEntrada != null && pobjMovimientoEntrada.t_Fecha != null)
                        {
                            var fechaMovimiento = pobjMovimientoEntrada.t_Fecha.Value;
                            var listapreciosTemp = dbContext.listapreciodetalle.AsParallel().Where(p => p.i_Eliminado == 0).ToList();

                            var listasActivas = dbContext.listaprecio.Where(p => p.i_Eliminado == 0).ToList();
                            foreach (var movimientoDetalle in pobjMovimientoEntradaDetalle.AsParallel())
                            {
                                if (movimientoDetalle.d_Precio != null && movimientoDetalle.d_Precio.Value > 0)
                                {
                                    //separo en una lista los articulos que se van a procesar
                                    var listProductos = pobjMovimientoEntradaDetalle.Select(p => p.v_IdProductoDetalle).ToList();

                                    //se arma una temporal de listaspreciodetalle de solo los productos qque se van a procesar de la lista 'listProductos'.
                                    //listapreciosTemp =
                                    //    listapreciosTemp.Where(
                                    //        p =>
                                    //            p.i_Eliminado == 0 &&
                                    //            listProductos.Any(
                                    //                o =>
                                    //                    p.productoalmacen != null &&
                                    //                    p.productoalmacen.productodetalle != null &&
                                    //                    o.Equals(p.productoalmacen.productodetalle.v_IdProductoDetalle)))
                                    //        .ToList();

                                    // se arma una temporal de listaspreciodetalle de solo los productos qque se van a procesar de la lista 'listProductos'.
                                    listapreciosTemp =
                                        listapreciosTemp.Where(
                                            p =>
                                                p.i_Eliminado == 0 &&
                                                listProductos.Any(
                                                    o =>
                                                        o.Equals(p.productodetalle.v_IdProductoDetalle)))
                                            .ToList();




                                    if (!eliminacion)
                                    {
                                        #region Si se trata de un ingreso nuevo o modificado.

                                        var xx = dbContext.movimiento
                                            .Where(p => p.i_IdTipoMovimiento == 1 && p.i_Eliminado == 0 && p.t_Fecha != null
                                                    && !p.v_IdMovimiento.Equals(pobjMovimientoEntrada.v_IdMovimiento) &&
                                                    p.movimientodetalle.Any(o => o.i_Eliminado == 0 && o.v_IdProductoDetalle.Equals(movimientoDetalle.v_IdProductoDetalle)));

                                        var fechaMaximaUltimoReg = xx.Any() ? xx.Max(x => x.t_Fecha.Value) : fechaMovimiento;

                                        if (fechaMaximaUltimoReg <= fechaMovimiento)
                                        {
                                            var productoDetalle = dbContext.productodetalle.FirstOrDefault(p => p.v_IdProductoDetalle.Equals(movimientoDetalle.v_IdProductoDetalle));
                                            if (productoDetalle != null)
                                            {
                                                var producto = productoDetalle.producto;
                                                producto.d_PrecioCosto = movimientoDetalle.d_Precio ?? 0;
                                                dbContext.producto.ApplyCurrentValues(producto);

                                                ActualizarUtilidadPorCosto(ref pobjOperationResult, productoDetalle.v_IdProductoDetalle, producto.d_PrecioCosto.Value, listapreciosTemp, listasActivas);
                                                if (pobjOperationResult.Success == 0) return;
                                            }
                                        }
                                        #endregion
                                    }
                                    else
                                    {
                                        #region Si se trata de un ingreso eliminado
                                        var ultimoMovimientoSegunFecha = dbContext.movimiento.Where(p => p.i_IdTipoMovimiento == 1 && p.i_Eliminado == 0
                                                                                && !p.v_IdMovimiento.Equals(pobjMovimientoEntrada.v_IdMovimiento) && p.movimientodetalle
                                                                            .Any(o => o.i_Eliminado == 0 && o.v_IdProductoDetalle.Equals(movimientoDetalle.v_IdProductoDetalle))).ToList();

                                        if (ultimoMovimientoSegunFecha.Any())
                                        {
                                            var ultimoReg = ultimoMovimientoSegunFecha.Where(p => p.t_Fecha != null).OrderBy(t => t.t_Fecha.Value).LastOrDefault();
                                            var productoDetalle = dbContext.productodetalle.FirstOrDefault(p => p.v_IdProductoDetalle.Equals(movimientoDetalle.v_IdProductoDetalle));
                                            if (productoDetalle != null)
                                            {
                                                var producto = productoDetalle.producto;
                                                producto.d_PrecioCosto = ultimoReg.movimientodetalle.FirstOrDefault(o => o.v_IdProductoDetalle.Equals(movimientoDetalle.v_IdProductoDetalle)).d_Precio ?? 0;
                                                dbContext.producto.ApplyCurrentValues(producto);

                                                ActualizarUtilidadPorCosto(ref pobjOperationResult, productoDetalle.v_IdProductoDetalle, producto.d_PrecioCosto.Value, listapreciosTemp, listasActivas);
                                                if (pobjOperationResult.Success == 0) return;
                                            }
                                        }
                                        else
                                        {
                                            var productoDetalle = dbContext.productodetalle.FirstOrDefault(p => p.v_IdProductoDetalle.Equals(movimientoDetalle.v_IdProductoDetalle));
                                            if (productoDetalle != null)
                                            {
                                                var producto = productoDetalle.producto;
                                                producto.d_PrecioCosto = 0;
                                                dbContext.producto.ApplyCurrentValues(producto);

                                                ActualizarUtilidadPorCosto(ref pobjOperationResult, productoDetalle.v_IdProductoDetalle, producto.d_PrecioCosto.Value, listapreciosTemp, listasActivas);
                                                if (pobjOperationResult.Success == 0) return;
                                            }
                                        }
                                        #endregion
                                    }
                                }
                            }

                            dbContext.SaveChanges();
                            ts.Complete();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                pobjOperationResult.Success = 0;
                pobjOperationResult.AdditionalInformation = "MovimientoBL.ActualizarCostoSegunUltimoMovimiento()";
                pobjOperationResult.ErrorMessage = ex.Message;
                pobjOperationResult.ExceptionMessage = ex.InnerException != null ? ex.InnerException.Message : string.Empty;
                Utils.ExceptionToLog(Globals.ClientSession.i_SystemUserId, pobjOperationResult);
            }
        }

        /// <summary>
        /// Actualiza los % de utilidad de los productos en las listas de precio existentes segun un el costo brindado.
        /// </summary>
        /// <param name="pobjOperationResult"></param>
        /// <param name="pstrProductoDetalleId"></param>
        /// <param name="costo"></param>
        private static void ActualizarUtilidadPorCosto(ref OperationResult pobjOperationResult,
            string pstrProductoDetalleId, decimal costo, List<listapreciodetalle> pTempListaPrecios, List<listaprecio> listasActivas)
        {
            try
            {
                using (var ts = TransactionUtils.CreateTransactionScope())
                {
                    using (var dbContext = new SAMBHSEntitiesModelWin())
                    {
                        foreach (var listaActiva in listasActivas.AsParallel())
                        {
                            var activa = listaActiva;
                            var temp = pTempListaPrecios.AsParallel().Where(p => p.v_IdListaPrecios == activa.v_IdListaPrecios);
                            //var producto = temp.FirstOrDefault(p => p.productoalmacen.i_Eliminado == 0 && p.productoalmacen.v_ProductoDetalleId.Equals(pstrProductoDetalleId));

                            var producto = temp.FirstOrDefault(p => p.productodetalle.i_Eliminado == 0 && p.productodetalle.v_IdProductoDetalle.Equals(pstrProductoDetalleId));

                            if (producto != null)
                            {
                                var precioLista = producto.d_Precio ?? 0;
                                if (costo != 0)
                                    producto.d_Utilidad = (precioLista - costo) / costo * 100;
                                else
                                {
                                    producto.d_Utilidad = 0;
                                    producto.d_Precio = 0;
                                }
                                var tempSource = dbContext.listapreciodetalle.FirstOrDefault(p => p.v_idListaPrecioDetalle == producto.v_idListaPrecioDetalle);

                                if (tempSource != null)
                                {
                                    tempSource.d_Utilidad = producto.d_Utilidad;
                                    tempSource.d_Precio = producto.d_Precio;
                                    dbContext.listapreciodetalle.ApplyCurrentValues(tempSource);
                                }
                            }
                        }

                        dbContext.SaveChanges();
                        pobjOperationResult.Success = 1;
                        ts.Complete();
                    }
                }
            }
            catch (Exception ex)
            {
                pobjOperationResult.Success = 0;
                pobjOperationResult.AdditionalInformation = "MovimientoBL.ActualizarUtilidadPorCosto()";
                pobjOperationResult.ErrorMessage = ex.Message;
                pobjOperationResult.ExceptionMessage = ex.InnerException != null ? ex.InnerException.Message : string.Empty;
                Utils.ExceptionToLog(Globals.ClientSession.i_SystemUserId, pobjOperationResult);
            }
        }
        #endregion

        /// <summary>
        /// Método para corregir los errores de validaciion y distorcion de data de la empresa Chayan
        /// El metodo regenera primero las guias de remision de compras y luego recalcula sus notas de ingreso.
        /// Lo mismo hace para compras.
        /// </summary>
        /// <param name="pobjOperationResult"></param>
        public void RegeneraIngresosSegunCompras(ref OperationResult pobjOperationResult)
        {
            try
            {
                using (var ts = TransactionUtils.CreateTransactionScope())
                {
                    using (var dbContext = new SAMBHSEntitiesModelWin())
                    {
                        var detallesMovimiento = dbContext.movimientodetalle
                                                   .Where(p => p.i_Eliminado == 0 && p.movimiento.i_IdTipoMovimiento == 1);

                        #region Elimina movimientos sin detalle
                        var movimientosSinDetalle =
                            dbContext.movimiento.Where(
                                m =>
                                    m.i_IdTipoMovimiento == 1 &&
                                    !detallesMovimiento.Any(d => d.v_IdMovimiento.Equals(m.v_IdMovimiento)) &&
                                    m.i_Eliminado == 0);

                        if (movimientosSinDetalle.Any())
                        {
                            movimientosSinDetalle.ToList().ForEach(m => dbContext.movimiento.DeleteObject(m));
                            dbContext.SaveChanges();
                        }
                        #endregion

                        #region Regenera Guias de Remision
                        var guiasRemisionCompras = dbContext.guiaremisioncompra.Where(p => p.i_Eliminado == 0);
                        foreach (var guiaCompra in guiasRemisionCompras)
                        {
                            var serieGuia = guiaCompra.v_SerieDocumento.Trim();
                            var correlativoGuia = guiaCompra.v_CorrelativoDocumento.Trim();
                            var movimientoRelacionado =
                                dbContext.movimiento.Where(
                                    p =>
                                        detallesMovimiento.Where(y => y.i_Eliminado == 0
                                            && y.v_IdMovimiento.Equals(p.v_IdMovimiento))
                                            .Any(
                                                o =>
                                                    (o.v_NroGuiaRemision.Equals(serieGuia + " - " + correlativoGuia)
                                                    || o.v_NroGuiaRemision.Equals(serieGuia + "-" + correlativoGuia))
                                                    && o.v_NumeroDocumento.Trim().Equals("")) &&
                                        p.v_OrigenTipo.Equals("G") &&
                                        p.i_IdTipoMovimiento == 1).ToList();

                            if (movimientoRelacionado.Any())
                            {
                                var insertarCabecera = movimientoRelacionado.FirstOrDefault().ToDTO();
                                foreach (var movimiento in movimientoRelacionado)
                                {
                                    EliminarMovimiento(ref pobjOperationResult, movimiento.v_IdMovimiento,
                                        Globals.ClientSession.GetAsList());
                                    if (pobjOperationResult.Success == 0) return;
                                }

                                var detallesGuiaCompra = guiaCompra.guiaremisioncompradetalle.Where(p => p.i_Eliminado == 0).ToList();
                                foreach (var detallesGuia in detallesGuiaCompra.GroupBy(f => f.i_IdAlmacen))
                                {
                                    var movimientoRelacionadoCompra =
                                        dbContext.movimiento.Where(
                                            p =>
                                                detallesMovimiento.Where(y => y.i_Eliminado == 0 &&
                                                    y.v_IdMovimiento.Equals(p.v_IdMovimiento))
                                                .Any(
                                                o =>
                                                    (o.v_NroGuiaRemision.Equals(serieGuia + " - " + correlativoGuia)
                                                    || o.v_NroGuiaRemision.Equals(serieGuia + "-" + correlativoGuia))
                                                    && !o.v_NumeroDocumento.Trim().Equals("")) &&
                                            p.v_OrigenTipo.Equals("C") &&
                                            p.i_IdTipoMovimiento == 1).ToList();

                                    if (!movimientoRelacionadoCompra.Any())
                                    {
                                        insertarCabecera.i_IdAlmacenOrigen = detallesGuia.Key;
                                        var insertarDetalle = detallesGuia.ToList()
                                            .Select(d => new movimientodetalleDto
                                            {
                                                v_IdProductoDetalle = d.v_IdProductoDetalle,
                                                i_IdTipoDocumento = -1,
                                                v_NumeroDocumento = string.Empty,
                                                v_NroGuiaRemision =
                                                    string.Format("{0} - {1}", serieGuia, correlativoGuia),
                                                d_Cantidad = d.d_Cantidad ?? 0,
                                                i_IdUnidad = d.i_IdUnidadMedida ?? -1,
                                                d_CantidadEmpaque = d.d_CantidadEmpaque ?? 0,
                                                d_Precio = d.d_PrecioUnitario ?? 0
                                            }).ToList();
                                        insertarCabecera.d_TotalCantidad = insertarDetalle.Sum(p => p.d_Cantidad ?? 0);
                                        insertarCabecera.d_TotalPrecio = insertarDetalle.Sum(p => p.d_Precio ?? 0);
                                        InsertarMovimiento(ref pobjOperationResult, insertarCabecera,
                                            Globals.ClientSession.GetAsList(), insertarDetalle);
                                        if (pobjOperationResult.Success == 0) return;
                                    }
                                }
                            }
                        }
                        #endregion

                        #region Buscar compras que no existen en los ingresos y las ingresa.
                        var comprasValidas =
                            dbContext.compra.Where(
                                                p =>
                                                    p.compradetalle
                                                    .Any(cd => !cd.v_IdProductoDetalle.Trim().Equals("")
                                                        && cd.i_Eliminado == 0)
                                                        && p.i_Eliminado == 0
                                                        && (!p.v_GuiaRemisionCorrelativo.Trim().Equals("")
                                                        && !p.v_GuiaRemisionSerie.Trim().Equals("")));


                        foreach (var compra in comprasValidas)
                        {
                            var serieCompra = compra.v_SerieDocumento.Trim();
                            var correlativoCompra = compra.v_CorrelativoDocumento.Trim();
                            var detMov = detallesMovimiento.ToList();
                            var detallesPorRegularizar = (from p1 in compra.compradetalle.ToList().AsParallel()
                                                          where
                                                              p1.i_Eliminado == 0 &&
                                                              (p1.v_IdProductoDetalle != null && !p1.v_IdProductoDetalle.Trim().Equals(""))
                                                          let existeEnDetalle =
                                                              detMov
                                                                  .Any(
                                                                      p =>
                                                                          (p.v_NumeroDocumento != null && (p.v_NumeroDocumento.Equals(serieCompra + "-" + correlativoCompra)
                                                                          || p.v_NumeroDocumento.Equals(serieCompra + " - " + correlativoCompra))) &&
                                                                          p.i_IdTipoDocumento.HasValue &&
                                                                          p.i_IdTipoDocumento.Value.Equals(compra.i_IdTipoDocumento ?? -1) &&
                                                                          (p1.v_IdProductoDetalle != null &&
                                                                           p.v_IdProductoDetalle.Equals(p1.v_IdProductoDetalle)))
                                                          where !existeEnDetalle
                                                          select p1).ToList();

                            if (detallesPorRegularizar.Any())
                            {
                                List<KeyValueDTO> ListaMovimientos = new List<KeyValueDTO>();
                                ListaMovimientos = ObtenerListadoMovimientos(ref pobjOperationResult, compra.v_Periodo, compra.v_Mes, (int)TipoDeMovimiento.NotadeSalida);
                                int maxMovimiento = ListaMovimientos.Any() ? int.Parse(ListaMovimientos[ListaMovimientos.Count - 1].Value1) : 0;

                                foreach (var detalle in detallesPorRegularizar.GroupBy(p => p.i_IdAlmacen))
                                {
                                    var movimientoDto = new movimientoDto();
                                    maxMovimiento++;
                                    movimientoDto.d_TipoCambio = compra.d_TipoCambio;
                                    movimientoDto.i_IdAlmacenOrigen = detalle.Key;
                                    movimientoDto.i_IdMoneda = compra.i_IdMoneda;
                                    movimientoDto.i_IdTipoMotivo = 1; //Compra nacional
                                    movimientoDto.t_Fecha = compra.t_FechaRegistro;
                                    movimientoDto.v_Mes = compra.v_Mes.Trim();
                                    movimientoDto.v_Periodo = compra.v_Periodo.Trim();
                                    movimientoDto.i_IdTipoMovimiento = (int)TipoDeMovimiento.NotadeIngreso;
                                    movimientoDto.v_Correlativo = maxMovimiento.ToString("00000000");
                                    movimientoDto.v_IdCliente = compra.v_IdProveedor;
                                    movimientoDto.v_OrigenTipo = "C";
                                    movimientoDto.i_EsDevolucion = 0;
                                    movimientoDto.v_OrigenRegCorrelativo = compra.v_Correlativo;
                                    movimientoDto.v_OrigenRegMes = compra.v_Mes;
                                    movimientoDto.v_OrigenRegPeriodo = compra.v_Periodo;
                                    movimientoDto.d_TotalPrecio = compra.d_Total;
                                    movimientoDto.i_IdEstablecimiento = compra.i_IdEstablecimiento ?? 1;

                                    var movimientosDetalleDto = detalle.ToList()
                                        .Select(d => new movimientodetalleDto
                                        {
                                            v_IdProductoDetalle = d.v_IdProductoDetalle,
                                            i_IdTipoDocumento = compra.i_IdTipoDocumento ?? -1,
                                            v_NumeroDocumento = string.Format("{0}-{1}", serieCompra, correlativoCompra),
                                            v_NroGuiaRemision = d.v_NroGuiaRemision,
                                            d_Cantidad = d.d_Cantidad ?? 0,
                                            i_IdUnidad = d.i_IdUnidadMedida ?? -1,
                                            d_CantidadEmpaque = d.d_CantidadEmpaque ?? 0,
                                            d_Precio = d.d_Precio ?? 0
                                        }).ToList();

                                    movimientoDto.d_TotalCantidad = movimientosDetalleDto.Sum(p => p.d_Cantidad ?? 0);
                                    movimientoDto.d_TotalPrecio = movimientosDetalleDto.Sum(p => p.d_Precio ?? 0);
                                    InsertarMovimiento(ref pobjOperationResult, movimientoDto,
                                        Globals.ClientSession.GetAsList(), movimientosDetalleDto);
                                    if (pobjOperationResult.Success == 0) return;
                                }
                            }
                        }
                        #endregion
                    }
                    pobjOperationResult.Success = 1;
                    ts.Complete();
                }
            }
            catch (Exception ex)
            {
                pobjOperationResult.Success = 0;
                pobjOperationResult.AdditionalInformation = "MovimientoBL.RegeneraIngresosSegunCompras()";
                pobjOperationResult.ErrorMessage = ex.Message;
                pobjOperationResult.ExceptionMessage = ex.InnerException != null ? ex.InnerException.Message : string.Empty;
                Utils.ExceptionToLog(Globals.ClientSession.i_SystemUserId, pobjOperationResult);
            }
        }

        /// <summary>
        ///Este metodo actualiza las Transferencias de Chayna que se generaron mal debido a que los Saldos Iniciales no tiene los costo unitarios correctos 
        /// </summary>
        public void RegenerarTransferencias(ref OperationResult objOperationResult, ref string error, int IdAlmacen, int Mes, bool PorMes)
        {
            try
            {
                objOperationResult.Success = 1;
                MovimientoBL _objMovimientoBL = new MovimientoBL();
                using (TransactionScope ts = TransactionUtils.CreateTransactionScope())
                {
                    using (SAMBHSEntitiesModelWin dbContext = new SAMBHSEntitiesModelWin())
                    {









                        #region RecopilaTodasTransferencias del Periodo
                        var Periodo = Globals.ClientSession.i_Periodo.ToString();
                        var iPeriodo = int.Parse(Periodo);
                        List<movimientoDto> Transferencias = new List<movimientoDto>();
                        if (PorMes)
                        {
                            Transferencias = dbContext.movimiento.Where(x => x.i_IdAlmacenOrigen == IdAlmacen && x.t_Fecha.Value.Year == iPeriodo && x.t_Fecha.Value.Month == Mes && x.i_Eliminado == 0 && x.i_IdTipoMovimiento.Value == (int)TipoDeMovimiento.Transferencia && x.v_Periodo == Periodo).ToList().OrderBy(x => x.t_Fecha).ToDTOs();

                        }
                        else
                        {
                            Transferencias = dbContext.movimiento.Where(x => x.i_IdAlmacenOrigen == IdAlmacen && x.i_Eliminado == 0 && x.i_IdTipoMovimiento.Value == (int)TipoDeMovimiento.Transferencia && x.t_Fecha.Value.Year == iPeriodo).ToList().OrderBy(x => x.t_Fecha).ToDTOs();

                        }
                        Globals.ProgressbarStatus.i_TotalProgress = Transferencias.Count;
                        #endregion
                        #region ActualizaDetallesTransferencias
                        foreach (var transf in Transferencias)
                        {

                            List<movimientodetalleDto> transDetalles = dbContext.movimientodetalle.Where(x => x.v_IdMovimiento.Equals(transf.v_IdMovimiento) && x.i_Eliminado == 0).ToList().ToDTOs();
                            List<movimientodetalleDto> _TempDetalle_AgregarDto = new List<movimientodetalleDto>();
                            List<movimientodetalleDto> _TempDetalle_EliminarDto = new List<movimientodetalleDto>();
                            transf.v_MesGuardado = transf.v_Mes;
                            transf.v_AnioGuardado = transf.v_Periodo;
                            transf.v_CorrelativoGuardado = transf.v_Correlativo;
                            if (transf.v_Mes == "01" && transf.v_Correlativo == "02000007")
                            {
                                string h = "";
                            }
                            _objMovimientoBL.ActualizarMovimiento(ref objOperationResult, transf, Globals.ClientSession.GetAsList(), _TempDetalle_AgregarDto, transDetalles, _TempDetalle_EliminarDto);
                            Globals.ProgressbarStatus.i_Progress++;
                            error = transf.v_Mes + " " + transf.v_Correlativo;

                        }
                        #endregion
                    }
                    ts.Complete();
                }
            }
            catch (Exception ex)
            {
                objOperationResult.Success = 0;
            }

        }

        public string RegenerarTransferencia(ref OperationResult objOperationResult, string pstrIdMovimiento, List<string> ClientSession)
        {
            using (var ts = TransactionUtils.CreateTransactionScope())
            {
                using (SAMBHSEntitiesModelWin dbContext = new SAMBHSEntitiesModelWin())
                {
                    SecuentialBL objSecuentialBL = new SecuentialBL();
                    movimientodetalleDto _movimientodetallenNIDto = new movimientodetalleDto();
                    List<movimientodetalleDto> objEntityMovimientoDetalleNS = new List<movimientodetalleDto>();
                    List<movimientodetalleDto> objEntityMovimientoDetalleNI = new List<movimientodetalleDto>();
                    List<movimientodetalleDto> _movimientodetalleDtos = new List<movimientodetalleDto>();
                    List<KeyValueDTO> ListaMovimientos = new List<KeyValueDTO>();
                    movimientoDto _movimientoCabeceraNIDto = new movimientoDto();
                    movimientoDto _movimientoCabeceraNSDto = new movimientoDto();



                   


                    #region RegenerarTransferencia
                    var pobjDtoEntity = dbContext.movimiento.Where(o => o.i_Eliminado == 0 && o.v_IdMovimiento == pstrIdMovimiento).FirstOrDefault().ToDTO();
                    var DetallesTransferencia = dbContext.movimientodetalle.Where(o => o.v_IdMovimiento == pstrIdMovimiento && o.i_Eliminado == 0).ToList().ToDTOs();
                    
                    var intNodeId = int.Parse(ClientSession[0]);

                    foreach (movimientodetalleDto movimientodetalleDto in DetallesTransferencia)
                    {


                        List<KardexList> StockValorizado = new List<KardexList>();
                        var IdEstablecimiento = BuscarIdEstablecimiento(pobjDtoEntity.i_IdAlmacenDestino.Value).i_IdEstablecimiento;
                        List<string> Filters = new List<string>();
                        string strFilter = "", ListaCodigosProductos = "";
                        Filters.Add("IdAlmacen==" + pobjDtoEntity.i_IdAlmacenOrigen.ToString());
                        var fechaT = pobjDtoEntity.t_Fecha.Value;
                        foreach (var item in DetallesTransferencia)
                        {

                            var CodigoProducto = new ProductoBL().ObtenerProductoDesdeProdDetalle(ref  objOperationResult, item.v_IdProductoDetalle);
                            ListaCodigosProductos = ListaCodigosProductos + "CodProducto==" + "\"" + item.CodigoProducto + "\"" + " || ";
                        }
                        ListaCodigosProductos = ListaCodigosProductos.Substring(0, ListaCodigosProductos.Length - 4);
                        Filters.Add("(" + (ListaCodigosProductos ?? ListaCodigosProductos) + ")");
                        strFilter = string.Join(" && ", Filters);
                        StockValorizado = new AlmacenBL().ReporteStock(ref objOperationResult, IdEstablecimiento, DateTime.Parse("01/01/" + Globals.ClientSession.i_Periodo.ToString()), DateTime.Parse(fechaT.Date.Day.ToString() + "/" + fechaT.Date.Month.ToString() + "/" + fechaT.Date.Year.ToString() + " 23:59"), strFilter, pobjDtoEntity.i_IdMoneda.Value, "", "", "-1", 0, 0, 0, 0, 1, 2, "", DateTime.Now, 0);

                        if (objOperationResult.Success == 0) return null;
                       
                        _movimientodetallenNIDto = new movimientodetalleDto();
                        _movimientodetallenNIDto.v_IdProductoDetalle = movimientodetalleDto.v_IdProductoDetalle.Trim();
                        _movimientodetallenNIDto.i_IdTipoDocumento = movimientodetalleDto.i_IdTipoDocumento;
                        _movimientodetallenNIDto.v_NumeroDocumento = movimientodetalleDto.v_NumeroDocumento;
                        _movimientodetallenNIDto.d_Cantidad = movimientodetalleDto.d_Cantidad;
                        _movimientodetallenNIDto.i_IdUnidad = movimientodetalleDto.i_IdUnidad;
                        //var PrecioAnterioresCompras = BuscarPrecioMovimientos(_movimientodetallenNIDto.v_IdProductoDetalle, pobjDtoEntity.t_Fecha.Value, BuscarIdEstablecimiento(pobjDtoEntity.i_IdAlmacenDestino.Value).i_IdEstablecimiento, pobjDtoEntity.i_IdAlmacenOrigen.Value, pobjDtoEntity.i_IdMoneda.Value);
                       var PrecioAnterioresCompras = BuscarPrecioMovimientosII(_movimientodetallenNIDto.v_IdProductoDetalle, StockValorizado);
                        _movimientodetallenNIDto.d_Precio = Utils.Windows.DevuelveValorRedondeado(PrecioAnterioresCompras, Globals.ClientSession.i_PrecioDecimales.Value);
                        _movimientodetallenNIDto.d_Total = Utils.Windows.DevuelveValorRedondeado(_movimientodetallenNIDto.d_Cantidad.Value * _movimientodetallenNIDto.d_Precio.Value, 2);
                        _movimientodetallenNIDto.v_NroPedido = movimientodetalleDto.v_NroPedido;
                        _movimientodetallenNIDto.v_NroGuiaRemision = movimientodetalleDto.v_NroGuiaRemision;

                        //_movimientodetallenNIDto.v_IdMovimientoDetalleTransferencia = newIdMovimientoDetalle;
                        _movimientodetallenNIDto.v_IdMovimientoDetalleTransferencia = movimientodetalleDto.v_IdMovimientoDetalle;// newIdMovimientoDetalle;
                        _movimientodetallenNIDto.d_CantidadEmpaque = movimientodetalleDto.d_CantidadEmpaque;
                        objEntityMovimientoDetalleNI.Add(_movimientodetallenNIDto);

                        var _movsalida = new movimientodetalleDto();
                        _movsalida = (movimientodetalleDto)_movimientodetallenNIDto.Clone();
                        _movsalida.d_Precio = movimientodetalleDto.d_Precio.Value;
                        _movsalida.d_Total = Utils.Windows.DevuelveValorRedondeado(_movsalida.d_Precio.Value * _movsalida.d_Cantidad.Value, 2);

                        objEntityMovimientoDetalleNS.Add(_movsalida);
                        //}
                        //error = movimientodetalleDto.v_IdProductoDetalle;
                        //i = i + 1;


                    }
                    //if (pobjDtoEntity.i_IdTipoMovimiento == (int)Common.Resource.TipoDeMovimiento.Transferencia)
                    //{
                    #region Inserta CabeceraNotaIngreso
                    _movimientodetalleDtos = new List<movimientodetalleDto>();

                    int MaxMovimiento;
                    if ((DetallesTransferencia.Find(p => p.EsServicio == 0) != null))
                    {
                        ListaMovimientos = new List<KeyValueDTO>();
                        ListaMovimientos = ObtenerListadoMovimientos(ref objOperationResult, pobjDtoEntity.v_Periodo, pobjDtoEntity.v_Mes, (int)TipoDeMovimiento.NotadeIngreso);
                        MaxMovimiento = ListaMovimientos.Any() ? int.Parse(ListaMovimientos[ListaMovimientos.Count() - 1].Value1.ToString()) : 0;
                        _movimientoCabeceraNIDto = new movimientoDto();
                        MaxMovimiento++;
                        _movimientoCabeceraNIDto.d_TipoCambio = pobjDtoEntity.d_TipoCambio;
                        _movimientoCabeceraNIDto.i_IdAlmacenOrigen = pobjDtoEntity.i_IdAlmacenDestino;
                        _movimientoCabeceraNIDto.i_IdMoneda = pobjDtoEntity.i_IdMoneda;
                        _movimientoCabeceraNIDto.i_IdTipoMotivo = 15;//Importación
                        _movimientoCabeceraNIDto.t_Fecha = pobjDtoEntity.t_Fecha;
                        _movimientoCabeceraNIDto.v_Mes = pobjDtoEntity.v_Mes.Trim();
                        _movimientoCabeceraNIDto.v_Periodo = pobjDtoEntity.v_Periodo.Trim();
                        _movimientoCabeceraNIDto.i_IdTipoMovimiento = (int)TipoDeMovimiento.NotadeIngreso;
                        _movimientoCabeceraNIDto.v_Correlativo = MaxMovimiento.ToString("00000000");
                        _movimientoCabeceraNIDto.v_IdCliente = null;
                        _movimientoCabeceraNIDto.v_OrigenTipo = "T";
                        _movimientoCabeceraNIDto.i_EsDevolucion = 0;
                        _movimientoCabeceraNIDto.v_OrigenRegCorrelativo = pobjDtoEntity.v_Correlativo;
                        _movimientoCabeceraNIDto.v_OrigenRegMes = pobjDtoEntity.v_Mes;
                        _movimientoCabeceraNIDto.v_OrigenRegPeriodo = pobjDtoEntity.v_Periodo;
                        _movimientoCabeceraNIDto.d_TotalCantidad = _movimientodetalleDtos.Sum(p => p.d_Cantidad.Value);
                        _movimientoCabeceraNIDto.d_TotalPrecio = _movimientodetalleDtos.Sum(p => p.d_Total.Value);
                        _movimientoCabeceraNIDto.v_IdMovimientoOrigen = pstrIdMovimiento;

                        var NuevoEstablecimiento = BuscarIdEstablecimiento(pobjDtoEntity.i_IdAlmacenDestino.Value);

                        _movimientoCabeceraNIDto.i_IdEstablecimiento = NuevoEstablecimiento.i_IdEstablecimiento;

                        var NuevoEstab = BuscarIdEstablecimiento(pobjDtoEntity.i_IdAlmacenOrigen.Value);
                        _movimientoCabeceraNIDto.v_Glosa = " TRANSFERENCIA DE " + NuevoEstab.NombreAlmacen;

                    }


                    #endregion

                    #region Inserta CabeceraNotaSalida
                    if ((DetallesTransferencia.Find(p => p.EsServicio == 0) != null))
                    {
                        ListaMovimientos = new List<KeyValueDTO>();
                        ListaMovimientos = ObtenerListadoMovimientos(ref objOperationResult, pobjDtoEntity.v_Periodo, pobjDtoEntity.v_Mes, (int)TipoDeMovimiento.NotadeSalida);
                        MaxMovimiento = ListaMovimientos.Any() ? int.Parse(ListaMovimientos[ListaMovimientos.Count() - 1].Value1.ToString()) : 0;
                        _movimientoCabeceraNSDto = new movimientoDto();
                        MaxMovimiento++;
                        _movimientoCabeceraNSDto.d_TipoCambio = pobjDtoEntity.d_TipoCambio;
                        _movimientoCabeceraNSDto.i_IdAlmacenOrigen = pobjDtoEntity.i_IdAlmacenOrigen;
                        _movimientoCabeceraNSDto.i_IdAlmacenDestino = pobjDtoEntity.i_IdAlmacenDestino;
                        _movimientoCabeceraNSDto.i_IdMoneda = pobjDtoEntity.i_IdMoneda;
                        _movimientoCabeceraNSDto.i_IdTipoMotivo = 16;//Compra nacional
                        _movimientoCabeceraNSDto.t_Fecha = pobjDtoEntity.t_Fecha;
                        _movimientoCabeceraNSDto.v_Mes = pobjDtoEntity.v_Mes.Trim();
                        _movimientoCabeceraNSDto.v_Periodo = pobjDtoEntity.v_Periodo.Trim();
                        _movimientoCabeceraNSDto.i_IdTipoMovimiento = (int)TipoDeMovimiento.NotadeSalida;
                        _movimientoCabeceraNSDto.v_Correlativo = MaxMovimiento.ToString("00000000");
                        _movimientoCabeceraNSDto.v_IdCliente = pobjDtoEntity.v_IdCliente;
                        _movimientoCabeceraNSDto.v_OrigenTipo = "T";
                        _movimientoCabeceraNSDto.i_EsDevolucion = 0;
                        _movimientoCabeceraNSDto.v_OrigenRegCorrelativo = pobjDtoEntity.v_Correlativo;
                        _movimientoCabeceraNSDto.v_OrigenRegMes = pobjDtoEntity.v_Mes;
                        _movimientoCabeceraNSDto.v_OrigenRegPeriodo = pobjDtoEntity.v_Periodo;
                        _movimientoCabeceraNSDto.d_TotalPrecio = pobjDtoEntity.d_TotalPrecio;
                        _movimientoCabeceraNSDto.i_IdEstablecimiento = pobjDtoEntity.i_IdEstablecimiento;
                        _movimientoCabeceraNSDto.i_IdTipoDocumento = pobjDtoEntity.i_IdTipoDocumento;
                        _movimientoCabeceraNSDto.v_SerieDocumento = pobjDtoEntity.v_SerieDocumento;
                        _movimientoCabeceraNSDto.v_CorrelativoDocumento = pobjDtoEntity.v_CorrelativoDocumento;
                        _movimientoCabeceraNSDto.v_IdMovimientoOrigen = pstrIdMovimiento;
                        var NuevoEstablecimiento = BuscarIdEstablecimiento(pobjDtoEntity.i_IdAlmacenDestino.Value);
                        _movimientoCabeceraNSDto.v_Glosa = " TRANSFERENCIA A " + NuevoEstablecimiento.NombreAlmacen;

                    }
                    #endregion

                    _movimientoCabeceraNIDto.d_TotalCantidad = objEntityMovimientoDetalleNI.Sum(p => p.d_Cantidad.Value);
                    _movimientoCabeceraNIDto.d_TotalPrecio = objEntityMovimientoDetalleNI.Sum(p => p.d_Total.Value);
                    _movimientoCabeceraNSDto.d_TotalCantidad = objEntityMovimientoDetalleNS.Sum(p => p.d_Cantidad.Value);
                    _movimientoCabeceraNSDto.d_TotalPrecio = objEntityMovimientoDetalleNS.Sum(p => p.d_Total.Value);
                    InsertarMovimiento(ref objOperationResult, _movimientoCabeceraNIDto, Globals.ClientSession.GetAsList(), objEntityMovimientoDetalleNI); //Inserta Nota Ingreso
                    if (objOperationResult.Success == 0) return "";
                    InsertarMovimiento(ref objOperationResult, _movimientoCabeceraNSDto, Globals.ClientSession.GetAsList(), objEntityMovimientoDetalleNS);//Inserta Nota Salida
                    if (objOperationResult.Success == 0) return "";
                    dbContext.SaveChanges();
                    #endregion



                }

                objOperationResult.Success = 1;
                ts.Complete();
                return pstrIdMovimiento;

            }


        }

        public void RegeraTransferenciaMetodo2(ref OperationResult objOperationResult, string pstrPeriodo, List<string> ClientSession)
        {
            try
            {
                objOperationResult.Success = 1;
                MovimientoBL _objMovimientoBL = new MovimientoBL();
                var per = Globals.ClientSession.i_Periodo.ToString();
                using (TransactionScope ts = TransactionUtils.CreateTransactionScope())
                {
                    using (SAMBHSEntitiesModelWin dbContext = new SAMBHSEntitiesModelWin())
                    {


                        #region ReenumeroCorrelativo

                        var listadoTransferencias = dbContext.movimiento.Where(p => p.v_Periodo == pstrPeriodo && p.i_IdTipoMovimiento == 3 && p.i_Eliminado == 0 && p.i_IdAlmacenOrigen == Globals.ClientSession.i_IdAlmacenPredeterminado.Value).ToList().OrderBy(o => o.t_Fecha).ToList();

                        foreach (
                            var operacionesPorMes in
                                listadoTransferencias.GroupBy(
                                    p =>
                                        new
                                        {
                                            mes = p.t_Fecha.Value.Month,
                                            establecimiento = p.v_IdMovimiento.Substring(2, 2)
                                        }))
                        {
                            var counter = 1;

                            var listaOperacionesPorMes = operacionesPorMes.OrderBy(o => o.t_Fecha).ToList();
                            foreach (var operacion in listaOperacionesPorMes)
                            {
                                var idAlmacen = int.Parse(operacion.v_IdMovimiento.Substring(2, 2));
                                var correlativo = idAlmacen.ToString("00") + counter.ToString("000000");
                                var mes = operacion.t_Fecha.Value.Month.ToString("00");



                                var MovIS = ObtenerCabeceraNotaISEmitidasTransferenciaEliminar(ref objOperationResult, operacion.v_IdMovimiento);
                                if (objOperationResult.Success == 0)
                                {
                                    return;
                                }
                                foreach (var Fila in MovIS)
                                {
                                    EliminarMovimiento(ref objOperationResult, Fila, Globals.ClientSession.GetAsList());
                                    if (objOperationResult.Success == 0)
                                        return;
                                }
                                dbContext.SaveChanges();
                                var _movimientos = dbContext.movimiento.Where(p => p.i_Eliminado == 0).ToList();

                                var movimientoRelacionados = _movimientos.Where(
                                        p =>
                                            p.v_OrigenTipo == "T" && p.v_OrigenRegPeriodo == pstrPeriodo &&
                                            p.v_OrigenRegMes.Trim() == operacion.v_Mes.Trim() &&
                                            p.v_OrigenRegCorrelativo == operacion.v_Correlativo && p.i_Eliminado == 0);

                                operacion.v_Mes = mes;
                                operacion.v_Correlativo = correlativo;
                                foreach (var movimientoRelacionado in movimientoRelacionados)
                                {
                                    movimientoRelacionado.v_OrigenRegMes = mes;
                                    movimientoRelacionado.v_OrigenRegCorrelativo = correlativo;
                                    dbContext.movimiento.ApplyCurrentValues(movimientoRelacionado);
                                }

                                counter++;
                            }
                        }

                        dbContext.SaveChanges();
                        #endregion
                        #region RegenerarTransferencias
                        Globals.ProgressbarStatus.i_TotalProgress = listadoTransferencias.Count;

                        foreach (var transf in listadoTransferencias)
                        {
                            RegenerarTransferencia(ref objOperationResult, transf.v_IdMovimiento, ClientSession);
                            Globals.ProgressbarStatus.i_Progress++;
                            if (objOperationResult.Success == 0)
                            {
                                return;
                            }
                        }

                        #endregion

                    }
                    ts.Complete();
                }
            }
            catch (Exception ex)
            {
                objOperationResult.Success = 0;
            }


        }

        public void AsociarIds(ref OperationResult objOperationResult)
        {
            try
            {
                using (var ts = TransactionUtils.CreateTransactionScope())
                {
                    objOperationResult.Success = 1;
                    using (SAMBHSEntitiesModelWin dbContext = new SAMBHSEntitiesModelWin())
                    {
                        var periodo = Globals.ClientSession.i_Periodo.ToString();
                        var Transferencias = dbContext.movimiento.Where(o => o.i_Eliminado == 0 && o.i_IdTipoMovimiento == (int)TipoDeMovimiento.Transferencia && o.v_Periodo == periodo && o.i_IdAlmacenOrigen == Globals.ClientSession.i_IdAlmacenPredeterminado.Value).ToList();
                        var IngresosSalidas = dbContext.movimiento.Where(o => o.i_Eliminado == 0 && o.v_OrigenTipo == "T" && o.v_Periodo == periodo).ToList().OrderBy(o => o.v_Correlativo).ToList();

                        foreach (var transf in Transferencias)
                        {
                            var Ingreso = IngresosSalidas.Where(o => o.v_OrigenTipo == "T" && o.v_OrigenRegMes == transf.v_Mes && o.v_OrigenRegCorrelativo == transf.v_Correlativo && o.v_OrigenRegPeriodo == transf.v_Periodo && o.i_IdTipoMovimiento == (int)TipoDeMovimiento.NotadeIngreso).FirstOrDefault();

                            var Salida = IngresosSalidas.Where(o => o.v_OrigenTipo == "T" && o.v_OrigenRegMes == transf.v_Mes && o.v_OrigenRegCorrelativo == transf.v_Correlativo && o.v_OrigenRegPeriodo == transf.v_Periodo && o.i_IdTipoMovimiento == (int)TipoDeMovimiento.NotadeSalida).FirstOrDefault();


                            Ingreso.v_IdMovimientoOrigen = transf.v_IdMovimiento;
                            Salida.v_IdMovimientoOrigen = transf.v_IdMovimiento;
                            dbContext.movimiento.ApplyCurrentValues(Ingreso);
                            dbContext.movimiento.ApplyCurrentValues(Salida);
                        }

                        dbContext.SaveChanges();


                    }
                    ts.Complete();
                }
            }
            catch (Exception ex)
            {
                objOperationResult.Success = 0;
            }

        }

        public void RegenerarGuiasRemisionDetalles(ref OperationResult objOperationResult)
        {

            try
            {
                using (var ts = TransactionUtils.CreateTransactionScope())
                {
                    using (SAMBHSEntitiesModelWin dbContext = new SAMBHSEntitiesModelWin())
                    {
                        var IngresosSalidasTransferencias = (from a in dbContext.movimientodetalle
                                                             join b in dbContext.movimiento on new { m = a.v_IdMovimiento, eliminado = 0 } equals new { m = b.v_IdMovimiento, eliminado = b.i_Eliminado.Value } into b_join
                                                             from b in b_join.DefaultIfEmpty()
                                                             where (b.i_IdTipoMovimiento == 1 || b.i_IdTipoMovimiento == 2) && b.v_OrigenTipo == "T" && b.i_Eliminado == 0 && a.i_Eliminado == 0
                                                             && (a.i_IdTipoDocumento == -1) && (a.v_NumeroDocumento == null || a.v_NumeroDocumento.Trim() == "")
                                                             && (a.v_NroGuiaRemision != null && a.v_NroGuiaRemision.Trim() != "")
                                                             select a).ToList();

                        foreach (var item in IngresosSalidasTransferencias)
                        {
                            //item.v_NroGuiaRemision.Leng = 8;
                            if (!item.v_NroGuiaRemision.Contains("-"))
                            {
                                item.v_NroGuiaRemision = item.v_NroGuiaRemision.Substring(0, 4) + "-" + item.v_NroGuiaRemision.Substring(4, item.v_NroGuiaRemision.Length - 4);
                                item.i_IdTipoDocumento = 9;
                                item.v_NumeroDocumento = item.v_NroGuiaRemision;
                            }
                            else
                            {
                                item.i_IdTipoDocumento = 9;
                                item.v_NumeroDocumento = item.v_NroGuiaRemision;

                            }
                            dbContext.movimientodetalle.ApplyCurrentValues(item);
                        }


                        var Transferencias = (from a in dbContext.movimientodetalle
                                              join b in dbContext.movimiento on new { m = a.v_IdMovimiento, eliminado = 0 } equals new { m = b.v_IdMovimiento, eliminado = b.i_Eliminado.Value } into b_join
                                              from b in b_join.DefaultIfEmpty()
                                              where (b.i_IdTipoMovimiento == 3) && b.i_Eliminado == 0 && a.i_Eliminado == 0
                                              && (a.i_IdTipoDocumento == 9 || a.i_IdTipoDocumento == -1) && (a.v_NumeroDocumento == null || a.v_NumeroDocumento.Trim() == "")
                                              && (a.v_NroGuiaRemision != null && a.v_NroGuiaRemision.Trim() != "")
                                              select a).ToList();

                        foreach (var item in Transferencias)
                        {
                            //item.v_NroGuiaRemision.Leng = 8;
                            if (!item.v_NroGuiaRemision.Contains("-"))
                            {
                                item.v_NroGuiaRemision = item.v_NroGuiaRemision.Substring(0, 4) + "-" + item.v_NroGuiaRemision.Substring(4, item.v_NroGuiaRemision.Length - 4);
                                item.i_IdTipoDocumento = 9;
                                item.v_NumeroDocumento = item.v_NroGuiaRemision;
                            }
                            else
                            {
                                item.i_IdTipoDocumento = 9;
                                item.v_NumeroDocumento = item.v_NroGuiaRemision;
                            }
                            dbContext.movimientodetalle.ApplyCurrentValues(item);
                        }
                        dbContext.SaveChanges();

                    }
                    ts.Complete();
                    objOperationResult.Success = 1;
                }
            }
            catch (Exception ex)
            {
                objOperationResult.Success = 0;
            }
        }

        public List<ReporteTransferencias> ReporteTransferencias(ref  OperationResult objOperationResult, DateTime FechaInicio, DateTime FechaFin, int Almacen)
        {


            using (SAMBHSEntitiesModelWin dbContext = new SAMBHSEntitiesModelWin())
            {

                List<ReporteTransferencias> ListaFinal = new List<Common.BE.ReporteTransferencias>();
                var IngresosSalidas = (from a in dbContext.movimiento

                                       where (a.i_IdTipoMovimiento == (int)TipoDeMovimiento.NotadeIngreso || a.i_IdTipoMovimiento == (int)TipoDeMovimiento.NotadeSalida) && a.i_Eliminado == 0


                                      && a.t_Fecha >= FechaInicio && a.t_Fecha <= FechaFin && a.v_IdMovimientoOrigen != null
                                       select new ReporteTransferencias
                                       {
                                           IdMovimiento = a.v_IdMovimientoOrigen,
                                           NroTransferencia = a.i_IdTipoMovimiento == 1 ? "N/I : " + a.v_Mes + " - " + a.v_Correlativo : "N/S : " + a.v_Mes + " - " + a.v_Correlativo,
                                           TipoMovimiento = a.i_IdTipoMovimiento.Value,
                                           Key = a.v_IdMovimientoOrigen,
                                       }).ToList();

                var Transferencias = (from a in dbContext.movimiento

                                      where a.i_IdTipoMovimiento == (int)TipoDeMovimiento.Transferencia && a.i_Eliminado == 0

                                     && a.t_Fecha >= FechaInicio && a.t_Fecha <= FechaFin && a.i_IdAlmacenOrigen == Almacen
                                      select new ReporteTransferencias
                                      {
                                          IdMovimiento = a.v_IdMovimiento,
                                          NroTransferencia = "TRANSFERENCIA : " + a.v_Mes + " - " + a.v_Correlativo,
                                          TipoMovimiento = a.i_IdTipoMovimiento.Value,
                                          Key = a.v_IdMovimiento,
                                      }).ToList();

                foreach (var item in Transferencias)
                {
                    var Ingreso = IngresosSalidas.Where(o => o.IdMovimiento == item.IdMovimiento && o.TipoMovimiento == (int)TipoDeMovimiento.NotadeIngreso).ToList();

                    var IdIngresos = Ingreso != null ? string.Join(", ", Ingreso.Select(o => o.NroTransferencia)) : "";
                    item.NroIngreso = IdIngresos;
                    var Salida = IngresosSalidas.Where(o => o.IdMovimiento == item.IdMovimiento && o.TipoMovimiento == (int)TipoDeMovimiento.NotadeSalida).ToList();

                    var IdSalidas = Salida != null ? string.Join(", ", Salida.Select(o => o.NroTransferencia)) : "";
                    item.NroSalida = IdSalidas;
                    ListaFinal.Add(item);
                }

                return ListaFinal.OrderBy(o => o.NroTransferencia).ToList();

            }


        }

    }
}
