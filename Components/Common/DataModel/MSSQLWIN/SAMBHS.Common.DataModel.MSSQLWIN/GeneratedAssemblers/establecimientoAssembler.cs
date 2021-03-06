//-------------------------------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by EntitiesToDTOs.v3.2 (entitiestodtos.codeplex.com).
//     Timestamp: 2017/07/13 - 15:13:21
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
    /// Assembler for <see cref="establecimiento"/> and <see cref="establecimientoDto"/>.
    /// </summary>
    public static partial class establecimientoAssembler
    {
        /// <summary>
        /// Invoked when <see cref="ToDTO"/> operation is about to return.
        /// </summary>
        /// <param name="dto"><see cref="establecimientoDto"/> converted from <see cref="establecimiento"/>.</param>
        static partial void OnDTO(this establecimiento entity, establecimientoDto dto);

        /// <summary>
        /// Invoked when <see cref="ToEntity"/> operation is about to return.
        /// </summary>
        /// <param name="entity"><see cref="establecimiento"/> converted from <see cref="establecimientoDto"/>.</param>
        static partial void OnEntity(this establecimientoDto dto, establecimiento entity);

        /// <summary>
        /// Converts this instance of <see cref="establecimientoDto"/> to an instance of <see cref="establecimiento"/>.
        /// </summary>
        /// <param name="dto"><see cref="establecimientoDto"/> to convert.</param>
        public static establecimiento ToEntity(this establecimientoDto dto)
        {
            if (dto == null) return null;

            var entity = new establecimiento();

            entity.i_IdEstablecimiento = dto.i_IdEstablecimiento;
            entity.v_Nombre = dto.v_Nombre;
            entity.v_Direccion = dto.v_Direccion;
            entity.i_IdCentroCosto = dto.i_IdCentroCosto;
            entity.i_Eliminado = dto.i_Eliminado;
            entity.i_InsertaIdUsuario = dto.i_InsertaIdUsuario;
            entity.t_InsertaFecha = dto.t_InsertaFecha;
            entity.i_ActualizaIdUsuario = dto.i_ActualizaIdUsuario;
            entity.t_ActualizaFecha = dto.t_ActualizaFecha;

            dto.OnEntity(entity);

            return entity;
        }

        /// <summary>
        /// Converts this instance of <see cref="establecimiento"/> to an instance of <see cref="establecimientoDto"/>.
        /// </summary>
        /// <param name="entity"><see cref="establecimiento"/> to convert.</param>
        public static establecimientoDto ToDTO(this establecimiento entity)
        {
            if (entity == null) return null;

            var dto = new establecimientoDto();

            dto.i_IdEstablecimiento = entity.i_IdEstablecimiento;
            dto.v_Nombre = entity.v_Nombre;
            dto.v_Direccion = entity.v_Direccion;
            dto.i_IdCentroCosto = entity.i_IdCentroCosto;
            dto.i_Eliminado = entity.i_Eliminado;
            dto.i_InsertaIdUsuario = entity.i_InsertaIdUsuario;
            dto.t_InsertaFecha = entity.t_InsertaFecha;
            dto.i_ActualizaIdUsuario = entity.i_ActualizaIdUsuario;
            dto.t_ActualizaFecha = entity.t_ActualizaFecha;

            entity.OnDTO(dto);

            return dto;
        }

        /// <summary>
        /// Converts each instance of <see cref="establecimientoDto"/> to an instance of <see cref="establecimiento"/>.
        /// </summary>
        /// <param name="dtos"></param>
        /// <returns></returns>
        public static List<establecimiento> ToEntities(this IEnumerable<establecimientoDto> dtos)
        {
            if (dtos == null) return null;

            return dtos.Select(e => e.ToEntity()).ToList();
        }

        /// <summary>
        /// Converts each instance of <see cref="establecimiento"/> to an instance of <see cref="establecimientoDto"/>.
        /// </summary>
        /// <param name="entities"></param>
        /// <returns></returns>
        public static List<establecimientoDto> ToDTOs(this IEnumerable<establecimiento> entities)
        {
            if (entities == null) return null;

            return entities.Select(e => e.ToDTO()).ToList();
        }

    }
}
