//-------------------------------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by EntitiesToDTOs.v3.2 (entitiestodtos.codeplex.com).
//     Timestamp: 2017/07/13 - 15:07:44
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
    public partial class planillaafechrsexttardDto
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
        public Nullable<Int32> i_HorasExtras { get; set; }

        [DataMember()]
        public Nullable<Int32> i_Tardanza { get; set; }

        [DataMember()]
        public Nullable<Int32> i_Eliminado { get; set; }

        [DataMember()]
        public Nullable<DateTime> t_InsertaFecha { get; set; }

        [DataMember()]
        public Nullable<Int32> i_InsertaIdUsuario { get; set; }

        [DataMember()]
        public Nullable<DateTime> t_ActualizaFecha { get; set; }

        [DataMember()]
        public Nullable<Int32> i_ActualizaIdUsuario { get; set; }

        public planillaafechrsexttardDto()
        {
        }

        public planillaafechrsexttardDto(Int32 i_Id, String v_Periodo, String v_Mes, String v_IdConceptoPlanilla, Nullable<Int32> i_HorasExtras, Nullable<Int32> i_Tardanza, Nullable<Int32> i_Eliminado, Nullable<DateTime> t_InsertaFecha, Nullable<Int32> i_InsertaIdUsuario, Nullable<DateTime> t_ActualizaFecha, Nullable<Int32> i_ActualizaIdUsuario)
        {
			this.i_Id = i_Id;
			this.v_Periodo = v_Periodo;
			this.v_Mes = v_Mes;
			this.v_IdConceptoPlanilla = v_IdConceptoPlanilla;
			this.i_HorasExtras = i_HorasExtras;
			this.i_Tardanza = i_Tardanza;
			this.i_Eliminado = i_Eliminado;
			this.t_InsertaFecha = t_InsertaFecha;
			this.i_InsertaIdUsuario = i_InsertaIdUsuario;
			this.t_ActualizaFecha = t_ActualizaFecha;
			this.i_ActualizaIdUsuario = i_ActualizaIdUsuario;
        }
    }
}
