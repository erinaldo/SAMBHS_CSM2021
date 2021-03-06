//-------------------------------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by EntitiesToDTOs.v3.2 (entitiestodtos.codeplex.com).
//     Timestamp: 2017/07/13 - 15:13:30
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
    /// Assembler for <see cref="flujoefectivoasientoajustedetalle"/> and <see cref="flujoefectivoasientoajustedetalleDto"/>.
    /// </summary>
    public static partial class flujoefectivoasientoajustedetalleAssembler
    {
        /// <summary>
        /// Invoked when <see cref="ToDTO"/> operation is about to return.
        /// </summary>
        /// <param name="dto"><see cref="flujoefectivoasientoajustedetalleDto"/> converted from <see cref="flujoefectivoasientoajustedetalle"/>.</param>
        static partial void OnDTO(this flujoefectivoasientoajustedetalle entity, flujoefectivoasientoajustedetalleDto dto);

        /// <summary>
        /// Invoked when <see cref="ToEntity"/> operation is about to return.
        /// </summary>
        /// <param name="entity"><see cref="flujoefectivoasientoajustedetalle"/> converted from <see cref="flujoefectivoasientoajustedetalleDto"/>.</param>
        static partial void OnEntity(this flujoefectivoasientoajustedetalleDto dto, flujoefectivoasientoajustedetalle entity);

        /// <summary>
        /// Converts this instance of <see cref="flujoefectivoasientoajustedetalleDto"/> to an instance of <see cref="flujoefectivoasientoajustedetalle"/>.
        /// </summary>
        /// <param name="dto"><see cref="flujoefectivoasientoajustedetalleDto"/> to convert.</param>
        public static flujoefectivoasientoajustedetalle ToEntity(this flujoefectivoasientoajustedetalleDto dto)
        {
            if (dto == null) return null;

            var entity = new flujoefectivoasientoajustedetalle();

            entity.i_IdAsientoAjusteDetalle = dto.i_IdAsientoAjusteDetalle;
            entity.i_IdAsientoAjuste = dto.i_IdAsientoAjuste;
            entity.v_NroCuenta = dto.v_NroCuenta;
            entity.v_Naturaleza = dto.v_Naturaleza;
            entity.d_Importe = dto.d_Importe;
            entity.d_Cambio = dto.d_Cambio;

            dto.OnEntity(entity);

            return entity;
        }

        /// <summary>
        /// Converts this instance of <see cref="flujoefectivoasientoajustedetalle"/> to an instance of <see cref="flujoefectivoasientoajustedetalleDto"/>.
        /// </summary>
        /// <param name="entity"><see cref="flujoefectivoasientoajustedetalle"/> to convert.</param>
        public static flujoefectivoasientoajustedetalleDto ToDTO(this flujoefectivoasientoajustedetalle entity)
        {
            if (entity == null) return null;

            var dto = new flujoefectivoasientoajustedetalleDto();

            dto.i_IdAsientoAjusteDetalle = entity.i_IdAsientoAjusteDetalle;
            dto.i_IdAsientoAjuste = entity.i_IdAsientoAjuste;
            dto.v_NroCuenta = entity.v_NroCuenta;
            dto.v_Naturaleza = entity.v_Naturaleza;
            dto.d_Importe = entity.d_Importe;
            dto.d_Cambio = entity.d_Cambio;

            entity.OnDTO(dto);

            return dto;
        }

        /// <summary>
        /// Converts each instance of <see cref="flujoefectivoasientoajustedetalleDto"/> to an instance of <see cref="flujoefectivoasientoajustedetalle"/>.
        /// </summary>
        /// <param name="dtos"></param>
        /// <returns></returns>
        public static List<flujoefectivoasientoajustedetalle> ToEntities(this IEnumerable<flujoefectivoasientoajustedetalleDto> dtos)
        {
            if (dtos == null) return null;

            return dtos.Select(e => e.ToEntity()).ToList();
        }

        /// <summary>
        /// Converts each instance of <see cref="flujoefectivoasientoajustedetalle"/> to an instance of <see cref="flujoefectivoasientoajustedetalleDto"/>.
        /// </summary>
        /// <param name="entities"></param>
        /// <returns></returns>
        public static List<flujoefectivoasientoajustedetalleDto> ToDTOs(this IEnumerable<flujoefectivoasientoajustedetalle> entities)
        {
            if (entities == null) return null;

            return entities.Select(e => e.ToDTO()).ToList();
        }

    }
}
