//-------------------------------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by EntitiesToDTOs.v3.2 (entitiestodtos.codeplex.com).
//     Timestamp: 2017/07/13 - 15:11:51
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
    public partial class regimenpensionariotrabajadorDto
    {
        [DataMember()]
        public String v_IdRegimenPensionario { get; set; }

        [DataMember()]
        public String v_IdTrabajador { get; set; }

        [DataMember()]
        public Nullable<Int32> i_IdRegimenPensionario { get; set; }

        [DataMember()]
        public Nullable<Int32> i_RegimenVigente { get; set; }

        [DataMember()]
        public Nullable<DateTime> t_FechaInscripcion { get; set; }

        [DataMember()]
        public String v_NroCussp { get; set; }

        [DataMember()]
        public String v_NroCuenta { get; set; }

        [DataMember()]
        public Nullable<Int32> i_IdModalidadRegimen { get; set; }

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
        public trabajadorDto trabajador { get; set; }

        public regimenpensionariotrabajadorDto()
        {
        }

        public regimenpensionariotrabajadorDto(String v_IdRegimenPensionario, String v_IdTrabajador, Nullable<Int32> i_IdRegimenPensionario, Nullable<Int32> i_RegimenVigente, Nullable<DateTime> t_FechaInscripcion, String v_NroCussp, String v_NroCuenta, Nullable<Int32> i_IdModalidadRegimen, Nullable<Int32> i_Eliminado, Nullable<Int32> i_InsertaIdUsuario, Nullable<DateTime> t_InsertaFecha, Nullable<Int32> i_ActualizaIdUsuario, Nullable<DateTime> t_ActualizaFecha, trabajadorDto trabajador)
        {
			this.v_IdRegimenPensionario = v_IdRegimenPensionario;
			this.v_IdTrabajador = v_IdTrabajador;
			this.i_IdRegimenPensionario = i_IdRegimenPensionario;
			this.i_RegimenVigente = i_RegimenVigente;
			this.t_FechaInscripcion = t_FechaInscripcion;
			this.v_NroCussp = v_NroCussp;
			this.v_NroCuenta = v_NroCuenta;
			this.i_IdModalidadRegimen = i_IdModalidadRegimen;
			this.i_Eliminado = i_Eliminado;
			this.i_InsertaIdUsuario = i_InsertaIdUsuario;
			this.t_InsertaFecha = t_InsertaFecha;
			this.i_ActualizaIdUsuario = i_ActualizaIdUsuario;
			this.t_ActualizaFecha = t_ActualizaFecha;
			this.trabajador = trabajador;
        }
    }
}
