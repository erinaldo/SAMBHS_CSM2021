//-------------------------------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by EntitiesToDTOs.v3.3.0.0 (entitiestodtos.codeplex.com).
//     Timestamp: 2017/07/19 - 12:50:45
//
//     Changes to this file may cause incorrect behavior and will be lost if the code is regenerated.
// </auto-generated>
//-------------------------------------------------------------------------------------------------------
using System.Text;
using System.Runtime.Serialization;
using System.Collections.Generic;
using System;

namespace SAMBHS.Common.BE
{
    [DataContract()]
    public partial class guiaremisionDto
    {
        [DataMember()]
        public string v_IdGuiaRemision { get; set; }

        [DataMember()]
        public int? i_IdEstablecimiento { get; set; }

        [DataMember()]
        public string v_IdTransportista { get; set; }

        [DataMember()]
        public string v_IdUnidadTransporte { get; set; }

        [DataMember()]
        public string v_IdChofer { get; set; }

        [DataMember()]
        public string v_IdAgenciaTransporte { get; set; }

        [DataMember()]
        public string v_Periodo { get; set; }

        [DataMember()]
        public string v_Mes { get; set; }

        [DataMember()]
        public string v_Correlativo { get; set; }

        [DataMember()]
        public string v_SerieGuiaRemision { get; set; }

        [DataMember()]
        public string v_NumeroGuiaRemision { get; set; }

        [DataMember()]
        public DateTime? t_FechaEmision { get; set; }

        [DataMember()]
        public decimal? d_TipoCambio { get; set; }

        [DataMember()]
        public DateTime? t_FechaTraslado { get; set; }

        [DataMember()]
        public string v_SerieDocumentoRef { get; set; }

        [DataMember()]
        public string v_NumeroDocumentoRef { get; set; }

        [DataMember()]
        public string v_NumeroPedidoCotizacion { get; set; }

        [DataMember()]
        public int? i_IdEstado { get; set; }

        [DataMember()]
        public string v_PuntoPartida { get; set; }

        [DataMember()]
        public string v_PuntoLLegada { get; set; }

        [DataMember()]
        public int? i_IdMotivoTraslado { get; set; }

        [DataMember()]
        public int? i_IdMoneda { get; set; }

        [DataMember()]
        public decimal? d_Total { get; set; }

        [DataMember()]
        public decimal? d_TotalBultos { get; set; }

        [DataMember()]
        public int? i_IdTipoDocumento { get; set; }

        [DataMember()]
        public string v_IdCliente { get; set; }

        [DataMember()]
        public decimal? d_Redondeo { get; set; }

        [DataMember()]
        public int? i_UsadoEnIngresoAlmacen { get; set; }

        [DataMember()]
        public int? i_Eliminado { get; set; }

        [DataMember()]
        public int? i_InsertaIdUsuario { get; set; }

        [DataMember()]
        public int? i_ActualizaIdUsuario { get; set; }

        [DataMember()]
        public DateTime? t_InsertaFecha { get; set; }

        [DataMember()]
        public DateTime? t_ActualizaFecha { get; set; }

        [DataMember()]
        public int? i_IdTipoGuia { get; set; }

        [DataMember()]
        public int? i_AfectoIgv { get; set; }

        [DataMember()]
        public int? i_PrecionInclIgv { get; set; }

        [DataMember()]
        public int? i_IdIgv { get; set; }

        [DataMember()]
        public int? i_IdAlmacenDestino { get; set; }

        [DataMember()]
        public int? i_IdDireccionCliente { get; set; }

        [DataMember()]
        public string v_UbigueoLlegada { get; set; }

        [DataMember()]
        public decimal? d_TotalPeso { get; set; }

        [DataMember()]
        public short? i_EstadoSunat { get; set; }

        [DataMember()]
        public short? i_Modalidad { get; set; }

        [DataMember()]
        public string v_UbigueoPartida { get; set; }

        [DataMember()]
        public string transportistachofer_v_IdChofer { get; set; }

        [DataMember()]
        public List<int> guiaremisionhomologacion_i_Idhomologacion { get; set; }

        public guiaremisionDto()
        {
        }

