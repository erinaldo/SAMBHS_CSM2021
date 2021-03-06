//-------------------------------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by EntitiesToDTOs.v3.2 (entitiestodtos.codeplex.com).
//     Timestamp: 2017/07/13 - 15:13:23
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
    /// Assembler for <see cref="agenciatransporte"/> and <see cref="agenciatransporteDto"/>.
    /// </summary>
    public static partial class agenciatransporteAssembler
    {
        /// <summary>
        /// Invoked when <see cref="ToDTO"/> operation is about to return.
        /// </summary>
        /// <param name="dto"><see cref="agenciatransporteDto"/> converted from <see cref="agenciatransporte"/>.</param>
        static partial void OnDTO(this agenciatransporte entity, agenciatransporteDto dto);

        /// <summary>
        /// Invoked when <see cref="ToEntity"/> operation is about to return.
        /// </summary>
        /// <param name="entity"><see cref="agenciatransporte"/> converted from <see cref="agenciatransporteDto"/>.</param>
        static partial void OnEntity(this agenciatransporteDto dto, agenciatransporte entity);

        /// <summary>
        /// Converts this instance of <see cref="agenciatransporteDto"/> to an instance of <see cref="agenciatransporte"/>.
        /// </summary>
        /// <param name="dto"><see cref="agenciatransporteDto"/> to convert.</param>
        public static agenciatransporte ToEntity(this agenciatransporteDto dto)
        {
            if (dto == null) return null;

            var entity = new agenciatransporte();

            entity.v_IdAgenciaTransporte = dto.v_IdAgenciaTransporte;
            entity.v_CodTransportista = dto.v_CodTransportista;
            entity.v_NombreRazonSocial = dto.v_NombreRazonSocial;
            entity.v_NombreContacto = dto.v_NombreContacto;
            entity.v_Direccion = dto.v_Direccion;
            entity.i_IdTipoPersona = dto.i_IdTipoPersona;
            entity.i_IdTipoIdentificacion = dto.i_IdTipoIdentificacion;
            entity.v_NumeroDocumento = dto.v_NumeroDocumento;
            entity.i_IdPais = dto.i_IdPais;
            entity.i_IdDepartamento = dto.i_IdDepartamento;
            entity.i_IdProvincia = dto.i_IdProvincia;
            entity.i_IdDistrito = dto.i_IdDistrito;
            entity.v_Telefono = dto.v_Telefono;
            entity.v_Fax = dto.v_Fax;
            entity.v_CorreoElectronico = dto.v_CorreoElectronico;
            entity.i_Eliminado = dto.i_Eliminado;
            entity.i_InsertaIdUsuario = dto.i_InsertaIdUsuario;
            entity.t_InsertaFecha = dto.t_InsertaFecha;
            entity.i_ActualizaIdUsuario = dto.i_ActualizaIdUsuario;
            entity.t_ActualizaFecha = dto.t_ActualizaFecha;

            dto.OnEntity(entity);

            return entity;
        }

        /// <summary>
        /// Converts this instance of <see cref="agenciatransporte"/> to an instance of <see cref="agenciatransporteDto"/>.
        /// </summary>
        /// <param name="entity"><see cref="agenciatransporte"/> to convert.</param>
        public static agenciatransporteDto ToDTO(this agenciatransporte entity)
        {
            if (entity == null) return null;

            var dto = new agenciatransporteDto();

            dto.v_IdAgenciaTransporte = entity.v_IdAgenciaTransporte;
            dto.v_CodTransportista = entity.v_CodTransportista;
            dto.v_NombreRazonSocial = entity.v_NombreRazonSocial;
            dto.v_NombreContacto = entity.v_NombreContacto;
            dto.v_Direccion = entity.v_Direccion;
            dto.i_IdTipoPersona = entity.i_IdTipoPersona;
            dto.i_IdTipoIdentificacion = entity.i_IdTipoIdentificacion;
            dto.v_NumeroDocumento = entity.v_NumeroDocumento;
            dto.i_IdPais = entity.i_IdPais;
            dto.i_IdDepartamento = entity.i_IdDepartamento;
            dto.i_IdProvincia = entity.i_IdProvincia;
            dto.i_IdDistrito = entity.i_IdDistrito;
            dto.v_Telefono = entity.v_Telefono;
            dto.v_Fax = entity.v_Fax;
            dto.v_CorreoElectronico = entity.v_CorreoElectronico;
            dto.i_Eliminado = entity.i_Eliminado;
            dto.i_InsertaIdUsuario = entity.i_InsertaIdUsuario;
            dto.t_InsertaFecha = entity.t_InsertaFecha;
            dto.i_ActualizaIdUsuario = entity.i_ActualizaIdUsuario;
            dto.t_ActualizaFecha = entity.t_ActualizaFecha;

            entity.OnDTO(dto);

            return dto;
        }

        /// <summary>
        /// Converts each instance of <see cref="agenciatransporteDto"/> to an instance of <see cref="agenciatransporte"/>.
        /// </summary>
        /// <param name="dtos"></param>
        /// <returns></returns>
        public static List<agenciatransporte> ToEntities(this IEnumerable<agenciatransporteDto> dtos)
        {
            if (dtos == null) return null;

            return dtos.Select(e => e.ToEntity()).ToList();
        }

        /// <summary>
        /// Converts each instance of <see cref="agenciatransporte"/> to an instance of <see cref="agenciatransporteDto"/>.
        /// </summary>
        /// <param name="entities"></param>
        /// <returns></returns>
        public static List<agenciatransporteDto> ToDTOs(this IEnumerable<agenciatransporte> entities)
        {
            if (entities == null) return null;

            return entities.Select(e => e.ToDTO()).ToList();
        }

    }
}
