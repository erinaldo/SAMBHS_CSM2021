//-------------------------------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by EntitiesToDTOs.v3.1 (entitiestodtos.codeplex.com).
//     Timestamp: 2015/11/24 - 15:06:52
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
    public partial class nodewarehouseDto
    {
        [DataMember()]
        public Int32 i_NodeWarehouseId { get; set; }

        [DataMember()]
        public Nullable<Int32> i_NodeId { get; set; }

        [DataMember()]
        public Nullable<Int32> i_WarehouseId { get; set; }

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
        public nodeDto node { get; set; }

        [DataMember()]
        public warehouseDto warehouse { get; set; }

        public nodewarehouseDto()
        {
        }

        public nodewarehouseDto(Int32 i_NodeWarehouseId, Nullable<Int32> i_NodeId, Nullable<Int32> i_WarehouseId, Nullable<Int32> i_IsDeleted, Nullable<Int32> i_InsertUserId, Nullable<DateTime> d_InsertDate, Nullable<Int32> i_UpdateUserId, Nullable<DateTime> d_UpdateDate, nodeDto node, warehouseDto warehouse)
        {
			this.i_NodeWarehouseId = i_NodeWarehouseId;
			this.i_NodeId = i_NodeId;
			this.i_WarehouseId = i_WarehouseId;
			this.i_IsDeleted = i_IsDeleted;
			this.i_InsertUserId = i_InsertUserId;
			this.d_InsertDate = d_InsertDate;
			this.i_UpdateUserId = i_UpdateUserId;
			this.d_UpdateDate = d_UpdateDate;
			this.node = node;
			this.warehouse = warehouse;
        }
    }
}
