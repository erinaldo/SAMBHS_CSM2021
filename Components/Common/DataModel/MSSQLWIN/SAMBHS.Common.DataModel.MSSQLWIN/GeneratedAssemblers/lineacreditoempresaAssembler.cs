//-------------------------------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by EntitiesToDTOs.v3.2 (entitiestodtos.codeplex.com).
//     Timestamp: 2017/07/13 - 15:12:33
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
    /// Assembler for <see cref="lineacreditoempresa"/> and <see cref="lineacreditoempresaDto"/>.
    /// </summary>
    public static partial class lineacreditoempresaAssembler
    {
        /// <summary>
        /// Invoked when <see cref="ToDTO"/> operation is about to return.
        /// </summary>
        /// <param name="dto"><see cref="lineacreditoempresaDto"/> converted from <see cref="lineacreditoempresa"/>.</param>
        static partial void OnDTO(this lineacreditoempresa entity, lineacreditoempresaDto dto);

        /// <summary>
        /// Invoked when <see cref="ToEntity"/> operation is about to return.
        /// </summary>
        /// <param name="entity"><see cref="lineacreditoempresa"/> converted from <see cref="lineacreditoempresaDto"/>.</param>
        static partial void OnEntity(this lineacreditoempresaDto dto, lineacreditoempresa entity);

        /// <summary>
        /// Converts this instance of <see cref="lineacreditoempresaDto"/> to an instance of <see cref="lineacreditoempresa"/>.
        /// </summary>
        /// <param name="dto"><see cref="lineacreditoempresaDto"/> to convert.</param>
        public static lineacreditoempresa ToEntity(this lineacreditoempresaDto dto)
        {
            if (dto == null) return null;

            var entity = new lineacreditoempresa();

            entity.i_IdLineaPrecio = dto.i_IdLineaPrecio;
            entity.v_IdCliente = dto.v_IdCliente;
            entity.i_IdMoneda = dto.i_IdMoneda;
            entity.d_Credito = dto.d_Credito;
            entity.d_Acuenta = dto.d_Acuenta;
            entity.d_Saldo = dto.d_Saldo;

            dto.OnEntity(entity);

            return entity;
        }

        /// <summary>
        /// Converts this instance of <see cref="lineacreditoempresa"/> to an instance of <see cref="lineacreditoempresaDto"/>.
        /// </summary>
        /// <param name="entity"><see cref="lineacreditoempresa"/> to convert.</param>
        public static lineacreditoempresaDto ToDTO(this lineacreditoempresa entity)
        {
            if (entity == null) return null;

            var dto = new lineacreditoempresaDto();

            dto.i_IdLineaPrecio = entity.i_IdLineaPrecio;
            dto.v_IdCliente = entity.v_IdCliente;
            dto.i_IdMoneda = entity.i_IdMoneda;
            dto.d_Credito = entity.d_Credito;
            dto.d_Acuenta = entity.d_Acuenta;
            dto.d_Saldo = entity.d_Saldo;

            entity.OnDTO(dto);

            return dto;
        }

        /// <summary>
        /// Converts each instance of <see cref="lineacreditoempresaDto"/> to an instance of <see cref="lineacreditoempresa"/>.
        /// </summary>
        /// <param name="dtos"></param>
        /// <returns></returns>
        public static List<lineacreditoempresa> ToEntities(this IEnumerable<lineacreditoempresaDto> dtos)
        {
            if (dtos == null) return null;

            return dtos.Select(e => e.ToEntity()).ToList();
        }

        /// <summary>
        /// Converts each instance of <see cref="lineacreditoempresa"/> to an instance of <see cref="lineacreditoempresaDto"/>.
        /// </summary>
        /// <param name="entities"></param>
        /// <returns></returns>
        public static List<lineacreditoempresaDto> ToDTOs(this IEnumerable<lineacreditoempresa> entities)
        {
            if (entities == null) return null;

            return entities.Select(e => e.ToDTO()).ToList();
        }

    }
}
