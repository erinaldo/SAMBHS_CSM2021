//-------------------------------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by EntitiesToDTOs.v3.1 (entitiestodtos.codeplex.com).
//     Timestamp: 2015/11/24 - 15:06:49
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
    public partial class organizationDto
    {
        [DataMember()]
        public Int32 i_OrganizationId { get; set; }

        [DataMember()]
        public String v_IdentificationNumber { get; set; }

        [DataMember()]
        public String v_Name { get; set; }

        [DataMember()]
        public String v_Address { get; set; }

        [DataMember()]
        public String v_PhoneNumber { get; set; }

        [DataMember()]
        public String v_Mail { get; set; }

        [DataMember()]
        public String v_ContacName { get; set; }

        [DataMember()]
        public String v_Observation { get; set; }

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

        public organizationDto()
        {
        }

        public organizationDto(Int32 i_OrganizationId, String v_IdentificationNumber, String v_Name, String v_Address, String v_PhoneNumber, String v_Mail, String v_ContacName, String v_Observation, Nullable<Int32> i_IsDeleted, Nullable<Int32> i_InsertUserId, Nullable<DateTime> d_InsertDate, Nullable<Int32> i_UpdateUserId, Nullable<DateTime> d_UpdateDate)
        {
			this.i_OrganizationId = i_OrganizationId;
			this.v_IdentificationNumber = v_IdentificationNumber;
			this.v_Name = v_Name;
			this.v_Address = v_Address;
			this.v_PhoneNumber = v_PhoneNumber;
			this.v_Mail = v_Mail;
			this.v_ContacName = v_ContacName;
			this.v_Observation = v_Observation;
			this.i_IsDeleted = i_IsDeleted;
			this.i_InsertUserId = i_InsertUserId;
			this.d_InsertDate = d_InsertDate;
			this.i_UpdateUserId = i_UpdateUserId;
			this.d_UpdateDate = d_UpdateDate;
        }
    }
}