        public guiaremisionDto(string v_IdGuiaRemision, int? i_IdEstablecimiento, string v_IdTransportista, string v_IdUnidadTransporte, string v_IdChofer, string v_IdAgenciaTransporte, string v_Periodo, string v_Mes, string v_Correlativo, string v_SerieGuiaRemision, string v_NumeroGuiaRemision, DateTime? t_FechaEmision, decimal? d_TipoCambio, DateTime? t_FechaTraslado, string v_SerieDocumentoRef, string v_NumeroDocumentoRef, string v_NumeroPedidoCotizacion, int? i_IdEstado, string v_PuntoPartida, string v_PuntoLLegada, int? i_IdMotivoTraslado, int? i_IdMoneda, decimal? d_Total, decimal? d_TotalBultos, int? i_IdTipoDocumento, string v_IdCliente, decimal? d_Redondeo, int? i_UsadoEnIngresoAlmacen, int? i_Eliminado, int? i_InsertaIdUsuario, int? i_ActualizaIdUsuario, DateTime? t_InsertaFecha, DateTime? t_ActualizaFecha, int? i_IdTipoGuia, int? i_AfectoIgv, int? i_PrecionInclIgv, int? i_IdIgv, int? i_IdAlmacenDestino, int? i_IdDireccionCliente, string v_UbigueoLlegada, decimal? d_TotalPeso, short? i_EstadoSunat, short? i_Modalidad, string v_UbigueoPartida, string transportistachofer_v_IdChofer, List<int> guiaremisionhomologacion_i_Idhomologacion)
        {
			this.v_IdGuiaRemision = v_IdGuiaRemision;
			this.i_IdEstablecimiento = i_IdEstablecimiento;
			this.v_IdTransportista = v_IdTransportista;
			this.v_IdUnidadTransporte = v_IdUnidadTransporte;
			this.v_IdChofer = v_IdChofer;
			this.v_IdAgenciaTransporte = v_IdAgenciaTransporte;
			this.v_Periodo = v_Periodo;
			this.v_Mes = v_Mes;
			this.v_Correlativo = v_Correlativo;
			this.v_SerieGuiaRemision = v_SerieGuiaRemision;
			this.v_NumeroGuiaRemision = v_NumeroGuiaRemision;
			this.t_FechaEmision = t_FechaEmision;
			this.d_TipoCambio = d_TipoCambio;
			this.t_FechaTraslado = t_FechaTraslado;
			this.v_SerieDocumentoRef = v_SerieDocumentoRef;
			this.v_NumeroDocumentoRef = v_NumeroDocumentoRef;
			this.v_NumeroPedidoCotizacion = v_NumeroPedidoCotizacion;
			this.i_IdEstado = i_IdEstado;
			this.v_PuntoPartida = v_PuntoPartida;
			this.v_PuntoLLegada = v_PuntoLLegada;
			this.i_IdMotivoTraslado = i_IdMotivoTraslado;
			this.i_IdMoneda = i_IdMoneda;
			this.d_Total = d_Total;
			this.d_TotalBultos = d_TotalBultos;
			this.i_IdTipoDocumento = i_IdTipoDocumento;
			this.v_IdCliente = v_IdCliente;
			this.d_Redondeo = d_Redondeo;
			this.i_UsadoEnIngresoAlmacen = i_UsadoEnIngresoAlmacen;
			this.i_Eliminado = i_Eliminado;
			this.i_InsertaIdUsuario = i_InsertaIdUsuario;
			this.i_ActualizaIdUsuario = i_ActualizaIdUsuario;
			this.t_InsertaFecha = t_InsertaFecha;
			this.t_ActualizaFecha = t_ActualizaFecha;
			this.i_IdTipoGuia = i_IdTipoGuia;
			this.i_AfectoIgv = i_AfectoIgv;
			this.i_PrecionInclIgv = i_PrecionInclIgv;
			this.i_IdIgv = i_IdIgv;
			this.i_IdAlmacenDestino = i_IdAlmacenDestino;
			this.i_IdDireccionCliente = i_IdDireccionCliente;
			this.v_UbigueoLlegada = v_UbigueoLlegada;
			this.d_TotalPeso = d_TotalPeso;
			this.i_EstadoSunat = i_EstadoSunat;
			this.i_Modalidad = i_Modalidad;
			this.v_UbigueoPartida = v_UbigueoPartida;
			this.transportistachofer_v_IdChofer = transportistachofer_v_IdChofer;
			this.guiaremisionhomologacion_i_Idhomologacion = guiaremisionhomologacion_i_Idhomologacion;
        }
    }
}