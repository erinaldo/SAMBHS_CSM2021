//-------------------------------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by EntitiesToDTOs.v3.1 (entitiestodtos.codeplex.com).
//     Timestamp: 2017/10/02 - 15:30:15
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
    /// Assembler for <see cref="ventaimportaciondataconfig"/> and <see cref="ventaimportaciondataconfigDto"/>.
    /// </summary>
    public static partial class ventaimportaciondataconfigAssembler
    {
        /// <summary>
        /// Invoked when <see cref="ToDTO"/> operation is about to return.
        /// </summary>
        /// <param name="dto"><see cref="ventaimportaciondataconfigDto"/> converted from <see cref="ventaimportaciondataconfig"/>.</param>
        static partial void OnDTO(this ventaimportaciondataconfig entity, ventaimportaciondataconfigDto dto);

        /// <summary>
        /// Invoked when <see cref="ToEntity"/> operation is about to return.
        /// </summary>
        /// <param name="entity"><see cref="ventaimportaciondataconfig"/> converted from <see cref="ventaimportaciondataconfigDto"/>.</param>
        static partial void OnEntity(this ventaimportaciondataconfigDto dto, ventaimportaciondataconfig entity);

        /// <summary>
        /// Converts this instance of <see cref="ventaimportaciondataconfigDto"/> to an instance of <see cref="ventaimportaciondataconfig"/>.
        /// </summary>
        /// <param name="dto"><see cref="ventaimportaciondataconfigDto"/> to convert.</param>
        public static ventaimportaciondataconfig ToEntity(this ventaimportaciondataconfigDto dto)
        {
            if (dto == null) return null;

            var entity = new ventaimportaciondataconfig();

            entity.i_Id = dto.i_Id;
            entity.v_CtaVenta = dto.v_CtaVenta;
            entity.v_CtaEfectivo = dto.v_CtaEfectivo;
            entity.v_CtaVisa = dto.v_CtaVisa;
            entity.v_CtaMastercard = dto.v_CtaMastercard;
            entity.v_CtaAmericanExpress = dto.v_CtaAmericanExpress;
            entity.i_IdDocumentoAmericanExpress = dto.i_IdDocumentoAmericanExpress;
            entity.i_IdDocumentoEfectivo = dto.i_IdDocumentoEfectivo;
            entity.i_IdDocumentoMastercard = dto.i_IdDocumentoMastercard;
            entity.i_IdDocumentoVisa = dto.i_IdDocumentoVisa;

            dto.OnEntity(entity);

            return entity;
        }

        /// <summary>
        /// Converts this instance of <see cref="ventaimportaciondataconfig"/> to an instance of <see cref="ventaimportaciondataconfigDto"/>.
        /// </summary>
        /// <param name="entity"><see cref="ventaimportaciondataconfig"/> to convert.</param>
        public static ventaimportaciondataconfigDto ToDTO(this ventaimportaciondataconfig entity)
        {
            if (entity == null) return null;

            var dto = new ventaimportaciondataconfigDto();

            dto.i_Id = entity.i_Id;
            dto.v_CtaVenta = entity.v_CtaVenta;
            dto.v_CtaEfectivo = entity.v_CtaEfectivo;
            dto.v_CtaVisa = entity.v_CtaVisa;
            dto.v_CtaMastercard = entity.v_CtaMastercard;
            dto.v_CtaAmericanExpress = entity.v_CtaAmericanExpress;
            dto.i_IdDocumentoAmericanExpress = entity.i_IdDocumentoAmericanExpress??1;
            dto.i_IdDocumentoEfectivo = entity.i_IdDocumentoEfectivo ?? 1;
            dto.i_IdDocumentoMastercard = entity.i_IdDocumentoMastercard ?? 1;
            dto.i_IdDocumentoVisa = entity.i_IdDocumentoVisa ?? 1;
            entity.OnDTO(dto);

            return dto;
        }

        /// <summary>
        /// Converts each instance of <see cref="ventaimportaciondataconfigDto"/> to an instance of <see cref="ventaimportaciondataconfig"/>.
        /// </summary>
        /// <param name="dtos"></param>
        /// <returns></returns>
        public static List<ventaimportaciondataconfig> ToEntities(this IEnumerable<ventaimportaciondataconfigDto> dtos)
        {
            if (dtos == null) return null;

            return dtos.Select(e => e.ToEntity()).ToList();
        }

        /// <summary>
        /// Converts each instance of <see cref="ventaimportaciondataconfig"/> to an instance of <see cref="ventaimportaciondataconfigDto"/>.
        /// </summary>
        /// <param name="entities"></param>
        /// <returns></returns>
        public static List<ventaimportaciondataconfigDto> ToDTOs(this IEnumerable<ventaimportaciondataconfig> entities)
        {
            if (entities == null) return null;

            return entities.Select(e => e.ToDTO()).ToList();
        }

    }
}
