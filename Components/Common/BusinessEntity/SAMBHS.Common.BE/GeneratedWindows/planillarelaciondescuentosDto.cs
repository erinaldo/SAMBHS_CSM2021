//-------------------------------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by EntitiesToDTOs.v3.2 (entitiestodtos.codeplex.com).
//     Timestamp: 2017/07/13 - 15:08:03
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
    public partial class planillarelaciondescuentosDto
    {
        [DataMember()]
        public Int32 i_Id { get; set; }

        [DataMember()]
        public String v_Periodo { get; set; }

        [DataMember()]
        public Nullable<Int32> i_IdTipoPlanilla { get; set; }

        [DataMember()]
        public String v_IdConceptoPlanilla { get; set; }

        [DataMember()]
        public String v_NroCuenta { get; set; }

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
        public planillaconceptosDto planillaconceptos { get; set; }

        public planillarelaciondescuentosDto()
        {
        }

        public planillarelaciondescuentosDto(Int32 i_Id, String v_Periodo, Nullable<Int32> i_IdTipoPlanilla, String v_IdConceptoPlanilla, String v_NroCuenta, Nullable<Int32> i_Eliminado, Nullable<Int32> i_InsertaIdUsuario, Nullable<DateTime> t_InsertaFecha, Nullable<Int32> i_ActualizaIdUsuario, Nullable<DateTime> t_ActualizaFecha, planillaconceptosDto planillaconceptos)
        {
			this.i_Id = i_Id;
			this.v_Periodo = v_Periodo;
			this.i_IdTipoPlanilla = i_IdTipoPlanilla;
			this.v_IdConceptoPlanilla = v_IdConceptoPlanilla;
			this.v_NroCuenta = v_NroCuenta;
			this.i_Eliminado = i_Eliminado;
			this.i_InsertaIdUsuario = i_InsertaIdUsuario;
			this.t_InsertaFecha = t_InsertaFecha;
			this.i_ActualizaIdUsuario = i_ActualizaIdUsuario;
			this.t_ActualizaFecha = t_ActualizaFecha;
			this.planillaconceptos = planillaconceptos;
        }
    }
}
