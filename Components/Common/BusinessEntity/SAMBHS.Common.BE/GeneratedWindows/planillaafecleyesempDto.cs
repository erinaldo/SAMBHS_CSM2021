//-------------------------------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by EntitiesToDTOs.v3.2 (entitiestodtos.codeplex.com).
//     Timestamp: 2017/07/13 - 15:07:45
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
    public partial class planillaafecleyesempDto
    {
        [DataMember()]
        public Int32 i_Id { get; set; }

        [DataMember()]
        public String v_Periodo { get; set; }

        [DataMember()]
        public String v_Mes { get; set; }

        [DataMember()]
        public String v_IdConceptoPlanilla { get; set; }

        [DataMember()]
        public Nullable<Int32> i_SeguroPensiones { get; set; }

        [DataMember()]
        public Nullable<Int32> i_Essalud { get; set; }

        [DataMember()]
        public Nullable<Int32> i_SNT { get; set; }

        [DataMember()]
        public Nullable<Int32> i_SCTR { get; set; }

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

        public planillaafecleyesempDto()
        {
        }

        public planillaafecleyesempDto(Int32 i_Id, String v_Periodo, String v_Mes, String v_IdConceptoPlanilla, Nullable<Int32> i_SeguroPensiones, Nullable<Int32> i_Essalud, Nullable<Int32> i_SNT, Nullable<Int32> i_SCTR, Nullable<Int32> i_Eliminado, Nullable<Int32> i_InsertaIdUsuario, Nullable<DateTime> t_InsertaFecha, Nullable<Int32> i_ActualizaIdUsuario, Nullable<DateTime> t_ActualizaFecha)
        {
			this.i_Id = i_Id;
			this.v_Periodo = v_Periodo;
			this.v_Mes = v_Mes;
			this.v_IdConceptoPlanilla = v_IdConceptoPlanilla;
			this.i_SeguroPensiones = i_SeguroPensiones;
			this.i_Essalud = i_Essalud;
			this.i_SNT = i_SNT;
			this.i_SCTR = i_SCTR;
			this.i_Eliminado = i_Eliminado;
			this.i_InsertaIdUsuario = i_InsertaIdUsuario;
			this.t_InsertaFecha = t_InsertaFecha;
			this.i_ActualizaIdUsuario = i_ActualizaIdUsuario;
			this.t_ActualizaFecha = t_ActualizaFecha;
        }
    }
}
