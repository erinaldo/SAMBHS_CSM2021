//-------------------------------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by EntitiesToDTOs.v3.2 (entitiestodtos.codeplex.com).
//     Timestamp: 2017/07/13 - 15:09:44
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
    public partial class flujoefectivoasientoajusteDto
    {
        [DataMember()]
        public Int32 i_IdAsientoAjuste { get; set; }

        [DataMember()]
        public Nullable<Int32> i_IdFlujoEfectivoCabecera { get; set; }

        [DataMember()]
        public Nullable<Int32> i_NroAsiento { get; set; }

        [DataMember()]
        public Nullable<Int32> i_IdMoneda { get; set; }

        [DataMember()]
        public Nullable<Decimal> d_TipoCambio { get; set; }

        [DataMember()]
        public String v_Glosa { get; set; }

        [DataMember()]
        public List<flujoefectivoasientoajustedetalleDto> flujoefectivoasientoajustedetalle { get; set; }

        [DataMember()]
        public flujoefectivocabeceraDto flujoefectivocabecera { get; set; }

        public flujoefectivoasientoajusteDto()
        {
        }

        public flujoefectivoasientoajusteDto(Int32 i_IdAsientoAjuste, Nullable<Int32> i_IdFlujoEfectivoCabecera, Nullable<Int32> i_NroAsiento, Nullable<Int32> i_IdMoneda, Nullable<Decimal> d_TipoCambio, String v_Glosa, List<flujoefectivoasientoajustedetalleDto> flujoefectivoasientoajustedetalle, flujoefectivocabeceraDto flujoefectivocabecera)
        {
			this.i_IdAsientoAjuste = i_IdAsientoAjuste;
			this.i_IdFlujoEfectivoCabecera = i_IdFlujoEfectivoCabecera;
			this.i_NroAsiento = i_NroAsiento;
			this.i_IdMoneda = i_IdMoneda;
			this.d_TipoCambio = d_TipoCambio;
			this.v_Glosa = v_Glosa;
			this.flujoefectivoasientoajustedetalle = flujoefectivoasientoajustedetalle;
			this.flujoefectivocabecera = flujoefectivocabecera;
        }
    }
}
