//-------------------------------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by EntitiesToDTOs.v3.2 (entitiestodtos.codeplex.com).
//     Timestamp: 2017/07/13 - 15:11:26
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
    public partial class planillavariablesdescuentosDto
    {
        [DataMember()]
        public String v_IdPlanillaVariablesDescuentos { get; set; }

        [DataMember()]
        public String v_IdPlanillaVariablesTrabajador { get; set; }

        [DataMember()]
        public String v_IdConceptoPlanilla { get; set; }

        [DataMember()]
        public Nullable<Decimal> d_Importe { get; set; }

        [DataMember()]
        public Nullable<Int32> i_IdMoneda { get; set; }

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
        public planillavariablestrabajadorDto planillavariablestrabajador { get; set; }

        public planillavariablesdescuentosDto()
        {
        }

        public planillavariablesdescuentosDto(String v_IdPlanillaVariablesDescuentos, String v_IdPlanillaVariablesTrabajador, String v_IdConceptoPlanilla, Nullable<Decimal> d_Importe, Nullable<Int32> i_IdMoneda, Nullable<Int32> i_Eliminado, Nullable<Int32> i_InsertaIdUsuario, Nullable<DateTime> t_InsertaFecha, Nullable<Int32> i_ActualizaIdUsuario, Nullable<DateTime> t_ActualizaFecha, planillavariablestrabajadorDto planillavariablestrabajador)
        {
			this.v_IdPlanillaVariablesDescuentos = v_IdPlanillaVariablesDescuentos;
			this.v_IdPlanillaVariablesTrabajador = v_IdPlanillaVariablesTrabajador;
			this.v_IdConceptoPlanilla = v_IdConceptoPlanilla;
			this.d_Importe = d_Importe;
			this.i_IdMoneda = i_IdMoneda;
			this.i_Eliminado = i_Eliminado;
			this.i_InsertaIdUsuario = i_InsertaIdUsuario;
			this.t_InsertaFecha = t_InsertaFecha;
			this.i_ActualizaIdUsuario = i_ActualizaIdUsuario;
			this.t_ActualizaFecha = t_ActualizaFecha;
			this.planillavariablestrabajador = planillavariablestrabajador;
        }
    }
}
