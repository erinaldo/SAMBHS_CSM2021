//-------------------------------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by EntitiesToDTOs.v3.2 (entitiestodtos.codeplex.com).
//     Timestamp: 2017/07/13 - 15:13:11
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
    /// Assembler for <see cref="activofijodetalle"/> and <see cref="activofijodetalleDto"/>.
    /// </summary>
    public static partial class activofijodetalleAssembler
    {
        /// <summary>
        /// Invoked when <see cref="ToDTO"/> operation is about to return.
        /// </summary>
        /// <param name="dto"><see cref="activofijodetalleDto"/> converted from <see cref="activofijodetalle"/>.</param>
        static partial void OnDTO(this activofijodetalle entity, activofijodetalleDto dto);

        /// <summary>
        /// Invoked when <see cref="ToEntity"/> operation is about to return.
        /// </summary>
        /// <param name="entity"><see cref="activofijodetalle"/> converted from <see cref="activofijodetalleDto"/>.</param>
        static partial void OnEntity(this activofijodetalleDto dto, activofijodetalle entity);

        /// <summary>
        /// Converts this instance of <see cref="activofijodetalleDto"/> to an instance of <see cref="activofijodetalle"/>.
        /// </summary>
        /// <param name="dto"><see cref="activofijodetalleDto"/> to convert.</param>
        public static activofijodetalle ToEntity(this activofijodetalleDto dto)
        {
            if (dto == null) return null;

            var entity = new activofijodetalle();

            entity.v_IdActivoFijoDetalle = dto.v_IdActivoFijoDetalle;
            entity.v_IdActivoFijo = dto.v_IdActivoFijo;
            entity.t_FechaAsignacion = dto.t_FechaAsignacion;
            entity.i_Ccosto = dto.i_Ccosto;
            entity.v_Observacion = dto.v_Observacion;
            entity.v_IdResponsableAsignacion = dto.v_IdResponsableAsignacion;
            entity.i_Eliminado = dto.i_Eliminado;
            entity.i_InsertaIdUsuario = dto.i_InsertaIdUsuario;
            entity.t_InsertaFecha = dto.t_InsertaFecha;
            entity.i_ActualizaIdUsuario = dto.i_ActualizaIdUsuario;
            entity.t_ActualizaFecha = dto.t_ActualizaFecha;

            dto.OnEntity(entity);

            return entity;
        }

        /// <summary>
        /// Converts this instance of <see cref="activofijodetalle"/> to an instance of <see cref="activofijodetalleDto"/>.
        /// </summary>
        /// <param name="entity"><see cref="activofijodetalle"/> to convert.</param>
        public static activofijodetalleDto ToDTO(this activofijodetalle entity)
        {
            if (entity == null) return null;

            var dto = new activofijodetalleDto();

            dto.v_IdActivoFijoDetalle = entity.v_IdActivoFijoDetalle;
            dto.v_IdActivoFijo = entity.v_IdActivoFijo;
            dto.t_FechaAsignacion = entity.t_FechaAsignacion;
            dto.i_Ccosto = entity.i_Ccosto;
            dto.v_Observacion = entity.v_Observacion;
            dto.v_IdResponsableAsignacion = entity.v_IdResponsableAsignacion;
            dto.i_Eliminado = entity.i_Eliminado;
            dto.i_InsertaIdUsuario = entity.i_InsertaIdUsuario;
            dto.t_InsertaFecha = entity.t_InsertaFecha;
            dto.i_ActualizaIdUsuario = entity.i_ActualizaIdUsuario;
            dto.t_ActualizaFecha = entity.t_ActualizaFecha;

            entity.OnDTO(dto);

            return dto;
        }

        /// <summary>
        /// Converts each instance of <see cref="activofijodetalleDto"/> to an instance of <see cref="activofijodetalle"/>.
        /// </summary>
        /// <param name="dtos"></param>
        /// <returns></returns>
        public static List<activofijodetalle> ToEntities(this IEnumerable<activofijodetalleDto> dtos)
        {
            if (dtos == null) return null;

            return dtos.Select(e => e.ToEntity()).ToList();
        }

        /// <summary>
        /// Converts each instance of <see cref="activofijodetalle"/> to an instance of <see cref="activofijodetalleDto"/>.
        /// </summary>
        /// <param name="entities"></param>
        /// <returns></returns>
        public static List<activofijodetalleDto> ToDTOs(this IEnumerable<activofijodetalle> entities)
        {
            if (entities == null) return null;

            return entities.Select(e => e.ToDTO()).ToList();
        }

    }
}
