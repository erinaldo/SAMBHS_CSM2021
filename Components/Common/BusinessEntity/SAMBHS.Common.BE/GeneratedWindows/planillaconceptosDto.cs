//-------------------------------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by EntitiesToDTOs.v3.2 (entitiestodtos.codeplex.com).
//     Timestamp: 2017/07/13 - 15:12:18
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
    public partial class planillaconceptosDto
    {
        [DataMember()]
        public String v_IdConceptoPlanilla { get; set; }

        [DataMember()]
        public Nullable<Int32> i_IdTipoConcepto { get; set; }

        [DataMember()]
        public String v_Codigo { get; set; }

        [DataMember()]
        public Nullable<Int32> i_IdTipoPlanilla { get; set; }

        [DataMember()]
        public String v_Nombre { get; set; }

        [DataMember()]
        public Nullable<Int32> i_IdTipoConceptoPlanilla { get; set; }

        [DataMember()]
        public Nullable<Int32> i_IdMoneda { get; set; }

        [DataMember()]
        public Nullable<Int32> i_ConsiderarVacaciones { get; set; }

        [DataMember()]
        public Nullable<Int32> i_DescontarEsSalud { get; set; }

        [DataMember()]
        public Nullable<Int32> i_DescontarSCTR { get; set; }

        [DataMember()]
        public Nullable<Int32> i_DescontarSCTRPens { get; set; }

        [DataMember()]
        public String v_ColumnaAfectaciones { get; set; }

        [DataMember()]
        public String v_ColumnaPorcentaje { get; set; }

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

        [DataMember()]
        public List<planillarelaciondescuentosDto> planillarelaciondescuentos { get; set; }

        [DataMember()]
        public List<planillaafectacionesgeneralesDto> planillaafectacionesgenerales { get; set; }

        [DataMember()]
        public List<planillacalculoDto> planillacalculo { get; set; }

        [DataMember()]
        public List<planillarelacionesaportacionesDto> planillarelacionesaportaciones { get; set; }

        [DataMember()]
        public List<planillarelacionesdescuentosafpDto> planillarelacionesdescuentosafp { get; set; }

        [DataMember()]
        public List<planillarelacioningresosDto> planillarelacioningresos { get; set; }

        [DataMember()]
        public List<planillavaloresrentaquintaDto> planillavaloresrentaquinta_v_IdConceptoPlanillaGratificacion { get; set; }

        [DataMember()]
        public List<planillavaloresrentaquintaDto> planillavaloresrentaquinta_v_IdConceptoPlanillaRenta5T { get; set; }

        [DataMember()]
        public String v_Siglas { get; set; }

        [DataMember()]
        public String v_Formula { get; set; }

        [DataMember()]
        public Nullable<Int32> i_IdTipo { get; set; }

        public planillaconceptosDto()
        {
        }

        public planillaconceptosDto(String v_IdConceptoPlanilla, Nullable<Int32> i_IdTipoConcepto, String v_Codigo, Nullable<Int32> i_IdTipoPlanilla, String v_Nombre, Nullable<Int32> i_IdTipoConceptoPlanilla, Nullable<Int32> i_IdMoneda, Nullable<Int32> i_ConsiderarVacaciones, Nullable<Int32> i_DescontarEsSalud, Nullable<Int32> i_DescontarSCTR, Nullable<Int32> i_DescontarSCTRPens, String v_ColumnaAfectaciones, String v_ColumnaPorcentaje, Nullable<Int32> i_Eliminado, Nullable<DateTime> t_InsertaFecha, Nullable<Int32> i_InsertaIdUsuario, Nullable<DateTime> t_ActualizaFecha, Nullable<Int32> i_ActualizaIdUsuario, List<planillarelaciondescuentosDto> planillarelaciondescuentos, List<planillaafectacionesgeneralesDto> planillaafectacionesgenerales, List<planillacalculoDto> planillacalculo, List<planillarelacionesaportacionesDto> planillarelacionesaportaciones, List<planillarelacionesdescuentosafpDto> planillarelacionesdescuentosafp, List<planillarelacioningresosDto> planillarelacioningresos, List<planillavaloresrentaquintaDto> planillavaloresrentaquinta_v_IdConceptoPlanillaGratificacion, List<planillavaloresrentaquintaDto> planillavaloresrentaquinta_v_IdConceptoPlanillaRenta5T)
        {
			this.v_IdConceptoPlanilla = v_IdConceptoPlanilla;
			this.i_IdTipoConcepto = i_IdTipoConcepto;
			this.v_Codigo = v_Codigo;
			this.i_IdTipoPlanilla = i_IdTipoPlanilla;
			this.v_Nombre = v_Nombre;
			this.i_IdTipoConceptoPlanilla = i_IdTipoConceptoPlanilla;
			this.i_IdMoneda = i_IdMoneda;
			this.i_ConsiderarVacaciones = i_ConsiderarVacaciones;
			this.i_DescontarEsSalud = i_DescontarEsSalud;
			this.i_DescontarSCTR = i_DescontarSCTR;
			this.i_DescontarSCTRPens = i_DescontarSCTRPens;
			this.v_ColumnaAfectaciones = v_ColumnaAfectaciones;
			this.v_ColumnaPorcentaje = v_ColumnaPorcentaje;
			this.i_Eliminado = i_Eliminado;
			this.t_InsertaFecha = t_InsertaFecha;
			this.i_InsertaIdUsuario = i_InsertaIdUsuario;
			this.t_ActualizaFecha = t_ActualizaFecha;
			this.i_ActualizaIdUsuario = i_ActualizaIdUsuario;
			this.planillarelaciondescuentos = planillarelaciondescuentos;
			this.planillaafectacionesgenerales = planillaafectacionesgenerales;
			this.planillacalculo = planillacalculo;
			this.planillarelacionesaportaciones = planillarelacionesaportaciones;
			this.planillarelacionesdescuentosafp = planillarelacionesdescuentosafp;
			this.planillarelacioningresos = planillarelacioningresos;
			this.planillavaloresrentaquinta_v_IdConceptoPlanillaGratificacion = planillavaloresrentaquinta_v_IdConceptoPlanillaGratificacion;
			this.planillavaloresrentaquinta_v_IdConceptoPlanillaRenta5T = planillavaloresrentaquinta_v_IdConceptoPlanillaRenta5T;
        }
    }
}
