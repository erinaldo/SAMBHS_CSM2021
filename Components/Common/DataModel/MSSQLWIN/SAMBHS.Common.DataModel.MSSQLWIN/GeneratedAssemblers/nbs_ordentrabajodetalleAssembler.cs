//-------------------------------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by EntitiesToDTOs.v3.2 (entitiestodtos.codeplex.com).
//     Timestamp: 2017/07/13 - 15:13:52
//
//     Changes to this file may cause incorrect behavior and will be lost if the code is regenerated.
// </auto-generated>
//-------------------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;
using System.Linq;
using SAMBHS.Common.DataModel;

namespace SAMBHS.Common.BE
{

    /// <summary>
    /// Assembler for <see cref="nbs_ordentrabajodetalle"/> and <see cref="nbs_ordentrabajodetalleDto"/>.
    /// </summary>
    public static partial class nbs_ordentrabajodetalleAssembler
    {
        /// <summary>
        /// Invoked when <see cref="ToDTO"/> operation is about to return.
        /// </summary>
        /// <param name="dto"><see cref="nbs_ordentrabajodetalleDto"/> converted from <see cref="nbs_ordentrabajodetalle"/>.</param>
        static partial void OnDTO(this nbs_ordentrabajodetalle entity, nbs_ordentrabajodetalleDto dto);

        /// <summary>
        /// Invoked when <see cref="ToEntity"/> operation is about to return.
        /// </summary>
        /// <param name="entity"><see cref="nbs_ordentrabajodetalle"/> converted from <see cref="nbs_ordentrabajodetalleDto"/>.</param>
        static partial void OnEntity(this nbs_ordentrabajodetalleDto dto, nbs_ordentrabajodetalle entity);

        /// <summary>
        /// Converts this instance of <see cref="nbs_ordentrabajodetalleDto"/> to an instance of <see cref="nbs_ordentrabajodetalle"/>.
        /// </summary>
        /// <param name="dto"><see cref="nbs_ordentrabajodetalleDto"/> to convert.</param>
        public static nbs_ordentrabajodetalle ToEntity(this nbs_ordentrabajodetalleDto dto)
        {
            if (dto == null) return null;

            var entity = new nbs_ordentrabajodetalle();

            entity.v_IdOrdenTrabajoDetalle = dto.v_IdOrdenTrabajoDetalle;
            entity.v_IdOrdenTrabajo = dto.v_IdOrdenTrabajo;
            entity.i_Cantidad = dto.i_Cantidad;
            entity.v_IdProductoDetalle = dto.v_IdProductoDetalle;
            entity.d_Importe = dto.d_Importe;
            entity.d_Total = dto.d_Total;
            entity.v_Glosa = dto.v_Glosa;
            entity.i_UsadoEnFUF = dto.i_UsadoEnFUF;
            entity.i_Eliminado = dto.i_Eliminado;
            entity.i_InsertaIdUsuario = dto.i_InsertaIdUsuario;
            entity.t_InsertaFecha = dto.t_InsertaFecha;
            entity.i_ActualizaIdUsuario = dto.i_ActualizaIdUsuario;
            entity.t_ActualizaFecha = dto.t_ActualizaFecha;
            entity.v_DescripcionTemporal = dto.v_DescripcionTemporal;
            entity.d_ImporteRegistral = dto.d_ImporteRegistral;

            dto.OnEntity(entity);

            return entity;
        }

        /// <summary>
        /// Converts this instance of <see cref="nbs_ordentrabajodetalle"/> to an instance of <see cref="nbs_ordentrabajodetalleDto"/>.
        /// </summary>
        /// <param name="entity"><see cref="nbs_ordentrabajodetalle"/> to convert.</param>
        public static nbs_ordentrabajodetalleDto ToDTO(this nbs_ordentrabajodetalle entity)
        {
            if (entity == null) return null;

            var dto = new nbs_ordentrabajodetalleDto();

            dto.v_IdOrdenTrabajoDetalle = entity.v_IdOrdenTrabajoDetalle;
            dto.v_IdOrdenTrabajo = entity.v_IdOrdenTrabajo;
            dto.i_Cantidad = entity.i_Cantidad;
            dto.v_IdProductoDetalle = entity.v_IdProductoDetalle;
            dto.d_Importe = entity.d_Importe;
            dto.d_Total = entity.d_Total;
            dto.v_Glosa = entity.v_Glosa;
            dto.i_UsadoEnFUF = entity.i_UsadoEnFUF;
            dto.i_Eliminado = entity.i_Eliminado;
            dto.i_InsertaIdUsuario = entity.i_InsertaIdUsuario;
            dto.t_InsertaFecha = entity.t_InsertaFecha;
            dto.i_ActualizaIdUsuario = entity.i_ActualizaIdUsuario;
            dto.t_ActualizaFecha = entity.t_ActualizaFecha;
            dto.v_DescripcionTemporal = entity.v_DescripcionTemporal;
            dto.d_ImporteRegistral = entity.d_ImporteRegistral;

            entity.OnDTO(dto);

            return dto;
        }

        /// <summary>
        /// Converts each instance of <see cref="nbs_ordentrabajodetalleDto"/> to an instance of <see cref="nbs_ordentrabajodetalle"/>.
        /// </summary>
        /// <param name="dtos"></param>
        /// <returns></returns>
        public static List<nbs_ordentrabajodetalle> ToEntities(this IEnumerable<nbs_ordentrabajodetalleDto> dtos)
        {
            if (dtos == null) return null;

            return dtos.Select(e => e.ToEntity()).ToList();
        }

        /// <summary>
        /// Converts each instance of <see cref="nbs_ordentrabajodetalle"/> to an instance of <see cref="nbs_ordentrabajodetalleDto"/>.
        /// </summary>
        /// <param name="entities"></param>
        /// <returns></returns>
        public static List<nbs_ordentrabajodetalleDto> ToDTOs(this IEnumerable<nbs_ordentrabajodetalle> entities)
        {
            if (entities == null) return null;

            return entities.Select(e => e.ToDTO()).ToList();
        }

    }
}
