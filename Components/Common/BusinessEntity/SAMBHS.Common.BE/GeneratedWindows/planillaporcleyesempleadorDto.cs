//-------------------------------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by EntitiesToDTOs.v3.2 (entitiestodtos.codeplex.com).
//     Timestamp: 2017/07/13 - 15:07:53
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
    public partial class planillaporcleyesempleadorDto
    {
        [DataMember()]
        public Int32 i_Id { get; set; }

        [DataMember()]
        public String v_Periodo { get; set; }

        [DataMember()]
        public String v_Mes { get; set; }

        [DataMember()]
        public Nullable<Decimal> d_EsSalud { get; set; }

        [DataMember()]
        public Nullable<Decimal> d_Senati { get; set; }

        [DataMember()]
        public Nullable<Decimal> d_SCTR { get; set; }

        [DataMember()]
        public Nullable<Decimal> d_SCTRPen { get; set; }

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

        public planillaporcleyesempleadorDto()
        {
        }

        public planillaporcleyesempleadorDto(Int32 i_Id, String v_Periodo, String v_Mes, Nullable<Decimal> d_EsSalud, Nullable<Decimal> d_Senati, Nullable<Decimal> d_SCTR, Nullable<Decimal> d_SCTRPen, Nullable<Int32> i_Eliminado, Nullable<Int32> i_InsertaIdUsuario, Nullable<DateTime> t_InsertaFecha, Nullable<Int32> i_ActualizaIdUsuario, Nullable<DateTime> t_ActualizaFecha)
        {
			this.i_Id = i_Id;
			this.v_Periodo = v_Periodo;
			this.v_Mes = v_Mes;
			this.d_EsSalud = d_EsSalud;
			this.d_Senati = d_Senati;
			this.d_SCTR = d_SCTR;
			this.d_SCTRPen = d_SCTRPen;
			this.i_Eliminado = i_Eliminado;
			this.i_InsertaIdUsuario = i_InsertaIdUsuario;
			this.t_InsertaFecha = t_InsertaFecha;
			this.i_ActualizaIdUsuario = i_ActualizaIdUsuario;
			this.t_ActualizaFecha = t_ActualizaFecha;
        }
    }
}
