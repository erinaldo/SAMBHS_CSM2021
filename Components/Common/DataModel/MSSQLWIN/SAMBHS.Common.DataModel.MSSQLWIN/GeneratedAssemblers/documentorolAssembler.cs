//-------------------------------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by EntitiesToDTOs.v3.2 (entitiestodtos.codeplex.com).
//     Timestamp: 2017/07/13 - 15:12:30
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
    /// Assembler for <see cref="documentorol"/> and <see cref="documentorolDto"/>.
    /// </summary>
    public static partial class documentorolAssembler
    {
        /// <summary>
        /// Invoked when <see cref="ToDTO"/> operation is about to return.
        /// </summary>
        /// <param name="dto"><see cref="documentorolDto"/> converted from <see cref="documentorol"/>.</param>
        static partial void OnDTO(this documentorol entity, documentorolDto dto);

        /// <summary>
        /// Invoked when <see cref="ToEntity"/> operation is about to return.
        /// </summary>
        /// <param name="entity"><see cref="documentorol"/> converted from <see cref="documentorolDto"/>.</param>
        static partial void OnEntity(this documentorolDto dto, documentorol entity);

        /// <summary>
        /// Converts this instance of <see cref="documentorolDto"/> to an instance of <see cref="documentorol"/>.
        /// </summary>
        /// <param name="dto"><see cref="documentorolDto"/> to convert.</param>
        public static documentorol ToEntity(this documentorolDto dto)
        {
            if (dto == null) return null;

            var entity = new documentorol();

            entity.i_IdDocumentoRol = dto.i_IdDocumentoRol;
            entity.i_CodigoEnum = dto.i_CodigoEnum;
            entity.i_IdTipoDocumento = dto.i_IdTipoDocumento;
            entity.i_Eliminado = dto.i_Eliminado;
            entity.i_InsertaIdUsuario = dto.i_InsertaIdUsuario;
            entity.t_InsertaFecha = dto.t_InsertaFecha;
            entity.i_ActualizaIdUsuario = dto.i_ActualizaIdUsuario;
            entity.t_ActualizaFecha = dto.t_ActualizaFecha;

            dto.OnEntity(entity);

            return entity;
        }

        /// <summary>
        /// Converts this instance of <see cref="documentorol"/> to an instance of <see cref="documentorolDto"/>.
        /// </summary>
        /// <param name="entity"><see cref="documentorol"/> to convert.</param>
        public static documentorolDto ToDTO(this documentorol entity)
        {
            if (entity == null) return null;

            var dto = new documentorolDto();

            dto.i_IdDocumentoRol = entity.i_IdDocumentoRol;
            dto.i_CodigoEnum = entity.i_CodigoEnum;
            dto.i_IdTipoDocumento = entity.i_IdTipoDocumento;
            dto.i_Eliminado = entity.i_Eliminado;
            dto.i_InsertaIdUsuario = entity.i_InsertaIdUsuario;
            dto.t_InsertaFecha = entity.t_InsertaFecha;
            dto.i_ActualizaIdUsuario = entity.i_ActualizaIdUsuario;
            dto.t_ActualizaFecha = entity.t_ActualizaFecha;

            entity.OnDTO(dto);

            return dto;
        }

        /// <summary>
        /// Converts each instance of <see cref="documentorolDto"/> to an instance of <see cref="documentorol"/>.
        /// </summary>
        /// <param name="dtos"></param>
        /// <returns></returns>
        public static List<documentorol> ToEntities(this IEnumerable<documentorolDto> dtos)
        {
            if (dtos == null) return null;

            return dtos.Select(e => e.ToEntity()).ToList();
        }

        /// <summary>
        /// Converts each instance of <see cref="documentorol"/> to an instance of <see cref="documentorolDto"/>.
        /// </summary>
        /// <param name="entities"></param>
        /// <returns></returns>
        public static List<documentorolDto> ToDTOs(this IEnumerable<documentorol> entities)
        {
            if (entities == null) return null;

            return entities.Select(e => e.ToDTO()).ToList();
        }

    }
}
