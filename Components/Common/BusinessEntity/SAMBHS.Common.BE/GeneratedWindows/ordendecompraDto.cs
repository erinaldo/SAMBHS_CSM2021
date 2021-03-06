//-------------------------------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by EntitiesToDTOs.v3.1 (entitiestodtos.codeplex.com).
//     Timestamp: 2017/09/22 - 11:53:26
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
    public partial class ordendecompraDto
    {
        [DataMember()]
        public String v_IdOrdenCompra { get; set; }

        [DataMember()]
        public String v_Periodo { get; set; }

        [DataMember()]
        public String v_Mes { get; set; }

        [DataMember()]
        public String v_Correlativo { get; set; }

        [DataMember()]
        public Nullable<Int32> i_IdTipoDocumento { get; set; }

        [DataMember()]
        public String v_SerieDocumento { get; set; }

        [DataMember()]
        public String v_CorrelativoDocumento { get; set; }

        [DataMember()]
        public String v_DocumentoInterno { get; set; }

        [DataMember()]
        public Nullable<DateTime> t_FechaRegistro { get; set; }

        [DataMember()]
        public String v_IdProveedor { get; set; }

        [DataMember()]
        public Nullable<Int32> i_PreciosAfectosIgv { get; set; }

        [DataMember()]
        public Nullable<Int32> i_PreciosIncluyeIgv { get; set; }

        [DataMember()]
        public Nullable<Int32> i_IdIgv { get; set; }

        [DataMember()]
        public Nullable<Int32> i_NodeId { get; set; }

        [DataMember()]
        public Nullable<Int32> i_IdAreaSolicita { get; set; }

        [DataMember()]
        public Nullable<Int32> i_IdFormaPago { get; set; }

        [DataMember()]
        public Nullable<Int32> i_IdEntidadBancaria { get; set; }

        [DataMember()]
        public Nullable<Int32> i_NroDias { get; set; }

        [DataMember()]
        public String v_NroCheque { get; set; }

        [DataMember()]
        public Nullable<Int32> i_IdMoneda { get; set; }

        [DataMember()]
        public Nullable<DateTime> t_FechaEntrega { get; set; }

        [DataMember()]
        public Nullable<Decimal> d_TipoCambio { get; set; }

        [DataMember()]
        public Nullable<Int32> i_IdEstado { get; set; }

        [DataMember()]
        public Nullable<Decimal> d_SubTotal { get; set; }

        [DataMember()]
        public Nullable<Decimal> d_IGV { get; set; }

        [DataMember()]
        public Nullable<Decimal> d_Total { get; set; }

        [DataMember()]
        public String v_AdjuntarAnexo { get; set; }

        [DataMember()]
        public String v_Importante { get; set; }

        [DataMember()]
        public String v_LugarEntrega { get; set; }

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
        public Nullable<Int32> i_IdTipoOrdenCompra { get; set; }

        public ordendecompraDto()
        {
        }

        public ordendecompraDto(String v_IdOrdenCompra, String v_Periodo, String v_Mes, String v_Correlativo, Nullable<Int32> i_IdTipoDocumento, String v_SerieDocumento, String v_CorrelativoDocumento, String v_DocumentoInterno, Nullable<DateTime> t_FechaRegistro, String v_IdProveedor, Nullable<Int32> i_PreciosAfectosIgv, Nullable<Int32> i_PreciosIncluyeIgv, Nullable<Int32> i_IdIgv, Nullable<Int32> i_NodeId, Nullable<Int32> i_IdAreaSolicita, Nullable<Int32> i_IdFormaPago, Nullable<Int32> i_IdEntidadBancaria, Nullable<Int32> i_NroDias, String v_NroCheque, Nullable<Int32> i_IdMoneda, Nullable<DateTime> t_FechaEntrega, Nullable<Decimal> d_TipoCambio, Nullable<Int32> i_IdEstado, Nullable<Decimal> d_SubTotal, Nullable<Decimal> d_IGV, Nullable<Decimal> d_Total, String v_AdjuntarAnexo, String v_Importante, String v_LugarEntrega, Nullable<Int32> i_Eliminado, Nullable<Int32> i_InsertaIdUsuario, Nullable<DateTime> t_InsertaFecha, Nullable<Int32> i_ActualizaIdUsuario, Nullable<DateTime> t_ActualizaFecha, Nullable<Int32> i_IdTipoOrdenCompra)
        {
			this.v_IdOrdenCompra = v_IdOrdenCompra;
			this.v_Periodo = v_Periodo;
			this.v_Mes = v_Mes;
			this.v_Correlativo = v_Correlativo;
			this.i_IdTipoDocumento = i_IdTipoDocumento;
			this.v_SerieDocumento = v_SerieDocumento;
			this.v_CorrelativoDocumento = v_CorrelativoDocumento;
			this.v_DocumentoInterno = v_DocumentoInterno;
			this.t_FechaRegistro = t_FechaRegistro;
			this.v_IdProveedor = v_IdProveedor;
			this.i_PreciosAfectosIgv = i_PreciosAfectosIgv;
			this.i_PreciosIncluyeIgv = i_PreciosIncluyeIgv;
			this.i_IdIgv = i_IdIgv;
			this.i_NodeId = i_NodeId;
			this.i_IdAreaSolicita = i_IdAreaSolicita;
			this.i_IdFormaPago = i_IdFormaPago;
			this.i_IdEntidadBancaria = i_IdEntidadBancaria;
			this.i_NroDias = i_NroDias;
			this.v_NroCheque = v_NroCheque;
			this.i_IdMoneda = i_IdMoneda;
			this.t_FechaEntrega = t_FechaEntrega;
			this.d_TipoCambio = d_TipoCambio;
			this.i_IdEstado = i_IdEstado;
			this.d_SubTotal = d_SubTotal;
			this.d_IGV = d_IGV;
			this.d_Total = d_Total;
			this.v_AdjuntarAnexo = v_AdjuntarAnexo;
			this.v_Importante = v_Importante;
			this.v_LugarEntrega = v_LugarEntrega;
			this.i_Eliminado = i_Eliminado;
			this.i_InsertaIdUsuario = i_InsertaIdUsuario;
			this.t_InsertaFecha = t_InsertaFecha;
			this.i_ActualizaIdUsuario = i_ActualizaIdUsuario;
			this.t_ActualizaFecha = t_ActualizaFecha;
			this.i_IdTipoOrdenCompra = i_IdTipoOrdenCompra;
        }
    }
}
