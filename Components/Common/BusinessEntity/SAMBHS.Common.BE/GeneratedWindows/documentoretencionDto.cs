//-------------------------------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by EntitiesToDTOs.v3.2 (entitiestodtos.codeplex.com).
//     Timestamp: 2017/07/13 - 15:08:57
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
    public partial class documentoretencionDto
    {
        [DataMember()]
        public String v_IdDocumentoRetencion { get; set; }

        [DataMember()]
        public String v_IdTesoreria { get; set; }

        [DataMember()]
        public String v_IdCliente { get; set; }

        [DataMember()]
        public Nullable<DateTime> t_FechaRegistro { get; set; }

        [DataMember()]
        public String v_Periodo { get; set; }

        [DataMember()]
        public String v_Mes { get; set; }

        [DataMember()]
        public String v_Correlativo { get; set; }

        [DataMember()]
        public String v_SerieDocumento { get; set; }

        [DataMember()]
        public String v_CorrelativoDocumento { get; set; }

        [DataMember()]
        public Nullable<Decimal> d_TotalRetenido { get; set; }

        [DataMember()]
        public Nullable<Int32> i_Estado { get; set; }

        [DataMember()]
        public Nullable<Int32> i_InsertaIdUsuario { get; set; }

        [DataMember()]
        public Nullable<DateTime> t_InsertaFecha { get; set; }

        [DataMember()]
        public Nullable<Int16> i_EstadoSunat { get; set; }

        [DataMember()]
        public Nullable<Int32> i_Eliminado { get; set; }

        [DataMember()]
        public Nullable<Int32> i_ActualizaUsuario { get; set; }

        [DataMember()]
        public Nullable<DateTime> t_ActualizaFecha { get; set; }

        [DataMember()]
        public Nullable<Int32> i_IdMoneda { get; set; }

        [DataMember()]
        public Nullable<Decimal> d_TipoCambio { get; set; }

        [DataMember()]
        public String v_MotivoEliminacion { get; set; }

        [DataMember()]
        public List<documentoretencionhomologacionDto> documentoretencionhomologacion { get; set; }

        [DataMember()]
        public tesoreriaDto tesoreria { get; set; }

        [DataMember()]
        public List<documentoretenciondetalleDto> documentoretenciondetalle { get; set; }

        public documentoretencionDto()
        {
        }

        public documentoretencionDto(String v_IdDocumentoRetencion, String v_IdTesoreria, String v_IdCliente, Nullable<DateTime> t_FechaRegistro, String v_Periodo, String v_Mes, String v_Correlativo, String v_SerieDocumento, String v_CorrelativoDocumento, Nullable<Decimal> d_TotalRetenido, Nullable<Int32> i_Estado, Nullable<Int32> i_InsertaIdUsuario, Nullable<DateTime> t_InsertaFecha, Nullable<Int16> i_EstadoSunat, Nullable<Int32> i_Eliminado, Nullable<Int32> i_ActualizaUsuario, Nullable<DateTime> t_ActualizaFecha, Nullable<Int32> i_IdMoneda, Nullable<Decimal> d_TipoCambio, String v_MotivoEliminacion, List<documentoretencionhomologacionDto> documentoretencionhomologacion, tesoreriaDto tesoreria, List<documentoretenciondetalleDto> documentoretenciondetalle)
        {
			this.v_IdDocumentoRetencion = v_IdDocumentoRetencion;
			this.v_IdTesoreria = v_IdTesoreria;
			this.v_IdCliente = v_IdCliente;
			this.t_FechaRegistro = t_FechaRegistro;
			this.v_Periodo = v_Periodo;
			this.v_Mes = v_Mes;
			this.v_Correlativo = v_Correlativo;
			this.v_SerieDocumento = v_SerieDocumento;
			this.v_CorrelativoDocumento = v_CorrelativoDocumento;
			this.d_TotalRetenido = d_TotalRetenido;
			this.i_Estado = i_Estado;
			this.i_InsertaIdUsuario = i_InsertaIdUsuario;
			this.t_InsertaFecha = t_InsertaFecha;
			this.i_EstadoSunat = i_EstadoSunat;
			this.i_Eliminado = i_Eliminado;
			this.i_ActualizaUsuario = i_ActualizaUsuario;
			this.t_ActualizaFecha = t_ActualizaFecha;
			this.i_IdMoneda = i_IdMoneda;
			this.d_TipoCambio = d_TipoCambio;
			this.v_MotivoEliminacion = v_MotivoEliminacion;
			this.documentoretencionhomologacion = documentoretencionhomologacion;
			this.tesoreria = tesoreria;
			this.documentoretenciondetalle = documentoretenciondetalle;
        }
    }
}
