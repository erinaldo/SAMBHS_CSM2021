//-------------------------------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by EntitiesToDTOs.v3.2 (entitiestodtos.codeplex.com).
//     Timestamp: 2017/07/13 - 15:09:47
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
    public partial class importaciondetallefobDto
    {
        [DataMember()]
        public String v_IdImportacionDetalleFob { get; set; }

        [DataMember()]
        public String v_IdImportacion { get; set; }

        [DataMember()]
        public String v_IdCliente { get; set; }

        [DataMember()]
        public Nullable<Int32> i_IdTipoDocumento { get; set; }

        [DataMember()]
        public String v_SerieDocumento { get; set; }

        [DataMember()]
        public String v_CorrelativoDocumento { get; set; }

        [DataMember()]
        public Nullable<DateTime> t_FechaEmision { get; set; }

        [DataMember()]
        public Nullable<Decimal> d_TipoCambio { get; set; }

        [DataMember()]
        public Nullable<Decimal> d_ValorFob { get; set; }

        [DataMember()]
        public String v_NroPedido { get; set; }

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
        public importacionDto importacion { get; set; }

        public importaciondetallefobDto()
        {
        }

        public importaciondetallefobDto(String v_IdImportacionDetalleFob, String v_IdImportacion, String v_IdCliente, Nullable<Int32> i_IdTipoDocumento, String v_SerieDocumento, String v_CorrelativoDocumento, Nullable<DateTime> t_FechaEmision, Nullable<Decimal> d_TipoCambio, Nullable<Decimal> d_ValorFob, String v_NroPedido, Nullable<Int32> i_Eliminado, Nullable<Int32> i_InsertaIdUsuario, Nullable<DateTime> t_InsertaFecha, Nullable<Int32> i_ActualizaIdUsuario, Nullable<DateTime> t_ActualizaFecha, importacionDto importacion)
        {
			this.v_IdImportacionDetalleFob = v_IdImportacionDetalleFob;
			this.v_IdImportacion = v_IdImportacion;
			this.v_IdCliente = v_IdCliente;
			this.i_IdTipoDocumento = i_IdTipoDocumento;
			this.v_SerieDocumento = v_SerieDocumento;
			this.v_CorrelativoDocumento = v_CorrelativoDocumento;
			this.t_FechaEmision = t_FechaEmision;
			this.d_TipoCambio = d_TipoCambio;
			this.d_ValorFob = d_ValorFob;
			this.v_NroPedido = v_NroPedido;
			this.i_Eliminado = i_Eliminado;
			this.i_InsertaIdUsuario = i_InsertaIdUsuario;
			this.t_InsertaFecha = t_InsertaFecha;
			this.i_ActualizaIdUsuario = i_ActualizaIdUsuario;
			this.t_ActualizaFecha = t_ActualizaFecha;
			this.importacion = importacion;
        }
    }
}
