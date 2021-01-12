//-------------------------------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by EntitiesToDTOs.v3.2 (entitiestodtos.codeplex.com).
//     Timestamp: 2017/07/13 - 15:14:21
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
    /// Assembler for <see cref="talla"/> and <see cref="tallaDto"/>.
    /// </summary>
    public static partial class tallaAssembler
    {
        /// <summary>
        /// Invoked when <see cref="ToDTO"/> operation is about to return.
        /// </summary>
        /// <param name="dto"><see cref="tallaDto"/> converted from <see cref="talla"/>.</param>
        static partial void OnDTO(this talla entity, tallaDto dto);

        /// <summary>
        /// Invoked when <see cref="ToEntity"/> operation is about to return.
        /// </summary>
        /// <param name="entity"><see cref="talla"/> converted from <see cref="tallaDto"/>.</param>
        static partial void OnEntity(this tallaDto dto, talla entity);

        /// <summary>
        /// Converts this instance of <see cref="tallaDto"/> to an instance of <see cref="talla"/>.
        /// </summary>
        /// <param name="dto"><see cref="tallaDto"/> to convert.</param>
        public static talla ToEntity(this tallaDto dto)
        {
            if (dto == null) return null;

            var entity = new talla();

            entity.v_IdTalla = dto.v_IdTalla;
            entity.v_CodTalla = dto.v_CodTalla;
            entity.v_Nombre = dto.v_Nombre;
            entity.i_Eliminado = dto.i_Eliminado;
            entity.i_InsertaIdUsuario = dto.i_InsertaIdUsuario;
            entity.t_InsertaFecha = dto.t_InsertaFecha;
            entity.i_ActualizaIdUsuario = dto.i_ActualizaIdUsuario;
            entity.t_ActualizaFecha = dto.t_ActualizaFecha;

            dto.OnEntity(entity);

            return entity;
        }

        /// <summary>
        /// Converts this instance of <see cref="talla"/> to an instance of <see cref="tallaDto"/>.
        /// </summary>
        /// <param name="entity"><see cref="talla"/> to convert.</param>
        public static tallaDto ToDTO(this talla entity)
        {
            if (entity == null) return null;

            var dto = new tallaDto();

            dto.v_IdTalla = entity.v_IdTalla;
            dto.v_CodTalla = entity.v_CodTalla;
            dto.v_Nombre = entity.v_Nombre;
            dto.i_Eliminado = entity.i_Eliminado;
            dto.i_InsertaIdUsuario = entity.i_InsertaIdUsuario;
            dto.t_InsertaFecha = entity.t_InsertaFecha;
            dto.i_ActualizaIdUsuario = entity.i_ActualizaIdUsuario;
            dto.t_ActualizaFecha = entity.t_ActualizaFecha;

            entity.OnDTO(dto);

            return dto;
        }

        /// <summary>
        /// Converts each instance of <see cref="tallaDto"/> to an instance of <see cref="talla"/>.
        /// </summary>
        /// <param name="dtos"></param>
        /// <returns></returns>
        public static List<talla> ToEntities(this IEnumerable<tallaDto> dtos)
        {
            if (dtos == null) return null;

            return dtos.Select(e => e.ToEntity()).ToList();
        }

        /// <summary>
        /// Converts each instance of <see cref="talla"/> to an instance of <see cref="tallaDto"/>.
        /// </summary>
        /// <param name="entities"></param>
        /// <returns></returns>
        public static List<tallaDto> ToDTOs(this IEnumerable<talla> entities)
        {
            if (entities == null) return null;

            return entities.Select(e => e.ToDTO()).ToList();
        }

    }
}
