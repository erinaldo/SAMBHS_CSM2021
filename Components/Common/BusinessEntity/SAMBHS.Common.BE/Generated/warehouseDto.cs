//-------------------------------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by EntitiesToDTOs.v3.1 (entitiestodtos.codeplex.com).
//     Timestamp: 2015/11/24 - 15:06:51
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
    public partial class warehouseDto
    {
        [DataMember()]
        public Int32 i_WarehouseId { get; set; }

        [DataMember()]
        public String v_Name { get; set; }

        [DataMember()]
        public String v_Address { get; set; }

        [DataMember()]
        public String v_PhoneNumber { get; set; }

        [DataMember()]
        public String v_CommercialName { get; set; }

        [DataMember()]
        public String v_TicketSerialNumber { get; set; }

        [DataMember()]
        public String v_EstablishmentCode { get; set; }

        [DataMember()]
        public Nullable<Int32> i_IsDeleted { get; set; }

        [DataMember()]
        public Nullable<Int32> i_InsertUserId { get; set; }

        [DataMember()]
        public Nullable<DateTime> d_InsertDate { get; set; }

        [DataMember()]
        public Nullable<Int32> i_UpdateUserId { get; set; }

        [DataMember()]
        public Nullable<DateTime> d_UpdateDate { get; set; }

        [DataMember()]
        public List<nodewarehouseDto> nodewarehouse { get; set; }

        public warehouseDto()
        {
        }

        public warehouseDto(Int32 i_WarehouseId, String v_Name, String v_Address, String v_PhoneNumber, String v_CommercialName, String v_TicketSerialNumber, String v_EstablishmentCode, Nullable<Int32> i_IsDeleted, Nullable<Int32> i_InsertUserId, Nullable<DateTime> d_InsertDate, Nullable<Int32> i_UpdateUserId, Nullable<DateTime> d_UpdateDate, List<nodewarehouseDto> nodewarehouse)
        {
			this.i_WarehouseId = i_WarehouseId;
			this.v_Name = v_Name;
			this.v_Address = v_Address;
			this.v_PhoneNumber = v_PhoneNumber;
			this.v_CommercialName = v_CommercialName;
			this.v_TicketSerialNumber = v_TicketSerialNumber;
			this.v_EstablishmentCode = v_EstablishmentCode;
			this.i_IsDeleted = i_IsDeleted;
			this.i_InsertUserId = i_InsertUserId;
			this.d_InsertDate = d_InsertDate;
			this.i_UpdateUserId = i_UpdateUserId;
			this.d_UpdateDate = d_UpdateDate;
			this.nodewarehouse = nodewarehouse;
        }
    }
}
