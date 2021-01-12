//-------------------------------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by EntitiesToDTOs.v3.2 (entitiestodtos.codeplex.com).
//     Timestamp: 2017/07/13 - 15:11:41
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
    public partial class planillavariablestrabajadorDto
    {
        [DataMember()]
        public String v_IdPlanillaVariablesTrabajador { get; set; }

        [DataMember()]
        public Int32 i_IdPlanillaNumeracion { get; set; }

        [DataMember()]
        public String v_IdTrabajador { get; set; }

        [DataMember()]
        public String v_IdContrato { get; set; }

        [DataMember()]
        public Nullable<Int32> i_Movilidad { get; set; }

        [DataMember()]
        public Nullable<Decimal> d_Imp { get; set; }

        [DataMember()]
        public Nullable<Int32> i_DiasLaborados { get; set; }

        [DataMember()]
        public Nullable<Int32> i_DiasNoLaborados { get; set; }

        [DataMember()]
        public Nullable<Int32> i_DiasSubsidiados { get; set; }

        [DataMember()]
        public Nullable<Int32> i_DiasLaboradosBP { get; set; }

        [DataMember()]
        public Nullable<Decimal> d_HorasLaboradosBP { get; set; }

        [DataMember()]
        public Nullable<Decimal> d_TiempoTardanza { get; set; }

        [DataMember()]
        public Nullable<Int32> i_Pago { get; set; }

        [DataMember()]
        public Nullable<Int32> i_AfectoSenati { get; set; }

        [DataMember()]
        public Nullable<Int32> i_NoAplicarDCTOLeyesAFP { get; set; }

        [DataMember()]
        public Nullable<Int32> i_AfectoSCTR { get; set; }

        [DataMember()]
        public Nullable<Int32> i_AfectoSCTRPen { get; set; }

        [DataMember()]
        public Nullable<DateTime> t_FechaVacacionesInicio { get; set; }

        [DataMember()]
        public Nullable<DateTime> t_FechaVacacionesFin { get; set; }

        [DataMember()]
        public Nullable<Decimal> d_TotalIngresoSoles { get; set; }

        [DataMember()]
        public Nullable<Decimal> d_TotalIngresoDolares { get; set; }

        [DataMember()]
        public Nullable<Decimal> d_TotalDescuentoSoles { get; set; }

        [DataMember()]
        public Nullable<Decimal> d_TotalDescuentoDolares { get; set; }

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
        public Nullable<Int32> i_TieneVacaciones { get; set; }

        [DataMember()]
        public List<planillavariablesaportacionesDto> planillavariablesaportaciones { get; set; }

        [DataMember()]
        public List<planillavariablesdescuentosDto> planillavariablesdescuentos { get; set; }

        [DataMember()]
        public List<planillavariablesdiasnolabsubsidiadosDto> planillavariablesdiasnolabsubsidiados { get; set; }

        [DataMember()]
        public List<planillavariableshorasextrasDto> planillavariableshorasextras { get; set; }

        [DataMember()]
        public List<planillavariablesingresosDto> planillavariablesingresos { get; set; }

        [DataMember()]
        public contratotrabajadorDto contratotrabajador { get; set; }

        [DataMember()]
        public planillanumeracionDto planillanumeracion { get; set; }

        [DataMember()]
        public trabajadorDto trabajador { get; set; }

        public planillavariablestrabajadorDto()
        {
        }

        public planillavariablestrabajadorDto(String v_IdPlanillaVariablesTrabajador, Int32 i_IdPlanillaNumeracion, String v_IdTrabajador, String v_IdContrato, Nullable<Int32> i_Movilidad, Nullable<Decimal> d_Imp, Nullable<Int32> i_DiasLaborados, Nullable<Int32> i_DiasNoLaborados, Nullable<Int32> i_DiasSubsidiados, Nullable<Int32> i_DiasLaboradosBP, Nullable<Decimal> d_HorasLaboradosBP, Nullable<Decimal> d_TiempoTardanza, Nullable<Int32> i_Pago, Nullable<Int32> i_AfectoSenati, Nullable<Int32> i_NoAplicarDCTOLeyesAFP, Nullable<Int32> i_AfectoSCTR, Nullable<Int32> i_AfectoSCTRPen, Nullable<DateTime> t_FechaVacacionesInicio, Nullable<DateTime> t_FechaVacacionesFin, Nullable<Decimal> d_TotalIngresoSoles, Nullable<Decimal> d_TotalIngresoDolares, Nullable<Decimal> d_TotalDescuentoSoles, Nullable<Decimal> d_TotalDescuentoDolares, Nullable<Int32> i_Eliminado, Nullable<Int32> i_InsertaIdUsuario, Nullable<DateTime> t_InsertaFecha, Nullable<Int32> i_ActualizaIdUsuario, Nullable<DateTime> t_ActualizaFecha, Nullable<Int32> i_TieneVacaciones, List<planillavariablesaportacionesDto> planillavariablesaportaciones, List<planillavariablesdescuentosDto> planillavariablesdescuentos, List<planillavariablesdiasnolabsubsidiadosDto> planillavariablesdiasnolabsubsidiados, List<planillavariableshorasextrasDto> planillavariableshorasextras, List<planillavariablesingresosDto> planillavariablesingresos, contratotrabajadorDto contratotrabajador, planillanumeracionDto planillanumeracion, trabajadorDto trabajador)
        {
			this.v_IdPlanillaVariablesTrabajador = v_IdPlanillaVariablesTrabajador;
			this.i_IdPlanillaNumeracion = i_IdPlanillaNumeracion;
			this.v_IdTrabajador = v_IdTrabajador;
			this.v_IdContrato = v_IdContrato;
			this.i_Movilidad = i_Movilidad;
			this.d_Imp = d_Imp;
			this.i_DiasLaborados = i_DiasLaborados;
			this.i_DiasNoLaborados = i_DiasNoLaborados;
			this.i_DiasSubsidiados = i_DiasSubsidiados;
			this.i_DiasLaboradosBP = i_DiasLaboradosBP;
			this.d_HorasLaboradosBP = d_HorasLaboradosBP;
			this.d_TiempoTardanza = d_TiempoTardanza;
			this.i_Pago = i_Pago;
			this.i_AfectoSenati = i_AfectoSenati;
			this.i_NoAplicarDCTOLeyesAFP = i_NoAplicarDCTOLeyesAFP;
			this.i_AfectoSCTR = i_AfectoSCTR;
			this.i_AfectoSCTRPen = i_AfectoSCTRPen;
			this.t_FechaVacacionesInicio = t_FechaVacacionesInicio;
			this.t_FechaVacacionesFin = t_FechaVacacionesFin;
			this.d_TotalIngresoSoles = d_TotalIngresoSoles;
			this.d_TotalIngresoDolares = d_TotalIngresoDolares;
			this.d_TotalDescuentoSoles = d_TotalDescuentoSoles;
			this.d_TotalDescuentoDolares = d_TotalDescuentoDolares;
			this.i_Eliminado = i_Eliminado;
			this.i_InsertaIdUsuario = i_InsertaIdUsuario;
			this.t_InsertaFecha = t_InsertaFecha;
			this.i_ActualizaIdUsuario = i_ActualizaIdUsuario;
			this.t_ActualizaFecha = t_ActualizaFecha;
			this.i_TieneVacaciones = i_TieneVacaciones;
			this.planillavariablesaportaciones = planillavariablesaportaciones;
			this.planillavariablesdescuentos = planillavariablesdescuentos;
			this.planillavariablesdiasnolabsubsidiados = planillavariablesdiasnolabsubsidiados;
			this.planillavariableshorasextras = planillavariableshorasextras;
			this.planillavariablesingresos = planillavariablesingresos;
			this.contratotrabajador = contratotrabajador;
			this.planillanumeracion = planillanumeracion;
			this.trabajador = trabajador;
        }
    }
}
