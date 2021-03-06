//-------------------------------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by EntitiesToDTOs.v3.2 (entitiestodtos.codeplex.com).
//     Timestamp: 2017/07/13 - 15:10:32
//
//     Changes to this file may cause incorrect behavior and will be lost if the code is regenerated.
// </auto-generated>
//-------------------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace SAMBHS.Common.BE
{
    [DataContract()]
    public partial class liquidacioncompraDto
    {
        [DataMember()]
        public String v_IdLiquidacionCompra { get; set; }

        [DataMember()]
        public String v_Periodo { get; set; }

        [DataMember()]
        public String v_Mes { get; set; }

        [DataMember()]
        public String v_Correlativo { get; set; }

        [DataMember()]
        public Nullable<Int32> i_IdIgv { get; set; }

        [DataMember()]
        public Nullable<Int32> i_IdTipoDocumento { get; set; }

        [DataMember()]
        public String v_SerieDocumento { get; set; }

        [DataMember()]
        public String v_CorrelativoDocumento { get; set; }

        [DataMember()]
        public Nullable<DateTime> t_FechaRegistro { get; set; }

        [DataMember()]
        public Nullable<DateTime> t_FechaEmision { get; set; }

        [DataMember()]
        public Nullable<Decimal> d_TipoCambio { get; set; }

        [DataMember()]
        public String v_IdProveedor { get; set; }

        [DataMember()]
        public Nullable<Int32> i_IdDestino { get; set; }

        [DataMember()]
        public Nullable<Int32> i_IdEstablecimiento { get; set; }

        [DataMember()]
        public String v_Glosa { get; set; }

        [DataMember()]
        public Nullable<Int32> i_IdMoneda { get; set; }

        [DataMember()]
        public Nullable<Int32> i_IdEstado { get; set; }

        [DataMember()]
        public Nullable<Int32> i_EsAfectoIgv { get; set; }

        [DataMember()]
        public Nullable<Int32> i_PreciosIncluyenIgv { get; set; }

        [DataMember()]
        public Nullable<Decimal> d_ValorVenta { get; set; }

        [DataMember()]
        public Nullable<Decimal> d_IGV { get; set; }

        [DataMember()]
        public Nullable<Decimal> d_Total { get; set; }

        [DataMember()]
        public Nullable<Int32> i_Eliminado { get; set; }

        [DataMember()]
        public Nullable<Int32> i_InsertaIdUsuario { get; set; }

        [DataMember()]
        public Nullable<DateTime> t_InsertaFecha { get; set; }

        [DataMember()]
        public Nullable<Int32> i_ActualizaIdUsuario { get; set; }

        [DataMember()]
        public Nullable<DateTime> t_ActualizaFecha { get; set; }

        [DataMember()]
        public clienteDto cliente { get; set; }

        [DataMember()]
        public List<liquidacioncompradetalleDto> liquidacioncompradetalle { get; set; }

        [DataMember()]
        public List<pagopendienteDto> pagopendiente { get; set; }

        public liquidacioncompraDto()
        {
        }

        public liquidacioncompraDto(String v_IdLiquidacionCompra, String v_Periodo, String v_Mes, String v_Correlativo, Nullable<Int32> i_IdIgv, Nullable<Int32> i_IdTipoDocumento, String v_SerieDocumento, String v_CorrelativoDocumento, Nullable<DateTime> t_FechaRegistro, Nullable<DateTime> t_FechaEmision, Nullable<Decimal> d_TipoCambio, String v_IdProveedor, Nullable<Int32> i_IdDestino, Nullable<Int32> i_IdEstablecimiento, String v_Glosa, Nullable<Int32> i_IdMoneda, Nullable<Int32> i_IdEstado, Nullable<Int32> i_EsAfectoIgv, Nullable<Int32> i_PreciosIncluyenIgv, Nullable<Decimal> d_ValorVenta, Nullable<Decimal> d_IGV, Nullable<Decimal> d_Total, Nullable<Int32> i_Eliminado, Nullable<Int32> i_InsertaIdUsuario, Nullable<DateTime> t_InsertaFecha, Nullable<Int32> i_ActualizaIdUsuario, Nullable<DateTime> t_ActualizaFecha, clienteDto cliente, List<liquidacioncompradetalleDto> liquidacioncompradetalle, List<pagopendienteDto> pagopendiente)
        {
			this.v_IdLiquidacionCompra = v_IdLiquidacionCompra;
			this.v_Periodo = v_Periodo;
			this.v_Mes = v_Mes;
			this.v_Correlativo = v_Correlativo;
			this.i_IdIgv = i_IdIgv;
			this.i_IdTipoDocumento = i_IdTipoDocumento;
			this.v_SerieDocumento = v_SerieDocumento;
			this.v_CorrelativoDocumento = v_CorrelativoDocumento;
			this.t_FechaRegistro = t_FechaRegistro;
			this.t_FechaEmision = t_FechaEmision;
			this.d_TipoCambio = d_TipoCambio;
			this.v_IdProveedor = v_IdProveedor;
			this.i_IdDestino = i_IdDestino;
			this.i_IdEstablecimiento = i_IdEstablecimiento;
			this.v_Glosa = v_Glosa;
			this.i_IdMoneda = i_IdMoneda;
			this.i_IdEstado = i_IdEstado;
			this.i_EsAfectoIgv = i_EsAfectoIgv;
			this.i_PreciosIncluyenIgv = i_PreciosIncluyenIgv;
			this.d_ValorVenta = d_ValorVenta;
			this.d_IGV = d_IGV;
			this.d_Total = d_Total;
			this.i_Eliminado = i_Eliminado;
			this.i_InsertaIdUsuario = i_InsertaIdUsuario;
			this.t_InsertaFecha = t_InsertaFecha;
			this.i_ActualizaIdUsuario = i_ActualizaIdUsuario;
			this.t_ActualizaFecha = t_ActualizaFecha;
			this.cliente = cliente;
			this.liquidacioncompradetalle = liquidacioncompradetalle;
			this.pagopendiente = pagopendiente;
        }
    }
}
