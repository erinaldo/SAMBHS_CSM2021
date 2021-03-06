//-------------------------------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by EntitiesToDTOs.v3.2 (entitiestodtos.codeplex.com).
//     Timestamp: 2017/07/13 - 15:13:04
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
    /// Assembler for <see cref="ventadetalleanexo"/> and <see cref="ventadetalleanexoDto"/>.
    /// </summary>
    public static partial class ventadetalleanexoAssembler
    {
        /// <summary>
        /// Invoked when <see cref="ToDTO"/> operation is about to return.
        /// </summary>
        /// <param name="dto"><see cref="ventadetalleanexoDto"/> converted from <see cref="ventadetalleanexo"/>.</param>
        static partial void OnDTO(this ventadetalleanexo entity, ventadetalleanexoDto dto);

        /// <summary>
        /// Invoked when <see cref="ToEntity"/> operation is about to return.
        /// </summary>
        /// <param name="entity"><see cref="ventadetalleanexo"/> converted from <see cref="ventadetalleanexoDto"/>.</param>
        static partial void OnEntity(this ventadetalleanexoDto dto, ventadetalleanexo entity);

        /// <summary>
        /// Converts this instance of <see cref="ventadetalleanexoDto"/> to an instance of <see cref="ventadetalleanexo"/>.
        /// </summary>
        /// <param name="dto"><see cref="ventadetalleanexoDto"/> to convert.</param>
        public static ventadetalleanexo ToEntity(this ventadetalleanexoDto dto)
        {
            if (dto == null) return null;

            var entity = new ventadetalleanexo();

            entity.i_IdVentaDetalleAnexo = dto.i_IdVentaDetalleAnexo;
            entity.v_Anexo = dto.v_Anexo;
            entity.i_Eliminado = dto.i_Eliminado;
            entity.i_InsertaIdUsuario = dto.i_InsertaIdUsuario;
            entity.t_InsertaFecha = dto.t_InsertaFecha;
            entity.i_ActualizaIdUsuario = dto.i_ActualizaIdUsuario;
            entity.t_ActualizaFecha = dto.t_ActualizaFecha;

            dto.OnEntity(entity);

            return entity;
        }

        /// <summary>
        /// Converts this instance of <see cref="ventadetalleanexo"/> to an instance of <see cref="ventadetalleanexoDto"/>.
        /// </summary>
        /// <param name="entity"><see cref="ventadetalleanexo"/> to convert.</param>
        public static ventadetalleanexoDto ToDTO(this ventadetalleanexo entity)
        {
            if (entity == null) return null;

            var dto = new ventadetalleanexoDto();

            dto.i_IdVentaDetalleAnexo = entity.i_IdVentaDetalleAnexo;
            dto.v_Anexo = entity.v_Anexo;
            dto.i_Eliminado = entity.i_Eliminado;
            dto.i_InsertaIdUsuario = entity.i_InsertaIdUsuario;
            dto.t_InsertaFecha = entity.t_InsertaFecha;
            dto.i_ActualizaIdUsuario = entity.i_ActualizaIdUsuario;
            dto.t_ActualizaFecha = entity.t_ActualizaFecha;

            entity.OnDTO(dto);

            return dto;
        }

        /// <summary>
        /// Converts each instance of <see cref="ventadetalleanexoDto"/> to an instance of <see cref="ventadetalleanexo"/>.
        /// </summary>
        /// <param name="dtos"></param>
        /// <returns></returns>
        public static List<ventadetalleanexo> ToEntities(this IEnumerable<ventadetalleanexoDto> dtos)
        {
            if (dtos == null) return null;

            return dtos.Select(e => e.ToEntity()).ToList();
        }

        /// <summary>
        /// Converts each instance of <see cref="ventadetalleanexo"/> to an instance of <see cref="ventadetalleanexoDto"/>.
        /// </summary>
        /// <param name="entities"></param>
        /// <returns></returns>
        public static List<ventadetalleanexoDto> ToDTOs(this IEnumerable<ventadetalleanexo> entities)
        {
            if (entities == null) return null;

            return entities.Select(e => e.ToDTO()).ToList();
        }

    }
}
