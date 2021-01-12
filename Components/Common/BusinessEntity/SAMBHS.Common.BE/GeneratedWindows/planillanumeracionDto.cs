//-------------------------------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by EntitiesToDTOs.v3.2 (entitiestodtos.codeplex.com).
//     Timestamp: 2017/07/13 - 15:11:34
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
    public partial class planillanumeracionDto
    {
        [DataMember()]
        public Int32 i_Id { get; set; }

        [DataMember()]
        public String v_Numero { get; set; }

        [DataMember()]
        public String v_Periodo { get; set; }

        [DataMember()]
        public String v_Mes { get; set; }

        [DataMember()]
        public String v_Observaciones { get; set; }

        [DataMember()]
        public Nullable<Int32> i_IdTipoPlanilla { get; set; }

        [DataMember()]
        public Nullable<Decimal> d_TipoCambio { get; set; }

        [DataMember()]
        public Nullable<Decimal> d_SueldoMinimo { get; set; }

        [DataMember()]
        public Nullable<Int32> i_Remuneraciones { get; set; }

        [DataMember()]
        public Nullable<Int32> i_Gratificaciones { get; set; }

        [DataMember()]
        public Nullable<Int32> i_Vacaciones { get; set; }

        [DataMember()]
        public Nullable<DateTime> t_FechaInicio { get; set; }

        [DataMember()]
        public Nullable<DateTime> t_FechaTermino { get; set; }

        [DataMember()]
        public Nullable<Int32> i_PlanillaCerrada { get; set; }

        [DataMember()]
        public Nullable<Int32> i_NoAplicaDctoLeyAFP { get; set; }

        [DataMember()]
        public Nullable<Int32> i_NoAplicaSNPAFP { get; set; }

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
        public List<planillacalculoDto> planillacalculo { get; set; }

        [DataMember()]
        public List<planillavariablestrabajadorDto> planillavariablestrabajador { get; set; }

        public planillanumeracionDto()
        {
        }

        public planillanumeracionDto(Int32 i_Id, String v_Numero, String v_Periodo, String v_Mes, String v_Observaciones, Nullable<Int32> i_IdTipoPlanilla, Nullable<Decimal> d_TipoCambio, Nullable<Decimal> d_SueldoMinimo, Nullable<Int32> i_Remuneraciones, Nullable<Int32> i_Gratificaciones, Nullable<Int32> i_Vacaciones, Nullable<DateTime> t_FechaInicio, Nullable<DateTime> t_FechaTermino, Nullable<Int32> i_PlanillaCerrada, Nullable<Int32> i_NoAplicaDctoLeyAFP, Nullable<Int32> i_NoAplicaSNPAFP, Nullable<Int32> i_Eliminado, Nullable<Int32> i_InsertaIdUsuario, Nullable<DateTime> t_InsertaFecha, Nullable<Int32> i_ActualizaIdUsuario, Nullable<DateTime> t_ActualizaFecha, List<planillacalculoDto> planillacalculo, List<planillavariablestrabajadorDto> planillavariablestrabajador)
        {
			this.i_Id = i_Id;
			this.v_Numero = v_Numero;
			this.v_Periodo = v_Periodo;
			this.v_Mes = v_Mes;
			this.v_Observaciones = v_Observaciones;
			this.i_IdTipoPlanilla = i_IdTipoPlanilla;
			this.d_TipoCambio = d_TipoCambio;
			this.d_SueldoMinimo = d_SueldoMinimo;
			this.i_Remuneraciones = i_Remuneraciones;
			this.i_Gratificaciones = i_Gratificaciones;
			this.i_Vacaciones = i_Vacaciones;
			this.t_FechaInicio = t_FechaInicio;
			this.t_FechaTermino = t_FechaTermino;
			this.i_PlanillaCerrada = i_PlanillaCerrada;
			this.i_NoAplicaDctoLeyAFP = i_NoAplicaDctoLeyAFP;
			this.i_NoAplicaSNPAFP = i_NoAplicaSNPAFP;
			this.i_Eliminado = i_Eliminado;
			this.i_InsertaIdUsuario = i_InsertaIdUsuario;
			this.t_InsertaFecha = t_InsertaFecha;
			this.i_ActualizaIdUsuario = i_ActualizaIdUsuario;
			this.t_ActualizaFecha = t_ActualizaFecha;
			this.planillacalculo = planillacalculo;
			this.planillavariablestrabajador = planillavariablestrabajador;
        }
    }
}
