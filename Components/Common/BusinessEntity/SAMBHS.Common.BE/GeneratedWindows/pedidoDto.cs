//-------------------------------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by EntitiesToDTOs.v3.1 (entitiestodtos.codeplex.com).
//     Timestamp: 2017/09/04 - 15:38:52
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
    public partial class pedidoDto
    {
        [DataMember()]
        public String v_IdPedido { get; set; }

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
        public Nullable<DateTime> t_FechaEmision { get; set; }

        [DataMember()]
        public Nullable<Int32> i_DiasVigencia { get; set; }

        [DataMember()]
        public Nullable<DateTime> t_FechaVencimiento { get; set; }

        [DataMember()]
        public Nullable<Decimal> d_TipoCambio { get; set; }

        [DataMember()]
        public String v_IdCliente { get; set; }

        [DataMember()]
        public Nullable<Int32> i_IdCondicionPago { get; set; }

        [DataMember()]
        public String v_Glosa { get; set; }

        [DataMember()]
        public Nullable<Int32> i_IdMoneda { get; set; }

        [DataMember()]
        public Nullable<Int32> i_IdEstado { get; set; }

        [DataMember()]
        public Nullable<Int32> i_IdEstablecimiento { get; set; }

        [DataMember()]
        public Nullable<Int32> i_AfectoIgv { get; set; }

        [DataMember()]
        public Nullable<Int32> i_PrecionInclIgv { get; set; }

        [DataMember()]
        public Nullable<Decimal> d_Dscto { get; set; }

        [DataMember()]
        public String v_IdVendedor { get; set; }

        [DataMember()]
        public Nullable<Decimal> d_Valor { get; set; }

        [DataMember()]
        public Nullable<Decimal> d_VVenta { get; set; }

        [DataMember()]
        public Nullable<Decimal> d_Descuento { get; set; }

        [DataMember()]
        public Nullable<Int32> i_IdIgv { get; set; }

        [DataMember()]
        public Nullable<Decimal> d_CantidadTotal { get; set; }

        [DataMember()]
        public Nullable<Decimal> d_PrecioVenta { get; set; }

        [DataMember()]
        public String v_NombreClienteTemporal { get; set; }

        [DataMember()]
        public String v_DireccionClienteTemporal { get; set; }

        [DataMember()]
        public Nullable<Decimal> d_Igv { get; set; }

        [DataMember()]
        public Nullable<Int32> i_Eliminado { get; set; }

        [DataMember()]
        public Nullable<Int32> i_InsertaUsuario { get; set; }

        [DataMember()]
        public Nullable<DateTime> t_InsertaFecha { get; set; }

        [DataMember()]
        public Nullable<Int32> i_ActualizaIdUsuario { get; set; }

        [DataMember()]
        public Nullable<DateTime> t_ActualizaFecha { get; set; }

        [DataMember()]
        public String v_IdVendedorRef { get; set; }

        [DataMember()]
        public Nullable<DateTime> t_FechaDespacho { get; set; }

        [DataMember()]
        public String v_IdAgenciaTransporte { get; set; }

        [DataMember()]
        public Int32 i_IdTipoOperacion { get; set; }

        [DataMember()]
        public Nullable<Int32> i_IdDireccionCliente { get; set; }

        [DataMember()]
        public Nullable<Int32> i_IdTipoVerificacion { get; set; }

        [DataMember()]
        public String v_MotivoEliminacion { get; set; }

        public pedidoDto()
        {
        }

        public pedidoDto(String v_IdPedido, String v_Periodo, String v_Mes, String v_Correlativo, Nullable<Int32> i_IdTipoDocumento, String v_SerieDocumento, String v_CorrelativoDocumento, Nullable<DateTime> t_FechaEmision, Nullable<Int32> i_DiasVigencia, Nullable<DateTime> t_FechaVencimiento, Nullable<Decimal> d_TipoCambio, String v_IdCliente, Nullable<Int32> i_IdCondicionPago, String v_Glosa, Nullable<Int32> i_IdMoneda, Nullable<Int32> i_IdEstado, Nullable<Int32> i_IdEstablecimiento, Nullable<Int32> i_AfectoIgv, Nullable<Int32> i_PrecionInclIgv, Nullable<Decimal> d_Dscto, String v_IdVendedor, Nullable<Decimal> d_Valor, Nullable<Decimal> d_VVenta, Nullable<Decimal> d_Descuento, Nullable<Int32> i_IdIgv, Nullable<Decimal> d_CantidadTotal, Nullable<Decimal> d_PrecioVenta, String v_NombreClienteTemporal, String v_DireccionClienteTemporal, Nullable<Decimal> d_Igv, Nullable<Int32> i_Eliminado, Nullable<Int32> i_InsertaUsuario, Nullable<DateTime> t_InsertaFecha, Nullable<Int32> i_ActualizaIdUsuario, Nullable<DateTime> t_ActualizaFecha, String v_IdVendedorRef, Nullable<DateTime> t_FechaDespacho, String v_IdAgenciaTransporte, Int32 i_IdTipoOperacion, Nullable<Int32> i_IdDireccionCliente, Nullable<Int32> i_IdTipoVerificacion, String v_MotivoEliminacion)
        {
			this.v_IdPedido = v_IdPedido;
			this.v_Periodo = v_Periodo;
			this.v_Mes = v_Mes;
			this.v_Correlativo = v_Correlativo;
			this.i_IdTipoDocumento = i_IdTipoDocumento;
			this.v_SerieDocumento = v_SerieDocumento;
			this.v_CorrelativoDocumento = v_CorrelativoDocumento;
			this.t_FechaEmision = t_FechaEmision;
			this.i_DiasVigencia = i_DiasVigencia;
			this.t_FechaVencimiento = t_FechaVencimiento;
			this.d_TipoCambio = d_TipoCambio;
			this.v_IdCliente = v_IdCliente;
			this.i_IdCondicionPago = i_IdCondicionPago;
			this.v_Glosa = v_Glosa;
			this.i_IdMoneda = i_IdMoneda;
			this.i_IdEstado = i_IdEstado;
			this.i_IdEstablecimiento = i_IdEstablecimiento;
			this.i_AfectoIgv = i_AfectoIgv;
			this.i_PrecionInclIgv = i_PrecionInclIgv;
			this.d_Dscto = d_Dscto;
			this.v_IdVendedor = v_IdVendedor;
			this.d_Valor = d_Valor;
			this.d_VVenta = d_VVenta;
			this.d_Descuento = d_Descuento;
			this.i_IdIgv = i_IdIgv;
			this.d_CantidadTotal = d_CantidadTotal;
			this.d_PrecioVenta = d_PrecioVenta;
			this.v_NombreClienteTemporal = v_NombreClienteTemporal;
			this.v_DireccionClienteTemporal = v_DireccionClienteTemporal;
			this.d_Igv = d_Igv;
			this.i_Eliminado = i_Eliminado;
			this.i_InsertaUsuario = i_InsertaUsuario;
			this.t_InsertaFecha = t_InsertaFecha;
			this.i_ActualizaIdUsuario = i_ActualizaIdUsuario;
			this.t_ActualizaFecha = t_ActualizaFecha;
			this.v_IdVendedorRef = v_IdVendedorRef;
			this.t_FechaDespacho = t_FechaDespacho;
			this.v_IdAgenciaTransporte = v_IdAgenciaTransporte;
			this.i_IdTipoOperacion = i_IdTipoOperacion;
			this.i_IdDireccionCliente = i_IdDireccionCliente;
			this.i_IdTipoVerificacion = i_IdTipoVerificacion;
			this.v_MotivoEliminacion = v_MotivoEliminacion;
        }
    }
}
