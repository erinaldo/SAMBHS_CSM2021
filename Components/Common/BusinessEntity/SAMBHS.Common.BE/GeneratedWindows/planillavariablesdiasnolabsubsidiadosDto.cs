//-------------------------------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by EntitiesToDTOs.v3.2 (entitiestodtos.codeplex.com).
//     Timestamp: 2017/07/13 - 15:11:27
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
    public partial class planillavariablesdiasnolabsubsidiadosDto
    {
        [DataMember()]
        public Int32 i_Id { get; set; }

        [DataMember()]
        public String v_IdPlanillaVariablesTrabajador { get; set; }

        [DataMember()]
        public Nullable<Int32> i_IdConcepto { get; set; }

        [DataMember()]
        public Nullable<Int32> i_IdTipoConcepto { get; set; }

        [DataMember()]
        public Nullable<Int32> i_CantidadDias { get; set; }

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

        public planillavariablesdiasnolabsubsidiadosDto()
        {
        }

        public planillavariablesdiasnolabsubsidiadosDto(Int32 i_Id, String v_IdPlanillaVariablesTrabajador, Nullable<Int32> i_IdConcepto, Nullable<Int32> i_IdTipoConcepto, Nullable<Int32> i_CantidadDias, Nullable<Int32> i_Eliminado, Nullable<Int32> i_InsertaIdUsuario, Nullable<DateTime> t_InsertaFecha, Nullable<Int32> i_ActualizaIdUsuario, Nullable<DateTime> t_ActualizaFecha, planillavariablestrabajadorDto planillavariablestrabajador)
        {
			this.i_Id = i_Id;
			this.v_IdPlanillaVariablesTrabajador = v_IdPlanillaVariablesTrabajador;
			this.i_IdConcepto = i_IdConcepto;
			this.i_IdTipoConcepto = i_IdTipoConcepto;
			this.i_CantidadDias = i_CantidadDias;
			this.i_Eliminado = i_Eliminado;
			this.i_InsertaIdUsuario = i_InsertaIdUsuario;
			this.t_InsertaFecha = t_InsertaFecha;
			this.i_ActualizaIdUsuario = i_ActualizaIdUsuario;
			this.t_ActualizaFecha = t_ActualizaFecha;
			this.planillavariablestrabajador = planillavariablestrabajador;
        }
    }
}
